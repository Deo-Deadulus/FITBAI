using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FITBAI
{
    public partial class usrSIGNin : Form
    {
      

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        
        public usrSIGNin()
        {
            InitializeComponent();
            
            // Attach Custom Graphics
            panelLeft.Paint += SidePanel_Paint;
            panelRight.Paint += SidePanel_Paint;
            lblMainTitle.Paint += TitleGradient_Paint;
            btnRegister.Paint += GradientButton_Paint;
            btnBack.Paint += SecondaryButton_Paint;
        }

        // --- CUSTOM UI GRAPHICS ---

        private void SidePanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, 25, 75), Color.Transparent))
                { e.Graphics.FillRectangle(hBrush, panel.ClientRectangle); }
            }
        }

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle,
                    Color.FromArgb(80, 120, 255), Color.FromArgb(180, 80, 255), LinearGradientMode.Horizontal);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, lbl.ClientRectangle, sf);
            }
        }

        private void GradientButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle,
                    Color.FromArgb(120, 50, 200), Color.FromArgb(60, 20, 100), LinearGradientMode.Vertical))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void SecondaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (Pen pen = new Pen(Color.FromArgb(80, 100, 200), 2))
                { e.Graphics.DrawRectangle(pen, 1, 1, btn.Width - 2, btn.Height - 2); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.FromArgb(170, 180, 220), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        // --- DATABASE LOGIC ---

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!chkAgree.Checked)
            {
                MessageBox.Show("You must agree to the Terms and Conditions.", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtbxUsername.Text.Trim();
            string password = txtbxPassword.Text;
            string email = txtbxEmail.Text.Trim();
            string firstName = txtbxFullName.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @user";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@user", username);
                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string insertQuery = @"INSERT INTO users (username, email, password_hash, role, full_name, created_at, status) 
               VALUES (@user, @email, @pass, 'Client', @fname, @created, 'Active')";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pass", HashPassword(password));
                        cmd.Parameters.AddWithValue("@fname", firstName);
                        cmd.Parameters.AddWithValue("@created", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        cmd.ExecuteNonQuery();
                    }

                    // === THE FIX IS HERE ===
                    // We call the correct form name (usrSetUpProfilecs) instead of txtbxWeight!
                    usrSetUpProfilecs profileSetup = new usrSetUpProfilecs(this, username);
                    profileSetup.StartPosition = FormStartPosition.Manual;
                    profileSetup.Location = this.Location;
                    profileSetup.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => TermsBox.ShowTerms();

        // --- WINDOW CONTROLS ---

        private void btnBack_Click(object sender, EventArgs e)
        {
            Opening start = new Opening();
            start.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();
        private void btnMin_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void btnOpMinMax_Click(object sender, EventArgs e) => this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        private void topheader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); }
        }
    }
}