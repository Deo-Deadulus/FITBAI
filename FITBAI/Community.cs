using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class Community : Form
    {
        // --- CONSTANTS ---
        private const int CARD_WIDTH = 320;
        private const int CARD_HEIGHT = 470;
        private const int PIC_WIDTH = 300;
        private const int PIC_HEIGHT = 260;

        private int _currentClientId = 0;
        private string? selectedFilePath = null;
        private string _mediaVaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MediaVault");

        // Background worker for loading posts
        private BackgroundWorker feedLoader;
        private Label lblEmptyState;

        public Community()
        {
            InitializeComponent();

            feedLoader = new BackgroundWorker();
            feedLoader.DoWork += FeedLoader_DoWork;
            feedLoader.RunWorkerCompleted += FeedLoader_RunWorkerCompleted;

            // Empty state setup
            lblEmptyState = new Label();
            lblEmptyState.Text = "No posts yet. Be the first to broadcast your progress!";
            lblEmptyState.ForeColor = Color.Gray;
            lblEmptyState.Font = new Font("Segoe UI", 16F, FontStyle.Italic);
            lblEmptyState.AutoSize = true;
            lblEmptyState.Visible = false;

            this.Load += Community_Load;
            btnPost.Paint += PrimaryButton_Paint;
            btnAttach.Click += BtnAttach_Click;
            btnPost.Click += BtnPost_Click;
        }

        private void Community_Load(object? sender, EventArgs e)
        {
            if (!Directory.Exists(_mediaVaultPath)) Directory.CreateDirectory(_mediaVaultPath);
            flowFeed.Controls.Add(lblEmptyState);

            FetchClientId();
            EnsureDatabaseSchema();

            // Start async load
            lblFeedTitle.Text = "VISUAL PROOF FEED (Loading...)";
            feedLoader.RunWorkerAsync();
        }

        private void FetchClientId()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand("SELECT clientID FROM users WHERE username = @u", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", AppFlowManager.CurrentUsername);
                        object? res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) _currentClientId = Convert.ToInt32(res);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Identity Error: " + ex.Message); }
        }

        // ==========================================
        // SCHEMA ENFORCEMENT
        // ==========================================
        private void EnsureDatabaseSchema()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Ensure flag_count exists
                    try { new OleDbCommand("SELECT TOP 1 flag_count FROM community_posts", conn).ExecuteScalar(); }
                    catch { new OleDbCommand("ALTER TABLE community_posts ADD COLUMN flag_count INT DEFAULT 0", conn).ExecuteNonQuery(); }

                    // 2. Create Junction Tables for Spam Prevention
                    try { new OleDbCommand("SELECT TOP 1 1 FROM community_flags", conn).ExecuteScalar(); }
                    catch { new OleDbCommand("CREATE TABLE community_flags (postID INT, clientID INT, PRIMARY KEY (postID, clientID))", conn).ExecuteNonQuery(); }

                    try { new OleDbCommand("SELECT TOP 1 1 FROM community_likes", conn).ExecuteScalar(); }
                    catch { new OleDbCommand("CREATE TABLE community_likes (postID INT, clientID INT, PRIMARY KEY (postID, clientID))", conn).ExecuteNonQuery(); }

                    // 3. Create Indexes
                    try { new OleDbCommand("CREATE INDEX idx_client ON community_posts(clientID)", conn).ExecuteNonQuery(); } catch { }
                    try { new OleDbCommand("CREATE INDEX idx_date ON community_posts(post_date)", conn).ExecuteNonQuery(); } catch { }
                }
            }
            catch { /* Ignore schema errors if tables exist */ }
        }

        // ==========================================
        // ASYNC FEED LOADING
        // ==========================================
        private void FeedLoader_DoWork(object? sender, DoWorkEventArgs e)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT p.postID, p.clientID, u.username, p.post_text, p.post_date,
                           p.likes_count, p.flag_count, p.media_path
                    FROM community_posts p
                    INNER JOIN users u ON p.clientID = u.clientID
                    WHERE p.media_path IS NOT NULL AND p.media_path <> ''
                    ORDER BY p.post_date DESC";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            e.Result = dt;
        }

        private void FeedLoader_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Feed Error: " + e.Error.Message);
                return;
            }

            lblFeedTitle.Text = "VISUAL PROOF FEED";

            // Explicitly dispose old controls to prevent memory leaks
            foreach (Control c in flowFeed.Controls)
            {
                if (c is Panel pnl)
                {
                    foreach (Control child in pnl.Controls)
                    {
                        if (child is PictureBox pb && pb.Image != null) pb.Image.Dispose();
                        child.Dispose();
                    }
                    pnl.Dispose();
                }
            }
            flowFeed.Controls.Clear();
            flowFeed.Controls.Add(lblEmptyState);

            DataTable dt = (DataTable)e.Result!;
            if (dt.Rows.Count == 0)
            {
                lblEmptyState.Visible = true;
                return;
            }

            lblEmptyState.Visible = false;

            foreach (DataRow row in dt.Rows)
            {
                int postId = Convert.ToInt32(row["postID"]);
                int postOwnerId = Convert.ToInt32(row["clientID"]);
                string username = row["username"].ToString()!;
                string caption = row["post_text"].ToString()!;

                // Handle Date parsing securely
                DateTime parsedDate;
                string dateStr = row["post_date"].ToString()!;
                string displayDate = DateTime.TryParse(dateStr, out parsedDate) ? parsedDate.ToString("g") : dateStr;

                int likes = Convert.ToInt32(row["likes_count"]);
                int flags = row["flag_count"] == DBNull.Value ? 0 : Convert.ToInt32(row["flag_count"]);
                string fileName = row["media_path"].ToString()!;

                string fullPath = Path.Combine(_mediaVaultPath, fileName);
                bool isOwnPost = (postOwnerId == _currentClientId);
                CreatePostCard(postId, username, caption, displayDate, likes, flags, fullPath, fileName, isOwnPost);
            }
        }

        // ==========================================
        // CARD BUILDER
        // ==========================================
        private void CreatePostCard(int postId, string username, string caption, string date,
                                    int likes, int flags, string fullPath, string fileName, bool isOwnPost)
        {
            Panel card = new Panel();
            card.Size = new Size(CARD_WIDTH, CARD_HEIGHT);
            card.BackColor = Color.FromArgb(20, 25, 60);
            card.Margin = new Padding(15);
            card.BorderStyle = BorderStyle.FixedSingle;

            PictureBox pic = new PictureBox();
            pic.Size = new Size(PIC_WIDTH, PIC_HEIGHT);
            pic.Location = new Point(10, 10);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Cursor = Cursors.Hand;
            pic.BackColor = Color.FromArgb(10, 15, 30);

            string ext = Path.GetExtension(fileName).ToLower();
            bool isVideo = ext == ".mp4" || ext == ".mov";

            if (!isVideo && File.Exists(fullPath))
            {
                try
                {
                    using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        pic.Image = Image.FromStream(fs); // Keeps file unlocked
                    }
                }
                catch { }
            }

            if (isVideo || pic.Image == null)
            {
                pic.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(80, 120, 255)))
                    {
                        Point[] triangle = { new Point(120, 100), new Point(120, 160), new Point(175, 130) };
                        e.Graphics.FillPolygon(brush, triangle);
                    }
                    if (isVideo)
                    {
                        e.Graphics.DrawString(fileName, new Font("Segoe UI", 8), Brushes.White, new Point(10, 235));
                    }
                };
            }

            pic.Click += (s, e) =>
            {
                if (File.Exists(fullPath)) Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
                else MessageBox.Show("Media file is missing.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            Label lblUser = new Label();
            lblUser.Text = "🏋 " + username.ToUpper();
            lblUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUser.ForeColor = Color.FromArgb(170, 200, 255);
            lblUser.BackColor = Color.FromArgb(120, 15, 20, 50);
            lblUser.AutoSize = false;
            lblUser.Size = new Size(180, 24);
            lblUser.Location = new Point(0, 0);
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            lblUser.Padding = new Padding(5, 0, 0, 0);
            pic.Controls.Add(lblUser);

            // FIX: Button placed at PIC_WIDTH - 45 (255, 5) instead of (265, 0)
            // to ensure it is fully visible and not clipped by the PictureBox boundary.
            if (isOwnPost)
            {
                Button btnDelete = new Button();
                btnDelete.Text = "✕";
                btnDelete.Size = new Size(35, 35);
                btnDelete.Location = new Point(PIC_WIDTH - 45, 5); // Fixed: was Point(265, 0)
                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.BackColor = Color.FromArgb(180, 40, 60);
                btnDelete.ForeColor = Color.White;
                btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                btnDelete.Cursor = Cursors.Hand;
                btnDelete.Click += (s, e) => DeletePost(postId, fullPath, card, pic);
                pic.Controls.Add(btnDelete);
            }
            else
            {
                Button btnFlag = new Button();
                btnFlag.Text = "🚩";
                btnFlag.Size = new Size(35, 35);
                btnFlag.Location = new Point(PIC_WIDTH - 45, 5); // Fixed: was Point(265, 0)
                btnFlag.FlatStyle = FlatStyle.Flat;
                btnFlag.FlatAppearance.BorderSize = 0;
                btnFlag.BackColor = Color.FromArgb(120, 30, 20, 20);
                btnFlag.ForeColor = Color.White;
                btnFlag.Font = new Font("Segoe UI", 10F);
                btnFlag.Cursor = Cursors.Hand;
                btnFlag.Click += (s, e) => FlagPost(postId, btnFlag);
                pic.Controls.Add(btnFlag);
            }

            Label lblCap = new Label();
            lblCap.Text = string.IsNullOrWhiteSpace(caption) ? "No caption" : caption;
            lblCap.ForeColor = Color.White;
            lblCap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCap.Location = new Point(10, 280);
            lblCap.AutoSize = true;
            lblCap.MaximumSize = new Size(300, 40);

            Label lblDate = new Label();
            lblDate.Text = date;
            lblDate.ForeColor = Color.FromArgb(150, 160, 200);
            lblDate.Font = new Font("Segoe UI", 8F);
            lblDate.Location = new Point(10, 322);
            lblDate.AutoSize = true;

            Label lblFlagCount = new Label();
            lblFlagCount.Text = flags > 0 ? $"⚠️ {flags} report(s)" : "";
            lblFlagCount.ForeColor = Color.FromArgb(255, 160, 60);
            lblFlagCount.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFlagCount.Location = new Point(10, 342);
            lblFlagCount.AutoSize = true;

            Label lblLikes = new Label();
            lblLikes.Text = $"👍 {likes}";
            lblLikes.ForeColor = Color.White;
            lblLikes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLikes.Location = new Point(10, 400);
            lblLikes.AutoSize = true;

            Button btnLike = new Button();
            btnLike.Text = "LIKE";
            btnLike.Size = new Size(90, 32);
            btnLike.Location = new Point(210, 395);
            btnLike.FlatStyle = FlatStyle.Flat;
            btnLike.FlatAppearance.BorderColor = Color.FromArgb(80, 120, 255);
            btnLike.FlatAppearance.BorderSize = 1;
            btnLike.BackColor = Color.FromArgb(30, 40, 90);
            btnLike.ForeColor = Color.White;
            btnLike.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLike.Cursor = Cursors.Hand;
            btnLike.Click += (s, e) => LikePost(postId, lblLikes, btnLike);

            card.Controls.Add(pic);
            card.Controls.Add(lblCap);
            card.Controls.Add(lblDate);
            card.Controls.Add(lblFlagCount);
            card.Controls.Add(lblLikes);
            card.Controls.Add(btnLike);

            flowFeed.Controls.Add(card);
        }

        // ==========================================
        // ACTIONS
        // ==========================================
        private void BtnAttach_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Media Files|*.jpg;*.jpeg;*.png;*.mp4;*.mov" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;
                    lblFileName.Text = "📎 " + Path.GetFileName(selectedFilePath);
                    lblFileName.ForeColor = Color.LimeGreen;
                }
            }
        }

        private void BtnPost_Click(object? sender, EventArgs e)
        {
            if (_currentClientId == 0) return;

            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Media proof is mandatory!", "Upload Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string ext = Path.GetExtension(selectedFilePath);
                string fileName = $"COMM_{_currentClientId}_{DateTime.Now:yyyyMMddHHmmss}{ext}";
                string destPath = Path.Combine(_mediaVaultPath, fileName);
                File.Copy(selectedFilePath, destPath);

                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO community_posts (clientID, post_text, post_date, likes_count, media_path, flag_count) VALUES (@cid, @txt, @date, 0, @path, 0)";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        cmd.Parameters.AddWithValue("@txt", txtNewPost.Text?.Trim() ?? "");
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@path", fileName);
                        cmd.ExecuteNonQuery();
                    }
                }

                txtNewPost.Clear();
                selectedFilePath = null;
                lblFileName.Text = "No file selected";
                lblFileName.ForeColor = Color.Gray;

                MessageBox.Show("Progress broadcasted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                feedLoader.RunWorkerAsync(); // Reload
            }
            catch (Exception ex) { MessageBox.Show("Broadcast Failed: " + ex.Message); }
        }

        private void LikePost(int postId, Label lblLikes, Button btnLike)
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Junction Table Anti-Spam Check
                    using (OleDbCommand check = new OleDbCommand("SELECT COUNT(*) FROM community_likes WHERE postID = @pid AND clientID = @cid", conn))
                    {
                        check.Parameters.AddWithValue("@pid", postId);
                        check.Parameters.AddWithValue("@cid", _currentClientId);
                        int count = Convert.ToInt32(check.ExecuteScalar());
                        if (count > 0) return; // Already liked
                    }

                    // Insert Like Record
                    using (OleDbCommand insert = new OleDbCommand("INSERT INTO community_likes (postID, clientID) VALUES (@pid, @cid)", conn))
                    {
                        insert.Parameters.AddWithValue("@pid", postId);
                        insert.Parameters.AddWithValue("@cid", _currentClientId);
                        insert.ExecuteNonQuery();
                    }

                    // Increment Counter
                    using (OleDbCommand cmd = new OleDbCommand("UPDATE community_posts SET likes_count = likes_count + 1 WHERE postID = @pid", conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", postId);
                        cmd.ExecuteNonQuery();
                    }

                    using (OleDbCommand cmd2 = new OleDbCommand("SELECT likes_count FROM community_posts WHERE postID = @pid", conn))
                    {
                        cmd2.Parameters.AddWithValue("@pid", postId);
                        object? res = cmd2.ExecuteScalar();
                        if (res != null) lblLikes.Text = $"👍 {res}";
                    }

                    btnLike.BackColor = Color.LimeGreen;
                    btnLike.Enabled = false;
                }
            }
            catch { }
        }

        private void FlagPost(int postId, Button btnFlag)
        {
            DialogResult confirm = MessageBox.Show("Report this post?", "Report Content", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Junction Table Anti-Spam Check
                    using (OleDbCommand check = new OleDbCommand("SELECT COUNT(*) FROM community_flags WHERE postID = @pid AND clientID = @cid", conn))
                    {
                        check.Parameters.AddWithValue("@pid", postId);
                        check.Parameters.AddWithValue("@cid", _currentClientId);
                        int count = Convert.ToInt32(check.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("You have already reported this post.");
                            return;
                        }
                    }

                    using (OleDbCommand insert = new OleDbCommand("INSERT INTO community_flags (postID, clientID) VALUES (@pid, @cid)", conn))
                    {
                        insert.Parameters.AddWithValue("@pid", postId);
                        insert.Parameters.AddWithValue("@cid", _currentClientId);
                        insert.ExecuteNonQuery();
                    }

                    using (OleDbCommand cmd = new OleDbCommand("UPDATE community_posts SET flag_count = flag_count + 1 WHERE postID = @pid", conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", postId);
                        cmd.ExecuteNonQuery();
                    }
                }

                btnFlag.BackColor = Color.FromArgb(200, 50, 50);
                btnFlag.Enabled = false; // Prevent Session Double Flagging
                MessageBox.Show("Post has been flagged.", "Report Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }

        private void DeletePost(int postId, string fullPath, Panel card, PictureBox pic)
        {
            DialogResult confirm = MessageBox.Show("Remove this post from the feed?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Explicit Ownership Check on Delete
                    using (OleDbCommand cmd = new OleDbCommand("DELETE FROM community_posts WHERE postID = @pid AND clientID = @cid", conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", postId);
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0) return; // Denied
                    }
                }

                // Explicitly dispose of image before deleting
                if (pic.Image != null)
                {
                    pic.Image.Dispose();
                    pic.Image = null;
                }

                if (File.Exists(fullPath)) File.Delete(fullPath);

                flowFeed.Controls.Remove(card);
                card.Dispose();
            }
            catch (Exception ex) { MessageBox.Show("Delete failed: " + ex.Message); }
        }

        private void PrimaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(80, 120, 255), Color.FromArgb(140, 60, 255), LinearGradientMode.Horizontal))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}