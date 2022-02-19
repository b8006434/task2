using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TollSystemServices;

namespace TollSystemWinForms.UI
{
    /// <summary>
    /// Login form
    /// </summary>
    public partial class ForgottenPassword : Form
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ForgottenPassword()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Log the user in when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBttn_Click(object sender, EventArgs e)
        {
            string username = usernameTxtBox.Text;
            if (!(Validation.CheckForValidString(username)) ||
                !(DataHelper.CheckForExistingEmail(username)) || !(Validation.IsValidEmail(username)))
            {
                MessageBox.Show("Enter a correct email address");
                this.DialogResult = DialogResult.None;
                return;
            }

            //Reset password here - currently not doing anything as DB is running locally
            //Otherwise server would send a password request code to user

            MessageBox.Show("Password reset email sent! ");
        }
    }
}
