
namespace TollSystemTollOperator.UI
{
    partial class Drivers
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
            this.driversOverviewGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.streetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billHistory = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.driversOverviewGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // driversOverviewGridView
            // 
            this.driversOverviewGridView.BackgroundColor = System.Drawing.Color.White;
            this.driversOverviewGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.driversOverviewGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.userName,
            this.userEmail,
            this.userType,
            this.streetName,
            this.city,
            this.postCode,
            this.country,
            this.billHistory});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.driversOverviewGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.driversOverviewGridView.Location = new System.Drawing.Point(12, 12);
            this.driversOverviewGridView.Name = "driversOverviewGridView";
            this.driversOverviewGridView.Size = new System.Drawing.Size(514, 289);
            this.driversOverviewGridView.TabIndex = 22;
            this.driversOverviewGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.driversOverviewGridView_CellClick);
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
            // userEmail
            // 
            this.userEmail.HeaderText = "User Email";
            this.userEmail.Name = "userEmail";
            this.userEmail.ReadOnly = true;
            // 
            // userType
            // 
            this.userType.HeaderText = "User Type";
            this.userType.Name = "userType";
            this.userType.ReadOnly = true;
            // 
            // streetName
            // 
            this.streetName.HeaderText = "Street Name";
            this.streetName.Name = "streetName";
            this.streetName.ReadOnly = true;
            // 
            // city
            // 
            this.city.HeaderText = "City";
            this.city.Name = "city";
            this.city.ReadOnly = true;
            // 
            // postCode
            // 
            this.postCode.HeaderText = "Post Code";
            this.postCode.Name = "postCode";
            this.postCode.ReadOnly = true;
            // 
            // country
            // 
            this.country.HeaderText = "Country";
            this.country.Name = "country";
            this.country.ReadOnly = true;
            // 
            // billHistory
            // 
            this.billHistory.HeaderText = "Bill History";
            this.billHistory.Name = "billHistory";
            this.billHistory.ReadOnly = true;
            this.billHistory.Text = "Bill History";
            this.billHistory.UseColumnTextForButtonValue = true;
            // 
            // Drivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.driversOverviewGridView);
            this.Name = "Drivers";
            this.Text = "Drivers";
            ((System.ComponentModel.ISupportInitialize)(this.driversOverviewGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView driversOverviewGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn userEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn userType;
        private System.Windows.Forms.DataGridViewTextBoxColumn streetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn postCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewButtonColumn billHistory;
    }
}