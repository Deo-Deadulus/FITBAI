namespace FITBAI
{
    partial class Opening
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opening));
            topheader = new Panel();
            lblSmallGothic = new Label();
            btnMin = new Button();
            btnOpMinMax = new Button();
            btnClose = new Button();
            panelLeft = new Panel();
            panelRight = new Panel();
            panelCenterContent = new Panel();
            btnSignin = new Button();
            btnLogin = new Button();
            pcbxTitle = new PictureBox();
            lblSubtitle = new Label();
            topheader.SuspendLayout();
            panelCenterContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbxTitle).BeginInit();
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
            panelCenterContent.BackColor = Color.Transparent;
            panelCenterContent.Controls.Add(pcbxTitle);
            panelCenterContent.Controls.Add(lblSubtitle);
            panelCenterContent.Controls.Add(btnSignin);
            panelCenterContent.Controls.Add(btnLogin);
            panelCenterContent.Dock = DockStyle.Fill;
            panelCenterContent.Location = new Point(150, 50);
            panelCenterContent.Name = "panelCenterContent";
            panelCenterContent.Size = new Size(1620, 1030);
            panelCenterContent.TabIndex = 0;
            // 
            // btnSignin
            // 
            btnSignin.Anchor = AnchorStyles.None;
            btnSignin.BackColor = Color.SteelBlue;
            btnSignin.Cursor = Cursors.Hand;
            btnSignin.FlatAppearance.BorderSize = 0;
            btnSignin.FlatStyle = FlatStyle.Flat;
            btnSignin.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnSignin.ForeColor = SystemColors.ControlLightLight;
            btnSignin.Location = new Point(685, 600);
            btnSignin.Name = "btnSignin";
            btnSignin.Size = new Size(250, 65);
            btnSignin.TabIndex = 2;
            btnSignin.Text = "SIGN IN";
            btnSignin.UseVisualStyleBackColor = false;
            btnSignin.Click += btnSignin_Click;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.BackColor = Color.SteelBlue;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnLogin.ForeColor = SystemColors.ControlLightLight;
            btnLogin.Location = new Point(685, 690);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 65);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pcbxTitle
            // 
            pcbxTitle.Image = (Image)resources.GetObject("pcbxTitle.Image");
            pcbxTitle.Location = new Point(556, 143);
            pcbxTitle.Name = "pcbxTitle";
            pcbxTitle.Size = new Size(522, 371);
            pcbxTitle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbxTitle.TabIndex = 4;
            pcbxTitle.TabStop = false;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Anchor = AnchorStyles.None;
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Arial", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.FromArgb(170, 180, 220);
            lblSubtitle.Location = new Point(510, 527);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(617, 44);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "BODY ACHIEVEMENT INDICATOR";
            // 
            // Opening
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 14, 40);
            ClientSize = new Size(1920, 1080);
            Controls.Add(panelCenterContent);
            Controls.Add(panelLeft);
            Controls.Add(panelRight);
            Controls.Add(topheader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Opening";
            StartPosition = FormStartPosition.CenterScreen;
            topheader.ResumeLayout(false);
            topheader.PerformLayout();
            panelCenterContent.ResumeLayout(false);
            panelCenterContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcbxTitle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topheader;
        private System.Windows.Forms.Label lblSmallGothic;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnOpMinMax;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelCenterContent;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignin;
        private PictureBox pcbxTitle;
        private Label lblSubtitle;
    }
}