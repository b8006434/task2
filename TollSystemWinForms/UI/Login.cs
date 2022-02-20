using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TollSystemWinForms.UI;
using TollSystemTollOperator.UI;
using TollSystemDriver.UI;
using TollSystemServices.Enums;
using TollSystemServices;

namespace TollSystemWinForms
{
    /// <summary>
    /// Login form
    /// </summary>
    public partial class Login : Form
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }


        /// <summary>
        /// White username, greyed out password text boxes
        /// </summary>
        private void FormatUsernameTxtBox()
        {
            usernameTxtBox.BackColor = Color.White;
            userNamePanel.BackColor = Color.White;
            passwordPanel.BackColor = SystemColors.Control;
            passwordTxtBox.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// White password, greyed out username text boxes
        /// </summary>
        private void FormatPasswordTxtBox()
        {
            passwordTxtBox.BackColor = Color.White;
            passwordPanel.BackColor = Color.White;
            usernameTxtBox.BackColor = SystemColors.Control;
            userNamePanel.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Custom close button, for modern look as WPF one doesn't look sleek enough
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closebttn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Format form when username textbox is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Click(object sender, EventArgs e)
        {
            FormatUsernameTxtBox();
        }

        /// <summary>
        /// Format form when password textbox is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_Click(object sender, EventArgs e)
        {
            FormatPasswordTxtBox();
        }

        /// <summary>
        /// When mouse held down, display the password in plain text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            passwordTxtBox.UseSystemPasswordChar = false;
        }

        /// <summary>
        /// When mouse is released, hide the password with password chars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            passwordTxtBox.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Close the login form and open the sign up form when sign up button clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signupBttn_Click(object sender, EventArgs e)
        {
            this.Hide();
            DialogResult signUpSuccess;
            using (Signup signupForm = new Signup())
            {
                signUpSuccess = signupForm.ShowDialog();
            }
            Show();
        }

        /// <summary>
        /// Log the user in when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBttn_Click(object sender, EventArgs e)
        {

            string username = usernameTxtBox.Text;
            string password = passwordTxtBox.Text;

            bool areFieldsValid = Validation.CheckForValidString(username) && Validation.CheckForValidString(password);

            if (!areFieldsValid)
            {
                MessageBox.Show("Please enter details in the credential fields!");
                passwordTxtBox.Text = string.Empty;
                return;
            }

            User currentUser = DataHelper.LogInUser(username, password);

            if (currentUser == null)
            {
                MessageBox.Show("Invalid credentials supplied");
                passwordTxtBox.Text = string.Empty;
                return;
            }

            this.Hide();
            DialogResult mainMenuSuccess;

            if(currentUser.UserType == UserType.Driver)
            {
                using(DriverDashboard driverDashboard = new DriverDashboard(currentUser))
                {
                    driverDashboard.ShowDialog();
                }
            }

            else if(currentUser.UserType == UserType.TollOperator)
            {
                using(TollOperatorDashboard tollOperatorDashboard = new TollOperatorDashboard(currentUser))
                {
                    tollOperatorDashboard.ShowDialog();
                }
            }

            if (!this.loginBttn.IsDisposed)
            {
                usernameTxtBox.Text = string.Empty;
                passwordTxtBox.Text = string.Empty;
                Show();
            }

        }

        /// <summary>
        /// Reset a password form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forgotPasswordBttn_Click(object sender, EventArgs e)
        {
            this.Hide();
            DialogResult forgottenPasswordSuccess;

            using (ForgottenPassword forgottenPassword = new ForgottenPassword())
            {
                forgottenPasswordSuccess = forgottenPassword.ShowDialog();
            }

            Show();
        }
    }
}
