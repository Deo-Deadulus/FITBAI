namespace FITBAI
{
    partial class adminModerator
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
            cardQueue = new Panel();
            lblQueueTitle = new Label();
            dgvFlaggedPosts = new DataGridView();
            cardQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlaggedPosts).BeginInit();
            SuspendLayout();
            // lblTitle
            lblTitle.Font = new Font("Arial Black", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(170, 180, 220);
            lblTitle.Location = new Point(85, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(600, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "COMMUNITY REPORTS";
            // cardQueue
            cardQueue.BackColor = Color.FromArgb(20, 25, 60);
            cardQueue.Controls.Add(lblQueueTitle);
            cardQueue.Controls.Add(dgvFlaggedPosts);
            cardQueue.Location = new Point(85, 130);
            cardQueue.Name = "cardQueue";
            cardQueue.Size = new Size(1400, 750);
            cardQueue.TabIndex = 2;
            // lblQueueTitle
            lblQueueTitle.AutoSize = true;
            lblQueueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQueueTitle.ForeColor = Color.FromArgb(255, 120, 120);
            lblQueueTitle.Location = new Point(20, 20);
            lblQueueTitle.Name = "lblQueueTitle";
            lblQueueTitle.Size = new Size(262, 28);
            lblQueueTitle.TabIndex = 0;
            lblQueueTitle.Text = "FLAGGED CONTENT QUEUE";
            // dgvFlaggedPosts
            dgvFlaggedPosts.AllowUserToAddRows = false;
            dgvFlaggedPosts.AllowUserToDeleteRows = false;
            dgvFlaggedPosts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFlaggedPosts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvFlaggedPosts.BackgroundColor = Color.FromArgb(15, 20, 40);
            dgvFlaggedPosts.BorderStyle = BorderStyle.None;
            dgvFlaggedPosts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(90, 30, 40);
            headerStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            headerStyle.ForeColor = Color.White;
            headerStyle.SelectionBackColor = SystemColors.Highlight;
            headerStyle.SelectionForeColor = SystemColors.HighlightText;
            headerStyle.WrapMode = DataGridViewTriState.True;
            dgvFlaggedPosts.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvFlaggedPosts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFlaggedPosts.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = Color.FromArgb(15, 20, 40);
            rowStyle.Font = new Font("Segoe UI", 12F);
            rowStyle.ForeColor = Color.White;
            rowStyle.SelectionBackColor = Color.FromArgb(150, 60, 80);
            rowStyle.SelectionForeColor = Color.White;
            rowStyle.WrapMode = DataGridViewTriState.True;
            dgvFlaggedPosts.DefaultCellStyle = rowStyle;
            dgvFlaggedPosts.GridColor = Color.FromArgb(90, 40, 50);
            dgvFlaggedPosts.Location = new Point(25, 70);
            dgvFlaggedPosts.Name = "dgvFlaggedPosts";
            dgvFlaggedPosts.ReadOnly = true;
            dgvFlaggedPosts.RowHeadersVisible = false;
            dgvFlaggedPosts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFlaggedPosts.Size = new Size(1345, 650);
            dgvFlaggedPosts.TabIndex = 1;
            // adminModerator
            BackColor = Color.FromArgb(15, 20, 40);
            ClientSize = new Size(1670, 1023);
            Controls.Add(cardQueue);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "adminModerator";
            Text = "Community Moderator";
            cardQueue.ResumeLayout(false);
            cardQueue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFlaggedPosts).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel cardQueue;
        private System.Windows.Forms.Label lblQueueTitle;
        private System.Windows.Forms.DataGridView dgvFlaggedPosts;
    }
}