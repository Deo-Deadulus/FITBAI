using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class Settings : Form
    {
        private int _currentClientId = 0;
        private string _mediaVaultPath = "";

        public Settings()
        {
            InitializeComponent();

            // Wire up Gothic UI elements
            cardDiagnostics.Paint += Card_Paint;
            cardExport.Paint += Card_Paint;
            cardScorched.Paint += Card_Paint;
            lblMainTitle.Paint += TitleGradient_Paint;

            btnRefreshDiag.Paint += PrimaryButton_Paint;
            btnExportCSV.Paint += PrimaryButton_Paint;
            // Note: Termination button intentionally uses a solid warning color, not the gradient

            _mediaVaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MediaVault");

            this.Load += Settings_Load;

            // FIX #4: Refresh only reruns diagnostics, not the full load (avoids redundant SeedTerminationTable schema check)
            btnRefreshDiag.Click += (s, e) => { if (_currentClientId != 0) RunDiagnostics(); };

            btnExportCSV.Click += BtnExportCSV_Click;

            // Wire the termination button
            btnScorchedEarth.Click += BtnScorchedEarth_Click;
        }

        private void Settings_Load(object? sender, EventArgs e)
        {
            // 1. Ensure the Admin queue table exists (only runs once on form load, not on every refresh)
            SeedTerminationTable();

            // 2. Fetch the user's ID
            FetchClientId();

            if (_currentClientId != 0)
            {
                // 3. Load UI data
                RunDiagnostics();
                CheckPendingRequests(); // See if they already asked to be deleted
            }
        }

        // ==========================================
        // INITIALIZATION & ADMIN QUEUE SEEDER
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

        private void SeedTerminationTable()
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
                        if (row["TABLE_NAME"].ToString() == "termination_requests") exists = true;
                    }

                    if (!exists)
                    {
                        string createSql = "CREATE TABLE termination_requests (requestID AUTOINCREMENT PRIMARY KEY, clientID INT, request_date VARCHAR(50), reason VARCHAR(255), status VARCHAR(50))";
                        using (OleDbCommand cmd = new OleDbCommand(createSql, conn)) { cmd.ExecuteNonQuery(); }
                    }
                }
            }
            catch { /* Ignore if it already exists */ }
        }

        private void CheckPendingRequests()
        {
            // FIX #2: No longer silently swallowing exceptions — failure is surfaced to the developer/log.
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM termination_requests WHERE clientID = @cid AND status = 'Pending'", conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            // Lock down the UI if they already submitted a request
                            btnScorchedEarth.Text = "REQUEST PENDING ADMIN REVIEW";
                            btnScorchedEarth.Enabled = false;
                            btnScorchedEarth.BackColor = Color.FromArgb(40, 50, 90);
                            txtPassword.Enabled = false;
                            txtReason.Enabled = false;
                            txtPassword.Text = "Locked";
                            txtReason.Text = "Request already submitted.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Surface the error instead of silently failing.
                MessageBox.Show(
                    "Warning: Could not verify pending termination status.\n\n" + ex.Message,
                    "Status Check Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // ==========================================
        // CARD 1: DIAGNOSTICS ENGINE
        // ==========================================
        private void RunDiagnostics()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Count Logs
                    using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM activity_logs WHERE clientID = @cid", conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        int logs = Convert.ToInt32(cmd.ExecuteScalar());
                        lblLogCount.Text = $"Total Activity Logs: {logs}";
                    }

                    // Count Gallery
                    using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM gallery_logs WHERE clientID = @cid", conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        int gal = Convert.ToInt32(cmd.ExecuteScalar());
                        lblGalCount.Text = $"Vault Media Items: {gal}";
                    }
                }

                // Calculate Physical Folder Size
                long sizeBytes = 0;
                if (Directory.Exists(_mediaVaultPath))
                {
                    string searchPattern = $"CLIENT_{_currentClientId}_*.*";
                    string[] files = Directory.GetFiles(_mediaVaultPath, searchPattern);
                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);
                        sizeBytes += fi.Length;
                    }
                }
                double sizeMb = sizeBytes / 1048576.0; // Convert bytes to MB
                lblVaultSize.Text = $"Local Storage Used: {sizeMb:F2} MB";
            }
            catch (Exception ex) { MessageBox.Show("Diagnostics Error: " + ex.Message); }
        }

        // ==========================================
        // CARD 2: TACTICAL CSV EXPORT
        // ==========================================
        private void BtnExportCSV_Click(object? sender, EventArgs e)
        {
            if (_currentClientId == 0) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Excel File|*.csv";
            sfd.Title = "Save Progress Report";
            sfd.FileName = $"FITBAI_Export_{AppFlowManager.CurrentUsername}_{DateTime.Now.ToString("yyyyMMdd")}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder csv = new StringBuilder();
                    csv.AppendLine("LogID,Date,Protocol Executed,Status"); // Excel Headers

                    using (OleDbConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "SELECT logID, log_date, planID, workout_done FROM activity_logs WHERE clientID = @cid ORDER BY log_date DESC";
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@cid", _currentClientId);
                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string logId = reader["logID"].ToString()!;
                                    string date = reader["log_date"].ToString()!;
                                    string pId = reader["planID"].ToString()!;
                                    string status = Convert.ToBoolean(reader["workout_done"]) ? "CLEARED" : "FAILED";

                                    // Quotes ensure commas inside text don't break the Excel columns
                                    csv.AppendLine($"\"{logId}\",\"{date}\",\"Protocol ID: {pId}\",\"{status}\"");
                                }
                            }
                        }
                    }

                    File.WriteAllText(sfd.FileName, csv.ToString());
                    MessageBox.Show("Tactical Export Complete. Data has been saved to your local drive.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Export Error: " + ex.Message); }
            }
        }

        // ==========================================
        // CARD 3: ACCOUNT TERMINATION REQUEST
        // ==========================================

        // ADDED: The Hashing function needed for secure password verification
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes) builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private void BtnScorchedEarth_Click(object? sender, EventArgs e)
        {
            if (_currentClientId == 0) return;

            // Prevent them from clicking if they didn't type a password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("You must enter your current password to authorize this request.", "Authentication Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. THE SECURITY CHECK
                    // UPGRADED: Hash the input to match the secure database format
                    string hashedInput = HashPassword(txtPassword.Text);

                    // UPGRADED: Change [password] to password_hash
                    string verifySql = "SELECT COUNT(*) FROM users WHERE clientID = @cid AND password_hash = @p";
                    using (OleDbCommand cmd = new OleDbCommand(verifySql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        cmd.Parameters.AddWithValue("@p", hashedInput); // Pass the hash, not the plaintext

                        int matchCount = Convert.ToInt32(cmd.ExecuteScalar());

                        // If password is wrong, deny access and kick them out
                        if (matchCount == 0)
                        {
                            MessageBox.Show("Security Override Denied: Incorrect password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Clear();
                            return;
                        }
                    }

                    // 2. THE CONFIRMATION
                    DialogResult confirm = MessageBox.Show(
                        "Password verified.\n\nAre you sure you want to request Account Termination? An Administrator will review your request. If approved, all of your schedules, logs, and media will be permanently purged.",
                        "Confirm Request",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        // 3. SUBMIT THE REQUEST TO ADMIN QUEUE
                        string query = "INSERT INTO termination_requests (clientID, request_date, reason, status) VALUES (@cid, @date, @reason, 'Pending')";
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@cid", _currentClientId);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                            // Safely grab the reason, default to "No reason provided" if empty
                            string reason = string.IsNullOrWhiteSpace(txtReason.Text) ? "No reason provided" : txtReason.Text;
                            cmd.Parameters.AddWithValue("@reason", reason);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Your termination request has been deployed to the Administration queue.", "Request Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Lock down the UI so they can't submit it twice
                        btnScorchedEarth.Text = "REQUEST PENDING ADMIN REVIEW";
                        btnScorchedEarth.Enabled = false;
                        btnScorchedEarth.BackColor = Color.FromArgb(40, 50, 90);
                        txtPassword.Enabled = false;
                        txtReason.Enabled = false;
                        txtPassword.Clear();

                        // FIX #3: Match the locked state of CheckPendingRequests
                        txtReason.Text = "Request already submitted.";
                    }
                }
            }
            catch (Exception ex)
            {
                // The ultimate catch-all if the database drops or query fails
                MessageBox.Show("A critical system error occurred while processing your request:\n\n" + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // UI STYLING ENGINE
        // ==========================================
        private void Card_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                // If it's the termination card, give it a subtle warning tint
                Color startCol = panel == cardScorched ? Color.FromArgb(40, 30, 20) : Color.FromArgb(25, 30, 70);

                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, startCol, Color.FromArgb(15, 20, 50)))
                { e.Graphics.FillRectangle(hBrush, panel.ClientRectangle); }

                Color penCol = panel == cardScorched ? Color.FromArgb(180, 80, 40) : Color.FromArgb(80, 100, 200);
                using (Pen pen = new Pen(penCol, 1))
                { e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1); }
            }
        }

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                // FIX #5: Anti-aliasing added for crisp, smooth gradient text rendering
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
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