namespace FITBAI
{
    partial class instructorMAINpage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topheader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnUsrPfMin = new System.Windows.Forms.Button();
            this.btnUsrPfMinMax = new System.Windows.Forms.Button();
            this.btnUsrPfClose = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnBuildWorkout = new System.Windows.Forms.Button();
            this.btnOverview = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelCenterContent = new System.Windows.Forms.Panel();
            this.topheader.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();

            // topheader
            this.topheader.BackColor = System.Drawing.Color.FromArgb(8, 15, 20); // Darker teal tint
            this.topheader.Controls.Add(this.lblWelcome);
            this.topheader.Controls.Add(this.btnUsrPfMin);
            this.topheader.Controls.Add(this.btnUsrPfMinMax);
            this.topheader.Controls.Add(this.btnUsrPfClose);
            this.topheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.topheader.Location = new System.Drawing.Point(0, 0);
            this.topheader.Size = new System.Drawing.Size(1920, 50);
            this.topheader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topheader_MouseDown);

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblWelcome.Location = new System.Drawing.Point(20, 12);
            this.lblWelcome.Text = "LOGGED IN AS: ...";

            // Window Controls (Min, Max, Close)
            this.btnUsrPfClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUsrPfClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsrPfClose.FlatAppearance.BorderSize = 0;
            this.btnUsrPfClose.ForeColor = System.Drawing.Color.White;
            this.btnUsrPfClose.Size = new System.Drawing.Size(50, 50);
            this.btnUsrPfClose.Text = "✕";
            this.btnUsrPfClose.Click += new System.EventHandler(this.btnUsrPfClose_Click);

            this.btnUsrPfMinMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUsrPfMinMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsrPfMinMax.FlatAppearance.BorderSize = 0;
            this.btnUsrPfMinMax.ForeColor = System.Drawing.Color.White;
            this.btnUsrPfMinMax.Size = new System.Drawing.Size(50, 50);
            this.btnUsrPfMinMax.Text = "⬜";
            this.btnUsrPfMinMax.Click += new System.EventHandler(this.btnUsrPfMinMax_Click);

            this.btnUsrPfMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUsrPfMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsrPfMin.FlatAppearance.BorderSize = 0;
            this.btnUsrPfMin.ForeColor = System.Drawing.Color.White;
            this.btnUsrPfMin.Size = new System.Drawing.Size(50, 50);
            this.btnUsrPfMin.Text = "—";
            this.btnUsrPfMin.Click += new System.EventHandler(this.btnUsrPfMin_Click);

            // panelLeft (The Sidebar)
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(10, 20, 25);
            this.panelLeft.Controls.Add(this.btnLogout);
            this.panelLeft.Controls.Add(this.btnBuildWorkout);
            this.panelLeft.Controls.Add(this.btnOverview);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 50);
            this.panelLeft.Size = new System.Drawing.Size(300, 1030); // 300px wide sidebar

            // btnOverview
            this.btnOverview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOverview.FlatAppearance.BorderSize = 0;
            this.btnOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOverview.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnOverview.Location = new System.Drawing.Point(0, 100);
            this.btnOverview.Size = new System.Drawing.Size(300, 70);
            this.btnOverview.Text = "CLIENT OVERVIEW";
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_Click);

            // btnBuildWorkout
            this.btnBuildWorkout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuildWorkout.FlatAppearance.BorderSize = 0;
            this.btnBuildWorkout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuildWorkout.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnBuildWorkout.Location = new System.Drawing.Point(0, 170); // Sit nicely right under Overview
            this.btnBuildWorkout.Size = new System.Drawing.Size(300, 70);
            this.btnBuildWorkout.Text = "ASSIGN WORKOUT";
            this.btnBuildWorkout.Click += new System.EventHandler(this.btnBuildWorkout_Click);

            // btnLogout
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(0, 900); // Bottom of sidebar
            this.btnLogout.Size = new System.Drawing.Size(300, 70);
            this.btnLogout.Text = "SECURE LOGOUT";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // panelRight
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(10, 20, 25);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1620, 50);
            this.panelRight.Size = new System.Drawing.Size(300, 1030);

            // panelCenterContent
            this.panelCenterContent.BackColor = System.Drawing.Color.FromArgb(15, 20, 30);
            this.panelCenterContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterContent.Location = new System.Drawing.Point(300, 50);

            // instructorMAINpage
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panelCenterContent);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.topheader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.topheader.ResumeLayout(false);
            this.topheader.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel topheader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnUsrPfMin;
        private System.Windows.Forms.Button btnUsrPfMinMax;
        private System.Windows.Forms.Button btnUsrPfClose;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Button btnBuildWorkout;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelCenterContent;
    }
}