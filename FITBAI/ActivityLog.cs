using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class ActivityLog : Form
    {
        private int _waterCount = 0;
        private int _currentClientId = 0;

        // Data Structure for the Chart
        private struct ActivityRecord
        {
            public DateTime Date;
            public double Weight;
            public int Hydration;
        }
        private List<ActivityRecord> _historyData = new List<ActivityRecord>();

        public ActivityLog()
        {
            InitializeComponent();

            // Wire up graphics and events
            cardInput.Paint += Card_Paint;
            cardHistory.Paint += Card_Paint;
            lblMainTitle.Paint += TitleGradient_Paint;
            btnSaveLog.Paint += PrimaryButton_Paint;

            pnlChart.Paint += PnlChart_Paint;

            btnWaterPlus.Click += (s, e) => { _waterCount++; UpdateWaterDisplay(); };
            btnWaterMinus.Click += (s, e) => { if (_waterCount > 0) _waterCount--; UpdateWaterDisplay(); };
            btnSaveLog.Click += BtnSaveLog_Click;

            // Wire up the RPE Slider Event
            trkRPE.ValueChanged += TrkRPE_ValueChanged;

            this.Load += ActivityLog_Load;
        }

        private void ActivityLog_Load(object? sender, EventArgs e)
        {
            FetchClientId();
            if (_currentClientId != 0)
            {
                SeedActivityTable();
                LoadTodayData();
                LoadHistoryData();
                CheckTodayStatus();
            }
            lblDateDisplay.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy").ToUpper();
        }

        private void UpdateWaterDisplay() => lblWaterCount.Text = _waterCount.ToString();

        // Dynamically update the Text and Color of the RPE label
        private void TrkRPE_ValueChanged(object? sender, EventArgs e)
        {
            int val = trkRPE.Value;
            if (val == 0) { lblRpeDesc.Text = "0 - Rest Day / No Training"; lblRpeDesc.ForeColor = Color.White; }
            else if (val <= 3) { lblRpeDesc.Text = $"{val} - Easy Recovery"; lblRpeDesc.ForeColor = Color.DeepSkyBlue; }
            else if (val <= 6) { lblRpeDesc.Text = $"{val} - Moderate Base Work"; lblRpeDesc.ForeColor = Color.LimeGreen; }
            else if (val <= 8) { lblRpeDesc.Text = $"{val} - Hard Effort"; lblRpeDesc.ForeColor = Color.Orange; }
            else { lblRpeDesc.Text = $"{val} - Absolute Limit"; lblRpeDesc.ForeColor = Color.Crimson; }
        }

        // ==========================================
        // DATABASE LOGIC
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

        private void SeedActivityTable()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Create table if it doesn't exist at all
                    DataTable tables = conn.GetSchema("Tables");
                    bool exists = false;
                    foreach (DataRow row in tables.Rows)
                        if (row["TABLE_NAME"].ToString() == "activity_logs") exists = true;

                    if (!exists)
                    {
                        string createSql = "CREATE TABLE activity_logs (logID AUTOINCREMENT PRIMARY KEY, clientID INT, log_date DATETIME, weight_kg DOUBLE, water_glasses INT, rpe_score INT)";
                        using (OleDbCommand cmd = new OleDbCommand(createSql, conn)) { cmd.ExecuteNonQuery(); }
                    }
                    else
                    {
                        // 2. If it DOES exist, attempt to patch the schema to include the new rpe_score column
                        try
                        {
                            new OleDbCommand("ALTER TABLE activity_logs ADD COLUMN rpe_score INT", conn).ExecuteNonQuery();
                        }
                        catch { /* Column already exists, safe to ignore */ }
                    }
                }
            }
            catch { }
        }

        private void LoadTodayData()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT weight_kg, water_glasses, rpe_score FROM activity_logs WHERE clientID = @cid AND DateValue(log_date) = DateValue(@today)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        cmd.Parameters.AddWithValue("@today", DateTime.Now.Date.ToString("yyyy-MM-dd"));

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtbxWeight.Text = reader["weight_kg"]?.ToString();
                                _waterCount = Convert.ToInt32(reader["water_glasses"]);

                                // Load the RPE slider if it exists
                                if (reader["rpe_score"] != DBNull.Value)
                                {
                                    trkRPE.Value = Convert.ToInt32(reader["rpe_score"]);
                                    TrkRPE_ValueChanged(null, EventArgs.Empty); // Force the color update
                                }
                                UpdateWaterDisplay();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load today's log: " + ex.Message); }
        }

        private void CheckTodayStatus()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM activity_logs WHERE clientID = @cid AND DateValue(log_date) = DateValue(@today)";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        cmd.Parameters.AddWithValue("@today", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            btnSaveLog.Text = "UPDATE SECURED METRICS";
                            btnSaveLog.BackColor = Color.LimeGreen;
                            lblStatus.Text = "SYSTEM STATUS: LOGGED FOR TODAY";
                            lblStatus.ForeColor = Color.LimeGreen;
                        }
                    }
                }
            }
            catch { }
        }

        private void LoadHistoryData()
        {
            _historyData.Clear();
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT log_date, weight_kg, water_glasses FROM activity_logs WHERE clientID = @cid ORDER BY log_date ASC";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (DateTime.TryParse(reader["log_date"].ToString(), out DateTime d) &&
                                    double.TryParse(reader["weight_kg"].ToString(), out double w) &&
                                    int.TryParse(reader["water_glasses"].ToString(), out int h))
                                {
                                    _historyData.Add(new ActivityRecord { Date = d, Weight = w, Hydration = h });
                                }
                            }
                        }
                    }
                }
                pnlChart.Invalidate();
            }
            catch (Exception ex) { MessageBox.Show("Failed to load history: " + ex.Message); }
        }

        private void BtnSaveLog_Click(object? sender, EventArgs e)
        {
            if (_currentClientId == 0) return;
            double.TryParse(txtbxWeight.Text, out double weight);
            if (weight == 0) { MessageBox.Show("Please enter a valid weight.", "Metrics Required"); return; }

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    bool recordExists = false;
                    using (OleDbCommand checkCmd = new OleDbCommand("SELECT COUNT(*) FROM activity_logs WHERE clientID = @cid AND DateValue(log_date) = DateValue(@today)", conn))
                    {
                        checkCmd.Parameters.AddWithValue("@cid", _currentClientId);
                        checkCmd.Parameters.AddWithValue("@today", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                        recordExists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                    }

                    if (recordExists)
                    {
                        string updateQuery = "UPDATE activity_logs SET weight_kg = @w, water_glasses = @wa, rpe_score = @rpe WHERE clientID = @cid AND DateValue(log_date) = DateValue(@today)";
                        using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@w", weight);
                            cmd.Parameters.AddWithValue("@wa", _waterCount);
                            cmd.Parameters.AddWithValue("@rpe", trkRPE.Value);
                            cmd.Parameters.AddWithValue("@cid", _currentClientId);
                            cmd.Parameters.AddWithValue("@today", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO activity_logs (clientID, log_date, weight_kg, water_glasses, rpe_score) VALUES (@cid, @date, @w, @wa, @rpe)";
                        using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@cid", _currentClientId);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@w", weight);
                            cmd.Parameters.AddWithValue("@wa", _waterCount);
                            cmd.Parameters.AddWithValue("@rpe", trkRPE.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    using (OleDbCommand syncCmd = new OleDbCommand("UPDATE users SET weight_kg = @w WHERE clientID = @cid", conn))
                    {
                        syncCmd.Parameters.AddWithValue("@w", weight);
                        syncCmd.Parameters.AddWithValue("@cid", _currentClientId);
                        syncCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Metrics successfully secured.", "Log Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHistoryData();
                    CheckTodayStatus();
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to save metrics: " + ex.Message); }
        }

        // ==========================================
        // CUSTOM CHARTING ENGINE (GDI+)
        // ==========================================
        private void PnlChart_Paint(object? sender, PaintEventArgs e)
        {
            if (_historyData.Count == 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int padX = 50, padY = 50;
            float graphW = pnlChart.Width - (padX * 2);
            float graphH = pnlChart.Height - (padY * 2);

            double minW = _historyData.Min(x => x.Weight) - 2;
            double maxW = _historyData.Max(x => x.Weight) + 2;
            double diffW = maxW - minW;
            if (diffW == 0) diffW = 1;

            int maxHydration = _historyData.Max(x => x.Hydration);
            if (maxHydration < 8) maxHydration = 8;

            float spacingX = _historyData.Count > 1 ? graphW / (_historyData.Count - 1) : graphW;

            // 1. Draw Grid Lines
            using (Pen gridPen = new Pen(Color.FromArgb(40, 50, 90), 1))
            {
                gridPen.DashStyle = DashStyle.Dash;
                for (int i = 0; i <= 4; i++)
                {
                    float y = padY + (graphH / 4) * i;
                    g.DrawLine(gridPen, padX, y, padX + graphW, y);

                    double labelWeight = maxW - ((diffW / 4) * i);
                    TextRenderer.DrawText(g, labelWeight.ToString("F1"), new Font("Segoe UI", 10), new Point(10, (int)y - 8), Color.FromArgb(170, 180, 220));
                }
            }

            PointF[] points = new PointF[_historyData.Count];
            for (int i = 0; i < _historyData.Count; i++)
            {
                float x = padX + (i * spacingX);
                float y = padY + graphH - (float)(((_historyData[i].Weight - minW) / diffW) * graphH);
                points[i] = new PointF(x, y);

                // 2. Draw Hydration Bars
                float barHeight = ((float)_historyData[i].Hydration / maxHydration) * (graphH / 3);
                using (SolidBrush barBrush = new SolidBrush(Color.FromArgb(100, 80, 50, 150)))
                {
                    g.FillRectangle(barBrush, x - 10, padY + graphH - barHeight, 20, barHeight);
                }

                if (_historyData.Count < 15 || i % 2 == 0)
                {
                    TextRenderer.DrawText(g, _historyData[i].Date.ToString("MM/dd"), new Font("Segoe UI", 9), new Point((int)x - 15, pnlChart.Height - 30), Color.FromArgb(170, 180, 220));
                }
            }

            // 3. Draw Glowing Weight Line
            if (points.Length > 1)
            {
                using (Pen glowPen = new Pen(Color.FromArgb(40, 80, 120, 255), 8))
                { g.DrawLines(glowPen, points); }

                using (Pen corePen = new Pen(Color.FromArgb(80, 120, 255), 3))
                { g.DrawLines(corePen, points); }
            }

            // 4. Draw Data Nodes
            foreach (var pt in points)
            {
                using (SolidBrush dotBrush = new SolidBrush(Color.White))
                { g.FillEllipse(dotBrush, pt.X - 5, pt.Y - 5, 10, 10); }
            }
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