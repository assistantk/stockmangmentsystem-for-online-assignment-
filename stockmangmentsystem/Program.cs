using System;
using System.Windows.Forms;

namespace stockmangmentsystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Start the application with the login form
            Application.Run(new Form1());
        }
    }
}
