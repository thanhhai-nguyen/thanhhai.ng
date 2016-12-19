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
    public partial class frmOrder : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        bool addNew;
        public frmOrder()
        {
            InitializeComponent();
            addNew = true;
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            /// integrated security = true
            LoadDatabase();
            cbxSearch.SelectedIndex = 0;
            panelText.Show();
            loadComboBOx();
        }

        public void loadComboBOx()
        {
            con.Open();
            cmd = new SqlCommand("[GetCountry]", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string country = String.Format("{0}", reader.GetValue(0));
                txtShipCountry.Items.Add(country);
                txtShipCountry.SelectedIndex = 0;
            }
            con.Close();
        }

        public void LoadDatabase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[OrderGetAll]";
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgOrder.DataSource = table;

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
            get { return dgOrder; }
        }

        #endregion

        #region setID
        public void setShipID(string shipID)
        {
            this.txtShipperID.Text = shipID;
        }

        public void setCusID(string custID)
        {
            this.txtCustomerID.Text = custID;
        }

        public void setEmpID(string empID)
        {
            this.txtEmployeeID.Text = empID;
        }
        #endregion

        public void setInfo(Lib order)
        {
            this.txtOrderID.Text = order.OrderID1;
            this.txtCustomerID.Text = order.CustomerID1;
            this.txtEmployeeID.Text = order.EmployeeID1;
            this.dtpOrderDate.Value = DateTime.Parse(order.OrderDate1);
            this.dtpRequireDate.Value = DateTime.Parse(order.RequireDate1);


            string shipDate = order.ShipDate1;
            if (shipDate == null || shipDate == "")
            {
                ckNotShip.Checked = true;
                dtpShipDate.Enabled = false;
            }
            else
            {
                dtpShipDate.Enabled = true;
                ckNotShip.Checked = false;
                this.dtpShipDate.Value = DateTime.Parse(order.ShipDate1);
            }
            this.txtShipperID.Text = order.ShipID1;
            this.txtFreight.Text = order.Freight1;
            this.txtShipName.Text = order.ShipName1;
            this.txtShipAddress.Text = order.ShipAddress1;
            this.txtShipCity.Text = order.ShipCity1;
            this.txtShipRegion.Text = order.ShipRegion1;
            this.txtShipPostalCode.Text = order.ShipPostalCode1;
            this.txtShipCountry.Text = order.ShipCountry1;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgOrder.SelectedRows.Count == 0)
            {
                errorProvider1.SetError(btnDelete, "Please select an order!");
                return;
            }
            if (txtOrderID.Text.Length == 0)
            {
                MessageBox.Show("Please select an order!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            errorProvider1.Clear();
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[DeleteOrder]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter();

                #region orderID
                param1.ParameterName = "@orderid";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = txtOrderID.Text;
                cmd.Parameters.Add(param1);
                #endregion

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Success");
                LoadDatabase();
            }
            catch (SqlException)
            {
                con.Close();
                DialogResult rs = MessageBox.Show("Your delete is related to another table. \nDo you really want delete selected row ?", "Confirm", MessageBoxButtons.YesNo);
                if (rs == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[DeleteOrderDetail]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    #region orderID
                    param.ParameterName = "@orderid";
                    param.SqlDbType = SqlDbType.Int;
                    param.Value = txtOrderID.Text;
                    cmd.Parameters.Add(param);
                    #endregion
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //////////////////////////////

                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[DeleteOrder]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter();

                    #region orderID
                    param1.ParameterName = "@orderid";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = txtOrderID.Text;
                    cmd.Parameters.Add(param1);
                    #endregion

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Delete Success");
                    LoadDatabase();
                }
            }
        }

        bool validateInput()
        {

            bool bError = false;
            if (txtShipPostalCode.MaskCompleted == false)
            {
                errorShipPostalCode.SetError(txtShipPostalCode, "Please enter required digit!");
                bError = true;
            }

            string customerID = txtCustomerID.Text.Trim();
            if (customerID.Length == 0)
            {
                errorCusID.SetError(txtCustomerID, "CustomerID must be fill!");
                bError = true;
            }

            string employeeID = txtEmployeeID.Text.Trim();
            if (employeeID.Length == 0)
            {
                errorEmpID.SetError(txtEmployeeID, "EmployeeID must be fill!");
                bError = true;
            }
            
            DateTime orderDate = dtpOrderDate.Value;
            DateTime requireDate = dtpRequireDate.Value;
            DateTime shipdate = dtpShipDate.Value;
            if (requireDate < orderDate)
            {
                errorShipDate.SetError(dtpRequireDate, "Require date must be >= order date");
                bError = true;
            }
            if (dtpShipDate.Enabled == true)
            {
                if (shipdate < orderDate)
                {
                    errorShipID.SetError(dtpShipDate, "Ship date must be >= order date");
                    bError = true;
                }
            }
            

            string shipID = txtShipperID.Text.Trim();
            if (shipID.Length == 0)
            {
                errorShipID.SetError(txtShipperID, "Ship ID must be choice !!!");
                bError = true;
            }

            string freight = txtFreight.Text.Trim();
            if (freight.Length == 0)
            {
                errorFreight.SetError(txtFreight, "Freight must be fill!");
                bError = true;
            }

            string shipname = txtShipName.Text.Trim();
            if (shipname.Length == 0)
            {
                errorShipName.SetError(txtShipName, "Ship name must be fill!");
                bError = true;
            }

            string shipaddress = txtShipAddress.Text.Trim();
            if (shipaddress.Length == 0)
            {
                errorShipAdd.SetError(txtShipAddress, "Ship address must be fill!");
                bError = true;
            }

            string shipcity = txtShipCity.Text.Trim();
            if (shipcity.Length == 0)
            {
                errorShipCity.SetError(txtShipCity, "Ship city must be fill!");
                bError = true;
            }

            string shipregion = txtShipRegion.Text.Trim();
            if (shipregion.Length == 0)
            {
                errorShipRegion.SetError(txtShipRegion, "Ship region must be fill!");
                bError = true;
            }

            string shipcountry = txtShipCountry.Text.Trim();
            if (shipcountry.Length == 0)
            {
                errorShipCountry.SetError(txtShipCountry, "Ship country must be fill!");
                bError = true;
            }

            if (bError == true)
            {
                return false;
            }
            return true;
        }

        void reset()
        {
            txtOrderID.Enabled = false;
            dtpOrderDate.ResetText();
            dtpRequireDate.ResetText();
            dtpShipDate.ResetText();
            txtCustomerID.Text = "";
            txtEmployeeID.Text = "";
            txtFreight.Text = "";
            txtOrderID.Text = "";
            txtShipAddress.Text = "";
            txtShipCity.Text = "";
            txtShipPostalCode.Text = "";
            txtShipCountry.Text = "";
            txtShipName.Text = "";
            txtShipperID.Text = "";
            txtShipRegion.Text = "";
            errorCusID.Clear();
            errorEmpID.Clear();
            errorFreight.Clear();
            errorOrderDate.Clear();
            errorProvider1.Clear();
            errorRequireDate.Clear();
            errorShipAdd.Clear();
            errorShipCity.Clear();
            errorShipCountry.Clear();
            errorShipDate.Clear();
            errorShipID.Clear();
            errorShipName.Clear();
            errorShipPostalCode.Clear();
            errorShipRegion.Clear();
            txtTo.Clear();
            txtFrom.Clear();
            dtpFrom.ResetText();
            dtpTo.ResetText();
            txtSearch.Clear();
        }

        void ClearError()
        {
            errorCusID.Clear();
            errorEmpID.Clear();
            errorFreight.Clear();
            errorOrderDate.Clear();
            errorProvider1.Clear();
            errorRequireDate.Clear();
            errorShipAdd.Clear();
            errorShipCity.Clear();
            errorShipCountry.Clear();
            errorShipDate.Clear();
            errorShipID.Clear();
            errorShipName.Clear();
            errorShipPostalCode.Clear();
            errorShipRegion.Clear();
            txtTo.Clear();
            txtFrom.Clear();
            dtpFrom.ResetText();
            dtpTo.ResetText();
            txtSearch.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateInput() == false)
            {
                return;
            }
            if (txtOrderID.Enabled == false && txtOrderID.Text == "")
            {
                addNewOrder();
                reset();
            }
            else
            {
                updateOrder();
                reset();
            }
        }

        public void updateOrder()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[UpdateOrder]";
                cmd.CommandType = CommandType.StoredProcedure;

                ///////
                #region SQL param

                SqlParameter param = new SqlParameter();

                #region orderID
                param.ParameterName = "@orderid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtOrderID.Text);
                cmd.Parameters.Add(param);
                #endregion

                param = new SqlParameter();
                param.ParameterName = "@custid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtCustomerID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@empid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtEmployeeID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@orderdate";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpOrderDate.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@requireddate";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpRequireDate.Value;
                cmd.Parameters.Add(param);

                if (ckNotShip.Checked == true)
                {
                    param = new SqlParameter();
                    param.ParameterName = "@shippeddate";
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);
                }
                else
                {
                    param = new SqlParameter();
                    param.ParameterName = "@shippeddate";
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Value = dtpShipDate.Value;
                    cmd.Parameters.Add(param);
                }

                param = new SqlParameter();
                param.ParameterName = "@shipperid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtShipperID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@freight";
                param.SqlDbType = SqlDbType.Money;
                param.Value = txtFreight.Text;
                cmd.Parameters.Add(param);


                param = new SqlParameter();
                param.ParameterName = "@shipname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = txtShipName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@shipaddress";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 60;
                param.Value = txtShipAddress.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@shipcity";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtShipCity.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@shipregion";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtShipRegion.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@shippostalcode";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 10;
                param.Value = txtShipPostalCode.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@shipcountry";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtShipCountry.Text;
                cmd.Parameters.Add(param);
                #endregion

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update Success");
                LoadDatabase();

                DialogResult rs = MessageBox.Show("Do you update related order detail ????", "Confirm", MessageBoxButtons.YesNoCancel);
                if (rs == DialogResult.Yes)
                {
                    frmOrderDetail frm = new frmOrderDetail();
                    frm.Owner = this;
                    frm.getOrderID(txtOrderID.Text);
                    frm.Show();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                con.Close();
                return;
            }
        }

        public void addNewOrder()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[InsertOrder]";
                cmd.CommandType = CommandType.StoredProcedure;


                #region SQL param
                SqlParameter param = new SqlParameter();

                param = new SqlParameter();
                param.ParameterName = "@custid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtCustomerID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@empid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtEmployeeID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@orderdate";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpOrderDate.Value;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@requireddate";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpRequireDate.Value;
                cmd.Parameters.Add(param);


                if (ckNotShip.Checked == true)
                {
                    param = new SqlParameter();
                    param.ParameterName = "@shippeddate";
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Value = DBNull.Value;
                    cmd.Parameters.Add(param);
                }
                else
                {
                    param = new SqlParameter();
                    param.ParameterName = "@shippeddate";
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Value = dtpShipDate.Value;
                    cmd.Parameters.Add(param);
                }

                param = new SqlParameter();
                param.ParameterName = "@shipperid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtShipperID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@freight";
                param.SqlDbType = SqlDbType.Money;
                param.Value = txtFreight.Text;
                cmd.Parameters.Add(param);


                param = new SqlParameter();
                param.ParameterName = "@shipname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = txtShipName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@shipaddress";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 60;
                param.Value = txtShipAddress.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@shipcity";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtShipCity.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@shipregion";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtShipRegion.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@shippostalcode";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 10;
                param.Value = txtShipPostalCode.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@shipcountry";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtShipCountry.Text;
                cmd.Parameters.Add(param);
                #endregion

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Add Success");
                LoadDatabase();

                #region openForm
                DialogResult rs = MessageBox.Show("Want to add order detail ????", "Confirm", MessageBoxButtons.YesNoCancel);
                if (rs == DialogResult.Yes)
                {
                    string orderID = dgOrder.Rows[dgOrder.RowCount - 1].Cells[0].Value.ToString();
                    frmOrderDetail frm = new frmOrderDetail();
                    frm.Owner = this;
                    frm.getOrderID(orderID);
                    frm.Show();

                    #endregion
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                con.Close();
            }
        }

        private void txtFreight_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back && e.KeyCode != Keys.OemPeriod)
            {
                errorFreight.SetError(txtFreight, "Freight is a number !!!");
                e.SuppressKeyPress = true;
            }
            else
            {
                errorFreight.Clear();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string search = cbxSearch.Text;
            string value = txtSearch.Text.Trim();
            if (txtFrom.Text.Trim() == "" && dtpFrom.Text == "" && dtpTo.Text == "" && txtTo.Text.Trim() == "" 
                && txtSearchName.Text.Trim() == "" && txtSearch.Text.Trim() == "")
            {
                MessageBox.Show("Empty search value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (panelDate.Visible == true)
            {
                DateTime fromDate = dtpFrom.Value;
                DateTime toDate = dtpTo.Value;
                if (DateTime.Compare(fromDate, toDate) != -1)
                {
                    MessageBox.Show("To date must be bigger than From date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (search.Equals("Customer ID"))
            {
                errorProvider1.Clear();
                try
                {

                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[searchCustID]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    #region SQL param

                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter();
                    param.ParameterName = "@custid";
                    param.SqlDbType = SqlDbType.Int;
                    param.Value = txtSearch.Text;
                    cmd.Parameters.Add(param);

                    #endregion

                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    dgOrder.DataSource = table;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (search.Equals("Order Date"))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[searchOrderDate]";
                    cmd.CommandType = CommandType.StoredProcedure;


                    #region SQL param
                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter();
                    param.ParameterName = "@dateFrom";
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Value = dtpFrom.Value.ToShortDateString();
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@dateTo";
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Value = dtpTo.Value.ToShortDateString();
                    cmd.Parameters.Add(param);

                    #endregion
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    dgOrder.DataSource = table;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }

            if (search.Equals("Require Date"))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[searchRequireDate]";
                    cmd.CommandType = CommandType.StoredProcedure;


                    #region SQL param
                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter();
                    param.ParameterName = "@dateFrom";
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Value = dtpFrom.Value.ToShortDateString();
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@dateTo";
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Value = dtpTo.Value.ToShortDateString();
                    cmd.Parameters.Add(param);

                    #endregion
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    dgOrder.DataSource = table;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            if (search.Equals("Ship Date"))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[searchShipDate]";
                    cmd.CommandType = CommandType.StoredProcedure;


                    #region SQL param
                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter();
                    param.ParameterName = "@dateFrom";
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Value = dtpFrom.Value.ToShortDateString();
                    cmd.Parameters.Add(param);


                    param = new SqlParameter();
                    param.ParameterName = "@dateTo";
                    param.SqlDbType = SqlDbType.DateTime;
                    param.Value = dtpTo.Value.ToShortDateString();
                    cmd.Parameters.Add(param);

                    #endregion
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    dgOrder.DataSource = table;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            if (search.Equals("Product Name (Order Detail)"))
            {
                if (txtSearchName.Text.Trim() == "" )
                {
                    MessageBox.Show("Empty search value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                errorProvider1.Clear();
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[searchProductName]";
                    cmd.CommandType = CommandType.StoredProcedure;


                    #region SQL param
                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter();
                    param.ParameterName = "@search";
                    param.SqlDbType = SqlDbType.NVarChar;
                    param.Size = 30;
                    param.Value = txtSearchName.Text;
                    cmd.Parameters.Add(param);

                    #endregion
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    dgOrder.DataSource = table;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            if (search.Equals("Total Value"))
            {
                if (txtFrom.Text.Trim() == "" || txtTo.Text.Trim() == "")
                {
                    MessageBox.Show("Empty search value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                errorProvider1.Clear();
                if (int.Parse(txtFrom.Text) < int.Parse(txtTo.Text))
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "[searchTotal]";
                        cmd.CommandType = CommandType.StoredProcedure;


                        #region SQL param
                        SqlParameter param = new SqlParameter();

                        param = new SqlParameter();
                        param.ParameterName = "@totalFrom";
                        param.SqlDbType = SqlDbType.Int;
                        param.Value = txtFrom.Text;
                        cmd.Parameters.Add(param);

                        param = new SqlParameter();
                        param.ParameterName = "@totalTo";
                        param.SqlDbType = SqlDbType.Int;
                        param.Value = txtTo.Text;
                        cmd.Parameters.Add(param);

                        #endregion
                        DataTable table = new DataTable();
                        table.Load(cmd.ExecuteReader());
                        dgOrder.DataSource = table;
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("To value must bigger than from From value !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


        }


        private void dgOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtOrderID.Enabled = false;
                DataGridViewRow r = dgOrder.SelectedRows[0];
                ClearError();
                Lib order = new Lib(r.Cells[0].Value.ToString(),
                    r.Cells[1].Value.ToString(),
                    r.Cells[2].Value.ToString(),
                    r.Cells[3].Value.ToString(),
                    r.Cells[4].Value.ToString(),
                    r.Cells[5].Value.ToString(),
                    r.Cells[6].Value.ToString(),
                    r.Cells[7].Value.ToString(),
                    r.Cells[8].Value.ToString(),
                    r.Cells[9].Value.ToString(),
                    r.Cells[10].Value.ToString(),
                    r.Cells[11].Value.ToString(),
                    r.Cells[12].Value.ToString(),
                    r.Cells[13].Value.ToString());

                setInfo(order);
            }
            catch (Exception)
            {

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Enabled = true;
            LoadDatabase();
            reset();
        }


        #region pop-up ID
        private void btnSearchEmpID_Click(object sender, EventArgs e)
        {
            frmSearchEmpID frm = new frmSearchEmpID();
            frm.Owner = this;
            frm.Show();
        }

        private void btnSearchCusID_Click(object sender, EventArgs e)
        {
            frmSearchCusID frm = new frmSearchCusID();
            frm.Owner = this;
            frm.Show();
        }

        private void btnSearchShipID_Click(object sender, EventArgs e)
        {
            frmSearchShipID frm = new frmSearchShipID();
            frm.Owner = this;
            frm.Show();
        }
        #endregion

        private void frmOrder_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void BtnOrderDetail_Click(object sender, EventArgs e)
        {
            if (txtOrderID.Text.Trim() == "")
            {
                MessageBox.Show("Please select an order!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                frmOrderDetail frm = new frmOrderDetail();
                frm.Owner = this;
                frm.getOrderID(txtOrderID.Text);
                frm.Show();
            }

        }

        private void cbxSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxSearch.Text.Equals("Customer ID"))
            {
                panelText.Show();
                panelDate.Hide();
                panel2Text.Hide();
                panelName.Hide();
            }
            else if (cbxSearch.Text.Equals("Product Name (Order Detail)"))
            {
                panelText.Hide();
                panelDate.Hide();
                panel2Text.Hide();
                panelName.Show();
            }
            else if (cbxSearch.Text.Equals("Total Value"))
            {
                panelText.Hide();
                panelDate.Hide();
                panel2Text.Show();
                panelName.Hide();
            }
            else
            {
                panelText.Hide();
                panelDate.Show();
                panel2Text.Hide();
                panelName.Hide();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back)
            {
                errorProvider1.SetError(txtSearch, "Must be a number !!!");
                e.SuppressKeyPress = true;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void ckNotShip_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckNotShip.Checked == false)
            {
                dtpShipDate.Enabled = true;
            }
            else
            {
                dtpShipDate.Enabled = false;
                
            }
        }

        private void txtTo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back)
            {
                errorProvider1.SetError(btnSearch, "Must be a number !!!");
                e.SuppressKeyPress = true;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back)
            {
                errorProvider1.SetError(btnSearch, "Must be a number !!!");
                e.SuppressKeyPress = true;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            
        }
    }
}
