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
    /// This is the code class for the 'Driver's form
    /// This returns a grid view withh all Users of type 'Driver'
    /// </summary>
    public partial class Drivers : Form
    {
        /// <summary>
        /// Default constructor that refreshes the data for the grid views
        /// </summary>
        public Drivers()
        {
            InitializeComponent();
            RefreshDataForUsersGridView();
        }

        /// <summary>
        /// Refresh the grid view with updated data
        /// </summary>
        public void RefreshDataForUsersGridView()
        {
            //Return all users of type 'driver' from the database
            var users = DataConnection.ReturnAllDrivers();

            //Return if no users found
            if (users == null || users.Count == 0)
            {
                return;
            }

            //Set the datasource to null and remove all rows from grid view, clearing it
            driversOverviewGridView.DataSource = null;
            driversOverviewGridView.Rows.Clear();

            //Add each driver into the grid view
            foreach (User user in users)
            {
                driversOverviewGridView.Rows.Add(user.ID,user.Name,user.Username,user.UserType.ToString(),
                                                 user.StreetName,user.City,user.PostCode,user.Country);
            }

            //Format the grid view and visually refresh it for the user
            UIHelper.FormatGridView(driversOverviewGridView);
            driversOverviewGridView.Refresh();
        }

        /// <summary>
        /// Cell click event for the grid view
        /// This fires off, when a cell is clicked by a user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void driversOverviewGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //If the cell clicked is not the 'Bill History' button, or the column headers were clicked, return
            if (e?.ColumnIndex != driversOverviewGridView.Columns["billHistory"].Index)
            {
                return;
            }
            else if(e.RowIndex == -1)
            {
                return;
            }

            int userID;

            //Try to get user ID of the clicked user, if not valid return
            if (!int.TryParse(driversOverviewGridView[0, e.RowIndex].Value?.ToString(), out userID))
            {
                return;
            }

            //Retrieve the email of the given user from the grid view
            string email = driversOverviewGridView[1, e.RowIndex].Value?.ToString();

            //Create a new bill history form for the given user, and show this to the toll operator
            BillHistoryForDriver billHistory = new BillHistoryForDriver(userID, email);
            billHistory.Show();

        }
    }
}
