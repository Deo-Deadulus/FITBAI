namespace FITBAI
{
    partial class ActivityLog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.cardInput = new System.Windows.Forms.Panel();
            this.cardHistory = new System.Windows.Forms.Panel();

            // Input Controls
            this.lblInputTitle = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.txtbxWeight = new System.Windows.Forms.TextBox();
            this.lblWater = new System.Windows.Forms.Label();
            this.btnWaterMinus = new System.Windows.Forms.Button();
            this.lblWaterCount = new System.Windows.Forms.Label();
            this.btnWaterPlus = new System.Windows.Forms.Button();

            // NEW RPE CONTROLS
            this.lblRpeTitle = new System.Windows.Forms.Label();
            this.trkRPE = new System.Windows.Forms.TrackBar();
            this.lblRpeDesc = new System.Windows.Forms.Label();

            this.btnSaveLog = new System.Windows.Forms.Button();
            this.lblDateDisplay = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();

            // History Controls
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.pnlChart = new System.Windows.Forms.Panel();

            this.cardInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkRPE)).BeginInit();
            this.cardHistory.SuspendLayout();
            this.SuspendLayout();

            // --- Shared Styles ---
            System.Drawing.Font headerFont = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font titleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            System.Drawing.Color labelColor = System.Drawing.Color.FromArgb(170, 180, 220);
            System.Drawing.Color textBg = System.Drawing.Color.FromArgb(20, 25, 60);

            // lblMainTitle
            this.lblMainTitle.Font = headerFont;
            this.lblMainTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblMainTitle.Location = new System.Drawing.Point(85, 40);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(600, 60);
            this.lblMainTitle.Text = "Tactical Recovery Log";

            // lblDateDisplay
            this.lblDateDisplay.Font = titleFont;
            this.lblDateDisplay.ForeColor = labelColor;
            this.lblDateDisplay.Location = new System.Drawing.Point(85, 100);
            this.lblDateDisplay.Name = "lblDateDisplay";
            this.lblDateDisplay.Size = new System.Drawing.Size(400, 30);
            this.lblDateDisplay.Text = "DATE PLACEHOLDER";

            // cardInput
            this.cardInput.Location = new System.Drawing.Point(85, 150);
            this.cardInput.Name = "cardInput";
            this.cardInput.Size = new System.Drawing.Size(500, 800);

            this.lblInputTitle.Text = "DAILY METRICS";
            this.lblInputTitle.Font = titleFont;
            this.lblInputTitle.ForeColor = labelColor;
            this.lblInputTitle.Location = new System.Drawing.Point(40, 40);
            this.lblInputTitle.AutoSize = true;

            this.lblStatus.Text = "SYSTEM STATUS: AWAITING INPUT";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.Orange;
            this.lblStatus.Location = new System.Drawing.Point(40, 75);
            this.lblStatus.AutoSize = true;

            this.lblWeight.Text = "Weight (kg)";
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            this.lblWeight.ForeColor = labelColor;
            this.lblWeight.Location = new System.Drawing.Point(40, 140);
            this.lblWeight.AutoSize = true;

            this.txtbxWeight.Location = new System.Drawing.Point(40, 180);
            this.txtbxWeight.Size = new System.Drawing.Size(420, 45);
            this.txtbxWeight.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txtbxWeight.BackColor = textBg;
            this.txtbxWeight.ForeColor = System.Drawing.Color.White;
            this.txtbxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblWater.Text = "Hydration (Glasses)";
            this.lblWater.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            this.lblWater.ForeColor = labelColor;
            this.lblWater.Location = new System.Drawing.Point(40, 260);
            this.lblWater.AutoSize = true;

            this.btnWaterMinus.Text = "−";
            this.btnWaterMinus.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnWaterMinus.ForeColor = System.Drawing.Color.White;
            this.btnWaterMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaterMinus.Location = new System.Drawing.Point(40, 300);
            this.btnWaterMinus.Size = new System.Drawing.Size(60, 60);

            this.lblWaterCount.Text = "0";
            this.lblWaterCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblWaterCount.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblWaterCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWaterCount.Location = new System.Drawing.Point(110, 300);
            this.lblWaterCount.Size = new System.Drawing.Size(100, 60);

            this.btnWaterPlus.Text = "+";
            this.btnWaterPlus.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnWaterPlus.ForeColor = System.Drawing.Color.White;
            this.btnWaterPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaterPlus.Location = new System.Drawing.Point(220, 300);
            this.btnWaterPlus.Size = new System.Drawing.Size(60, 60);

            // NEW: RPE SCALE
            this.lblRpeTitle.Text = "Intensity Scale (RPE)";
            this.lblRpeTitle.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            this.lblRpeTitle.ForeColor = labelColor;
            this.lblRpeTitle.Location = new System.Drawing.Point(40, 400);
            this.lblRpeTitle.AutoSize = true;

            this.trkRPE.Location = new System.Drawing.Point(40, 440);
            this.trkRPE.Size = new System.Drawing.Size(420, 45);
            this.trkRPE.Minimum = 0;
            this.trkRPE.Maximum = 10;
            this.trkRPE.Value = 0;
            this.trkRPE.TickStyle = System.Windows.Forms.TickStyle.BottomRight;

            this.lblRpeDesc.Text = "0 - Rest Day / No Training";
            this.lblRpeDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRpeDesc.ForeColor = System.Drawing.Color.White;
            this.lblRpeDesc.Location = new System.Drawing.Point(40, 490);
            this.lblRpeDesc.AutoSize = true;

            // SAVE BUTTON
            this.btnSaveLog.Text = "SECURE METRICS";
            this.btnSaveLog.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnSaveLog.ForeColor = System.Drawing.Color.White;
            this.btnSaveLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveLog.FlatAppearance.BorderSize = 0;
            this.btnSaveLog.Location = new System.Drawing.Point(40, 690);
            this.btnSaveLog.Size = new System.Drawing.Size(420, 65);

            this.cardInput.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblInputTitle, this.lblStatus, this.lblWeight, this.txtbxWeight,
                this.lblWater, this.btnWaterMinus, this.lblWaterCount, this.btnWaterPlus,
                this.lblRpeTitle, this.trkRPE, this.lblRpeDesc, this.btnSaveLog
            });

            // cardHistory
            this.cardHistory.Location = new System.Drawing.Point(620, 150);
            this.cardHistory.Name = "cardHistory";
            this.cardHistory.Size = new System.Drawing.Size(950, 800);

            this.lblHistoryTitle.Text = "BIOMETRIC TREND ANALYSIS";
            this.lblHistoryTitle.Font = titleFont;
            this.lblHistoryTitle.ForeColor = labelColor;
            this.lblHistoryTitle.Location = new System.Drawing.Point(40, 40);
            this.lblHistoryTitle.AutoSize = true;

            // THE CHART PANEL
            this.pnlChart.Location = new System.Drawing.Point(40, 100);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(870, 650);
            this.pnlChart.BackColor = System.Drawing.Color.Transparent;

            this.cardHistory.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblHistoryTitle, this.pnlChart
            });

            // Form Basics
            this.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            this.ClientSize = new System.Drawing.Size(1670, 1023);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.lblDateDisplay);
            this.Controls.Add(this.cardInput);
            this.Controls.Add(this.cardHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActivityLog";

            this.cardInput.ResumeLayout(false); this.cardInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkRPE)).EndInit();
            this.cardHistory.ResumeLayout(false); this.cardHistory.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblDateDisplay;
        private System.Windows.Forms.Panel cardInput;
        private System.Windows.Forms.Panel cardHistory;

        private System.Windows.Forms.Label lblInputTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtbxWeight;
        private System.Windows.Forms.Label lblWater;
        private System.Windows.Forms.Button btnWaterMinus;
        private System.Windows.Forms.Label lblWaterCount;
        private System.Windows.Forms.Button btnWaterPlus;

        private System.Windows.Forms.Label lblRpeTitle;
        private System.Windows.Forms.TrackBar trkRPE;
        private System.Windows.Forms.Label lblRpeDesc;

        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.Panel pnlChart;
    }
}