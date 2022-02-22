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
    public partial class TravelHistory : Form
    {
        public User CurrentUser { get; set; }

        public TravelHistory(User user)
        {
            InitializeComponent();

            this.CurrentUser = user;
            RefreshDataForBillsGridView();
        }

        private void RefreshDataForBillsGridView()
        {
            travelOverviewGridView.DataSource = null;
            travelOverviewGridView.Rows.Clear();
            var unpaidBills = DataConnection.ReturnPaidBillsForUser(CurrentUser.ID);

            foreach (Bill bill in unpaidBills)
            {
                travelOverviewGridView.Rows.Add(bill.ID, bill.MotorwayEntryPoint, bill.MotorwayLeavingPoint,
                                         bill.RegistrationPlate, bill.VehicleType, $"£{bill.AmountToPay}",bill.PaidDateTime);
            }

            FormatGridView();
            travelOverviewGridView.Refresh();
        }

        /// <summary>
        /// Format the grid view preview for user
        /// </summary>
        private void FormatGridView()
        {
            travelOverviewGridView.ReadOnly = true;
            travelOverviewGridView.DefaultCellStyle.SelectionBackColor = travelOverviewGridView.DefaultCellStyle.BackColor;
            travelOverviewGridView.DefaultCellStyle.SelectionForeColor = travelOverviewGridView.DefaultCellStyle.ForeColor;
            travelOverviewGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            travelOverviewGridView.DefaultCellStyle.ForeColor = Color.Black;
            travelOverviewGridView.DefaultCellStyle.SelectionBackColor = Color.GhostWhite;
            travelOverviewGridView.RowHeadersVisible = false;
            travelOverviewGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewRow row in travelOverviewGridView.Rows)
            {
                travelOverviewGridView[0, row.Index].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }

            foreach (DataGridViewColumn column in travelOverviewGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
    }
}
