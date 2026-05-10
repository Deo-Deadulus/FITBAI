namespace FITBAI
{
    partial class Community
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new System.Windows.Forms.Label();
            cardPost = new System.Windows.Forms.Panel();
            lblFileName = new System.Windows.Forms.Label();
            btnAttach = new System.Windows.Forms.Button();
            lblPostPrompt = new System.Windows.Forms.Label();
            txtNewPost = new System.Windows.Forms.TextBox();
            btnPost = new System.Windows.Forms.Button();
            lblFeedTitle = new System.Windows.Forms.Label();
            flowFeed = new System.Windows.Forms.FlowLayoutPanel();
            cardPost.SuspendLayout();
            SuspendLayout();

            // lblTitle
            lblTitle.Font = new System.Drawing.Font("Arial Black", 28F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            lblTitle.Location = new System.Drawing.Point(85, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(600, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THE LOCKER ROOM";

            // cardPost
            cardPost.BackColor = System.Drawing.Color.FromArgb(20, 25, 60);
            cardPost.Controls.Add(lblFileName);
            cardPost.Controls.Add(btnAttach);
            cardPost.Controls.Add(lblPostPrompt);
            cardPost.Controls.Add(txtNewPost);
            cardPost.Controls.Add(btnPost);
            cardPost.Location = new System.Drawing.Point(85, 130);
            cardPost.Name = "cardPost";
            cardPost.Size = new System.Drawing.Size(1400, 200);
            cardPost.TabIndex = 1;

            // lblPostPrompt
            lblPostPrompt.AutoSize = true;
            lblPostPrompt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblPostPrompt.ForeColor = System.Drawing.Color.White;
            lblPostPrompt.Location = new System.Drawing.Point(20, 20);
            lblPostPrompt.Name = "lblPostPrompt";
            lblPostPrompt.Size = new System.Drawing.Size(434, 28);
            lblPostPrompt.TabIndex = 0;
            lblPostPrompt.Text = "BROADCAST YOUR PROGRESS (MEDIA REQUIRED)";

            // btnAttach
            btnAttach.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAttach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAttach.ForeColor = System.Drawing.Color.DeepSkyBlue;
            btnAttach.Location = new System.Drawing.Point(25, 145);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new System.Drawing.Size(120, 35);
            btnAttach.TabIndex = 3;
            btnAttach.Text = "📎 ATTACH";
            btnAttach.UseVisualStyleBackColor = true;

            // lblFileName
            lblFileName.AutoSize = true;
            lblFileName.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblFileName.ForeColor = System.Drawing.Color.Gray;
            lblFileName.Location = new System.Drawing.Point(160, 150);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new System.Drawing.Size(124, 23);
            lblFileName.TabIndex = 4;
            lblFileName.Text = "No file selected";

            // txtNewPost
            txtNewPost.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            txtNewPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNewPost.Font = new System.Drawing.Font("Segoe UI", 14F);
            txtNewPost.ForeColor = System.Drawing.Color.White;
            txtNewPost.Location = new System.Drawing.Point(25, 60);
            txtNewPost.Multiline = true;
            txtNewPost.Name = "txtNewPost";
            txtNewPost.PlaceholderText = "Add an optional caption...";
            txtNewPost.Size = new System.Drawing.Size(1100, 75);
            txtNewPost.TabIndex = 1;

            // btnPost
            btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPost.FlatAppearance.BorderSize = 0;
            btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPost.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            btnPost.ForeColor = System.Drawing.Color.White;
            btnPost.Location = new System.Drawing.Point(1150, 60);
            btnPost.Name = "btnPost";
            btnPost.Size = new System.Drawing.Size(220, 120);
            btnPost.TabIndex = 2;
            btnPost.Text = "BROADCAST";
            btnPost.UseVisualStyleBackColor = true;

            // lblFeedTitle
            lblFeedTitle.AutoSize = true;
            lblFeedTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblFeedTitle.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            lblFeedTitle.Location = new System.Drawing.Point(85, 345);
            lblFeedTitle.Name = "lblFeedTitle";
            lblFeedTitle.Size = new System.Drawing.Size(229, 28);
            lblFeedTitle.TabIndex = 3;
            lblFeedTitle.Text = "VISUAL PROOF FEED";

            // flowFeed
            flowFeed.AutoScroll = true;
            flowFeed.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            flowFeed.Location = new System.Drawing.Point(85, 385);
            flowFeed.Name = "flowFeed";
            flowFeed.Padding = new System.Windows.Forms.Padding(10);
            flowFeed.Size = new System.Drawing.Size(1400, 600);
            flowFeed.TabIndex = 4;

            // Community
            BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            ClientSize = new System.Drawing.Size(1670, 1023);
            Controls.Add(flowFeed);
            Controls.Add(lblFeedTitle);
            Controls.Add(cardPost);
            Controls.Add(lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "Community";
            Text = "Community Hub";
            cardPost.ResumeLayout(false);
            cardPost.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel cardPost;
        private System.Windows.Forms.Label lblPostPrompt;
        private System.Windows.Forms.TextBox txtNewPost;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblFeedTitle;
        private System.Windows.Forms.FlowLayoutPanel flowFeed;
    }
}