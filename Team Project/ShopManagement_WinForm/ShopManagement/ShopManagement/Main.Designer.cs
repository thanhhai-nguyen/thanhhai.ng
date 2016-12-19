namespace ShopManagement
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Categories = new System.Windows.Forms.ToolStripButton();
            this.Shippers = new System.Windows.Forms.ToolStripButton();
            this.Suppliers = new System.Windows.Forms.ToolStripButton();
            this.Products = new System.Windows.Forms.ToolStripButton();
            this.Employees = new System.Windows.Forms.ToolStripButton();
            this.Orders = new System.Windows.Forms.ToolStripButton();
            this.Customer = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Categories,
            this.Shippers,
            this.Suppliers,
            this.Products,
            this.Employees,
            this.Orders,
            this.Customer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 70);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1064, 89);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Categories
            // 
            this.Categories.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categories.Image = ((System.Drawing.Image)(resources.GetObject("Categories.Image")));
            this.Categories.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Categories.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Categories.Name = "Categories";
            this.Categories.Size = new System.Drawing.Size(84, 86);
            this.Categories.Text = "Categories";
            this.Categories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Categories.Click += new System.EventHandler(this.Categories_Click);
            // 
            // Shippers
            // 
            this.Shippers.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shippers.Image = ((System.Drawing.Image)(resources.GetObject("Shippers.Image")));
            this.Shippers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Shippers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Shippers.Name = "Shippers";
            this.Shippers.Size = new System.Drawing.Size(70, 86);
            this.Shippers.Text = "Shippers";
            this.Shippers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Shippers.Click += new System.EventHandler(this.Shippers_Click);
            // 
            // Suppliers
            // 
            this.Suppliers.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Suppliers.Image = ((System.Drawing.Image)(resources.GetObject("Suppliers.Image")));
            this.Suppliers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Suppliers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Suppliers.Name = "Suppliers";
            this.Suppliers.Size = new System.Drawing.Size(74, 86);
            this.Suppliers.Text = "Suppliers";
            this.Suppliers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Suppliers.Click += new System.EventHandler(this.Suppliers_Click);
            // 
            // Products
            // 
            this.Products.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Products.Image = ((System.Drawing.Image)(resources.GetObject("Products.Image")));
            this.Products.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Products.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Products.Name = "Products";
            this.Products.Size = new System.Drawing.Size(70, 86);
            this.Products.Text = "Products";
            this.Products.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Products.Click += new System.EventHandler(this.Products_Click);
            // 
            // Employees
            // 
            this.Employees.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Employees.Image = ((System.Drawing.Image)(resources.GetObject("Employees.Image")));
            this.Employees.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Employees.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Employees.Name = "Employees";
            this.Employees.Size = new System.Drawing.Size(85, 86);
            this.Employees.Text = "Employees";
            this.Employees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Employees.Click += new System.EventHandler(this.Employees_Click);
            // 
            // Orders
            // 
            this.Orders.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Orders.Image = ((System.Drawing.Image)(resources.GetObject("Orders.Image")));
            this.Orders.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Orders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Orders.Name = "Orders";
            this.Orders.Size = new System.Drawing.Size(59, 86);
            this.Orders.Text = "Orders";
            this.Orders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Orders.Click += new System.EventHandler(this.Orders_Click);
            // 
            // Customer
            // 
            this.Customer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer.Image = ((System.Drawing.Image)(resources.GetObject("Customer.Image")));
            this.Customer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Customer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(82, 86);
            this.Customer.Text = "Customers";
            this.Customer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Customer.Click += new System.EventHandler(this.Customer_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 550);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Categories;
        private System.Windows.Forms.ToolStripButton Shippers;
        private System.Windows.Forms.ToolStripButton Suppliers;
        private System.Windows.Forms.ToolStripButton Products;
        private System.Windows.Forms.ToolStripButton Employees;
        private System.Windows.Forms.ToolStripButton Orders;
        private System.Windows.Forms.ToolStripButton Customer;
    }
}