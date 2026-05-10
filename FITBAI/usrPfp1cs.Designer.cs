namespace FITBAI
{
    partial class usrPfp1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.topheader = new System.Windows.Forms.Panel();
            this.btnUsrPfMin = new System.Windows.Forms.Button();
            this.btnUsrPfMinMax = new System.Windows.Forms.Button();
            this.btnUsrPfClose = new System.Windows.Forms.Button();

            this.cardMetrics = new System.Windows.Forms.Panel();
            this.lblMetricsTitle = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtbxHeight = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtbxWeight = new System.Windows.Forms.TextBox();

            // NEW: TARGET WEIGHT CONTROLS
            this.lblTargetWeight = new System.Windows.Forms.Label();
            this.txtbxTargetWeight = new System.Windows.Forms.TextBox();

            this.btnProceed = new System.Windows.Forms.Button();

            this.cardAnalysis = new System.Windows.Forms.Panel();
            this.lblAnalysisTitle = new System.Windows.Forms.Label();
            this.lblBMIValue = new System.Windows.Forms.Label();
            this.lblBMICategory = new System.Windows.Forms.Label();
            this.lblSystemRec = new System.Windows.Forms.Label();
            this.lblGoalsTitle = new System.Windows.Forms.Label();
            this.rdoLoseWeight = new System.Windows.Forms.RadioButton();
            this.rdoMaintain = new System.Windows.Forms.RadioButton();
            this.rdoGainMuscle = new System.Windows.Forms.RadioButton();
            this.rdoIncreaseStamina = new System.Windows.Forms.RadioButton();
            this.rdoFlexibility = new System.Windows.Forms.RadioButton();

            this.topheader.SuspendLayout();
            this.cardMetrics.SuspendLayout();
            this.cardAnalysis.SuspendLayout();
            this.SuspendLayout();

            // --- Shared Styles ---
            System.Drawing.Font boxFont = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font labelFont = new System.Drawing.Font("Segoe UI Semilight", 14F);
            System.Drawing.Color textBg = System.Drawing.Color.FromArgb(20, 25, 60);
            System.Drawing.Color labelColor = System.Drawing.Color.FromArgb(170, 180, 220);

            // topheader
            this.topheader.BackColor = System.Drawing.Color.FromArgb(8, 10, 25);
            this.topheader.Controls.Add(this.btnUsrPfMin);
            this.topheader.Controls.Add(this.btnUsrPfMinMax);
            this.topheader.Controls.Add(this.btnUsrPfClose);
            this.topheader.Dock = System.Windows.Forms.DockStyle.Top;
            this.topheader.Size = new System.Drawing.Size(1920, 50);

            // Header Buttons
            this.btnUsrPfMin.Dock = System.Windows.Forms.DockStyle.Right; this.btnUsrPfMin.Size = new System.Drawing.Size(50, 50); this.btnUsrPfMin.Text = "—"; this.btnUsrPfMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnUsrPfMin.ForeColor = System.Drawing.Color.White; this.btnUsrPfMin.FlatAppearance.BorderSize = 0;
            this.btnUsrPfMinMax.Dock = System.Windows.Forms.DockStyle.Right; this.btnUsrPfMinMax.Size = new System.Drawing.Size(50, 50); this.btnUsrPfMinMax.Text = "⬜"; this.btnUsrPfMinMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnUsrPfMinMax.ForeColor = System.Drawing.Color.White; this.btnUsrPfMinMax.FlatAppearance.BorderSize = 0;
            this.btnUsrPfClose.Dock = System.Windows.Forms.DockStyle.Right; this.btnUsrPfClose.Size = new System.Drawing.Size(50, 50); this.btnUsrPfClose.Text = "✕"; this.btnUsrPfClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnUsrPfClose.ForeColor = System.Drawing.Color.White; this.btnUsrPfClose.FlatAppearance.BorderSize = 0;

            // ==========================================
            // CARD METRICS (LEFT SIDE)
            // ==========================================
            this.cardMetrics.Location = new System.Drawing.Point(235, 160);
            this.cardMetrics.Size = new System.Drawing.Size(600, 800);

            this.lblMetricsTitle.Text = "PHYSICAL BIOMETRICS";
            this.lblMetricsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMetricsTitle.ForeColor = labelColor;
            this.lblMetricsTitle.Location = new System.Drawing.Point(40, 40);
            this.lblMetricsTitle.AutoSize = true;

            this.lblHeight.Text = "Height (cm)";
            this.lblHeight.Font = labelFont; this.lblHeight.ForeColor = labelColor; this.lblHeight.Location = new System.Drawing.Point(40, 120); this.lblHeight.AutoSize = true;
            this.txtbxHeight.Location = new System.Drawing.Point(40, 160); this.txtbxHeight.Size = new System.Drawing.Size(520, 52); this.txtbxHeight.Font = boxFont; this.txtbxHeight.BackColor = textBg; this.txtbxHeight.ForeColor = System.Drawing.Color.White; this.txtbxHeight.Enabled = false; this.txtbxHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblWeight.Text = "Current Weight (kg)";
            this.lblWeight.Font = labelFont; this.lblWeight.ForeColor = labelColor; this.lblWeight.Location = new System.Drawing.Point(40, 260); this.lblWeight.AutoSize = true;
            this.txtbxWeight.Location = new System.Drawing.Point(40, 300); this.txtbxWeight.Size = new System.Drawing.Size(520, 52); this.txtbxWeight.Font = boxFont; this.txtbxWeight.BackColor = textBg; this.txtbxWeight.ForeColor = System.Drawing.Color.White; this.txtbxWeight.Enabled = false; this.txtbxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // NEW: TARGET WEIGHT
            this.lblTargetWeight.Text = "Target Weight (kg)";
            this.lblTargetWeight.Font = labelFont;
            this.lblTargetWeight.ForeColor = System.Drawing.Color.DeepSkyBlue; // Stands out as an actionable input
            this.lblTargetWeight.Location = new System.Drawing.Point(40, 400);
            this.lblTargetWeight.AutoSize = true;

            this.txtbxTargetWeight.Location = new System.Drawing.Point(40, 440);
            this.txtbxTargetWeight.Size = new System.Drawing.Size(520, 52);
            this.txtbxTargetWeight.Font = boxFont;
            this.txtbxTargetWeight.BackColor = textBg;
            this.txtbxTargetWeight.ForeColor = System.Drawing.Color.White;
            this.txtbxTargetWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnProceed.Text = "AUTHORIZE DIRECTIVES";
            this.btnProceed.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnProceed.ForeColor = System.Drawing.Color.White;
            this.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceed.FlatAppearance.BorderSize = 0;
            this.btnProceed.Location = new System.Drawing.Point(40, 690);
            this.btnProceed.Size = new System.Drawing.Size(520, 65);
            this.btnProceed.Cursor = System.Windows.Forms.Cursors.Hand;

            this.cardMetrics.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMetricsTitle, this.lblHeight, this.txtbxHeight,
                this.lblWeight, this.txtbxWeight,
                this.lblTargetWeight, this.txtbxTargetWeight, // ADDED
                this.btnProceed
            });

            // ==========================================
            // CARD ANALYSIS (RIGHT SIDE)
            // ==========================================
            this.cardAnalysis.Location = new System.Drawing.Point(885, 160);
            this.cardAnalysis.Size = new System.Drawing.Size(850, 800);

            this.lblAnalysisTitle.Text = "SYSTEM CALCULATION"; this.lblAnalysisTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); this.lblAnalysisTitle.ForeColor = labelColor; this.lblAnalysisTitle.Location = new System.Drawing.Point(40, 40); this.lblAnalysisTitle.AutoSize = true;
            this.lblBMIValue.Text = "00.0"; this.lblBMIValue.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold); this.lblBMIValue.ForeColor = System.Drawing.Color.White; this.lblBMIValue.Location = new System.Drawing.Point(30, 80); this.lblBMIValue.AutoSize = true;
            this.lblBMICategory.Text = "AWAITING INPUT"; this.lblBMICategory.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold); this.lblBMICategory.ForeColor = System.Drawing.Color.FromArgb(80, 120, 255); this.lblBMICategory.Location = new System.Drawing.Point(45, 260); this.lblBMICategory.AutoSize = true;
            this.lblSystemRec.Text = "___________________________________________"; this.lblSystemRec.Font = labelFont; this.lblSystemRec.ForeColor = labelColor; this.lblSystemRec.Location = new System.Drawing.Point(45, 320); this.lblSystemRec.AutoSize = true;
            this.lblGoalsTitle.Text = "SELECT PRIMARY DIRECTIVE"; this.lblGoalsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); this.lblGoalsTitle.ForeColor = labelColor; this.lblGoalsTitle.Location = new System.Drawing.Point(40, 380); this.lblGoalsTitle.AutoSize = true;

            // Radio Buttons
            System.Drawing.Font rdoFont = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.rdoLoseWeight.Text = " Protocol Alpha: Fat Loss / Cut"; this.rdoLoseWeight.Font = rdoFont; this.rdoLoseWeight.ForeColor = System.Drawing.Color.White; this.rdoLoseWeight.Location = new System.Drawing.Point(45, 420); this.rdoLoseWeight.Size = new System.Drawing.Size(600, 45); this.rdoLoseWeight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoMaintain.Text = " Protocol Beta: Maintain Weight / Recomp"; this.rdoMaintain.Font = rdoFont; this.rdoMaintain.ForeColor = System.Drawing.Color.White; this.rdoMaintain.Location = new System.Drawing.Point(45, 475); this.rdoMaintain.Size = new System.Drawing.Size(600, 45); this.rdoMaintain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoGainMuscle.Text = " Protocol Omega: Gain Muscle / Bulk"; this.rdoGainMuscle.Font = rdoFont; this.rdoGainMuscle.ForeColor = System.Drawing.Color.White; this.rdoGainMuscle.Location = new System.Drawing.Point(45, 530); this.rdoGainMuscle.Size = new System.Drawing.Size(600, 45); this.rdoGainMuscle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoIncreaseStamina.Text = " Protocol Delta: Increase Stamina / Endurance"; this.rdoIncreaseStamina.Font = rdoFont; this.rdoIncreaseStamina.ForeColor = System.Drawing.Color.White; this.rdoIncreaseStamina.Location = new System.Drawing.Point(45, 585); this.rdoIncreaseStamina.Size = new System.Drawing.Size(600, 45); this.rdoIncreaseStamina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoFlexibility.Text = " Protocol Sigma: Flexibility / Mobility"; this.rdoFlexibility.Font = rdoFont; this.rdoFlexibility.ForeColor = System.Drawing.Color.White; this.rdoFlexibility.Location = new System.Drawing.Point(45, 640); this.rdoFlexibility.Size = new System.Drawing.Size(600, 45); this.rdoFlexibility.Cursor = System.Windows.Forms.Cursors.Hand;

            this.cardAnalysis.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblAnalysisTitle, this.lblBMIValue, this.lblBMICategory, this.lblSystemRec, this.lblGoalsTitle,
                this.rdoLoseWeight, this.rdoMaintain, this.rdoGainMuscle, this.rdoIncreaseStamina, this.rdoFlexibility
            });

            // Form Basics
            this.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.topheader);
            this.Controls.Add(this.cardMetrics);
            this.Controls.Add(this.cardAnalysis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "usrPfp1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.topheader.ResumeLayout(false);
            this.cardMetrics.ResumeLayout(false);
            this.cardMetrics.PerformLayout();
            this.cardAnalysis.ResumeLayout(false);
            this.cardAnalysis.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel topheader;
        private System.Windows.Forms.Button btnUsrPfMin;
        private System.Windows.Forms.Button btnUsrPfMinMax;
        private System.Windows.Forms.Button btnUsrPfClose;
        private System.Windows.Forms.Panel cardMetrics;
        private System.Windows.Forms.Panel cardAnalysis;

        private System.Windows.Forms.Label lblMetricsTitle;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtbxHeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtbxWeight;

        // ADDED VARIABLES
        private System.Windows.Forms.Label lblTargetWeight;
        private System.Windows.Forms.TextBox txtbxTargetWeight;

        private System.Windows.Forms.Button btnProceed;

        private System.Windows.Forms.Label lblAnalysisTitle;
        private System.Windows.Forms.Label lblBMIValue;
        private System.Windows.Forms.Label lblBMICategory;
        private System.Windows.Forms.Label lblSystemRec;

        private System.Windows.Forms.Label lblGoalsTitle;
        private System.Windows.Forms.RadioButton rdoLoseWeight;
        private System.Windows.Forms.RadioButton rdoMaintain;
        private System.Windows.Forms.RadioButton rdoGainMuscle;
        private System.Windows.Forms.RadioButton rdoIncreaseStamina;
        private System.Windows.Forms.RadioButton rdoFlexibility;
    }
}