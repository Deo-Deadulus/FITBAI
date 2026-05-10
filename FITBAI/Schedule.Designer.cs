namespace FITBAI
{
    partial class Schedule
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
            this.cardSchedule = new System.Windows.Forms.Panel();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.cmbWeekPicker = new System.Windows.Forms.ComboBox();
            this.btnSaveSchedule = new System.Windows.Forms.Button();

            // Days Labels & TextBoxes
            this.lblMon = new System.Windows.Forms.Label(); this.txtMon = new System.Windows.Forms.TextBox();
            this.lblTue = new System.Windows.Forms.Label(); this.txtTue = new System.Windows.Forms.TextBox();
            this.lblWed = new System.Windows.Forms.Label(); this.txtWed = new System.Windows.Forms.TextBox();
            this.lblThu = new System.Windows.Forms.Label(); this.txtThu = new System.Windows.Forms.TextBox();
            this.lblFri = new System.Windows.Forms.Label(); this.txtFri = new System.Windows.Forms.TextBox();
            this.lblSat = new System.Windows.Forms.Label(); this.txtSat = new System.Windows.Forms.TextBox();
            this.lblSun = new System.Windows.Forms.Label(); this.txtSun = new System.Windows.Forms.TextBox();

            this.cardSchedule.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblMainTitle.Location = new System.Drawing.Point(85, 40);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(600, 60);
            this.lblMainTitle.Text = "Tactical Weekly Schedule";

            // 
            // cardSchedule
            // 
            this.cardSchedule.Controls.Add(this.lblCardTitle);
            this.cardSchedule.Controls.Add(this.lblWeek);
            this.cardSchedule.Controls.Add(this.cmbWeekPicker);
            this.cardSchedule.Controls.Add(this.lblMon); this.cardSchedule.Controls.Add(this.txtMon);
            this.cardSchedule.Controls.Add(this.lblTue); this.cardSchedule.Controls.Add(this.txtTue);
            this.cardSchedule.Controls.Add(this.lblWed); this.cardSchedule.Controls.Add(this.txtWed);
            this.cardSchedule.Controls.Add(this.lblThu); this.cardSchedule.Controls.Add(this.txtThu);
            this.cardSchedule.Controls.Add(this.lblFri); this.cardSchedule.Controls.Add(this.txtFri);
            this.cardSchedule.Controls.Add(this.lblSat); this.cardSchedule.Controls.Add(this.txtSat);
            this.cardSchedule.Controls.Add(this.lblSun); this.cardSchedule.Controls.Add(this.txtSun);
            this.cardSchedule.Controls.Add(this.btnSaveSchedule);
            this.cardSchedule.Location = new System.Drawing.Point(85, 130);
            this.cardSchedule.Name = "cardSchedule";
            this.cardSchedule.Size = new System.Drawing.Size(1100, 850);

            // 
            // lblCardTitle
            // 
            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            this.lblCardTitle.Location = new System.Drawing.Point(40, 30);
            this.lblCardTitle.Text = "DEPLOYMENT MAP";

            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.lblWeek.ForeColor = System.Drawing.Color.FromArgb(170, 180, 220);
            this.lblWeek.Location = new System.Drawing.Point(40, 90);
            this.lblWeek.Text = "Select Progression Phase:";

            // 
            // cmbWeekPicker
            // 
            this.cmbWeekPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeekPicker.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbWeekPicker.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            this.cmbWeekPicker.ForeColor = System.Drawing.Color.White;
            this.cmbWeekPicker.FormattingEnabled = true;
            this.cmbWeekPicker.Items.AddRange(new object[] { "Week 1 (Foundation)", "Week 2 (Progression)", "Week 3 (Overload)", "Week 4 (Peak / Deload)" });
            this.cmbWeekPicker.Location = new System.Drawing.Point(40, 120);
            this.cmbWeekPicker.Size = new System.Drawing.Size(400, 40);

            // 
            // Day Labels and Textboxes Setup Method (Helper to keep code clean)
            // 
            System.Drawing.Font lblFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font txtFont = new System.Drawing.Font("Segoe UI Semilight", 14F);
            System.Drawing.Color darkBox = System.Drawing.Color.FromArgb(15, 20, 40);
            System.Drawing.Color whiteText = System.Drawing.Color.White;
            int startY = 200; int spacing = 70;

            // MONDAY
            this.lblMon.Text = "MONDAY"; this.lblMon.Location = new System.Drawing.Point(40, startY); this.lblMon.Font = lblFont; this.lblMon.ForeColor = whiteText; this.lblMon.AutoSize = true;
            this.txtMon.Location = new System.Drawing.Point(200, startY - 5); this.txtMon.Size = new System.Drawing.Size(850, 40); this.txtMon.Font = txtFont; this.txtMon.BackColor = darkBox; this.txtMon.ForeColor = whiteText; this.txtMon.ReadOnly = true; this.txtMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // TUESDAY
            this.lblTue.Text = "TUESDAY"; this.lblTue.Location = new System.Drawing.Point(40, startY + spacing); this.lblTue.Font = lblFont; this.lblTue.ForeColor = whiteText; this.lblTue.AutoSize = true;
            this.txtTue.Location = new System.Drawing.Point(200, startY + spacing - 5); this.txtTue.Size = new System.Drawing.Size(850, 40); this.txtTue.Font = txtFont; this.txtTue.BackColor = darkBox; this.txtTue.ForeColor = whiteText; this.txtTue.ReadOnly = true; this.txtTue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // WEDNESDAY
            this.lblWed.Text = "WEDNESDAY"; this.lblWed.Location = new System.Drawing.Point(40, startY + spacing * 2); this.lblWed.Font = lblFont; this.lblWed.ForeColor = whiteText; this.lblWed.AutoSize = true;
            this.txtWed.Location = new System.Drawing.Point(200, startY + spacing * 2 - 5); this.txtWed.Size = new System.Drawing.Size(850, 40); this.txtWed.Font = txtFont; this.txtWed.BackColor = darkBox; this.txtWed.ForeColor = whiteText; this.txtWed.ReadOnly = true; this.txtWed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // THURSDAY
            this.lblThu.Text = "THURSDAY"; this.lblThu.Location = new System.Drawing.Point(40, startY + spacing * 3); this.lblThu.Font = lblFont; this.lblThu.ForeColor = whiteText; this.lblThu.AutoSize = true;
            this.txtThu.Location = new System.Drawing.Point(200, startY + spacing * 3 - 5); this.txtThu.Size = new System.Drawing.Size(850, 40); this.txtThu.Font = txtFont; this.txtThu.BackColor = darkBox; this.txtThu.ForeColor = whiteText; this.txtThu.ReadOnly = true; this.txtThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // FRIDAY
            this.lblFri.Text = "FRIDAY"; this.lblFri.Location = new System.Drawing.Point(40, startY + spacing * 4); this.lblFri.Font = lblFont; this.lblFri.ForeColor = whiteText; this.lblFri.AutoSize = true;
            this.txtFri.Location = new System.Drawing.Point(200, startY + spacing * 4 - 5); this.txtFri.Size = new System.Drawing.Size(850, 40); this.txtFri.Font = txtFont; this.txtFri.BackColor = darkBox; this.txtFri.ForeColor = whiteText; this.txtFri.ReadOnly = true; this.txtFri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // SATURDAY
            this.lblSat.Text = "SATURDAY"; this.lblSat.Location = new System.Drawing.Point(40, startY + spacing * 5); this.lblSat.Font = lblFont; this.lblSat.ForeColor = whiteText; this.lblSat.AutoSize = true;
            this.txtSat.Location = new System.Drawing.Point(200, startY + spacing * 5 - 5); this.txtSat.Size = new System.Drawing.Size(850, 40); this.txtSat.Font = txtFont; this.txtSat.BackColor = darkBox; this.txtSat.ForeColor = whiteText; this.txtSat.ReadOnly = true; this.txtSat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // SUNDAY
            this.lblSun.Text = "SUNDAY"; this.lblSun.Location = new System.Drawing.Point(40, startY + spacing * 6); this.lblSun.Font = lblFont; this.lblSun.ForeColor = whiteText; this.lblSun.AutoSize = true;
            this.txtSun.Location = new System.Drawing.Point(200, startY + spacing * 6 - 5); this.txtSun.Size = new System.Drawing.Size(850, 40); this.txtSun.Font = txtFont; this.txtSun.BackColor = darkBox; this.txtSun.ForeColor = whiteText; this.txtSun.ReadOnly = true; this.txtSun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // 
            // btnSaveSchedule
            // 
            this.btnSaveSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSchedule.FlatAppearance.BorderSize = 0;
            this.btnSaveSchedule.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnSaveSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSaveSchedule.Location = new System.Drawing.Point(40, startY + spacing * 7 + 10);
            this.btnSaveSchedule.Name = "btnSaveSchedule";
            this.btnSaveSchedule.Size = new System.Drawing.Size(1010, 70);
            this.btnSaveSchedule.Text = "GENERATE & OVERWRITE SCHEDULE";

            // 
            // Schedule Form
            // 
            this.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            this.ClientSize = new System.Drawing.Size(1670, 1023);
            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.cardSchedule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Schedule";

            this.cardSchedule.ResumeLayout(false);
            this.cardSchedule.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Panel cardSchedule;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.ComboBox cmbWeekPicker;
        private System.Windows.Forms.Button btnSaveSchedule;

        private System.Windows.Forms.Label lblMon; private System.Windows.Forms.TextBox txtMon;
        private System.Windows.Forms.Label lblTue; private System.Windows.Forms.TextBox txtTue;
        private System.Windows.Forms.Label lblWed; private System.Windows.Forms.TextBox txtWed;
        private System.Windows.Forms.Label lblThu; private System.Windows.Forms.TextBox txtThu;
        private System.Windows.Forms.Label lblFri; private System.Windows.Forms.TextBox txtFri;
        private System.Windows.Forms.Label lblSat; private System.Windows.Forms.TextBox txtSat;
        private System.Windows.Forms.Label lblSun; private System.Windows.Forms.TextBox txtSun;
    }
}