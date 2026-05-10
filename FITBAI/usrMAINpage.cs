using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class usrMAINpage : Form
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

        private Form? activeForm = null;
        private string _activeUser;

        // ==========================================
        // UNIFIED MASTER CONSTRUCTOR
        // ==========================================
        public usrMAINpage(string username = "")
        {
            InitializeComponent();

            // 1. Catch the username
            _activeUser = username;

            // 2. Attach Custom Graphics Engine for the Gothic Theme
            lblSmallGothic.Paint += TitleGradient_Paint;
            sidebarPanel.Paint += Sidebar_Paint;

            // 3. Manage Roles
            ApplyRoleAccess(AppFlowManager.CurrentRole);

            // 4. Wire up the Profile Button explicitly
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);

            // 5. Load the default Dashboard view into the router!
            LoadPage(new Dashboard());
        }

        // ==========================================
        // CUSTOM UI GRAPHICS
        // ==========================================
        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle,
                    Color.FromArgb(80, 120, 255), Color.FromArgb(180, 80, 255), LinearGradientMode.Horizontal);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
            }
        }

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

        // ==========================================
        // CORE ROUTING FUNCTIONS
        // ==========================================
        public void LoadPage(Form childForm)
        {
            if (activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMainContainer.Controls.Add(childForm);
            panelMainContainer.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        public void ApplyRoleAccess(UserRole role)
        {
            // 1. Hide the restricted domains by default
            btnAdminPanel.Visible = false;
            btnMyStudio.Visible = false;

            // 2. Reveal them strictly based on the user's authorized role
            if (role == UserRole.Admin)
            {
                // Admins get access to everything
                btnAdminPanel.Visible = true;
                btnMyStudio.Visible = true;
            }
            else if (role == UserRole.Instructor)
            {
                // Instructors only get their studio
                btnMyStudio.Visible = true;
            }
        }

        // ==========================================
        // SIDEBAR NAVIGATION CLICKS
        // ==========================================
        private void btnProfile_Click(object? sender, EventArgs e) => LoadPage(new MyProfile());
        private void btnWorkout_Click(object? sender, EventArgs e) => LoadPage(new WorkoutPlan());
        private void btnActivityLog_Click(object? sender, EventArgs e) => LoadPage(new ActivityLog());
        private void btnSchedule_Click(object? sender, EventArgs e) => LoadPage(new Schedule());
        private void btnExercises_Click(object? sender, EventArgs e) => LoadPage(new ExerciseCodex());
        private void btnProgress_Click(object? sender, EventArgs e) => LoadPage(new ProgressMatrix());
        private void btnGallery_Click(object? sender, EventArgs e) => LoadPage(new Gallery());
        private void btnInstructors_Click(object? sender, EventArgs e) => LoadPage(new Instructors());
        private void btnSettings_Click(object? sender, EventArgs e) => LoadPage(new Settings());

        // NEW: Community Hub Router
        private void btnCommunity_Click(object? sender, EventArgs e) => LoadPage(new Community());

        // Dashboard Home Button (Clicking the Title)
        private void lblSmallGothic_Click(object? sender, EventArgs e) => LoadPage(new Dashboard());

        // ==========================================
        // NEW DYNAMIC ROLE CLICKS
        // ==========================================
        private void btnAdminPanel_Click(object? sender, EventArgs e)
        {
            AppFlowManager.LoadAdminDashboard(this);
        }

        private void btnMyStudio_Click(object? sender, EventArgs e)
        {
            AppFlowManager.LoadInstructorDashboard(this);
        }

        // ==========================================
        // TOP HEADER CONTROLS
        // ==========================================
        private void btnUsrPfClose_Click(object? sender, EventArgs e) => Application.Exit();

        private void btnUsrPfMinMax_Click(object? sender, EventArgs e) => this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;

        private void btnUsrPfMin_Click(object? sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void topheader_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            // 1. Show the standard confirmation dialog
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to log out of your current session?",
                "System Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // 2. Wipe the session memory (Safety First!)
                AppFlowManager.CurrentUsername = "";
                AppFlowManager.CurrentUserRole = "CLIENT"; // Reset to default

                // 3. Launch the Opening screen
                Opening loginGate = new Opening();
                loginGate.Show();

                // 4. Close the main dashboard completely
                this.Close();
            }
        }
    }
}