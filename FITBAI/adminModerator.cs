using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class adminModerator : Form
    {
        private string _mediaVaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MediaVault");
        private System.Windows.Forms.Timer autoRefreshTimer;
        public adminModerator()
        {
            InitializeComponent();

            // Setup 60s Auto Refresh[cite: 8]
            autoRefreshTimer = new System.Windows.Forms.Timer();
            autoRefreshTimer.Interval = 60000;
            autoRefreshTimer.Tick += (s, e) => LoadFlaggedQueue();

            this.Load += AdminModerator_Load;
            lblTitle.Paint += TitleGradient_Paint;
            dgvFlaggedPosts.CellContentClick += DgvFlaggedPosts_CellContentClick;
        }

        private void AdminModerator_Load(object? sender, EventArgs e)
        {
            LoadFlaggedQueue();
            autoRefreshTimer.Start();
        }

        private void LoadFlaggedQueue()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT p.postID, u.username, p.post_text, p.flag_count, p.post_date, p.media_path 
                        FROM community_posts p
                        INNER JOIN users u ON p.clientID = u.clientID
                        WHERE p.flag_count > 0
                        ORDER BY p.flag_count DESC, p.post_date DESC";
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvFlaggedPosts.DataSource = dt;

                        // Update dynamic title with queue size[cite: 8]
                        lblQueueTitle.Text = $"FLAGGED CONTENT QUEUE ({dt.Rows.Count} pending)";

                        if (dgvFlaggedPosts.Columns["postID"] is DataGridViewColumn c1) c1.Visible = false;
                        if (dgvFlaggedPosts.Columns["media_path"] is DataGridViewColumn c2) c2.Visible = false;
                        if (dgvFlaggedPosts.Columns["username"] is DataGridViewColumn c3) c3.HeaderText = "AUTHOR";
                        if (dgvFlaggedPosts.Columns["post_text"] is DataGridViewColumn c4) c4.HeaderText = "MESSAGE";
                        if (dgvFlaggedPosts.Columns["flag_count"] is DataGridViewColumn c5) c5.HeaderText = "FLAGS";
                        if (dgvFlaggedPosts.Columns["post_date"] is DataGridViewColumn c6) c6.HeaderText = "DATE";

                        if (!dgvFlaggedPosts.Columns.Contains("ReviewBtn"))
                        {
                            DataGridViewButtonColumn revBtn = new DataGridViewButtonColumn { Name = "ReviewBtn", HeaderText = "EVIDENCE", Text = "🔍 REVIEW", UseColumnTextForButtonValue = true };
                            dgvFlaggedPosts.Columns.Add(revBtn);
                        }
                        if (!dgvFlaggedPosts.Columns.Contains("PardonBtn"))
                        {
                            DataGridViewButtonColumn parBtn = new DataGridViewButtonColumn { Name = "PardonBtn", HeaderText = "CLEAR", Text = "✅ PARDON", UseColumnTextForButtonValue = true };
                            dgvFlaggedPosts.Columns.Add(parBtn);
                        }
                        if (!dgvFlaggedPosts.Columns.Contains("PurgeBtn"))
                        {
                            DataGridViewButtonColumn purgeBtn = new DataGridViewButtonColumn { Name = "PurgeBtn", HeaderText = "DELETE", Text = "☢️ PURGE", UseColumnTextForButtonValue = true };
                            dgvFlaggedPosts.Columns.Add(purgeBtn);
                        }
                    }
                }
            }
            catch { }
        }

        private void DgvFlaggedPosts_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var rawPostId = dgvFlaggedPosts.Rows[e.RowIndex].Cells["postID"]?.Value;
            if (rawPostId == null || rawPostId == DBNull.Value) return;

            int postId = Convert.ToInt32(rawPostId);
            string? fileName = dgvFlaggedPosts.Rows[e.RowIndex].Cells["media_path"].Value?.ToString();

            if (dgvFlaggedPosts.Columns[e.ColumnIndex].Name == "ReviewBtn")
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    string fullPath = Path.Combine(_mediaVaultPath, fileName);
                    if (File.Exists(fullPath)) System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fullPath) { UseShellExecute = true });
                }
            }
            else if (dgvFlaggedPosts.Columns[e.ColumnIndex].Name == "PardonBtn")
            {
                if (MessageBox.Show("Pardon this post?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExecutePardon(postId);
                }
            }
            else if (dgvFlaggedPosts.Columns[e.ColumnIndex].Name == "PurgeBtn")
            {
                if (MessageBox.Show("Permanently delete this post?", "Confirm Purge", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ExecutePurge(postId, fileName);
                }
            }
        }

        private void ExecutePardon(int postId)
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Reset flags to 0
                    using (OleDbCommand cmd = new OleDbCommand("UPDATE community_posts SET flag_count = 0 WHERE postID = @pid", conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", postId);
                        cmd.ExecuteNonQuery();
                    }
                    // Optional Pardon Notification could be added to an Inbox table here[cite: 8]
                }
                LoadFlaggedQueue();
            }
            catch { }
        }

        private void ExecutePurge(int postId, string? fileName)
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand("DELETE FROM community_posts WHERE postID = @pid", conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", postId);
                        cmd.ExecuteNonQuery();
                    }

                    // Cleanup junction tables to keep DB clean[cite: 8]
                    try { new OleDbCommand("DELETE FROM community_flags WHERE postID = " + postId, conn).ExecuteNonQuery(); } catch { }
                    try { new OleDbCommand("DELETE FROM community_likes WHERE postID = " + postId, conn).ExecuteNonQuery(); } catch { }
                }

                if (!string.IsNullOrEmpty(fileName))
                {
                    string fullPath = Path.Combine(_mediaVaultPath, fileName);
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath); // Safely delete[cite: 8]
                    }
                }

                LoadFlaggedQueue();
            }
            catch (Exception ex) { MessageBox.Show("Purge failed: " + ex.Message); }
        }

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle, Color.FromArgb(200, 80, 80), Color.FromArgb(255, 120, 80), LinearGradientMode.Horizontal);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
            }
        }
    }
}