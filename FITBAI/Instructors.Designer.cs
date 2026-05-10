namespace FITBAI
{
    partial class Instructors
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblBmiTitle = new System.Windows.Forms.Label();
            this.lblBmiValue = new System.Windows.Forms.Label();
            this.lblBmiCategory = new System.Windows.Forms.Label();
            this.lblPrefTitle = new System.Windows.Forms.Label();
            this.lblGoal = new System.Windows.Forms.Label();
            this.cmbGoal = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.cmbSchedule = new System.Windows.Forms.ComboBox();
            this.btnFindMatch = new System.Windows.Forms.Button();
            this.flowInstructors = new System.Windows.Forms.FlowLayoutPanel();

            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblMainTitle.Location = new System.Drawing.Point(85, 40);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(800, 60);
            this.lblMainTitle.Text = "Tactical Instructor Matchmaking";

            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.lblBmiTitle);
            this.panelSidebar.Controls.Add(this.lblBmiValue);
            this.panelSidebar.Controls.Add(this.lblBmiCategory);
            this.panelSidebar.Controls.Add(this.lblPrefTitle);
            this.panelSidebar.Controls.Add(this.lblGoal);
            this.panelSidebar.Controls.Add(this.cmbGoal);
            this.panelSidebar.Controls.Add(this.lblGender);
            this.panelSidebar.Controls.Add(this.cmbGender);
            this.panelSidebar.Controls.Add(this.lblSchedule);
            this.panelSidebar.Controls.Add(this.cmbSchedule);
            this.panelSidebar.Controls.Add(this.btnFindMatch);
            this.panelSidebar.Location = new System.Drawing.Point(85, 130);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(350, 850);

            // BMI Section
            this.lblBmiTitle.AutoSize = true;
            this.lblBmiTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBmiTitle.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            this.lblBmiTitle.Location = new System.Drawing.Point(20, 20);
            this.lblBmiTitle.Text = "YOUR BIOMETRIC PROFILE";

            this.lblBmiValue.AutoSize = true;
            this.lblBmiValue.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblBmiValue.ForeColor = System.Drawing.Color.White;
            this.lblBmiValue.Location = new System.Drawing.Point(15, 50);
            this.lblBmiValue.Text = "00.0";

            this.lblBmiCategory.AutoSize = true;
            this.lblBmiCategory.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            this.lblBmiCategory.ForeColor = System.Drawing.Color.FromArgb(80, 120, 255);
            this.lblBmiCategory.Location = new System.Drawing.Point(25, 120);
            this.lblBmiCategory.Text = "Awaiting Data";

            // Preferences Section
            this.lblPrefTitle.AutoSize = true;
            this.lblPrefTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPrefTitle.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            this.lblPrefTitle.Location = new System.Drawing.Point(20, 220);
            this.lblPrefTitle.Text = "MATCHING FILTERS";

            System.Drawing.Font labelFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font comboFont = new System.Drawing.Font("Segoe UI", 14F);
            System.Drawing.Color darkBg = System.Drawing.Color.FromArgb(15, 20, 40);

            // Goal Combo
            this.lblGoal.Text = "PRIMARY GOAL"; this.lblGoal.Font = labelFont; this.lblGoal.ForeColor = System.Drawing.Color.White; this.lblGoal.Location = new System.Drawing.Point(20, 270); this.lblGoal.AutoSize = true;
            this.cmbGoal.Items.AddRange(new object[] { "Weight Loss", "Build Muscle", "Increase Stamina", "Flexibility" });
            this.cmbGoal.Location = new System.Drawing.Point(20, 300); this.cmbGoal.Size = new System.Drawing.Size(300, 40);
            this.cmbGoal.Font = comboFont; this.cmbGoal.BackColor = darkBg; this.cmbGoal.ForeColor = System.Drawing.Color.White; this.cmbGoal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Gender Combo
            this.lblGender.Text = "PREFERRED GENDER"; this.lblGender.Font = labelFont; this.lblGender.ForeColor = System.Drawing.Color.White; this.lblGender.Location = new System.Drawing.Point(20, 360); this.lblGender.AutoSize = true;
            this.cmbGender.Items.AddRange(new object[] { "Any", "Male", "Female" });
            this.cmbGender.Location = new System.Drawing.Point(20, 390); this.cmbGender.Size = new System.Drawing.Size(300, 40);
            this.cmbGender.Font = comboFont; this.cmbGender.BackColor = darkBg; this.cmbGender.ForeColor = System.Drawing.Color.White; this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Schedule Combo
            this.lblSchedule.Text = "SCHEDULE PREFERENCE"; this.lblSchedule.Font = labelFont; this.lblSchedule.ForeColor = System.Drawing.Color.White; this.lblSchedule.Location = new System.Drawing.Point(20, 450); this.lblSchedule.AutoSize = true;
            this.cmbSchedule.Items.AddRange(new object[] { "Any", "Morning", "Evening", "Weekends" });
            this.cmbSchedule.Location = new System.Drawing.Point(20, 480); this.cmbSchedule.Size = new System.Drawing.Size(300, 40);
            this.cmbSchedule.Font = comboFont; this.cmbSchedule.BackColor = darkBg; this.cmbSchedule.ForeColor = System.Drawing.Color.White; this.cmbSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Match Button
            this.btnFindMatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindMatch.FlatAppearance.BorderSize = 0;
            this.btnFindMatch.ForeColor = System.Drawing.Color.White;
            this.btnFindMatch.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnFindMatch.Location = new System.Drawing.Point(20, 750);
            this.btnFindMatch.Size = new System.Drawing.Size(300, 60);
            this.btnFindMatch.Text = "FIND MY MATCH";

            // 
            // flowInstructors
            // 
            this.flowInstructors.AutoScroll = true;
            this.flowInstructors.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            this.flowInstructors.Location = new System.Drawing.Point(470, 130);
            this.flowInstructors.Name = "flowInstructors";
            this.flowInstructors.Size = new System.Drawing.Size(1150, 850);
            this.flowInstructors.Padding = new System.Windows.Forms.Padding(10);

            // 
            // Instructors
            // 
            this.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            this.ClientSize = new System.Drawing.Size(1670, 1023);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.flowInstructors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Instructors";

            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblBmiTitle;
        private System.Windows.Forms.Label lblBmiValue;
        private System.Windows.Forms.Label lblBmiCategory;
        private System.Windows.Forms.Label lblPrefTitle;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.ComboBox cmbGoal;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.ComboBox cmbSchedule;
        private System.Windows.Forms.Button btnFindMatch;
        private System.Windows.Forms.FlowLayoutPanel flowInstructors;
    }
}