namespace FITBAI
{
    partial class ProgressMatrix
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            lblMainTitle = new Label();
            lblSubtitle = new Label();
            cardStats = new Panel();
            lblTitleStart = new Label();
            lblValStart = new Label();
            lblTitleCurrent = new Label();
            lblValCurrent = new Label();
            lblTitleGoal = new Label();
            lblValGoal = new Label();
            lblTitleDelta = new Label();
            lblValDelta = new Label();
            cardChart = new Panel();
            chartProgress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            cardStats.SuspendLayout();
            cardChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartProgress).BeginInit();
            SuspendLayout();
            // 
            // lblMainTitle
            // 
            lblMainTitle.Font = new Font("Old English Text MT", 36F);
            lblMainTitle.ForeColor = Color.White;
            lblMainTitle.Location = new Point(80, 30);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(400, 60);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "Progress";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI Semilight", 14F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.FromArgb(80, 120, 255);
            lblSubtitle.Location = new Point(85, 95);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 30);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Track your body achievement.";
            // 
            // cardStats
            // 
            cardStats.BackColor = Color.Transparent;
            cardStats.Controls.Add(lblTitleStart);
            cardStats.Controls.Add(lblValStart);
            cardStats.Controls.Add(lblTitleCurrent);
            cardStats.Controls.Add(lblValCurrent);
            cardStats.Controls.Add(lblValDelta);
            cardStats.Controls.Add(lblValGoal);
            cardStats.Controls.Add(lblTitleGoal);
            cardStats.Controls.Add(lblTitleDelta);
            cardStats.Location = new Point(85, 150);
            cardStats.Name = "cardStats";
            cardStats.Size = new Size(1480, 130);
            cardStats.TabIndex = 2;
            // 
            // lblTitleStart
            // 
            lblTitleStart.AutoSize = true;
            lblTitleStart.Font = new Font("Segoe UI Semibold", 12F);
            lblTitleStart.ForeColor = Color.FromArgb(170, 180, 220);
            lblTitleStart.Location = new Point(40, 25);
            lblTitleStart.Name = "lblTitleStart";
            lblTitleStart.Size = new Size(150, 28);
            lblTitleStart.TabIndex = 0;
            lblTitleStart.Text = "START WEIGHT";
            // 
            // lblValStart
            // 
            lblValStart.AutoSize = true;
            lblValStart.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValStart.ForeColor = Color.White;
            lblValStart.Location = new Point(40, 53);
            lblValStart.Name = "lblValStart";
            lblValStart.Size = new Size(119, 54);
            lblValStart.TabIndex = 1;
            lblValStart.Text = "-- KG";
            // 
            // lblTitleCurrent
            // 
            lblTitleCurrent.AutoSize = true;
            lblTitleCurrent.Font = new Font("Segoe UI Semibold", 12F);
            lblTitleCurrent.ForeColor = Color.FromArgb(170, 180, 220);
            lblTitleCurrent.Location = new Point(347, 25);
            lblTitleCurrent.Name = "lblTitleCurrent";
            lblTitleCurrent.Size = new Size(179, 28);
            lblTitleCurrent.TabIndex = 2;
            lblTitleCurrent.Text = "CURRENT WEIGHT";
            // 
            // lblValCurrent
            // 
            lblValCurrent.AutoSize = true;
            lblValCurrent.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValCurrent.ForeColor = Color.DeepSkyBlue;
            lblValCurrent.Location = new Point(347, 53);
            lblValCurrent.Name = "lblValCurrent";
            lblValCurrent.Size = new Size(119, 54);
            lblValCurrent.TabIndex = 3;
            lblValCurrent.Text = "-- KG";
            // 
            // lblTitleGoal
            // 
            lblTitleGoal.AutoSize = true;
            lblTitleGoal.Font = new Font("Segoe UI Semibold", 12F);
            lblTitleGoal.ForeColor = Color.FromArgb(170, 180, 220);
            lblTitleGoal.Location = new Point(806, 25);
            lblTitleGoal.Name = "lblTitleGoal";
            lblTitleGoal.Size = new Size(140, 28);
            lblTitleGoal.TabIndex = 4;
            lblTitleGoal.Text = "TARGET GOAL";
            // 
            // lblValGoal
            // 
            lblValGoal.AutoSize = true;
            lblValGoal.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValGoal.ForeColor = Color.White;
            lblValGoal.Location = new Point(806, 65);
            lblValGoal.Name = "lblValGoal";
            lblValGoal.Size = new Size(119, 54);
            lblValGoal.TabIndex = 5;
            lblValGoal.Text = "-- KG";
            // 
            // lblTitleDelta
            // 
            lblTitleDelta.AutoSize = true;
            lblTitleDelta.Font = new Font("Segoe UI Semibold", 12F);
            lblTitleDelta.ForeColor = Color.FromArgb(170, 180, 220);
            lblTitleDelta.Location = new Point(1234, 25);
            lblTitleDelta.Name = "lblTitleDelta";
            lblTitleDelta.Size = new Size(154, 28);
            lblTitleDelta.TabIndex = 6;
            lblTitleDelta.Text = "TOTAL CHANGE";
            // 
            // lblValDelta
            // 
            lblValDelta.AutoSize = true;
            lblValDelta.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValDelta.ForeColor = Color.LimeGreen;
            lblValDelta.Location = new Point(1234, 65);
            lblValDelta.Name = "lblValDelta";
            lblValDelta.Size = new Size(119, 54);
            lblValDelta.TabIndex = 7;
            lblValDelta.Text = "-- KG";
            // 
            // cardChart
            // 
            cardChart.BackColor = Color.Transparent;
            cardChart.Controls.Add(chartProgress);
            cardChart.Location = new Point(85, 310);
            cardChart.Name = "cardChart";
            cardChart.Size = new Size(1480, 660);
            cardChart.TabIndex = 3;
            // 
            // chartProgress
            // 
            chartProgress.BackColor = Color.Transparent;
            chartArea1.Name = "MainArea";
            chartProgress.ChartAreas.Add(chartArea1);
            chartProgress.Location = new Point(30, 30);
            chartProgress.Name = "chartProgress";
            series1.ChartArea = "MainArea";
            series1.Name = "WeightLine";
            chartProgress.Series.Add(series1);
            chartProgress.Size = new Size(1420, 600);
            chartProgress.TabIndex = 0;
            // 
            // ProgressMatrix
            // 
            BackColor = Color.FromArgb(10, 14, 30);
            ClientSize = new Size(1670, 1023);
            Controls.Add(lblMainTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(cardStats);
            Controls.Add(cardChart);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProgressMatrix";
            cardStats.ResumeLayout(false);
            cardStats.PerformLayout();
            cardChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartProgress).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel cardStats;
        private System.Windows.Forms.Panel cardChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProgress;

        private System.Windows.Forms.Label lblTitleStart;
        private System.Windows.Forms.Label lblTitleCurrent;
        private System.Windows.Forms.Label lblTitleGoal;
        private System.Windows.Forms.Label lblTitleDelta;

        private System.Windows.Forms.Label lblValStart;
        private System.Windows.Forms.Label lblValCurrent;
        private System.Windows.Forms.Label lblValGoal;
        private System.Windows.Forms.Label lblValDelta;
    }
}