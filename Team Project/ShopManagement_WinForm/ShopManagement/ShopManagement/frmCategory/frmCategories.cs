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
    public partial class frmCategories : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        bool isNew;
        public frmCategories()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            LoadDataFromDatabase();
            isNew = true;
        }

        public void LoadDataFromDatabase()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Categories.SelectAll]";
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                dgCategory.DataSource = table;
                 
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

        bool isValidData()
        {
            string name = txtCategoryName.Text.Trim();
            string description = txtDescription.Text.Trim();
            bool isError = false;
            if (name.Length == 0)
            {
                isError = true;
                errCategoryName.SetError(txtCategoryName, "Name must not be empty!");
            }
            else
                errCategoryName.Clear();
            if (description.Length == 0)
            {
                isError = true;
                errDescription.SetError(txtDescription, "Description must not be empty!");
            }
            else
                errDescription.Clear();
            return !isError;
        }

        void ClearError()
        {
            errCategoryName.Clear();
            errDescription.Clear();
        }

        void SetData(string id, string name, string description)
        {
            ClearError();
            txtCategoryID.Text = id;
            txtCategoryName.Text = name;
            txtDescription.Text = description;
        }

     
        void AddNewCategory()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Categories.Insert]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "categoryname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtCategoryName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "description";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 200;
                param.Value = txtDescription.Text;
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

        void UpdateCurrentCategory()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Categories.Update]";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "categoryid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtCategoryID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "categoryname";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 15;
                param.Value = txtCategoryName.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "description";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 200;
                param.Value = txtDescription.Text;
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
                reader = cmd.ExecuteReader();
                table.Load(reader);
                dgCategory.DataSource = table;
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                reader.Close();
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
            SearchByName(searchValue);           
            btnClear_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            txtSearchValue.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgCategory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a category!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCategoryID.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select a category!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow row = dgCategory.SelectedRows[0];
            DialogResult dialogResult = MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[Categories.Delete]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "categoryid";
                    param.SqlDbType = SqlDbType.Int;
                    param.Value = int.Parse(txtCategoryID.Text);
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Delete successfully!", "Information");
                    if (txtSearchValue.Text.Trim().Length > 0)
                        btnSearch_Click(sender, e);
                    else
                        LoadDataFromDatabase();
                    SetData("", "", "");
                    isNew = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
               
            }


            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidData())
            {
                if (isNew)
                {
                    AddNewCategory();
                }
                else
                {
                    UpdateCurrentCategory();
                }
                LoadDataFromDatabase();
                btnClear_Click(sender, e);  
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SetData("", "", "");
            isNew = true;
        }

        private void dgCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgCategory.CurrentRow;
            if (row != null)
            {
                SetData(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(),
                        row.Cells[2].Value.ToString());
                isNew = false;
            }
        }
    }
}
