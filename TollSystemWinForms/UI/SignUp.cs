using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TollSystemServices.Enums;
using TollSystemServices;

namespace TollSystemWinForms.UI
{
    /// <summary>
    /// This is the code behind the Sign Up form
    /// This allows the user to sign up to the app as a driver user
    /// </summary>
    public partial class Signup : Form
    {
        /// <summary>
        /// Property to check the captcha text displayed
        /// </summary>
        private string CaptchaText = Validation.RandomString(5);

        /// <summary>
        /// Default Constructor that initialized the form and loads the captcha image
        /// </summary>
        public Signup()
        {
            InitializeComponent();
            LoadCaptcha();
        }

        /// <summary>
        /// Set the captcha image on the form load
        /// </summary>
        private void LoadCaptcha()
        {
            captchaPictureBox.Image = Validation.CaptchaToImage(CaptchaText, captchaPictureBox.Width,
                captchaPictureBox.Height);
        }

        /// <summary>
        /// Check that correct data has been input in the form fields
        /// </summary>
        /// <returns></returns>
        private bool DataValidation()
        {
            if (!Validation.IsValidEmail(usernameTxtBox.Text))
            {
                MessageBox.Show("Please enter a valid email address");
                return false;
            }

            else if (DataHelper.CheckForExistingEmail(usernameTxtBox.Text))
            {
                MessageBox.Show("Email already in use!");
                return false;
            }

            else if ((int)Validation.CheckPasswordStrength(passwordTxtBox.Text) < 3)
            {
                MessageBox.Show("Please enter a stronger password (One Uppercase Letter," +
                                "A Special Character, And A Minimum Length Of 12)");
                return false;
            }

            else if (!Validation.CheckForValidString(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a valid Name");
                return false;
            }

            else if (!Validation.CheckForValidString(streetTextBox.Text))
            {
                MessageBox.Show("Please enter a valid Street Name");
                return false;
            }

            else if (!Validation.CheckForValidString(cityTextBox.Text))
            {
                MessageBox.Show("Please enter a valid City");
                return false;
            }

            else if (!Validation.CheckForValidString(countryTextBox.Text))
            {
                MessageBox.Show("Please enter a valid Country");
                return false;
            }

            else if (!Validation.CheckForValidString(captchaTextBox.Text) ||
                    CaptchaText.ToUpper() != captchaTextBox.Text.ToUpper())
            {
                MessageBox.Show("Please enter a matching captcha");
                return false;
            }
            else if (!termsConditionsCheck.Checked)
            {
                MessageBox.Show("Agree to the terms and conditions");
                return false;
            }


            return true;
        }

        /// <summary>
        /// When the reload is clicked, change the captcha image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void captchaReloadPictureBox_Click(object sender, EventArgs e)
        {
            CaptchaText = Validation.RandomString(5);
            LoadCaptcha();
        }

        /// <summary>
        /// Create a new user in the database if all fields correctly filled in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signupBttn_Click(object sender, EventArgs e)
        {
            //If data is wrong or missing, abort creation of user
            if (!DataValidation())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            //Retrieve the data from the text boxes
            string email = usernameTxtBox.Text;
            string hashedPassword = Validation.HashPassword(passwordTxtBox.Text);
            string name = nameTextBox.Text;
            string streetName = streetTextBox.Text;
            string city = cityTextBox.Text;
            string postCode = postCodeTextBox.Text;
            string country = countryTextBox.Text;

            //Create a parameters list
            List<string> userDetails = new List<string> { email, hashedPassword, name, streetName, city, postCode, country };

            //Inser the user into the database
            DataConnection.InsertIntoUsersTable(userDetails,UserType.Driver);
        }

        /// <summary>
        /// Close the form, when the close button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closebttn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// When the mouse is held down on the password icon, display text password chars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            passwordTxtBox.UseSystemPasswordChar = false;
        }

        /// <summary>
        /// When the mouse is released on the password icon, display hidden password charss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            passwordTxtBox.UseSystemPasswordChar = true;
        }
    }
}
