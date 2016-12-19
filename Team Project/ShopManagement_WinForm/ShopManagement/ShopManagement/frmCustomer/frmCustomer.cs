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
    public partial class frmCustomer : Form
    {
        SqlConnection con;
        SqlCommand cmd;


        // Done
        public frmCustomer()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            // Database directory logging in with Window Authentication
            LoadDatabase();
            cbxSearch.SelectedIndex = 0;
        }
        // Done
        public void LoadDatabase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[tbCustomerLoad]";
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgCustomer.DataSource = table;
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
        #region getset
        public DataGridView gvOrder
        {
            get { return dgCustomer; }
        }
        #endregion
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCustID.Text.Length == 0)
            {
                MessageBox.Show("Please select a customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DataGridViewRow row = dgCustomer.SelectedRows[0];
            DialogResult dialogResult = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "DeleteCustomer";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@CustID";
                    param.SqlDbType = SqlDbType.Int;
                    param.Value = int.Parse(txtCustID.Text);
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Delete successful");
                    LoadDatabase();
                    btnClear_Click(sender, e);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Your delete is related to another table.", "Warning");
                    con.Close();
                }

            }

        }
        // Done
        // This method will try to clear out all poped error provider actived from the last try
        void resetErrorProvider()
        {
            erAddress.Clear();
            erCity.Clear();
            erCompName.Clear();
            erContName.Clear();
            erContTitle.Clear();
            erCountry.Clear();
            erFax.Clear();
            erPhone.Clear();
            erPostalCode.Clear();
            erRegion.Clear();
        }
        // Done
        // Check validation of the inputed data 
        bool validateInput()
        {
            resetErrorProvider();
            bool bError = false;
            if (mtxtPhone.Text.Equals(""))
            {
                erPhone.SetError(mtxtPhone, "This field is repuired!");
                bError = true;
            }
            string testStr = txtCompName.Text.Trim();
            if (testStr.Length == 0)
            {
                erCompName.SetError(txtCompName, "This field is repuired!");
                bError = true;
            }
            testStr = txtContName.Text.Trim();
            if (testStr.Length == 0)
            {
                erContName.SetError(txtContName, "This field is repuired!");
                bError = true;
            }
            testStr = txtContTitle.Text.Trim();
            if (testStr.Length == 0)
            {
                erContTitle.SetError(txtContTitle, "This field is repuired!");
                bError = true;
            }
            testStr = txtAddress.Text.Trim();
            if (testStr.Length == 0)
            {
                erAddress.SetError(txtAddress, "This field is repuired!");
                bError = true;
            }
            testStr = txtCity.Text.Trim();
            if (testStr.Length == 0)
            {
                erCity.SetError(txtCity, "This field is repuired!");
                bError = true;
            }
            testStr = cbCountry.Text.Trim();
            if (testStr.Length == 0)
            {
                erCountry.SetError(cbCountry, "This field is repuired!");
                bError = true;
            }
            return bError;
        }
        // Done
        // Reset the input form to ""
        void resetInput()
        {
            txtCustID.Enabled = true;
            txtCustID.Text = "";
            txtCompName.Text = "";
            txtContName.Text = "";
            txtContTitle.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtRegion.Text = "";
            mtxtPostalCode.Text = "";
            cbCountry.Text = "";
            mtxtPhone.Text = "";
            txtFax.Text = "";
        }
        // Done
        private void btnReset_Click(object sender, EventArgs e)
        {
            resetInput();
            resetErrorProvider();
        }
        //Done
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateInput())
            {
                if (txtCustID.Text.Equals(""))
                    addNewCustomer();
                else
                    updateOrder();
                resetInput();
            }
        }
        public void updateOrder()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UpdateCustomer";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@CustID";
                param.SqlDbType = SqlDbType.Int;
                param.Value = txtCustID.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@CompanyName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = txtCompName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@ContactName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 30;
                param.Value = txtContName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@ContactTitle";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 30;
                param.Value = txtContTitle.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Address";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 60;
                param.Value = txtAddress.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@City";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtCity.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Region";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtRegion.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@PostalCode";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 10;
                param.Value = mtxtPostalCode.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Country";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = cbCountry.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Phone";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 24;
                param.Value = mtxtPhone.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Fax";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 24;
                param.Value = txtFax.Text;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("A Customer updated successful!");
                LoadDatabase();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                con.Close();
            }
        }
        // Done
        // Add a new customer's information to database and load database to data grid view
        public void addNewCustomer()
        {
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "InsertCustomer";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@CompanyName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = txtCompName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@ContactName";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 30;
                param.Value = txtContName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@ContactTitle";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 30;
                param.Value = txtContTitle.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Address";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 60;
                param.Value = txtAddress.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@City";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtCity.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Region";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtRegion.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@PostalCode";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 10;
                param.Value = mtxtPostalCode.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Country";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = cbCountry.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Phone";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 24;
                param.Value = mtxtPhone.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Fax";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 24;
                param.Value = txtFax.Text;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Add new Customer successful!");
                LoadDatabase();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Done
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = cbxSearch.Text;
            string value = txtSearch.Text.Trim();
            if (search == "" || value == "")
            {
                MessageBox.Show("Empty search value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                con.Open();
                SqlParameter param = new SqlParameter();
                cmd = new SqlCommand();
                cmd.Connection = con;

                if (search.Equals("by Company Name"))
                {
                    cmd.CommandText = "SearchCustomerByCompanyName";
                    cmd.CommandType = CommandType.StoredProcedure;

                    param.ParameterName = "@CompName";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 40;
                    param.Value = value;
                    cmd.Parameters.Add(param);
                }
                if (search.Equals("by Contact Name"))
                {
                    cmd.CommandText = "SearchCustomerByContactName";
                    cmd.CommandType = CommandType.StoredProcedure;

                    param.ParameterName = "@ContName";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 30;
                    param.Value = value;
                    cmd.Parameters.Add(param);
                }
                if (search.Equals("by Country"))
                {
                    cmd.CommandText = "SearchCustomerByCountry";
                    cmd.CommandType = CommandType.StoredProcedure;

                    param.ParameterName = "@CountryName";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 15;
                    param.Value = value;
                    cmd.Parameters.Add(param);
                }
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgCustomer.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        //Done
        private void dgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustID.Enabled = false;

            DataGridViewRow r = dgCustomer.CurrentRow;
            if (r != null)
            {
                resetErrorProvider();
                Customer cust = new Customer(r.Cells[0].Value.ToString(),
                r.Cells[1].Value.ToString(),
                r.Cells[2].Value.ToString(),
                r.Cells[3].Value.ToString(),
                r.Cells[4].Value.ToString(),
                r.Cells[5].Value.ToString(),
                r.Cells[6].Value.ToString(),
                r.Cells[7].Value.ToString(),
                r.Cells[8].Value.ToString(),
                r.Cells[9].Value.ToString(),
                r.Cells[10].Value.ToString());
                this.setinfo(cust);
            }

        }
        //Done
        private void setinfo(Customer cust)
        {
            txtCustID.Text = cust.CustID1;
            txtCompName.Text = cust.CompanyName1;
            txtContName.Text = cust.ContactName1;
            txtContTitle.Text = cust.ContactTitile1;
            txtAddress.Text = cust.Address1;
            txtCity.Text = cust.City1;
            txtRegion.Text = cust.Region1;
            mtxtPostalCode.Text = cust.PostalCode1;
            cbCountry.Text = cust.Country1;
            mtxtPhone.Text = cust.Phone1;
            txtFax.Text = cust.Fax1;
        }
        //Done
        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadDatabase();
            txtSearch.Text = "";
            resetInput();
            resetErrorProvider();
        }
    }
}
