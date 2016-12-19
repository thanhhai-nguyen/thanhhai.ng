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
    public partial class frmSearchShipID : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public frmSearchShipID()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            LoadDatabase();
            txtShipperID.Enabled = false;
        }

        public void LoadDatabase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[ShipperGetData]";
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgShipper.DataSource = table;

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

        public void setInfo(string shipID, string compName, string phone)
        {
            this.txtShipperID.Text = shipID;
            this.txtCompname.Text = compName;
            this.txtPhone.Text = phone;
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            if (txtShipperID.Text == "")
            {
                MessageBox.Show("Please choice row before click 'Choice'");
            }
            else
            {
                frmOrder owner = (frmOrder)this.Owner;

                owner.setShipID(this.txtShipperID.Text);
                this.Close();
            }
        }

        private void dgShipper_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow r = dgShipper.SelectedRows[0];
                string empID1 = r.Cells[0].Value.ToString();
                string lastName1 = r.Cells[1].Value.ToString();
                string firstName1 = r.Cells[2].Value.ToString();
                setInfo(empID1, lastName1, firstName1);

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
                    cmd.CommandText = "[searchByName_Ship]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    #region SQL param

                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter();
                    param.ParameterName = "@compname";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 40;
                    param.Value = txtSearch.Text;
                    cmd.Parameters.Add(param);

                    #endregion

                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    dgShipper.DataSource = table;
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
            txtPhone.Clear();
            txtShipperID.Clear();
            txtSearch.Clear();
        }
    }
}
