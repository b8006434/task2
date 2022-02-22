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
    public partial class Drivers : Form
    {
        public Drivers()
        {
            InitializeComponent();
            RefreshDataForUsersGridView();
        }

        public void RefreshDataForUsersGridView()
        {
            driversOverviewGridView.DataSource = null;
            driversOverviewGridView.Rows.Clear();

            var users = DataConnection.ReturnAllDrivers();

            foreach (User user in users)
            {
                driversOverviewGridView.Rows.Add(user.ID,user.Name,user.Username,user.UserType.ToString(),
                                                 user.StreetName,user.City,user.PostCode,user.Country);
            }

            FormatGridView();
            driversOverviewGridView.Refresh();
        }

        /// <summary>
        /// Format the grid view preview for user
        /// </summary>
        private void FormatGridView()
        {
            driversOverviewGridView.ReadOnly = true;
            driversOverviewGridView.DefaultCellStyle.SelectionBackColor = driversOverviewGridView.DefaultCellStyle.BackColor;
            driversOverviewGridView.DefaultCellStyle.SelectionForeColor = driversOverviewGridView.DefaultCellStyle.ForeColor;
            driversOverviewGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            driversOverviewGridView.DefaultCellStyle.ForeColor = Color.Black;
            driversOverviewGridView.DefaultCellStyle.SelectionBackColor = Color.GhostWhite;
            driversOverviewGridView.RowHeadersVisible = false;
            driversOverviewGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewRow row in driversOverviewGridView.Rows)
            {
                driversOverviewGridView[0, row.Index].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }

            foreach (DataGridViewColumn column in driversOverviewGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private void driversOverviewGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e?.ColumnIndex != driversOverviewGridView.Columns["billHistory"].Index)
            {
                return;
            }

            int userID;

            if (!int.TryParse(driversOverviewGridView[0, e.RowIndex].Value?.ToString(), out userID))
            {
                return;
            }

            string userName = driversOverviewGridView[1, e.RowIndex].Value?.ToString();
            BillHistoryForDriver billHistory = new BillHistoryForDriver(userID, userName);
            billHistory.Show();

        }
    }
}
