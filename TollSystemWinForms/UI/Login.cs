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
    /// This is the code behind the Login form
    /// This lets the user login to the app
    /// </summary>
    public partial class Login : Form
    {
        /// <summary>
        /// Default Constructor that initializes the form
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Format the screen so the screen is: 
        /// Username textbox is white(active) and password text box is greyed out
        /// </summary>
        private void FormatUsernameTxtBox()
        {
            usernameTxtBox.BackColor = Color.White;
            userNamePanel.BackColor = Color.White;
            passwordPanel.BackColor = SystemColors.Control;
            passwordTxtBox.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Format the screen so the screen is: 
        /// Username textbox is greyed out and password text box is white(active)
        /// </summary>
        private void FormatPasswordTxtBox()
        {
            passwordTxtBox.BackColor = Color.White;
            passwordPanel.BackColor = Color.White;
            usernameTxtBox.BackColor = SystemColors.Control;
            userNamePanel.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Exit the application if the close button is clicked
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
        /// When the mouse is held down on the password icon, display plain text password chars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            passwordTxtBox.UseSystemPasswordChar = false;
        }

        /// <summary>
        /// When the mouse is released on the password icon, display hidden password chars
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
        /// Log the user in when the login button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBttn_Click(object sender, EventArgs e)
        {
            //Retrive username and password from the text boxes
            string username = usernameTxtBox.Text;
            string password = passwordTxtBox.Text;

            //Check that both fields are valid
            bool areFieldsValid = Validation.CheckForValidString(username) && Validation.CheckForValidString(password);

            //If fields are not valid, return, clear the password text box and display an error message
            if (!areFieldsValid)
            {
                MessageBox.Show("Please enter details in the credential fields!");
                passwordTxtBox.Text = string.Empty;
                return;
            }

            //Log in the user
            User currentUser = DataHelper.LogInUser(username, password);

            //If the user was not found, return and display an error message
            if (currentUser == null)
            {
                MessageBox.Show("Invalid credentials supplied");
                passwordTxtBox.Text = string.Empty;
                return;
            }

            this.Hide();

            //If the logged in user is a driver, display the driver dashboard
            if(currentUser.UserType == UserType.Driver)
            {
                using(DriverDashboard driverDashboard = new DriverDashboard(currentUser))
                {
                    driverDashboard.ShowDialog();
                }
            }

            //If the logged in user is a toll operator, display the toll operator dashbaord
            else if(currentUser.UserType == UserType.TollOperator)
            {
                using(TollOperatorDashboard tollOperatorDashboard = new TollOperatorDashboard(currentUser))
                {
                    tollOperatorDashboard.ShowDialog();
                }
            }

            //If for some reason, the user was not logged in, and the login form wasn't disposed of,
            //Show the login form again
            if (!this.loginBttn.IsDisposed)
            {
                usernameTxtBox.Text = string.Empty;
                passwordTxtBox.Text = string.Empty;
                Show();
            }

        }

        /// <summary>
        /// Display the forgot password form
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
