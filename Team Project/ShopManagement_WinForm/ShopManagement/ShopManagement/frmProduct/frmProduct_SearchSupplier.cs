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
    public partial class frmProduct_SearchSupplier : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public frmProduct_SearchSupplier()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            LoadFromDataBase();
        }

        void LoadFromDataBase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Supplier.SelectSomeInfo]";
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                dr = cmd.ExecuteReader();
                table.Load(dr);
                dgSupplier.DataSource = table;
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


        void SetData(string id, string companyname, string contactname, string country, string phone)
        {
            txtSupplierID.Text = id;
            txtCompanyName.Text = companyname;
            txtContactName.Text = contactname;
            txtCountry.Text = country;
            txtPhone.Text = phone;
        }

        private void dgSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgSupplier.CurrentRow;
            if (row != null)
            {
                SetData(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(),
                        row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString()
                        , row.Cells[4].Value.ToString());
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            frmProduct owner = (frmProduct)this.Owner;
            owner.SetSupplierID(txtSupplierID.Text);
            this.Close();
        }

        void SearchByName(string searchValue)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Supplier.SearchCompanyName]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "companyName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = searchValue;
                cmd.Parameters.Add(param);

                DataTable table = new DataTable();
                dr = cmd.ExecuteReader();
                table.Load(dr);
                dgSupplier.DataSource = table;
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
            string searchValue = txtSearchValue.Text.Trim();
            if (searchValue.Length == 0)
            {
                MessageBox.Show("Empty search value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                SearchByName(searchValue);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFromDataBase();
            txtSearchValue.Text = "";
        }
    }
}
