using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class Login : Form
    {
        // ==========================================
        // WINDOW DRAGGING IMPORTS
        // ==========================================
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Login()
        {
            InitializeComponent();

            // Wire up UI Styling
            btnLogin.Paint += PrimaryButton_Paint;
            panelLeft.Paint += SidePanel_Paint;
            panelRight.Paint += SidePanel_Paint;
        }

        // ==========================================
        // WINDOW CONTROLS
        // ==========================================
        private void topheader_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnUsrPfClose_Click(object? sender, EventArgs e) => Application.Exit();

        private void btnUsrPfMinMax_Click(object? sender, EventArgs e) =>
            this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;

        private void btnUsrPfMin_Click(object? sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void btnBack_Click(object? sender, EventArgs e)
        {
            Opening startScreen = new Opening();
            startScreen.Show();
            this.Close();
        }

        // ==========================================
        // SECURE LOGIN ENGINE & ROLE ROUTER
        // ==========================================
        private void btnLogin_Click(object? sender, EventArgs e)
        {
            // Use null-conditional to safely pull text, defaulting to empty string
            string inputUser = txtUsername.Text?.Trim() ?? "";
            string inputPass = txtPassword.Text ?? "";

            if (string.IsNullOrWhiteSpace(inputUser) || string.IsNullOrWhiteSpace(inputPass))
            {
                MessageBox.Show("Please enter both Username and Password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash the entered password with SHA-256 to match what registration stored
            string hashedPass = HashPassword(inputPass);

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // UPGRADED: Added the Soft Delete lock -> AND status <> 'Terminated'
                    string query = "SELECT clientID, [role] FROM users WHERE username = @u AND [password_hash] = @p AND status <> 'Terminated'";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", inputUser);
                        cmd.Parameters.AddWithValue("@p", hashedPass);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                AppFlowManager.CurrentUsername = inputUser;

                                // Safely extract the role, defaulting to CLIENT if null
                                string rawRole = reader["role"] != DBNull.Value ? (reader["role"]?.ToString() ?? "CLIENT") : "CLIENT";
                                string role = rawRole.Trim().ToUpper();
                                AppFlowManager.CurrentUserRole = role;

                                if (role == "ADMIN")
                                {
                                    AppFlowManager.LoadAdminDashboard(this);
                                }
                                else if (role == "INSTRUCTOR")
                                {
                                    AppFlowManager.LoadInstructorDashboard(this);
                                }
                                else
                                {
                                    AppFlowManager.LoadClientDashboard(this);
                                }
                            }
                            else
                            {
                                // If it fails, they are either typing it wrong, OR their account was soft-deleted
                                MessageBox.Show("Invalid credentials or account access has been revoked.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A critical system error occurred during authentication:\n\n" + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // PASSWORD HASHING (must match usrSIGNin.cs)
        // ==========================================
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

        // ==========================================
        // UI STYLING ENGINE
        // ==========================================
        private void SidePanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, 25, 75), Color.Transparent))
                {
                    e.Graphics.FillRectangle(hBrush, panel.ClientRectangle);
                }
            }
        }

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle, Color.FromArgb(80, 120, 255), Color.FromArgb(180, 80, 255), LinearGradientMode.Horizontal);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
            }
        }

        private void PrimaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(80, 120, 255), Color.FromArgb(140, 60, 255), LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, btn.ClientRectangle);
                }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}