using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class WorkoutPlan : Form
    {
        private int _currentClientId = 0;
        private bool _isCompletedToday = false;

        public WorkoutPlan()
        {
            InitializeComponent();

            pnlListContainer.Paint += Card_Paint;
            pnlDetails.Paint += Card_Paint;
            lblMainTitle.Paint += TitleGradient_Paint;
            btnActivate.Paint += PrimaryButton_Paint;

            lblMainTitle.Text = "Active Deployment";
            btnActivate.Text = "COMMENCE PROTOCOL";

            StyleDataGridView();
        }

        private void WorkoutPlan_Load(object sender, EventArgs e)
        {
            HealDatabase();
            FetchClientId();
            if (_currentClientId != 0)
            {
                CheckIfClearedToday();
                LoadLockedSchedule();
            }
        }

        // ==========================================
        // DATABASE LOGIC: INTELLIGENCE CHECKS
        // ==========================================

        private void FetchClientId()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand("SELECT clientID FROM users WHERE username = @u", conn))
                    {
                        cmd.Parameters.AddWithValue("@u", AppFlowManager.CurrentUsername);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value) _currentClientId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Identity Error: " + ex.Message); }
        }

        private void CheckIfClearedToday()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM activity_logs WHERE clientID = @cid AND DateValue(log_date) = DateValue(@today) AND workout_done = True";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        cmd.Parameters.AddWithValue("@today", DateTime.Now.ToString("yyyy-MM-dd"));
                        _isCompletedToday = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch { _isCompletedToday = false; }
        }

        private void LoadLockedSchedule()
        {
            try
            {
                Dictionary<string, (int id, string name)> scheduleData = new Dictionary<string, (int, string)>();

                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT s.day_of_week, s.planID, p.plan_name 
                                     FROM user_schedule s 
                                     LEFT JOIN workout_plans p ON s.planID = p.planID 
                                     WHERE s.clientID = @cid";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string day = reader["day_of_week"].ToString() ?? "";
                                int pId = Convert.ToInt32(reader["planID"]);

                                string pName = "— REST DAY —";
                                if (pId != 0 && reader["plan_name"] != DBNull.Value) pName = reader["plan_name"].ToString()!;

                                scheduleData[day] = (pId, pName);
                            }
                        }
                    }
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("planID", typeof(int));
                dt.Columns.Add("DisplayString", typeof(string));

                string[] orderedDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
                string todayName = DateTime.Now.DayOfWeek.ToString();
                bool hasSchedule = false;

                foreach (string day in orderedDays)
                {
                    if (scheduleData.ContainsKey(day))
                    {
                        hasSchedule = true;
                        string statusTag = "";

                        // Inject the Glowing Tag for Today's specific tab
                        if (day == todayName)
                        {
                            statusTag = _isCompletedToday ? "  [ CLEARED ]" : "  [ ACTIVE ]";
                        }

                        dt.Rows.Add(scheduleData[day].id, $"{day.ToUpper()} : {scheduleData[day].name.ToUpper()}{statusTag}");
                    }
                }

                if (!hasSchedule)
                {
                    lblPlanName.Text = "NO SCHEDULE DETECTED";
                    lblPlanDesc.Text = "Please report to the Tactical Schedule module to generate your weekly directives.";
                    btnActivate.Enabled = false;
                    return;
                }

                lstPlans.DataSource = dt;
                lstPlans.DisplayMember = "DisplayString";
                lstPlans.ValueMember = "planID";

                // Auto-select today's date if possible
                for (int i = 0; i < lstPlans.Items.Count; i++)
                {
                    if (((DataRowView)lstPlans.Items[i])["DisplayString"].ToString()!.Contains(todayName.ToUpper()))
                    {
                        lstPlans.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to sync with Schedule Module: " + ex.Message); }
        }

        private void lstPlans_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPlans.SelectedValue == null) return;
            if (lstPlans.SelectedValue is int planId) LoadExercises(planId);
        }

        private void LoadExercises(int planId)
        {
            try
            {
                string fullText = "";
                if (lstPlans.SelectedItem is DataRowView selectedRow)
                {
                    fullText = selectedRow["DisplayString"].ToString() ?? "";
                    // Clean up the title so it doesn't show the tag in the big header
                    string titleClean = fullText.Contains(":") ? fullText.Split(':')[1].Trim() : fullText;
                    titleClean = titleClean.Replace("[ CLEARED ]", "").Replace("[ ACTIVE ]", "").Trim();
                    lblPlanName.Text = titleClean;
                }

                // ==========================================
                // BUTTON LOCKOUT LOGIC
                // ==========================================
                string dayPart = fullText.Split(':')[0].Trim(); // Extracts "MONDAY", etc.
                string todayName = DateTime.Now.DayOfWeek.ToString().ToUpper();

                if (dayPart != todayName)
                {
                    btnActivate.Enabled = false;
                    btnActivate.Text = "UNAVAILABLE (OUT OF BOUNDS)";
                    btnActivate.BackColor = Color.FromArgb(40, 40, 60);
                }
                else if (planId == 0)
                {
                    btnActivate.Enabled = false;
                    btnActivate.Text = "REST DAY INITIATED";
                    btnActivate.BackColor = Color.FromArgb(40, 40, 60);
                }
                else if (_isCompletedToday)
                {
                    btnActivate.Enabled = false;
                    btnActivate.Text = "PROTOCOL SECURED";
                    btnActivate.BackColor = Color.LimeGreen; // Stays glowing green to show success!
                }
                else
                {
                    btnActivate.Enabled = true;
                    btnActivate.Text = "COMMENCE PROTOCOL";
                    btnActivate.BackColor = Color.FromArgb(80, 120, 255);
                }

                // Load Data Grid
                if (planId == 0)
                {
                    dgvExercises.DataSource = null;
                    lblPlanDesc.Text = "Active Recovery / Rest Protocol. No structural damage assigned for today.";
                    return;
                }

                lblPlanDesc.Text = "Execute the following parameters exactly as specified.";

                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT exercise_name AS [EXERCISE], sets AS [SETS], reps AS [REPS], rest_sec AS [REST (sec)] FROM exercises WHERE planID = @pid";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", planId);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvExercises.DataSource = dt;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Exercise Data Corrupted: " + ex.Message); }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            // Just an alert to send them to the Activity log!
            MessageBox.Show("PROTOCOL ACKNOWLEDGED.\n\nExecute directives and report to the Activity Log to register completion and lock in your streak.", "System Active", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HealDatabase()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // --- 1. HEAL STAMINA PROTOCOL ---
                    string getStamina = "SELECT planID FROM workout_plans WHERE target_goal = 'Increase Stamina'";
                    object resS = new OleDbCommand(getStamina, conn).ExecuteScalar();
                    int staminaId = 0;

                    // FIX: Must check for BOTH null (no rows returned) AND DBNull.Value (row exists but planID is null)
                    if (resS == null || resS == DBNull.Value)
                    {
                        new OleDbCommand("INSERT INTO workout_plans (plan_name, target_goal) VALUES ('Iron Lung HIIT', 'Increase Stamina')", conn).ExecuteNonQuery();
                        // FIX: Use @@IDENTITY instead of MAX(planID) to safely retrieve the newly inserted ID
                        staminaId = Convert.ToInt32(new OleDbCommand("SELECT @@IDENTITY", conn).ExecuteScalar());
                    }
                    else
                    {
                        staminaId = Convert.ToInt32(resS);
                    }

                    // Check if Stamina actually has exercises. If not, add them!
                    int exCountS = Convert.ToInt32(new OleDbCommand($"SELECT COUNT(*) FROM exercises WHERE planID = {staminaId}", conn).ExecuteScalar());
                    if (exCountS == 0)
                    {
                        new OleDbCommand($"INSERT INTO exercises (exercise_name, sets, reps, rest_sec, planID) VALUES ('Burpees', 4, 15, 30, {staminaId})", conn).ExecuteNonQuery();
                        new OleDbCommand($"INSERT INTO exercises (exercise_name, sets, reps, rest_sec, planID) VALUES ('Jump Rope', 3, 60, 30, {staminaId})", conn).ExecuteNonQuery();
                        new OleDbCommand($"INSERT INTO exercises (exercise_name, sets, reps, rest_sec, planID) VALUES ('Mountain Climbers', 4, 20, 20, {staminaId})", conn).ExecuteNonQuery();
                    }

                    // --- 2. HEAL FLEXIBILITY PROTOCOL ---
                    string getFlex = "SELECT planID FROM workout_plans WHERE target_goal = 'Flexibility'";
                    object resF = new OleDbCommand(getFlex, conn).ExecuteScalar();
                    int flexId = 0;

                    // FIX: Must check for BOTH null (no rows returned) AND DBNull.Value (row exists but planID is null)
                    if (resF == null || resF == DBNull.Value)
                    {
                        new OleDbCommand("INSERT INTO workout_plans (plan_name, target_goal) VALUES ('Zenith Mobility', 'Flexibility')", conn).ExecuteNonQuery();
                        // FIX: Use @@IDENTITY instead of MAX(planID) to safely retrieve the newly inserted ID
                        flexId = Convert.ToInt32(new OleDbCommand("SELECT @@IDENTITY", conn).ExecuteScalar());
                    }
                    else
                    {
                        flexId = Convert.ToInt32(resF);
                    }

                    // Check if Flexibility actually has exercises. If not, add them!
                    int exCountF = Convert.ToInt32(new OleDbCommand($"SELECT COUNT(*) FROM exercises WHERE planID = {flexId}", conn).ExecuteScalar());
                    if (exCountF == 0)
                    {
                        new OleDbCommand($"INSERT INTO exercises (exercise_name, sets, reps, rest_sec, planID) VALUES ('Pigeon Pose', 3, 30, 0, {flexId})", conn).ExecuteNonQuery();
                        new OleDbCommand($"INSERT INTO exercises (exercise_name, sets, reps, rest_sec, planID) VALUES ('Hip Flexor Stretch', 3, 45, 0, {flexId})", conn).ExecuteNonQuery();
                        new OleDbCommand($"INSERT INTO exercises (exercise_name, sets, reps, rest_sec, planID) VALUES ('Standing Toe Touch', 3, 30, 0, {flexId})", conn).ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Database Heal Error: " + ex.Message); }
        }

        // ==========================================
        // UI STYLING ENGINE (No changes needed here!)
        // ==========================================
        private void StyleDataGridView()
        {
            dgvExercises.EnableHeadersVisualStyles = false;
            dgvExercises.BorderStyle = BorderStyle.None;
            dgvExercises.BackgroundColor = Color.FromArgb(15, 20, 40);
            dgvExercises.GridColor = Color.FromArgb(40, 50, 90);
            dgvExercises.RowHeadersVisible = false;
            dgvExercises.AllowUserToAddRows = false;
            dgvExercises.ReadOnly = true;
            dgvExercises.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExercises.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvExercises.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 30, 70);
            dgvExercises.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(170, 180, 220);
            dgvExercises.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvExercises.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExercises.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvExercises.ColumnHeadersHeight = 50;

            dgvExercises.DefaultCellStyle.BackColor = Color.FromArgb(20, 25, 50);
            dgvExercises.DefaultCellStyle.ForeColor = Color.White;
            dgvExercises.DefaultCellStyle.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular);
            dgvExercises.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 120, 255);
            dgvExercises.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvExercises.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvExercises.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(15, 20, 40);
            dgvExercises.RowTemplate.Height = 45;
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
                if (!btn.Enabled && btn.BackColor != Color.LimeGreen) return;

                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, btn.BackColor, Color.FromArgb(140, 60, 255), LinearGradientMode.Horizontal))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}