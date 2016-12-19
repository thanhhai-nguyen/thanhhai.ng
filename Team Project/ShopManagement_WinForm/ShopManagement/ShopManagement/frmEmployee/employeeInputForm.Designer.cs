namespace ShopManagement
{
    partial class employeeInputForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dpkBirthday = new System.Windows.Forms.DateTimePicker();
            this.cbbCourtecy = new System.Windows.Forms.ComboBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLink = new System.Windows.Forms.Button();
            this.dpkHireDate = new System.Windows.Forms.DateTimePicker();
            this.txtMngID = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbbCountry = new System.Windows.Forms.ComboBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.mtPostalCode = new System.Windows.Forms.MaskedTextBox();
            this.mtPhone = new System.Windows.Forms.MaskedTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.errLastName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errFirstname = new System.Windows.Forms.ErrorProvider(this.components);
            this.errTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.errPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.errAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.errCity = new System.Windows.Forms.ErrorProvider(this.components);
            this.errBirthday = new System.Windows.Forms.ErrorProvider(this.components);
            this.errHireday = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClearMngID = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFirstname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBirthday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errHireday)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dpkBirthday);
            this.panel1.Controls.Add(this.cbbCourtecy);
            this.panel1.Controls.Add(this.txtFirstName);
            this.panel1.Controls.Add(this.txtLastName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 162);
            this.panel1.TabIndex = 0;
            // 
            // dpkBirthday
            // 
            this.dpkBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpkBirthday.Location = new System.Drawing.Point(109, 127);
            this.dpkBirthday.Name = "dpkBirthday";
            this.dpkBirthday.Size = new System.Drawing.Size(158, 20);
            this.dpkBirthday.TabIndex = 9;
            // 
            // cbbCourtecy
            // 
            this.cbbCourtecy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCourtecy.FormattingEnabled = true;
            this.cbbCourtecy.Items.AddRange(new object[] {
            "Ms.",
            "Mrs.",
            "Mr.",
            "Dr."});
            this.cbbCourtecy.Location = new System.Drawing.Point(109, 90);
            this.cbbCourtecy.Name = "cbbCourtecy";
            this.cbbCourtecy.Size = new System.Drawing.Size(158, 21);
            this.cbbCourtecy.TabIndex = 8;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(109, 50);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(195, 20);
            this.txtFirstName.TabIndex = 6;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(109, 7);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(195, 20);
            this.txtLastName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Birthday:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Courtecy:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "City:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Title:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Region:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Manager ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Potal Code:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Hire Date:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Phone:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClearMngID);
            this.panel2.Controls.Add(this.btnLink);
            this.panel2.Controls.Add(this.dpkHireDate);
            this.panel2.Controls.Add(this.txtMngID);
            this.panel2.Controls.Add(this.txtTitle);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(13, 182);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(331, 149);
            this.panel2.TabIndex = 13;
            // 
            // btnLink
            // 
            this.btnLink.Image = global::ShopManagement.Properties.Resources.search_loop_512;
            this.btnLink.Location = new System.Drawing.Point(176, 88);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(30, 23);
            this.btnLink.TabIndex = 13;
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // dpkHireDate
            // 
            this.dpkHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpkHireDate.Location = new System.Drawing.Point(109, 20);
            this.dpkHireDate.Name = "dpkHireDate";
            this.dpkHireDate.Size = new System.Drawing.Size(158, 20);
            this.dpkHireDate.TabIndex = 10;
            // 
            // txtMngID
            // 
            this.txtMngID.Location = new System.Drawing.Point(109, 91);
            this.txtMngID.Name = "txtMngID";
            this.txtMngID.Size = new System.Drawing.Size(61, 20);
            this.txtMngID.TabIndex = 12;
            this.txtMngID.TextChanged += new System.EventHandler(this.txtMngID_TextChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(109, 58);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(195, 20);
            this.txtTitle.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Country:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbbCountry);
            this.panel3.Controls.Add(this.txtRegion);
            this.panel3.Controls.Add(this.txtCity);
            this.panel3.Controls.Add(this.txtAddress);
            this.panel3.Controls.Add(this.mtPostalCode);
            this.panel3.Controls.Add(this.mtPhone);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(351, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 243);
            this.panel3.TabIndex = 14;
            // 
            // cbbCountry
            // 
            this.cbbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCountry.FormattingEnabled = true;
            this.cbbCountry.Items.AddRange(new object[] {
            "USA",
            "UK",
            "Campodia",
            "Japan",
            "Germany",
            "Laos",
            "Vietnam"});
            this.cbbCountry.Location = new System.Drawing.Point(104, 161);
            this.cbbCountry.Name = "cbbCountry";
            this.cbbCountry.Size = new System.Drawing.Size(158, 21);
            this.cbbCountry.TabIndex = 9;
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(104, 204);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(195, 20);
            this.txtRegion.TabIndex = 17;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(104, 125);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(195, 20);
            this.txtCity.TabIndex = 16;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(104, 83);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(195, 20);
            this.txtAddress.TabIndex = 8;
            // 
            // mtPostalCode
            // 
            this.mtPostalCode.Location = new System.Drawing.Point(104, 46);
            this.mtPostalCode.Mask = "00000";
            this.mtPostalCode.Name = "mtPostalCode";
            this.mtPostalCode.Size = new System.Drawing.Size(110, 20);
            this.mtPostalCode.TabIndex = 15;
            this.mtPostalCode.ValidatingType = typeof(int);
            // 
            // mtPhone
            // 
            this.mtPhone.Location = new System.Drawing.Point(104, 8);
            this.mtPhone.Mask = "(999) 000-0000";
            this.mtPhone.Name = "mtPhone";
            this.mtPhone.Size = new System.Drawing.Size(110, 20);
            this.mtPhone.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(383, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(539, 276);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // errLastName
            // 
            this.errLastName.ContainerControl = this;
            // 
            // errFirstname
            // 
            this.errFirstname.ContainerControl = this;
            // 
            // errTitle
            // 
            this.errTitle.ContainerControl = this;
            // 
            // errPhone
            // 
            this.errPhone.ContainerControl = this;
            // 
            // errAddress
            // 
            this.errAddress.ContainerControl = this;
            // 
            // errCity
            // 
            this.errCity.ContainerControl = this;
            // 
            // errBirthday
            // 
            this.errBirthday.ContainerControl = this;
            // 
            // errHireday
            // 
            this.errHireday.ContainerControl = this;
            // 
            // btnClearMngID
            // 
            this.btnClearMngID.Location = new System.Drawing.Point(213, 88);
            this.btnClearMngID.Name = "btnClearMngID";
            this.btnClearMngID.Size = new System.Drawing.Size(24, 23);
            this.btnClearMngID.TabIndex = 14;
            this.btnClearMngID.Text = "X";
            this.btnClearMngID.UseVisualStyleBackColor = true;
            this.btnClearMngID.Click += new System.EventHandler(this.btnClearMngID_Click);
            // 
            // employeeInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 343);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "employeeInputForm";
            this.Text = "Employee Input";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errFirstname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errBirthday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errHireday)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtMngID;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.MaskedTextBox mtPostalCode;
        private System.Windows.Forms.MaskedTextBox mtPhone;
        private System.Windows.Forms.ComboBox cbbCourtecy;
        private System.Windows.Forms.ComboBox cbbCountry;
        private System.Windows.Forms.DateTimePicker dpkBirthday;
        private System.Windows.Forms.DateTimePicker dpkHireDate;
        private System.Windows.Forms.ErrorProvider errLastName;
        private System.Windows.Forms.ErrorProvider errFirstname;
        private System.Windows.Forms.ErrorProvider errTitle;
        private System.Windows.Forms.ErrorProvider errPhone;
        private System.Windows.Forms.ErrorProvider errAddress;
        private System.Windows.Forms.ErrorProvider errCity;
        private System.Windows.Forms.ErrorProvider errBirthday;
        private System.Windows.Forms.ErrorProvider errHireday;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Button btnClearMngID;
    }
}