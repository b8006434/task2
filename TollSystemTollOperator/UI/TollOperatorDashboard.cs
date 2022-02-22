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

namespace TollSystemTollOperator.UI
{
    public partial class TollOperatorDashboard : Form
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
        /// Main constructor
        /// </summary>
        /// <param name="currentUser"></param>
        public TollOperatorDashboard(User user)
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
        /// Additional constructor for inheritance
        /// </summary>
        public TollOperatorDashboard()
        {

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
            this.myProfileBttn.Image = (new Bitmap(Properties.Resources.information, new Size(32, 32)));
            this.driversBttn.Image = (new Bitmap(Properties.Resources.team, new Size(32, 32)));
            this.logoutBttn.Image = (new Bitmap(Properties.Resources.logout, new Size(32, 32)));
        }

        /// <summary>
        /// Set a random theme color 
        /// </summary>
        /// <returns></returns>
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        /// <summary>
        /// Highlight the clicked button
        /// </summary>
        /// <param name="btnSender"></param>
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        /// <summary>
        /// Disable button theme
        /// </summary>
        private void DisableButton()
        {
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
            if (activeForm != null && activeForm.Text != "Daily Challenge")
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        /// <summary>
        /// Open dashboards screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myInformationBttn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MyProfile(CurrentUser), sender);
        }

        /// <summary>
        /// Open challenges screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void driversBttn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Drivers(), sender);
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
