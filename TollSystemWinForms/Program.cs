using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TollSystemWinForms
{
    /// <summary>
    /// This is the program class, where the actual application is launched from
    /// All the test data(tollsystem@admin.com, driver@norway.com & driver@sweden.com) have the password
    /// set as 'password123.'
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
