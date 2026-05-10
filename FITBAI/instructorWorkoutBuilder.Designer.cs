namespace FITBAI
{
    partial class instructorWorkoutBuilder
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPart1 = new System.Windows.Forms.Label();
            this.lblPlanName = new System.Windows.Forms.Label();
            this.txtPlanName = new System.Windows.Forms.TextBox();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();

            // NEW: Exercise Search Controls
            this.lblExerciseSearch = new System.Windows.Forms.Label();
            this.txtExerciseSearch = new System.Windows.Forms.TextBox();
            this.lblSearchResults = new System.Windows.Forms.Label();

            this.lblExercise = new System.Windows.Forms.Label();
            this.cmbExercise = new System.Windows.Forms.ComboBox();
            this.lblSets = new System.Windows.Forms.Label();
            this.numSets = new System.Windows.Forms.NumericUpDown();
            this.lblReps = new System.Windows.Forms.Label();
            this.numReps = new System.Windows.Forms.NumericUpDown();
            this.btnAddExercise = new System.Windows.Forms.Button();
            this.dgvDraft = new System.Windows.Forms.DataGridView();
            this.btnSavePlan = new System.Windows.Forms.Button();

            this.lblPart2 = new System.Windows.Forms.Label();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.dgvPlans = new System.Windows.Forms.DataGridView();
            this.btnAssign = new System.Windows.Forms.Button();
            this.lblClientHeader = new System.Windows.Forms.Label();
            this.lblPlanHeader = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.numSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDraft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Arial Black", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(40, 20);
            this.lblTitle.Size = new System.Drawing.Size(1000, 60);
            this.lblTitle.Text = "RELATIONAL WORKOUT ARCHITECT";

            // lblPart1
            this.lblPart1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPart1.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblPart1.Location = new System.Drawing.Point(40, 100);
            this.lblPart1.Text = "PHASE 1: BUILD TEMPLATE LIBRARY";
            this.lblPart1.AutoSize = true;

            // txtPlanName
            this.lblPlanName.ForeColor = System.Drawing.Color.LightGray;
            this.lblPlanName.Location = new System.Drawing.Point(40, 140);
            this.lblPlanName.Text = "Template Name (e.g. Heavy Push)";
            this.lblPlanName.AutoSize = true;

            this.txtPlanName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPlanName.Location = new System.Drawing.Point(40, 165);
            this.txtPlanName.Size = new System.Drawing.Size(300, 29);

            // cmbDifficulty
            this.lblDifficulty.ForeColor = System.Drawing.Color.LightGray;
            this.lblDifficulty.Location = new System.Drawing.Point(360, 140);
            this.lblDifficulty.Text = "Difficulty";
            this.lblDifficulty.AutoSize = true;

            this.cmbDifficulty.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbDifficulty.Items.AddRange(new object[] { "Beginner", "Intermediate", "Advanced" });
            this.cmbDifficulty.Location = new System.Drawing.Point(360, 165);
            this.cmbDifficulty.Size = new System.Drawing.Size(200, 29);
            this.cmbDifficulty.SelectedIndex = 0;
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // ==========================================
            // NEW: EXERCISE SEARCH BOX
            // Sits above the exercise ComboBox — type to filter in real-time
            // ==========================================

            // Label for the search box
            this.lblExerciseSearch.ForeColor = System.Drawing.Color.LightGray;
            this.lblExerciseSearch.Location = new System.Drawing.Point(40, 210);
            this.lblExerciseSearch.Text = "Search Exercise";
            this.lblExerciseSearch.AutoSize = true;

            // The search TextBox (drives the filter)
            this.txtExerciseSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtExerciseSearch.Location = new System.Drawing.Point(40, 233);
            this.txtExerciseSearch.Size = new System.Drawing.Size(220, 27);
            this.txtExerciseSearch.Text = "Search exercises...";

            // Small result count label (e.g. "12 / 40 matches")
            this.lblSearchResults.ForeColor = System.Drawing.Color.FromArgb(0, 188, 212);
            this.lblSearchResults.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSearchResults.Location = new System.Drawing.Point(270, 238);
            this.lblSearchResults.Size = new System.Drawing.Size(120, 20);
            this.lblSearchResults.Text = "";

            // ==========================================
            // Exercise ComboBox — now BELOW the search box
            // ==========================================
            this.lblExercise.ForeColor = System.Drawing.Color.LightGray;
            this.lblExercise.Location = new System.Drawing.Point(40, 273);
            this.lblExercise.Text = "Select Exercise Database Entry";
            this.lblExercise.AutoSize = true;

            this.cmbExercise.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbExercise.Location = new System.Drawing.Point(40, 298);
            this.cmbExercise.Size = new System.Drawing.Size(300, 29);
            this.cmbExercise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Sets & Reps — shifted down to accommodate new search row
            this.lblSets.ForeColor = System.Drawing.Color.LightGray;
            this.lblSets.Location = new System.Drawing.Point(360, 273);
            this.lblSets.Text = "Sets";
            this.lblSets.AutoSize = true;

            this.numSets.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numSets.Location = new System.Drawing.Point(360, 298);
            this.numSets.Size = new System.Drawing.Size(80, 29);
            this.numSets.Value = 3;

            this.lblReps.ForeColor = System.Drawing.Color.LightGray;
            this.lblReps.Location = new System.Drawing.Point(460, 273);
            this.lblReps.Text = "Reps";
            this.lblReps.AutoSize = true;

            this.numReps.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numReps.Location = new System.Drawing.Point(460, 298);
            this.numReps.Size = new System.Drawing.Size(80, 29);
            this.numReps.Value = 10;

            // btnAddExercise — shifted down
            this.btnAddExercise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExercise.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddExercise.Location = new System.Drawing.Point(560, 296);
            this.btnAddExercise.Size = new System.Drawing.Size(160, 32);
            this.btnAddExercise.Text = "+ ADD TO DRAFT";
            this.btnAddExercise.Click += new System.EventHandler(this.btnAddExercise_Click);

            // dgvDraft — adjusted to new layout
            this.dgvDraft.Location = new System.Drawing.Point(750, 140);
            this.dgvDraft.Size = new System.Drawing.Size(530, 240);

            // btnSavePlan — shifted down slightly
            this.btnSavePlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePlan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSavePlan.Location = new System.Drawing.Point(750, 400);
            this.btnSavePlan.Size = new System.Drawing.Size(530, 45);
            this.btnSavePlan.Text = "SAVE TEMPLATE TO LIBRARY";
            this.btnSavePlan.Click += new System.EventHandler(this.btnSavePlan_Click);

            // ==========================================
            // PART 2: ASSIGNMENT
            // ==========================================
            this.lblPart2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPart2.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lblPart2.Location = new System.Drawing.Point(40, 480);
            this.lblPart2.Text = "PHASE 2: DEPLOY PROTOCOL TO CLIENT";
            this.lblPart2.AutoSize = true;

            this.lblClientHeader.ForeColor = System.Drawing.Color.LightGray;
            this.lblClientHeader.Location = new System.Drawing.Point(40, 520);
            this.lblClientHeader.Text = "1. SELECT TARGET CLIENT";
            this.lblClientHeader.AutoSize = true;

            this.dgvClients.Location = new System.Drawing.Point(40, 550);
            this.dgvClients.Size = new System.Drawing.Size(580, 300);

            this.lblPlanHeader.ForeColor = System.Drawing.Color.LightGray;
            this.lblPlanHeader.Location = new System.Drawing.Point(650, 520);
            this.lblPlanHeader.Text = "2. SELECT MASTER TEMPLATE";
            this.lblPlanHeader.AutoSize = true;

            this.dgvPlans.Location = new System.Drawing.Point(650, 550);
            this.dgvPlans.Size = new System.Drawing.Size(630, 300);

            // btnAssign
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnAssign.Location = new System.Drawing.Point(40, 880);
            this.btnAssign.Size = new System.Drawing.Size(1240, 60);
            this.btnAssign.Text = "TRANSMIT WORKOUT PROTOCOL";
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);

            // instructorWorkoutBuilder form
            this.BackColor = System.Drawing.Color.FromArgb(15, 20, 30);
            this.ClientSize = new System.Drawing.Size(1320, 1030);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPart1);
            this.Controls.Add(this.lblPlanName);
            this.Controls.Add(this.txtPlanName);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.cmbDifficulty);
            // NEW search controls added here:
            this.Controls.Add(this.lblExerciseSearch);
            this.Controls.Add(this.txtExerciseSearch);
            this.Controls.Add(this.lblSearchResults);
            // Existing exercise controls:
            this.Controls.Add(this.lblExercise);
            this.Controls.Add(this.cmbExercise);
            this.Controls.Add(this.lblSets);
            this.Controls.Add(this.numSets);
            this.Controls.Add(this.lblReps);
            this.Controls.Add(this.numReps);
            this.Controls.Add(this.btnAddExercise);
            this.Controls.Add(this.dgvDraft);
            this.Controls.Add(this.btnSavePlan);
            this.Controls.Add(this.lblPart2);
            this.Controls.Add(this.lblClientHeader);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.lblPlanHeader);
            this.Controls.Add(this.dgvPlans);
            this.Controls.Add(this.btnAssign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            ((System.ComponentModel.ISupportInitialize)(this.numSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDraft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPart1;
        private System.Windows.Forms.Label lblPlanName;
        private System.Windows.Forms.TextBox txtPlanName;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.ComboBox cmbDifficulty;

        // NEW: Search controls
        private System.Windows.Forms.Label lblExerciseSearch;
        private System.Windows.Forms.TextBox txtExerciseSearch;
        private System.Windows.Forms.Label lblSearchResults;

        private System.Windows.Forms.Label lblExercise;
        private System.Windows.Forms.ComboBox cmbExercise;
        private System.Windows.Forms.Label lblSets;
        private System.Windows.Forms.NumericUpDown numSets;
        private System.Windows.Forms.Label lblReps;
        private System.Windows.Forms.NumericUpDown numReps;
        private System.Windows.Forms.Button btnAddExercise;
        private System.Windows.Forms.DataGridView dgvDraft;
        private System.Windows.Forms.Button btnSavePlan;

        private System.Windows.Forms.Label lblPart2;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.DataGridView dgvPlans;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Label lblClientHeader;
        private System.Windows.Forms.Label lblPlanHeader;
    }
}