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
    public partial class frmOrderDetailInput : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        bool isNew;
        public bool IsNew
        {
            set { isNew = value; }
        }

        public frmOrderDetailInput()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        }

        public void getOrderID(string orderID)
        {
            this.txtOrderID.Text = orderID;
        }

        public void SetChooseButton(bool state)
        {
                btnChooseProductID.Visible = state;
        }

        public void SetData( string productID, string unitprice, string qty, string discount)
        {
            txtProductID.Text = productID;
            txtUnitPrice.Text = unitprice;
            txtQuantity.Text = qty;
            txtDiscount.Text = discount;
        }

        public void SetOrderID(string orderID)
        {
            txtOrderID.Text = orderID;
        }
        public void SetProductID(string productID, string unitprice)
        {
            txtProductID.Text = productID;
            txtUnitPrice.Text = unitprice;
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
            bool isError = false;
            if (txtProductID.Text.Length == 0)
            {
                isError = true;
                errProductID.SetError(btnChooseProductID, "ProductID is empty");
            }
            else
                errProductID.Clear();
            if (!isValidFloat(txtUnitPrice.Text.Trim()))
            {
                isError = true;
                errUnitPrice.SetError(txtUnitPrice, "Unit price must be number");
            }
            else
                errUnitPrice.Clear();

            if (txtQuantity.Text.Length == 0 || int.Parse(txtQuantity.Text) == 0)
            {
                isError = true;
                errQuantity.SetError(txtQuantity, "Unit price must be number > 0");
            }
            else errQuantity.Clear();

            if (!isValidFloat(txtDiscount.Text.Trim()) || float.Parse(txtDiscount.Text.Trim()) > 1.0)
            {
                isError = true;
                errDiscount.SetError(txtDiscount, "Discount must be number and less than or equal 1");
            }
            else
                errDiscount.Clear();
            return !isError;
        }

        bool IsDuplicatedOrderDetail()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[OrderDetails.SelectOrder]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "orderid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtOrderID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "productid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtProductID.Text);
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                if (count == 0) return false;
                return true;

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }

        void AddNewOrderDetail()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[OrderDetails.Insert]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "orderid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtOrderID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "productid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtProductID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "unitprice";
                param.SqlDbType = SqlDbType.Money;
                param.Value = float.Parse(txtUnitPrice.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "qty";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Value = int.Parse(txtQuantity.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "discount";
                param.SqlDbType = SqlDbType.Float;
                param.Value = float.Parse(txtDiscount.Text);
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
        void UpdateOrderDetail()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[OrderDetails.Update]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "orderid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtOrderID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "productid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtProductID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "unitprice";
                param.SqlDbType = SqlDbType.Money;
                param.Value = float.Parse(txtUnitPrice.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "qty";
                param.SqlDbType = SqlDbType.SmallInt;
                param.Value = int.Parse(txtQuantity.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "discount";
                param.SqlDbType = SqlDbType.Float;
                param.Value = float.Parse(txtDiscount.Text);
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            SetData("", "", "", "");
            errProductID.Clear();
            errQuantity.Clear();
            errOrderID.Clear();
            errDiscount.Clear();
            errQuantity.Clear();
            SetChooseButton(true);
            isNew = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                frmOrderDetail owner = (frmOrderDetail)this.Owner;
                if (isNew) 
                {
                    if (!IsDuplicatedOrderDetail())
                    {
                        AddNewOrderDetail();
                        owner.LoadFromDatabase();
                    }
                    else
                    {
                        MessageBox.Show("This order detail is existed", "Warning");
                    }
                }
                else
                {
                    UpdateOrderDetail();
                    owner.LoadFromDatabase();
                }
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && (e.KeyCode != Keys.Back))
                e.SuppressKeyPress = true;
        }

        private void btnChooseOrder_Click(object sender, EventArgs e)
        {
            frmOrderDetail_SearchOrder searchOrder = new frmOrderDetail_SearchOrder();
            searchOrder.Owner = this;
            searchOrder.ShowDialog();
        }

        private void btnChooseProductID_Click(object sender, EventArgs e)
        {
            frmOrderDetail_SearchProduct search = new frmOrderDetail_SearchProduct();
            search.Owner = this;
            search.ShowDialog();
        }
    }
}
