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
    public partial class frmOrderDetail : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public frmOrderDetail()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            OrderID.Enabled = false;

        }

        public void LoadFromDatabase()
        {
            try
            {
                //dgOrderDetails.Rows.Clear();
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[OrderDetails.SelectAll]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();

                param = new SqlParameter();
                param.ParameterName = "orderid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(OrderID.Text);
                cmd.Parameters.Add(param);

                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgOrderDetails.DataSource = table;
                con.Close();
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


        public void getOrderID(string orderID)
        {
            this.OrderID.Text = orderID;
            LoadFromDatabase();
        }

        void DeleteOrder()
        {
            if (dgOrderDetails.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select row!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow row = dgOrderDetails.SelectedRows[0];
            if (row != null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "[OrderDetails.Delete]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "orderid";
                        param.SqlDbType = SqlDbType.Int;
                        param.Value = int.Parse(OrderID.Text);
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "productid";
                        param.SqlDbType = SqlDbType.Int;
                        param.Value = int.Parse(row.Cells[0].Value.ToString());
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Delete successfully!", "Information");
                        LoadFromDatabase();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }

                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (checkShipDate(OrderID.Text) == true)
            {
                MessageBox.Show("Order has been ship");
                return;
            }
            else
            {
                frmOrderDetailInput input = new frmOrderDetailInput();
                input.Owner = this;
                input.IsNew = true;
                input.getOrderID(OrderID.Text);
                input.ShowDialog();
            }

        }

        protected bool checkShipDate(string orderID)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[order.searchShipDate]";
                cmd.CommandType = CommandType.StoredProcedure;

                #region SQL param

                SqlParameter param = new SqlParameter();

                param = new SqlParameter();
                param.ParameterName = "@orderID";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(orderID);
                cmd.Parameters.Add(param);

                #endregion

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                return false;

            }
            catch (SqlException)
            {
                return true;
            }
            catch (Exception)
            {
                return true;
            }
            finally
            {
                con.Close();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkShipDate(OrderID.Text) == true)
            {
                MessageBox.Show("Order has been ship");
                return;
            }
            else
            {
                DataGridViewRow row = dgOrderDetails.CurrentRow;

                if (row != null)
                {
                    frmOrderDetailInput input = new frmOrderDetailInput();
                    input.Owner = this;
                    input.getOrderID(OrderID.Text);
                    input.IsNew = false;
                    input.SetChooseButton(false);
                    input.SetData(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString()
                        , row.Cells[3].Value.ToString());
                    input.ShowDialog();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFromDatabase();
        }
    }
}
