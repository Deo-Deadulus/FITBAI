using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            // Attach Custom Graphics Engine
            lblWelcome.Paint += TitleGradient_Paint;

            // Attach styling to all data cards
            cardBMI.Paint += Card_Paint;
            cardStreak.Paint += Card_Paint;
            cardTrend.Paint += Card_Paint;
            cardToday.Paint += Card_Paint;
            cardReminders.Paint += Card_Paint;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Set the personalized texts
            lblWelcome.Text = $"Welcome back, {AppFlowManager.CurrentUsername}!";
            lblRoleTag.Text = AppFlowManager.CurrentRole.ToString().ToUpper() + " DOMAIN";

            // Load data from DB
            LoadDashboardData();
        }

        // --- CUSTOM UI GRAPHICS ---

        // 1. Modern Gradient for the Welcome Title (No Gothic Font!)
        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle,
                    Color.FromArgb(80, 120, 255),  // Bright Blue
                    Color.FromArgb(180, 80, 255),  // Deep Violet
                    LinearGradientMode.Horizontal);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
            }
        }

        // 2. Draws the Dark Hatch Pattern and Glowing Border for the Cards
        private void Card_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                // Subtle hatch pattern for the background of the cards
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal,
                    Color.FromArgb(25, 30, 70),  // Pattern line color
                    Color.FromArgb(15, 20, 50))) // Card base color
                {
                    e.Graphics.FillRectangle(hBrush, panel.ClientRectangle);
                }

                // Glowing crisp border
                using (Pen pen = new Pen(Color.FromArgb(80, 100, 200), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
        }

        // --- DATABASE LOGIC ---
        private int CalculateStreak(int clientId, OleDbConnection conn)
        {
            int streak = 0;
            // Pull all log dates for this client, newest first
            string query = "SELECT log_date FROM activity_logs WHERE clientID = @id ORDER BY log_date DESC";

            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", clientId);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    DateTime expectedDate = DateTime.Today;
                    bool isFirstLog = true;

                    while (reader.Read())
                    {
                        DateTime logDate;
                        // Parse the Short Text date from Access into a real C# Date
                        if (DateTime.TryParse(reader["log_date"].ToString(), out logDate))
                        {
                            if (isFirstLog)
                            {
                                // To have an active streak, the most recent log MUST be today or yesterday.
                                if (logDate.Date == DateTime.Today)
                                {
                                    streak++;
                                    expectedDate = DateTime.Today.AddDays(-1);
                                }
                                else if (logDate.Date == DateTime.Today.AddDays(-1))
                                {
                                    streak++;
                                    expectedDate = DateTime.Today.AddDays(-2);
                                }
                                else
                                {
                                    return 0; // Streak is dead!
                                }
                                isFirstLog = false;
                            }
                            else
                            {
                                // Check if the next log down matches the expected consecutive day
                                if (logDate.Date == expectedDate)
                                {
                                    streak++;
                                    expectedDate = expectedDate.AddDays(-1); // Push the expectation back one more day
                                }
                                else if (logDate.Date < expectedDate)
                                {
                                    break; // We found a gap! The consecutive streak ends here.
                                }
                                // Note: If they logged twice in one day, it just ignores the duplicate and keeps checking
                            }
                        }
                    }
                }
            }
            return streak;
        }
        private void UpdateWeightTrend(int clientId, OleDbConnection conn)
        {
            // Grab only the two most recent weights
            string query = "SELECT TOP 2 weight_kg FROM activity_logs WHERE clientID = @id ORDER BY log_date DESC";

            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", clientId);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    List<double> recentWeights = new List<double>();
                    while (reader.Read())
                    {
                        recentWeights.Add(Convert.ToDouble(reader["weight_kg"]));
                    }

                    // If we have at least 2 logs, we can calculate a trend!
                    if (recentWeights.Count >= 2)
                    {
                        double currentWeight = recentWeights[0];
                        double previousWeight = recentWeights[1];
                        double difference = Math.Round(currentWeight - previousWeight, 1);

                        if (difference < 0)
                        {
                            lblWeightTrend.Text = $"{Math.Abs(difference)} kg DOWN ▼";
                            lblWeightTrend.ForeColor = Color.LimeGreen;
                        }
                        else if (difference > 0)
                        {
                            lblWeightTrend.Text = $"{difference} kg UP ▲";
                            lblWeightTrend.ForeColor = Color.OrangeRed;
                        }
                        else
                        {
                            lblWeightTrend.Text = "STABLE ➖";
                            lblWeightTrend.ForeColor = Color.Gold;
                        }
                    }
                    else if (recentWeights.Count == 1)
                    {
                        lblWeightTrend.Text = "LOGGED ➖";
                        lblWeightTrend.ForeColor = Color.Gold;
                    }
                    else
                    {
                        lblWeightTrend.Text = "NO DATA";
                        lblWeightTrend.ForeColor = Color.Gray;
                    }
                }
            }
        }
        private void LoadDashboardData()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // --- A. FETCH BMI DATA ---
                    string bmiQuery = "SELECT bmi, weight_kg FROM users WHERE username = @user";
                    using (OleDbCommand cmd = new OleDbCommand(bmiQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", AppFlowManager.CurrentUsername);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (double.TryParse(reader["bmi"]?.ToString(), out double actualBmi))
                                {
                                    lblBMIValue.Text = actualBmi.ToString("F1", System.Globalization.CultureInfo.InvariantCulture);
                                    var category = BMICalculator.GetBMICategory(actualBmi);
                                    lblBMICategory.Text = category.ToString().ToUpper();

                                    if (category == BMICalculator.BMICategory.Normal) lblBMICategory.ForeColor = Color.LimeGreen;
                                    else if (category == BMICalculator.BMICategory.Underweight) lblBMICategory.ForeColor = Color.DeepSkyBlue;
                                    else if (category == BMICalculator.BMICategory.Overweight) lblBMICategory.ForeColor = Color.Orange;
                                    else lblBMICategory.ForeColor = Color.Crimson;
                                }
                            }
                        }
                    }

                    // ==============================================================
                    // --- B. TACTICAL SCHEDULE SYNC (DASHBOARD INTELLIGENCE) ---
                    // ==============================================================

                    // 1. Figure out what day it is right now
                    string todayString = DateTime.Now.DayOfWeek.ToString();

                    // Default State: Assume Rest Day
                    lblTodaySession.Text = "REST DAY";
                    lblTodaySession.ForeColor = Color.FromArgb(170, 180, 220); // Muted Purple

                    // 2. Safely get the Client ID
                    int currentId = 0;
                    using (OleDbCommand cmdU = new OleDbCommand("SELECT clientID FROM users WHERE username = @u", conn))
                    {
                        cmdU.Parameters.AddWithValue("@u", AppFlowManager.CurrentUsername);
                        object resU = cmdU.ExecuteScalar();
                        if (resU != null && resU != DBNull.Value) currentId = Convert.ToInt32(resU);
                    }

                    if (currentId != 0)
                    {
                        // 3. Check the schedule table for TODAY
                        int scheduledPlanId = 0;
                        using (OleDbCommand cmdS = new OleDbCommand("SELECT planID FROM user_schedule WHERE clientID = @cid AND day_of_week = @day", conn))
                        {
                            cmdS.Parameters.AddWithValue("@cid", currentId);
                            cmdS.Parameters.AddWithValue("@day", todayString);
                            object resS = cmdS.ExecuteScalar();
                            if (resS != null && resS != DBNull.Value) scheduledPlanId = Convert.ToInt32(resS);
                        }

                        // 4. If a plan is found (planID > 0), fetch the actual name!
                        if (scheduledPlanId > 0)
                        {
                            using (OleDbCommand cmdP = new OleDbCommand("SELECT plan_name FROM workout_plans WHERE planID = @pid", conn))
                            {
                                cmdP.Parameters.AddWithValue("@pid", scheduledPlanId);
                                object resP = cmdP.ExecuteScalar();
                                if (resP != null && resP != DBNull.Value)
                                {
                                    lblTodaySession.Text = resP.ToString().ToUpper();
                                    lblTodaySession.ForeColor = Color.FromArgb(80, 120, 255); // Glowing Blue Active State
                                }
                            }
                        }
                    }

                    if (currentId != 0)
                    {
                        int currentStreak = CalculateStreak(currentId, conn);

                        // Update the UI
                        lblStreakValue.Text = currentStreak.ToString() + " DAYS";

                        // Color Psychology based on dedication
                        if (currentStreak == 0) lblStreakValue.ForeColor = Color.White;
                        else if (currentStreak < 3) lblStreakValue.ForeColor = Color.Orange;
                        else lblStreakValue.ForeColor = Color.LimeGreen; // Glowing green for a strong streak
                    }

                    // Leave Weight Trend as a placeholder for the next update!
                    UpdateWeightTrend(currentId, conn);
                    // Reminders
                    lstReminders.Items.Clear();
                    lstReminders.Items.Add($"📅 Today is {todayString}");
                    lstReminders.Items.Add("💧 Log your hydration in Activity Log");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not sync Dashboard Intelligence: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}