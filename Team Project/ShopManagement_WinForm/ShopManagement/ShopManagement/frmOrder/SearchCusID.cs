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
    public partial class frmSearchCusID : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public frmSearchCusID()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            LoadDatabase();
            txtCusID.Enabled = false;
        }

        public void LoadDatabase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[CustomerGetData]";
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgCust.DataSource = table;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void setInfo(string cusID, string compName, string contactName)
        {
            this.txtCusID.Text = cusID;
            this.txtCompname.Text = compName;
            this.txtContactname.Text = contactName;
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            if (txtCusID.Text == "")
            {
                MessageBox.Show("Please choice row before click 'Choice'");
            }
            else
            {
                frmOrder owner = (frmOrder)this.Owner;

                owner.setCusID(this.txtCusID.Text);
                this.Close();
            }
        }

        private void dgCust_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dgCust.SelectedRows[0];
                string cusID1 = r.Cells[0].Value.ToString();
                string compName1 = r.Cells[1].Value.ToString();
                string contactName1 = r.Cells[2].Value.ToString();
                setInfo(cusID1, compName1, contactName1);
            }
            catch (Exception)
            {
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string value = txtSearch.Text.Trim();
            if (value.Trim() == "")
            {
                errorProvider1.SetError(btnSearch, "Please input value before search !!!");
                return;
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[searchByName_Cust]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    #region SQL param

                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter();
                    param.ParameterName = "@contactname";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 30;
                    param.Value = txtSearch.Text;
                    cmd.Parameters.Add(param);

                    #endregion

                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    dgCust.DataSource = table;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadDatabase();
            txtCompname.Clear();
            txtContactname.Clear();
            txtCusID.Clear();
            txtSearch.Clear();
        }
    }
}

