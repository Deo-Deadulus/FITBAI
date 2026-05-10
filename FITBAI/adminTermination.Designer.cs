namespace FITBAI
{
    partial class adminTerminationQueue
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
            this.dgvPurgeList = new System.Windows.Forms.DataGridView();
            this.btnPurge = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurgeList)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Arial Black", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(50, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(800, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TERMINATION QUEUE";

            // dgvPurgeList
            this.dgvPurgeList.AllowUserToAddRows = false;
            this.dgvPurgeList.AllowUserToDeleteRows = false;
            this.dgvPurgeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurgeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurgeList.Location = new System.Drawing.Point(50, 140);
            this.dgvPurgeList.Name = "dgvPurgeList";
            this.dgvPurgeList.ReadOnly = true;
            this.dgvPurgeList.RowHeadersVisible = false;
            this.dgvPurgeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurgeList.Size = new System.Drawing.Size(1220, 600);
            this.dgvPurgeList.TabIndex = 1;

            // btnPurge
            this.btnPurge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurge.FlatAppearance.BorderSize = 0;
            this.btnPurge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurge.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnPurge.Location = new System.Drawing.Point(50, 770);
            this.btnPurge.Name = "btnPurge";
            this.btnPurge.Size = new System.Drawing.Size(400, 65);
            this.btnPurge.TabIndex = 2;
            this.btnPurge.Text = "EXECUTE PURGE";
            this.btnPurge.UseVisualStyleBackColor = true;
            this.btnPurge.Click += new System.EventHandler(this.btnPurge_Click);

            // adminTerminationQueue
            this.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            this.ClientSize = new System.Drawing.Size(1321, 879);
            this.Controls.Add(this.btnPurge);
            this.Controls.Add(this.dgvPurgeList);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "adminTerminationQueue";
            this.Text = "Termination Queue";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurgeList)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvPurgeList;
        private System.Windows.Forms.Button btnPurge;
    }
}