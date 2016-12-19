namespace ShopManagement
{
    partial class frmOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            this.dgOrder = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dtpShipDate = new System.Windows.Forms.DateTimePicker();
            this.dtpRequireDate = new System.Windows.Forms.DateTimePicker();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtShipRegion = new System.Windows.Forms.TextBox();
            this.txtShipCity = new System.Windows.Forms.TextBox();
            this.txtShipAddress = new System.Windows.Forms.TextBox();
            this.txtShipName = new System.Windows.Forms.TextBox();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.txtShipperID = new System.Windows.Forms.TextBox();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.frmDetail = new System.Windows.Forms.Panel();
            this.ckNotShip = new System.Windows.Forms.CheckBox();
            this.btnSearchShipID = new System.Windows.Forms.Button();
            this.btnSearchCusID = new System.Windows.Forms.Button();
            this.btnSearchEmpID = new System.Windows.Forms.Button();
            this.txtShipPostalCode = new System.Windows.Forms.MaskedTextBox();
            this.BtnOrderDetail = new System.Windows.Forms.Button();
            this.errorCusID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorEmpID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorOrderDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorRequireDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorShipDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorShipID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorFreight = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorShipName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorShipAdd = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorShipCity = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorShipRegion = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorShipPostalCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorShipCountry = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.cbxSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelDate = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.From = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.panel2Text = new System.Windows.Forms.Panel();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panelText = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panelName = new System.Windows.Forms.Panel();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.countryDataSet = new ShopManagement.CountryDataSet();
            this.countryDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countryDataSet1 = new ShopManagement.CountryDataSet1();
            this.countryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countryTableAdapter = new ShopManagement.CountryDataSet1TableAdapters.CountryTableAdapter();
            this.txtShipCountry = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrder)).BeginInit();
            this.frmDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorCusID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEmpID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorOrderDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRequireDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorFreight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipPostalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelDate.SuspendLayout();
            this.panel2Text.SuspendLayout();
            this.panelText.SuspendLayout();
            this.panelName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgOrder
            // 
            this.dgOrder.AllowUserToAddRows = false;
            this.dgOrder.AllowUserToDeleteRows = false;
            this.dgOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrder.Location = new System.Drawing.Point(28, 61);
            this.dgOrder.MultiSelect = false;
            this.dgOrder.Name = "dgOrder";
            this.dgOrder.ReadOnly = true;
            this.dgOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrder.Size = new System.Drawing.Size(829, 488);
            this.dgOrder.TabIndex = 0;
            this.dgOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOrder_CellClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1060, 490);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(1049, 114);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 20);
            this.dtpOrderDate.TabIndex = 63;
            // 
            // dtpShipDate
            // 
            this.dtpShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpShipDate.Location = new System.Drawing.Point(1049, 176);
            this.dtpShipDate.Name = "dtpShipDate";
            this.dtpShipDate.Size = new System.Drawing.Size(200, 20);
            this.dtpShipDate.TabIndex = 62;
            // 
            // dtpRequireDate
            // 
            this.dtpRequireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRequireDate.Location = new System.Drawing.Point(1049, 144);
            this.dtpRequireDate.Name = "dtpRequireDate";
            this.dtpRequireDate.Size = new System.Drawing.Size(200, 20);
            this.dtpRequireDate.TabIndex = 61;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1196, 490);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 60;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(918, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 59;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtShipRegion
            // 
            this.txtShipRegion.Location = new System.Drawing.Point(163, 369);
            this.txtShipRegion.Name = "txtShipRegion";
            this.txtShipRegion.Size = new System.Drawing.Size(100, 20);
            this.txtShipRegion.TabIndex = 57;
            // 
            // txtShipCity
            // 
            this.txtShipCity.Location = new System.Drawing.Point(163, 342);
            this.txtShipCity.Name = "txtShipCity";
            this.txtShipCity.Size = new System.Drawing.Size(100, 20);
            this.txtShipCity.TabIndex = 56;
            // 
            // txtShipAddress
            // 
            this.txtShipAddress.Location = new System.Drawing.Point(163, 309);
            this.txtShipAddress.Name = "txtShipAddress";
            this.txtShipAddress.Size = new System.Drawing.Size(100, 20);
            this.txtShipAddress.TabIndex = 55;
            // 
            // txtShipName
            // 
            this.txtShipName.Location = new System.Drawing.Point(163, 281);
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.Size = new System.Drawing.Size(100, 20);
            this.txtShipName.TabIndex = 54;
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(163, 248);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(100, 20);
            this.txtFreight.TabIndex = 53;
            this.txtFreight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFreight_KeyDown);
            // 
            // txtShipperID
            // 
            this.txtShipperID.Enabled = false;
            this.txtShipperID.Location = new System.Drawing.Point(163, 220);
            this.txtShipperID.Name = "txtShipperID";
            this.txtShipperID.Size = new System.Drawing.Size(100, 20);
            this.txtShipperID.TabIndex = 52;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Enabled = false;
            this.txtEmployeeID.Location = new System.Drawing.Point(1049, 80);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(100, 20);
            this.txtEmployeeID.TabIndex = 51;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Enabled = false;
            this.txtCustomerID.Location = new System.Drawing.Point(1049, 50);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(100, 20);
            this.txtCustomerID.TabIndex = 50;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Enabled = false;
            this.txtOrderID.Location = new System.Drawing.Point(1049, 20);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(100, 20);
            this.txtOrderID.TabIndex = 49;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 400);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "Ship Postal Code";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 312);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Ship Address";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(905, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Require Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(905, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Order Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(905, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Employee ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Freight";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Shipper ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 369);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Ship Region";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(905, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Shipped Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Ship Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Ship City";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(905, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Customer ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Ship Country";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(905, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Order ID";
            // 
            // frmDetail
            // 
            this.frmDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frmDetail.Controls.Add(this.txtShipCountry);
            this.frmDetail.Controls.Add(this.ckNotShip);
            this.frmDetail.Controls.Add(this.btnSearchShipID);
            this.frmDetail.Controls.Add(this.btnSearchCusID);
            this.frmDetail.Controls.Add(this.btnSearchEmpID);
            this.frmDetail.Controls.Add(this.txtShipPostalCode);
            this.frmDetail.Controls.Add(this.label14);
            this.frmDetail.Controls.Add(this.label4);
            this.frmDetail.Controls.Add(this.label5);
            this.frmDetail.Controls.Add(this.label7);
            this.frmDetail.Controls.Add(this.label8);
            this.frmDetail.Controls.Add(this.txtShipRegion);
            this.frmDetail.Controls.Add(this.label9);
            this.frmDetail.Controls.Add(this.txtShipCity);
            this.frmDetail.Controls.Add(this.label13);
            this.frmDetail.Controls.Add(this.label2);
            this.frmDetail.Controls.Add(this.txtShipAddress);
            this.frmDetail.Controls.Add(this.txtShipperID);
            this.frmDetail.Controls.Add(this.txtShipName);
            this.frmDetail.Controls.Add(this.txtFreight);
            this.frmDetail.Location = new System.Drawing.Point(885, 12);
            this.frmDetail.Name = "frmDetail";
            this.frmDetail.Size = new System.Drawing.Size(404, 472);
            this.frmDetail.TabIndex = 66;
            // 
            // ckNotShip
            // 
            this.ckNotShip.AutoSize = true;
            this.ckNotShip.Location = new System.Drawing.Point(163, 193);
            this.ckNotShip.Name = "ckNotShip";
            this.ckNotShip.Size = new System.Drawing.Size(67, 17);
            this.ckNotShip.TabIndex = 75;
            this.ckNotShip.Text = "Not Ship";
            this.ckNotShip.UseVisualStyleBackColor = true;
            this.ckNotShip.CheckStateChanged += new System.EventHandler(this.ckNotShip_CheckStateChanged);
            // 
            // btnSearchShipID
            // 
            this.btnSearchShipID.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchShipID.Image")));
            this.btnSearchShipID.Location = new System.Drawing.Point(269, 215);
            this.btnSearchShipID.Name = "btnSearchShipID";
            this.btnSearchShipID.Size = new System.Drawing.Size(27, 28);
            this.btnSearchShipID.TabIndex = 74;
            this.btnSearchShipID.UseVisualStyleBackColor = true;
            this.btnSearchShipID.Click += new System.EventHandler(this.btnSearchShipID_Click);
            // 
            // btnSearchCusID
            // 
            this.btnSearchCusID.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCusID.Image")));
            this.btnSearchCusID.Location = new System.Drawing.Point(269, 37);
            this.btnSearchCusID.Name = "btnSearchCusID";
            this.btnSearchCusID.Size = new System.Drawing.Size(27, 24);
            this.btnSearchCusID.TabIndex = 73;
            this.btnSearchCusID.UseVisualStyleBackColor = true;
            this.btnSearchCusID.Click += new System.EventHandler(this.btnSearchCusID_Click);
            // 
            // btnSearchEmpID
            // 
            this.btnSearchEmpID.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchEmpID.Image")));
            this.btnSearchEmpID.Location = new System.Drawing.Point(269, 67);
            this.btnSearchEmpID.Name = "btnSearchEmpID";
            this.btnSearchEmpID.Size = new System.Drawing.Size(27, 23);
            this.btnSearchEmpID.TabIndex = 72;
            this.btnSearchEmpID.UseVisualStyleBackColor = true;
            this.btnSearchEmpID.Click += new System.EventHandler(this.btnSearchEmpID_Click);
            // 
            // txtShipPostalCode
            // 
            this.txtShipPostalCode.Location = new System.Drawing.Point(163, 397);
            this.txtShipPostalCode.Mask = "099";
            this.txtShipPostalCode.Name = "txtShipPostalCode";
            this.txtShipPostalCode.Size = new System.Drawing.Size(100, 20);
            this.txtShipPostalCode.TabIndex = 64;
            // 
            // BtnOrderDetail
            // 
            this.BtnOrderDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrderDetail.Location = new System.Drawing.Point(1029, 528);
            this.BtnOrderDetail.Name = "BtnOrderDetail";
            this.BtnOrderDetail.Size = new System.Drawing.Size(135, 26);
            this.BtnOrderDetail.TabIndex = 72;
            this.BtnOrderDetail.Text = "Order Detail";
            this.BtnOrderDetail.UseVisualStyleBackColor = true;
            this.BtnOrderDetail.Click += new System.EventHandler(this.BtnOrderDetail_Click);
            // 
            // errorCusID
            // 
            this.errorCusID.ContainerControl = this;
            // 
            // errorEmpID
            // 
            this.errorEmpID.ContainerControl = this;
            // 
            // errorOrderDate
            // 
            this.errorOrderDate.ContainerControl = this;
            // 
            // errorRequireDate
            // 
            this.errorRequireDate.ContainerControl = this;
            // 
            // errorShipDate
            // 
            this.errorShipDate.ContainerControl = this;
            // 
            // errorShipID
            // 
            this.errorShipID.ContainerControl = this;
            // 
            // errorFreight
            // 
            this.errorFreight.ContainerControl = this;
            // 
            // errorShipName
            // 
            this.errorShipName.ContainerControl = this;
            // 
            // errorShipAdd
            // 
            this.errorShipAdd.ContainerControl = this;
            // 
            // errorShipCity
            // 
            this.errorShipCity.ContainerControl = this;
            // 
            // errorShipRegion
            // 
            this.errorShipRegion.ContainerControl = this;
            // 
            // errorShipPostalCode
            // 
            this.errorShipPostalCode.ContainerControl = this;
            // 
            // errorShipCountry
            // 
            this.errorShipCountry.ContainerControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(42, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 17);
            this.label15.TabIndex = 67;
            this.label15.Text = "Search";
            // 
            // cbxSearch
            // 
            this.cbxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearch.FormattingEnabled = true;
            this.cbxSearch.Items.AddRange(new object[] {
            "Customer ID",
            "Order Date",
            "Require Date",
            "Ship Date",
            "Product Name (Order Detail)",
            "Total Value"});
            this.cbxSearch.Location = new System.Drawing.Point(101, 17);
            this.cbxSearch.Name = "cbxSearch";
            this.cbxSearch.Size = new System.Drawing.Size(95, 21);
            this.cbxSearch.TabIndex = 69;
            this.cbxSearch.SelectedValueChanged += new System.EventHandler(this.cbxSearch_SelectedValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(532, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 70;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(651, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 28);
            this.btnClear.TabIndex = 71;
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.label16);
            this.panelDate.Controls.Add(this.From);
            this.panelDate.Controls.Add(this.dtpTo);
            this.panelDate.Controls.Add(this.dtpFrom);
            this.panelDate.Location = new System.Drawing.Point(202, 3);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(303, 52);
            this.panelDate.TabIndex = 73;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(162, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 20);
            this.label16.TabIndex = 3;
            this.label16.Text = "To";
            // 
            // From
            // 
            this.From.AutoSize = true;
            this.From.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.From.Location = new System.Drawing.Point(-1, 17);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(46, 20);
            this.From.TabIndex = 2;
            this.From.Text = "From";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(195, 16);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(105, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(45, 16);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 0;
            // 
            // panel2Text
            // 
            this.panel2Text.Controls.Add(this.txtFrom);
            this.panel2Text.Controls.Add(this.txtTo);
            this.panel2Text.Controls.Add(this.label17);
            this.panel2Text.Controls.Add(this.label18);
            this.panel2Text.Location = new System.Drawing.Point(202, 3);
            this.panel2Text.Name = "panel2Text";
            this.panel2Text.Size = new System.Drawing.Size(303, 52);
            this.panel2Text.TabIndex = 74;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(45, 17);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 20);
            this.txtFrom.TabIndex = 75;
            this.txtFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFrom_KeyDown);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(195, 17);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 4;
            this.txtTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTo_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(162, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 20);
            this.label17.TabIndex = 3;
            this.label17.Text = "To";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(-1, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 20);
            this.label18.TabIndex = 2;
            this.label18.Text = "From";
            // 
            // panelText
            // 
            this.panelText.Controls.Add(this.txtSearch);
            this.panelText.Location = new System.Drawing.Point(234, 1);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(200, 55);
            this.panelText.TabIndex = 76;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(23, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // panelName
            // 
            this.panelName.Controls.Add(this.txtSearchName);
            this.panelName.Location = new System.Drawing.Point(237, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(200, 55);
            this.panelName.TabIndex = 77;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(23, 17);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(100, 20);
            this.txtSearchName.TabIndex = 0;
            // 
            // countryDataSet
            // 
            this.countryDataSet.DataSetName = "CountryDataSet";
            this.countryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // countryDataSetBindingSource
            // 
            this.countryDataSetBindingSource.DataSource = this.countryDataSet;
            this.countryDataSetBindingSource.Position = 0;
            // 
            // countryDataSet1
            // 
            this.countryDataSet1.DataSetName = "CountryDataSet1";
            this.countryDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // countryBindingSource
            // 
            this.countryBindingSource.DataMember = "Country";
            this.countryBindingSource.DataSource = this.countryDataSet1;
            // 
            // countryTableAdapter
            // 
            this.countryTableAdapter.ClearBeforeFill = true;
            // 
            // txtShipCountry
            // 
            this.txtShipCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtShipCountry.FormattingEnabled = true;
            this.txtShipCountry.Location = new System.Drawing.Point(163, 431);
            this.txtShipCountry.Name = "txtShipCountry";
            this.txtShipCountry.Size = new System.Drawing.Size(115, 21);
            this.txtShipCountry.TabIndex = 77;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 566);
            this.Controls.Add(this.panelName);
            this.Controls.Add(this.BtnOrderDetail);
            this.Controls.Add(this.panelText);
            this.Controls.Add(this.panel2Text);
            this.Controls.Add(this.panelDate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cbxSearch);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.dtpShipDate);
            this.Controls.Add(this.dtpRequireDate);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgOrder);
            this.Controls.Add(this.frmDetail);
            this.Name = "frmOrder";
            this.Text = "Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrder_FormClosing);
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrder)).EndInit();
            this.frmDetail.ResumeLayout(false);
            this.frmDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorCusID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEmpID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorOrderDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRequireDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorFreight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipPostalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorShipCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.panel2Text.ResumeLayout(false);
            this.panel2Text.PerformLayout();
            this.panelText.ResumeLayout(false);
            this.panelText.PerformLayout();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgOrder;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.DateTimePicker dtpShipDate;
        private System.Windows.Forms.DateTimePicker dtpRequireDate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtShipRegion;
        private System.Windows.Forms.TextBox txtShipCity;
        private System.Windows.Forms.TextBox txtShipAddress;
        private System.Windows.Forms.TextBox txtShipName;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.TextBox txtShipperID;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel frmDetail;
        private System.Windows.Forms.ErrorProvider errorCusID;
        private System.Windows.Forms.ErrorProvider errorEmpID;
        private System.Windows.Forms.ErrorProvider errorOrderDate;
        private System.Windows.Forms.ErrorProvider errorRequireDate;
        private System.Windows.Forms.ErrorProvider errorShipDate;
        private System.Windows.Forms.ErrorProvider errorShipID;
        private System.Windows.Forms.ErrorProvider errorFreight;
        private System.Windows.Forms.ErrorProvider errorShipName;
        private System.Windows.Forms.ErrorProvider errorShipAdd;
        private System.Windows.Forms.ErrorProvider errorShipCity;
        private System.Windows.Forms.ErrorProvider errorShipRegion;
        private System.Windows.Forms.ErrorProvider errorShipPostalCode;
        private System.Windows.Forms.ErrorProvider errorShipCountry;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbxSearch;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.MaskedTextBox txtShipPostalCode;
        private System.Windows.Forms.Button btnSearchShipID;
        private System.Windows.Forms.Button btnSearchCusID;
        private System.Windows.Forms.Button btnSearchEmpID;
        private System.Windows.Forms.Button BtnOrderDetail;
        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label From;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Panel panel2Text;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox ckNotShip;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.BindingSource countryDataSetBindingSource;
        private CountryDataSet countryDataSet;
        private CountryDataSet1 countryDataSet1;
        private System.Windows.Forms.BindingSource countryBindingSource;
        private CountryDataSet1TableAdapters.CountryTableAdapter countryTableAdapter;
        private System.Windows.Forms.ComboBox txtShipCountry;
    }
}

