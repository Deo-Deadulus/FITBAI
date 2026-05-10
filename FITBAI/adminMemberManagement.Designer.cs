namespace FITBAI
{
    partial class adminMemberManagement
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
            this.dgvMemberList = new System.Windows.Forms.DataGridView();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Arial Black", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 40);
            this.lblTitle.Size = new System.Drawing.Size(700, 60);
            this.lblTitle.Text = "MEMBER DIRECTORY";

            // dgvMemberList
            this.dgvMemberList.AllowUserToAddRows = false;
            this.dgvMemberList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMemberList.Location = new System.Drawing.Point(50, 140);
            this.dgvMemberList.Name = "dgvMemberList";
            this.dgvMemberList.ReadOnly = true;
            this.dgvMemberList.RowHeadersVisible = false;
            this.dgvMemberList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemberList.Size = new System.Drawing.Size(1220, 600);

            // btnUpdateStatus
            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnUpdateStatus.Location = new System.Drawing.Point(50, 770);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(350, 60);
            this.btnUpdateStatus.Text = "TOGGLE ACCOUNT STATUS";
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);

            // adminMemberManagement
            this.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            this.ClientSize = new System.Drawing.Size(1321, 879);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.dgvMemberList);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "adminMemberManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvMemberList;
        private System.Windows.Forms.Button btnUpdateStatus;
    }
}