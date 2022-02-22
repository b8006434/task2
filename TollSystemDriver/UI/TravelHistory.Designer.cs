
namespace TollSystemDriver.UI
{
    partial class TravelHistory
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
            this.travelOverviewGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entryPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leavingPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regPlate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billPaidDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.travelOverviewGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // travelOverviewGridView
            // 
            this.travelOverviewGridView.BackgroundColor = System.Drawing.Color.White;
            this.travelOverviewGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.travelOverviewGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.entryPoint,
            this.leavingPoint,
            this.regPlate,
            this.vehicleType,
            this.amountPaid,
            this.billPaidDate});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.travelOverviewGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.travelOverviewGridView.Location = new System.Drawing.Point(12, 12);
            this.travelOverviewGridView.Name = "travelOverviewGridView";
            this.travelOverviewGridView.Size = new System.Drawing.Size(514, 289);
            this.travelOverviewGridView.TabIndex = 22;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
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
            // amountPaid
            // 
            this.amountPaid.HeaderText = "Amount Paid";
            this.amountPaid.Name = "amountPaid";
            this.amountPaid.ReadOnly = true;
            // 
            // billPaidDate
            // 
            this.billPaidDate.HeaderText = "Paid Date";
            this.billPaidDate.Name = "billPaidDate";
            // 
            // TravelHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.travelOverviewGridView);
            this.Name = "TravelHistory";
            this.Text = "TravelHistory";
            ((System.ComponentModel.ISupportInitialize)(this.travelOverviewGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView travelOverviewGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn leavingPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn regPlate;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn billPaidDate;
    }
}