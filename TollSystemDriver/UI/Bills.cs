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
using TollSystemServices.Enums;
using TollSystemServices.Services;

namespace TollSystemDriver.UI
{
    /// <summary>
    /// This class is the UI backend for the 'Bills' page, when a driver is logged in.
    /// </summary>
    public partial class Bills : Form
    {
        /// <summary>
        /// Property to retrieve current user and the details
        /// </summary>
        private User CurrentUser;

        /// <summary>
        /// The default constructor to create a bills page
        /// Sets the user and sets the bills grid view with data
        /// </summary>
        /// <param name="currentUser"></param>
        public Bills(User currentUser)
        {

            InitializeComponent();

            this.CurrentUser = currentUser;
            RefreshDataForBillsGridView();
        }

        /// <summary>
        /// Refresh Data for bills grid view
        /// This is needed after bill is paid, as the collection of bills has changed
        /// </summary>
        private void RefreshDataForBillsGridView()
        {
            //Return unpaid bills from the DB for the currently logged in user
            var unpaidBills = DataConnection.ReturnUnpaidBillsForUser(CurrentUser.ID);

            //Return if no unpaid bills found
            if (unpaidBills == null || unpaidBills.Count == 0)
            {
                return;
            }

            //Delete the data source for grid view by setting it to null
            //Also remove all visible rows
            billsOverviewGridView.DataSource = null;
            billsOverviewGridView.Rows.Clear();

            //Add each unpaid bill into the grid view
            foreach (Bill bill in unpaidBills)
            {
                billsOverviewGridView.Rows.Add(bill.ID,bill.MotorwayEntryPoint, bill.MotorwayLeavingPoint, bill.DriverType,
                                         bill.RegistrationPlate, bill.VehicleType, $"£{bill.AmountToPay}");
            }

            //Format grid view and refresh so the user can see the changes
            UIHelper.FormatGridView(billsOverviewGridView);
            billsOverviewGridView.Refresh();
        }

        /// <summary>
        /// This calls the payment processor to process a bill payment
        /// This is called when the 'Pay Bill' button is pressed in the grid view
        /// </summary>
        /// <param name="billID"></param>
        /// <returns></returns>
        public bool PayBill(int billID)
        {
            //Call the payment processor, and return the payment status (true for success)
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            return paymentProcessor.PayBill(billID);
        }

        /// <summary>
        /// Event that is called when the user clicks a cell in the grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void billsOverviewGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //If the 'Pay Bill' button is not clicked, or a column header was clicked, return
            if(e?.ColumnIndex != billsOverviewGridView.Columns["payBills"].Index)
            {
                return;
            }
            else if(e.RowIndex == -1)
            {
                return;
            }

            //Try to retrieve the bill ID, if not succuesfull, return
            int billID;
            if (!int.TryParse(billsOverviewGridView[0, e.RowIndex].Value?.ToString(), out billID))
            {
                return;
            }

            //Call the payment processor, if the payment does not fail, refresh data
            if(PayBill(billID))
            {
                RefreshDataForBillsGridView();
            }


        }

    }
}
