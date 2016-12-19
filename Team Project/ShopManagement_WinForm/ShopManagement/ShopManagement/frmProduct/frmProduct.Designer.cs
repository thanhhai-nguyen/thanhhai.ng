namespace ShopManagement
{
    partial class frmProduct
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgProducts = new System.Windows.Forms.DataGridView();
            this.cbbSearchType = new System.Windows.Forms.ComboBox();
            this.txtSearchValue2 = new System.Windows.Forms.TextBox();
            this.lblToMoney = new System.Windows.Forms.Label();
            this.errSearch1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errSearch2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChooseCategory = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnChooseSupplier = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chkDiscontinued = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errProductName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errSupplierID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errCategoryID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errUnitPrice = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSearch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSearch2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProductName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSupplierID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCategoryID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errUnitPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1022, 443);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(377, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(57, 23);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(310, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 23);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(164, 24);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(124, 20);
            this.txtSearchValue.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Search";
            // 
            // dgProducts
            // 
            this.dgProducts.AllowUserToAddRows = false;
            this.dgProducts.AllowUserToDeleteRows = false;
            this.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Location = new System.Drawing.Point(29, 98);
            this.dgProducts.MultiSelect = false;
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.ReadOnly = true;
            this.dgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProducts.Size = new System.Drawing.Size(860, 406);
            this.dgProducts.TabIndex = 18;
            this.dgProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProducts_CellClick);
            // 
            // cbbSearchType
            // 
            this.cbbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchType.FormattingEnabled = true;
            this.cbbSearchType.Items.AddRange(new object[] {
            "Name",
            "Unit price",
            "Supplier Name",
            "Category Name"});
            this.cbbSearchType.Location = new System.Drawing.Point(65, 24);
            this.cbbSearchType.Name = "cbbSearchType";
            this.cbbSearchType.Size = new System.Drawing.Size(93, 21);
            this.cbbSearchType.TabIndex = 26;
            this.cbbSearchType.SelectedIndexChanged += new System.EventHandler(this.cbbSearchType_SelectedIndexChanged);
            // 
            // txtSearchValue2
            // 
            this.txtSearchValue2.Location = new System.Drawing.Point(164, 50);
            this.txtSearchValue2.Name = "txtSearchValue2";
            this.txtSearchValue2.Size = new System.Drawing.Size(123, 20);
            this.txtSearchValue2.TabIndex = 27;
            this.txtSearchValue2.Visible = false;
            // 
            // lblToMoney
            // 
            this.lblToMoney.AutoSize = true;
            this.lblToMoney.Location = new System.Drawing.Point(138, 53);
            this.lblToMoney.Name = "lblToMoney";
            this.lblToMoney.Size = new System.Drawing.Size(20, 13);
            this.lblToMoney.TabIndex = 28;
            this.lblToMoney.Text = "To";
            this.lblToMoney.Visible = false;
            // 
            // errSearch1
            // 
            this.errSearch1.ContainerControl = this;
            // 
            // errSearch2
            // 
            this.errSearch2.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnChooseCategory);
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Controls.Add(this.btnChooseSupplier);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.chkDiscontinued);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUnitPrice);
            this.panel1.Controls.Add(this.txtProductID);
            this.panel1.Controls.Add(this.txtCategoryID);
            this.panel1.Controls.Add(this.txtSupplierID);
            this.panel1.Location = new System.Drawing.Point(913, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 320);
            this.panel1.TabIndex = 29;
            // 
            // btnChooseCategory
            // 
            this.btnChooseCategory.Image = global::ShopManagement.Properties.Resources.search_loop_512;
            this.btnChooseCategory.Location = new System.Drawing.Point(189, 160);
            this.btnChooseCategory.Name = "btnChooseCategory";
            this.btnChooseCategory.Size = new System.Drawing.Size(32, 23);
            this.btnChooseCategory.TabIndex = 45;
            this.btnChooseCategory.Text = " ";
            this.btnChooseCategory.UseVisualStyleBackColor = true;
            this.btnChooseCategory.Click += new System.EventHandler(this.btnChooseCategory_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(105, 69);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(153, 20);
            this.txtProductName.TabIndex = 36;
            // 
            // btnChooseSupplier
            // 
            this.btnChooseSupplier.Image = global::ShopManagement.Properties.Resources.search_loop_512;
            this.btnChooseSupplier.Location = new System.Drawing.Point(189, 113);
            this.btnChooseSupplier.Name = "btnChooseSupplier";
            this.btnChooseSupplier.Size = new System.Drawing.Size(32, 23);
            this.btnChooseSupplier.TabIndex = 44;
            this.btnChooseSupplier.Text = " ";
            this.btnChooseSupplier.UseVisualStyleBackColor = true;
            this.btnChooseSupplier.Click += new System.EventHandler(this.btnChooseSupplier_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Product ID";
            // 
            // chkDiscontinued
            // 
            this.chkDiscontinued.AutoSize = true;
            this.chkDiscontinued.Location = new System.Drawing.Point(105, 251);
            this.chkDiscontinued.Name = "chkDiscontinued";
            this.chkDiscontinued.Size = new System.Drawing.Size(88, 17);
            this.chkDiscontinued.TabIndex = 43;
            this.chkDiscontinued.Text = "Discontinued";
            this.chkDiscontinued.UseVisualStyleBackColor = true;
            this.chkDiscontinued.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Product Name";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 252);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 42;
            this.lblStatus.Text = "Status";
            this.lblStatus.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "SupplierID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "CategoryID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Unit price";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(105, 206);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(153, 20);
            this.txtUnitPrice.TabIndex = 39;
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(105, 27);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(78, 20);
            this.txtProductID.TabIndex = 35;
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.Location = new System.Drawing.Point(105, 162);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.ReadOnly = true;
            this.txtCategoryID.Size = new System.Drawing.Size(78, 20);
            this.txtCategoryID.TabIndex = 38;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(105, 115);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(78, 20);
            this.txtSupplierID.TabIndex = 37;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1129, 443);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 41;
            this.btnClear.Text = "Reset";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(916, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errProductName
            // 
            this.errProductName.ContainerControl = this;
            // 
            // errSupplierID
            // 
            this.errSupplierID.ContainerControl = this;
            // 
            // errCategoryID
            // 
            this.errCategoryID.ContainerControl = this;
            // 
            // errUnitPrice
            // 
            this.errUnitPrice.ContainerControl = this;
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 530);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblToMoney);
            this.Controls.Add(this.txtSearchValue2);
            this.Controls.Add(this.cbbSearchType);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchValue);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgProducts);
            this.Name = "frmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product List";
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSearch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSearch2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProductName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSupplierID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCategoryID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errUnitPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgProducts;
        private System.Windows.Forms.ComboBox cbbSearchType;
        private System.Windows.Forms.TextBox txtSearchValue2;
        private System.Windows.Forms.Label lblToMoney;
        private System.Windows.Forms.ErrorProvider errSearch1;
        private System.Windows.Forms.ErrorProvider errSearch2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChooseCategory;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnChooseSupplier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkDiscontinued;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.ErrorProvider errProductName;
        private System.Windows.Forms.ErrorProvider errSupplierID;
        private System.Windows.Forms.ErrorProvider errCategoryID;
        private System.Windows.Forms.ErrorProvider errUnitPrice;
    }
}