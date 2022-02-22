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
    public partial class BillHistoryForDriver : Form
    {
        public BillHistoryForDriver(int userID, string userName)
        {
            InitializeComponent();
            RefreshDataForBillsGridView(userID,userName);
        }

        private void RefreshDataForBillsGridView(int userID, string userName)
        {
            billsOverviewGridView.DataSource = null;
            billsOverviewGridView.Rows.Clear();
            var allBills = DataConnection.ReturnAllBillsByUserID(userID);

            foreach (Bill bill in allBills)
            {
                string billPaid = bill.BillPaid == true ? "Yes" : "No";
                string billPaidDate = bill.PaidDateTime.ToString() == "01/01/0001 00:00:00" ? "" : bill.PaidDateTime.ToString();

                billsOverviewGridView.Rows.Add(bill.ID,userName, bill.MotorwayEntryPoint, bill.MotorwayLeavingPoint, bill.DriverType,
                                         bill.RegistrationPlate, bill.VehicleType, $"£{bill.AmountToPay}", billPaid, billPaidDate);
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

    }
}
