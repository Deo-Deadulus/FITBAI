namespace FITBAI
{
    partial class instructorOverview
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            dgvClients = new DataGridView();
            dgvActivity = new DataGridView();
            dgvMedia = new DataGridView();
            lblRosterHeader = new Label();
            lblSelectedClient = new Label();
            lblMediaHeader = new Label();
            btnReviewMedia = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActivity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedia).BeginInit();
            SuspendLayout();
            // lblTitle
            lblTitle.Font = new Font("Arial Black", 28F, FontStyle.Bold);
            lblTitle.Location = new Point(40, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(700, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "INSTRUCTOR DASHBOARD";
            // lblRosterHeader
            lblRosterHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRosterHeader.ForeColor = Color.MediumTurquoise;
            lblRosterHeader.Location = new Point(40, 120);
            lblRosterHeader.Name = "lblRosterHeader";
            lblRosterHeader.Size = new Size(400, 25);
            lblRosterHeader.TabIndex = 1;
            lblRosterHeader.Text = "ACTIVE CLIENT ROSTER";
            // dgvClients
            dgvClients.Location = new Point(40, 150);
            dgvClients.Name = "dgvClients";
            dgvClients.Size = new Size(400, 750);
            dgvClients.TabIndex = 2;
            // lblSelectedClient
            lblSelectedClient.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSelectedClient.ForeColor = Color.White;
            lblSelectedClient.Location = new Point(480, 115);
            lblSelectedClient.Name = "lblSelectedClient";
            lblSelectedClient.Size = new Size(500, 30);
            lblSelectedClient.TabIndex = 3;
            lblSelectedClient.Text = "MONITORING: [SELECT A CLIENT]";
            // dgvActivity
            dgvActivity.Location = new Point(480, 150);
            dgvActivity.Name = "dgvActivity";
            dgvActivity.Size = new Size(800, 350);
            dgvActivity.TabIndex = 4;
            // lblMediaHeader
            lblMediaHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMediaHeader.ForeColor = Color.MediumTurquoise;
            lblMediaHeader.Location = new Point(480, 520);
            lblMediaHeader.Name = "lblMediaHeader";
            lblMediaHeader.Size = new Size(400, 25);
            lblMediaHeader.TabIndex = 5;
            lblMediaHeader.Text = "CLIENT GALLERY & FORM CHECKS";
            // dgvMedia
            dgvMedia.Location = new Point(480, 550);
            dgvMedia.Name = "dgvMedia";
            dgvMedia.Size = new Size(800, 250);
            dgvMedia.TabIndex = 6;
            // btnReviewMedia
            btnReviewMedia.Cursor = Cursors.Hand;
            btnReviewMedia.FlatAppearance.BorderSize = 0;
            btnReviewMedia.FlatStyle = FlatStyle.Flat;
            btnReviewMedia.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReviewMedia.Location = new Point(480, 830);
            btnReviewMedia.Name = "btnReviewMedia";
            btnReviewMedia.Size = new Size(250, 45);
            btnReviewMedia.TabIndex = 7;
            btnReviewMedia.Text = "REVIEW SELECTED MEDIA";
            btnReviewMedia.Click += btnReviewMedia_Click;
            // instructorOverview
            BackColor = Color.FromArgb(15, 20, 30);
            ClientSize = new Size(1320, 1030);
            Controls.Add(btnReviewMedia);
            Controls.Add(dgvMedia);
            Controls.Add(lblMediaHeader);
            Controls.Add(dgvActivity);
            Controls.Add(lblSelectedClient);
            Controls.Add(dgvClients);
            Controls.Add(lblRosterHeader);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "instructorOverview";
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActivity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedia).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.DataGridView dgvActivity;
        private System.Windows.Forms.DataGridView dgvMedia;
        private System.Windows.Forms.Label lblRosterHeader;
        private System.Windows.Forms.Label lblSelectedClient;
        private System.Windows.Forms.Label lblMediaHeader;
        private System.Windows.Forms.Button btnReviewMedia;
    }
}