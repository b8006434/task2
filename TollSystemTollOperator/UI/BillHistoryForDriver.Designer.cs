
namespace TollSystemTollOperator.UI
{
    partial class BillHistoryForDriver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.billsOverviewGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entryPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leavingPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regPlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.billsOverviewGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // billsOverviewGridView
            // 
            this.billsOverviewGridView.BackgroundColor = System.Drawing.Color.White;
            this.billsOverviewGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.billsOverviewGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.userName,
            this.entryPoint,
            this.leavingPoint,
            this.driverType,
            this.regPlate,
            this.vehicleType,
            this.amountDue,
            this.billPaid,
            this.paidDateTime});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.billsOverviewGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.billsOverviewGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billsOverviewGridView.Location = new System.Drawing.Point(0, 0);
            this.billsOverviewGridView.Name = "billsOverviewGridView";
            this.billsOverviewGridView.Size = new System.Drawing.Size(800, 450);
            this.billsOverviewGridView.TabIndex = 22;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // userName
            // 
            this.userName.HeaderText = "User Name";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            // 
            // entryPoint
            // 
            this.entryPoint.HeaderText = "Entry Point";
            this.entryPoint.Name = "entryPoint";
            this.entryPoint.ReadOnly = true;
            // 
            // leavingPoint
            // 
            this.leavingPoint.HeaderText = "Leaving Point";
            this.leavingPoint.Name = "leavingPoint";
            this.leavingPoint.ReadOnly = true;
            // 
            // driverType
            // 
            this.driverType.HeaderText = "Driver Type";
            this.driverType.Name = "driverType";
            this.driverType.ReadOnly = true;
            // 
            // regPlate
            // 
            this.regPlate.HeaderText = "Reg. Plate";
            this.regPlate.Name = "regPlate";
            this.regPlate.ReadOnly = true;
            // 
            // vehicleType
            // 
            this.vehicleType.HeaderText = "Vehicle Type";
            this.vehicleType.Name = "vehicleType";
            this.vehicleType.ReadOnly = true;
            // 
            // amountDue
            // 
            this.amountDue.HeaderText = "Amount Due";
            this.amountDue.Name = "amountDue";
            this.amountDue.ReadOnly = true;
            // 
            // billPaid
            // 
            this.billPaid.HeaderText = "Paid";
            this.billPaid.Name = "billPaid";
            this.billPaid.ReadOnly = true;
            // 
            // paidDateTime
            // 
            this.paidDateTime.HeaderText = "Paid On";
            this.paidDateTime.Name = "paidDateTime";
            this.paidDateTime.ReadOnly = true;
            // 
            // BillHistoryForDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.billsOverviewGridView);
            this.Name = "BillHistoryForDriver";
            this.Text = "BillHistoryForDriver";
            ((System.ComponentModel.ISupportInitialize)(this.billsOverviewGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView billsOverviewGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn leavingPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverType;
        private System.Windows.Forms.DataGridViewTextBoxColumn regPlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn billPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidDateTime;
    }
}