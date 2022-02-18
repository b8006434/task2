namespace TollSystemWinForms
{
    partial class Login
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
            this.leftSidePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.doctorPicture = new System.Windows.Forms.PictureBox();
            this.rightSidePanel = new System.Windows.Forms.Panel();
            this.forgotPasswordBttn = new System.Windows.Forms.Button();
            this.signupBttn = new System.Windows.Forms.Button();
            this.loginBttn = new System.Windows.Forms.Button();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.passwordTxtBox = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.userNamePanel = new System.Windows.Forms.Panel();
            this.usernameTxtBox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closebttn = new System.Windows.Forms.Button();
            this.leftSidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doctorPicture)).BeginInit();
            this.rightSidePanel.SuspendLayout();
            this.passwordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.userNamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // leftSidePanel
            // 
            this.leftSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.leftSidePanel.Controls.Add(this.label2);
            this.leftSidePanel.Controls.Add(this.label3);
            this.leftSidePanel.Controls.Add(this.doctorPicture);
            this.leftSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftSidePanel.Location = new System.Drawing.Point(0, 0);
            this.leftSidePanel.Name = "leftSidePanel";
            this.leftSidePanel.Size = new System.Drawing.Size(300, 350);
            this.leftSidePanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(83, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Toll System App";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sign Up Or Log In To The";
            // 
            // doctorPicture
            // 
            this.doctorPicture.Image = global::TollSystemWinForms.Properties.Resources.bill;
            this.doctorPicture.Location = new System.Drawing.Point(99, 65);
            this.doctorPicture.Name = "doctorPicture";
            this.doctorPicture.Size = new System.Drawing.Size(120, 120);
            this.doctorPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.doctorPicture.TabIndex = 0;
            this.doctorPicture.TabStop = false;
            // 
            // rightSidePanel
            // 
            this.rightSidePanel.Controls.Add(this.forgotPasswordBttn);
            this.rightSidePanel.Controls.Add(this.signupBttn);
            this.rightSidePanel.Controls.Add(this.loginBttn);
            this.rightSidePanel.Controls.Add(this.passwordPanel);
            this.rightSidePanel.Controls.Add(this.userNamePanel);
            this.rightSidePanel.Controls.Add(this.label1);
            this.rightSidePanel.Controls.Add(this.closebttn);
            this.rightSidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightSidePanel.Location = new System.Drawing.Point(300, 0);
            this.rightSidePanel.Name = "rightSidePanel";
            this.rightSidePanel.Size = new System.Drawing.Size(450, 350);
            this.rightSidePanel.TabIndex = 1;
            // 
            // forgotPasswordBttn
            // 
            this.forgotPasswordBttn.BackColor = System.Drawing.SystemColors.Control;
            this.forgotPasswordBttn.FlatAppearance.BorderSize = 0;
            this.forgotPasswordBttn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotPasswordBttn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.forgotPasswordBttn.Location = new System.Drawing.Point(82, 276);
            this.forgotPasswordBttn.Name = "forgotPasswordBttn";
            this.forgotPasswordBttn.Size = new System.Drawing.Size(274, 26);
            this.forgotPasswordBttn.TabIndex = 10;
            this.forgotPasswordBttn.Text = "Forgot Password?";
            this.forgotPasswordBttn.UseVisualStyleBackColor = false;
            this.forgotPasswordBttn.Click += new System.EventHandler(this.forgotPasswordBttn_Click);
            // 
            // signupBttn
            // 
            this.signupBttn.BackColor = System.Drawing.SystemColors.Control;
            this.signupBttn.FlatAppearance.BorderSize = 0;
            this.signupBttn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupBttn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.signupBttn.Location = new System.Drawing.Point(242, 225);
            this.signupBttn.Name = "signupBttn";
            this.signupBttn.Size = new System.Drawing.Size(148, 35);
            this.signupBttn.TabIndex = 9;
            this.signupBttn.Text = "SIGNUP";
            this.signupBttn.UseVisualStyleBackColor = false;
            this.signupBttn.Click += new System.EventHandler(this.signupBttn_Click);
            // 
            // loginBttn
            // 
            this.loginBttn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.loginBttn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBttn.ForeColor = System.Drawing.Color.White;
            this.loginBttn.Location = new System.Drawing.Point(48, 225);
            this.loginBttn.Name = "loginBttn";
            this.loginBttn.Size = new System.Drawing.Size(148, 35);
            this.loginBttn.TabIndex = 8;
            this.loginBttn.Text = "LOGIN";
            this.loginBttn.UseVisualStyleBackColor = false;
            this.loginBttn.Click += new System.EventHandler(this.loginBttn_Click);
            // 
            // passwordPanel
            // 
            this.passwordPanel.BackColor = System.Drawing.SystemColors.Control;
            this.passwordPanel.Controls.Add(this.passwordTxtBox);
            this.passwordPanel.Controls.Add(this.pictureBox3);
            this.passwordPanel.Location = new System.Drawing.Point(0, 164);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(450, 45);
            this.passwordPanel.TabIndex = 7;
            // 
            // passwordTxtBox
            // 
            this.passwordTxtBox.BackColor = System.Drawing.SystemColors.Control;
            this.passwordTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTxtBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTxtBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.passwordTxtBox.Location = new System.Drawing.Point(55, 12);
            this.passwordTxtBox.Name = "passwordTxtBox";
            this.passwordTxtBox.Size = new System.Drawing.Size(370, 20);
            this.passwordTxtBox.TabIndex = 9;
            this.passwordTxtBox.UseSystemPasswordChar = true;
            this.passwordTxtBox.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TollSystemWinForms.Properties.Resources.padlockIcon;
            this.pictureBox3.Location = new System.Drawing.Point(6, 18);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
            // 
            // userNamePanel
            // 
            this.userNamePanel.BackColor = System.Drawing.Color.White;
            this.userNamePanel.Controls.Add(this.usernameTxtBox);
            this.userNamePanel.Controls.Add(this.pictureBox2);
            this.userNamePanel.Location = new System.Drawing.Point(3, 115);
            this.userNamePanel.Name = "userNamePanel";
            this.userNamePanel.Size = new System.Drawing.Size(450, 45);
            this.userNamePanel.TabIndex = 6;
            // 
            // usernameTxtBox
            // 
            this.usernameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTxtBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTxtBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.usernameTxtBox.Location = new System.Drawing.Point(42, 18);
            this.usernameTxtBox.Name = "usernameTxtBox";
            this.usernameTxtBox.Size = new System.Drawing.Size(370, 20);
            this.usernameTxtBox.TabIndex = 8;
            this.usernameTxtBox.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TollSystemWinForms.Properties.Resources.emailIcon;
            this.pictureBox2.Location = new System.Drawing.Point(6, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label1.Location = new System.Drawing.Point(20, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Login to your profile";
            // 
            // closebttn
            // 
            this.closebttn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closebttn.FlatAppearance.BorderSize = 0;
            this.closebttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebttn.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebttn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.closebttn.Location = new System.Drawing.Point(410, 0);
            this.closebttn.Name = "closebttn";
            this.closebttn.Size = new System.Drawing.Size(40, 40);
            this.closebttn.TabIndex = 0;
            this.closebttn.Text = "X ";
            this.closebttn.UseVisualStyleBackColor = true;
            this.closebttn.Click += new System.EventHandler(this.closebttn_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.loginBttn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 350);
            this.ControlBox = false;
            this.Controls.Add(this.rightSidePanel);
            this.Controls.Add(this.leftSidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.leftSidePanel.ResumeLayout(false);
            this.leftSidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doctorPicture)).EndInit();
            this.rightSidePanel.ResumeLayout(false);
            this.rightSidePanel.PerformLayout();
            this.passwordPanel.ResumeLayout(false);
            this.passwordPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.userNamePanel.ResumeLayout(false);
            this.userNamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftSidePanel;
        private System.Windows.Forms.PictureBox doctorPicture;
        private System.Windows.Forms.Panel rightSidePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button closebttn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.Panel userNamePanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button signupBttn;
        private System.Windows.Forms.Button loginBttn;
        private System.Windows.Forms.TextBox passwordTxtBox;
        private System.Windows.Forms.TextBox usernameTxtBox;
        private System.Windows.Forms.Button forgotPasswordBttn;
    }
}

