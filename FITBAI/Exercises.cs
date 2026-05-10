using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics; // REQUIRED for opening external browsers!

namespace FITBAI
{
    public partial class ExerciseCodex : Form
    {
        private DataTable? _codexTable;
        private string _currentVideoUrl = ""; // Tracks the active URL

        public ExerciseCodex()
        {
            InitializeComponent();

            // Setup Graphics
            cardSearch.Paint += Card_Paint;
            cardDetails.Paint += Card_Paint;
            lblMainTitle.Paint += TitleGradient_Paint;
            pnlVisualizer.Paint += Visualizer_Paint;
            btnWatchVideo.Paint += PrimaryButton_Paint; // Style the new button!

            // Programmatic Event Wiring
            this.Load += ExerciseCodex_Load;
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.cmbCategory.SelectedIndexChanged += CmbCategory_SelectedIndexChanged;
            this.lstExercises.SelectedIndexChanged += LstExercises_SelectedIndexChanged;
            this.btnWatchVideo.Click += BtnWatchVideo_Click; // Wire the launch button

            // Setup Search Placeholder Text
            txtSearch.Text = "Search directives...";
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == "Search directives...") { txtSearch.Text = ""; txtSearch.ForeColor = Color.White; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "Search directives..."; txtSearch.ForeColor = Color.Gray; } };

            // Default State
            btnWatchVideo.Visible = false;
        }

        private void ExerciseCodex_Load(object? sender, EventArgs e)
        {
            LoadDictionary();
        }

        // ==========================================
        // DATABASE LOGIC
        // ==========================================
        private void LoadDictionary()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT dictID, exercise_name, muscle_group, difficulty, Instructions FROM exercise_dictionary ORDER BY exercise_name ASC";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        _codexTable = new DataTable();
                        adapter.Fill(_codexTable);
                    }
                }

                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All Targets");

                DataView view = new DataView(_codexTable);
                DataTable distinctTargets = view.ToTable(true, "muscle_group");

                foreach (DataRow row in distinctTargets.Rows)
                {
                    string target = row["muscle_group"]?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(target))
                        cmbCategory.Items.Add(target);
                }
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Codex Sync Failed: " + ex.Message); }
        }

        private void ApplyFilters()
        {
            if (_codexTable == null) return;

            string filterQuery = "";

            if (cmbCategory.SelectedIndex > 0)
            {
                string selectedCat = cmbCategory.SelectedItem?.ToString() ?? "";
                filterQuery = $"muscle_group = '{selectedCat.Replace("'", "''")}'";
            }

            string searchText = txtSearch.Text?.Trim() ?? "";
            if (searchText != "Search directives..." && !string.IsNullOrWhiteSpace(searchText))
            {
                if (filterQuery.Length > 0) filterQuery += " AND ";
                filterQuery += $"exercise_name LIKE '%{searchText.Replace("'", "''")}%'";
            }

            _codexTable.DefaultView.RowFilter = filterQuery;
            lstExercises.DataSource = _codexTable.DefaultView;
            lstExercises.DisplayMember = "exercise_name";
            lstExercises.ValueMember = "dictID";
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (txtSearch.ForeColor != Color.Gray) ApplyFilters();
        }

        private void CmbCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplyFilters();
        }

        // ==========================================
        // EXERCISE DETAIL LOADER
        // ==========================================
        private void LstExercises_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstExercises.SelectedItem == null) return;

            DataRowView? selectedRow = lstExercises.SelectedItem as DataRowView;
            if (selectedRow == null) return;

            string selectedExercise = selectedRow["exercise_name"]?.ToString() ?? "";

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            d.exercise_name, 
                            d.muscle_group, 
                            d.difficulty, 
                            d.Instructions, 
                            e.media_file
                        FROM exercise_dictionary AS d
                        LEFT JOIN exercises AS e ON d.exercise_name = e.exercise_name
                        WHERE d.exercise_name = @name";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", selectedExercise);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string exName = reader["exercise_name"]?.ToString()?.ToUpper() ?? "UNKNOWN";
                                string target = reader["muscle_group"]?.ToString()?.ToUpper() ?? "NONE";
                                string diff = reader["difficulty"]?.ToString()?.ToUpper() ?? "---";

                                lblExName.Text = exName;
                                lblExTarget.Text = $"TARGET: {target}  |  DIFFICULTY: {diff}";
                                txtInstructions.Text = reader["Instructions"]?.ToString() ?? "No instructions provided.";

                                string rawMediaField = reader["media_file"]?.ToString() ?? "";
                                UpdateVideoUI(rawMediaField);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Intelligence Retrieval Error: " + ex.Message); }
        }

        // ==========================================
        // THE EXTERNAL BROWSER LAUNCH ENGINE
        // ==========================================
        private void UpdateVideoUI(string rawMediaField)
        {
            // Strip the # wrapper your DB uses: #https://...#
            string cleanUrl = rawMediaField.Trim('#').Trim();

            if (!string.IsNullOrEmpty(cleanUrl) && cleanUrl.StartsWith("http"))
            {
                _currentVideoUrl = cleanUrl; // Lock it into the global variable

                // Update UI to show the launch button
                lblVisualizerText.Text = "EXTERNAL DEMO AVAILABLE";
                lblVisualizerText.Location = new Point(0, 100); // Move text up slightly
                lblVisualizerText.Height = 100;
                btnWatchVideo.Visible = true;
            }
            else
            {
                _currentVideoUrl = ""; // Clear the lock

                // Reset UI to offline state
                btnWatchVideo.Visible = false;
                lblVisualizerText.Location = new Point(0, 0);
                lblVisualizerText.Height = 400; // Full height
                lblVisualizerText.Text = "[ VIDEO DEMO UNAVAILABLE ]";
            }
        }

        private void BtnWatchVideo_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentVideoUrl))
            {
                try
                {
                    // This is the .NET Core command to open the user's default browser (Chrome/Edge)
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = _currentVideoUrl,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not launch external browser. Ensure the link is valid. Error: " + ex.Message);
                }
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

        private void Visualizer_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen gridPen = new Pen(Color.FromArgb(30, 40, 70), 1))
                {
                    int step = 40;
                    for (int x = 0; x < panel.Width; x += step) e.Graphics.DrawLine(gridPen, x, 0, x, panel.Height);
                    for (int y = 0; y < panel.Height; y += step) e.Graphics.DrawLine(gridPen, 0, y, panel.Width, y);
                }
                using (Pen borderPen = new Pen(Color.FromArgb(80, 120, 255), 2))
                { e.Graphics.DrawRectangle(borderPen, 1, 1, panel.Width - 3, panel.Height - 3); }
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
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(0, 150, 136), Color.FromArgb(0, 100, 100), LinearGradientMode.Vertical))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}