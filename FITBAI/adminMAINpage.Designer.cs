namespace FITBAI
{
    partial class adminMAINpage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminMAINpage));
            topheader = new Panel();
            btnMin = new Button();
            btnOpMinMax = new Button();
            btnClose = new Button();
            sidebarPanel = new Panel();
            button1 = new Button();
            btnInstructorsHub = new Button();
            btnMemberManagement = new Button();
            pictureBox1 = new PictureBox();
            btnLogout = new Button();
            btnTermination = new Button();
            btnDashboard = new Button();
            lblAdminTitle = new Label();
            pnlAdminContent = new Panel();
            topheader.SuspendLayout();
            sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // topheader
            // 
            topheader.BackColor = Color.FromArgb(8, 10, 25);
            topheader.Controls.Add(btnMin);
            topheader.Controls.Add(btnOpMinMax);
            topheader.Controls.Add(btnClose);
            topheader.Dock = DockStyle.Top;
            topheader.Location = new Point(0, 0);
            topheader.Name = "topheader";
            topheader.Size = new Size(1920, 50);
            topheader.TabIndex = 2;
            topheader.MouseDown += topheader_MouseDown;
            // 
            // btnMin
            // 
            btnMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.ForeColor = Color.White;
            btnMin.Location = new Point(1770, 0);
            btnMin.Name = "btnMin";
            btnMin.Size = new Size(50, 50);
            btnMin.TabIndex = 1;
            btnMin.Text = "—";
            btnMin.Click += btnMin_Click;
            // 
            // btnOpMinMax
            // 
            btnOpMinMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpMinMax.FlatAppearance.BorderSize = 0;
            btnOpMinMax.FlatStyle = FlatStyle.Flat;
            btnOpMinMax.ForeColor = Color.White;
            btnOpMinMax.Location = new Point(1820, 0);
            btnOpMinMax.Name = "btnOpMinMax";
            btnOpMinMax.Size = new Size(50, 50);
            btnOpMinMax.TabIndex = 2;
            btnOpMinMax.Text = "☐";
            btnOpMinMax.Click += btnOpMinMax_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1870, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(50, 50);
            btnClose.TabIndex = 3;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(15, 20, 40);
            sidebarPanel.Controls.Add(button1);
            sidebarPanel.Controls.Add(btnInstructorsHub);
            sidebarPanel.Controls.Add(btnMemberManagement);
            sidebarPanel.Controls.Add(pictureBox1);
            sidebarPanel.Controls.Add(btnLogout);
            sidebarPanel.Controls.Add(btnTermination);
            sidebarPanel.Controls.Add(btnDashboard);
            sidebarPanel.Controls.Add(lblAdminTitle);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 50);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(316, 1030);
            sidebarPanel.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(44, 555);
            button1.Name = "button1";
            button1.Size = new Size(250, 60);
            button1.TabIndex = 6;
            button1.Text = "Community Moderation";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnModerator_Click;
            // 
            // btnInstructorsHub
            // 
            btnInstructorsHub.BackColor = Color.Navy;
            btnInstructorsHub.Cursor = Cursors.Hand;
            btnInstructorsHub.FlatAppearance.BorderSize = 0;
            btnInstructorsHub.FlatStyle = FlatStyle.Flat;
            btnInstructorsHub.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnInstructorsHub.ForeColor = Color.White;
            btnInstructorsHub.Location = new Point(44, 474);
            btnInstructorsHub.Name = "btnInstructorsHub";
            btnInstructorsHub.Size = new Size(250, 60);
            btnInstructorsHub.TabIndex = 5;
            btnInstructorsHub.Text = "Instructors Hub";
            btnInstructorsHub.UseVisualStyleBackColor = false;
            btnInstructorsHub.Click += btnInstructorsHub_Click;
            // 
            // btnMemberManagement
            // 
            btnMemberManagement.BackColor = Color.Navy;
            btnMemberManagement.Cursor = Cursors.Hand;
            btnMemberManagement.FlatAppearance.BorderSize = 0;
            btnMemberManagement.FlatStyle = FlatStyle.Flat;
            btnMemberManagement.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMemberManagement.ForeColor = Color.White;
            btnMemberManagement.Location = new Point(44, 395);
            btnMemberManagement.Name = "btnMemberManagement";
            btnMemberManagement.Size = new Size(250, 60);
            btnMemberManagement.TabIndex = 4;
            btnMemberManagement.Text = "Member Management";
            btnMemberManagement.UseVisualStyleBackColor = false;
            btnMemberManagement.Click += btnMemberManagement_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(109, 71);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(114, 67);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogout.ForeColor = SystemColors.ButtonFace;
            btnLogout.Location = new Point(0, 970);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(316, 60);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnTermination
            // 
            btnTermination.BackColor = Color.Navy;
            btnTermination.Cursor = Cursors.Hand;
            btnTermination.FlatAppearance.BorderSize = 0;
            btnTermination.FlatStyle = FlatStyle.Flat;
            btnTermination.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTermination.ForeColor = Color.White;
            btnTermination.Location = new Point(44, 308);
            btnTermination.Name = "btnTermination";
            btnTermination.Size = new Size(250, 60);
            btnTermination.TabIndex = 2;
            btnTermination.Text = "Termination Queue";
            btnTermination.UseVisualStyleBackColor = false;
            btnTermination.Click += btnTermination_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Navy;
            btnDashboard.Cursor = Cursors.Hand;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(44, 226);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(250, 60);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "User Analytics";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // lblAdminTitle
            // 
            lblAdminTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAdminTitle.ForeColor = Color.FromArgb(15, 20, 40);
            lblAdminTitle.Location = new Point(12, 21);
            lblAdminTitle.Name = "lblAdminTitle";
            lblAdminTitle.Size = new Size(298, 120);
            lblAdminTitle.TabIndex = 0;
            lblAdminTitle.Text = " ADMIN DOMAIN";
            lblAdminTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAdminContent
            // 
            pnlAdminContent.BackColor = Color.FromArgb(10, 12, 25);
            pnlAdminContent.Dock = DockStyle.Fill;
            pnlAdminContent.Location = new Point(316, 50);
            pnlAdminContent.Name = "pnlAdminContent";
            pnlAdminContent.Size = new Size(1604, 1030);
            pnlAdminContent.TabIndex = 1;
            // 
            // adminMAINpage
            // 
            ClientSize = new Size(1920, 1080);
            Controls.Add(pnlAdminContent);
            Controls.Add(sidebarPanel);
            Controls.Add(topheader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "adminMAINpage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FITBAI - Admin Command Center";
            Load += adminMAINpage_Load;
            topheader.ResumeLayout(false);
            sidebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel topheader;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnOpMinMax;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label lblAdminTitle;
        public System.Windows.Forms.Button btnDashboard;
        public System.Windows.Forms.Button btnTermination;
        public System.Windows.Forms.Button btnLogout;
        public System.Windows.Forms.Panel pnlAdminContent;
        private PictureBox pictureBox1;
        public Button btnMemberManagement;
        public Button btnInstructorsHub;
        public Button button1;
    }
}