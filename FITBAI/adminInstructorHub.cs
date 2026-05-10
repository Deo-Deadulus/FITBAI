using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class adminInstructorHub : Form
    {
        public adminInstructorHub()
        {
            InitializeComponent();
            StyleGrids();

            // Wire up UI Styling
            lblTitle.Paint += TitleGradient_Paint;
            btnPromote.Paint += PrimaryButton_Paint;
            btnRevoke.Paint += RedButton_Paint;

            this.Load += AdminInstructorHub_Load;
        }

        private void AdminInstructorHub_Load(object? sender, EventArgs e)
        {
            RefreshHub();
        }

        private void RefreshHub()
        {
            LoadStaffList();
            LoadCandidateList();
        }

        // ==========================================
        // DATABASE OPERATIONS
        // ==========================================
        private void LoadStaffList()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // Added i.clientID to the SELECT statement
                    string query = @"
                SELECT 
                    i.instructorID, 
                    i.clientID,
                    u.full_name, 
                    u.username, 
                    i.specialization 
                FROM instructors i 
                INNER JOIN users u ON i.clientID = u.clientID
                ORDER BY i.instructorID ASC";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvActiveStaff.DataSource = dt;

                    // Make headers look professional
                    dgvActiveStaff.Columns["instructorID"].HeaderText = "STAFF ID";
                    dgvActiveStaff.Columns["full_name"].HeaderText = "FULL NAME";
                    dgvActiveStaff.Columns["username"].HeaderText = "SYSTEM HANDLE";
                    dgvActiveStaff.Columns["specialization"].HeaderText = "SPECIALTY";

                    // HIDE the clientID column from the UI, but keep the data for the Revoke button!
                    dgvActiveStaff.Columns["clientID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Staff Sync Failed: " + ex.Message, "System Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCandidateList()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // Only show 'Clients' who could be promoted
                    string query = "SELECT clientID, username, full_name, email FROM users WHERE [role] = 'Client' OR [role] IS NULL";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCandidates.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Candidate Sync Failed: " + ex.Message); }
        }

        private void btnPromote_Click(object sender, EventArgs e)
        {
            if (dgvCandidates.CurrentRow == null)
            {
                MessageBox.Show("Please select a candidate from the recruitment list.", "Selection Required");
                return;
            }

            int clientID = Convert.ToInt32(dgvCandidates.CurrentRow.Cells["clientID"].Value);
            string spec = cmbSpecialization.Text;

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Fetch the Full Name from the Users table first
                    string nameQuery = "SELECT full_name FROM users WHERE clientID = @id";
                    string fullName = "New Instructor"; // Fallback

                    using (OleDbCommand cmdName = new OleDbCommand(nameQuery, conn))
                    {
                        cmdName.Parameters.AddWithValue("@id", clientID);
                        object result = cmdName.ExecuteScalar();
                        if (result != null) fullName = result.ToString();
                    }

                    // 2. Perform the Promotion with the Name included
                    // Note: Ensure your 'instructors' table has the 'full_name' column!
                    string promoteQuery = @"INSERT INTO instructors (clientID, full_name, specialization, rating) 
                                   VALUES (@cID, @name, @spec, 5.0)";

                    using (OleDbCommand cmdPromote = new OleDbCommand(promoteQuery, conn))
                    {
                        cmdPromote.Parameters.AddWithValue("@cID", clientID);
                        cmdPromote.Parameters.AddWithValue("@name", fullName);
                        cmdPromote.Parameters.AddWithValue("@spec", spec);
                        cmdPromote.ExecuteNonQuery();
                    }

                    // 3. Update the User Role to 'Instructor'
                    string roleQuery = "UPDATE users SET [role] = 'Instructor' WHERE clientID = @id";
                    using (OleDbCommand cmdRole = new OleDbCommand(roleQuery, conn))
                    {
                        cmdRole.Parameters.AddWithValue("@id", clientID);
                        cmdRole.ExecuteNonQuery();
                    }

                    MessageBox.Show($"{fullName} has been officially commissioned as an Instructor!", "Promotion Successful");
                    RefreshHub();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Promotion failed: " + ex.Message);
            }
        }

        private void btnRevoke_Click(object sender, EventArgs e)
        {
            // 1. Ensure someone is actually selected
            if (dgvActiveStaff.CurrentRow == null)
            {
                MessageBox.Show("Select an Active Instructor to revoke credentials.", "System Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Grab their specific IDs
            int instID = Convert.ToInt32(dgvActiveStaff.CurrentRow.Cells["instructorID"].Value);
            int cID = Convert.ToInt32(dgvActiveStaff.CurrentRow.Cells["clientID"].Value);
            string name = dgvActiveStaff.CurrentRow.Cells["full_name"].Value.ToString();

            // 3. Admin Confirmation check (Safety feature)
            DialogResult confirm = MessageBox.Show($"WARNING: You are about to strip Staff Credentials from {name}.\n\nThey will be demoted back to a standard Client. Proceed?",
                "Confirm Revocation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (OleDbConnection conn = DatabaseHelper.GetConnection())
                    {
                        conn.Open();
                        OleDbTransaction trans = conn.BeginTransaction();
                        try
                        {
                            // Action A: Delete their profile from the instructors table
                            using (OleDbCommand cmd = new OleDbCommand("DELETE FROM instructors WHERE instructorID = @instId", conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@instId", instID);
                                cmd.ExecuteNonQuery();
                            }

                            // Action B: Demote their role back to 'Client' in the users table
                            using (OleDbCommand cmd = new OleDbCommand("UPDATE users SET [role] = 'Client' WHERE clientID = @cId", conn, trans))
                            {
                                cmd.Parameters.AddWithValue("@cId", cID);
                                cmd.ExecuteNonQuery();
                            }

                            trans.Commit();
                            MessageBox.Show($"Credentials revoked. {name} has been returned to the candidate pool.", "Revocation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the hub to watch them move from Left to Right instantly!
                            RefreshHub();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Revocation Error: " + ex.Message, "Critical Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // UI STYLING ENGINE
        // ==========================================
        private void StyleGrids()
        {
            DataGridView[] grids = { dgvActiveStaff, dgvCandidates };
            foreach (var g in grids)
            {
                g.BackgroundColor = Color.FromArgb(20, 25, 45);
                g.EnableHeadersVisualStyles = false;
                g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 40, 100);
                g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                g.DefaultCellStyle.BackColor = Color.FromArgb(15, 20, 40);
                g.DefaultCellStyle.ForeColor = Color.White;
                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                g.RowHeadersVisible = false;
                g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle, Color.FromArgb(0, 191, 255), Color.FromArgb(138, 43, 226), LinearGradientMode.Horizontal);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
            }
        }

        private void PrimaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(60, 80, 250), Color.FromArgb(30, 40, 150), LinearGradientMode.Vertical))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void RedButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle, Color.FromArgb(180, 20, 20), Color.FromArgb(80, 5, 5), LinearGradientMode.Vertical))
                { e.Graphics.FillRectangle(brush, btn.ClientRectangle); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}