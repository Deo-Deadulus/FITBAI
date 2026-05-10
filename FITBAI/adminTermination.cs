using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class adminTerminationQueue : Form
    {
        public adminTerminationQueue()
        {
            InitializeComponent();
            StylePurgeGrid();

            lblTitle.Paint += TitleGradient_Paint;
            btnPurge.Paint += RedButton_Paint;

            this.Load += AdminTerminationQueue_Load;
        }

        private void AdminTerminationQueue_Load(object? sender, EventArgs e)
        {
            LoadTerminationRequests();
        }

        private void LoadTerminationRequests()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT tr.requestID, tr.clientID, u.username, tr.request_date, tr.reason 
                                   FROM termination_requests tr 
                                   INNER JOIN users u ON tr.clientID = u.clientID 
                                   WHERE tr.status = 'Pending'
                                   ORDER BY tr.request_date DESC";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvPurgeList.DataSource = dt;

                        // Column renaming: guards are defensive but safe to keep for resilience
                        // against schema changes that might remove a column from the query.
                        if (dgvPurgeList.Columns.Contains("requestID")) dgvPurgeList.Columns["requestID"].HeaderText = "REQ ID";
                        if (dgvPurgeList.Columns.Contains("clientID")) dgvPurgeList.Columns["clientID"].HeaderText = "CLIENT ID";
                        if (dgvPurgeList.Columns.Contains("username")) dgvPurgeList.Columns["username"].HeaderText = "USERNAME";
                        if (dgvPurgeList.Columns.Contains("request_date")) dgvPurgeList.Columns["request_date"].HeaderText = "TIMESTAMP";
                        if (dgvPurgeList.Columns.Contains("reason")) dgvPurgeList.Columns["reason"].HeaderText = "REASON FOR TERMINATION";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Telemetry Link Offline. Error reading termination queue:\n" + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPurge_Click(object? sender, EventArgs e)
        {
            if (dgvPurgeList.CurrentRow == null) return;

            // Safely check if the cell and its value actually exist before converting
            var rawClientId = dgvPurgeList.CurrentRow.Cells["clientID"]?.Value;
            if (rawClientId == null || rawClientId == DBNull.Value) return;

            int targetID = Convert.ToInt32(rawClientId);

            // FIX #9: Also capture requestID now so future Deny/Defer actions can target the
            // correct row without re-querying. Not used by Purge itself, but makes the pattern safe.
            var rawRequestId = dgvPurgeList.CurrentRow.Cells["requestID"]?.Value;
            int targetRequestID = (rawRequestId != null && rawRequestId != DBNull.Value)
                ? Convert.ToInt32(rawRequestId)
                : 0;

            // Safely pull the username, defaulting to "Unknown" if the cell is completely empty
            string targetUser = dgvPurgeList.CurrentRow.Cells["username"]?.Value?.ToString() ?? "Unknown";

            DialogResult confirm = MessageBox.Show(
                $"WARNING: You are about to terminate access for user '{targetUser}' (ID: {targetID}).\n\nThis will lock their account, detach them from their instructor, and archive their historical data. Proceed?",
                "ADMIN CLEARANCE REQUIRED",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                ExecutePurge(targetID, targetUser);
            }
        }

        private void ExecutePurge(int clientID, string username)
        {
            // NOTE: The soft-delete sets [password] = 'ACCESS_REVOKED' as a sentinel lock value.
            // This works correctly while passwords are stored as plaintext.
            // FIX #8: If password hashing is ever introduced, this sentinel must be updated to a
            // hash of an impossible value (e.g. a GUID) so it never accidentally matches a real hash.
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    OleDbTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Mark request as Completed
                        using (OleDbCommand cmd = new OleDbCommand(
                            "UPDATE termination_requests SET status = 'Completed' WHERE clientID = @id AND status = 'Pending'",
                            conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", clientID);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Soft Delete the user
                        string softDeleteSql = @"
                            UPDATE users 
                            SET status = 'Terminated', 
                                password_hash = 'ACCESS_REVOKED', 
                                assigned_instructor = NULL 
                            WHERE clientID = @id";

                        using (OleDbCommand cmd = new OleDbCommand(softDeleteSql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", clientID);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show(
                            $"User '{username}' has been successfully soft-deleted. Their access is revoked.",
                            "Termination Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        LoadTerminationRequests();
                    }
                    catch
                    {
                        transaction.Rollback();
                        // Re-throwing correctly to preserve the stack trace
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical Failure during termination sequence: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // UI STYLING ENGINE
        // ==========================================
        private void StylePurgeGrid()
        {
            dgvPurgeList.BackgroundColor = Color.FromArgb(20, 10, 10);
            dgvPurgeList.GridColor = Color.FromArgb(80, 20, 20);
            dgvPurgeList.EnableHeadersVisualStyles = false;
            dgvPurgeList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(120, 20, 20);
            dgvPurgeList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPurgeList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvPurgeList.DefaultCellStyle.BackColor = Color.FromArgb(30, 15, 15);
            dgvPurgeList.DefaultCellStyle.ForeColor = Color.White;
            dgvPurgeList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 40, 40);
            dgvPurgeList.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPurgeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(
                    lbl.ClientRectangle,
                    Color.FromArgb(255, 80, 80),
                    Color.FromArgb(180, 20, 20),
                    LinearGradientMode.Horizontal);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, 0, 0);
            }
        }

        private void RedButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    btn.ClientRectangle,
                    Color.FromArgb(200, 20, 20),
                    Color.FromArgb(100, 5, 5),
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, btn.ClientRectangle);
                }
                TextRenderer.DrawText(
                    e.Graphics,
                    btn.Text,
                    btn.Font,
                    btn.ClientRectangle,
                    Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}