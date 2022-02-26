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
    /// <summary>
    /// Code for the 'Travel History' form
    /// Allows the user to see their travel history
    /// </summary>
    public partial class TravelHistory : Form
    {
        /// <summary>
        /// Property that retrieves the currently logged in user
        /// </summary>
        private User CurrentUser { get; set; }

        /// <summary>
        /// Default constructor, which sets the logged in user value, and populates the grid view with data
        /// </summary>
        /// <param name="user"></param>
        public TravelHistory(User user)
        {
            InitializeComponent();

            this.CurrentUser = user;
            RefreshDataForBillsGridView();
        }

        /// <summary>
        /// Refresh the data in the grid view
        /// </summary>
        private void RefreshDataForBillsGridView()
        {
            //Return the paid bills for the given user - this is the travel history
            var paidBills = DataConnection.ReturnTravelHistoryForUser(CurrentUser.ID);

            //Return if no paid bills found
            if (paidBills == null || paidBills.Count == 0)
            {
                return;
            }

            //Remove all data from the grid view, by setting the data source to null and removing all displayed rows
            travelOverviewGridView.DataSource = null;
            travelOverviewGridView.Rows.Clear();

            //Add each journey information to the grid view
            foreach (Bill bill in paidBills)
            {
                travelOverviewGridView.Rows.Add(bill.ID, bill.MotorwayEntryPoint, bill.MotorwayLeavingPoint,
                                         bill.RegistrationPlate, bill.VehicleType, $"£{bill.AmountToPay}",bill.PaidDateTime);
            }

            //Format the grid view and refresh data for the user so they can see the change visually
            UIHelper.FormatGridView(travelOverviewGridView);
            travelOverviewGridView.Refresh();
        }

    }
}
