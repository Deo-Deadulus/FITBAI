using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class adminDashboard : Form
    {
        // ==========================================
        // GLOBAL VARIABLES FOR THE GRAPHICS ENGINE
        // ==========================================
        // Leaderboard Bar Graph Data
        private List<string> topUsernames = new List<string>();
        private List<int> topWorkouts = new List<int>();

        // Goal Distribution Pie Chart Data
        private Dictionary<string, int> goalData = new Dictionary<string, int>();
        private int totalGoals = 0;
        // The color palette for the pie slices
        private Color[] pieColors = { Color.DeepSkyBlue, Color.LimeGreen, Color.Crimson, Color.Gold, Color.BlueViolet, Color.OrangeRed };

        public adminDashboard()
        {
            InitializeComponent();

            // Wire up UI Styling
            lblTitle.Paint += TitleGradient_Paint;
            cardClients.Paint += Card_Paint;
            cardSchedules.Paint += Card_Paint;
            cardWorkouts.Paint += Card_Paint;
            cardAlerts.Paint += AlertCard_Paint;

            // WIRE UP THE CUSTOM GRAPHICS ENGINES
            cardLeaderboard.Paint += LeaderboardGraph_Paint;
            cardGoals.Paint += GoalPieChart_Paint;

            this.Load += AdminDashboard_Load;
        }

        private void AdminDashboard_Load(object? sender, EventArgs e)
        {
            LoadTelemetryData();
        }

        // ==========================================
        // DATABASE TELEMETRY ENGINE
        // ==========================================
        private void LoadTelemetryData()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Count Active Clients (UPGRADED: Ignores soft-deleted 'Terminated' users)
                    string qClients = "SELECT COUNT(*) FROM users WHERE ([role] = 'Client' OR [role] IS NULL) AND status <> 'Terminated'";
                    using (OleDbCommand cmd = new OleDbCommand(qClients, conn))
                    { lblClientCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0"; }

                    // 2. Count Total Active Schedules
                    using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM user_schedule", conn))
                    { lblScheduleCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0"; }

                    // 3. Count Total Workouts Completed
                    using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM activity_logs", conn))
                    { lblWorkoutCount.Text = cmd.ExecuteScalar()?.ToString() ?? "0"; }

                    // 4. Count Pending Termination Requests (UPGRADED: Only counts 'Pending' requests)
                    using (OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM termination_requests WHERE status = 'Pending'", conn))
                    {
                        int purgeCount = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                        lblAlertCount.Text = purgeCount.ToString();

                        if (purgeCount > 0)
                        {
                            lblAlertCount.ForeColor = Color.Crimson;
                            lblAlertText.Text = "PENDING DELETE REQUESTS";
                        }
                        else
                        {
                            lblAlertCount.ForeColor = Color.White;
                            lblAlertText.Text = "DELETE REQUESTS";
                        }
                    }

                    // 5. PIE CHART DATA (UPGRADED: Ignores goals of soft-deleted users)
                    string qGoals = "SELECT primary_goal, COUNT(*) FROM users WHERE primary_goal IS NOT NULL AND status <> 'Terminated' GROUP BY primary_goal";
                    using (OleDbCommand cmd = new OleDbCommand(qGoals, conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            goalData.Clear();
                            totalGoals = 0;

                            while (reader.Read())
                            {
                                string goalName = reader[0].ToString() ?? "Unknown";
                                int count = Convert.ToInt32(reader[1]);
                                goalData[goalName] = count;
                                totalGoals += count;
                            }
                            cardGoals.Invalidate(); // Forces the Pie Chart to redraw
                        }
                    }

                    // 6. BAR GRAPH DATA (Top Athletes)
                    // UPGRADED: Excludes terminated users from taking up leaderboard spots
                    string leaderQuery = @"
                SELECT TOP 3 u.username, COUNT(a.logID) as Workouts 
                FROM activity_logs a 
                INNER JOIN users u ON a.clientID = u.clientID 
                WHERE u.status <> 'Terminated'
                GROUP BY u.username 
                ORDER BY COUNT(a.logID) DESC";

                    topUsernames.Clear();
                    topWorkouts.Clear();

                    using (OleDbCommand cmd = new OleDbCommand(leaderQuery, conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                topUsernames.Add(reader["username"].ToString() ?? "Unknown");
                                topWorkouts.Add(Convert.ToInt32(reader["Workouts"]));
                            }
                        }
                    }
                    cardLeaderboard.Invalidate(); // Forces the Bar Graph to redraw
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Telemetry Link Offline. Error reading database:\n" + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // DYNAMIC PIE CHART ENGINE 
        // ==========================================
        private void GoalPieChart_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(25, 30, 70), Color.FromArgb(15, 20, 50)))
                { e.Graphics.FillRectangle(hBrush, panel.ClientRectangle); }
                using (Pen pen = new Pen(Color.FromArgb(80, 100, 200), 1))
                { e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1); }

                if (totalGoals == 0)
                {
                    TextRenderer.DrawText(e.Graphics, "AWAITING USER DATA", new Font("Segoe UI", 12, FontStyle.Bold), new Point(20, 60), Color.DimGray);
                    return;
                }

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle pieRect = new Rectangle(75, 55, 350, 350);
                float startAngle = 0f;
                int colorIndex = 0;

                int legendX = 20;
                int legendY = 450;

                foreach (var kvp in goalData)
                {
                    float sweepAngle = ((float)kvp.Value / totalGoals) * 360f;
                    Color sliceColor = pieColors[colorIndex % pieColors.Length];

                    using (SolidBrush brush = new SolidBrush(sliceColor))
                    { e.Graphics.FillPie(brush, pieRect, startAngle, sweepAngle); }

                    startAngle += sweepAngle;

                    using (SolidBrush brush = new SolidBrush(sliceColor))
                    { e.Graphics.FillRectangle(brush, legendX, legendY, 15, 15); }

                    double percentage = Math.Round(((double)kvp.Value / totalGoals) * 100, 1);
                    string legendText = $"{kvp.Key.ToUpper()} ({percentage}%)";
                    TextRenderer.DrawText(e.Graphics, legendText, new Font("Arial", 12, FontStyle.Bold), new Point(legendX + 20, legendY), Color.White);

                    legendY += 22;
                    colorIndex++;
                }
            }
        }

        // ==========================================
        // DYNAMIC BAR GRAPH ENGINE
        // ==========================================
        private void LeaderboardGraph_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(25, 30, 70), Color.FromArgb(15, 20, 50)))
                { e.Graphics.FillRectangle(hBrush, panel.ClientRectangle); }
                using (Pen pen = new Pen(Color.FromArgb(80, 100, 200), 1))
                { e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1); }

                if (topWorkouts.Count == 0)
                {
                    TextRenderer.DrawText(e.Graphics, "NO ACTIVITY LOGGED", new Font("Segoe UI", 12, FontStyle.Bold), new Point(20, 60), Color.DimGray);
                    return;
                }

                int maxWorkouts = topWorkouts.Max();
                if (maxWorkouts == 0) maxWorkouts = 1;

                int startY = 45;
                int maxBarWidth = 350;
                int barHeight = 25;
                int spacing = 35;

                for (int i = 0; i < topUsernames.Count; i++)
                {
                    int currentBarWidth = (int)(((double)topWorkouts[i] / maxWorkouts) * maxBarWidth);
                    int currentY = startY + (i * spacing);

                    Rectangle barRect = new Rectangle(20, currentY, currentBarWidth, barHeight);
                    using (SolidBrush barBrush = new SolidBrush(Color.LimeGreen))
                    { e.Graphics.FillRectangle(barBrush, barRect); }

                    string label = $"#{i + 1} {topUsernames[i]} - {topWorkouts[i]} Sessions";
                    TextRenderer.DrawText(e.Graphics, label, new Font("Segoe UI", 10, FontStyle.Bold), new Point(25, currentY + 4), Color.Black);
                    TextRenderer.DrawText(e.Graphics, label, new Font("Segoe UI", 10, FontStyle.Bold), new Point(24, currentY + 3), Color.White);
                }
            }
        }

        // ==========================================
        // STANDARD UI STYLING ENGINE
        // ==========================================
        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle, Color.FromArgb(80, 120, 255), Color.FromArgb(180, 80, 255), LinearGradientMode.Horizontal);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
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

        private void AlertCard_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(70, 20, 30), Color.FromArgb(40, 15, 20)))
                { e.Graphics.FillRectangle(hBrush, panel.ClientRectangle); }
                using (Pen pen = new Pen(Color.Crimson, 1))
                { e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1); }
            }
        }
    }
}