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

namespace TollSystemDriver.UI
{
    public partial class MyProfile : Form
    {
        /// <summary>
        /// Currently logged in user
        /// </summary>
        User currentUser;

        /// <summary>
        /// Main constructor
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
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            label4.ForeColor = ThemeColor.PrimaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
            label6.ForeColor = ThemeColor.PrimaryColor;
            label7.ForeColor = ThemeColor.PrimaryColor;
            label8.ForeColor = ThemeColor.PrimaryColor;
            label10.ForeColor = ThemeColor.PrimaryColor;
            label11.ForeColor = ThemeColor.PrimaryColor;
        }

        /// <summary>
        /// Load the theme from main menu on load
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
        /// Check that correct data has been input in the form fields
        /// </summary>
        /// <returns></returns>
        private bool dataValidation()
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

            else if (!Validation.CheckStringIsDigitOnly(cityTextBox.Text))
            {
                MessageBox.Show("Please enter a valid City");
                return false;
            }

            else if (!Validation.CheckForValidDecimal(postCodeTextBox.Text))
            {
                MessageBox.Show("Please enter valid Post Code");
                return false;
            }
            else if (!Validation.CheckForValidDecimal(countryTextBox.Text))
            {
                MessageBox.Show("Please enter valid Country");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Update values when button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBttn_Click(object sender, EventArgs e)
        {
            //If data is wrong or missing, abort creation of user
            if (!dataValidation())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            string hashedPassword;
            int ID = currentUser.ID;
            string email = usernameTxtBox.Text;
            string name = nameTextBox.Text;
            string streetName = streetTextBox.Text;
            string city = cityTextBox.Text;
            string postCode = postCodeTextBox.Text;
            string country = countryTextBox.Text;


            //Check if password has been updated
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

            SetFieldValues();

            MessageBox.Show($"{currentUser.Name}, your account is succesfully updated! ");

        }

    }
}
