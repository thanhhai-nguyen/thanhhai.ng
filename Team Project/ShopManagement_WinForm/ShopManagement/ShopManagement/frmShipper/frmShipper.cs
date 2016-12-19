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
    public partial class frmShipper : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        public frmShipper()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            LoadDatabase();
            txtShipperID.Enabled = false;
            cbxSearch.SelectedIndex = 0;

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
            string search = cbxSearch.Text;
            string value = txtSearch.Text.Trim();
            if (value.Trim() == "")
            {
                MessageBox.Show("Empty search value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (search.Equals("Company Name"))
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
            if (search.Equals("Phone"))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[Shipper.searchByPhone]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    #region SQL param

                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter();
                    param.ParameterName = "@phone";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 24;
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
            errName.Clear();
            errorPhone.Clear();
        }

        bool isValidData()
        {
            string name = txtCompname.Text.Trim();
            string phone = txtPhone.Text.Trim();
            bool isError = false;
            if (name.Length == 0)
            {
                isError = true;
                errName.SetError(txtCompname, "Name must not be empty!");
            }
            else
                errName.Clear();
            if (phone.Length == 0)
            {
                isError = true;
                errorPhone.SetError(txtPhone, "Phone must not be empty!");
            }
            else
                errorPhone.Clear();
            return !isError;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
     
            if (isValidData())
            {
                if (txtShipperID.Text == "")
                {
                    addNewOrder();
                }

                else
                {
                    updateOrder();
                }
            }

        }

        public void addNewOrder()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Shipper.Insert]";
                cmd.CommandType = CommandType.StoredProcedure;

                ///////

                #region SQL param
                SqlParameter param = new SqlParameter();

                param = new SqlParameter();
                param.ParameterName = "@companyname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = txtCompname.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@phone";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 24;
                param.Value = txtPhone.Text;
                cmd.Parameters.Add(param);

                #endregion

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Add Successfully!", "Information");
                LoadDatabase();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                con.Close();
            }
        }

        public void updateOrder()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Shipper.Update]";
                cmd.CommandType = CommandType.StoredProcedure;

                ///////

                #region SQL param
                SqlParameter param = new SqlParameter();

                param = new SqlParameter();
                param.ParameterName = "@shipperid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = txtShipperID.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@companyname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = txtCompname.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@phone";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 24;
                param.Value = txtPhone.Text;
                cmd.Parameters.Add(param);

                #endregion

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update successfully!", "Information");
                LoadDatabase();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgShipper.SelectedRows.Count == 0)
            {
                errName.SetError(btnDelete, "Please select a shipper!");
                return;
            }
            if (txtShipperID.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select a shipper!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            errName.Clear();
            try
            {
                DialogResult rs = MessageBox.Show("Do you want delete this shipper?", "Confirm", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[Shipper.DeleteOnShipper]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter();

                    #region orderID

                    param1.ParameterName = "@shipperid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = int.Parse(txtShipperID.Text);
                    cmd.Parameters.Add(param1);

                    #endregion

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Delete Success", "Information");
                    LoadDatabase();
                    txtCompname.Clear();
                    txtPhone.Clear();
                    txtSearch.Clear();
                    txtShipperID.Clear();
                    errName.Clear();
                }
            }
            catch (SqlException)
            {
                con.Close();
                MessageBox.Show("Orders of this shipper still function. Cannot delete !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCompname.Clear();
            txtPhone.Clear();
            txtSearch.Clear();
            txtShipperID.Clear();
            errName.Clear();
        }


    }
}
