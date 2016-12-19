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
    public partial class frmOrderDetail_SearchOrder : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public frmOrderDetail_SearchOrder()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            LoadFromDataBase();
            cbbSearchType.SelectedIndex = 0;
        }

        public void LoadFromDataBase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Order.MapCusAndEmp]";
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                dr = cmd.ExecuteReader();
                table.Load(dr);
                dgOrder.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

         void SetData(string orderID, string company, string contact, string emp, string orderDate)
        {
            txtOrderID.Text = orderID;
            txtCompany.Text = company;
            txtContact.Text = contact;
            txtEmp.Text = emp;
            txtOrderDate.Text = orderDate;
        }

        private void dgOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgOrder.CurrentRow;
            if (row != null)
            {
                SetData(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), 
                    row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString());
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            frmOrderDetailInput owner = (frmOrderDetailInput) this.Owner;
            owner.SetOrderID(txtOrderID.Text);
            this.Close();
        }

        void SearchByOrderID(string searchValue)
        { 
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Order.MapCusAndEmp.SearchOrderID]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "orderid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(searchValue);
                cmd.Parameters.Add(param);

                DataTable table = new DataTable();
                dr = cmd.ExecuteReader();
                table.Load(dr);
                dgOrder.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }
        void SearchByCompanyName(string searchValue)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Order.MapCusAndEmp.SearchCompanyName]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "companyName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = '%' + searchValue + '%';
                cmd.Parameters.Add(param);

                DataTable table = new DataTable();
                dr = cmd.ExecuteReader();
                table.Load(dr);
                dgOrder.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int searchType = cbbSearchType.SelectedIndex;
            string searchValue = txtSearchValue.Text.Trim();
            if (searchValue.Length == 0)
            {
                LoadFromDataBase();
            }
            else
            {
                switch (searchType)
                {
                    case 0:
                        SearchByOrderID(searchValue);
                        break;
                    case 1:
                        SearchByCompanyName(searchValue);
                        break;

                }
            }
        }

        private void txtSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            int searchType = cbbSearchType.SelectedIndex;
            if (searchType == 0)
            {
                if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && (e.KeyCode != Keys.Back))
                    e.SuppressKeyPress = true;
            }
        }

        private void frmOrderDetail_SearchOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
