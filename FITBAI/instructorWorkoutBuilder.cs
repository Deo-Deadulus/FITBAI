using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class instructorWorkoutBuilder : Form
    {
        private int currentInstructorID = -1;
        private DataTable draftTable;
        private DataTable _allExercises; // Master exercise list for search filtering

        public instructorWorkoutBuilder()
        {
            InitializeComponent();
            StyleUI();
            InitializeDraftTable();

            this.Load += InstructorWorkoutBuilder_Load;

            // Wire up the exercise search box
            txtExerciseSearch.TextChanged += TxtExerciseSearch_TextChanged;
            txtExerciseSearch.Enter += (s, e) =>
            {
                if (txtExerciseSearch.Text == "Search exercises...")
                {
                    txtExerciseSearch.Text = "";
                    txtExerciseSearch.ForeColor = Color.White;
                }
            };
            txtExerciseSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtExerciseSearch.Text))
                {
                    txtExerciseSearch.Text = "Search exercises...";
                    txtExerciseSearch.ForeColor = Color.Gray;
                }
            };
        }

        private void InstructorWorkoutBuilder_Load(object? sender, EventArgs e)
        {
            FetchInstructorID();
            LoadExercisesDropdown();
            LoadClients();
            LoadWorkoutPlans();
        }

        // ==========================================
        // 1. SETUP & DATA LOADING
        // ==========================================
        private void InitializeDraftTable()
        {
            draftTable = new DataTable();
            draftTable.Columns.Add("exID", typeof(int));
            draftTable.Columns.Add("EXERCISE NAME", typeof(string));
            draftTable.Columns.Add("SETS", typeof(int));
            draftTable.Columns.Add("REPS", typeof(int));
            dgvDraft.DataSource = draftTable;
            dgvDraft.Columns["exID"].Visible = false;
        }

        private void FetchInstructorID()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT i.instructorID FROM instructors i 
                                     INNER JOIN users u ON i.clientID = u.clientID 
                                     WHERE u.username = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", AppFlowManager.CurrentUsername);
                        object result = cmd.ExecuteScalar();
                        if (result != null) currentInstructorID = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to verify instructor identity: " + ex.Message); }
        }

        private void LoadExercisesDropdown()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT exID, exercise_name FROM exercises ORDER BY exercise_name ASC", conn);
                    _allExercises = new DataTable();
                    adapter.Fill(_allExercises);

                    // Bind full list to dropdown initially
                    BindExerciseDropdown(_allExercises.DefaultView);
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load exercises: " + ex.Message); }
        }

        /// <summary>
        /// Binds a DataView (filtered or full) to the exercise ComboBox.
        /// </summary>
        private void BindExerciseDropdown(DataView view)
        {
            DataTable filtered = view.ToTable();
            cmbExercise.DataSource = filtered;
            cmbExercise.DisplayMember = "exercise_name";
            cmbExercise.ValueMember = "exID";
        }

        // ==========================================
        // EXERCISE SEARCH ALGORITHM
        // ==========================================

        /// <summary>
        /// Filters the exercise ComboBox in real-time as the user types.
        /// Matches any exercise whose name CONTAINS the search string (case-insensitive).
        /// </summary>
        private void TxtExerciseSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_allExercises == null) return;

            string searchText = txtExerciseSearch.Text.Trim();

            // Ignore placeholder text
            if (searchText == "Search exercises..." || string.IsNullOrWhiteSpace(searchText))
            {
                // Reset to full list
                _allExercises.DefaultView.RowFilter = "";
                BindExerciseDropdown(_allExercises.DefaultView);
                UpdateSearchResultLabel(_allExercises.Rows.Count, _allExercises.Rows.Count);
                return;
            }

            // Apply LIKE-style filter on the in-memory DataTable (no extra DB call needed)
            string safeSearch = searchText.Replace("'", "''");
            _allExercises.DefaultView.RowFilter = $"exercise_name LIKE '%{safeSearch}%'";

            BindExerciseDropdown(_allExercises.DefaultView);

            int matchCount = _allExercises.DefaultView.Count;
            int totalCount = _allExercises.Rows.Count;
            UpdateSearchResultLabel(matchCount, totalCount);

            // Auto-select first result for convenience
            if (matchCount > 0 && cmbExercise.Items.Count > 0)
                cmbExercise.SelectedIndex = 0;
        }

        /// <summary>
        /// Updates the small result count label next to the search box.
        /// </summary>
        private void UpdateSearchResultLabel(int matchCount, int totalCount)
        {
            if (matchCount == totalCount)
                lblSearchResults.Text = $"{totalCount} exercises";
            else
                lblSearchResults.Text = $"{matchCount} / {totalCount} matches";
        }

        private void LoadClients()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT clientID, full_name, primary_goal FROM users WHERE [role] = 'Client' AND status = 'Active'", conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvClients.DataSource = dt;
                    dgvClients.Columns["clientID"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load clients: " + ex.Message); }
        }

        private void LoadWorkoutPlans()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT planID, plan_name, difficulty FROM workout_plans ORDER BY planID DESC";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvPlans.DataSource = dt;
                    dgvPlans.Columns["planID"].Visible = false;
                    dgvPlans.Columns["plan_name"].HeaderText = "TEMPLATE NAME";
                    dgvPlans.Columns["difficulty"].HeaderText = "DIFFICULTY";
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to load workout plans: " + ex.Message); }
        }

        // ==========================================
        // 2. TEMPLATE CREATOR LOGIC (TOP HALF)
        // ==========================================
        private void btnAddExercise_Click(object sender, EventArgs e)
        {
            if (cmbExercise.SelectedValue == null) return;

            int exID = Convert.ToInt32(cmbExercise.SelectedValue);
            string exName = cmbExercise.Text;
            int sets = (int)numSets.Value;
            int reps = (int)numReps.Value;

            draftTable.Rows.Add(exID, exName, sets, reps);
        }

        private void btnSavePlan_Click(object sender, EventArgs e)
        {
            string planName = txtPlanName.Text.Trim();
            string difficulty = cmbDifficulty.Text;

            if (string.IsNullOrWhiteSpace(planName) || draftTable.Rows.Count == 0)
            {
                MessageBox.Show("Please provide a Plan Name and add at least one exercise.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    OleDbTransaction trans = conn.BeginTransaction();
                    try
                    {
                        using (OleDbCommand cmd = new OleDbCommand("INSERT INTO workout_plans (plan_name, difficulty) VALUES (?, ?)", conn, trans))
                        {
                            cmd.Parameters.AddWithValue("?", planName);
                            cmd.Parameters.AddWithValue("?", difficulty);
                            cmd.ExecuteNonQuery();
                        }

                        int newPlanID = 0;
                        using (OleDbCommand cmdID = new OleDbCommand("SELECT @@IDENTITY", conn, trans))
                        {
                            newPlanID = Convert.ToInt32(cmdID.ExecuteScalar());
                        }

                        foreach (DataRow row in draftTable.Rows)
                        {
                            using (OleDbCommand cmdEx = new OleDbCommand("INSERT INTO plan_exercises (planID, exID, sets, reps) VALUES (?, ?, ?, ?)", conn, trans))
                            {
                                cmdEx.Parameters.AddWithValue("?", newPlanID);
                                cmdEx.Parameters.AddWithValue("?", row["exID"]);
                                cmdEx.Parameters.AddWithValue("?", row["SETS"]);
                                cmdEx.Parameters.AddWithValue("?", row["REPS"]);
                                cmdEx.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        MessageBox.Show($"Template '{planName}' saved to the Library!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtPlanName.Clear();
                        draftTable.Rows.Clear();
                        LoadWorkoutPlans();
                    }
                    catch { trans.Rollback(); throw; }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to save template: " + ex.Message); }
        }

        // ==========================================
        // 3. DEPLOYMENT LOGIC (BOTTOM HALF)
        // ==========================================
        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null || dgvPlans.CurrentRow == null)
            {
                MessageBox.Show("Please select ONE Client and ONE Plan from the grids to transmit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int targetClientID = Convert.ToInt32(dgvClients.CurrentRow.Cells["clientID"].Value);
            string clientName = dgvClients.CurrentRow.Cells["full_name"].Value.ToString() ?? "Client";

            int targetPlanID = Convert.ToInt32(dgvPlans.CurrentRow.Cells["planID"].Value);
            string planName = dgvPlans.CurrentRow.Cells["plan_name"].Value.ToString() ?? "Plan";

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO assigned_workouts (clientID, planID, assigned_date, status) VALUES (?, ?, ?, 'Pending')";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", targetClientID);
                        cmd.Parameters.AddWithValue("?", targetPlanID);
                        cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Protocol '{planName}' successfully transmitted to {clientName}!", "Deployment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Deployment Error: " + ex.Message); }
        }

        // ==========================================
        // UI STYLING ENGINE
        // ==========================================
        private void StyleUI()
        {
            DataGridView[] grids = { dgvClients, dgvPlans, dgvDraft };
            foreach (var g in grids)
            {
                g.BackgroundColor = Color.FromArgb(20, 25, 35);
                g.GridColor = Color.FromArgb(40, 50, 70);
                g.EnableHeadersVisualStyles = false;
                g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136);
                g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                g.DefaultCellStyle.BackColor = Color.FromArgb(15, 20, 30);
                g.DefaultCellStyle.ForeColor = Color.White;
                g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 188, 212);
                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                g.RowHeadersVisible = false;
                g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                g.ReadOnly = true;
                g.AllowUserToAddRows = false;
            }

            // Style search textbox
            txtExerciseSearch.BackColor = Color.FromArgb(20, 25, 45);
            txtExerciseSearch.ForeColor = Color.Gray;
            txtExerciseSearch.BorderStyle = BorderStyle.FixedSingle;
            txtExerciseSearch.Font = new Font("Segoe UI", 11F);

            lblSearchResults.ForeColor = Color.FromArgb(0, 188, 212);
            lblSearchResults.Font = new Font("Segoe UI", 9F, FontStyle.Italic);

            lblTitle.Paint += TitleGradient_Paint;
            btnAddExercise.Paint += PrimaryButton_Paint;
            btnSavePlan.Paint += PrimaryButton_Paint;
            btnAssign.Paint += PrimaryButton_Paint;
        }

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle, Color.FromArgb(0, 255, 200), Color.FromArgb(0, 150, 255), LinearGradientMode.Horizontal);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
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