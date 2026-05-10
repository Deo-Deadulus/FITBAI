namespace FITBAI
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelCenterContent = new Panel();
            lblWelcome = new Label();
            lblRoleTag = new Label();
            cardBMI = new Panel();
            label1 = new Label();
            lblBMIValue = new Label();
            lblBMICategory = new Label();
            cardStreak = new Panel();
            label2 = new Label();
            lblStreakValue = new Label();
            cardTrend = new Panel();
            label3 = new Label();
            lblWeightTrend = new Label();
            cardToday = new Panel();
            label4 = new Label();
            lblTodaySession = new Label();
            cardReminders = new Panel();
            label5 = new Label();
            lstReminders = new ListBox();
            panelCenterContent.SuspendLayout();
            cardBMI.SuspendLayout();
            cardStreak.SuspendLayout();
            cardTrend.SuspendLayout();
            cardToday.SuspendLayout();
            cardReminders.SuspendLayout();
            SuspendLayout();
            // 
            // panelCenterContent
            // 
            panelCenterContent.BackColor = Color.Transparent;
            panelCenterContent.Controls.Add(lblWelcome);
            panelCenterContent.Controls.Add(lblRoleTag);
            panelCenterContent.Controls.Add(cardBMI);
            panelCenterContent.Controls.Add(cardStreak);
            panelCenterContent.Controls.Add(cardTrend);
            panelCenterContent.Controls.Add(cardToday);
            panelCenterContent.Controls.Add(cardReminders);
            panelCenterContent.Dock = DockStyle.Fill;
            panelCenterContent.Location = new Point(0, 0);
            panelCenterContent.Name = "panelCenterContent";
            panelCenterContent.Size = new Size(1670, 1023);
            panelCenterContent.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.Transparent;
            lblWelcome.Location = new Point(85, 35);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(1200, 95);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome back!";
            // 
            // lblRoleTag
            // 
            lblRoleTag.AutoSize = true;
            lblRoleTag.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRoleTag.ForeColor = Color.FromArgb(100, 120, 200);
            lblRoleTag.Location = new Point(95, 135);
            lblRoleTag.Name = "lblRoleTag";
            lblRoleTag.Size = new Size(170, 28);
            lblRoleTag.TabIndex = 1;
            lblRoleTag.Text = "CLIENT DOMAIN";
            // 
            // cardBMI
            // 
            cardBMI.Controls.Add(label1);
            cardBMI.Controls.Add(lblBMIValue);
            cardBMI.Controls.Add(lblBMICategory);
            cardBMI.Location = new Point(85, 220);
            cardBMI.Name = "cardBMI";
            cardBMI.Size = new Size(439, 250);
            cardBMI.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 14F);
            label1.ForeColor = Color.FromArgb(170, 180, 220);
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(138, 32);
            label1.TabIndex = 0;
            label1.Text = "Current BMI";
            // 
            // lblBMIValue
            // 
            lblBMIValue.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblBMIValue.ForeColor = Color.White;
            lblBMIValue.Location = new Point(25, 90);
            lblBMIValue.Name = "lblBMIValue";
            lblBMIValue.Size = new Size(250, 81);
            lblBMIValue.TabIndex = 1;
            lblBMIValue.Text = "--.-";
            // 
            // lblBMICategory
            // 
            lblBMICategory.AutoSize = true;
            lblBMICategory.Font = new Font("Segoe UI", 16F);
            lblBMICategory.Location = new Point(30, 170);
            lblBMICategory.Name = "lblBMICategory";
            lblBMICategory.Size = new Size(130, 37);
            lblBMICategory.TabIndex = 2;
            lblBMICategory.Text = "Unknown";
            // 
            // cardStreak
            // 
            cardStreak.Controls.Add(label2);
            cardStreak.Controls.Add(lblStreakValue);
            cardStreak.Location = new Point(605, 220);
            cardStreak.Name = "cardStreak";
            cardStreak.Size = new Size(460, 250);
            cardStreak.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 14F);
            label2.ForeColor = Color.FromArgb(170, 180, 220);
            label2.Location = new Point(30, 30);
            label2.Name = "label2";
            label2.Size = new Size(159, 32);
            label2.TabIndex = 0;
            label2.Text = "Session Streak";
            // 
            // lblStreakValue
            // 
            lblStreakValue.AutoSize = true;
            lblStreakValue.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblStreakValue.ForeColor = Color.FromArgb(180, 80, 255);
            lblStreakValue.Location = new Point(25, 90);
            lblStreakValue.Name = "lblStreakValue";
            lblStreakValue.Size = new Size(59, 81);
            lblStreakValue.TabIndex = 1;
            lblStreakValue.Text = "-";
            // 
            // cardTrend
            // 
            cardTrend.Controls.Add(label3);
            cardTrend.Controls.Add(lblWeightTrend);
            cardTrend.Location = new Point(1125, 220);
            cardTrend.Name = "cardTrend";
            cardTrend.Size = new Size(460, 250);
            cardTrend.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 14F);
            label3.ForeColor = Color.FromArgb(170, 180, 220);
            label3.Location = new Point(30, 30);
            label3.Name = "label3";
            label3.Size = new Size(151, 32);
            label3.TabIndex = 0;
            label3.Text = "Weight Trend";
            // 
            // lblWeightTrend
            // 
            lblWeightTrend.AutoSize = true;
            lblWeightTrend.Font = new Font("Segoe UI", 24F);
            lblWeightTrend.ForeColor = Color.White;
            lblWeightTrend.Location = new Point(25, 100);
            lblWeightTrend.Name = "lblWeightTrend";
            lblWeightTrend.Size = new Size(165, 54);
            lblWeightTrend.TabIndex = 1;
            lblWeightTrend.Text = "No data";
            // 
            // cardToday
            // 
            cardToday.Controls.Add(label4);
            cardToday.Controls.Add(lblTodaySession);
            cardToday.Location = new Point(85, 530);
            cardToday.Name = "cardToday";
            cardToday.Size = new Size(980, 350);
            cardToday.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 14F);
            label4.ForeColor = Color.FromArgb(170, 180, 220);
            label4.Location = new Point(30, 30);
            label4.Name = "label4";
            label4.Size = new Size(192, 32);
            label4.TabIndex = 0;
            label4.Text = "Today's Objective";
            // 
            // lblTodaySession
            // 
            lblTodaySession.AutoSize = true;
            lblTodaySession.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTodaySession.ForeColor = Color.White;
            lblTodaySession.Location = new Point(25, 100);
            lblTodaySession.Name = "lblTodaySession";
            lblTodaySession.Size = new Size(440, 72);
            lblTodaySession.TabIndex = 1;
            lblTodaySession.Text = "Awaiting Orders";
            // 
            // cardReminders
            // 
            cardReminders.Controls.Add(label5);
            cardReminders.Controls.Add(lstReminders);
            cardReminders.Location = new Point(1125, 530);
            cardReminders.Name = "cardReminders";
            cardReminders.Size = new Size(460, 350);
            cardReminders.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semilight", 14F);
            label5.ForeColor = Color.FromArgb(170, 180, 220);
            label5.Location = new Point(30, 30);
            label5.Name = "label5";
            label5.Size = new Size(113, 32);
            label5.TabIndex = 0;
            label5.Text = "Directives";
            // 
            // lstReminders
            // 
            lstReminders.BackColor = Color.FromArgb(15, 20, 50);
            lstReminders.BorderStyle = BorderStyle.None;
            lstReminders.Font = new Font("Segoe UI", 14F);
            lstReminders.ForeColor = Color.White;
            lstReminders.Location = new Point(30, 90);
            lstReminders.Name = "lstReminders";
            lstReminders.Size = new Size(400, 217);
            lstReminders.TabIndex = 1;
            // 
            // Dashboard
            // 
            BackColor = Color.FromArgb(15, 20, 40);
            ClientSize = new Size(1670, 1023);
            Controls.Add(panelCenterContent);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            Load += Dashboard_Load;
            panelCenterContent.ResumeLayout(false);
            panelCenterContent.PerformLayout();
            cardBMI.ResumeLayout(false);
            cardBMI.PerformLayout();
            cardStreak.ResumeLayout(false);
            cardStreak.PerformLayout();
            cardTrend.ResumeLayout(false);
            cardTrend.PerformLayout();
            cardToday.ResumeLayout(false);
            cardToday.PerformLayout();
            cardReminders.ResumeLayout(false);
            cardReminders.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelCenterContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRoleTag;

        private System.Windows.Forms.Panel cardBMI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBMIValue;
        private System.Windows.Forms.Label lblBMICategory;

        private System.Windows.Forms.Panel cardStreak;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStreakValue;

        private System.Windows.Forms.Panel cardTrend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWeightTrend;

        private System.Windows.Forms.Panel cardToday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTodaySession;

        private System.Windows.Forms.Panel cardReminders;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstReminders;
    }
}