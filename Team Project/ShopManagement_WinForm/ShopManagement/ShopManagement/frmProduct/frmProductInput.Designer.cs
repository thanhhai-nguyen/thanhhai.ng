namespace ShopManagement
{
    partial class frmProductInput
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.txtSupplierID = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkDiscontinued = new System.Windows.Forms.CheckBox();
            this.btnChooseCategory = new System.Windows.Forms.Button();
            this.btnChooseSupplier = new System.Windows.Forms.Button();
            this.errProductName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errSupplierID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errCategoryID = new System.Windows.Forms.ErrorProvider(this.components);
            this.errUnitPrice = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errProductName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSupplierID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCategoryID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errUnitPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(155, 319);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(58, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(128, 218);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(116, 20);
            this.txtUnitPrice.TabIndex = 23;
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.Location = new System.Drawing.Point(128, 174);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.ReadOnly = true;
            this.txtCategoryID.Size = new System.Drawing.Size(78, 20);
            this.txtCategoryID.TabIndex = 22;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(128, 127);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.ReadOnly = true;
            this.txtSupplierID.Size = new System.Drawing.Size(78, 20);
            this.txtSupplierID.TabIndex = 21;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(128, 81);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(116, 20);
            this.txtProductName.TabIndex = 20;
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(128, 39);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(78, 20);
            this.txtProductID.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Unit price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "CategoryID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "SupplierID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Product Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Product ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Status";
            // 
            // chkDiscontinued
            // 
            this.chkDiscontinued.AutoSize = true;
            this.chkDiscontinued.Location = new System.Drawing.Point(128, 263);
            this.chkDiscontinued.Name = "chkDiscontinued";
            this.chkDiscontinued.Size = new System.Drawing.Size(88, 17);
            this.chkDiscontinued.TabIndex = 27;
            this.chkDiscontinued.Text = "Discontinued";
            this.chkDiscontinued.UseVisualStyleBackColor = true;
            // 
            // btnChooseCategory
            // 
            this.btnChooseCategory.Image = global::ShopManagement.Properties.Resources.search_loop_512;
            this.btnChooseCategory.Location = new System.Drawing.Point(212, 172);
            this.btnChooseCategory.Name = "btnChooseCategory";
            this.btnChooseCategory.Size = new System.Drawing.Size(32, 23);
            this.btnChooseCategory.TabIndex = 29;
            this.btnChooseCategory.Text = " ";
            this.btnChooseCategory.UseVisualStyleBackColor = true;
            this.btnChooseCategory.Click += new System.EventHandler(this.btnChooseCategory_Click);
            // 
            // btnChooseSupplier
            // 
            this.btnChooseSupplier.Image = global::ShopManagement.Properties.Resources.search_loop_512;
            this.btnChooseSupplier.Location = new System.Drawing.Point(212, 125);
            this.btnChooseSupplier.Name = "btnChooseSupplier";
            this.btnChooseSupplier.Size = new System.Drawing.Size(32, 23);
            this.btnChooseSupplier.TabIndex = 28;
            this.btnChooseSupplier.Text = " ";
            this.btnChooseSupplier.UseVisualStyleBackColor = true;
            this.btnChooseSupplier.Click += new System.EventHandler(this.btnChooseSupplier_Click);
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
            // frmProductInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 395);
            this.Controls.Add(this.btnChooseCategory);
            this.Controls.Add(this.btnChooseSupplier);
            this.Controls.Add(this.chkDiscontinued);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.txtCategoryID);
            this.Controls.Add(this.txtSupplierID);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmProductInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input Product";
            ((System.ComponentModel.ISupportInitialize)(this.errProductName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSupplierID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCategoryID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errUnitPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.TextBox txtSupplierID;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkDiscontinued;
        private System.Windows.Forms.Button btnChooseCategory;
        private System.Windows.Forms.Button btnChooseSupplier;
        private System.Windows.Forms.ErrorProvider errProductName;
        private System.Windows.Forms.ErrorProvider errSupplierID;
        private System.Windows.Forms.ErrorProvider errCategoryID;
        private System.Windows.Forms.ErrorProvider errUnitPrice;
    }
}