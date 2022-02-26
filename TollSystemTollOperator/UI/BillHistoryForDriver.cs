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
    /// This is the code for the 'Bill History For Driver' form
    /// This form displays all bills for a given driver
    /// </summary>
    public partial class BillHistoryForDriver : Form
    {
        /// <summary>
        /// Default constructor setting the data for the grid view
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        public BillHistoryForDriver(int userID, string userName)
        {
            InitializeComponent();
            RefreshDataForBillsGridView(userID,userName);
        }


        /// <summary>
        /// Refresh the grid view with updated data
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userName"></param>
        private void RefreshDataForBillsGridView(int userID, string userName)
        {
            //Return all bills for a giver user
            var allBills = DataConnection.ReturnAllBillsByUserID(userID);

            //Return if no bills found
            if (allBills == null || allBills.Count == 0)
            {
                return;
            }

            //Set the data source to null and remove all user rows, clearing the grid view
            billsOverviewGridView.DataSource = null;
            billsOverviewGridView.Rows.Clear();

            //Add each returned bill into the grid view
            foreach (Bill bill in allBills)
            {
                string billPaid = bill.BillPaid == true ? "Yes" : "No";
                string billPaidDate = bill.PaidDateTime.ToString() == "01/01/0001 00:00:00" ? "" : bill.PaidDateTime.ToString();

                billsOverviewGridView.Rows.Add(bill.ID,userName, bill.MotorwayEntryPoint, bill.MotorwayLeavingPoint, bill.DriverType,
                                         bill.RegistrationPlate, bill.VehicleType, $"£{bill.AmountToPay}", billPaid, billPaidDate);
            }

            //Format the grid view and visually refresh the grid view for user
            UIHelper.FormatGridView(billsOverviewGridView);
            billsOverviewGridView.Refresh();
        }
    }
}
