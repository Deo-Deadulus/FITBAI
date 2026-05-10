namespace FITBAI
{
    partial class usrMAINpage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            topheader = new System.Windows.Forms.Panel();
            lblSmallGothic = new System.Windows.Forms.Label();
            btnUsrPfMin = new System.Windows.Forms.Button();
            btnUsrPfMinMax = new System.Windows.Forms.Button();
            btnUsrPfClose = new System.Windows.Forms.Button();
            sidebarPanel = new System.Windows.Forms.Panel();
            btnLogOut = new System.Windows.Forms.Button();
            btnSettings = new System.Windows.Forms.Button();
            btnAdminPanel = new System.Windows.Forms.Button();
            btnMyStudio = new System.Windows.Forms.Button();
            btnInstructors = new System.Windows.Forms.Button();
            btnCommunity = new System.Windows.Forms.Button(); // NEW
            btnGallery = new System.Windows.Forms.Button();
            btnProgress = new System.Windows.Forms.Button();
            btnActivityLog = new System.Windows.Forms.Button();
            btnExercises = new System.Windows.Forms.Button();
            btnSchedule = new System.Windows.Forms.Button();
            btnWorkout = new System.Windows.Forms.Button();
            btnProfile = new System.Windows.Forms.Button();
            panelMainContainer = new System.Windows.Forms.Panel();
            topheader.SuspendLayout();
            sidebarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topheader
            // 
            topheader.BackColor = System.Drawing.Color.FromArgb(8, 10, 25);
            topheader.Controls.Add(lblSmallGothic);
            topheader.Controls.Add(btnUsrPfMin);
            topheader.Controls.Add(btnUsrPfMinMax);
            topheader.Controls.Add(btnUsrPfClose);
            topheader.Dock = System.Windows.Forms.DockStyle.Top;
            topheader.Location = new System.Drawing.Point(0, 0);
            topheader.Name = "topheader";
            topheader.Size = new System.Drawing.Size(1920, 50);
            topheader.TabIndex = 0;
            topheader.MouseDown += topheader_MouseDown;
            // 
            // lblSmallGothic
            // 
            lblSmallGothic.AutoSize = true;
            lblSmallGothic.Cursor = System.Windows.Forms.Cursors.Hand;
            lblSmallGothic.Font = new System.Drawing.Font("Old English Text MT", 16F);
            lblSmallGothic.ForeColor = System.Drawing.Color.Transparent;
            lblSmallGothic.Location = new System.Drawing.Point(20, 10);
            lblSmallGothic.Name = "lblSmallGothic";
            lblSmallGothic.Size = new System.Drawing.Size(262, 32);
            lblSmallGothic.TabIndex = 0;
            lblSmallGothic.Text = "Fit BAI - Dashboard";
            lblSmallGothic.Click += lblSmallGothic_Click;
            // 
            // btnUsrPfMin
            // 
            btnUsrPfMin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnUsrPfMin.FlatAppearance.BorderSize = 0;
            btnUsrPfMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUsrPfMin.ForeColor = System.Drawing.Color.White;
            btnUsrPfMin.Location = new System.Drawing.Point(1770, 0);
            btnUsrPfMin.Name = "btnUsrPfMin";
            btnUsrPfMin.Size = new System.Drawing.Size(50, 50);
            btnUsrPfMin.TabIndex = 1;
            btnUsrPfMin.Text = "—";
            btnUsrPfMin.Click += btnUsrPfMin_Click;
            // 
            // btnUsrPfMinMax
            // 
            btnUsrPfMinMax.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnUsrPfMinMax.FlatAppearance.BorderSize = 0;
            btnUsrPfMinMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUsrPfMinMax.ForeColor = System.Drawing.Color.White;
            btnUsrPfMinMax.Location = new System.Drawing.Point(1820, 0);
            btnUsrPfMinMax.Name = "btnUsrPfMinMax";
            btnUsrPfMinMax.Size = new System.Drawing.Size(50, 50);
            btnUsrPfMinMax.TabIndex = 2;
            btnUsrPfMinMax.Text = "☐";
            btnUsrPfMinMax.Click += btnUsrPfMinMax_Click;
            // 
            // btnUsrPfClose
            // 
            btnUsrPfClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnUsrPfClose.FlatAppearance.BorderSize = 0;
            btnUsrPfClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUsrPfClose.ForeColor = System.Drawing.Color.White;
            btnUsrPfClose.Location = new System.Drawing.Point(1870, 0);
            btnUsrPfClose.Name = "btnUsrPfClose";
            btnUsrPfClose.Size = new System.Drawing.Size(50, 50);
            btnUsrPfClose.TabIndex = 3;
            btnUsrPfClose.Text = "X";
            btnUsrPfClose.Click += btnUsrPfClose_Click;
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = System.Drawing.Color.FromArgb(12, 16, 33);
            sidebarPanel.Controls.Add(btnLogOut);
            sidebarPanel.Controls.Add(btnSettings);
            sidebarPanel.Controls.Add(btnAdminPanel);
            sidebarPanel.Controls.Add(btnMyStudio);
            sidebarPanel.Controls.Add(btnInstructors);
            sidebarPanel.Controls.Add(btnCommunity); // NEW
            sidebarPanel.Controls.Add(btnGallery);
            sidebarPanel.Controls.Add(btnProgress);
            sidebarPanel.Controls.Add(btnActivityLog);
            sidebarPanel.Controls.Add(btnExercises);
            sidebarPanel.Controls.Add(btnSchedule);
            sidebarPanel.Controls.Add(btnWorkout);
            sidebarPanel.Controls.Add(btnProfile);
            sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            sidebarPanel.Location = new System.Drawing.Point(0, 50);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new System.Drawing.Size(250, 1030);
            sidebarPanel.TabIndex = 1;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = System.Drawing.Color.Transparent;
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogOut.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            btnLogOut.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            btnLogOut.Location = new System.Drawing.Point(0, 917);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new System.Drawing.Size(250, 60);
            btnLogOut.TabIndex = 12;
            btnLogOut.Text = "Log Out";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += button1_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = System.Drawing.Color.Transparent;
            btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSettings.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            btnSettings.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            btnSettings.Location = new System.Drawing.Point(0, 970);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new System.Drawing.Size(250, 60);
            btnSettings.TabIndex = 11;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnAdminPanel
            // 
            btnAdminPanel.BackColor = System.Drawing.Color.Transparent;
            btnAdminPanel.FlatAppearance.BorderSize = 0;
            btnAdminPanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnAdminPanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnAdminPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdminPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnAdminPanel.ForeColor = System.Drawing.Color.FromArgb(200, 100, 100);
            btnAdminPanel.Location = new System.Drawing.Point(0, 620);
            btnAdminPanel.Name = "btnAdminPanel";
            btnAdminPanel.Size = new System.Drawing.Size(250, 60);
            btnAdminPanel.TabIndex = 10;
            btnAdminPanel.Text = "Admin Domain";
            btnAdminPanel.UseVisualStyleBackColor = false;
            btnAdminPanel.Click += btnAdminPanel_Click;
            // 
            // btnMyStudio
            // 
            btnMyStudio.BackColor = System.Drawing.Color.Transparent;
            btnMyStudio.FlatAppearance.BorderSize = 0;
            btnMyStudio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnMyStudio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnMyStudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMyStudio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnMyStudio.ForeColor = System.Drawing.Color.FromArgb(200, 180, 100);
            btnMyStudio.Location = new System.Drawing.Point(0, 560);
            btnMyStudio.Name = "btnMyStudio";
            btnMyStudio.Size = new System.Drawing.Size(250, 60);
            btnMyStudio.TabIndex = 9;
            btnMyStudio.Text = "Instructor Studio";
            btnMyStudio.UseVisualStyleBackColor = false;
            btnMyStudio.Click += btnMyStudio_Click;
            // 
            // btnInstructors
            // 
            btnInstructors.BackColor = System.Drawing.Color.Transparent;
            btnInstructors.FlatAppearance.BorderSize = 0;
            btnInstructors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnInstructors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnInstructors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInstructors.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            btnInstructors.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            btnInstructors.Location = new System.Drawing.Point(0, 500);
            btnInstructors.Name = "btnInstructors";
            btnInstructors.Size = new System.Drawing.Size(250, 60);
            btnInstructors.TabIndex = 8;
            btnInstructors.Text = "Instructors";
            btnInstructors.UseVisualStyleBackColor = false;
            btnInstructors.Click += btnInstructors_Click;
            // 
            // btnCommunity (NEW BUTTON)
            // 
            btnCommunity.BackColor = System.Drawing.Color.Transparent;
            btnCommunity.FlatAppearance.BorderSize = 0;
            btnCommunity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnCommunity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnCommunity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCommunity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnCommunity.ForeColor = System.Drawing.Color.FromArgb(170, 220, 180);
            btnCommunity.Location = new System.Drawing.Point(0, 440);
            btnCommunity.Name = "btnCommunity";
            btnCommunity.Size = new System.Drawing.Size(250, 60);
            btnCommunity.TabIndex = 7;
            btnCommunity.Text = "Community";
            btnCommunity.UseVisualStyleBackColor = false;
            btnCommunity.Click += btnCommunity_Click;
            // 
            // btnGallery
            // 
            btnGallery.BackColor = System.Drawing.Color.Transparent;
            btnGallery.FlatAppearance.BorderSize = 0;
            btnGallery.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnGallery.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnGallery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGallery.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            btnGallery.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            btnGallery.Location = new System.Drawing.Point(0, 380);
            btnGallery.Name = "btnGallery";
            btnGallery.Size = new System.Drawing.Size(250, 60);
            btnGallery.TabIndex = 6;
            btnGallery.Text = "Gallery";
            btnGallery.UseVisualStyleBackColor = false;
            btnGallery.Click += btnGallery_Click;
            // 
            // btnProgress
            // 
            btnProgress.BackColor = System.Drawing.Color.Transparent;
            btnProgress.FlatAppearance.BorderSize = 0;
            btnProgress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnProgress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProgress.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            btnProgress.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            btnProgress.Location = new System.Drawing.Point(0, 320);
            btnProgress.Name = "btnProgress";
            btnProgress.Size = new System.Drawing.Size(250, 60);
            btnProgress.TabIndex = 5;
            btnProgress.Text = "Progress";
            btnProgress.UseVisualStyleBackColor = false;
            btnProgress.Click += btnProgress_Click;
            // 
            // btnActivityLog
            // 
            btnActivityLog.BackColor = System.Drawing.Color.Transparent;
            btnActivityLog.FlatAppearance.BorderSize = 0;
            btnActivityLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnActivityLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnActivityLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnActivityLog.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            btnActivityLog.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            btnActivityLog.Location = new System.Drawing.Point(0, 260);
            btnActivityLog.Name = "btnActivityLog";
            btnActivityLog.Size = new System.Drawing.Size(250, 60);
            btnActivityLog.TabIndex = 4;
            btnActivityLog.Text = "Activity Log";
            btnActivityLog.UseVisualStyleBackColor = false;
            btnActivityLog.Click += btnActivityLog_Click;
            // 
            // btnExercises
            // 
            btnExercises.BackColor = System.Drawing.Color.Transparent;
            btnExercises.FlatAppearance.BorderSize = 0;
            btnExercises.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnExercises.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnExercises.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExercises.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            btnExercises.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            btnExercises.Location = new System.Drawing.Point(0, 200);
            btnExercises.Name = "btnExercises";
            btnExercises.Size = new System.Drawing.Size(250, 60);
            btnExercises.TabIndex = 3;
            btnExercises.Text = "Exercises";
            btnExercises.UseVisualStyleBackColor = false;
            btnExercises.Click += btnExercises_Click;
            // 
            // btnSchedule
            // 
            btnSchedule.BackColor = System.Drawing.Color.Transparent;
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSchedule.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            btnSchedule.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            btnSchedule.Location = new System.Drawing.Point(0, 140);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new System.Drawing.Size(250, 60);
            btnSchedule.TabIndex = 2;
            btnSchedule.Text = "Schedule";
            btnSchedule.UseVisualStyleBackColor = false;
            btnSchedule.Click += btnSchedule_Click;
            // 
            // btnWorkout
            // 
            btnWorkout.BackColor = System.Drawing.Color.Transparent;
            btnWorkout.FlatAppearance.BorderSize = 0;
            btnWorkout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnWorkout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnWorkout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnWorkout.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            btnWorkout.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            btnWorkout.Location = new System.Drawing.Point(0, 80);
            btnWorkout.Name = "btnWorkout";
            btnWorkout.Size = new System.Drawing.Size(250, 60);
            btnWorkout.TabIndex = 1;
            btnWorkout.Text = "Workout Plan";
            btnWorkout.UseVisualStyleBackColor = false;
            btnWorkout.Click += btnWorkout_Click;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = System.Drawing.Color.Transparent;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 120, 255);
            btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 20, 100);
            btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProfile.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            btnProfile.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            btnProfile.Location = new System.Drawing.Point(0, 20);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new System.Drawing.Size(250, 60);
            btnProfile.TabIndex = 0;
            btnProfile.Text = "My Profile";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += btnProfile_Click;
            // 
            // panelMainContainer
            // 
            panelMainContainer.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMainContainer.Location = new System.Drawing.Point(250, 50);
            panelMainContainer.Name = "panelMainContainer";
            panelMainContainer.Size = new System.Drawing.Size(1670, 1030);
            panelMainContainer.TabIndex = 2;
            // 
            // usrMAINpage
            // 
            BackColor = System.Drawing.Color.FromArgb(10, 14, 40);
            ClientSize = new System.Drawing.Size(1920, 1080);
            Controls.Add(panelMainContainer);
            Controls.Add(sidebarPanel);
            Controls.Add(topheader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "usrMAINpage";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            topheader.ResumeLayout(false);
            topheader.PerformLayout();
            sidebarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel topheader;
        private System.Windows.Forms.Label lblSmallGothic;
        private System.Windows.Forms.Button btnUsrPfMin;
        private System.Windows.Forms.Button btnUsrPfMinMax;
        private System.Windows.Forms.Button btnUsrPfClose;

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnWorkout;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnExercises;
        private System.Windows.Forms.Button btnActivityLog;
        private System.Windows.Forms.Button btnProgress;
        private System.Windows.Forms.Button btnGallery;
        private System.Windows.Forms.Button btnCommunity; // NEW
        private System.Windows.Forms.Button btnInstructors;
        private System.Windows.Forms.Button btnMyStudio;
        private System.Windows.Forms.Button btnAdminPanel;
        private System.Windows.Forms.Button btnSettings;

        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Button btnLogOut;
    }
}