namespace FITBAI
{
    partial class usrSetUpProfilecs
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
            lblMainTitle = new Label();
            lblSubtitle = new Label();
            lblHeight = new Label();
            txtbxHeight = new TextBox();
            lblWeight = new Label();
            txtWeight = new TextBox();
            lblGender = new Label();
            txtbxGender = new TextBox();
            lblOccu = new Label();
            txtbxOccu = new TextBox();
            lblContact = new Label();
            txtbxContactNum = new TextBox();
            btnProceed = new Button();
            btnBack = new Button();
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
            // lblMainTitle
            // 
            lblMainTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblMainTitle.ForeColor = Color.White;
            lblMainTitle.Location = new Point(325, 120);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(1270, 80);
            lblMainTitle.TabIndex = 13;
            lblMainTitle.Text = "INITIALIZE BIOMETRICS";
            lblMainTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI Semilight", 14F);
            lblSubtitle.ForeColor = Color.FromArgb(170, 180, 220);
            lblSubtitle.Location = new Point(325, 200);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(1270, 40);
            lblSubtitle.TabIndex = 12;
            lblSubtitle.Text = "Enter your primary demographic data to calibrate the system.";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Font = new Font("Segoe UI Semilight", 12F);
            lblHeight.ForeColor = Color.FromArgb(170, 180, 220);
            lblHeight.Location = new Point(760, 295);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(111, 28);
            lblHeight.TabIndex = 11;
            lblHeight.Text = "Height (cm)";
            // 
            // txtbxHeight
            // 
            txtbxHeight.BackColor = Color.FromArgb(20, 25, 60);
            txtbxHeight.BorderStyle = BorderStyle.FixedSingle;
            txtbxHeight.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtbxHeight.ForeColor = Color.White;
            txtbxHeight.Location = new Point(760, 326);
            txtbxHeight.Name = "txtbxHeight";
            txtbxHeight.Size = new Size(400, 43);
            txtbxHeight.TabIndex = 10;
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Font = new Font("Segoe UI Semilight", 12F);
            lblWeight.ForeColor = Color.FromArgb(170, 180, 220);
            lblWeight.Location = new Point(760, 372);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(109, 28);
            lblWeight.TabIndex = 9;
            lblWeight.Text = "Weight (kg)";
            // 
            // txtWeight
            // 
            txtWeight.BackColor = Color.FromArgb(20, 25, 60);
            txtWeight.BorderStyle = BorderStyle.FixedSingle;
            txtWeight.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtWeight.ForeColor = Color.White;
            txtWeight.Location = new Point(760, 403);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(400, 43);
            txtWeight.TabIndex = 8;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semilight", 12F);
            lblGender.ForeColor = Color.FromArgb(170, 180, 220);
            lblGender.Location = new Point(760, 468);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(180, 28);
            lblGender.TabIndex = 7;
            lblGender.Text = "Gender Designation";
            // 
            // txtbxGender
            // 
            txtbxGender.BackColor = Color.FromArgb(20, 25, 60);
            txtbxGender.BorderStyle = BorderStyle.FixedSingle;
            txtbxGender.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtbxGender.ForeColor = Color.White;
            txtbxGender.Location = new Point(760, 499);
            txtbxGender.Name = "txtbxGender";
            txtbxGender.Size = new Size(400, 43);
            txtbxGender.TabIndex = 6;
            // 
            // lblOccu
            // 
            lblOccu.AutoSize = true;
            lblOccu.Font = new Font("Segoe UI Semilight", 12F);
            lblOccu.ForeColor = Color.FromArgb(170, 180, 220);
            lblOccu.Location = new Point(760, 578);
            lblOccu.Name = "lblOccu";
            lblOccu.Size = new Size(163, 28);
            lblOccu.TabIndex = 5;
            lblOccu.Text = "Occupation / Role";
            // 
            // txtbxOccu
            // 
            txtbxOccu.BackColor = Color.FromArgb(20, 25, 60);
            txtbxOccu.BorderStyle = BorderStyle.FixedSingle;
            txtbxOccu.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtbxOccu.ForeColor = Color.White;
            txtbxOccu.Location = new Point(760, 609);
            txtbxOccu.Name = "txtbxOccu";
            txtbxOccu.Size = new Size(400, 43);
            txtbxOccu.TabIndex = 4;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI Semilight", 12F);
            lblContact.ForeColor = Color.FromArgb(170, 180, 220);
            lblContact.Location = new Point(760, 682);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(224, 28);
            lblContact.TabIndex = 3;
            lblContact.Text = "Comm Link (Contact No.)";
            // 
            // txtbxContactNum
            // 
            txtbxContactNum.BackColor = Color.FromArgb(20, 25, 60);
            txtbxContactNum.BorderStyle = BorderStyle.FixedSingle;
            txtbxContactNum.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            txtbxContactNum.ForeColor = Color.White;
            txtbxContactNum.Location = new Point(760, 713);
            txtbxContactNum.Name = "txtbxContactNum";
            txtbxContactNum.Size = new Size(400, 43);
            txtbxContactNum.TabIndex = 2;
            // 
            // btnProceed
            // 
            btnProceed.Cursor = Cursors.Hand;
            btnProceed.FlatAppearance.BorderSize = 0;
            btnProceed.FlatStyle = FlatStyle.Flat;
            btnProceed.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnProceed.ForeColor = SystemColors.ControlLightLight;
            btnProceed.Location = new Point(760, 806);
            btnProceed.Name = "btnProceed";
            btnProceed.Size = new Size(400, 60);
            btnProceed.TabIndex = 1;
            btnProceed.Text = "PROCEED";
            btnProceed.Click += btnProceed_Click;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.ForeColor = SystemColors.ControlLightLight;
            btnBack.Location = new Point(760, 894);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(400, 50);
            btnBack.TabIndex = 0;
            btnBack.Text = "RETURN";
            btnBack.Click += btnBack_Click;
            // 
            // usrSetUpProfilecs
            // 
            BackColor = Color.FromArgb(15, 20, 40);
            ClientSize = new Size(1920, 1080);
            Controls.Add(btnBack);
            Controls.Add(btnProceed);
            Controls.Add(txtbxContactNum);
            Controls.Add(lblContact);
            Controls.Add(txtbxOccu);
            Controls.Add(lblOccu);
            Controls.Add(txtbxGender);
            Controls.Add(lblGender);
            Controls.Add(txtWeight);
            Controls.Add(lblWeight);
            Controls.Add(txtbxHeight);
            Controls.Add(lblHeight);
            Controls.Add(lblSubtitle);
            Controls.Add(lblMainTitle);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(topheader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "usrSetUpProfilecs";
            StartPosition = FormStartPosition.CenterScreen;
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

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtbxHeight;

        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtWeight;

        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtbxGender;

        private System.Windows.Forms.Label lblOccu;
        private System.Windows.Forms.TextBox txtbxOccu;

        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtbxContactNum;

        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Button btnBack;
    }
}