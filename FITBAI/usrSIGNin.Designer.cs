namespace FITBAI
{
    partial class usrSIGNin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            topheader = new Panel();
            lblSmallGothic = new Label();
            btnMin = new Button();
            btnOpMinMax = new Button();
            btnClose = new Button();
            panelLeft = new Panel();
            panelRight = new Panel();
            panelCenterContent = new Panel();
            lblMainTitle = new Label();
            lblfn = new Label();
            txtbxFullName = new TextBox();
            label3 = new Label();
            txtbxUsername = new TextBox();
            label4 = new Label();
            txtbxEmail = new TextBox();
            label2 = new Label();
            txtbxPassword = new TextBox();
            chkAgree = new CheckBox();
            linkLabel1 = new LinkLabel();
            btnRegister = new Button();
            btnBack = new Button();
            topheader.SuspendLayout();
            panelCenterContent.SuspendLayout();
            SuspendLayout();
            // 
            // topheader
            // 
            topheader.BackColor = Color.FromArgb(8, 10, 25);
            topheader.Controls.Add(lblSmallGothic);
            topheader.Controls.Add(btnMin);
            topheader.Controls.Add(btnOpMinMax);
            topheader.Controls.Add(btnClose);
            topheader.Dock = DockStyle.Top;
            topheader.Location = new Point(0, 0);
            topheader.Name = "topheader";
            topheader.Size = new Size(1920, 50);
            topheader.TabIndex = 3;
            topheader.MouseDown += topheader_MouseDown;
            // 
            // lblSmallGothic
            // 
            lblSmallGothic.AutoSize = true;
            lblSmallGothic.Font = new Font("Old English Text MT", 16F);
            lblSmallGothic.ForeColor = Color.FromArgb(120, 140, 200);
            lblSmallGothic.Location = new Point(20, 10);
            lblSmallGothic.Name = "lblSmallGothic";
            lblSmallGothic.Size = new Size(119, 32);
            lblSmallGothic.TabIndex = 0;
            lblSmallGothic.Text = "Fit BAI";
            // 
            // btnMin
            // 
            btnMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.ForeColor = Color.White;
            btnMin.Location = new Point(1770, 0);
            btnMin.Name = "btnMin";
            btnMin.Size = new Size(50, 50);
            btnMin.TabIndex = 1;
            btnMin.Text = "—";
            btnMin.Click += btnMin_Click;
            // 
            // btnOpMinMax
            // 
            btnOpMinMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpMinMax.FlatAppearance.BorderSize = 0;
            btnOpMinMax.FlatStyle = FlatStyle.Flat;
            btnOpMinMax.ForeColor = Color.White;
            btnOpMinMax.Location = new Point(1820, 0);
            btnOpMinMax.Name = "btnOpMinMax";
            btnOpMinMax.Size = new Size(50, 50);
            btnOpMinMax.TabIndex = 2;
            btnOpMinMax.Text = "☐";
            btnOpMinMax.Click += btnOpMinMax_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1870, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(50, 50);
            btnClose.TabIndex = 3;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // panelLeft
            // 
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 50);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(150, 1030);
            panelLeft.TabIndex = 1;
            // 
            // panelRight
            // 
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(1770, 50);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(150, 1030);
            panelRight.TabIndex = 2;
            // 
            // panelCenterContent
            // 
            panelCenterContent.Controls.Add(lblMainTitle);
            panelCenterContent.Controls.Add(lblfn);
            panelCenterContent.Controls.Add(txtbxFullName);
            panelCenterContent.Controls.Add(label3);
            panelCenterContent.Controls.Add(txtbxUsername);
            panelCenterContent.Controls.Add(label4);
            panelCenterContent.Controls.Add(txtbxEmail);
            panelCenterContent.Controls.Add(label2);
            panelCenterContent.Controls.Add(txtbxPassword);
            panelCenterContent.Controls.Add(chkAgree);
            panelCenterContent.Controls.Add(linkLabel1);
            panelCenterContent.Controls.Add(btnRegister);
            panelCenterContent.Controls.Add(btnBack);
            panelCenterContent.Dock = DockStyle.Fill;
            panelCenterContent.Location = new Point(150, 50);
            panelCenterContent.Name = "panelCenterContent";
            panelCenterContent.Size = new Size(1620, 1030);
            panelCenterContent.TabIndex = 0;
            // 
            // lblMainTitle
            // 
            lblMainTitle.Anchor = AnchorStyles.None;
            lblMainTitle.Font = new Font("Old English Text MT", 72F);
            lblMainTitle.ForeColor = Color.Transparent;
            lblMainTitle.Location = new Point(551, 224);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(500, 150);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "Register";
            lblMainTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblfn
            // 
            lblfn.Anchor = AnchorStyles.None;
            lblfn.AutoSize = true;
            lblfn.Font = new Font("Segoe UI Semilight", 12F);
            lblfn.ForeColor = Color.FromArgb(170, 180, 220);
            lblfn.Location = new Point(651, 379);
            lblfn.Name = "lblfn";
            lblfn.Size = new Size(98, 28);
            lblfn.TabIndex = 1;
            lblfn.Text = "Full Name";
            // 
            // txtbxFullName
            // 
            txtbxFullName.Anchor = AnchorStyles.None;
            txtbxFullName.BackColor = Color.FromArgb(20, 25, 60);
            txtbxFullName.BorderStyle = BorderStyle.FixedSingle;
            txtbxFullName.Font = new Font("Segoe UI", 16F);
            txtbxFullName.ForeColor = Color.White;
            txtbxFullName.Location = new Point(651, 410);
            txtbxFullName.Name = "txtbxFullName";
            txtbxFullName.Size = new Size(300, 43);
            txtbxFullName.TabIndex = 2;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 12F);
            label3.ForeColor = Color.FromArgb(170, 180, 220);
            label3.Location = new Point(651, 533);
            label3.Name = "label3";
            label3.Size = new Size(98, 28);
            label3.TabIndex = 3;
            label3.Text = "Username";
            // 
            // txtbxUsername
            // 
            txtbxUsername.Anchor = AnchorStyles.None;
            txtbxUsername.BackColor = Color.FromArgb(20, 25, 60);
            txtbxUsername.BorderStyle = BorderStyle.FixedSingle;
            txtbxUsername.Font = new Font("Segoe UI", 16F);
            txtbxUsername.ForeColor = Color.White;
            txtbxUsername.Location = new Point(651, 564);
            txtbxUsername.Name = "txtbxUsername";
            txtbxUsername.Size = new Size(300, 43);
            txtbxUsername.TabIndex = 4;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 12F);
            label4.ForeColor = Color.FromArgb(170, 180, 220);
            label4.Location = new Point(651, 456);
            label4.Name = "label4";
            label4.Size = new Size(130, 28);
            label4.TabIndex = 5;
            label4.Text = "Email Address";
            // 
            // txtbxEmail
            // 
            txtbxEmail.Anchor = AnchorStyles.None;
            txtbxEmail.BackColor = Color.FromArgb(20, 25, 60);
            txtbxEmail.BorderStyle = BorderStyle.FixedSingle;
            txtbxEmail.Font = new Font("Segoe UI", 16F);
            txtbxEmail.ForeColor = Color.White;
            txtbxEmail.Location = new Point(651, 487);
            txtbxEmail.Name = "txtbxEmail";
            txtbxEmail.Size = new Size(300, 43);
            txtbxEmail.TabIndex = 6;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 12F);
            label2.ForeColor = Color.FromArgb(170, 180, 220);
            label2.Location = new Point(651, 610);
            label2.Name = "label2";
            label2.Size = new Size(91, 28);
            label2.TabIndex = 7;
            label2.Text = "Password";
            // 
            // txtbxPassword
            // 
            txtbxPassword.Anchor = AnchorStyles.None;
            txtbxPassword.BackColor = Color.FromArgb(20, 25, 60);
            txtbxPassword.BorderStyle = BorderStyle.FixedSingle;
            txtbxPassword.Font = new Font("Segoe UI", 16F);
            txtbxPassword.ForeColor = Color.White;
            txtbxPassword.Location = new Point(651, 641);
            txtbxPassword.Name = "txtbxPassword";
            txtbxPassword.PasswordChar = '•';
            txtbxPassword.Size = new Size(300, 43);
            txtbxPassword.TabIndex = 8;
            // 
            // chkAgree
            // 
            chkAgree.Anchor = AnchorStyles.None;
            chkAgree.AutoSize = true;
            chkAgree.ForeColor = Color.FromArgb(170, 180, 220);
            chkAgree.Location = new Point(668, 700);
            chkAgree.Name = "chkAgree";
            chkAgree.Size = new Size(124, 24);
            chkAgree.TabIndex = 9;
            chkAgree.Text = "I agree to the ";
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.None;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(120, 140, 200);
            linkLabel1.Location = new Point(799, 701);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(152, 20);
            linkLabel1.TabIndex = 10;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Terms and Conditions";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.None;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnRegister.ForeColor = SystemColors.ControlLight;
            btnRegister.Location = new Point(651, 740);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(300, 55);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "PLEDGE OATH";
            btnRegister.Click += btnRegister_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.None;
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F);
            btnBack.ForeColor = SystemColors.ControlLight;
            btnBack.Location = new Point(697, 815);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(200, 40);
            btnBack.TabIndex = 12;
            btnBack.Text = "RETURN";
            btnBack.Click += btnBack_Click;
            // 
            // usrSIGNin
            // 
            BackColor = Color.FromArgb(10, 14, 40);
            ClientSize = new Size(1920, 1080);
            Controls.Add(panelCenterContent);
            Controls.Add(panelLeft);
            Controls.Add(panelRight);
            Controls.Add(topheader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "usrSIGNin";
            StartPosition = FormStartPosition.CenterScreen;
            topheader.ResumeLayout(false);
            topheader.PerformLayout();
            panelCenterContent.ResumeLayout(false);
            panelCenterContent.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel topheader;
        private System.Windows.Forms.Label lblSmallGothic;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnOpMinMax;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelCenterContent;

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblfn;
        private System.Windows.Forms.TextBox txtbxFullName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbxUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbxEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxPassword;
        private System.Windows.Forms.CheckBox chkAgree;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBack;
    }
}