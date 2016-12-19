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
    public partial class employeeInputForm : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        bool isAdd;
        int empID;
        public employeeInputForm()
        {
            InitializeComponent();
            con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            isAdd = true;
            cbbCountry.SelectedIndex = 0;
            cbbCourtecy.SelectedIndex = 0;
            txtMngID.Enabled = false;
            btnClearMngID.Visible = false;
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        bool isValidData()
        {
            string lastname = txtLastName.Text.Trim();
            string firstname = txtFirstName.Text.Trim();
            string title = txtTitle.Text.Trim();
            string phone = mtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string city = txtCity.Text.Trim();
            DateTime currDay = DateTime.Now;
            int curYear = currDay.Year;
            DateTime DOB = dpkBirthday.Value;
            int birthYear = DOB.Year;
            DateTime hireDay = dpkHireDate.Value;
            int hireYear = hireDay.Year;
            int age = curYear - birthYear;
            bool isError = false;
            if (lastname.Length == 0)
            {
                isError = true;
                errLastName.SetError(txtLastName, "Last name must not be empty!");
            }
            else
                errLastName.Clear();
            if (firstname.Length == 0)
            {
                isError = true;
                errFirstname.SetError(txtFirstName, "First name must not be empty!");
            }
            else
                errFirstname.Clear();

            if (age<18)
            {
                isError = true;
                errBirthday.SetError(dpkBirthday, "Employee's age must be greater than 18!");
            }
            else
                errBirthday.Clear();
            if (DOB > hireDay)
            {
                isError = true;
                errHireday.SetError(dpkHireDate, "Hire day must be greater than birthday!");
            } else if (hireYear - birthYear < 18)
            {
                isError = true;
                errHireday.SetError(dpkHireDate, "Employee's age must be greater than 18!");
            }
            else
                errHireday.Clear();

            if (title.Length == 0)
            {
                isError = true;
                errTitle.SetError(txtTitle, "Description must not be empty!");
            }
            else
                errTitle.Clear();
            
            if (phone.Length == 0)
            {
                isError = true;
                errPhone.SetError(mtPhone, "Description must not be empty!");
            }
            else
                errPhone.Clear();
            if (address.Length == 0)
            {
                isError = true;
                errAddress.SetError(txtAddress, "Description must not be empty!");
            }
            else
                errAddress.Clear();

            if (city.Length == 0)
            {
                isError = true;
                errCity.SetError(txtCity, "Description must not be empty!");
            }
            else
                errCity.Clear();
            return !isError;
        }
        void addEmployee()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[insertEmployee]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("lastname", SqlDbType.NVarChar).Value = txtLastName.Text;
                cmd.Parameters.Add("firstname", SqlDbType.NVarChar).Value = txtFirstName.Text;
                cmd.Parameters.Add("title", SqlDbType.NVarChar).Value = txtTitle.Text;
                cmd.Parameters.Add("titleofcourtecy", SqlDbType.NVarChar).Value = cbbCourtecy.Text;
                cmd.Parameters.Add("birthdate", SqlDbType.DateTime).Value = dpkBirthday.Value.ToShortDateString();
                cmd.Parameters.Add("hiredate", SqlDbType.DateTime).Value = dpkHireDate.Value.ToShortDateString();
                cmd.Parameters.Add("address", SqlDbType.NVarChar).Value = txtAddress.Text;
                cmd.Parameters.Add("city", SqlDbType.NVarChar).Value = txtCity.Text;
                cmd.Parameters.Add("region", SqlDbType.NVarChar).Value = txtRegion.Text;
                cmd.Parameters.Add("postalcode", SqlDbType.NVarChar).Value = mtPostalCode.Text;
                cmd.Parameters.Add("country", SqlDbType.NVarChar).Value = cbbCountry.Text;
                cmd.Parameters.Add("phone", SqlDbType.NVarChar).Value = mtPhone.Text;
                if (txtMngID.Text.Length != 0)
                {
                    cmd.Parameters.Add("mgrid", SqlDbType.NVarChar).Value = txtMngID.Text;
                } else
                {
                    cmd.Parameters.Add("mgrid", SqlDbType.NVarChar).Value = (object)DBNull.Value;
                }
                cmd.ExecuteNonQuery();
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
        void updateEmployee()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[updateEmployee]";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("empid", SqlDbType.NVarChar).Value = empID;
                cmd.Parameters.Add("lastname", SqlDbType.NVarChar).Value = txtLastName.Text;
                cmd.Parameters.Add("firstname", SqlDbType.NVarChar).Value = txtFirstName.Text;
                cmd.Parameters.Add("title", SqlDbType.NVarChar).Value = txtTitle.Text;
                cmd.Parameters.Add("titleofcourtecy", SqlDbType.NVarChar).Value = cbbCourtecy.Text;
                cmd.Parameters.Add("birthdate", SqlDbType.DateTime).Value = dpkBirthday.Value.ToShortDateString();
                cmd.Parameters.Add("hiredate", SqlDbType.DateTime).Value = dpkHireDate.Value.ToShortDateString();
                cmd.Parameters.Add("address", SqlDbType.NVarChar).Value = txtAddress.Text;
                cmd.Parameters.Add("city", SqlDbType.NVarChar).Value = txtCity.Text;
                cmd.Parameters.Add("region", SqlDbType.NVarChar).Value = txtRegion.Text;
                cmd.Parameters.Add("postalcode", SqlDbType.NVarChar).Value = mtPostalCode.Text;
                cmd.Parameters.Add("country", SqlDbType.NVarChar).Value = cbbCountry.Text;
                cmd.Parameters.Add("phone", SqlDbType.NVarChar).Value = mtPhone.Text;
                if (txtMngID.Text.Length != 0)
                {
                    cmd.Parameters.Add("mgrid", SqlDbType.NVarChar).Value = txtMngID.Text;
                }
                else
                {
                    cmd.Parameters.Add("mgrid", SqlDbType.NVarChar).Value = (object)DBNull.Value;
                }
                cmd.ExecuteNonQuery();
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
        public void setInfo(string lastname, string firstname, string courtesy,
            DateTime birthday, DateTime hireday, string title, string mngID,
            string phone, string postal, string address, string city, string country,
            string region, int empid)
        {
            txtLastName.Text = lastname;
            txtFirstName.Text = firstname;
            cbbCourtecy.Text = courtesy;
            dpkBirthday.Value = birthday;
            dpkHireDate.Value = hireday;
            txtTitle.Text = title;
            txtMngID.Text = mngID;
            mtPhone.Text = phone;
            mtPostalCode.Text = postal;
            txtAddress.Text = address;
            txtCity.Text = city;
            cbbCountry.Text = country;
            txtRegion.Text = region;

            isAdd = false;
            empID = empid;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isValidData())
            {
                return;
            }
            if (isAdd)
            {
                addEmployee();
                this.Close();
            } else
            {
                updateEmployee();
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLastName.Text = "";
            txtFirstName.Text = "";
            cbbCourtecy.SelectedIndex = 0;
            dpkBirthday.Value = DateTime.Now;
            dpkHireDate.Value = DateTime.Now;
            txtTitle.Text = "";
            txtMngID.Text = "";
            mtPhone.Text = "";
            mtPostalCode.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            cbbCountry.SelectedIndex = 0;
            txtRegion.Text = "";
            errAddress.Clear();
            errBirthday.Clear();
            errCity.Clear();
            errFirstname.Clear();
            errHireday.Clear();
            errLastName.Clear();
            errTitle.Clear();
        }
        public void setMngerID(string mngerID)
        {
            txtMngID.Text = mngerID;
        }
        private void btnLink_Click(object sender, EventArgs e)
        {
            mngerChooseForm form = new mngerChooseForm();
            form.Owner = this;
            if (!isAdd)
            {
                form.CurEmpID = empID;
            } else
            {
                form.CurEmpID = -1;
            }
            form.LoadDatabase();
            form.ShowDialog();
        }

        private void btnClearMngID_Click(object sender, EventArgs e)
        {
            txtMngID.Text = "";
            btnClearMngID.Visible = false;
        }

        private void txtMngID_TextChanged(object sender, EventArgs e)
        {
            if (txtMngID.Text.Length > 0)
            {
                btnClearMngID.Visible = true;
            } 
        }
    }
}
