namespace FITBAI
{
    partial class Settings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMainTitle = new System.Windows.Forms.Label();
            cardDiagnostics = new System.Windows.Forms.Panel();
            lblDiagTitle = new System.Windows.Forms.Label();
            lblLogCount = new System.Windows.Forms.Label();
            lblGalCount = new System.Windows.Forms.Label();
            lblVaultSize = new System.Windows.Forms.Label();
            btnRefreshDiag = new System.Windows.Forms.Button();
            cardExport = new System.Windows.Forms.Panel();
            lblExpTitle = new System.Windows.Forms.Label();
            lblExpDesc = new System.Windows.Forms.Label();
            btnExportCSV = new System.Windows.Forms.Button();
            cardScorched = new System.Windows.Forms.Panel();
            lblScorchTitle = new System.Windows.Forms.Label();
            lblScorchDesc = new System.Windows.Forms.Label();
            lblPassReq = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            lblReasonReq = new System.Windows.Forms.Label();
            txtReason = new System.Windows.Forms.TextBox();
            btnScorchedEarth = new System.Windows.Forms.Button();
            cardDiagnostics.SuspendLayout();
            cardExport.SuspendLayout();
            cardScorched.SuspendLayout();
            SuspendLayout();

            // lblMainTitle
            lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
            lblMainTitle.Location = new System.Drawing.Point(85, 40);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new System.Drawing.Size(600, 60);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "System Configuration";

            // cardDiagnostics
            cardDiagnostics.Controls.Add(lblDiagTitle);
            cardDiagnostics.Controls.Add(lblLogCount);
            cardDiagnostics.Controls.Add(lblGalCount);
            cardDiagnostics.Controls.Add(lblVaultSize);
            cardDiagnostics.Controls.Add(btnRefreshDiag);
            cardDiagnostics.Location = new System.Drawing.Point(85, 130);
            cardDiagnostics.Name = "cardDiagnostics";
            cardDiagnostics.Size = new System.Drawing.Size(450, 450);
            cardDiagnostics.TabIndex = 1;

            // lblDiagTitle
            lblDiagTitle.AutoSize = true;
            lblDiagTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblDiagTitle.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            lblDiagTitle.Location = new System.Drawing.Point(30, 30);
            lblDiagTitle.Name = "lblDiagTitle";
            lblDiagTitle.Size = new System.Drawing.Size(181, 28);
            lblDiagTitle.TabIndex = 0;
            lblDiagTitle.Text = "DATA FOOTPRINT";

            // lblLogCount
            lblLogCount.AutoSize = true;
            lblLogCount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblLogCount.ForeColor = System.Drawing.Color.White;
            lblLogCount.Location = new System.Drawing.Point(30, 90);
            lblLogCount.Name = "lblLogCount";
            lblLogCount.Size = new System.Drawing.Size(387, 32);
            lblLogCount.TabIndex = 1;
            lblLogCount.Text = "Total Activity Logs: Calculating...";

            // lblGalCount
            lblGalCount.AutoSize = true;
            lblGalCount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblGalCount.ForeColor = System.Drawing.Color.White;
            lblGalCount.Location = new System.Drawing.Point(30, 160);
            lblGalCount.Name = "lblGalCount";
            lblGalCount.Size = new System.Drawing.Size(383, 32);
            lblGalCount.TabIndex = 2;
            lblGalCount.Text = "Vault Media Items: Calculating...";

            // lblVaultSize
            lblVaultSize.AutoSize = true;
            lblVaultSize.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblVaultSize.ForeColor = System.Drawing.Color.White;
            lblVaultSize.Location = new System.Drawing.Point(30, 230);
            lblVaultSize.Name = "lblVaultSize";
            lblVaultSize.Size = new System.Drawing.Size(393, 32);
            lblVaultSize.TabIndex = 3;
            lblVaultSize.Text = "Local Storage Used: Calculating...";

            // btnRefreshDiag
            btnRefreshDiag.FlatAppearance.BorderSize = 0;
            btnRefreshDiag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefreshDiag.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnRefreshDiag.ForeColor = System.Drawing.Color.White;
            btnRefreshDiag.Location = new System.Drawing.Point(30, 340);
            btnRefreshDiag.Name = "btnRefreshDiag";
            btnRefreshDiag.Size = new System.Drawing.Size(390, 60);
            btnRefreshDiag.TabIndex = 4;
            btnRefreshDiag.Text = "REFRESH TELEMETRY";

            // cardExport
            cardExport.Controls.Add(lblExpTitle);
            cardExport.Controls.Add(lblExpDesc);
            cardExport.Controls.Add(btnExportCSV);
            cardExport.Location = new System.Drawing.Point(570, 130);
            cardExport.Name = "cardExport";
            cardExport.Size = new System.Drawing.Size(450, 450);
            cardExport.TabIndex = 2;

            // lblExpTitle
            lblExpTitle.AutoSize = true;
            lblExpTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblExpTitle.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            lblExpTitle.Location = new System.Drawing.Point(30, 30);
            lblExpTitle.Name = "lblExpTitle";
            lblExpTitle.Size = new System.Drawing.Size(185, 28);
            lblExpTitle.TabIndex = 0;
            lblExpTitle.Text = "TACTICAL EXPORT";

            // lblExpDesc
            lblExpDesc.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            lblExpDesc.ForeColor = System.Drawing.Color.White;
            lblExpDesc.Location = new System.Drawing.Point(30, 90);
            lblExpDesc.Name = "lblExpDesc";
            lblExpDesc.Size = new System.Drawing.Size(390, 100);
            lblExpDesc.TabIndex = 1;
            lblExpDesc.Text = "Compile and download your entire historical activity log to a localized Excel (.csv) file for external analysis.";

