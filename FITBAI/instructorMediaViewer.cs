using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace FITBAI
{
    public partial class instructorMediaViewer : Form
    {
        private int currentMediaID;
        private string mediaFilePath;
        private string currentMediaType;

        // Custom Constructor to receive data from the Overview grid
        public instructorMediaViewer(int mediaID, string mediaType, string caption, string filePath)
        {
            InitializeComponent();

            this.currentMediaID = mediaID;
            this.currentMediaType = mediaType;
            this.mediaFilePath = filePath;

            // Set UI details
            lblCaption.Text = $"CLIENT NOTE: \"{caption}\"";

            // Wire up UI Styling
            this.Paint += Border_Paint;
            btnSubmit.Paint += PrimaryButton_Paint;
            btnCancel.Paint += SecondaryButton_Paint;
            btnPlayVideo.Paint += PrimaryButton_Paint;

            this.Load += InstructorMediaViewer_Load;
        }

        private void InstructorMediaViewer_Load(object? sender, EventArgs e)
        {
            // Logic to handle Image vs Video
            if (currentMediaType.ToUpper() == "IMAGE")
            {
                btnPlayVideo.Visible = false;
                try
                {
                    if (File.Exists(mediaFilePath))
                    {
                        picViewer.Image = Image.FromFile(mediaFilePath);
                    }
                    else
                    {
                        lblError.Text = "Image file not found on disk.";
                        lblError.Visible = true;
                    }
                }
                catch { lblError.Text = "Error loading image."; lblError.Visible = true; }
            }
            else if (currentMediaType.ToUpper() == "VIDEO")
            {
                picViewer.Visible = false;
                btnPlayVideo.Visible = true;
            }
        }

        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(mediaFilePath))
                {
                    // Launches the video in the computer's default media player
                    Process.Start(new ProcessStartInfo(mediaFilePath) { UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show("Video file not found on disk.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { MessageBox.Show("Could not launch video: " + ex.Message); }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string feedback = txtFeedback.Text.Trim();

            if (string.IsNullOrWhiteSpace(feedback))
            {
                MessageBox.Show("Please enter feedback before submitting.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    // OleDb requires positional ? placeholders — NOT named @params
                    string query = "UPDATE gallery_logs SET instructor_feedback = ?, feedback_date = ? WHERE mediaID = ?";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Order MUST match the ? positions in the query above
                        cmd.Parameters.AddWithValue("?", feedback);
                        cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("?", currentMediaID);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                            throw new Exception("No matching record found for mediaID " + currentMediaID + ". Verify DB migration was applied.");
                    }
                }
                MessageBox.Show("Feedback securely transmitted to client.", "Form Check Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Database Sync Failed: " + ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ==========================================
        // UI STYLING ENGINE
        // ==========================================
        private void Border_Paint(object? sender, PaintEventArgs e)
        {
            // Draws a cool glowing teal border around the pop-up
            using (Pen pen = new Pen(Color.FromArgb(0, 188, 212), 4))
            { e.Graphics.DrawRectangle(pen, 2, 2, this.Width - 4, this.Height - 4); }
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

        private void SecondaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                e.Graphics.Clear(Color.FromArgb(20, 25, 35));
                using (Pen pen = new Pen(Color.FromArgb(100, 110, 130), 2))
                { e.Graphics.DrawRectangle(pen, 1, 1, btn.Width - 2, btn.Height - 2); }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.LightGray, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}