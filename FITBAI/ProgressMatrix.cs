using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FITBAI
{
    public partial class ProgressMatrix : Form
    {
        private int _currentClientId = 0;
        private double _targetWeight = 0;

        public ProgressMatrix()
        {
            InitializeComponent();

            // DoubleBuffer the form to prevent flickering when drawing the background
            this.DoubleBuffered = true;

            // Attach Custom Card Painters
            cardStats.Paint += Card_Paint;
            cardChart.Paint += Card_Paint;

            this.Load += ProgressMatrix_Load;
        }

        // ==========================================
        // SICK DOT-MATRIX BACKGROUND RENDERER
        // ==========================================
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Draw subtle dot pattern on the deep navy background
            using (SolidBrush dotBrush = new SolidBrush(Color.FromArgb(30, 45, 80)))
            {
                int dotSpacing = 30;
                for (int x = 0; x < this.Width; x += dotSpacing)
                {
                    for (int y = 0; y < this.Height; y += dotSpacing)
                    {
                        g.FillEllipse(dotBrush, x, y, 3, 3);
                    }
                }
            }
        }

        private void ProgressMatrix_Load(object? sender, EventArgs e)
        {
            FetchClientIdAndGoal();
            if (_currentClientId != 0)
            {
                StyleGothicChart();
                LoadAnalytics();
            }
        }

        private void FetchClientIdAndGoal()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Silent Schema Patch: Ensure 'target_weight' exists in the users table
                    try
                    {
                        new OleDbCommand("ALTER TABLE users ADD COLUMN target_weight DOUBLE", conn).ExecuteNonQuery();
                    }
                    catch { /* Column exists, safe to ignore */ }

                    // 2. Fetch User ID and Target Goal
                    string query = "SELECT clientID, target_weight FROM users WHERE username = @u";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", AppFlowManager.CurrentUsername);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _currentClientId = Convert.ToInt32(reader["clientID"]);
                                if (reader["target_weight"] != DBNull.Value)
                                    _targetWeight = Convert.ToDouble(reader["target_weight"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Identity Error: " + ex.Message); }
        }

        private void LoadAnalytics()
        {
            try
            {
                // Bulletproof Failsafe
                if (chartProgress.Series.IndexOf("WeightLine") == -1) { StyleGothicChart(); }

                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    double firstWeight = 0;
                    double currentWeight = 0;

                    // 1. Fetch Chart Data & Start/Current Weights
                    string chartQuery = "SELECT log_date, weight_kg FROM activity_logs WHERE clientID = @cid AND weight_kg > 0 ORDER BY log_date ASC";
                    using (OleDbCommand cmd = new OleDbCommand(chartQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@cid", _currentClientId);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            chartProgress.Series["WeightLine"].Points.Clear();
                            bool isFirst = true;

                            while (reader.Read())
                            {
                                if (DateTime.TryParse(reader["log_date"].ToString(), out DateTime date) &&
                                    double.TryParse(reader["weight_kg"].ToString(), out double weight))
                                {
                                    if (isFirst) { firstWeight = weight; isFirst = false; }
                                    currentWeight = weight; // Overwrites until the last (newest) row

                                    int idx = chartProgress.Series["WeightLine"].Points.AddXY(date, weight);
                                    chartProgress.Series["WeightLine"].Points[idx].ToolTip = $"{date:MMM dd}: {weight:F1} kg";
                                }
                            }
                        }
                    }

                    // 2. Populate the 4 Stat Cards
                    lblValStart.Text = firstWeight > 0 ? $"{firstWeight:F1} KG" : "-- KG";
                    lblValCurrent.Text = currentWeight > 0 ? $"{currentWeight:F1} KG" : "-- KG";

                    // Goal logic
                    if (_targetWeight > 0) lblValGoal.Text = $"{_targetWeight:F1} KG";
                    else lblValGoal.Text = "Not Set";

                    // Total Progress / Delta Logic
                    if (firstWeight > 0 && currentWeight > 0)
                    {
                        double delta = currentWeight - firstWeight;
                        string sign = delta > 0 ? "+" : "";
                        lblValDelta.Text = $"{sign}{delta:F1} KG";

                        if (delta < 0) lblValDelta.ForeColor = Color.LimeGreen;
                        else if (delta > 0) lblValDelta.ForeColor = Color.Orange;
                        else lblValDelta.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load analytics: " + ex.Message); }
        }

        // ==========================================
        // ADVANCED LINE CHART STYLING
        // ==========================================
        private void StyleGothicChart()
        {
            chartProgress.BackColor = Color.Transparent;
            chartProgress.ChartAreas.Clear();
            chartProgress.Series.Clear();

            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.Transparent;

            // Minimalist X/Y Grid
            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(170, 180, 220);
            area.AxisX.LabelStyle.Format = "MMM dd";
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            area.AxisX.LineColor = Color.FromArgb(40, 50, 90);
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(25, 30, 60);

            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(170, 180, 220);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            area.AxisY.LineColor = Color.FromArgb(40, 50, 90);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(25, 30, 60);
            area.AxisY.IsStartedFromZero = false;

            chartProgress.ChartAreas.Add(area);

            // The Glowing Weight Line
            Series weightLine = new Series("WeightLine");
            weightLine.ChartType = SeriesChartType.SplineArea; // Gives that smooth bottom-filled look
            weightLine.Color = Color.FromArgb(60, 80, 120, 255); // Translucent Fill
            weightLine.BorderColor = Color.FromArgb(80, 120, 255); // Neon Border
            weightLine.BorderWidth = 4;
            weightLine.MarkerStyle = MarkerStyle.Circle;
            weightLine.MarkerSize = 12;
            weightLine.MarkerColor = Color.White;
            weightLine.MarkerBorderColor = Color.FromArgb(80, 120, 255);
            weightLine.MarkerBorderWidth = 2;

            chartProgress.Series.Add(weightLine);
        }

        // ==========================================
        // CARD UI GRAPHICS
        // ==========================================
        private void Card_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                // Draws the dark transparent cards over the dot-matrix background
                using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(220, 15, 20, 40)))
                { e.Graphics.FillRectangle(bgBrush, panel.ClientRectangle); }

                using (Pen pen = new Pen(Color.FromArgb(60, 80, 150), 1))
                { e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1); }
            }
        }
    }
}