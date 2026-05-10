namespace FITBAI
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            topheader = new Panel();
            btnUsrPfMin = new Button();
            btnUsrPfMinMax = new Button();
            btnUsrPfClose = new Button();
            panelLeft = new Panel();
            panelRight = new Panel();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnBack = new Button();
            label1 = new Label();
            topheader.SuspendLayout();
            SuspendLayout();
            // 
            // topheader
            // 
            topheader.BackColor = Color.FromArgb(8, 10, 25);
            topheader.Controls.Add(btnUsrPfMin);
            topheader.Controls.Add(btnUsrPfMinMax);
            topheader.Controls.Add(btnUsrPfClose);
            topheader.Dock = DockStyle.Top;
            topheader.Location = new Point(0, 0);
            topheader.Name = "topheader";
            topheader.Size = new Size(1920, 50);
            topheader.TabIndex = 16;
            topheader.MouseDown += topheader_MouseDown;
            // 
            // btnUsrPfMin
            // 
            btnUsrPfMin.Dock = DockStyle.Right;
            btnUsrPfMin.FlatAppearance.BorderSize = 0;
            btnUsrPfMin.FlatStyle = FlatStyle.Flat;
            btnUsrPfMin.ForeColor = Color.White;
            btnUsrPfMin.Location = new Point(1770, 0);
            btnUsrPfMin.Name = "btnUsrPfMin";
            btnUsrPfMin.Size = new Size(50, 50);
            btnUsrPfMin.TabIndex = 0;
            btnUsrPfMin.Text = "—";
            btnUsrPfMin.Click += btnUsrPfMin_Click;
            // 
            // btnUsrPfMinMax
            // 
            btnUsrPfMinMax.Dock = DockStyle.Right;
            btnUsrPfMinMax.FlatAppearance.BorderSize = 0;
            btnUsrPfMinMax.FlatStyle = FlatStyle.Flat;
            btnUsrPfMinMax.ForeColor = Color.White;
            btnUsrPfMinMax.Location = new Point(1820, 0);
            btnUsrPfMinMax.Name = "btnUsrPfMinMax";
            btnUsrPfMinMax.Size = new Size(50, 50);
            btnUsrPfMinMax.TabIndex = 1;
            btnUsrPfMinMax.Text = "⬜";
            btnUsrPfMinMax.Click += btnUsrPfMinMax_Click;
            // 
            // btnUsrPfClose
            // 
            btnUsrPfClose.Dock = DockStyle.Right;
            btnUsrPfClose.FlatAppearance.BorderSize = 0;
            btnUsrPfClose.FlatStyle = FlatStyle.Flat;
            btnUsrPfClose.ForeColor = Color.White;
            btnUsrPfClose.Location = new Point(1870, 0);
            btnUsrPfClose.Name = "btnUsrPfClose";
            btnUsrPfClose.Size = new Size(50, 50);
            btnUsrPfClose.TabIndex = 2;
            btnUsrPfClose.Text = "✕";
            btnUsrPfClose.Click += btnUsrPfClose_Click;
            // 
            // panelLeft
            // 
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 50);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(150, 1030);
            panelLeft.TabIndex = 15;
            // 
            // panelRight
            // 
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(1770, 50);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(150, 1030);
            panelRight.TabIndex = 14;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semilight", 12F);
            lblUsername.ForeColor = Color.FromArgb(170, 180, 220);
            lblUsername.Location = new Point(786, 422);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(102, 28);
            lblUsername.TabIndex = 11;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(20, 25, 60);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(786, 453);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(400, 43);
            txtUsername.TabIndex = 10;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Semilight", 12F);
            lblPassword.ForeColor = Color.FromArgb(170, 180, 220);
            lblPassword.Location = new Point(786, 522);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(95, 28);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(20, 25, 60);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(786, 553);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(400, 43);
            txtPassword.TabIndex = 8;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(128, 128, 255);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnLogin.ForeColor = SystemColors.ControlLightLight;
            btnLogin.Location = new Point(786, 647);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 60);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "PROCEED";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.RoyalBlue;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.ForeColor = SystemColors.ControlLight;
            btnBack.Location = new Point(786, 727);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(400, 50);
            btnBack.TabIndex = 0;
            btnBack.Text = "RETURN";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Old English Text MT", 72F);
            label1.ForeColor = Color.CornflowerBlue;
            label1.Location = new Point(721, 245);
            label1.Name = "label1";
            label1.Size = new Size(500, 150);
            label1.TabIndex = 17;
            label1.Text = "Login";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            BackColor = Color.FromArgb(15, 20, 40);
            ClientSize = new Size(1920, 1080);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(topheader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "System Authorization";
            topheader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel topheader;
        private System.Windows.Forms.Button btnUsrPfClose;
        private System.Windows.Forms.Button btnUsrPfMinMax;
        private System.Windows.Forms.Button btnUsrPfMin;

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;

        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnBack;
        private Label label1;
    }
}