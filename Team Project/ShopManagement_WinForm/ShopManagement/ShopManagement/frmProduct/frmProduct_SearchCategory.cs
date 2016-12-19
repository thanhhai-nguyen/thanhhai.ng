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
    public partial class frmProduct_SearchCategory : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public frmProduct_SearchCategory()
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
                cmd.CommandText = "[Categories.SelectAll]";
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable table = new DataTable();
                dr = cmd.ExecuteReader();
                table.Load(dr);
                dgCategory.DataSource = table;
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


        void SetData(string id, string name, string description)
        {
            txtCatID.Text = id;
            txtCatName.Text = name;
            txtDes.Text = description;
        }

        private void dgCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgCategory.CurrentRow;
            if (row != null)
            {
                SetData(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(),
                        row.Cells[2].Value.ToString());
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            frmProduct owner = (frmProduct)this.Owner;
            owner.SetCategoryID(txtCatID.Text);
            this.Close();
        }

        void SearchByName(string searchValue)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Categories.SearchByName]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "categoryname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = searchValue;
                cmd.Parameters.Add(param);

                DataTable table = new DataTable();
                dr = cmd.ExecuteReader();
                table.Load(dr);
                dgCategory.DataSource = table;
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
