using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace FITBAI
{
    public static class DatabaseHelper
    {
        // ONE connection string to rule them all! 
        // We use the exact path you provided earlier.
        public static readonly string ConnectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\johnl\Documents\G\FITBAI\FITBAI\ftbaiUSERS.accdb";

        /// <summary>
        /// Generates a fresh, ready-to-use database connection.
        /// Always wrap this in a 'using' statement in your forms!
        /// </summary>
        public static OleDbConnection GetConnection()
        {
            return new OleDbConnection(ConnectionString);
        }
    }
}