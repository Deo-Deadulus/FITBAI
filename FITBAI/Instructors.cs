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
    public partial class Instructors : Form
    {
        private int _currentClientId = 0;
        private string _userGoal = "";
        private string _activeUsername = "";

        // Structure to hold instructor data for sorting
        private struct InstructorModel
        {
            public int Id;
            public string Name;
            public string Specialization;
            public string Gender;
            public string SchedulePref;
            public double Rating;
            public double MatchScore;
            public int RelevantPlansBuilt; // THE NEW INTELLIGENCE METRIC
        }

        public Instructors(string username = "")
        {
            InitializeComponent();
            _activeUsername = username;

            // Note: If you aren't passing username from usrMAINpage yet, we fall back to global
            if (string.IsNullOrEmpty(_activeUsername)) _activeUsername = AppFlowManager.CurrentUsername;

            panelSidebar.Paint += Card_Paint;
            lblMainTitle.Paint += TitleGradient_Paint;
            btnFindMatch.Paint += PrimaryButton_Paint;

            this.Load += Instructors_Load;
            btnFindMatch.Click += BtnFindMatch_Click;
        }

        private void Instructors_Load(object? sender, EventArgs e)
        {
            FetchUserData();

            // Set defaults in combo boxes
            cmbGender.SelectedIndex = 0; // Any
            cmbSchedule.SelectedIndex = 0; // Any

            // Automatically run the smart match on load based on their DB profile!
            if (!string.IsNullOrEmpty(_userGoal))
            {
                cmbGoal.Text = _userGoal;
                RunIntelligenceMatch();
            }
        }

        // ==========================================
        // DATABASE RETRIEVAL
        // ==========================================
        private void FetchUserData()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT clientID, weight_kg, height_cm, primary_goal FROM users WHERE username = @user";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", _activeUsername);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _currentClientId = Convert.ToInt32(reader["clientID"]);
                                _userGoal = reader["primary_goal"].ToString() ?? "General Fitness";

                                double w = Convert.ToDouble(reader["weight_kg"]);
                                double h = Convert.ToDouble(reader["height_cm"]);
                                double bmi = BMICalculator.CalcBMI(h, w);

                                lblBmiValue.Text = bmi.ToString();
                                lblBmiCategory.Text = BMICalculator.GetBMICategory(bmi).ToString().ToUpper();
                                lblBmiCategory.ForeColor = Color.MediumTurquoise;
                            }
                        }
                    }
                }
            }
            catch { /* Handled silently for smooth UI */ }
        }

        private int CountInstructorPlansForGoal(int instructorId, string goal, OleDbConnection conn)
        {
            // THE INTELLIGENCE ENGINE: Actually looks at the relational workout_plans table!
            string query = "SELECT COUNT(*) FROM workout_plans WHERE instructorID = @id AND target_goal = @goal";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", instructorId);
                cmd.Parameters.AddWithValue("@goal", goal);
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        // ==========================================
        // THE SMART MATCHING ALGORITHM
        // ==========================================
        private void BtnFindMatch_Click(object sender, EventArgs e)
        {
            RunIntelligenceMatch();
        }

        private void RunIntelligenceMatch()
        {
            flowInstructors.Controls.Clear();
            List<InstructorModel> instructorList = new List<InstructorModel>();

            string targetGoal = cmbGoal.Text;
            string targetGender = cmbGender.Text;
            string targetSchedule = cmbSchedule.Text;

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM instructors";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InstructorModel inst = new InstructorModel
                            {
                                Id = Convert.ToInt32(reader["instructorID"]),
                                Name = reader["full_name"].ToString() ?? "Coach",
                                Specialization = reader["specialization"].ToString() ?? "General Fitness",
                                Gender = reader["gender"].ToString() ?? "Any",
                                SchedulePref = reader["schedule_pref"].ToString() ?? "Any",

                                // SAFE CASTING: Check if rating is NULL before converting
                                Rating = reader["rating"] != DBNull.Value ? Convert.ToDouble(reader["rating"]) : 5.0
                            };

                            double matchScore = 0;

                            // 1. Text-Based Specialization Check (+30 pts)
                            if (inst.Specialization.Contains(targetGoal, StringComparison.OrdinalIgnoreCase))
                                matchScore += 30;

                            // 2. TRUE INTELLIGENCE CHECK: How many plans have they actually built for this goal?
                            // This method already handles its own database connection safely
                            inst.RelevantPlansBuilt = CountInstructorPlansForGoal(inst.Id, targetGoal, conn);
                            matchScore += (inst.RelevantPlansBuilt * 15);

                            // 3. User Preferences (+20 pts each)
                            if (targetGender != "Any" && inst.Gender.Equals(targetGender, StringComparison.OrdinalIgnoreCase)) matchScore += 20;
                            if (targetSchedule != "Any" && inst.SchedulePref.Equals(targetSchedule, StringComparison.OrdinalIgnoreCase)) matchScore += 20;

                            // 4. Rating Bonus
                            matchScore += inst.Rating;

                            inst.MatchScore = matchScore;
                            instructorList.Add(inst);
                        }
                    }
                }

                // Sort by highest match score and render!
                var sortedInstructors = instructorList.OrderByDescending(i => i.MatchScore).ToList();

                if (sortedInstructors.Count == 0)
                {
                    Label lblEmpty = new Label { Text = "No instructors found in the database.", ForeColor = Color.White, AutoSize = true, Font = new Font("Segoe UI", 12) };
                    flowInstructors.Controls.Add(lblEmpty);
                    return;
                }

                bool isTopMatch = true;
                foreach (var inst in sortedInstructors)
                {
                    flowInstructors.Controls.Add(GenerateInstructorCard(inst, isTopMatch));
                    isTopMatch = false; // Only the first one gets the "99% MATCH" glowing UI
                }
            }
            catch (Exception ex) { MessageBox.Show("Intelligence Match Failed: " + ex.Message); }
        }

        // ==========================================
        // DYNAMIC UI GENERATOR
        // ==========================================
        private Panel GenerateInstructorCard(InstructorModel inst, bool isTopMatch)
        {
            Panel card = new Panel
            {
                Size = new Size(1000, 160),
                Margin = new Padding(10, 10, 10, 20),
                BackColor = Color.FromArgb(20, 25, 45)
            };

            // Calculate percentage display (capping at 99%)
            double percentage = Math.Min(99.0, (inst.MatchScore / 100.0) * 100.0);
            if (isTopMatch && percentage < 85) percentage = 88.5; // Artificial boost for the top result visual

            Label lblMatch = new Label
            {
                Text = isTopMatch ? $"⭐ TOP MATCH: {percentage:0}%" : $"{percentage:0}% Match",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = isTopMatch ? Color.Gold : Color.MediumTurquoise,
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblName = new Label
            {
                Text = inst.Name.ToUpper(),
                Font = new Font("Arial Black", 20, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 45),
                AutoSize = true
            };

            Label lblDetails = new Label
            {
                Text = $"SPECIALTIES: {inst.Specialization} | RATING: {inst.Rating}/5.0\n" +
                       $"PROVEN EXPERIENCE: {inst.RelevantPlansBuilt} Active Templates built for '{cmbGoal.Text}'",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.LightGray,
                Location = new Point(20, 90),
                AutoSize = true
            };

            Button btnEnlist = new Button
            {
                Text = "ENLIST COACH",
                Size = new Size(220, 50),
                Location = new Point(750, 55),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnEnlist.FlatAppearance.BorderSize = 0;
            btnEnlist.Paint += PrimaryButton_Paint;
            btnEnlist.Click += (s, e) => EnlistInstructor(inst.Id, inst.Name);

            card.Controls.Add(lblMatch);
            card.Controls.Add(lblName);
            card.Controls.Add(lblDetails);
            card.Controls.Add(btnEnlist);

            // Add the glowing border logic
            card.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(isTopMatch ? Color.Gold : Color.FromArgb(80, 100, 200), isTopMatch ? 3 : 1))
                { e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1); }
            };

            return card;
        }

        private void EnlistInstructor(int instructorId, string instructorName)
        {
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to enlist {instructorName} as your dedicated FIT BAI Coach? They will be able to review your Form Checks and deploy Workouts directly to your dashboard.",
                "Confirm Coach Deployment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (OleDbConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        // Updates the user table to lock in their instructor!
                        string query = "UPDATE users SET assigned_instructor = @instID WHERE clientID = @cID";
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@instID", instructorId);
                            cmd.Parameters.AddWithValue("@cID", _currentClientId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"Success! {instructorName} has been assigned to your profile.", "Enlisted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("Could not process request. Ensure the 'assigned_instructor' column exists in your database. Error: " + ex.Message); }
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
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
            }
        }

        private void PrimaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(80, 120, 255), Color.FromArgb(140, 60, 255), LinearGradientMode.Vertical))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}