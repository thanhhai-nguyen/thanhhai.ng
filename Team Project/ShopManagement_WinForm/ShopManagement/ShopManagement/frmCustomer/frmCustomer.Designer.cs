namespace ShopManagement
{
    partial class frmCustomer
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
            this.dgCustomer = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContTitle = new System.Windows.Forms.TextBox();
            this.txtContName = new System.Windows.Forms.TextBox();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.lbPostCode = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbContTitile = new System.Windows.Forms.Label();
            this.lbContName = new System.Windows.Forms.Label();
            this.lbRegion = new System.Windows.Forms.Label();
            this.lbCity = new System.Windows.Forms.Label();
            this.lbCaomName = new System.Windows.Forms.Label();
            this.lbCountry = new System.Windows.Forms.Label();
            this.lbCustID = new System.Windows.Forms.Label();
            this.frmDetail = new System.Windows.Forms.Panel();
            this.txtCustID = new System.Windows.Forms.TextBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.lbFax = new System.Windows.Forms.Label();
            this.mtxtPostalCode = new System.Windows.Forms.MaskedTextBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbxSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.erCompName = new System.Windows.Forms.ErrorProvider(this.components);
            this.erContName = new System.Windows.Forms.ErrorProvider(this.components);
            this.erContTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.erAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.erCity = new System.Windows.Forms.ErrorProvider(this.components);
            this.erRegion = new System.Windows.Forms.ErrorProvider(this.components);
            this.erPostalCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.erCountry = new System.Windows.Forms.ErrorProvider(this.components);
            this.erPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.erFax = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).BeginInit();
            this.frmDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erCompName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erContName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erContTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erPostalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erFax)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCustomer
            // 
            this.dgCustomer.AllowUserToAddRows = false;
            this.dgCustomer.AllowUserToDeleteRows = false;
            this.dgCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomer.Location = new System.Drawing.Point(23, 56);
            this.dgCustomer.MultiSelect = false;
            this.dgCustomer.Name = "dgCustomer";
            this.dgCustomer.ReadOnly = true;
            this.dgCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCustomer.Size = new System.Drawing.Size(788, 481);
            this.dgCustomer.TabIndex = 0;
            this.dgCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCustomer_CellClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1015, 507);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // mtxtPhone
            // 
            this.mtxtPhone.Location = new System.Drawing.Point(160, 340);
            this.mtxtPhone.Mask = "+(000)0000 0000";
            this.mtxtPhone.Name = "mtxtPhone";
            this.mtxtPhone.Size = new System.Drawing.Size(100, 20);
            this.mtxtPhone.TabIndex = 64;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1138, 507);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 60;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(881, 507);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 59;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(160, 377);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(100, 20);
            this.txtFax.TabIndex = 58;
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(160, 219);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(100, 20);
            this.txtRegion.TabIndex = 55;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(160, 180);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 54;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(160, 148);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 20);
            this.txtAddress.TabIndex = 53;
            // 
            // txtContTitle
            // 
            this.txtContTitle.Location = new System.Drawing.Point(160, 110);
            this.txtContTitle.Name = "txtContTitle";
            this.txtContTitle.Size = new System.Drawing.Size(100, 20);
            this.txtContTitle.TabIndex = 52;
            // 
            // txtContName
            // 
            this.txtContName.Location = new System.Drawing.Point(160, 77);
            this.txtContName.Name = "txtContName";
            this.txtContName.Size = new System.Drawing.Size(100, 20);
            this.txtContName.TabIndex = 51;
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(160, 47);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(100, 20);
            this.txtCompName.TabIndex = 50;
            // 
            // lbPostCode
            // 
            this.lbPostCode.AutoSize = true;
            this.lbPostCode.Location = new System.Drawing.Point(26, 261);
            this.lbPostCode.Name = "lbPostCode";
            this.lbPostCode.Size = new System.Drawing.Size(64, 13);
            this.lbPostCode.TabIndex = 48;
            this.lbPostCode.Text = "Postal Code";
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(26, 155);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(45, 13);
            this.lbAddress.TabIndex = 47;
            this.lbAddress.Text = "Address";
            // 
            // lbContTitile
            // 
            this.lbContTitile.AutoSize = true;
            this.lbContTitile.Location = new System.Drawing.Point(26, 117);
            this.lbContTitile.Name = "lbContTitile";
            this.lbContTitile.Size = new System.Drawing.Size(69, 13);
            this.lbContTitile.TabIndex = 45;
            this.lbContTitile.Text = "Contact Titile";
            // 
            // lbContName
            // 
            this.lbContName.AutoSize = true;
            this.lbContName.Location = new System.Drawing.Point(26, 84);
            this.lbContName.Name = "lbContName";
            this.lbContName.Size = new System.Drawing.Size(75, 13);
            this.lbContName.TabIndex = 44;
            this.lbContName.Text = "Contact Name";
            // 
            // lbRegion
            // 
            this.lbRegion.AutoSize = true;
            this.lbRegion.Location = new System.Drawing.Point(26, 226);
            this.lbRegion.Name = "lbRegion";
            this.lbRegion.Size = new System.Drawing.Size(41, 13);
            this.lbRegion.TabIndex = 41;
            this.lbRegion.Text = "Region";
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Location = new System.Drawing.Point(26, 187);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(24, 13);
            this.lbCity.TabIndex = 38;
            this.lbCity.Text = "City";
            // 
            // lbCaomName
            // 
            this.lbCaomName.AutoSize = true;
            this.lbCaomName.Location = new System.Drawing.Point(26, 54);
            this.lbCaomName.Name = "lbCaomName";
            this.lbCaomName.Size = new System.Drawing.Size(82, 13);
            this.lbCaomName.TabIndex = 37;
            this.lbCaomName.Text = "Company Name";
            // 
            // lbCountry
            // 
            this.lbCountry.AutoSize = true;
            this.lbCountry.Location = new System.Drawing.Point(26, 303);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(43, 13);
            this.lbCountry.TabIndex = 36;
            this.lbCountry.Text = "Country";
            // 
            // lbCustID
            // 
            this.lbCustID.AutoSize = true;
            this.lbCustID.Location = new System.Drawing.Point(26, 23);
            this.lbCustID.Name = "lbCustID";
            this.lbCustID.Size = new System.Drawing.Size(65, 13);
            this.lbCustID.TabIndex = 35;
            this.lbCustID.Text = "Customer ID";
            // 
            // frmDetail
            // 
            this.frmDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frmDetail.Controls.Add(this.txtCustID);
            this.frmDetail.Controls.Add(this.cbCountry);
            this.frmDetail.Controls.Add(this.txtContName);
            this.frmDetail.Controls.Add(this.lbAddress);
            this.frmDetail.Controls.Add(this.txtCompName);
            this.frmDetail.Controls.Add(this.lbCity);
            this.frmDetail.Controls.Add(this.lbRegion);
            this.frmDetail.Controls.Add(this.lbPostCode);
            this.frmDetail.Controls.Add(this.lbFax);
            this.frmDetail.Controls.Add(this.txtFax);
            this.frmDetail.Controls.Add(this.mtxtPostalCode);
            this.frmDetail.Controls.Add(this.mtxtPhone);
            this.frmDetail.Controls.Add(this.lbPhone);
            this.frmDetail.Controls.Add(this.lbCountry);
            this.frmDetail.Controls.Add(this.txtContTitle);
            this.frmDetail.Controls.Add(this.txtAddress);
            this.frmDetail.Controls.Add(this.txtRegion);
            this.frmDetail.Controls.Add(this.txtCity);
            this.frmDetail.Controls.Add(this.lbContTitile);
            this.frmDetail.Controls.Add(this.lbContName);
            this.frmDetail.Controls.Add(this.lbCaomName);
            this.frmDetail.Controls.Add(this.lbCustID);
            this.frmDetail.Location = new System.Drawing.Point(851, 56);
            this.frmDetail.Name = "frmDetail";
            this.frmDetail.Size = new System.Drawing.Size(388, 424);
            this.frmDetail.TabIndex = 66;
            // 
            // txtCustID
            // 
            this.txtCustID.Location = new System.Drawing.Point(160, 16);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.ReadOnly = true;
            this.txtCustID.Size = new System.Drawing.Size(100, 20);
            this.txtCustID.TabIndex = 66;
            // 
            // cbCountry
            // 
            this.cbCountry.AutoCompleteCustomSource.AddRange(new string[] {
            "Argentina",
            "Austria",
            "Belgium",
            "Brazil",
            "Canada",
            "Denmark",
            "Finland",
            "France",
            "Germany",
            "Italy",
            "Mexico",
            "Portugal",
            "Spain",
            "Sweden",
            "Switzerland",
            "UK",
            "Venezuela"});
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Items.AddRange(new object[] {
            "",
            "Argentina",
            "Austria",
            "Belgium",
            "Brazil",
            "Canada",
            "Denmark",
            "Finland",
            "France",
            "Germany",
            "Italy",
            "Mexico",
            "Portugal",
            "Spain",
            "Sweden",
            "Switzerland",
            "UK",
            "Venezuela"});
            this.cbCountry.Location = new System.Drawing.Point(160, 300);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(121, 21);
            this.cbCountry.Sorted = true;
            this.cbCountry.TabIndex = 65;
            // 
            // lbFax
            // 
            this.lbFax.AutoSize = true;
            this.lbFax.Location = new System.Drawing.Point(26, 380);
            this.lbFax.Name = "lbFax";
            this.lbFax.Size = new System.Drawing.Size(24, 13);
            this.lbFax.TabIndex = 36;
            this.lbFax.Text = "Fax";
            // 
            // mtxtPostalCode
            // 
            this.mtxtPostalCode.Location = new System.Drawing.Point(160, 261);
            this.mtxtPostalCode.Mask = "00000";
            this.mtxtPostalCode.Name = "mtxtPostalCode";
            this.mtxtPostalCode.Size = new System.Drawing.Size(100, 20);
            this.mtxtPostalCode.TabIndex = 64;
            this.mtxtPostalCode.ValidatingType = typeof(int);
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(26, 343);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(38, 13);
            this.lbPhone.TabIndex = 36;
            this.lbPhone.Text = "Phone";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(42, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 17);
            this.label15.TabIndex = 67;
            this.label15.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(231, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(139, 20);
            this.txtSearch.TabIndex = 68;
            // 
            // cbxSearch
            // 
            this.cbxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearch.FormattingEnabled = true;
            this.cbxSearch.Items.AddRange(new object[] {
            "by Company Name",
            "by Contact Name",
            "by Country"});
            this.cbxSearch.Location = new System.Drawing.Point(101, 21);
            this.cbxSearch.Name = "cbxSearch";
            this.cbxSearch.Size = new System.Drawing.Size(124, 21);
            this.cbxSearch.TabIndex = 69;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(417, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 70;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClear.Location = new System.Drawing.Point(535, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 71;
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // erCompName
            // 
            this.erCompName.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erCompName.ContainerControl = this;
            // 
            // erContName
            // 
            this.erContName.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erContName.ContainerControl = this;
            // 
            // erContTitle
            // 
            this.erContTitle.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erContTitle.ContainerControl = this;
            // 
            // erAddress
            // 
            this.erAddress.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erAddress.ContainerControl = this;
            // 
            // erCity
            // 
            this.erCity.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erCity.ContainerControl = this;
            // 
            // erRegion
            // 
            this.erRegion.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erRegion.ContainerControl = this;
            // 
            // erPostalCode
            // 
            this.erPostalCode.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erPostalCode.ContainerControl = this;
            // 
            // erCountry
            // 
            this.erCountry.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erCountry.ContainerControl = this;
            // 
            // erPhone
            // 
            this.erPhone.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erPhone.ContainerControl = this;
            // 
            // erFax
            // 
            this.erFax.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erFax.ContainerControl = this;
            // 
            // frmCustomer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 549);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dgCustomer);
            this.Controls.Add(this.frmDetail);
            this.Name = "frmCustomer";
            this.Text = "Customer";
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomer)).EndInit();
            this.frmDetail.ResumeLayout(false);
            this.frmDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erCompName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erContName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erContTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erPostalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erFax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCustomer;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.MaskedTextBox mtxtPhone;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContTitle;
        private System.Windows.Forms.TextBox txtContName;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.Label lbPostCode;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbContTitile;
        private System.Windows.Forms.Label lbContName;
        private System.Windows.Forms.Label lbRegion;
        private System.Windows.Forms.Label lbCity;
        private System.Windows.Forms.Label lbCaomName;
        private System.Windows.Forms.Label lbCountry;
        private System.Windows.Forms.Label lbCustID;
        private System.Windows.Forms.Panel frmDetail;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lbFax;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.MaskedTextBox mtxtPostalCode;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.TextBox txtCustID;
        private System.Windows.Forms.ErrorProvider erCompName;
        private System.Windows.Forms.ErrorProvider erContName;
        private System.Windows.Forms.ErrorProvider erContTitle;
        private System.Windows.Forms.ErrorProvider erAddress;
        private System.Windows.Forms.ErrorProvider erCity;
        private System.Windows.Forms.ErrorProvider erRegion;
        private System.Windows.Forms.ErrorProvider erPostalCode;
        private System.Windows.Forms.ErrorProvider erCountry;
        private System.Windows.Forms.ErrorProvider erPhone;
        private System.Windows.Forms.ErrorProvider erFax;
    }
}

