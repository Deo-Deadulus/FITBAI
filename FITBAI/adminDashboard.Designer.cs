namespace FITBAI
{
    partial class adminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            cardClients = new Panel();
            lblClientCount = new Label();
            lblClientText = new Label();
            cardSchedules = new Panel();
            lblScheduleCount = new Label();
            lblScheduleText = new Label();
            cardWorkouts = new Panel();
            lblWorkoutCount = new Label();
            lblWorkoutText = new Label();
            cardAlerts = new Panel();
            lblAlertText = new Label();
            lblAlertCount = new Label();
            cardGoals = new Panel();
            lblGoalText = new Label();
            cardLeaderboard = new Panel();
            lblLeaderboardText = new Label();
            cardClients.SuspendLayout();
            cardSchedules.SuspendLayout();
            cardWorkouts.SuspendLayout();
            cardAlerts.SuspendLayout();
            cardGoals.SuspendLayout();
            cardLeaderboard.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial Black", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 20, 40);
            lblTitle.Location = new Point(90, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(600, 60);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "USER ANALYTICS";
            // 
            // cardClients
            // 
            cardClients.Controls.Add(lblClientCount);
            cardClients.Controls.Add(lblClientText);
            cardClients.Location = new Point(90, 150);
            cardClients.Name = "cardClients";
            cardClients.Size = new Size(300, 150);
            cardClients.TabIndex = 5;
            // 
            // lblClientCount
            // 
            lblClientCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblClientCount.ForeColor = Color.White;
            lblClientCount.Location = new Point(20, 20);
            lblClientCount.Name = "lblClientCount";
            lblClientCount.Size = new Size(261, 70);
            lblClientCount.TabIndex = 0;
            lblClientCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblClientText
            // 
            lblClientText.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            lblClientText.ForeColor = Color.FromArgb(170, 180, 220);
            lblClientText.Location = new Point(20, 90);
            lblClientText.Name = "lblClientText";
            lblClientText.Size = new Size(261, 30);
            lblClientText.TabIndex = 1;
            lblClientText.Text = "TOTAL ACTIVE CLIENTS";
            lblClientText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardSchedules
            // 
            cardSchedules.Controls.Add(lblScheduleCount);
            cardSchedules.Controls.Add(lblScheduleText);
            cardSchedules.Location = new Point(440, 150);
            cardSchedules.Name = "cardSchedules";
            cardSchedules.Size = new Size(300, 150);
            cardSchedules.TabIndex = 4;
            // 
            // lblScheduleCount
            // 
            lblScheduleCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblScheduleCount.ForeColor = Color.White;
            lblScheduleCount.Location = new Point(16, 20);
            lblScheduleCount.Name = "lblScheduleCount";
            lblScheduleCount.Size = new Size(264, 70);
            lblScheduleCount.TabIndex = 0;
            lblScheduleCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblScheduleText
            // 
            lblScheduleText.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            lblScheduleText.ForeColor = Color.FromArgb(170, 180, 220);
            lblScheduleText.Location = new Point(16, 90);
            lblScheduleText.Name = "lblScheduleText";
            lblScheduleText.Size = new Size(264, 30);
            lblScheduleText.TabIndex = 1;
            lblScheduleText.Text = "ACTIVE SCHEDULES";
            lblScheduleText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardWorkouts
            // 
            cardWorkouts.Controls.Add(lblWorkoutCount);
            cardWorkouts.Controls.Add(lblWorkoutText);
            cardWorkouts.Location = new Point(90, 350);
            cardWorkouts.Name = "cardWorkouts";
            cardWorkouts.Size = new Size(300, 150);
            cardWorkouts.TabIndex = 3;
            // 
            // lblWorkoutCount
            // 
            lblWorkoutCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblWorkoutCount.ForeColor = Color.White;
            lblWorkoutCount.Location = new Point(29, 20);
            lblWorkoutCount.Name = "lblWorkoutCount";
            lblWorkoutCount.Size = new Size(252, 70);
            lblWorkoutCount.TabIndex = 0;
            lblWorkoutCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWorkoutText
            // 
            lblWorkoutText.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            lblWorkoutText.ForeColor = Color.FromArgb(170, 180, 220);
            lblWorkoutText.Location = new Point(29, 90);
            lblWorkoutText.Name = "lblWorkoutText";
            lblWorkoutText.Size = new Size(252, 30);
            lblWorkoutText.TabIndex = 1;
            lblWorkoutText.Text = "TOTAL LOGGED ACTIVITY";
            lblWorkoutText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardAlerts
            // 
            cardAlerts.Controls.Add(lblAlertText);
            cardAlerts.Controls.Add(lblAlertCount);
            cardAlerts.Location = new Point(440, 350);
            cardAlerts.Name = "cardAlerts";
            cardAlerts.Size = new Size(300, 150);
            cardAlerts.TabIndex = 2;
            // 
            // lblAlertText
            // 
            lblAlertText.Font = new Font("Arial Black", 12F, FontStyle.Bold);
            lblAlertText.ForeColor = Color.FromArgb(170, 180, 220);
            lblAlertText.Location = new Point(16, 90);
            lblAlertText.Name = "lblAlertText";
            lblAlertText.Size = new Size(264, 30);
            lblAlertText.TabIndex = 1;
            lblAlertText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAlertCount
            // 
            lblAlertCount.BackColor = Color.Transparent;
            lblAlertCount.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblAlertCount.ForeColor = Color.Crimson;
            lblAlertCount.Location = new Point(16, 20);
            lblAlertCount.Name = "lblAlertCount";
            lblAlertCount.Size = new Size(264, 70);
            lblAlertCount.TabIndex = 0;
            lblAlertCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardGoals
            // 
            cardGoals.Controls.Add(lblGoalText);
            cardGoals.Location = new Point(796, 150);
            cardGoals.Name = "cardGoals";
            cardGoals.Size = new Size(495, 685);
            cardGoals.TabIndex = 1;
            // 
            // lblGoalText
            // 
            lblGoalText.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGoalText.ForeColor = Color.FromArgb(170, 180, 220);
            lblGoalText.Location = new Point(25, 20);
            lblGoalText.Name = "lblGoalText";
            lblGoalText.Size = new Size(446, 25);
            lblGoalText.TabIndex = 0;
            lblGoalText.Text = "GLOBAL DEMOGRAPHICS (PRIMARY GOALS)";
            // 
            // cardLeaderboard
            // 
            cardLeaderboard.Controls.Add(lblLeaderboardText);
            cardLeaderboard.Location = new Point(90, 538);
            cardLeaderboard.Name = "cardLeaderboard";
            cardLeaderboard.Size = new Size(650, 297);
            cardLeaderboard.TabIndex = 0;
            // 
            // lblLeaderboardText
            // 
            lblLeaderboardText.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLeaderboardText.ForeColor = Color.FromArgb(170, 180, 220);
            lblLeaderboardText.Location = new Point(20, 10);
            lblLeaderboardText.Name = "lblLeaderboardText";
            lblLeaderboardText.Size = new Size(360, 25);
            lblLeaderboardText.TabIndex = 0;
            lblLeaderboardText.Text = "TOP MEMBERS (MOST ACTIVITY)";
            // 
            // adminDashboard
            // 
            BackColor = Color.FromArgb(15, 20, 40);
            ClientSize = new Size(1321, 879);
            Controls.Add(cardLeaderboard);
            Controls.Add(cardGoals);
            Controls.Add(cardAlerts);
            Controls.Add(cardWorkouts);
            Controls.Add(cardSchedules);
            Controls.Add(cardClients);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "adminDashboard";
            Text = "Admin Dashboard";
            cardClients.ResumeLayout(false);
            cardSchedules.ResumeLayout(false);
            cardWorkouts.ResumeLayout(false);
            cardAlerts.ResumeLayout(false);
            cardGoals.ResumeLayout(false);
            cardLeaderboard.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel cardClients;
        private System.Windows.Forms.Label lblClientCount;
        private System.Windows.Forms.Label lblClientText;
        private System.Windows.Forms.Panel cardSchedules;
        private System.Windows.Forms.Label lblScheduleCount;
        private System.Windows.Forms.Label lblScheduleText;
        private System.Windows.Forms.Panel cardWorkouts;
        private System.Windows.Forms.Label lblWorkoutCount;
        private System.Windows.Forms.Label lblWorkoutText;
        private System.Windows.Forms.Panel cardAlerts;
        private System.Windows.Forms.Label lblAlertCount;

        private System.Windows.Forms.Panel cardGoals;
        private System.Windows.Forms.Label lblGoalText;

        private System.Windows.Forms.Panel cardLeaderboard;
        private System.Windows.Forms.Label lblLeaderboardText;
        private Label lblAlertText;
    }
}