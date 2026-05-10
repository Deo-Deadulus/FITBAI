using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class adminMAINpage : Form
    {
        // ==========================================
        // WINDOW DRAGGING IMPORTS (The Requirements!)
        // ==========================================
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private Form? activeForm = null;

        public adminMAINpage()
        {
            InitializeComponent();

            sidebarPanel.Paint += Sidebar_Paint;
            lblAdminTitle.Paint += TitleGradient_Paint;
        }

        private void adminMAINpage_Load(object sender, EventArgs e)
        {
            btnDashboard.PerformClick();
        }

        // ==========================================
        // CUSTOM HEADER CONTROLS
        // ==========================================
        private void topheader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();

        private void btnOpMinMax_Click(object sender, EventArgs e) =>
            this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;

        private void btnMin_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;


        // ==========================================
        // UI STYLING ENGINE
        // ==========================================
        private void Sidebar_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, 25, 60), Color.Transparent))
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

        // ==========================================
        // CORE ROUTING FUNCTIONS
        // ==========================================
        public void LoadAdminPage(Form childForm)
        {
            if (activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlAdminContent.Controls.Add(childForm);
            pnlAdminContent.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        // ==========================================
        // NAVIGATION BUTTONS
        // ==========================================
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadAdminPage(new adminDashboard());
        }

        private void btnTermination_Click(object sender, EventArgs e)
        {
            LoadAdminPage(new adminTerminationQueue());
        }
        private void btnMemberManagement_Click(object sender, EventArgs e)
        {
            LoadAdminPage(new adminMemberManagement());
        }
        private void btnInstructorsHub_Click(object sender, EventArgs e)
        {
            LoadAdminPage(new adminInstructorHub());
        }
        private void btnModerator_Click(object sender, EventArgs e)
        {
            LoadAdminPage(new adminModerator());
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to log out of the Admin Command Center?", "System Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                AppFlowManager.Logout(this);
            }
        }

       
    }
}