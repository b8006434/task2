using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TollSystemServices;

namespace TollSystemDriver.UI
{
    /// <summary>
    /// Code for the 'My Profile' form.
    /// Allows users to change their information in the DB
    /// </summary>
    public partial class MyProfile : Form
    {
        /// <summary>
        /// Property for the currently logged in user
        /// </summary>
        private User currentUser;

        /// <summary>
        /// Main constructor, set the user property
        /// </summary>
        public MyProfile(User user)
        {
            InitializeComponent();

            this.currentUser = user;
        }

        /// <summary>
        /// Load theme from main menu in here
        /// </summary>
        private void LoadTheme()
        {
            //Set the colours of each button to the theme from UIHelper
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = UIHelper.PrimaryColor;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.FlatAppearance.BorderColor = UIHelper.SecondaryColor;
                }
            }

            //Set all of the labels' color to the theme from UIHelper
            label4.ForeColor = UIHelper.PrimaryColor;
            label5.ForeColor = UIHelper.PrimaryColor;
            label6.ForeColor = UIHelper.PrimaryColor;
            label7.ForeColor = UIHelper.PrimaryColor;
            label8.ForeColor = UIHelper.PrimaryColor;
            label10.ForeColor = UIHelper.PrimaryColor;
            label11.ForeColor = UIHelper.PrimaryColor;
        }

        /// <summary>
        /// When form shown for the first time, load the colours and set the current user's values 
        /// To the text fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyProfile_Load(object sender, EventArgs e)
        {
            LoadTheme();
            SetFieldValues();
        }

        /// <summary>
        /// Set field values to values from the currently logged in user
        /// </summary>
        private void SetFieldValues()
        {
            usernameTxtBox.Text = currentUser.Username;
            passwordTxtBox.Text = currentUser.HashedPassword;
            nameTextBox.Text = currentUser.Name;
            streetTextBox.Text = currentUser.StreetName;
            cityTextBox.Text = currentUser.City;
            postCodeTextBox.Text = currentUser.PostCode;
            countryTextBox.Text = currentUser.Country;

        }

        /// <summary>
        /// Check that correct data has been input in the form fields, and show error message,
        /// When wrong data has been input in the field
        /// </summary>
        /// <returns></returns>
        private bool DataValidation()
        {
            if (!Validation.IsValidEmail(usernameTxtBox.Text))
            {
                MessageBox.Show("Please enter a valid email address");
                return false;
            }

            else if (DataHelper.CheckForExistingEmail(usernameTxtBox.Text) && usernameTxtBox.Text != currentUser.Username)
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

            else if (!Validation.CheckForValidString(postCodeTextBox.Text))
            {
                MessageBox.Show("Please enter valid Post Code");
                return false;
            }
            else if (!Validation.CheckForValidString(countryTextBox.Text))
            {
                MessageBox.Show("Please enter valid Country");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Update values when the 'Update' button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBttn_Click(object sender, EventArgs e)
        {
            //If data is wrong or missing, abort the update of the user
            if (!DataValidation())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            //Get the user details from the text boxes
            string hashedPassword;
            int ID = currentUser.ID;
            string email = usernameTxtBox.Text;
            string name = nameTextBox.Text;
            string streetName = streetTextBox.Text;
            string city = cityTextBox.Text;
            string postCode = postCodeTextBox.Text;
            string country = countryTextBox.Text;


            //If the password has been changed, hash it, if not just use the current value
            if (!Validation.CheckIfPasswordChanged(ID, passwordTxtBox.Text))
            {
                hashedPassword = passwordTxtBox.Text;
            }
            else
            {
                hashedPassword = Validation.HashPassword(passwordTxtBox.Text);
            }

            //Set the parameters up
            List<string> parameters = new List<string>();
            parameters.AddRange(new[] {email,hashedPassword,name,streetName,city,postCode,country});

            //Update the user in database, and update the current user info
            DataConnection.UpdateUserInTable(ID, parameters);
            currentUser = DataConnection.LoginUser(email, hashedPassword);

            //Update the text field values in the form
            SetFieldValues();

            //Display a success message
            MessageBox.Show($"{currentUser.Name}, your account is succesfully updated! ");

        }

    }
}
