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
    public partial class employeeDetailForm : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;
        string searchValue;

        public employeeDetailForm()
        {
            InitializeComponent();
            cbbSearchBy.SelectedIndex = 0;
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            loadData();
        }

        public void showDataFromSource(SqlDataReader dr)
        {
            while (dr.Read())
            {
                dgEmployees.Rows.Add(dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2].ToString(),
                    dr[3].ToString(),
                    dr[4].ToString(),
                    DateTime.Parse(dr[5].ToString()).ToShortDateString(),
                    DateTime.Parse(dr[6].ToString()).ToShortDateString(),
                    dr[7].ToString(),
                    dr[8].ToString(),
                    dr[9].ToString(),
                    dr[10].ToString(),
                    dr[11].ToString(),
                    dr[12].ToString(),
                    dr[13].ToString());
            }
            dr.Close();
        }
        public void loadData()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[getAllEmployee]";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                dgEmployees.Rows.Clear();
                showDataFromSource(dr);                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            txtSearchValue.Clear();
        }

        #region Search Functions
        void searchByLastname()
        {
            try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[searchByLastnameEmployee]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = '%' + searchValue + '%';

                    SqlDataReader result = cmd.ExecuteReader();
                    dgEmployees.Rows.Clear();
                    showDataFromSource(result);
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
        void searchByFirstname()
        {
            try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[searchByFirstnameEmployee]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = '%' + searchValue + '%';

                    SqlDataReader result = cmd.ExecuteReader();
                    dgEmployees.Rows.Clear();
                    showDataFromSource(result);
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
       
      
      
        void searchByBirthday()
        {
            if (dtpFROM.Value >= dtpTO.Value)
            {
                MessageBox.Show("Invalid date range! Please check again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[searchByBirthday]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("fromDate", SqlDbType.DateTime).Value = dtpFROM.Value;
                cmd.Parameters.Add("toDate", SqlDbType.DateTime).Value = dtpTO.Value;

                SqlDataReader result = cmd.ExecuteReader();
                dgEmployees.Rows.Clear();
                showDataFromSource(result);
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
        #endregion
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchValue = txtSearchValue.Text.ToUpper();
            int searchCol = cbbSearchBy.SelectedIndex;
            if (searchCol < 2 && searchValue.Length == 0)
            {
                MessageBox.Show("Empty search value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (searchCol)
            {
                case 0: searchByLastname();
                    break;
                case 1:searchByFirstname();
                    break;
                case 2:searchByBirthday();
                    break;
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DataGridViewRow r = dgEmployees.SelectedRows[0];           
                DialogResult result = MessageBox.Show("Do you want to delete this row?", "Confirm deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[removeEmployee]";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "empid";
                    param.Value = int.Parse(r.Cells[0].Value.ToString());
                    cmd.Parameters.Add(param);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            dgEmployees.Rows.Clear();
            loadData();
        }

        private void bnNew_Click(object sender, EventArgs e)
        {
            employeeInputForm inputForm = new employeeInputForm();
            inputForm.Owner = this;
    
            inputForm.ShowDialog();
            dgEmployees.Rows.Clear();
            loadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose 1 row!");
                return;
            }
            employeeInputForm inputForm = new employeeInputForm();
            inputForm.Owner = this;
            DataGridViewRow r = dgEmployees.SelectedRows[0];
            inputForm.setInfo(r.Cells["lastname"].Value.ToString(), r.Cells["firstname"].Value.ToString(),
                r.Cells["courtesy"].Value.ToString(), DateTime.Parse(r.Cells["birthday"].Value.ToString()), 
                DateTime.Parse(r.Cells["hireDate"].Value.ToString()),
                r.Cells["Title"].Value.ToString(), r.Cells["mgrid"].Value.ToString(), r.Cells["phone"].Value.ToString(),
                r.Cells["postalCode"].Value.ToString(), r.Cells["address"].Value.ToString(), r.Cells["City"].Value.ToString(),
                r.Cells["country"].Value.ToString(), r.Cells["region"].Value.ToString(), int.Parse(r.Cells["emID"].Value.ToString()));
            inputForm.ShowDialog();
            dgEmployees.Rows.Clear();
            loadData();
        }

        private void cbbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSearchBy.SelectedIndex < 2)
            {
                gbName.Visible = true;
                gbDOB.Visible = false;
            } else
            {
                gbDOB.Visible = true;
                gbName.Visible = false;
            }
        }
    }
}
