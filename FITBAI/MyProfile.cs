using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class MyProfile : Form
    {
        private int _currentClientId = 0;
        private double _currentHeight = 0;

        public MyProfile()
        {
            InitializeComponent();

            // Wire up Gothic UI elements
            cardBiometrics.Paint += Card_Paint;
            cardDirectives.Paint += Card_Paint;
            cardSecurity.Paint += Card_Paint;
            lblMainTitle.Paint += TitleGradient_Paint;

            btnUpdateBio.Paint += PrimaryButton_Paint;
            btnUpdateGoal.Paint += PrimaryButton_Paint;
            btnUpdateSec.Paint += PrimaryButton_Paint;

            this.Load += MyProfile_Load;
            btnUpdateBio.Click += BtnUpdateBio_Click;
            btnUpdateGoal.Click += BtnUpdateGoal_Click;
            btnUpdateSec.Click += BtnUpdateSec_Click;
        }

        private void MyProfile_Load(object? sender, EventArgs e)
        {
            LoadProfileData();
        }

        // ==========================================
        // DATA RETRIEVAL & INTELLIGENCE
        // ==========================================
        private void LoadProfileData()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT clientID, height_cm, weight_kg, bmi, primary_goal FROM users WHERE username = @u";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", AppFlowManager.CurrentUsername);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _currentClientId = Convert.ToInt32(reader["clientID"]);

                                if (reader["height_cm"] != DBNull.Value) _currentHeight = Convert.ToDouble(reader["height_cm"]);
                                double weight = reader["weight_kg"] != DBNull.Value ? Convert.ToDouble(reader["weight_kg"]) : 0;
                                double bmi = reader["bmi"] != DBNull.Value ? Convert.ToDouble(reader["bmi"]) : 0;
                                string goal = reader["primary_goal"]?.ToString() ?? "UNASSIGNED";

                                // 1. Update Biometric UI
                                lblHeightVal.Text = _currentHeight > 0 ? _currentHeight.ToString() : "N/A";
                                txtWeight.Text = weight > 0 ? weight.ToString() : "";

                                string bmiCat = "";
                                if (bmi > 0)
                                {
                                    if (bmi < 18.5) bmiCat = " (Underweight)";
                                    else if (bmi < 25) bmiCat = " (Normal)";
                                    else if (bmi < 30) bmiCat = " (Overweight)";
                                    else bmiCat = " (Obese)";
                                }
                                lblBmiVal.Text = bmi > 0 ? $"{bmi:F1}{bmiCat}" : "N/A";

                                // 2. Update Glowing Directive UI
                                lblCurrentGoal.Text = goal.ToUpper();

                                if (goal.Contains("Loss")) lblCurrentGoal.ForeColor = Color.DeepSkyBlue;
                                else if (goal.Contains("Muscle")) lblCurrentGoal.ForeColor = Color.Crimson;
                                else if (goal.Contains("Stamina") || goal.Contains("Flexibility")) lblCurrentGoal.ForeColor = Color.Orange;
                                else lblCurrentGoal.ForeColor = Color.LimeGreen;

                                // Sync the dropdown box to match current status
                                if (cmbGoal.Items.Contains(goal)) cmbGoal.SelectedItem = goal;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load profile data: " + ex.Message); }
        }

        // ==========================================
        // UPDATE ALGORITHMS
        // ==========================================
        private void BtnUpdateBio_Click(object? sender, EventArgs e)
        {
            if (_currentClientId == 0 || _currentHeight == 0) return;
            if (!double.TryParse(txtWeight.Text, out double newWeight))
            {
                MessageBox.Show("Invalid weight format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // AI BMI Recalculation
            double heightInMeters = _currentHeight / 100.0;
            double newBmi = newWeight / (heightInMeters * heightInMeters);

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE users SET weight_kg = @w, bmi = @b WHERE clientID = @cid";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@w", newWeight);
                        cmd.Parameters.AddWithValue("@b", newBmi);
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Biometrics updated. AI Algorithms have been recalibrated based on your new BMI.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProfileData(); // Instantly refresh UI to show new BMI
            }
            catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); }
        }

        private void BtnUpdateGoal_Click(object? sender, EventArgs e)
        {
            if (_currentClientId == 0 || cmbGoal.SelectedIndex == -1) return;
            string newGoal = cmbGoal.Text;

            DialogResult confirm = MessageBox.Show($"Are you sure you want to change your primary directive to '{newGoal}'?\n\nThis will wipe your current weekly schedule.", "Confirm Override", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // 1. Lock in new goal
                    using (OleDbCommand cmd = new OleDbCommand("UPDATE users SET primary_goal = @g WHERE clientID = @cid", conn))
                    {
                        cmd.Parameters.AddWithValue("@g", newGoal);
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Wipe Tactical Schedule to prevent cross-training errors
                    using (OleDbCommand cmdWipe = new OleDbCommand("DELETE FROM user_schedule WHERE clientID = @cid", conn))
                    {
                        cmdWipe.Parameters.AddWithValue("@cid", _currentClientId);
                        cmdWipe.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Directive updated and active schedule purged.\n\nPlease report to the Schedule module to map out your new deployment.", "Directive Override", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProfileData(); // Instantly refresh UI to show glowing new goal
            }
            catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); }
        }

        private void BtnUpdateSec_Click(object? sender, EventArgs e)
        {
            if (_currentClientId == 0 || string.IsNullOrWhiteSpace(txtOldPass.Text) || string.IsNullOrWhiteSpace(txtNewPass.Text)) return;

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // 1. Verify old password before allowing changes
                    string verifySql = "SELECT COUNT(*) FROM users WHERE clientID = @cid AND [password] = @p";
                    using (OleDbCommand cmd = new OleDbCommand(verifySql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        cmd.Parameters.AddWithValue("@p", txtOldPass.Text);
                        int count = (int)cmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Current password incorrect. Security override denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 2. Inject new password
                    string updateSql = "UPDATE users SET [password] = @np WHERE clientID = @cid";
                    using (OleDbCommand cmd = new OleDbCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@np", txtNewPass.Text);
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Security credentials successfully updated.", "Override Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPass.Clear();
                txtNewPass.Clear();
            }
            catch (Exception ex) { MessageBox.Show("Security System Error: " + ex.Message); }
        }

        // ==========================================
        // UI STYLING ENGINE
        // ==========================================
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

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle, Color.FromArgb(80, 120, 255), Color.FromArgb(180, 80, 255), LinearGradientMode.Horizontal);
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
            }
        }

        private void PrimaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                if (!btn.Enabled) return;
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(80, 120, 255), Color.FromArgb(140, 60, 255), LinearGradientMode.Horizontal))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}