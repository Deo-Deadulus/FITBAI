using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace FITBAI
{
    public class TermsBox : Form
    {
        // Custom Colors matching your design
        private Color bgColor = Color.FromArgb(12, 16, 33);
        private Color panelBgColor = Color.FromArgb(15, 20, 40);
        private Color borderColor = Color.FromArgb(40, 50, 85);
        private Color headerColor = Color.FromArgb(140, 165, 215);
        private Color textColor = Color.FromArgb(100, 120, 160);

        public TermsBox()
        {
            // Form Setup
            this.Size = new Size(700, 550); // Slightly taller for easy reading
            this.BackColor = bgColor;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;

            // Form Border
            this.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
            };

            // Close Button (The 'X')
            Label lblClose = new Label();
            lblClose.Text = "X";
            lblClose.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            lblClose.ForeColor = headerColor;
            lblClose.AutoSize = true;
            lblClose.Location = new Point(this.Width - 30, 15);
            lblClose.Cursor = Cursors.Hand;
            lblClose.Click += (s, e) => this.Close();
            this.Controls.Add(lblClose);

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "fitBAI • terms & conditions";
            lblTitle.Font = new Font("Old English Text MT", 24, FontStyle.Regular);
            lblTitle.ForeColor = headerColor;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(30, 30);
            this.Controls.Add(lblTitle);

            // Create the rounded panel container for the text
            Panel textPanel = new Panel();
            textPanel.Location = new Point(35, 90);
            textPanel.Size = new Size(630, 420);
            textPanel.BackColor = panelBgColor;
            textPanel.Paint += DrawRoundedPanel;
            this.Controls.Add(textPanel);

            // Scrollable Text Box
            TextBox txtTerms = new TextBox();
            txtTerms.Multiline = true;
            txtTerms.ReadOnly = true;
            txtTerms.ScrollBars = ScrollBars.Vertical;
            txtTerms.BackColor = panelBgColor;
            txtTerms.ForeColor = textColor;
            txtTerms.BorderStyle = BorderStyle.None;
            txtTerms.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtTerms.Location = new Point(15, 15);
            txtTerms.Size = new Size(600, 390);

            // Load text from file if it exists, otherwise use fallback
            if (File.Exists("termsandcond.txt"))
            {
                txtTerms.Text = File.ReadAllText("termsandcond.txt");
            }
            else
            {
                txtTerms.Text = GetFallbackText();
            }

            // Unselect text so it doesn't look highlighted on load
            txtTerms.SelectionStart = 0;
            txtTerms.SelectionLength = 0;

            textPanel.Controls.Add(txtTerms);
        }

        // Helper method to draw the rounded border
        private void DrawRoundedPanel(object sender, PaintEventArgs e)
        {
            Panel? p = sender as Panel;
            if (p == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            int radius = 10;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(p.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(p.Width - radius - 1, p.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, p.Height - radius - 1, radius, radius, 90, 90);
            path.CloseFigure();

            using (Pen pen = new Pen(borderColor, 1.5f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        // Fallback text just in case termsandcond.txt is missing
        private string GetFallbackText()
        {
            return @"Terms and Conditions: Fit BAI

The following Terms and Conditions govern the use of Fit BAI: Body Adiposity Indicator. By completing the registration process and clicking “I Agree” during sign-up, the user acknowledges that they have read, understood, and accepted all terms stated herein. Users who do not agree must not proceed with registration.

8.1 Acceptance of Terms
Registration and use of Fit BAI constitutes full and unconditional acceptance of these Terms and Conditions. Fit BAI reserves the right to update or modify these terms at any time. Continued use of the application following any modification constitutes acceptance of the revised terms. Users will be notified of significant changes upon their next login.

8.2 User Eligibility
Age Requirement: Fit BAI is intended for users aged 13 and above. Users between the ages of 13 and 17 must have parental or guardian consent before registering.

Accuracy of Information: Users must provide accurate, complete, and truthful information during registration, including name, age, gender, height, and weight. False information may result in inaccurate fitness recommendations and account suspension.

Account Limits: Each individual may maintain only one (1) active account. Duplicate accounts are subject to removal without prior notice.

8.3 Account Responsibilities
Users are solely responsible for maintaining the confidentiality of their login credentials. Any activity performed under a registered account is the full responsibility of the account holder. Users must immediately notify the system administrator if unauthorized access to their account is suspected. Fit BAI shall not be held liable for any loss or damage resulting from a failure to safeguard account credentials.

8.4 Health & Fitness Disclaimer
Fit BAI provides adaptive workout plans and fitness recommendations based on user-supplied profile data (gender, age, weight, and BMI). These recommendations are generated for general informational and educational purposes only and do not constitute medical advice, diagnosis, or treatment.

Users with pre-existing medical conditions, injuries, or health concerns are strongly advised to consult a licensed physician or certified fitness professional before beginning any exercise program suggested by the application. Fit BAI and its developers assume no liability for injury, health complications, or adverse effects arising from the use of generated workout plans.

8.5 Data Privacy & Storage
Local Storage: All user data, including personal profile information, workout history, and activity logs, is stored locally in a portable MS Access database file (FitBAI.accdb) on the user’s device. No data is transmitted to external servers or third parties.

Security: User passwords are protected using HMACSHA512 hashing with a unique salt per account. Plain-text passwords are never stored.

Right to Deletion: Users have the right to request deletion of their account and associated data at any time by contacting the system administrator.

No Telemetry: The application does not collect analytics, telemetry, or usage data beyond what is explicitly saved by the user within the application.

8.6 Acceptable Use Policy
Users agree not to misuse the application in any of the following ways:

• Attempting to gain unauthorized access to other user accounts or the Admin dashboard.
• Submitting false, misleading, or harmful data that may compromise the integrity of the system or other users’ experiences.
• Reverse engineering, decompiling, or distributing the application or its database without explicit written permission from the developer.
• Using the application for any purpose that violates applicable local, national, or international laws or regulations.

Note: Violation of the Acceptable Use Policy may result in immediate account suspension or permanent termination without prior notice.

8.7 Intellectual Property
All software code, UI design, database schema, workout content, and exercise media (images and video clips) included in Fit BAI are the intellectual property of the developer, John Lourence Deo, unless otherwise attributed. Users are granted a limited, non-exclusive, non-transferable license to use the application for personal, non-commercial fitness management purposes only. Redistribution, resale, or commercial use is strictly prohibited without written consent.

8.8 Limitation of Liability
To the fullest extent permitted by applicable law, Fit BAI and its developer shall not be liable for any direct, indirect, incidental, consequential, or punitive damages arising from:

• Use or inability to use the application.
• Reliance on workout recommendations or fitness data generated by the application.
• Data loss due to hardware failure, accidental deletion, or database corruption.
• Unauthorized access to user data resulting from circumstances beyond the developer’s reasonable control.

8.9 Termination
The developer reserves the right to terminate or suspend any user account at any time, with or without cause, including but not limited to violations of these Terms and Conditions. Upon termination, the user’s access to the application will be revoked, and their data may be permanently deleted from the database.

8.10 Governing Law
These Terms and Conditions shall be governed by and construed in accordance with the laws of the Republic of the Philippines. Any disputes arising from the use of this application shall be subject to the exclusive jurisdiction of the competent courts of the Philippines.

8.11 User Consent at Sign-Up
During the registration screen, users will be presented with a scrollable Terms and Conditions dialog. The “Register” button will remain disabled until the user checks the acknowledgment checkbox labeled:

""I have read and agree to the Fit BAI Terms and Conditions and Health Disclaimer.""";
        }

        // Call this to display the box
        public static void ShowTerms()
        {
            using (TermsBox box = new TermsBox())
            {
                box.ShowDialog();
            }
        }
    }
}