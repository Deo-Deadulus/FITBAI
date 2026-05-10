using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class Opening : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Opening()
        {
            InitializeComponent();

            panelLeft.Paint += SidePanel_Paint;
            panelRight.Paint += SidePanel_Paint;
            btnLogin.Paint += GradientButton_Paint;
            btnSignin.Paint += GradientButton_Paint;
        }

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

        private void GradientButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle,
                    Color.FromArgb(120, 50, 200),
                    Color.FromArgb(60, 20, 100),
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, btn.ClientRectangle);
                }

                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle,
                    Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        // ==========================================
        // NAVIGATION FLOW (Fixed for decoupled architecture)
        // ==========================================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;
            loginForm.Show();
            this.Hide();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            usrSIGNin registerForm = new usrSIGNin();
            registerForm.StartPosition = FormStartPosition.Manual;
            registerForm.Location = this.Location;
            registerForm.Show();
            this.Hide();
        }

        // --- WINDOW CONTROLS ---
        private void topheader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();
        private void btnMin_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void btnOpMinMax_Click(object sender, EventArgs e) => this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
    }
}