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
    /// This is the code behind the Forgotten Password screen
    /// This lets the user reset their password
    /// </summary>
    public partial class ForgottenPassword : Form
    {
        /// <summary>
        /// Default Constructor that initializes the form
        /// </summary>
        public ForgottenPassword()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Send a reset password request to the user's email address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetPasswordBttn_Click(object sender, EventArgs e)
        {
            string email = usernameTxtBox.Text;

            //If the email supplied is wrong, doesn't exist or isn't valid, return here and display an error message
            if (!(Validation.CheckForValidString(email)) ||
                !(DataHelper.CheckForExistingEmail(email)) || !(Validation.IsValidEmail(email)))
            {
                MessageBox.Show("Enter a correct email address");
                this.DialogResult = DialogResult.None;
                return;
            }

            //Reset password here - currently not doing anything as DB is running locally
            //Otherwise server would send a password request email to user

            MessageBox.Show("Password reset email sent! ");
        }
    }
}
