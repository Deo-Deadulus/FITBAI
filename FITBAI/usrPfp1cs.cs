using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FITBAI
{
    public partial class usrPfp1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private string _activeUser;
        private Form? _parentForm;

        public usrPfp1(string passedHeight = "", string passedWeight = "", string username = "", Form? parent = null)
        {
            InitializeComponent();

            _activeUser = username;
            _parentForm = parent;

            cardMetrics.Paint += Card_Paint;
            cardAnalysis.Paint += Card_Paint;
            btnProceed.Paint += PrimaryButton_Paint;

            topheader.MouseDown += Topheader_MouseDown;
            btnUsrPfClose.Click += BtnUsrPfClose_Click;
            btnUsrPfMinMax.Click += BtnUsrPfMinMax_Click;
            btnUsrPfMin.Click += BtnUsrPfMin_Click;

            txtbxHeight.TextChanged += TxtMetrics_TextChanged;
            txtbxWeight.TextChanged += TxtMetrics_TextChanged;
            btnProceed.Click += BtnProceed_Click;

            if (!string.IsNullOrWhiteSpace(passedHeight)) txtbxHeight.Text = passedHeight;
            if (!string.IsNullOrWhiteSpace(passedWeight)) txtbxWeight.Text = passedWeight;
        }

        private void Topheader_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnUsrPfClose_Click(object? sender, EventArgs e) => Application.Exit();
        private void BtnUsrPfMinMax_Click(object? sender, EventArgs e) => this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        private void BtnUsrPfMin_Click(object? sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void TxtMetrics_TextChanged(object? sender, EventArgs e)
        {
            if (double.TryParse(txtbxHeight.Text, out double height) &&
                double.TryParse(txtbxWeight.Text, out double weight))
            {
                ApplyBMIRestrictions(height, weight);
            }
            else
            {
                lblBMIValue.Text = "00.0";
                lblBMICategory.Text = "AWAITING INPUT";
                lblBMICategory.ForeColor = Color.FromArgb(80, 120, 255);
                lblSystemRec.Text = "SYSTEM REC: Please input biometrics to receive clearance.";
                lblSystemRec.ForeColor = Color.FromArgb(170, 180, 220);
            }
        }

        private void ApplyBMIRestrictions(double heightCm, double weightKg)
        {
            double heightM = heightCm / 100.0;
            if (heightM <= 0) return;

            double bmi = weightKg / (heightM * heightM);
            lblBMIValue.Text = bmi.ToString("F1");

            rdoLoseWeight.Enabled = true;
            rdoGainMuscle.Enabled = true;
            rdoMaintain.Enabled = true;
            rdoLoseWeight.ForeColor = Color.White;
            rdoGainMuscle.ForeColor = Color.White;
            rdoMaintain.ForeColor = Color.White;

            if (bmi < 18.5)
            {
                lblBMICategory.Text = "UNDERWEIGHT";
                lblBMICategory.ForeColor = Color.DeepSkyBlue;
                lblSystemRec.Text = "SYSTEM REC: Caloric Surplus & Hypertrophy.";
                lblSystemRec.ForeColor = Color.DeepSkyBlue;
                rdoLoseWeight.Enabled = false;
                rdoLoseWeight.ForeColor = Color.FromArgb(60, 60, 80);
                rdoGainMuscle.Checked = true;
            }
            else if (bmi >= 18.5 && bmi <= 24.9)
            {
                lblBMICategory.Text = "NORMAL WEIGHT";
                lblBMICategory.ForeColor = Color.LimeGreen;
                lblSystemRec.Text = "SYSTEM REC: Maintenance or Lean Muscle Gain.";
                lblSystemRec.ForeColor = Color.LimeGreen;
                rdoMaintain.Checked = true;
            }
            else
            {
                lblBMICategory.Text = bmi >= 30 ? "OBESE" : "OVERWEIGHT";
                lblBMICategory.ForeColor = bmi >= 30 ? Color.Crimson : Color.Orange;
                lblSystemRec.Text = "SYSTEM REC: Caloric Deficit & Fat Loss Protocol.";
                lblSystemRec.ForeColor = bmi >= 30 ? Color.Crimson : Color.Orange;
                rdoGainMuscle.Enabled = false;
                rdoGainMuscle.ForeColor = Color.FromArgb(60, 60, 80);
                rdoLoseWeight.Checked = true;
            }
        }

        private void BtnProceed_Click(object? sender, EventArgs e)
        {
            string selectedGoal = "";
            if (rdoLoseWeight.Checked) selectedGoal = "Weight Loss";
            if (rdoMaintain.Checked) selectedGoal = "Maintain Weight";
            if (rdoGainMuscle.Checked) selectedGoal = "Build Muscle";
            if (rdoIncreaseStamina.Checked) selectedGoal = "Increase Stamina";
            if (rdoFlexibility.Checked) selectedGoal = "Flexibility";

            if (string.IsNullOrEmpty(selectedGoal))
            {
                MessageBox.Show("A Primary Directive must be selected.", "System Halt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtbxTargetWeight.Text, out double targetWeight) || targetWeight <= 0)
            {
                MessageBox.Show("Please enter a valid Target Weight in KG.", "Metrics Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    try
                    {
                        new OleDbCommand("ALTER TABLE users ADD COLUMN target_weight DOUBLE", conn).ExecuteNonQuery();
                    }
                    catch { }

                    string finalSaveQuery = "UPDATE users SET primary_goal = @goal, target_weight = @tw WHERE username = @user";
                    using (OleDbCommand cmd = new OleDbCommand(finalSaveQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@goal", selectedGoal);
                        cmd.Parameters.AddWithValue("@tw", targetWeight);
                        cmd.Parameters.AddWithValue("@user", _activeUser);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Directive Locked: {selectedGoal.ToUpper()}.\nTarget Acquired: {targetWeight} KG.\n\nProfile Calibration Complete.", "System Active", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ==========================================
                // FIXED ROUTING: Passing control to AppFlowManager
                // ==========================================
                AppFlowManager.CurrentUsername = _activeUser;
                AppFlowManager.CurrentUserRole = "Client";
                AppFlowManager.LoadClientDashboard(this);

                _parentForm?.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to secure directive: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Card_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(25, 30, 70), Color.FromArgb(15, 20, 50)))
                { e.Graphics.FillRectangle(hBrush, panel.ClientRectangle); }
                using (Pen pen = new Pen(Color.FromArgb(80, 100, 200), 1))
                { e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1); }
            }
        }

        private void PrimaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(80, 120, 255), Color.FromArgb(140, 60, 255), LinearGradientMode.Horizontal))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}