namespace FITBAI
{
    partial class ExerciseCodex
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMainTitle = new System.Windows.Forms.Label();
            cardSearch = new System.Windows.Forms.Panel();
            lblSearchTitle = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            cmbCategory = new System.Windows.Forms.ComboBox();
            lstExercises = new System.Windows.Forms.ListBox();
            cardDetails = new System.Windows.Forms.Panel();
            lblExName = new System.Windows.Forms.Label();
            lblExTarget = new System.Windows.Forms.Label();
            pnlVisualizer = new System.Windows.Forms.Panel();
            btnWatchVideo = new System.Windows.Forms.Button();
            lblVisualizerText = new System.Windows.Forms.Label();
            txtInstructions = new System.Windows.Forms.TextBox();
            cardSearch.SuspendLayout();
            cardDetails.SuspendLayout();
            pnlVisualizer.SuspendLayout();
            SuspendLayout();
            // 
            // lblMainTitle
            // 
            lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblMainTitle.ForeColor = System.Drawing.Color.Transparent;
            lblMainTitle.Location = new System.Drawing.Point(85, 40);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new System.Drawing.Size(600, 60);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "Exercise Codex";
            // 
            // cardSearch
            // 
            cardSearch.Controls.Add(lblSearchTitle);
            cardSearch.Controls.Add(txtSearch);
            cardSearch.Controls.Add(cmbCategory);
            cardSearch.Controls.Add(lstExercises);
            cardSearch.Location = new System.Drawing.Point(85, 130);
            cardSearch.Name = "cardSearch";
            cardSearch.Size = new System.Drawing.Size(450, 800);
            cardSearch.TabIndex = 1;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            lblSearchTitle.Location = new System.Drawing.Point(30, 30);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new System.Drawing.Size(185, 28);
            lblSearchTitle.TabIndex = 0;
            lblSearchTitle.Text = "DATABASE QUERY";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = System.Drawing.Color.FromArgb(20, 25, 60);
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 14F);
            txtSearch.ForeColor = System.Drawing.Color.White;
            txtSearch.Location = new System.Drawing.Point(30, 80);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(390, 39);
            txtSearch.TabIndex = 1;
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = System.Drawing.Color.FromArgb(20, 25, 60);
            cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbCategory.Font = new System.Drawing.Font("Segoe UI", 14F);
            cmbCategory.ForeColor = System.Drawing.Color.White;
            cmbCategory.Location = new System.Drawing.Point(30, 140);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new System.Drawing.Size(390, 39);
            cmbCategory.TabIndex = 2;
            // 
            // lstExercises
            // 
            lstExercises.BackColor = System.Drawing.Color.FromArgb(15, 20, 50);
            lstExercises.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstExercises.Font = new System.Drawing.Font("Segoe UI", 16F);
            lstExercises.ForeColor = System.Drawing.Color.White;
            lstExercises.Location = new System.Drawing.Point(30, 210);
            lstExercises.Name = "lstExercises";
            lstExercises.Size = new System.Drawing.Size(390, 518);
            lstExercises.TabIndex = 3;
            // 
            // cardDetails
            // 
            cardDetails.Controls.Add(lblExName);
            cardDetails.Controls.Add(lblExTarget);
            cardDetails.Controls.Add(pnlVisualizer);
            cardDetails.Controls.Add(txtInstructions);
            cardDetails.Location = new System.Drawing.Point(565, 130);
            cardDetails.Name = "cardDetails";
            cardDetails.Size = new System.Drawing.Size(1020, 800);
            cardDetails.TabIndex = 2;
            // 
            // lblExName
            // 
            lblExName.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            lblExName.ForeColor = System.Drawing.Color.White;
            lblExName.Location = new System.Drawing.Point(40, 30);
            lblExName.Name = "lblExName";
            lblExName.Size = new System.Drawing.Size(900, 70);
            lblExName.TabIndex = 0;
            lblExName.Text = "Awaiting Selection";
            // 
            // lblExTarget
            // 
            lblExTarget.AutoSize = true;
            lblExTarget.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblExTarget.ForeColor = System.Drawing.Color.FromArgb(80, 120, 255);
            lblExTarget.Location = new System.Drawing.Point(50, 110);
            lblExTarget.Name = "lblExTarget";
            lblExTarget.Size = new System.Drawing.Size(356, 32);
            lblExTarget.TabIndex = 1;
            lblExTarget.Text = "TARGET: ---  |  DIFFICULTY: ---";
            // 
            // pnlVisualizer
            // 
            pnlVisualizer.BackColor = System.Drawing.Color.FromArgb(10, 12, 30);
            pnlVisualizer.Controls.Add(btnWatchVideo);
            pnlVisualizer.Controls.Add(lblVisualizerText);
            pnlVisualizer.Location = new System.Drawing.Point(50, 170);
            pnlVisualizer.Name = "pnlVisualizer";
            pnlVisualizer.Size = new System.Drawing.Size(920, 400);
            pnlVisualizer.TabIndex = 2;
            // 
            // btnWatchVideo
            // 
            btnWatchVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            btnWatchVideo.FlatAppearance.BorderSize = 0;
            btnWatchVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnWatchVideo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            btnWatchVideo.Location = new System.Drawing.Point(310, 220);
            btnWatchVideo.Name = "btnWatchVideo";
            btnWatchVideo.Size = new System.Drawing.Size(300, 60);
            btnWatchVideo.TabIndex = 1;
            btnWatchVideo.Text = "WATCH IN BROWSER ↗";
            btnWatchVideo.UseVisualStyleBackColor = true;
            // 
            // lblVisualizerText
            // 
            lblVisualizerText.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblVisualizerText.ForeColor = System.Drawing.Color.FromArgb(60, 70, 110);
            lblVisualizerText.Location = new System.Drawing.Point(0, 0);
            lblVisualizerText.Name = "lblVisualizerText";
            lblVisualizerText.Size = new System.Drawing.Size(920, 400);
            lblVisualizerText.TabIndex = 0;
            lblVisualizerText.Text = "[ BIOMETRIC VISUALIZER OFFLINE ]";
            lblVisualizerText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInstructions
            // 
            txtInstructions.BackColor = System.Drawing.Color.FromArgb(15, 20, 50);
            txtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInstructions.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            txtInstructions.ForeColor = System.Drawing.Color.White;
            txtInstructions.Location = new System.Drawing.Point(50, 600);
            txtInstructions.Multiline = true;
            txtInstructions.Name = "txtInstructions";
            txtInstructions.ReadOnly = true;
            txtInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtInstructions.Size = new System.Drawing.Size(920, 170);
            txtInstructions.TabIndex = 3;
            txtInstructions.Text = "Select a movement from the database to view execution protocols.";
            // 
            // ExerciseCodex
            // 
            BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            ClientSize = new System.Drawing.Size(1670, 1023);
            Controls.Add(lblMainTitle);
            Controls.Add(cardSearch);
            Controls.Add(cardDetails);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "ExerciseCodex";
            cardSearch.ResumeLayout(false);
            cardSearch.PerformLayout();
            cardDetails.ResumeLayout(false);
            cardDetails.PerformLayout();
            pnlVisualizer.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Panel cardSearch;
        private System.Windows.Forms.Panel cardDetails;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ListBox lstExercises;
        private System.Windows.Forms.Label lblExName;
        private System.Windows.Forms.Label lblExTarget;
        private System.Windows.Forms.Panel pnlVisualizer;
        private System.Windows.Forms.Label lblVisualizerText;
        private System.Windows.Forms.TextBox txtInstructions;

        // The newly injected execution button
        private System.Windows.Forms.Button btnWatchVideo;
    }
}