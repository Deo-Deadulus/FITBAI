namespace FITBAI
{
    partial class instructorMediaViewer
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
            lblCaption = new Label();
            picViewer = new PictureBox();
            btnPlayVideo = new Button();
            txtFeedback = new TextBox();
            lblFeedbackHeader = new Label();
            btnSubmit = new Button();
            btnCancel = new Button();
            lblError = new Label();
            ((System.ComponentModel.ISupportInitialize)picViewer).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial Black", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.MediumTurquoise;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(560, 35);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "FORM CHECK PROTOCOL";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCaption
            // 
            lblCaption.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblCaption.ForeColor = Color.LightGray;
            lblCaption.Location = new Point(20, 65);
            lblCaption.Name = "lblCaption";
            lblCaption.Size = new Size(560, 25);
            lblCaption.TabIndex = 7;
            lblCaption.Text = "CLIENT NOTE: \"...\"";
            lblCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picViewer
            // 
            picViewer.BackColor = Color.FromArgb(10, 15, 20);
            picViewer.BorderStyle = BorderStyle.FixedSingle;
            picViewer.Location = new Point(50, 100);
            picViewer.Name = "picViewer";
            picViewer.Size = new Size(500, 300);
            picViewer.SizeMode = PictureBoxSizeMode.Zoom;
            picViewer.TabIndex = 6;
            picViewer.TabStop = false;
            // 
            // btnPlayVideo
            // 
            btnPlayVideo.FlatAppearance.BorderSize = 0;
            btnPlayVideo.FlatStyle = FlatStyle.Flat;
            btnPlayVideo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPlayVideo.Location = new Point(150, 200);
            btnPlayVideo.Name = "btnPlayVideo";
            btnPlayVideo.Size = new Size(300, 60);
            btnPlayVideo.TabIndex = 5;
            btnPlayVideo.Text = "▶ PLAY VIDEO EXTERNALLY";
            btnPlayVideo.Visible = false;
            btnPlayVideo.Click += btnPlayVideo_Click;
            // 
            // txtFeedback
            // 
            txtFeedback.BackColor = Color.FromArgb(30, 40, 50);
            txtFeedback.BorderStyle = BorderStyle.FixedSingle;
            txtFeedback.Font = new Font("Segoe UI", 12F);
            txtFeedback.ForeColor = Color.White;
            txtFeedback.Location = new Point(50, 460);
            txtFeedback.Multiline = true;
            txtFeedback.Name = "txtFeedback";
            txtFeedback.Size = new Size(500, 120);
            txtFeedback.TabIndex = 2;
            // 
            // lblFeedbackHeader
            // 
            lblFeedbackHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFeedbackHeader.ForeColor = Color.White;
            lblFeedbackHeader.Location = new Point(50, 430);
            lblFeedbackHeader.Name = "lblFeedbackHeader";
            lblFeedbackHeader.Size = new Size(500, 23);
            lblFeedbackHeader.TabIndex = 3;
            lblFeedbackHeader.Text = "INSTRUCTOR FEEDBACK:";
            // 
            // btnSubmit
            // 
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSubmit.Location = new Point(350, 610);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(200, 45);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "SUBMIT CHECK";
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.Location = new Point(50, 610);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "CANCEL";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblError
            // 
            lblError.ForeColor = Color.IndianRed;
            lblError.Location = new Point(50, 410);
            lblError.Name = "lblError";
            lblError.Size = new Size(500, 20);
            lblError.TabIndex = 4;
            lblError.Text = "Error message here";
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = false;
            // 
            // instructorMediaViewer
            // 
            BackColor = Color.FromArgb(20, 25, 35);
            ClientSize = new Size(600, 700);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(txtFeedback);
            Controls.Add(lblFeedbackHeader);
            Controls.Add(lblError);
            Controls.Add(btnPlayVideo);
            Controls.Add(picViewer);
            Controls.Add(lblCaption);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "instructorMediaViewer";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)picViewer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.PictureBox picViewer;
        private System.Windows.Forms.Button btnPlayVideo;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.Label lblFeedbackHeader;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblError;
    }
}