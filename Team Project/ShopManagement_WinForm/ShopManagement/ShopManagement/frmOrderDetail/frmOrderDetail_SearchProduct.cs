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
    public partial class frmOrderDetail_SearchProduct : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public frmOrderDetail_SearchProduct()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            LoadFromDataBase();
        }


        public void LoadFromDataBase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.GetSomeInfo]";
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                reader = cmd.ExecuteReader();
                table.Load(reader);
                dgProduct.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }

        void SetData(string productID, string productName, string unitPrice, bool isCheck)
        {
            txtProductID.Text = productID;
            txtProductName.Text = productName;
            txtUnitPrice.Text = unitPrice;
            chkDiscontinued.Checked = isCheck;
        }

        private void dgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgProduct.CurrentRow;
            if (row != null)
            {
                SetData(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(),
                        row.Cells[2].Value.ToString(), (bool)row.Cells[3].Value);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (chkDiscontinued.Checked == true)
            {
                MessageBox.Show("This product is discontinued!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmOrderDetailInput owner = (frmOrderDetailInput)this.Owner;
                owner.SetProductID(txtProductID.Text, txtUnitPrice.Text);
                this.Close();
            }
        }

        void SearchByName(string value)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.SearchByName]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "productname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = value;
                cmd.Parameters.Add(param);

                DataTable table = new DataTable();
                reader = cmd.ExecuteReader();
                table.Load(reader);
                dgProduct.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string value = txtSearchValue.Text.Trim();
            if (value.Length == 0)
            {
                LoadFromDataBase();
            }
            else
            {
                SearchByName(value);
            }
        }
    }
}
