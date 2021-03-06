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

namespace TollSystemTollOperator.UI
{
    /// <summary>
    /// The code behing the My Profile form
    /// This lets the toll operator change their password and name
    /// </summary>
    public partial class MyProfile : Form
    {
        /// <summary>
        /// Currently logged in user
        /// </summary>
        User currentUser;

        /// <summary>
        /// Default constructor setting the currently logged in user property
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
                    btn.BackColor = UIHelper.PrimaryColor;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.FlatAppearance.BorderColor = UIHelper.SecondaryColor;
                }
            }

            label4.ForeColor = UIHelper.PrimaryColor;
            label5.ForeColor = UIHelper.PrimaryColor;
            label6.ForeColor = UIHelper.PrimaryColor;
        }

        /// <summary>
        /// When this form is loaded, set the theme and text field values
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

            return true;
        }

        /// <summary>
        /// Event that fires, when the update button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBttn_Click(object sender, EventArgs e)
        {
            //If data is wrong or missing, abort update of user
            if (!DataValidation())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            //Properties to be retrieved from forms
            string hashedPassword;
            int ID = currentUser.ID;
            string email = usernameTxtBox.Text;
            string name = nameTextBox.Text;

            //Properties set from currently logged in toll operator user, as unable to change these
            string streetName = currentUser.StreetName;
            string city = currentUser.City;
            string postCode = currentUser.PostCode;
            string country = currentUser.Country;


            //Set the password if it was updated
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
            parameters.AddRange(new[] { email, hashedPassword, name, streetName, city, postCode, country });

            //Update the user in database, and update the current user info
            DataConnection.UpdateUserInTable(ID, parameters);
            currentUser = DataConnection.LoginUser(email, hashedPassword);

            //Refresh the text field values, as the user details have changed
            SetFieldValues();

            //Show a message success to the user
            MessageBox.Show($"{currentUser.Name}, your account is succesfully updated! ");

        }

    }
}
