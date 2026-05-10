using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class instructorMAINpage : Form
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

        public instructorMAINpage()
        {
            InitializeComponent();

            // Wire up the Custom Paint Events
            panelLeft.Paint += SidePanel_Paint;
            panelRight.Paint += SidePanel_Paint;

            // Buttons getting that Teal Gradient!
            btnOverview.Paint += SidebarButton_Paint;
            btnBuildWorkout.Paint += SidebarButton_Paint; // <-- NEW: Added paint event for Workout Builder
            btnLogout.Paint += SidebarButton_Paint;

            this.Load += InstructorMAINpage_Load;
        }

        private void InstructorMAINpage_Load(object? sender, EventArgs e)
        {
            // Set the Welcome text
            lblWelcome.Text = $"LOGGED IN AS: {AppFlowManager.CurrentUsername.ToUpper()} | ROLE: INSTRUCTOR";

            // Automatically load the Overview grids when the shell opens
            LoadInstructorPage(new instructorOverview());
        }

        // ==========================================
        // MASTER CONTAINER ROUTING
        // ==========================================
        public void LoadInstructorPage(Form childForm)
        {
            if (panelCenterContent.Controls.Count > 0)
            {
                panelCenterContent.Controls[0].Dispose();
            }

            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelCenterContent.Controls.Add(childForm);
            panelCenterContent.Tag = childForm;
            childForm.Show();
        }

        // ==========================================
        // SIDEBAR NAVIGATION
        // ==========================================
        private void btnOverview_Click(object sender, EventArgs e)
        {
            LoadInstructorPage(new instructorOverview());
        }

        // <-- NEW: The click event to launch the Relational Workout Builder! -->
        private void btnBuildWorkout_Click(object sender, EventArgs e)
        {
            LoadInstructorPage(new instructorWorkoutBuilder());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to log out of the Staff Portal?", "Secure Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                AppFlowManager.Logout(this);
            }
        }

        // ==========================================
        // WINDOW CONTROLS
        // ==========================================
        private void topheader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void btnUsrPfClose_Click(object sender, EventArgs e) => Application.Exit();
        private void btnUsrPfMinMax_Click(object sender, EventArgs e) => this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        private void btnUsrPfMin_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        // ==========================================
        // UI STYLING ENGINE (Instructor Teal Theme)
        // ==========================================
        private void SidePanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                // Different hatch pattern and color for Instructor vibe
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.WideUpwardDiagonal, Color.FromArgb(0, 80, 80), Color.Transparent))
                { e.Graphics.FillRectangle(hBrush, panel.ClientRectangle); }
            }
        }

        private void SidebarButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(0, 150, 136), Color.FromArgb(0, 100, 100), LinearGradientMode.Horizontal))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}