using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShopManagement
{
    public partial class frmProductInput : Form
    {
        bool isNew;
        SqlConnection con;
        SqlCommand cmd;

        public bool IsNew
        {
            set
            {
                isNew = value;
            }
        }
        public frmProductInput()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        }

        public void SetData(string id, string name, string supplierID, string categoryID, string unitPrice, bool status)
        {
            txtProductID.Text = id;
            txtProductName.Text = name;
            txtSupplierID.Text = supplierID;
            txtCategoryID.Text = categoryID;
            txtUnitPrice.Text = unitPrice;
            chkDiscontinued.Checked = status;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SetData("", "", "", "", "", false);
            errCategoryID.Clear();
            errProductName.Clear();
            errUnitPrice.Clear();
            errSupplierID.Clear();
            SetChooseButton(true);
        }

        bool isValidFloat(string str)
        {
            try
            {
                float f = float.Parse(str);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        bool isValidData()
        {
            string name = txtProductName.Text.Trim();
            string supID = txtSupplierID.Text.Trim();
            string catID = txtCategoryID.Text.Trim();
            string unitprice = txtUnitPrice.Text.Trim();
            bool status = chkDiscontinued.Checked;

            bool isError = false;
            if (name.Length == 0)
            {
                isError = true;
                errProductName.SetError(txtProductName, "Name must not be empty!");
            }
            else
                errProductName.Clear();
            if (supID.Length == 0)
            {
                isError = true;
                errSupplierID.SetError(btnChooseSupplier, "Supplier must be choiced!");
            }
            else
                errSupplierID.Clear();
            if (catID.Length == 0)
            {
                isError = true;
                errCategoryID.SetError(btnChooseCategory, "CategoryID must be choiced!");
            }
            else
                errCategoryID.Clear();
            if (!isValidFloat(unitprice) || float.Parse(unitprice) <= 0)
            {
                isError = true;
                errUnitPrice.SetError(txtUnitPrice, "Unit price must be number greater than 0");
            }
            else
            {
                errUnitPrice.Clear();
            }

            return !isError;
        }

        void AddNewOrderDetail()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.Insert]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "productname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = txtProductName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "supplierid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtSupplierID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "categoryid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtCategoryID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "unitprice";
                param.SqlDbType = SqlDbType.Money;
                param.Value = float.Parse(txtUnitPrice.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "discontinued";
                param.SqlDbType = SqlDbType.Bit;
                param.Value = chkDiscontinued.Checked;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Add successfully!", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }
        public void SetChooseButton(bool state)
        {
            btnChooseCategory.Visible = state;
            btnChooseSupplier.Visible = state;
        }
        void UpdateOrderDetail()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.Update]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "productid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtProductID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "productname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = txtProductName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "supplierid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtSupplierID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "categoryid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtCategoryID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "unitprice";
                param.SqlDbType = SqlDbType.Money;
                param.Value = float.Parse(txtUnitPrice.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "discontinued";
                param.SqlDbType = SqlDbType.Bit;
                param.Value = chkDiscontinued.Checked;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successfully!", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                frmProduct owner = (frmProduct)this.Owner;
                if (isNew)
                {
                    AddNewOrderDetail();
                    owner.LoadDataFromDatabase();
                }
                else
                {
                    UpdateOrderDetail();
                    owner.LoadDataFromDatabase();
                }
            }
        }

        public void SetSupplierID(string id)
        {
            txtSupplierID.Text = id;
        }
        public void SetCategoryID(string id)
        {
            txtCategoryID.Text = id;
        }

        private void btnChooseSupplier_Click(object sender, EventArgs e)
        {
            frmProduct_SearchSupplier sup = new frmProduct_SearchSupplier();
            sup.Owner = this;
            sup.ShowDialog();
        }

        private void btnChooseCategory_Click(object sender, EventArgs e)
        {
            frmProduct_SearchCategory cat = new frmProduct_SearchCategory();
            cat.Owner = this;
            cat.ShowDialog();
        }
    }
}