            // btnExportCSV
            btnExportCSV.FlatAppearance.BorderSize = 0;
            btnExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExportCSV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnExportCSV.ForeColor = System.Drawing.Color.White;
            btnExportCSV.Location = new System.Drawing.Point(30, 340);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new System.Drawing.Size(390, 60);
            btnExportCSV.TabIndex = 2;
            btnExportCSV.Text = "DOWNLOAD PROGRESS REPORT";

            // cardScorched
            cardScorched.Controls.Add(lblScorchTitle);
            cardScorched.Controls.Add(lblScorchDesc);
            cardScorched.Controls.Add(lblPassReq);
            cardScorched.Controls.Add(txtPassword);
            cardScorched.Controls.Add(lblReasonReq);
            cardScorched.Controls.Add(txtReason);
            cardScorched.Controls.Add(btnScorchedEarth);
            cardScorched.Location = new System.Drawing.Point(1055, 130);
            cardScorched.Name = "cardScorched";
            cardScorched.Size = new System.Drawing.Size(450, 450);
            cardScorched.TabIndex = 3;

            // lblScorchTitle
            lblScorchTitle.AutoSize = true;
            lblScorchTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblScorchTitle.ForeColor = System.Drawing.Color.Orange;
            lblScorchTitle.Location = new System.Drawing.Point(30, 20);
            lblScorchTitle.Name = "lblScorchTitle";
            lblScorchTitle.Size = new System.Drawing.Size(251, 28);
            lblScorchTitle.TabIndex = 0;
            lblScorchTitle.Text = "ACCOUNT TERMINATION";

            // lblScorchDesc
            lblScorchDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblScorchDesc.ForeColor = System.Drawing.Color.White;
            lblScorchDesc.Location = new System.Drawing.Point(30, 60);
            lblScorchDesc.Name = "lblScorchDesc";
            lblScorchDesc.Size = new System.Drawing.Size(390, 50);
            lblScorchDesc.TabIndex = 1;
            lblScorchDesc.Text = "Submit a formal request to FITBAI Administration to permanently close your account and purge your data.";

            // lblPassReq
            lblPassReq.AutoSize = true;
            lblPassReq.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            lblPassReq.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            lblPassReq.Location = new System.Drawing.Point(30, 120);
            lblPassReq.Name = "lblPassReq";
            lblPassReq.Size = new System.Drawing.Size(256, 28);
            lblPassReq.TabIndex = 2;
            lblPassReq.Text = "Current Password (Required):";

            // txtPassword
            txtPassword.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPassword.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            txtPassword.ForeColor = System.Drawing.Color.White;
            txtPassword.Location = new System.Drawing.Point(30, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new System.Drawing.Size(390, 39);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;

            // lblReasonReq
            lblReasonReq.AutoSize = true;
            lblReasonReq.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            lblReasonReq.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            lblReasonReq.Location = new System.Drawing.Point(30, 200);
            lblReasonReq.Name = "lblReasonReq";
            lblReasonReq.Size = new System.Drawing.Size(259, 28);
            lblReasonReq.TabIndex = 4;
            lblReasonReq.Text = "Reason for leaving (Optional):";

            // txtReason
            txtReason.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtReason.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            txtReason.ForeColor = System.Drawing.Color.White;
            txtReason.Location = new System.Drawing.Point(30, 230);
            txtReason.Name = "txtReason";
            txtReason.Size = new System.Drawing.Size(390, 39);
            txtReason.TabIndex = 5;

            // btnScorchedEarth
            btnScorchedEarth.BackColor = System.Drawing.Color.FromArgb(180, 80, 40);
            btnScorchedEarth.FlatAppearance.BorderSize = 0;
            btnScorchedEarth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnScorchedEarth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnScorchedEarth.ForeColor = System.Drawing.Color.White;
            btnScorchedEarth.Location = new System.Drawing.Point(30, 340);
            btnScorchedEarth.Name = "btnScorchedEarth";
            btnScorchedEarth.Size = new System.Drawing.Size(390, 60);
            btnScorchedEarth.TabIndex = 6;
            btnScorchedEarth.Text = "SUBMIT TERMINATION REQUEST";
            btnScorchedEarth.UseVisualStyleBackColor = false;

            // Settings
            BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            ClientSize = new System.Drawing.Size(1670, 1023);
            Controls.Add(lblMainTitle);
            Controls.Add(cardDiagnostics);
            Controls.Add(cardExport);
            Controls.Add(cardScorched);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "Settings";
            cardDiagnostics.ResumeLayout(false);
            cardDiagnostics.PerformLayout();
            cardExport.ResumeLayout(false);
            cardExport.PerformLayout();
            cardScorched.ResumeLayout(false);
            cardScorched.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Panel cardDiagnostics;
        private System.Windows.Forms.Label lblDiagTitle;
        private System.Windows.Forms.Label lblLogCount;
        private System.Windows.Forms.Label lblGalCount;
        private System.Windows.Forms.Label lblVaultSize;
        private System.Windows.Forms.Button btnRefreshDiag;
        private System.Windows.Forms.Panel cardExport;
        private System.Windows.Forms.Label lblExpTitle;
        private System.Windows.Forms.Label lblExpDesc;
        private System.Windows.Forms.Button btnExportCSV;

        // Card 3 Variables
        private System.Windows.Forms.Panel cardScorched;
        private System.Windows.Forms.Label lblScorchTitle;
        private System.Windows.Forms.Label lblScorchDesc;
        private System.Windows.Forms.Label lblPassReq;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblReasonReq;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnScorchedEarth;
    }
}