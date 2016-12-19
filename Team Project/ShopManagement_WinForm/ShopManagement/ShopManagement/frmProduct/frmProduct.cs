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
    public partial class frmProduct : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        bool isNew;

        public frmProduct()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            LoadDataFromDatabase();
            isNew = true;
            cbbSearchType.SelectedIndex = 0;
            dgProducts.Columns[2].Visible = false;
            dgProducts.Columns[3].Visible = false;
        }

        public void LoadDataFromDatabase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.SelectAll2]";
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                dgProducts.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }

        void SetData(string id, string name, string supplierID, string categoryID, string unitPrice, bool status)
        {
            txtProductID.Text = id;
            txtProductName.Text = name;
            txtSupplierID.Text = supplierID;
            txtCategoryID.Text = categoryID;
            txtUnitPrice.Text = unitPrice;
            chkDiscontinued.Checked = status;
        }

        void ClearError()
        {
            errCategoryID.Clear();
            errProductName.Clear();
            errSearch1.Clear();
            errSupplierID.Clear();
        }

        void SetStatus(bool state)
        {
            chkDiscontinued.Visible = state;
            lblStatus.Visible = state;
        }

        public void SetSupplierID(string id)
        {
            txtSupplierID.Text = id;
        }
        public void SetCategoryID(string id)
        {
            txtCategoryID.Text = id;
        }

        #region Check validation 
        bool isIdNumber(string value)
        {
            try
            {
                int.Parse(value);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        bool isValidFloat(string str)
        {
            try
            {
                float f = float.Parse(str);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        bool isValidData()
        {
            string name = txtProductName.Text.Trim();
            string supID = txtSupplierID.Text.Trim();
            string catID = txtCategoryID.Text.Trim();
            string unitprice = txtUnitPrice.Text.Trim();
            bool status = chkDiscontinued.Checked;

            bool isError = false;
            if (name.Length == 0)
            {
                isError = true;
                errProductName.SetError(txtProductName, "Name must not be empty!");
            }
            else
                errProductName.Clear();
            if (supID.Length == 0)
            {
                isError = true;
                errSupplierID.SetError(btnChooseSupplier, "Supplier must be choiced!");
            }
            else
                errSupplierID.Clear();
            if (catID.Length == 0)
            {
                isError = true;
                errCategoryID.SetError(btnChooseCategory, "CategoryID must be choiced!");
            }
            else
                errCategoryID.Clear();
            if (!isValidFloat(unitprice) || float.Parse(unitprice) <= 0)
            {
                isError = true;
                errSearch1.SetError(txtUnitPrice, "Unit price must be number greater than 0");
            }
            else
            {
                errSearch1.Clear();
            }

            return !isError;
        }
        #endregion

        #region Search Function
        void SearchByName(string value)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.SearchByName2]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "productname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = value;
                cmd.Parameters.Add(param);

                DataTable table = new DataTable();
                reader = cmd.ExecuteReader();
                table.Load(reader);
                dgProducts.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
        void SearchByUnitPrice(string value1, string value2)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.SearchByUnitPrice2]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "fromprice";
                param.SqlDbType = SqlDbType.Money;
                param.Value = float.Parse(value1);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "toprice";
                param.SqlDbType = SqlDbType.Money;
                param.Value = float.Parse(value2);
                cmd.Parameters.Add(param);

                DataTable table = new DataTable();
                reader = cmd.ExecuteReader();
                table.Load(reader);
                dgProducts.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
        //void SearchBySupID(int value)
        //{
        //    try
        //    {
        //        con.Open();
        //        cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "[Product.SearchBySupplierID]";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter param = new SqlParameter();
        //        param.ParameterName = "supplierid";
        //        param.SqlDbType = SqlDbType.Int;
        //        param.Value = value;
        //        cmd.Parameters.Add(param);

        //        DataTable table = new DataTable();
        //        reader = cmd.ExecuteReader();
        //        table.Load(reader);
        //        dgProducts.DataSource = table;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        reader.Close();
        //        con.Close();
        //    }
        //}
        //void SearchByCatID(int value)
        //{
        //    try
        //    {
        //        con.Open();
        //        cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "[Product.SearchByCategoryID]";
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter param = new SqlParameter();
        //        param.ParameterName = "categoryid";
        //        param.SqlDbType = SqlDbType.Int;
        //        param.Value = value;
        //        cmd.Parameters.Add(param);

        //        DataTable table = new DataTable();
        //        reader = cmd.ExecuteReader();
        //        table.Load(reader);
        //        dgProducts.DataSource = table;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    finally
        //    {
        //        reader.Close();
        //        con.Close();
        //    }
        //}

        void SearchBySupName(string value)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.SearchBySupplierCompany]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "company";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = value;
                cmd.Parameters.Add(param);

                DataTable table = new DataTable();
                reader = cmd.ExecuteReader();
                table.Load(reader);
                dgProducts.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }

        void SearchByCatName(string value)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.SearchByCategoryName]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "categoryname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = value;
                cmd.Parameters.Add(param);

                DataTable table = new DataTable();
                reader = cmd.ExecuteReader();
                table.Load(reader);
                dgProducts.DataSource = table;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
        #endregion

        #region Add Delete Update
        void AddNewProduct()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.Insert]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "productname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = txtProductName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "supplierid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtSupplierID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "categoryid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtCategoryID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "unitprice";
                param.SqlDbType = SqlDbType.Money;
                param.Value = float.Parse(txtUnitPrice.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "discontinued";
                param.SqlDbType = SqlDbType.Bit;
                param.Value = chkDiscontinued.Checked;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Add successfully!", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }
        void UpdateProduct()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Product.Update]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "productid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtProductID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "productname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 40;
                param.Value = txtProductName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "supplierid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtSupplierID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "categoryid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtCategoryID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "unitprice";
                param.SqlDbType = SqlDbType.Money;
                param.Value = float.Parse(txtUnitPrice.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "discontinued";
                param.SqlDbType = SqlDbType.Bit;
                param.Value = chkDiscontinued.Checked;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update successfully!", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        void DeleteProduct()
        {
            if (dgProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtProductID.Text.Length == 0)
            {
                MessageBox.Show("Please select a product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow row = dgProducts.SelectedRows[0];
            if (row != null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "[Product.Delete]";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "productid";
                        param.SqlDbType = SqlDbType.Int;
                        param.Value = int.Parse(txtProductID.Text);
                        cmd.Parameters.Add(param);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Delete successfully!", "Information");
                        LoadDataFromDatabase();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }

                }
            }
        }
        #endregion

        private void dgProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgProducts.CurrentRow;
            if (row != null)
            {
                ClearError();
                SetData(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(),
                        row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(),
                        row.Cells[6].Value.ToString(), (bool)row.Cells[7].Value);
                isNew = false;
                SetStatus(true);
            }
        }

        private void btnChooseSupplier_Click(object sender, EventArgs e)
        {
            frmProduct_SearchSupplier sup = new frmProduct_SearchSupplier();
            sup.Owner = this;
            sup.ShowDialog();
        }

        private void btnChooseCategory_Click(object sender, EventArgs e)
        {
            frmProduct_SearchCategory cat = new frmProduct_SearchCategory();
            cat.Owner = this;
            cat.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                if (isNew)
                {
                    AddNewProduct();
                    LoadDataFromDatabase();
                    SetData("", "", "", "", "", false);
                }
                else
                {
                    UpdateProduct();
                    LoadDataFromDatabase();
                }
                btnClear_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int index = cbbSearchType.SelectedIndex;
            bool isValid1, isValid2;
            string value1 = txtSearchValue.Text.Trim();
            string value2 = txtSearchValue2.Text.Trim();
            if (index != 1 && value1.Length == 0)
            {
                MessageBox.Show("Empty search value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (index)
            {
                case 0:
                    SearchByName(value1);
                    break;
                case 1:
                    if (value1.Length == 0 || value2.Length == 0)
                    {
                        MessageBox.Show("Empty search value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    isValid1 = isValidFloat(value1);
                    isValid2 = isValidFloat(value2);
                    if (isValid1 && isValid2)
                    {
                        if (float.Parse(value1) > float.Parse(value2))
                        {
                            errSearch1.SetError(txtSearchValue, "Unit price from must be bigger than unit price to");
                        }
                        else
                        {
                            errSearch1.Clear();
                            errSearch2.Clear();
                            SearchByUnitPrice(value1, value2);
                        }
                    }
                    else
                    {
                        if (!isValid1)
                            errSearch1.SetError(txtSearchValue, "Unit price must be number");
                        if (!isValid2)
                            errSearch2.SetError(txtSearchValue2, "Unit price must be number");
                    }
                    break;
                case 2:
                    errSearch1.Clear();
                    errSearch2.Clear();
                    SearchBySupName(value1);
                    break;

                case 3:
                    errSearch1.Clear();
                    errSearch2.Clear();
                    SearchByCatName(value1);
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            txtSearchValue.Text = "";
            txtSearchValue2.Text = "";
            errSearch1.Clear();
            errSearch2.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SetData("", "", "", "", "", false);
            ClearError();
            SetStatus(false);
            isNew = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct();
            btnClear_Click(sender, e);
        }

        private void cbbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSearchType.SelectedIndex == 1)
            {
                lblToMoney.Visible = true;
                txtSearchValue2.Visible = true;
            }
            else
            {
                lblToMoney.Visible = false;
                txtSearchValue2.Visible = false;
            }
        }
    }
}
