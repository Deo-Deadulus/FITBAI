using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class Gallery : Form
    {
        private int _currentClientId = 0;
        private string _selectedFilePath = "";
        private string _mediaVaultPath = "";

        public Gallery()
        {
            InitializeComponent();

            cardUpload.Paint += Card_Paint;
            lblMainTitle.Paint += TitleGradient_Paint;
            btnUpload.Paint += PrimaryButton_Paint;

            // Define the local storage directory
            _mediaVaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MediaVault");
            if (!Directory.Exists(_mediaVaultPath)) Directory.CreateDirectory(_mediaVaultPath);

            this.Load += Gallery_Load;
            btnSelectMedia.Click += BtnSelectMedia_Click;
            btnUpload.Click += BtnUpload_Click;
            txtbxCaption.Enter += (s, e) => { if (txtbxCaption.Text == "Enter a caption for this log...") txtbxCaption.Text = ""; };
        }

        private void Gallery_Load(object? sender, EventArgs e)
        {
            FetchClientId();
            if (_currentClientId != 0)
            {
                SeedGalleryTable();
                LoadUserGallery();
            }
        }

        // ==========================================
        // DATABASE LOGIC
        // ==========================================
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
                        object res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) _currentClientId = Convert.ToInt32(res);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Identity Error: " + ex.Message); }
        }

        private void SeedGalleryTable()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    DataTable tables = conn.GetSchema("Tables");
                    bool exists = false;
                    foreach (DataRow row in tables.Rows)
                    {
                        if (row["TABLE_NAME"].ToString() == "gallery_logs") exists = true;
                    }

                    if (!exists)
                    {
                        string createSql = "CREATE TABLE gallery_logs (mediaID AUTOINCREMENT PRIMARY KEY, clientID INT, file_path VARCHAR(255), media_type VARCHAR(20), caption VARCHAR(255), upload_date VARCHAR(50))";
                        using (OleDbCommand cmd = new OleDbCommand(createSql, conn)) { cmd.ExecuteNonQuery(); }
                    }
                }
            }
            catch { /* Ignore if already exists */ }
        }

        // ==========================================
        // UPLOAD & FILE MANAGEMENT
        // ==========================================
        private void BtnSelectMedia_Click(object? sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Physique Update";
            ofd.Filter = "Media Files|*.jpg;*.jpeg;*.png;*.mp4;*.avi";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _selectedFilePath = ofd.FileName;

                // File Size Safety Check (~50MB Limit)
                FileInfo fileInfo = new FileInfo(_selectedFilePath);
                if (fileInfo.Length > 50000000)
                {
                    MessageBox.Show("File exceeds maximum allowed size (50MB). Please select a compressed file.", "System Override", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _selectedFilePath = "";
                    return;
                }

                string ext = Path.GetExtension(_selectedFilePath).ToLower();

                if (ext == ".mp4" || ext == ".avi")
                {
                    picPreview.Image = null;
                    picPreview.BackColor = Color.FromArgb(40, 50, 90);
                }
                else 
                {
                    picPreview.BackColor = Color.FromArgb(15, 20, 40);
                    using (Image tempImage = Image.FromFile(_selectedFilePath))
                    {
                        picPreview.Image = new Bitmap(tempImage);
                    }
                }
                btnUpload.Enabled = true;
            }
        }

        private void BtnUpload_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedFilePath) || _currentClientId == 0) return;

            try
            {
                string ext = Path.GetExtension(_selectedFilePath).ToLower();
                string uniqueFileName = $"CLIENT_{_currentClientId}_{DateTime.Now.Ticks}{ext}";
                string destinationPath = Path.Combine(_mediaVaultPath, uniqueFileName);

                File.Copy(_selectedFilePath, destinationPath, true);

                string mediaType = (ext == ".mp4" || ext == ".avi") ? "Video" : "Image";
                string caption = txtbxCaption.Text == "Enter a caption for this log..." ? "" : txtbxCaption.Text;

                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string insertSql = "INSERT INTO gallery_logs (clientID, file_path, media_type, caption, upload_date) VALUES (@cid, @path, @type, @cap, @date)";
                    using (OleDbCommand cmd = new OleDbCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        cmd.Parameters.AddWithValue("@path", uniqueFileName);
                        cmd.Parameters.AddWithValue("@type", mediaType);
                        cmd.Parameters.AddWithValue("@cap", caption);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Media secured to Vault.", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _selectedFilePath = "";
                picPreview.Image = null;
                txtbxCaption.Text = "Enter a caption for this log...";
                btnUpload.Enabled = false;
                LoadUserGallery();
            }
            catch (Exception ex) { MessageBox.Show("Upload failed: " + ex.Message); }
        }

        // ==========================================
        // DISPLAY GALLERY & DELETION LOGIC
        // ==========================================
        private void LoadUserGallery()
        {
            flowGallery.Controls.Clear();

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT mediaID, file_path, media_type, caption, upload_date FROM gallery_logs WHERE clientID = @cid ORDER BY mediaID DESC";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int mId = Convert.ToInt32(reader["mediaID"]);
                                string fileName = reader["file_path"].ToString()!;
                                string type = reader["media_type"].ToString()!;
                                string caption = reader["caption"].ToString()!;
                                string date = reader["upload_date"].ToString()!;

                                string fullPath = Path.Combine(_mediaVaultPath, fileName);
                                if (File.Exists(fullPath))
                                {
                                    CreateGalleryCard(mId, fullPath, type, caption, date);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load gallery: " + ex.Message); }
        }

        private void CreateGalleryCard(int mediaId, string filePath, string type, string caption, string date)
        {
            Panel card = new Panel();
            card.Size = new Size(320, 380);
            card.BackColor = Color.FromArgb(20, 25, 60);
            card.Margin = new Padding(15);
            card.BorderStyle = BorderStyle.FixedSingle;

            PictureBox pic = new PictureBox();
            pic.Size = new Size(300, 280);
            pic.Location = new Point(10, 10);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Cursor = Cursors.Hand;
            pic.Click += (s, e) => { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { FileName = filePath, UseShellExecute = true }); };

            if (type == "Image")
            {
                using (Image tempImage = Image.FromFile(filePath))
                {
                    pic.Image = new Bitmap(tempImage);
                }
            }
            else
            {
                pic.BackColor = Color.FromArgb(10, 15, 30);
                pic.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(80, 120, 255)))
                    {
                        Point[] triangle = { new Point(130, 110), new Point(130, 170), new Point(180, 140) };
                        e.Graphics.FillPolygon(brush, triangle);
                    }
                };
            }

            // --- DELETE BUTTON ---
            Button btnDelete = new Button();
            btnDelete.Text = "✕";
            btnDelete.Size = new Size(35, 35);
            btnDelete.Location = new Point(265, 0); // Positioned inside top right of image
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.BackColor = Color.FromArgb(180, 40, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += (s, e) => { DeleteMediaRecord(mediaId, filePath, card); };

            Label lblCap = new Label();
            lblCap.Text = string.IsNullOrEmpty(caption) ? "No caption" : caption;
            lblCap.ForeColor = Color.White;
            lblCap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCap.Location = new Point(10, 300);
            lblCap.AutoSize = true;
            lblCap.MaximumSize = new Size(300, 0);

            Label lblDate = new Label();
            lblDate.Text = date;
            lblDate.ForeColor = Color.White;
            lblDate.Font = new Font("Segoe UI", 8F);
            lblDate.Location = new Point(10, 350);
            lblDate.AutoSize = true;

            pic.Controls.Add(btnDelete); // Bind delete button over picture
            card.Controls.Add(pic);
            card.Controls.Add(lblCap);
            card.Controls.Add(lblDate);
            flowGallery.Controls.Add(card);
        }

        private void DeleteMediaRecord(int mediaId, string filePath, Panel cardToRemove)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to permanently scrub this file from the Vault?", "Confirm Purge", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (OleDbConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand("DELETE FROM gallery_logs WHERE mediaID = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", mediaId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    if (File.Exists(filePath)) File.Delete(filePath);

                    flowGallery.Controls.Remove(cardToRemove);
                    cardToRemove.Dispose();
                }
                catch (Exception ex) { MessageBox.Show("Purge failed. The file might be in use: " + ex.Message); }
            }
        }

        // ==========================================
        // UI STYLING ENGINE
        // ==========================================
        private void Card_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(25, 30, 70), Color.FromArgb(15, 20, 50)))
                { e.Graphics.FillRectangle(hBrush, panel.ClientRectangle); }
                using (Pen pen = new Pen(Color.FromArgb(80, 100, 200), 1))
                { e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1); }
            }
        }

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle, Color.FromArgb(80, 120, 255), Color.FromArgb(180, 80, 255), LinearGradientMode.Horizontal);
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
            }
        }

        private void PrimaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                if (!btn.Enabled) return;
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(80, 120, 255), Color.FromArgb(140, 60, 255), LinearGradientMode.Horizontal))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}