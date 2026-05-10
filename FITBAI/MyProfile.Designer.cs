namespace FITBAI
{
    partial class MyProfile
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
            cardBiometrics = new Panel();
            lblBioTitle = new Label();
            lblHeightLabel = new Label();
            lblHeightVal = new Label();
            lblBmiLabel = new Label();
            lblBmiVal = new Label();
            lblWeightLabel = new Label();
            txtWeight = new TextBox();
            btnUpdateBio = new Button();
            cardDirectives = new Panel();
            lblDirTitle = new Label();
            lblCurrentGoal = new Label();
            lblGoalLabel = new Label();
            cmbGoal = new ComboBox();
            lblDirWarning = new Label();
            btnUpdateGoal = new Button();
            cardSecurity = new Panel();
            lblSecTitle = new Label();
            lblOldPass = new Label();
            txtOldPass = new TextBox();
            lblNewPass = new Label();
            txtNewPass = new TextBox();
            btnUpdateSec = new Button();
            cardBiometrics.SuspendLayout();
            cardDirectives.SuspendLayout();
            cardSecurity.SuspendLayout();
            SuspendLayout();
            // 
            // lblMainTitle
            // 
            lblMainTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblMainTitle.ForeColor = Color.FromArgb(0, 0, 64);
            lblMainTitle.Location = new Point(85, 40);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(600, 60);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "Operative Profile";
            // 
            // cardBiometrics
            // 
            cardBiometrics.Controls.Add(lblBioTitle);
            cardBiometrics.Controls.Add(lblHeightLabel);
            cardBiometrics.Controls.Add(lblHeightVal);
            cardBiometrics.Controls.Add(lblBmiLabel);
            cardBiometrics.Controls.Add(lblBmiVal);
            cardBiometrics.Controls.Add(lblWeightLabel);
            cardBiometrics.Controls.Add(txtWeight);
            cardBiometrics.Controls.Add(btnUpdateBio);
            cardBiometrics.Location = new Point(85, 130);
            cardBiometrics.Name = "cardBiometrics";
            cardBiometrics.Size = new Size(450, 450);
            cardBiometrics.TabIndex = 1;
            // 
            // lblBioTitle
            // 
            lblBioTitle.AutoSize = true;
            lblBioTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBioTitle.ForeColor = Color.FromArgb(170, 180, 220);
            lblBioTitle.Location = new Point(30, 30);
            lblBioTitle.Name = "lblBioTitle";
            lblBioTitle.Size = new Size(178, 28);
            lblBioTitle.TabIndex = 0;
            lblBioTitle.Text = "BIOMETRIC DATA";
            // 
            // lblHeightLabel
            // 
            lblHeightLabel.AutoSize = true;
            lblHeightLabel.Font = new Font("Segoe UI Semilight", 12F);
            lblHeightLabel.ForeColor = Color.FromArgb(170, 180, 220);
            lblHeightLabel.Location = new Point(30, 90);
            lblHeightLabel.Name = "lblHeightLabel";
            lblHeightLabel.Size = new Size(115, 28);
            lblHeightLabel.TabIndex = 1;
            lblHeightLabel.Text = "Height (cm):";
            // 
            // lblHeightVal
            // 
            lblHeightVal.AutoSize = true;
            lblHeightVal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeightVal.ForeColor = Color.White;
            lblHeightVal.Location = new Point(30, 120);
            lblHeightVal.Name = "lblHeightVal";
            lblHeightVal.Size = new Size(65, 37);
            lblHeightVal.TabIndex = 2;
            lblHeightVal.Text = "000";
            // 
            // lblBmiLabel
            // 
            lblBmiLabel.AutoSize = true;
            lblBmiLabel.Font = new Font("Segoe UI Semilight", 12F);
            lblBmiLabel.ForeColor = Color.FromArgb(170, 180, 220);
            lblBmiLabel.Location = new Point(220, 90);
            lblBmiLabel.Name = "lblBmiLabel";
            lblBmiLabel.Size = new Size(118, 28);
            lblBmiLabel.TabIndex = 3;
            lblBmiLabel.Text = "Current BMI:";
            // 
            // lblBmiVal
            // 
            lblBmiVal.AutoSize = true;
            lblBmiVal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBmiVal.ForeColor = Color.White;
            lblBmiVal.Location = new Point(220, 120);
            lblBmiVal.Name = "lblBmiVal";
            lblBmiVal.Size = new Size(178, 37);
            lblBmiVal.TabIndex = 4;
            lblBmiVal.Text = "00.0 (Status)";
            // 
            // lblWeightLabel
            // 
            lblWeightLabel.AutoSize = true;
            lblWeightLabel.Font = new Font("Segoe UI Semilight", 12F);
            lblWeightLabel.ForeColor = Color.FromArgb(170, 180, 220);
            lblWeightLabel.Location = new Point(30, 200);
            lblWeightLabel.Name = "lblWeightLabel";
            lblWeightLabel.Size = new Size(179, 28);
            lblWeightLabel.TabIndex = 5;
            lblWeightLabel.Text = "Update Weight (kg):";
            // 
            // txtWeight
            // 
            txtWeight.BackColor = Color.FromArgb(15, 20, 40);
            txtWeight.BorderStyle = BorderStyle.FixedSingle;
            txtWeight.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtWeight.ForeColor = Color.White;
            txtWeight.Location = new Point(30, 230);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(390, 43);
            txtWeight.TabIndex = 6;
            // 
            // btnUpdateBio
            // 
            btnUpdateBio.FlatAppearance.BorderSize = 0;
            btnUpdateBio.FlatStyle = FlatStyle.Flat;
            btnUpdateBio.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateBio.ForeColor = Color.White;
            btnUpdateBio.Location = new Point(30, 340);
            btnUpdateBio.Name = "btnUpdateBio";
            btnUpdateBio.Size = new Size(390, 60);
            btnUpdateBio.TabIndex = 7;
            btnUpdateBio.Text = "RECALIBRATE BMI";
            // 
            // cardDirectives
            // 
            cardDirectives.Controls.Add(lblDirTitle);
            cardDirectives.Controls.Add(lblCurrentGoal);
            cardDirectives.Controls.Add(lblGoalLabel);
            cardDirectives.Controls.Add(cmbGoal);
            cardDirectives.Controls.Add(lblDirWarning);
            cardDirectives.Controls.Add(btnUpdateGoal);
            cardDirectives.Location = new Point(570, 130);
            cardDirectives.Name = "cardDirectives";
            cardDirectives.Size = new Size(450, 450);
            cardDirectives.TabIndex = 2;
            // 
            // lblDirTitle
            // 
            lblDirTitle.AutoSize = true;
            lblDirTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDirTitle.ForeColor = Color.FromArgb(170, 180, 220);
            lblDirTitle.Location = new Point(30, 30);
            lblDirTitle.Name = "lblDirTitle";
            lblDirTitle.Size = new Size(206, 28);
            lblDirTitle.TabIndex = 0;
            lblDirTitle.Text = "PRIMARY DIRECTIVE";
            // 
            // lblCurrentGoal
            // 
            lblCurrentGoal.AutoSize = true;
            lblCurrentGoal.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblCurrentGoal.ForeColor = Color.LimeGreen;
            lblCurrentGoal.Location = new Point(25, 65);
            lblCurrentGoal.Name = "lblCurrentGoal";
            lblCurrentGoal.Size = new Size(317, 46);
            lblCurrentGoal.TabIndex = 1;
            lblCurrentGoal.Text = "AWAITING DATA...";
            // 
            // lblGoalLabel
            // 
            lblGoalLabel.AutoSize = true;
            lblGoalLabel.Font = new Font("Segoe UI Semilight", 12F);
            lblGoalLabel.ForeColor = Color.FromArgb(170, 180, 220);
            lblGoalLabel.Location = new Point(30, 140);
            lblGoalLabel.Name = "lblGoalLabel";
            lblGoalLabel.Size = new Size(167, 28);
            lblGoalLabel.TabIndex = 2;
            lblGoalLabel.Text = "Override Directive:";
            // 
            // cmbGoal
            // 
            cmbGoal.BackColor = Color.FromArgb(15, 20, 40);
            cmbGoal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGoal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            cmbGoal.ForeColor = Color.White;
            cmbGoal.Items.AddRange(new object[] { "Weight Loss", "Maintain Weight", "Build Muscle", "Increase Stamina", "Flexibility" });
            cmbGoal.Location = new Point(30, 170);
            cmbGoal.Name = "cmbGoal";
            cmbGoal.Size = new Size(390, 45);
            cmbGoal.TabIndex = 3;
            // 
            // lblDirWarning
            // 
            lblDirWarning.Font = new Font("Segoe UI", 10F);
            lblDirWarning.ForeColor = Color.Orange;
            lblDirWarning.Location = new Point(30, 240);
            lblDirWarning.Name = "lblDirWarning";
            lblDirWarning.Size = new Size(390, 60);
            lblDirWarning.TabIndex = 4;
            lblDirWarning.Text = "⚠️ Changing your goal will wipe your current Tactical Schedule and force a system recalculation.";
            // 
            // btnUpdateGoal
            // 
            btnUpdateGoal.FlatAppearance.BorderSize = 0;
            btnUpdateGoal.FlatStyle = FlatStyle.Flat;
            btnUpdateGoal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateGoal.ForeColor = Color.White;
            btnUpdateGoal.Location = new Point(30, 340);
            btnUpdateGoal.Name = "btnUpdateGoal";
            btnUpdateGoal.Size = new Size(390, 60);
            btnUpdateGoal.TabIndex = 5;
            btnUpdateGoal.Text = "UPDATE DIRECTIVE";
            // 
            // cardSecurity
            // 
            cardSecurity.Controls.Add(lblSecTitle);
            cardSecurity.Controls.Add(lblOldPass);
            cardSecurity.Controls.Add(txtOldPass);
            cardSecurity.Controls.Add(lblNewPass);
            cardSecurity.Controls.Add(txtNewPass);
            cardSecurity.Controls.Add(btnUpdateSec);
            cardSecurity.Location = new Point(1055, 130);
            cardSecurity.Name = "cardSecurity";
            cardSecurity.Size = new Size(450, 450);
            cardSecurity.TabIndex = 3;
            // 
            // lblSecTitle
            // 
            lblSecTitle.AutoSize = true;
            lblSecTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSecTitle.ForeColor = Color.FromArgb(170, 180, 220);
            lblSecTitle.Location = new Point(30, 30);
            lblSecTitle.Name = "lblSecTitle";
            lblSecTitle.Size = new Size(202, 28);
            lblSecTitle.TabIndex = 0;
            lblSecTitle.Text = "SECURITY SETTINGS";
            // 
            // lblOldPass
            // 
            lblOldPass.AutoSize = true;
            lblOldPass.Font = new Font("Segoe UI Semilight", 12F);
            lblOldPass.ForeColor = Color.FromArgb(170, 180, 220);
            lblOldPass.Location = new Point(30, 90);
            lblOldPass.Name = "lblOldPass";
            lblOldPass.Size = new Size(164, 28);
            lblOldPass.TabIndex = 1;
            lblOldPass.Text = "Current Password:";
            // 
            // txtOldPass
            // 
            txtOldPass.BackColor = Color.FromArgb(15, 20, 40);
            txtOldPass.BorderStyle = BorderStyle.FixedSingle;
            txtOldPass.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtOldPass.ForeColor = Color.White;
            txtOldPass.Location = new Point(30, 120);
            txtOldPass.Name = "txtOldPass";
            txtOldPass.Size = new Size(390, 43);
            txtOldPass.TabIndex = 2;
            txtOldPass.UseSystemPasswordChar = true;
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI Semilight", 12F);
            lblNewPass.ForeColor = Color.FromArgb(170, 180, 220);
            lblNewPass.Location = new Point(30, 180);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(139, 28);
            lblNewPass.TabIndex = 3;
            lblNewPass.Text = "New Password:";
            // 
            // txtNewPass
            // 
            txtNewPass.BackColor = Color.FromArgb(15, 20, 40);
            txtNewPass.BorderStyle = BorderStyle.FixedSingle;
            txtNewPass.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtNewPass.ForeColor = Color.White;
            txtNewPass.Location = new Point(30, 210);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(390, 43);
            txtNewPass.TabIndex = 4;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // btnUpdateSec
            // 
            btnUpdateSec.FlatAppearance.BorderSize = 0;
            btnUpdateSec.FlatStyle = FlatStyle.Flat;
            btnUpdateSec.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnUpdateSec.ForeColor = Color.White;
            btnUpdateSec.Location = new Point(30, 340);
            btnUpdateSec.Name = "btnUpdateSec";
            btnUpdateSec.Size = new Size(390, 60);
            btnUpdateSec.TabIndex = 5;
            btnUpdateSec.Text = "UPDATE CREDENTIALS";
            // 
            // MyProfile
            // 
            BackColor = Color.FromArgb(15, 20, 40);
            ClientSize = new Size(1670, 1023);
            Controls.Add(lblMainTitle);
            Controls.Add(cardBiometrics);
            Controls.Add(cardDirectives);
            Controls.Add(cardSecurity);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MyProfile";
            cardBiometrics.ResumeLayout(false);
            cardBiometrics.PerformLayout();
            cardDirectives.ResumeLayout(false);
            cardDirectives.PerformLayout();
            cardSecurity.ResumeLayout(false);
            cardSecurity.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Panel cardBiometrics;
        private System.Windows.Forms.Label lblBioTitle;
        private System.Windows.Forms.Label lblHeightLabel;
        private System.Windows.Forms.Label lblHeightVal;
        private System.Windows.Forms.Label lblWeightLabel;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblBmiLabel;
        private System.Windows.Forms.Label lblBmiVal;
        private System.Windows.Forms.Button btnUpdateBio;

        private System.Windows.Forms.Panel cardDirectives;
        private System.Windows.Forms.Label lblDirTitle;
        private System.Windows.Forms.Label lblCurrentGoal;
        private System.Windows.Forms.Label lblGoalLabel;
        private System.Windows.Forms.ComboBox cmbGoal;
        private System.Windows.Forms.Label lblDirWarning;
        private System.Windows.Forms.Button btnUpdateGoal;

        private System.Windows.Forms.Panel cardSecurity;
        private System.Windows.Forms.Label lblSecTitle;
        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Button btnUpdateSec;
    }
}