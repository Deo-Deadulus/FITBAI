namespace FITBAI
{
    partial class adminInstructorHub
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
            this.dgvActiveStaff = new System.Windows.Forms.DataGridView();
            this.dgvCandidates = new System.Windows.Forms.DataGridView();
            this.lblStaffHeader = new System.Windows.Forms.Label();
            this.lblCandidateHeader = new System.Windows.Forms.Label();
            this.cmbSpecialization = new System.Windows.Forms.ComboBox();
            this.btnPromote = new System.Windows.Forms.Button();
            this.btnRevoke = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidates)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial Black", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(50, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(800, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "INSTRUCTOR COMMAND";

            // 
            // lblStaffHeader
            // 
            this.lblStaffHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStaffHeader.ForeColor = System.Drawing.Color.LightBlue;
            this.lblStaffHeader.Location = new System.Drawing.Point(50, 130);
            this.lblStaffHeader.Name = "lblStaffHeader";
            this.lblStaffHeader.Size = new System.Drawing.Size(400, 25);
            this.lblStaffHeader.TabIndex = 1;
            this.lblStaffHeader.Text = "CERTIFIED INSTRUCTORS";

            // 
            // lblCandidateHeader
            // 
            this.lblCandidateHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCandidateHeader.ForeColor = System.Drawing.Color.LightBlue;
            this.lblCandidateHeader.Location = new System.Drawing.Point(680, 130);
            this.lblCandidateHeader.Name = "lblCandidateHeader";
            this.lblCandidateHeader.Size = new System.Drawing.Size(400, 25);
            this.lblCandidateHeader.TabIndex = 2;
            this.lblCandidateHeader.Text = "POTENTIAL CANDIDATES (CLIENTS)";

            // 
            // dgvActiveStaff
            // 
            this.dgvActiveStaff.AllowUserToAddRows = false;
            this.dgvActiveStaff.AllowUserToDeleteRows = false;
            this.dgvActiveStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActiveStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveStaff.Location = new System.Drawing.Point(50, 160);
            this.dgvActiveStaff.Name = "dgvActiveStaff";
            this.dgvActiveStaff.ReadOnly = true;
            this.dgvActiveStaff.RowHeadersVisible = false;
            this.dgvActiveStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActiveStaff.Size = new System.Drawing.Size(600, 550);
            this.dgvActiveStaff.TabIndex = 3;

            // 
            // dgvCandidates
            // 
            this.dgvCandidates.AllowUserToAddRows = false;
            this.dgvCandidates.AllowUserToDeleteRows = false;
            this.dgvCandidates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCandidates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCandidates.Location = new System.Drawing.Point(680, 160);
            this.dgvCandidates.Name = "dgvCandidates";
            this.dgvCandidates.ReadOnly = true;
            this.dgvCandidates.RowHeadersVisible = false;
            this.dgvCandidates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCandidates.Size = new System.Drawing.Size(600, 550);
            this.dgvCandidates.TabIndex = 4;

            // 
            // cmbSpecialization
            // 
            this.cmbSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialization.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbSpecialization.FormattingEnabled = true;
            this.cmbSpecialization.Items.AddRange(new object[] {
            "Select Specialization...",
            "Weight Loss, Cardio",
            "Build Muscle, Strength",
            "Increase Stamina, HIIT",
            "Flexibility, Mobility",
            "General Fitness"});
            this.cmbSpecialization.Location = new System.Drawing.Point(680, 735);
            this.cmbSpecialization.Name = "cmbSpecialization";
            this.cmbSpecialization.Size = new System.Drawing.Size(300, 33);
            this.cmbSpecialization.TabIndex = 5;
            this.cmbSpecialization.SelectedIndex = 0;

            // 
            // btnPromote
            // 
            this.btnPromote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPromote.FlatAppearance.BorderSize = 0;
            this.btnPromote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromote.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPromote.Location = new System.Drawing.Point(680, 790);
            this.btnPromote.Name = "btnPromote";
            this.btnPromote.Size = new System.Drawing.Size(300, 50);
            this.btnPromote.TabIndex = 6;
            this.btnPromote.Text = "PROMOTE TO STAFF";
            this.btnPromote.UseVisualStyleBackColor = true;
            this.btnPromote.Click += new System.EventHandler(this.btnPromote_Click);

            // 
            // btnRevoke
            // 
            this.btnRevoke.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevoke.FlatAppearance.BorderSize = 0;
            this.btnRevoke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevoke.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRevoke.Location = new System.Drawing.Point(50, 790);
            this.btnRevoke.Name = "btnRevoke";
            this.btnRevoke.Size = new System.Drawing.Size(300, 50);
            this.btnRevoke.TabIndex = 7;
            this.btnRevoke.Text = "REVOKE CREDENTIALS";
            this.btnRevoke.UseVisualStyleBackColor = true;
            this.btnRevoke.Click += new System.EventHandler(this.btnRevoke_Click);

            // 
            // adminInstructorHub
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1321, 879);
            this.Controls.Add(this.btnRevoke);
            this.Controls.Add(this.btnPromote);
            this.Controls.Add(this.cmbSpecialization);
            this.Controls.Add(this.dgvCandidates);
            this.Controls.Add(this.dgvActiveStaff);
            this.Controls.Add(this.lblCandidateHeader);
            this.Controls.Add(this.lblStaffHeader);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "adminInstructorHub";
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandidates)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvActiveStaff;
        private System.Windows.Forms.DataGridView dgvCandidates;
        private System.Windows.Forms.Label lblStaffHeader;
        private System.Windows.Forms.Label lblCandidateHeader;
        private System.Windows.Forms.ComboBox cmbSpecialization;
        private System.Windows.Forms.Button btnPromote;
        private System.Windows.Forms.Button btnRevoke;
    }
}