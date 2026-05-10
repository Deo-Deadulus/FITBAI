namespace FITBAI
{
    partial class WorkoutPlan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMainTitle = new Label();
            pnlListContainer = new Panel();
            lblListTitle = new Label();
            lstPlans = new ListBox();
            pnlDetails = new Panel();
            lblPlanName = new Label();
            lblPlanDesc = new Label();
            dgvExercises = new DataGridView();
            btnActivate = new Button();
            pnlListContainer.SuspendLayout();
            pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExercises).BeginInit();
            SuspendLayout();
            // 
            // lblMainTitle
            // 
            lblMainTitle.Font = new Font("Old English Text MT", 32F);
            lblMainTitle.ForeColor = Color.Transparent;
            lblMainTitle.Location = new Point(85, 30);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(600, 65);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "Workout Protocols";
            // 
            // pnlListContainer
            // 
            pnlListContainer.Controls.Add(lblListTitle);
            pnlListContainer.Controls.Add(lstPlans);
            pnlListContainer.Location = new Point(85, 120);
            pnlListContainer.Name = "pnlListContainer";
            pnlListContainer.Size = new Size(400, 800);
            pnlListContainer.TabIndex = 1;
            // 
            // lblListTitle
            // 
            lblListTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(170, 180, 220);
            lblListTitle.Location = new Point(20, 20);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(142, 23);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "AVAILABLE PLANS";
            // 
            // lstPlans
            // 
            lstPlans.BackColor = Color.FromArgb(15, 20, 50);
            lstPlans.BorderStyle = BorderStyle.None;
            lstPlans.Font = new Font("Segoe UI", 14F);
            lstPlans.ForeColor = Color.White;
            lstPlans.Location = new Point(20, 70);
            lstPlans.Name = "lstPlans";
            lstPlans.Size = new Size(360, 682);
            lstPlans.TabIndex = 1;
            lstPlans.SelectedIndexChanged += lstPlans_SelectedIndexChanged;
            // 
            // pnlDetails
            // 
            pnlDetails.Controls.Add(lblPlanName);
            pnlDetails.Controls.Add(lblPlanDesc);
            pnlDetails.Controls.Add(dgvExercises);
            pnlDetails.Controls.Add(btnActivate);
            pnlDetails.Location = new Point(520, 120);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(1065, 800);
            pnlDetails.TabIndex = 2;
            // 
            // lblPlanName
            // 
            lblPlanName.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblPlanName.ForeColor = Color.White;
            lblPlanName.Location = new Point(40, 40);
            lblPlanName.Name = "lblPlanName";
            lblPlanName.Size = new Size(800, 60);
            lblPlanName.TabIndex = 0;
            lblPlanName.Text = "Select a Protocol";
            // 
            // lblPlanDesc
            // 
            lblPlanDesc.Font = new Font("Segoe UI Semilight", 12F);
            lblPlanDesc.ForeColor = Color.FromArgb(170, 180, 220);
            lblPlanDesc.Location = new Point(45, 110);
            lblPlanDesc.Name = "lblPlanDesc";
            lblPlanDesc.Size = new Size(800, 30);
            lblPlanDesc.TabIndex = 1;
            lblPlanDesc.Text = "Standard military-grade conditioning for the modern athlete.";
            // 
            // dgvExercises
            // 
            dgvExercises.BackgroundColor = Color.FromArgb(15, 20, 50);
            dgvExercises.BorderStyle = BorderStyle.None;
            dgvExercises.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExercises.Location = new Point(40, 170);
            dgvExercises.Name = "dgvExercises";
            dgvExercises.ReadOnly = true;
            dgvExercises.RowHeadersWidth = 51;
            dgvExercises.Size = new Size(985, 480);
            dgvExercises.TabIndex = 2;
            // 
            // btnActivate
            // 
            btnActivate.FlatAppearance.BorderSize = 0;
            btnActivate.FlatStyle = FlatStyle.Flat;
            btnActivate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnActivate.Location = new Point(40, 690);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(985, 60);
            btnActivate.TabIndex = 3;
            btnActivate.Text = "INITIALIZE PROTOCOL";
            btnActivate.Click += btnActivate_Click;
            // 
            // WorkoutPlan
            // 
            BackColor = Color.FromArgb(15, 20, 40);
            ClientSize = new Size(1670, 1023);
            Controls.Add(lblMainTitle);
            Controls.Add(pnlListContainer);
            Controls.Add(pnlDetails);
            FormBorderStyle = FormBorderStyle.None;
            Name = "WorkoutPlan";
            Load += WorkoutPlan_Load;
            pnlListContainer.ResumeLayout(false);
            pnlDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExercises).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Panel pnlListContainer;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.ListBox lstPlans;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label lblPlanName;
        private System.Windows.Forms.Label lblPlanDesc;
        private System.Windows.Forms.DataGridView dgvExercises;
        private System.Windows.Forms.Button btnActivate;
    }
}