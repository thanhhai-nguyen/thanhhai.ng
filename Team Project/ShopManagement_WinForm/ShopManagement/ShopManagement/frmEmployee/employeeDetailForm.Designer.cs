namespace ShopManagement
{
    partial class employeeDetailForm
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
            this.dgEmployees = new System.Windows.Forms.DataGridView();
            this.emID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courtesy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mgrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbbSearchBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dtpFROM = new System.Windows.Forms.DateTimePicker();
            this.dtpTO = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbName = new System.Windows.Forms.GroupBox();
            this.gbDOB = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployees)).BeginInit();
            this.gbName.SuspendLayout();
            this.gbDOB.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgEmployees
            // 
            this.dgEmployees.AllowUserToAddRows = false;
            this.dgEmployees.AllowUserToDeleteRows = false;
            this.dgEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emID,
            this.lastname,
            this.firstname,
            this.Title,
            this.courtesy,
            this.birthday,
            this.hireDate,
            this.address,
            this.City,
            this.region,
            this.postalCode,
            this.country,
            this.phone,
            this.mgrid});
            this.dgEmployees.Location = new System.Drawing.Point(43, 78);
            this.dgEmployees.Name = "dgEmployees";
            this.dgEmployees.ReadOnly = true;
            this.dgEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEmployees.Size = new System.Drawing.Size(1255, 380);
            this.dgEmployees.TabIndex = 0;
            // 
            // emID
            // 
            this.emID.HeaderText = "ID";
            this.emID.Name = "emID";
            this.emID.ReadOnly = true;
            // 
            // lastname
            // 
            this.lastname.HeaderText = "Last Name";
            this.lastname.Name = "lastname";
            this.lastname.ReadOnly = true;
            // 
            // firstname
            // 
            this.firstname.HeaderText = "First Name";
            this.firstname.Name = "firstname";
            this.firstname.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // courtesy
            // 
            this.courtesy.HeaderText = "Courtesy";
            this.courtesy.Name = "courtesy";
            this.courtesy.ReadOnly = true;
            // 
            // birthday
            // 
            this.birthday.HeaderText = "Birthday";
            this.birthday.Name = "birthday";
            this.birthday.ReadOnly = true;
            // 
            // hireDate
            // 
            this.hireDate.HeaderText = "Hire Date";
            this.hireDate.Name = "hireDate";
            this.hireDate.ReadOnly = true;
            // 
            // address
            // 
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // City
            // 
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            // 
            // region
            // 
            this.region.HeaderText = "Region";
            this.region.Name = "region";
            this.region.ReadOnly = true;
            // 
            // postalCode
            // 
            this.postalCode.HeaderText = "Postal Code";
            this.postalCode.Name = "postalCode";
            this.postalCode.ReadOnly = true;
            // 
            // country
            // 
            this.country.HeaderText = "Country";
            this.country.Name = "country";
            this.country.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.HeaderText = "Phone";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // mgrid
            // 
            this.mgrid.HeaderText = "Manager ID";
            this.mgrid.Name = "mgrid";
            this.mgrid.ReadOnly = true;
            // 
            // bnNew
            // 
            this.bnNew.Location = new System.Drawing.Point(43, 480);
            this.bnNew.Name = "bnNew";
            this.bnNew.Size = new System.Drawing.Size(93, 21);
            this.bnNew.TabIndex = 1;
            this.bnNew.Text = "Create";
            this.bnNew.UseVisualStyleBackColor = true;
            this.bnNew.Click += new System.EventHandler(this.bnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(161, 479);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(96, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(284, 480);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(6, 12);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(177, 20);
            this.txtSearchValue.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(609, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 25);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbbSearchBy
            // 
            this.cbbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchBy.FormattingEnabled = true;
            this.cbbSearchBy.Items.AddRange(new object[] {
            "Last name",
            "First name",
            "Date of Birth"});
            this.cbbSearchBy.Location = new System.Drawing.Point(106, 27);
            this.cbbSearchBy.Name = "cbbSearchBy";
            this.cbbSearchBy.Size = new System.Drawing.Size(93, 21);
            this.cbbSearchBy.TabIndex = 7;
            this.cbbSearchBy.SelectedIndexChanged += new System.EventHandler(this.cbbSearchBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search by";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(747, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 26);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dtpFROM
            // 
            this.dtpFROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFROM.Location = new System.Drawing.Point(80, 16);
            this.dtpFROM.Name = "dtpFROM";
            this.dtpFROM.Size = new System.Drawing.Size(103, 20);
            this.dtpFROM.TabIndex = 10;
            // 
            // dtpTO
            // 
            this.dtpTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTO.Location = new System.Drawing.Point(211, 16);
            this.dtpTO.Name = "dtpTO";
            this.dtpTO.Size = new System.Drawing.Size(102, 20);
            this.dtpTO.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Birthday from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "to";
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.txtSearchValue);
            this.gbName.Location = new System.Drawing.Point(237, 12);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(193, 37);
            this.gbName.TabIndex = 15;
            this.gbName.TabStop = false;
            this.gbName.Text = "Search by Name";
            // 
            // gbDOB
            // 
            this.gbDOB.Controls.Add(this.label2);
            this.gbDOB.Controls.Add(this.dtpFROM);
            this.gbDOB.Controls.Add(this.label3);
            this.gbDOB.Controls.Add(this.dtpTO);
            this.gbDOB.Location = new System.Drawing.Point(237, 12);
            this.gbDOB.Name = "gbDOB";
            this.gbDOB.Size = new System.Drawing.Size(335, 47);
            this.gbDOB.TabIndex = 16;
            this.gbDOB.TabStop = false;
            this.gbDOB.Text = "Search by DOB";
            // 
            // employeeDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 523);
            this.Controls.Add(this.gbDOB);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.gbName);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbSearchBy);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.bnNew);
            this.Controls.Add(this.dgEmployees);
            this.Name = "employeeDetailForm";
            this.Text = "Employee Detail";
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployees)).EndInit();
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.gbDOB.ResumeLayout(false);
            this.gbDOB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn emID;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn courtesy;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn hireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn region;
        private System.Windows.Forms.DataGridViewTextBoxColumn postalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn mgrid;
        private System.Windows.Forms.Button bnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbbSearchBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dtpFROM;
        private System.Windows.Forms.DateTimePicker dtpTO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.GroupBox gbDOB;
    }
}

