using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TollSystemServices;

namespace TollSystemDriver.UI
{
    /// <summary>
    /// This is the main landing page for the 'Driver' user
    /// </summary>
    public partial class DriverDashboard : Form
    {
        /// <summary>
        /// Currently logged in user
        /// </summary>
        private User CurrentUser;

        /// <summary>
        /// Currently selected button
        /// </summary>
        private Button currentButton;

        /// <summary>
        /// Random variable
        /// </summary>
        private Random random;

        /// <summary>
        /// Temporary index
        /// </summary>
        private int tempIndex;

        /// <summary>
        /// Get currently active form
        /// </summary>
        private Form activeForm;

        /// <summary>
        /// Main constructor which sets the user and variables
        /// </summary>
        /// <param name="currentUser"></param>
        public DriverDashboard(User user)
        {
            InitializeComponent();

            SetIcons();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.CurrentUser = user;
            random = new Random();
        }

        /// <summary>
        /// Dll for custom drag
        /// </summary>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        /// <summary>
        /// Dll for custom drag
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="wMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// Set icons for various controls
        /// </summary>
        private void SetIcons()
        {
            //Set relevant icons for the left hand side buttons in the main menu for a 'Driver' user
            this.myProfileBttn.Image = (new Bitmap(Properties.Resources.information, new Size(32, 32)));
            this.travelHistoryBttn.Image = (new Bitmap(Properties.Resources.map, new Size(32, 32)));
            this.billsBttn.Image = (new Bitmap(Properties.Resources.bill, new Size(32, 32)));
            this.logoutBttn.Image = (new Bitmap(Properties.Resources.logout, new Size(32, 32)));
        }

        /// <summary>
        /// Set a random theme color 
        /// </summary>
        /// <returns>A color for a control</returns>
        private Color SelectThemeColor()
        {
            //Get a random number in the range of the color list defined in the UIHelper
            int index = random.Next(UIHelper.ColorList.Count);

            //Loop through the colors to get a random color
            while (tempIndex == index)
            {
                index = random.Next(UIHelper.ColorList.Count);
            }
            tempIndex = index;

            //Return the Color
            string color = UIHelper.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        /// <summary>
        /// Highlight the clicked button
        /// </summary>
        /// <param name="btnSender"></param>
        private void ActivateButton(object btnSender)
        {
            //If clicked object is not a button, and currently selected button is the same as sender, return
            if (btnSender == null)
            {
                return;
            }
            else if (currentButton == (Button)btnSender)
            {
                return;
            }

            //Set the button and panel properties
            DisableButton();
            Color color = SelectThemeColor();
            currentButton = (Button)btnSender;
            currentButton.BackColor = color;
            currentButton.ForeColor = Color.White;
            currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            panelTitleBar.BackColor = color;
            panelLogo.BackColor = UIHelper.ChangeColorBrightness(color, -0.3);
            UIHelper.PrimaryColor = color;
            UIHelper.SecondaryColor = UIHelper.ChangeColorBrightness(color, -0.3);
        }

        /// <summary>
        /// Disable button theme
        /// </summary>
        private void DisableButton()
        {
            //Change the theme for the buttons
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        /// <summary>
        /// Open a child form on the main form
        /// </summary>
        /// <param name="childForm"></param>
        /// <param name="btnSender"></param>
        private void OpenChildForm(Form childForm, object btnSender)
        {
            //If the form has already been opened , close it 
            if (activeForm != null)
            {
                activeForm.Close();
            }

            //Highlight the clicked button and set the active form
            ActivateButton(btnSender);
            activeForm = childForm;

            //Set the form properties
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            //Add the form to the controls
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;

            //Display the clicked form
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        /// <summary>
        /// Open my information screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myInformationBttn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MyProfile(CurrentUser), sender);
        }

        /// <summary>
        /// Open Bills screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void billsBttn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Bills(CurrentUser),sender);
        }

        /// <summary>
        /// Open travel history screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void travelHistoryBttn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TravelHistory(CurrentUser), sender);
        }

        /// <summary>
        /// Drag main form with the top bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Close button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Minimize button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Log the user out and close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logoutBttn_Click(object sender, EventArgs e)
        {
            this.CurrentUser = null;
        }

        /// <summary>
        /// Each time the main form is shown, refresh the logged in user data, in case it was changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mainfrm_Activated(object sender, EventArgs e)
        {
            var user = this.CurrentUser;
            this.CurrentUser = DataHelper.RefreshUser(user.Username, user.HashedPassword);
        }
    }
}
