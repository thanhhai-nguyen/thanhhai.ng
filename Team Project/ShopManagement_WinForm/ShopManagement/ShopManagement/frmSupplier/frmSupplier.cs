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
    public partial class frmSupplier : Form
    {

        SqlConnection con;
        SqlCommand cmd;

        public frmSupplier()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            LoadDatabase();
            cbxSearch.SelectedIndex = 0;
        }


        #region Utility
        public void LoadDatabase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Supplier.SelectAll]";
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgSupplier.DataSource = table;
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

        void resetInput()
        {
            
            txtSupID.Enabled = true;
            txtSupID.Text = "";
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

        public void addNewSupplier()
        {
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Supplier.Insert]";
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
                MessageBox.Show("Add new Supplier successful!");
                LoadDatabase();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updateSupplier()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Supplier.Update]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();

                param.ParameterName = "@SupID";
                param.SqlDbType = SqlDbType.Int;
                param.Value = txtSupID.Text;
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
                MessageBox.Show("A Supplier updated successful!");
                LoadDatabase();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                con.Close();
            }
        }

        private void setinfo(Supplier sup)
        {
            txtSupID.Text = sup.SupID1;
            txtCompName.Text = sup.CompanyName1;
            txtContName.Text = sup.ContactName1;
            txtContTitle.Text = sup.ContactTitile1;
            txtAddress.Text = sup.Address1;
            txtCity.Text = sup.City1;
            txtRegion.Text = sup.Region1;
            mtxtPostalCode.Text = sup.PostalCode1;
            cbCountry.Text = sup.Country1;
            mtxtPhone.Text = sup.Phone1;
            txtFax.Text = sup.Fax1;
        }
        #endregion

        #region Error Checker
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
        #endregion

        #region ButtonClick
        private void btnReset_Click(object sender, EventArgs e)
        {
            resetInput();
            resetErrorProvider();
        }

        private void btnDelete_Click(object sender, EventArgs e)


        {
            if (dgSupplier.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(txtSupID.Text== "")
            {
                MessageBox.Show("Please select a supplier!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgSupplier.SelectedRows[0];
            DialogResult dialogResult = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[Supplier.Delete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@SupID";
                    param.SqlDbType = SqlDbType.Int;
                    param.Value = int.Parse(txtSupID.Text);
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Delete Success !!!");
                    LoadDatabase();
                    btnClear_Click(sender, e);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Your delete is not permited because of relation with another table.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadDatabase();
            txtSearch.Text = "";
            resetInput();
            resetErrorProvider();
        }

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
                    cmd.CommandText = "[Supplier.SearchCustomerByCompanyName]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    param.ParameterName = "@CompName";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 40;
                    param.Value = value;
                    cmd.Parameters.Add(param);
                }
                if (search.Equals("by Contact Name"))
                {
                    cmd.CommandText = "[Supplier.SearchCustomerByContactName]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    param.ParameterName = "@ContName";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 30;
                    param.Value = value;
                    cmd.Parameters.Add(param);
                }
                if (search.Equals("by Country"))
                {
                    cmd.CommandText = "[Supplier.SearchCustomerByCountry]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    param.ParameterName = "@CountryName";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 15;
                    param.Value = value;
                    cmd.Parameters.Add(param);
                }
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgSupplier.DataSource = table;
                
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateInput())
            {
                if (txtSupID.Text.Equals(""))
                    addNewSupplier();
                else
                    updateSupplier();
                resetInput();
                resetErrorProvider();
            }
        }

        private void dgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSupID.Enabled = false;
            resetErrorProvider();
            DataGridViewRow r = dgSupplier.CurrentRow;
            if (r != null)
            {
                Supplier cust = new Supplier(r.Cells[0].Value.ToString(),
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

        #endregion
    }


}
