using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class instructorOverview : Form
    {
        // ==========================================
        // GLOBAL TRACKERS
        // ==========================================
        private int activeClientID = -1;
        private int currentInstructorID = -1;

        public instructorOverview()
        {
            InitializeComponent();
            StyleGrids();

            lblTitle.Paint += TitleGradient_Paint;
            btnReviewMedia.Paint += PrimaryButton_Paint;

            this.Load += InstructorOverview_Load;
            dgvClients.CellClick += DgvClients_CellClick;
        }

        private void InstructorOverview_Load(object? sender, EventArgs e)
        {
            FetchInstructorID();
            LoadClientRoster();
        }

        // ==========================================
        // DATABASE OPERATIONS & INTELLIGENCE
        // ==========================================
        private void FetchInstructorID()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // FIX: OleDb requires positional ? placeholders, not named @params
                    string query = @"SELECT i.instructorID 
                                     FROM instructors i 
                                     INNER JOIN users u ON i.clientID = u.clientID 
                                     WHERE u.username = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", AppFlowManager.CurrentUsername);
                        object result = cmd.ExecuteScalar();
                        if (result != null) currentInstructorID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to verify instructor identity: " + ex.Message); }
        }

        private void LoadClientRoster()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // FIX: OleDb requires positional ? placeholders, not named @instID
                    string query = @"SELECT clientID, full_name, primary_goal, weight_kg 
                                     FROM users 
                                     WHERE [role] = 'Client' 
                                     AND status = 'Active' 
                                     AND assigned_instructor = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", currentInstructorID);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvClients.DataSource = dt;

                        dgvClients.Columns["clientID"].Visible = false;
                        dgvClients.Columns["full_name"].HeaderText = "CLIENT NAME";
                        dgvClients.Columns["primary_goal"].HeaderText = "GOAL";
                        dgvClients.Columns["weight_kg"].HeaderText = "WEIGHT (KG)";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load client roster: " + ex.Message); }
        }

        private void DgvClients_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClients.CurrentRow != null)
            {
                activeClientID = Convert.ToInt32(dgvClients.CurrentRow.Cells["clientID"].Value);

                string clientName = dgvClients.CurrentRow.Cells["full_name"].Value.ToString() ?? "Unknown";
                lblSelectedClient.Text = $"MONITORING: {clientName.ToUpper()}";

                LoadClientActivity(activeClientID);
                LoadClientMedia(activeClientID);
            }
        }

        private void LoadClientActivity(int clientID)
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // FIX: OleDb requires positional ? placeholders, not named @id
                    string query = "SELECT log_date, weight_kg, water_glasses, workout_done, rpe_score FROM activity_logs WHERE clientID = ? ORDER BY log_date DESC";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", clientID);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvActivity.DataSource = dt;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Activity sync failed: " + ex.Message); }
        }

        private void LoadClientMedia(int clientID)
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // FIX: OleDb requires positional ? placeholders, not named @id
                    string query = "SELECT mediaID, upload_date, media_type, caption, instructor_feedback, file_path FROM gallery_logs WHERE clientID = ? ORDER BY upload_date DESC";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", clientID);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvMedia.DataSource = dt;

                        dgvMedia.Columns["mediaID"].Visible = false;
                        dgvMedia.Columns["file_path"].Visible = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Media sync failed: " + ex.Message); }
        }

        private void btnReviewMedia_Click(object sender, EventArgs e)
        {
            if (dgvMedia.CurrentRow == null)
            {
                MessageBox.Show("Select a media file from the Gallery Logs to review.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int mediaID = Convert.ToInt32(dgvMedia.CurrentRow.Cells["mediaID"].Value);
            string type = dgvMedia.CurrentRow.Cells["media_type"].Value.ToString() ?? "Image";
            string caption = dgvMedia.CurrentRow.Cells["caption"].Value.ToString() ?? "";
            string rawFilePath = dgvMedia.CurrentRow.Cells["file_path"].Value.ToString() ?? "";

            string finalFilePath = rawFilePath;
            if (!string.IsNullOrWhiteSpace(rawFilePath) && !rawFilePath.Contains(":\\"))
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                finalFilePath = System.IO.Path.Combine(baseDir, "MediaVault", rawFilePath);
            }

            using (instructorMediaViewer viewerPopup = new instructorMediaViewer(mediaID, type, caption, finalFilePath))
            {
                DialogResult result = viewerPopup.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadClientMedia(activeClientID);
                }
            }
        }

        // ==========================================
        // UI STYLING ENGINE
        // ==========================================
        private void StyleGrids()
        {
            DataGridView[] grids = { dgvClients, dgvActivity, dgvMedia };
            foreach (var g in grids)
            {
                g.BackgroundColor = Color.FromArgb(20, 25, 35);
                g.GridColor = Color.FromArgb(40, 50, 70);
                g.EnableHeadersVisualStyles = false;
                g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136);
                g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                g.DefaultCellStyle.BackColor = Color.FromArgb(15, 20, 30);
                g.DefaultCellStyle.ForeColor = Color.White;
                g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 188, 212);
                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                g.RowHeadersVisible = false;
                g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                g.ReadOnly = true;
                g.AllowUserToAddRows = false;
            }
        }

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle, Color.FromArgb(0, 255, 200), Color.FromArgb(0, 150, 255), LinearGradientMode.Horizontal);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
            }
        }

        private void PrimaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(0, 150, 136), Color.FromArgb(0, 100, 100), LinearGradientMode.Vertical))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}