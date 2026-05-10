namespace FITBAI
{
    partial class Gallery
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMainTitle = new Label();
            cardUpload = new Panel();
            lblUploadTitle = new Label();
            picPreview = new PictureBox();
            btnSelectMedia = new Button();
            txtbxCaption = new TextBox();
            btnUpload = new Button();
            flowGallery = new FlowLayoutPanel();
            cardUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            SuspendLayout();
            // 
            // lblMainTitle
            // 
            lblMainTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblMainTitle.ForeColor = Color.FromArgb(0, 0, 64);
            lblMainTitle.Location = new Point(85, 40);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(717, 60);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "Physique | Progress Vault";
            // 
            // cardUpload
            // 
            cardUpload.Controls.Add(lblUploadTitle);
            cardUpload.Controls.Add(picPreview);
            cardUpload.Controls.Add(btnSelectMedia);
            cardUpload.Controls.Add(txtbxCaption);
            cardUpload.Controls.Add(btnUpload);
            cardUpload.Location = new Point(85, 130);
            cardUpload.Name = "cardUpload";
            cardUpload.Size = new Size(400, 850);
            cardUpload.TabIndex = 1;
            // 
            // lblUploadTitle
            // 
            lblUploadTitle.AutoSize = true;
            lblUploadTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblUploadTitle.ForeColor = Color.FromArgb(170, 180, 220);
            lblUploadTitle.Location = new Point(20, 20);
            lblUploadTitle.Name = "lblUploadTitle";
            lblUploadTitle.Size = new Size(216, 28);
            lblUploadTitle.TabIndex = 0;
            lblUploadTitle.Text = "UPLOAD NEW MEDIA";
            // 
            // picPreview
            // 
            picPreview.BackColor = Color.FromArgb(15, 20, 40);
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(25, 70);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(350, 350);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 1;
            picPreview.TabStop = false;
            // 
            // btnSelectMedia
            // 
            btnSelectMedia.FlatAppearance.BorderColor = Color.FromArgb(80, 120, 255);
            btnSelectMedia.FlatStyle = FlatStyle.Flat;
            btnSelectMedia.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSelectMedia.ForeColor = Color.White;
            btnSelectMedia.Location = new Point(25, 440);
            btnSelectMedia.Name = "btnSelectMedia";
            btnSelectMedia.Size = new Size(350, 50);
            btnSelectMedia.TabIndex = 2;
            btnSelectMedia.Text = "BROWSE FILES";
            // 
            // txtbxCaption
            // 
            txtbxCaption.BackColor = Color.FromArgb(20, 25, 60);
            txtbxCaption.BorderStyle = BorderStyle.FixedSingle;
            txtbxCaption.Font = new Font("Segoe UI Semilight", 12F);
            txtbxCaption.ForeColor = Color.White;
            txtbxCaption.Location = new Point(25, 510);
            txtbxCaption.Multiline = true;
            txtbxCaption.Name = "txtbxCaption";
            txtbxCaption.Size = new Size(350, 100);
            txtbxCaption.TabIndex = 3;
            txtbxCaption.Text = "Enter a caption for this log...";
            // 
            // btnUpload
            // 
            btnUpload.Enabled = false;
            btnUpload.FlatAppearance.BorderSize = 0;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(25, 630);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(350, 60);
            btnUpload.TabIndex = 4;
            btnUpload.Text = "SECURE TO VAULT";
            // 
            // flowGallery
            // 
            flowGallery.AutoScroll = true;
            flowGallery.BackColor = Color.FromArgb(15, 20, 40);
            flowGallery.Location = new Point(520, 130);
            flowGallery.Name = "flowGallery";
            flowGallery.Padding = new Padding(10);
            flowGallery.Size = new Size(1100, 850);
            flowGallery.TabIndex = 2;
            // 
            // Gallery
            // 
            BackColor = Color.FromArgb(15, 20, 40);
            ClientSize = new Size(1670, 1023);
            Controls.Add(lblMainTitle);
            Controls.Add(cardUpload);
            Controls.Add(flowGallery);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Gallery";
            cardUpload.ResumeLayout(false);
            cardUpload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Panel cardUpload;
        private System.Windows.Forms.Label lblUploadTitle;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnSelectMedia;
        private System.Windows.Forms.TextBox txtbxCaption;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.FlowLayoutPanel flowGallery;
    }
}