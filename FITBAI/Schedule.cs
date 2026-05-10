using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class Schedule : Form
    {
        private int _currentClientId = 0;
        private double _userBmi = 0;
        private string _userGoal = "";
        private bool _isSystemLoading = false;

        // Protocol ID Mappers
        private Dictionary<int, string> _planIdToName = new Dictionary<int, string>();
        private int _pMuscle = 0, _pLoss = 0, _pStamina = 0, _pFlex = 0, _pGen = 0;

        private int[] _currentWeeklyPlanIds = new int[7];

        public Schedule()
        {
            InitializeComponent();

            cardSchedule.Paint += Card_Paint;
            lblMainTitle.Paint += TitleGradient_Paint;
            btnSaveSchedule.Paint += PrimaryButton_Paint;

            this.Load += Schedule_Load;
            this.cmbWeekPicker.SelectedIndexChanged += CmbWeekPicker_SelectedIndexChanged;
            this.btnSaveSchedule.Click += BtnSaveSchedule_Click;
        }

        private void Schedule_Load(object? sender, EventArgs e)
        {
            _isSystemLoading = true;

            // 1. Ensure the DB is fully stocked before we do anything
            HealDatabasePlans();

            // 2. Fetch data
            FetchUserMetrics();
            FetchGlobalPlans();

            // 3. Unlock and try to load Active deployment
            _isSystemLoading = false;

            if (!LoadActiveDeployment())
            {
                if (cmbWeekPicker.Items.Count > 0) cmbWeekPicker.SelectedIndex = 0;
            }
        }

        // ==========================================
        // DATABASE HEALER & FETCHING
        // ==========================================
        private void HealDatabasePlans()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    void InjectIfMissing(string targetGoal, string planName)
                    {
                        using (OleDbCommand checkCmd = new OleDbCommand("SELECT COUNT(*) FROM workout_plans WHERE target_goal = @g", conn))
                        {
                            checkCmd.Parameters.AddWithValue("@g", targetGoal);
                            if (Convert.ToInt32(checkCmd.ExecuteScalar()) == 0)
                            {
                                using (OleDbCommand insCmd = new OleDbCommand("INSERT INTO workout_plans (plan_name, target_goal) VALUES (@pn, @tg)", conn))
                                {
                                    insCmd.Parameters.AddWithValue("@pn", planName);
                                    insCmd.Parameters.AddWithValue("@tg", targetGoal);
                                    insCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    // Ensure every core archetype exists in the database
                    InjectIfMissing("Build Muscle", "Titan Hypertrophy");
                    InjectIfMissing("Weight Loss", "Alpha Fat Burn");
                    InjectIfMissing("Maintain Weight", "Spartan Recomp");
                    InjectIfMissing("Increase Stamina", "Ultra Endurance Challenge");
                    InjectIfMissing("Flexibility", "Advanced Mobility Challenge");
                }
            }
            catch { /* Ignore if errors */ }
        }

        private void FetchUserMetrics()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand("SELECT clientID, bmi, primary_goal FROM users WHERE username = @u", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", AppFlowManager.CurrentUsername);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _currentClientId = Convert.ToInt32(reader["clientID"]);
                                if (reader["bmi"] != DBNull.Value) _userBmi = Convert.ToDouble(reader["bmi"]);
                                if (reader["primary_goal"] != DBNull.Value) _userGoal = reader["primary_goal"].ToString() ?? "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Identity Error: " + ex.Message); }
        }

        private void FetchGlobalPlans()
        {
            _planIdToName.Clear();
            _planIdToName[0] = "— REST DAY —";
            _pMuscle = _pLoss = _pStamina = _pFlex = _pGen = 0;

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand("SELECT planID, target_goal, plan_name FROM workout_plans", conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["planID"]);
                                string tg = (reader["target_goal"].ToString() ?? "").ToLower();
                                string pn = reader["plan_name"].ToString() ?? "Unknown Protocol";

                                _planIdToName[id] = pn;

                                // FUZZY MAPPING: Map the plan to the correct variable based on keywords
                                if (_pMuscle == 0 && (tg.Contains("muscle") || tg.Contains("gain") || tg.Contains("bulk") || tg.Contains("hypertrophy"))) _pMuscle = id;
                                else if (_pLoss == 0 && (tg.Contains("loss") || tg.Contains("lose") || tg.Contains("fat") || tg.Contains("cut"))) _pLoss = id;
                                else if (_pStamina == 0 && (tg.Contains("stamina") || tg.Contains("endurance"))) _pStamina = id;
                                else if (_pFlex == 0 && (tg.Contains("flex") || tg.Contains("mobil"))) _pFlex = id;
                                else if (_pGen == 0 && (tg.Contains("maintain") || tg.Contains("general") || tg.Contains("fit"))) _pGen = id;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to sync protocols: " + ex.Message); }
        }

        // ==========================================
        // COMMAND CENTER: LOAD ACTIVE STATE
        // ==========================================
        private bool LoadActiveDeployment()
        {
            try
            {
                Dictionary<string, int> lockedSchedule = new Dictionary<string, int>();

                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    using (OleDbCommand cmd = new OleDbCommand("SELECT day_of_week, planID FROM user_schedule WHERE clientID = @cid", conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) lockedSchedule[reader["day_of_week"].ToString()!] = Convert.ToInt32(reader["planID"]);
                        }
                    }

                    if (lockedSchedule.Count == 0) return false;

                    DateTime startOfWeek = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek + (int)DayOfWeek.Monday);
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) startOfWeek = startOfWeek.AddDays(-7);

                    HashSet<string> clearedDays = new HashSet<string>();
                    string logQuery = "SELECT log_date FROM activity_logs WHERE clientID = @cid AND workout_done = True AND log_date >= @start";

                    using (OleDbCommand cmdLog = new OleDbCommand(logQuery, conn))
                    {
                        cmdLog.Parameters.AddWithValue("@cid", _currentClientId);
                        cmdLog.Parameters.AddWithValue("@start", startOfWeek.ToString("yyyy-MM-dd"));
                        using (OleDbDataReader reader = cmdLog.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (DateTime.TryParse(reader["log_date"].ToString(), out DateTime logDate))
                                    clearedDays.Add(logDate.DayOfWeek.ToString());
                            }
                        }
                    }

                    cmbWeekPicker.SelectedIndex = -1;
                    lblCardTitle.Text = "CURRENT ACTIVE DEPLOYMENT";
                    btnSaveSchedule.Text = "SCHEDULE LOCKED";
                    btnSaveSchedule.Enabled = false;

                    TextBox[] boxes = { txtMon, txtTue, txtWed, txtThu, txtFri, txtSat, txtSun };
                    string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

                    for (int i = 0; i < 7; i++)
                    {
                        string day = days[i];
                        if (lockedSchedule.ContainsKey(day))
                        {
                            int pId = lockedSchedule[day];
                            _currentWeeklyPlanIds[i] = pId;
                            string pName = _planIdToName.ContainsKey(pId) ? _planIdToName[pId].ToUpper() : "UNKNOWN";

                            if (clearedDays.Contains(day))
                            {
                                boxes[i].Text = $"{pName}   [ CLEARED ]";
                                boxes[i].ForeColor = Color.LimeGreen;
                            }
                            else
                            {
                                boxes[i].Text = pName;
                                boxes[i].ForeColor = Color.White;
                            }
                        }
                    }
                    return true;
                }
            }
            catch { return false; }
        }

        // ==========================================
        // PREVIEW MODE: THE GENERATOR
        // ==========================================
        private void CmbWeekPicker_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isSystemLoading || _currentClientId == 0 || cmbWeekPicker.SelectedIndex == -1) return;

            lblCardTitle.Text = "SYSTEM GENERATED PREVIEW (UNSAVED)";
            btnSaveSchedule.Enabled = true;
            btnSaveSchedule.Text = "GENERATE & OVERWRITE SCHEDULE";

            int weekLevel = cmbWeekPicker.SelectedIndex + 1;

            _currentWeeklyPlanIds = GenerateAlgorithm(_userGoal, _userBmi, weekLevel);

            TextBox[] boxes = { txtMon, txtTue, txtWed, txtThu, txtFri, txtSat, txtSun };
            for (int i = 0; i < 7; i++)
            {
                int pId = _currentWeeklyPlanIds[i];
                boxes[i].Text = _planIdToName.ContainsKey(pId) ? _planIdToName[pId].ToUpper() : "UNKNOWN";
                boxes[i].ForeColor = Color.FromArgb(80, 120, 255);
            }
        }

        // ==========================================
        // FUZZY LOGIC MATCHING ALGORITHM (Strict 5-Day Split)
        // ==========================================
        private int[] GenerateAlgorithm(string userGoal, double bmi, int weekLevel)
        {
            int rest = 0;

            // Safety Net: If a plan ID wasn't found, fallback to General Fitness or ID 1 to prevent empty schedules
            int muscle = _pMuscle > 0 ? _pMuscle : (_pGen > 0 ? _pGen : 1);
            int loss = _pLoss > 0 ? _pLoss : (_pGen > 0 ? _pGen : 1);
            int stamina = _pStamina > 0 ? _pStamina : (_pGen > 0 ? _pGen : 1);
            int flex = _pFlex > 0 ? _pFlex : (_pGen > 0 ? _pGen : 1);
            int gen = _pGen > 0 ? _pGen : 1;

            string ug = (userGoal ?? "").ToLower();

            // --- GOAL-BASED ROUTING ---

            // Protocol Omega: Gain Muscle / Bulk
            if (ug.Contains("muscle") || ug.Contains("gain") || ug.Contains("bulk"))
            {
                if (weekLevel == 1) return new[] { muscle, gen, muscle, rest, muscle, flex, rest };
                if (weekLevel == 2) return new[] { muscle, stamina, muscle, rest, muscle, flex, rest };
                if (weekLevel == 3) return new[] { muscle, muscle, stamina, rest, muscle, muscle, rest };
                return new[] { muscle, muscle, muscle, rest, muscle, muscle, rest };
            }

            // Protocol Alpha: Fat Loss / Cut
            if (ug.Contains("loss") || ug.Contains("lose") || ug.Contains("cut") || ug.Contains("burn"))
            {
                if (weekLevel == 1) return new[] { loss, gen, loss, rest, loss, flex, rest };
                if (weekLevel == 2) return new[] { loss, stamina, loss, rest, stamina, flex, rest };
                if (weekLevel == 3) return new[] { loss, stamina, loss, rest, loss, stamina, rest };
                return new[] { loss, loss, stamina, rest, loss, stamina, rest };
            }

            // Protocol Beta: Maintain Weight / Recomp
            if (ug.Contains("maintain") || ug.Contains("recomp") || ug.Contains("fit"))
            {
                if (weekLevel == 1) return new[] { gen, stamina, gen, rest, muscle, flex, rest };
                if (weekLevel == 2) return new[] { muscle, stamina, gen, rest, muscle, flex, rest };
                if (weekLevel == 3) return new[] { muscle, stamina, muscle, rest, stamina, flex, rest };
                return new[] { muscle, muscle, stamina, rest, muscle, flex, rest };
            }

            // Protocol Delta: Increase Stamina / Endurance
            if (ug.Contains("stamina") || ug.Contains("endurance"))
            {
                if (weekLevel == 1) return new[] { stamina, gen, stamina, rest, flex, gen, rest };
                if (weekLevel == 2) return new[] { stamina, stamina, gen, rest, stamina, flex, rest };
                if (weekLevel == 3) return new[] { stamina, stamina, stamina, rest, stamina, flex, rest };
                return new[] { stamina, stamina, stamina, rest, stamina, stamina, rest };
            }

            // Protocol Sigma: Flexibility / Mobility
            if (ug.Contains("flex") || ug.Contains("mobil"))
            {
                if (weekLevel == 1) return new[] { flex, gen, flex, rest, flex, gen, rest };
                if (weekLevel == 2) return new[] { flex, flex, stamina, rest, flex, gen, rest };
                if (weekLevel == 3) return new[] { flex, flex, stamina, rest, flex, flex, rest };
                return new[] { flex, stamina, flex, rest, flex, stamina, rest };
            }

            // --- BMI-BASED FALLBACK ---
            if (bmi < 18.5)
            {
                if (weekLevel == 1) return new[] { gen, muscle, gen, rest, muscle, flex, rest };
                if (weekLevel == 2) return new[] { muscle, gen, muscle, rest, muscle, flex, rest };
                if (weekLevel == 3) return new[] { muscle, stamina, muscle, rest, muscle, flex, rest };
                return new[] { muscle, muscle, stamina, rest, muscle, muscle, rest };
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                if (weekLevel == 1) return new[] { gen, stamina, gen, rest, flex, gen, rest };
                if (weekLevel == 2) return new[] { gen, stamina, muscle, rest, stamina, flex, rest };
                if (weekLevel == 3) return new[] { muscle, stamina, muscle, rest, stamina, flex, rest };
                return new[] { muscle, muscle, stamina, rest, muscle, flex, rest };
            }
            else if (bmi >= 25 && bmi < 30)
            {
                if (weekLevel == 1) return new[] { gen, loss, gen, rest, loss, flex, rest };
                if (weekLevel == 2) return new[] { loss, stamina, loss, rest, stamina, flex, rest };
                if (weekLevel == 3) return new[] { loss, stamina, loss, rest, loss, stamina, rest };
                return new[] { loss, loss, stamina, rest, loss, stamina, rest };
            }
            else
            {
                if (weekLevel == 1) return new[] { flex, gen, flex, rest, loss, gen, rest };
                if (weekLevel == 2) return new[] { loss, gen, loss, rest, flex, stamina, rest };
                if (weekLevel == 3) return new[] { loss, stamina, loss, rest, loss, flex, rest };
                return new[] { loss, stamina, loss, rest, stamina, flex, rest };
            }
        }

        // ==========================================
        // DATABASE SAVE LOGIC
        // ==========================================
        private void BtnSaveSchedule_Click(object? sender, EventArgs e)
        {
            if (_currentClientId == 0 || cmbWeekPicker.SelectedIndex == -1) return;

            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand delCmd = new OleDbCommand("DELETE FROM user_schedule WHERE clientID = @cid", conn))
                    {
                        delCmd.Parameters.AddWithValue("@cid", _currentClientId);
                        delCmd.ExecuteNonQuery();
                    }

                    string insertQuery = "INSERT INTO user_schedule (clientID, day_of_week, planID) VALUES (@cid, @day, @pid)";
                    using (OleDbCommand insCmd = new OleDbCommand(insertQuery, conn))
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            insCmd.Parameters.Clear();
                            insCmd.Parameters.AddWithValue("@cid", _currentClientId);
                            insCmd.Parameters.AddWithValue("@day", days[i]);
                            insCmd.Parameters.AddWithValue("@pid", _currentWeeklyPlanIds[i]);
                            insCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Directives locked for {cmbWeekPicker.Text}.\n\nOpen your Workout Protocols module to view your daily deployment.", "System Deployed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadActiveDeployment();
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to save schedule: " + ex.Message); }
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