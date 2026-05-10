using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;

namespace FITBAI
{
    public partial class usrSetUpProfilecs : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private Form? _parentForm;
        private string _currentUsername;

        // Constructor
        public usrSetUpProfilecs(Form parentForm, string registeredUsername)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _currentUsername = registeredUsername;

            // Attach Custom Graphics
            panelLeft.Paint += SidePanel_Paint;
            panelRight.Paint += SidePanel_Paint;
            lblMainTitle.Paint += TitleGradient_Paint;
            btnProceed.Paint += GradientButton_Paint;
            btnBack.Paint += SecondaryButton_Paint;
        }

        // ==========================================
        // CUSTOM UI GRAPHICS
        // ==========================================
        private void SidePanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (HatchBrush hBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, 25, 75), Color.Transparent))
                {
                    e.Graphics.FillRectangle(hBrush, panel.ClientRectangle);
                }
            }
        }

        private void TitleGradient_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Label lbl)
            {
                LinearGradientBrush brush = new LinearGradientBrush(lbl.ClientRectangle,
                    Color.FromArgb(80, 120, 255), Color.FromArgb(180, 80, 255), LinearGradientMode.Horizontal);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(lbl.Text, lbl.Font, brush, lbl.ClientRectangle, sf);
            }
        }

        private void GradientButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(btn.ClientRectangle,
                    Color.FromArgb(120, 50, 200), Color.FromArgb(60, 20, 100), LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, btn.ClientRectangle);
                }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void SecondaryButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button btn)
            {
                using (Pen pen = new Pen(Color.FromArgb(80, 100, 200), 2))
                {
                    e.Graphics.DrawRectangle(pen, 1, 1, btn.Width - 2, btn.Height - 2);
                }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, Color.FromArgb(170, 180, 220), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        // ==========================================
        // DATABASE & HANDOFF LOGIC
        // ==========================================
        private void btnProceed_Click(object sender, EventArgs e)
        {
            // 1. Validate Input
            if (!double.TryParse(txtbxHeight.Text, out double heightCm) || !double.TryParse(txtWeight.Text, out double weightKg))
            {
                MessageBox.Show("Please enter valid numerical values for Height (cm) and Weight (kg).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Incremental Database Update
            double initialBMI = BMICalculator.CalcBMI(heightCm, weightKg);

            try
            {
                using (OleDbConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string updateQuery = @"UPDATE users SET height_cm = @h, weight_kg = @w, bmi = @bmi, 
                       gender = @gender, occupation = @occ, contact_no = @contact 
                       WHERE username = @user";

                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@h", heightCm);
                        cmd.Parameters.AddWithValue("@w", weightKg);
                        cmd.Parameters.AddWithValue("@bmi", initialBMI);
                        cmd.Parameters.AddWithValue("@gender", txtbxGender.Text.Trim());
                        cmd.Parameters.AddWithValue("@occ", txtbxOccu.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact", txtbxContactNum.Text.Trim());
                        cmd.Parameters.AddWithValue("@user", _currentUsername);

                        cmd.ExecuteNonQuery();
                    }
                }

                // 3. THE HANDOFF TO STEP 2
                // We pass the raw text to trigger the BMI visual UI, plus the username and parent form!
                usrPfp1 goalSelection = new usrPfp1(txtbxHeight.Text, txtWeight.Text, _currentUsername, _parentForm);
                goalSelection.StartPosition = FormStartPosition.Manual;
                goalSelection.Location = this.Location;
                goalSelection.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Update Error: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // WINDOW CONTROLS
        // ==========================================
        private void btnBack_Click(object sender, EventArgs e)
        {
            _parentForm?.Show();
            this.Close();
        }

        private void btnUsrPfClose_Click(object sender, EventArgs e) => Application.Exit();

        private void btnUsrPfMin_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void btnUsrPfMinMax_Click(object sender, EventArgs e) => this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;

        private void topheader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}