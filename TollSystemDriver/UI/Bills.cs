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
    public partial class Bills : Form
    {
        private User CurrentUser;

        public Bills()
        {
            InitializeComponent();
            
        }

        public Bills(User currentUser)
        {

            InitializeComponent();

            this.CurrentUser = currentUser;
            RefreshDataForBillsGridView();
        }

        private void RefreshDataForBillsGridView()
        {
            billsOverviewGridView.DataSource = null;
            billsOverviewGridView.Rows.Clear();
            var unpaidBills = DataConnection.ReturnUnpaidBillsForUser(CurrentUser.ID);

            foreach (Bill bill in unpaidBills)
            {
                billsOverviewGridView.Rows.Add(bill.ID,bill.MotorwayEntryPoint, bill.MotorwayLeavingPoint, bill.DriverType,
                                         bill.RegistrationPlate, bill.VehicleType, $"£{bill.AmountToPay}");
            }

            FormatGridView();
            billsOverviewGridView.Refresh();
        }

        /// <summary>
        /// Format the grid view preview for user
        /// </summary>
        private void FormatGridView()
        {
            billsOverviewGridView.ReadOnly = true;
            billsOverviewGridView.DefaultCellStyle.SelectionBackColor = billsOverviewGridView.DefaultCellStyle.BackColor;
            billsOverviewGridView.DefaultCellStyle.SelectionForeColor = billsOverviewGridView.DefaultCellStyle.ForeColor;
            billsOverviewGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            billsOverviewGridView.DefaultCellStyle.ForeColor = Color.Black;
            billsOverviewGridView.DefaultCellStyle.SelectionBackColor = Color.GhostWhite;
            billsOverviewGridView.RowHeadersVisible = false;
            billsOverviewGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewRow row in billsOverviewGridView.Rows)
            {
                billsOverviewGridView[0, row.Index].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }

            foreach (DataGridViewColumn column in billsOverviewGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        public bool PayBill(int billID)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            return paymentProcessor.PayBill(billID);
        }

        private void billsOverviewGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e?.ColumnIndex != billsOverviewGridView.Columns["payBills"].Index)
            {
                return;
            }

            int billID;
            if (!int.TryParse(billsOverviewGridView[0, e.RowIndex].Value.ToString(), out billID))
            {
                return;
            }

            if(PayBill(billID))
            {
                RefreshDataForBillsGridView();
            }


        }

    }
}
