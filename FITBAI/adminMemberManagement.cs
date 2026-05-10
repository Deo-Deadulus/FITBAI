using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class adminMemberManagement : Form
    {
        public adminMemberManagement()
        {
            InitializeComponent();
            StyleMemberGrid();

            // Wire up UI Styling
            lblTitle.Paint += TitleGradient_Paint;
            btnUpdateStatus.Paint += PrimaryButton_Paint;

            this.Load += AdminMemberManagement_Load;
        }

        private void AdminMemberManagement_Load(object? sender, EventArgs e)
        {
            LoadMemberData();
        }

        private void LoadMemberData()
        {
            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT clientID, username, full_name, email, [role], status, occupation, primary_goal FROM users ORDER BY clientID ASC";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMemberList.DataSource = dt;

                    dgvMemberList.Columns["clientID"].HeaderText = "ID";
                    dgvMemberList.Columns["username"].HeaderText = "USERNAME";
                    dgvMemberList.Columns["full_name"].HeaderText = "NAME";
                    dgvMemberList.Columns["email"].HeaderText = "EMAIL";
                    dgvMemberList.Columns["role"].HeaderText = "ROLE";
                    dgvMemberList.Columns["status"].HeaderText = "STATUS";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sync Error: Unable to access user directory.\n" + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvMemberList.CurrentRow == null) return;

            int clientID = Convert.ToInt32(dgvMemberList.CurrentRow.Cells["clientID"].Value);
            string currentStatus = dgvMemberList.CurrentRow.Cells["status"].Value.ToString();
            string newStatus = (currentStatus == "Active") ? "Inactive" : "Active";

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE users SET [status] = @s WHERE clientID = @id";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@s", newStatus);
                        cmd.Parameters.AddWithValue("@id", clientID);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadMemberData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed: " + ex.Message);
            }
        }

        private void StyleMemberGrid()
        {
            dgvMemberList.BackgroundColor = Color.FromArgb(20, 25, 45);
            dgvMemberList.GridColor = Color.FromArgb(40, 50, 90);
            dgvMemberList.EnableHeadersVisualStyles = false;
            dgvMemberList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 40, 100);
            dgvMemberList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMemberList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvMemberList.DefaultCellStyle.BackColor = Color.FromArgb(15, 20, 40);
            dgvMemberList.DefaultCellStyle.ForeColor = Color.White;
            dgvMemberList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 120, 255);
            dgvMemberList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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