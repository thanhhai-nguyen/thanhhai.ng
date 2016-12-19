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
    public partial class frmSearchEmpID : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public frmSearchEmpID()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            LoadDatabase();
            txtEmpID.Enabled = false;
        }

        public void LoadDatabase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[EmployeeGetData]";
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgEmp.DataSource = table;

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

        public void setInfo(string empID, string lastName, string firstName)
        {
            this.txtEmpID.Text = empID;
            this.txtLastname.Text = lastName ;
            this.txtFirstname.Text = firstName;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow r = dgEmp.SelectedRows[0];
                string empID1 = r.Cells[0].Value.ToString();
                string lastName1 = r.Cells[1].Value.ToString();
                string firstName1 = r.Cells[2].Value.ToString();
                setInfo(empID1, lastName1, firstName1);
            }
            catch (Exception)
            {
                
            }
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            if (txtEmpID.Text == "")
            {
                MessageBox.Show("Please choice row before click 'Choice'");
            }
            else
            {
                frmOrder owner = (frmOrder)this.Owner;

                owner.setEmpID(this.txtEmpID.Text);
                this.Close();
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
                    cmd.CommandText = "[searchByName_Emp]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    #region SQL param

                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter();
                    param.ParameterName = "@lastname";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 20;
                    param.Value = txtSearch.Text;
                    cmd.Parameters.Add(param);

                    #endregion

                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    dgEmp.DataSource = table;
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
            txtEmpID.Clear();
            txtFirstname.Clear();
            txtLastname.Clear();
            txtSearch.Clear();
        }
    }
}
