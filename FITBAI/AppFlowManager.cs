using System;
using System.Windows.Forms;

namespace FITBAI
{
    // ==========================================
    // THE USER ROLE ENUMERATION
    // This tells C# exactly what a "UserRole" is!
    // ==========================================
    public enum UserRole
    {
        Client,
        Instructor,
        Admin
    }

    public static class AppFlowManager
    {
        // ==========================================
        // GLOBAL STATE (Session Memory)
        // ==========================================
        public static string CurrentUsername { get; set; } = "";
        public static string CurrentUserRole { get; set; } = "";

        // ==========================================
        // COMPUTED ENUM PROPERTY
        // Bridges the plain-text database string to the C# Enum safely.
        // ==========================================
        public static UserRole CurrentRole =>
            Enum.TryParse(CurrentUserRole, true, out UserRole r) ? r : UserRole.Client;

        // ==========================================
        // THE SMART ROUTER (Fixes Login.cs errors)
        // ==========================================
        public static void EnterApp(Form loginForm, string role)
        {
            // 1. Sanitize and Save the role to global memory
            CurrentUserRole = role.Trim();

            // 2. Route based on the role string
            string checkRole = CurrentUserRole.ToUpper();

            if (checkRole == "ADMIN")
            {
                LoadAdminDashboard(loginForm);
            }
            else if (checkRole == "INSTRUCTOR")
            {
                LoadInstructorDashboard(loginForm);
            }
            else
            {
                LoadClientDashboard(loginForm);
            }
        }

        // ==========================================
        // ROLE-BASED LOADING ENGINES
        // ==========================================
        public static void LoadClientDashboard(Form currentForm)
        {
            // Passes CurrentUsername so the client dashboard knows who is logged in
            usrMAINpage clientDash = new usrMAINpage(CurrentUsername);
            clientDash.Show();
            currentForm.Hide();
        }

        public static void LoadAdminDashboard(Form currentForm)
        {
            adminMAINpage adminDash = new adminMAINpage();
            adminDash.Show();
            currentForm.Hide();
        }

        public static void LoadInstructorDashboard(Form currentForm)
        {
            instructorMAINpage instructorDash = new instructorMAINpage();
            instructorDash.Show();
            currentForm.Hide();
        }

        // ==========================================
        // SECURE SYSTEM LOGOUT
        // ==========================================
        public static void Logout(Form currentForm)
        {
            // 1. Wipe the global session memory for security
            CurrentUsername = "";
            CurrentUserRole = "";

            // 2. Load a fresh Login screen
            Login loginScreen = new Login();
            loginScreen.Show();

            // 3. Destroy the current session window
            currentForm.Close();
        }
    }
}