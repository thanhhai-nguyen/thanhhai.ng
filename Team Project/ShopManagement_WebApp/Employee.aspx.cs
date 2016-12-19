using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class Employee : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;



    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        if (this.IsPostBack == false)
        {
            ViewState["mode"] = true;
            LoadEmployees();
            //BindCountry();
        }
        AlertBox.Visible = false;
        lblSearchError.Text = "";
        lblLastName.Visible = false;
        lblFirstName.Visible = false;
        lblAddress.Visible = false;
        lblCity.Visible = false;
        lblDate.Visible = false;
        lblHired.Visible = false;
        lblPhone.Visible = false;
        lblTitle.Visible = false;
    }

    //private void BindCountry()
    //{
    //    try
    //    {
    //        XmlDocument doc = new XmlDocument();
    //        doc.Load(Server.MapPath("countries.xml"));

    //        foreach (XmlNode node in doc.SelectNodes("//country"))
    //        {
    //            ddlCountry.Items.Add(new ListItem(node.InnerText, node.Attributes["code"].InnerText));
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        SetAlertBox(e.Message, "alert");
    //    }
        
    //}
    void showDB(SqlDataReader dr)
    {
        DataTable dt = new DataTable();
        dt.Load(dr);

        gvEmployee.AllowPaging = true;
        ViewState.Add("Ems", dt);

        gvEmployee.DataSource = dt;
        gvEmployee.DataBind();
        txtID.Enabled = false;

        DataTable dts = new DataTable();
        dts.Columns.Add("name", typeof(String));
        dts.Columns.Add("empid", typeof(int));
        DataRow wRow = dts.NewRow();
        wRow["name"] = "-- Select manager for employee -- ";
        wRow["empid"] = "-1";
        dts.Rows.Add(wRow);
        foreach (DataRow row in dt.Rows)
        {
            wRow = dts.NewRow();
            wRow["name"] = (string)row[1] + " " + (string)row[2];
            wRow["empid"] = row[0];
            dts.Rows.Add(wRow);
        }
        ddlManagerID.DataSource = dts;
        ddlManagerID.DataTextField = "name";
        ddlManagerID.DataValueField = "empid";
        ddlManagerID.DataBind();
        dr.Close();


    }
    void LoadEmployees()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[getAllEmployee]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            showDB(dr);
        }
        catch (Exception e)
        {
            string msg = e.Message.Replace('\'', '"');
            // Write to log of browser
            Response.Write("<script type=\"text/javascript\" >console.log('" + msg + "')</script>");
            // Send redirect to 404
            Response.Redirect("ErrorPage.html");
        }
        finally
        {
            con.Close();
        }
    }
    protected void gvEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = gvEmployee.SelectedRow;
        SetInfo(r.Cells[0].Text);
    }
    void SetInfo(string empid)
    {
        DataTable table = (DataTable)ViewState["Ems"];
        ViewState["mode"] = false;
        foreach (DataRow r in table.Rows)
        {
            if (r[0].ToString().Equals(empid))
            {
                txtID.Text = r[0].ToString();
                txtLaName.Text = r[1].ToString();
                txtFirName.Text = r[2].ToString();
                ddlCourtesy.SelectedValue = r[4].ToString();
                txtTitle.Text = r[3].ToString();
                txtDOB.TextMode = TextBoxMode.SingleLine;
                txtDOB.Text = DateTime.Parse(r[5].ToString()).ToShortDateString();
                //DateTime bDay = DateTime.Parse(r[5].ToString());                
                //txtDOB.Text = bDay.Day+"/"+bDay.Month+"/"+bDay.Year;
                txtHiredate.TextMode = TextBoxMode.SingleLine;
                txtHiredate.Text = DateTime.Parse(r[6].ToString()).ToShortDateString();
                //DateTime hDay = DateTime.Parse(r[6].ToString());
                //txtHiredate.Text = hDay.Day + "/" + hDay.Month + "/" + hDay.Year;
                txtPhone.Text = r[12].ToString();
                txtAddress.Text = r[7].ToString();
                txtCity.Text = r[8].ToString();
                ddlCountry.SelectedValue = r[11].ToString();
                txtRegion.Text = r[9].ToString();
                txtPostal.Text = r[10].ToString();
                if (r[13].ToString().Length > 0)
                    ddlManagerID.SelectedValue = r[13].ToString();
                else
                {
                    ddlManagerID.SelectedIndex = 0;
                }
                return;
            }
        }
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
            cmd.Parameters.Add("lastname", SqlDbType.NVarChar).Value = txtLaName.Text;
            cmd.Parameters.Add("firstname", SqlDbType.NVarChar).Value = txtFirName.Text;
            cmd.Parameters.Add("title", SqlDbType.NVarChar).Value = txtTitle.Text;
            cmd.Parameters.Add("titleofcourtecy", SqlDbType.NVarChar).Value = ddlCourtesy.Text;
            cmd.Parameters.Add("birthdate", SqlDbType.DateTime).Value = DateTime.Parse(txtDOB.Text);
            cmd.Parameters.Add("hiredate", SqlDbType.DateTime).Value = DateTime.Parse(txtHiredate.Text);
            cmd.Parameters.Add("address", SqlDbType.NVarChar).Value = txtAddress.Text;
            cmd.Parameters.Add("city", SqlDbType.NVarChar).Value = txtCity.Text;
            cmd.Parameters.Add("region", SqlDbType.NVarChar).Value = txtRegion.Text;
            cmd.Parameters.Add("postalcode", SqlDbType.NVarChar).Value = txtPostal.Text;
            cmd.Parameters.Add("country", SqlDbType.NVarChar).Value = ddlCountry.SelectedValue;
            cmd.Parameters.Add("phone", SqlDbType.NVarChar).Value = txtPhone.Text;
            if (ddlManagerID.SelectedValue.Equals("-1"))
            {
                cmd.Parameters.Add("mgrid", SqlDbType.Int).Value = (Object)DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("mgrid", SqlDbType.Int).Value = ddlManagerID.SelectedValue;
            }

            cmd.ExecuteNonQuery();
            SetAlertBox("Add successfully!", "alert alert-success");
        }
        catch (Exception ex)
        {
            SetAlertBox("Add failed!" + ex.Message, "alert");
        }
        finally
        {
            con.Close();
        }
    }
    void SetAlertBox(string message, string className)
    {
        lblMessage.Text = message;
        AlertBox.CssClass = className;
        AlertBox.Visible = true;
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
            cmd.Parameters.Add("empid", SqlDbType.NVarChar).Value = txtID.Text;
            cmd.Parameters.Add("lastname", SqlDbType.NVarChar).Value = txtLaName.Text;
            cmd.Parameters.Add("firstname", SqlDbType.NVarChar).Value = txtFirName.Text;
            cmd.Parameters.Add("title", SqlDbType.NVarChar).Value = txtTitle.Text;
            cmd.Parameters.Add("titleofcourtecy", SqlDbType.NVarChar).Value = ddlCourtesy.Text;
            cmd.Parameters.Add("birthdate", SqlDbType.DateTime).Value = DateTime.Parse(txtDOB.Text);
            cmd.Parameters.Add("hiredate", SqlDbType.DateTime).Value = DateTime.Parse(txtHiredate.Text);
            cmd.Parameters.Add("city", SqlDbType.NVarChar).Value = txtCity.Text;
            cmd.Parameters.Add("address", SqlDbType.NVarChar).Value = txtAddress.Text;
            cmd.Parameters.Add("region", SqlDbType.NVarChar).Value = txtRegion.Text;
            cmd.Parameters.Add("postalcode", SqlDbType.NVarChar).Value = txtPostal.Text;
            cmd.Parameters.Add("country", SqlDbType.NVarChar).Value = ddlCountry.SelectedValue.ToString();
            cmd.Parameters.Add("phone", SqlDbType.NVarChar).Value = txtPhone.Text;
            if (ddlManagerID.SelectedValue.Equals("-1"))
            {
                cmd.Parameters.Add("mgrid", SqlDbType.Int).Value = (Object)DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("mgrid", SqlDbType.Int).Value = ddlManagerID.SelectedValue;
            }
            cmd.ExecuteNonQuery(); SetAlertBox("Update successfully!", "alert alert-success");
        }
        catch (Exception e)
        {
            SetAlertBox("Update failed!" + e.Message, "alert");
        }
        finally
        {
            con.Close();
        }
    }
    void removeEmpInDB(string empID)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[removeEmployee]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("empid", SqlDbType.Int).Value = int.Parse(empID);
            cmd.ExecuteNonQuery();
            SetAlertBox("Delete succesfully!", "alert alert-success");
        }
        catch (Exception e)
        {
            SetAlertBox("Delete failed. This employee is doing some task(s)!" + e.Message, "alert");
        }
        finally
        {
            con.Close();
        }
    }
    protected void gvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }
        GridViewRow r = gvEmployee.Rows[e.RowIndex];
        ViewState["CurrentRow"] = e.RowIndex;
        DialogConfirm.Visible = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (validation())
        {
            bool isNew = bool.Parse(ViewState["mode"] + "");
            if (isNew)
            {
                addEmployee();
            }
            else
            {
                updateEmployee();
            }
            LoadEmployees();
            btnClear_Click(sender, e);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtID.Text = "";
        txtLaName.Text = "";
        txtFirName.Text = "";
        ddlCourtesy.SelectedIndex = 0;
        txtDOB.Text = "";
        txtHiredate.Text = "";
        txtTitle.Text = "";
        ddlManagerID.SelectedIndex = 0;
        txtPhone.Text = "";
        txtPostal.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        ddlCountry.SelectedIndex = 0;
        txtRegion.Text = "";
        txtDOB.TextMode = TextBoxMode.Date;
        txtHiredate.TextMode = TextBoxMode.Date;
        ViewState["mode"] = true;
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        int currRow = int.Parse(ViewState["CurrentRow"] + "");
        if (currRow < 0)
        {
            return;
        }
        GridViewRow r = gvEmployee.Rows[currRow];
        removeEmpInDB(r.Cells[0].Text);
        //Clear
        btnClear_Click(sender, e);
        LoadEmployees();
        DialogConfirm.Visible = false;
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        DialogConfirm.Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblSearchError.Text = "";
        btnClear_Click(sender, e);
        if (searchBy.SelectedIndex == 0)
        {
            lblSearchError.Text = "Please choose search method!";
            lblSearchError.Visible = true;
        }
        else
        if (searchBy.SelectedIndex == 1)
        {
            if (txtSearchVl1.Text.Length == 0)
            {
                lblSearchError.Text = "Error! No search value!";
                lblSearchError.Visible = true;
            }
            else
            {
                searchByLastname();
            }
        }
        else
        if (searchBy.SelectedIndex == 2)
        {
            if (txtSearchVl1.Text.Length == 0)
            {
                lblSearchError.Text = "Error! No search value!";
                lblSearchError.Visible = true;
            }
            else
            {
                searchByFirstname();
            }
        }
        else
        if (searchBy.SelectedIndex == 3)
        {
            if (txtSearchVl1.Text.Length == 0 || txtSearchVl2.Text.Length == 0)
            {
                lblSearchError.Text = "Error! Please enter from date and start date!";
                lblSearchError.Visible = true;
            }
            else
            {
                searchByBirthday();
            }
        }
    }
    void searchByLastname()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[searchByLastnameEmployee]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = '%' + txtSearchVl1.Text + '%';

            SqlDataReader result = cmd.ExecuteReader();
            showDB(result);
        }
        catch (Exception e)
        {
            SetAlertBox(e.Message, "alert");
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
            cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = '%' + txtSearchVl1.Text + '%';

            SqlDataReader result = cmd.ExecuteReader();
            showDB(result);
        }
        catch (Exception e)
        {
            SetAlertBox(e.Message, "alert");
        }
        finally
        {
            con.Close();
        }
    }
    void searchByBirthday()
    {
        if (DateTime.Parse(txtSearchVl1.Text) >= DateTime.Parse(txtSearchVl2.Text))
        {
            lblSearchError.Text = "Invalid date range! Please check again!";
            return;
        }
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[searchByBirthday]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("fromDate", SqlDbType.DateTime).Value = DateTime.Parse(txtSearchVl1.Text);
            cmd.Parameters.Add("toDate", SqlDbType.DateTime).Value = DateTime.Parse(txtSearchVl2.Text);

            SqlDataReader result = cmd.ExecuteReader();
            showDB(result);
        }
        catch (Exception ex)
        {
            SetAlertBox(ex.Message, "alert");
        }
        finally
        {
            con.Close();
        }
    }
    protected void searchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblSearchError.Text = "";
        if (searchBy.SelectedIndex != 3)
        {
            lblFromDate.Text = "Search value:";
            lblToDate.Visible = false;
            txtSearchVl2.Text = "";
            txtSearchVl1.Text = "";
            txtSearchVl2.Visible = false;
            txtSearchVl1.TextMode = TextBoxMode.SingleLine;
        }
        else
        {
            lblFromDate.Text = "From:";
            lblToDate.Visible = true;
            txtSearchVl1.TextMode = TextBoxMode.Date;
            txtSearchVl2.Visible = true;
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        btnClear_Click(sender, e);
        LoadEmployees();
        ViewState["SEARCHVALUE_1"] = "";
        ViewState["SEARCHVALUE_2"] = "";
    }
    bool validation()
    {
        bool isError = false;
        try
        {
            if (txtLaName.Text.Length == 0)
            {
                lblLastName.Visible = true;
                lblLastName.Text = "Please enter lastname!";
                isError = true;
            }
            if (txtFirName.Text.Length == 0)
            {
                lblFirstName.Visible = true;
                lblFirstName.Text = "Please enter firstname!";
                isError = true;
            }
            if (txtTitle.Text.Length == 0)
            {
                lblTitle.Visible = true;
                lblTitle.Text = "Please enter title!";
                isError = true;
            }
            if (txtDOB.Text.Length == 0)
            {
                lblDate.Visible = true;
                lblDate.Text = "Please enter birthday!";
                isError = true;
            }
            else
            if (DateTime.Parse(txtDOB.Text) > DateTime.Now)
            {
                lblDate.Visible = true;
                lblDate.Text = "Invalid date of birth!";
                isError = true;
            }
            if (txtHiredate.Text.Length == 0)
            {
                lblHired.Visible = true;
                lblHired.Text = "Please enter hire date!";
                isError = true;
            }
            if (txtHiredate.Text.Length != 0 && txtDOB.Text.Length != 0)
            {
                if (DateTime.Parse(txtHiredate.Text).Year - DateTime.Parse(txtDOB.Text).Year < 18)
                {
                    lblDate.Visible = true;
                    lblDate.Text = "Employee's age must be greater than 18 when hired!";
                    lblHired.Visible = true;
                    lblHired.Text = "Employee's age must be greater than 18 when hired!";
                    isError = true;
                }
            }
            if (txtPhone.Text.Length == 0)
            {
                lblPhone.Visible = true;
                lblPhone.Text = "Please enter phone number!";
                isError = true;
            }
            if (txtAddress.Text.Length == 0)
            {
                lblAddress.Visible = true;
                lblAddress.Text = "Please enter address!";
                isError = true;
            }
            if (txtCity.Text.Length == 0)
            {
                lblCity.Visible = true;
                lblCity.Text = "Please enter city!";
                isError = true;
            }
        }
        catch (Exception e)
        {
            SetAlertBox("Invalid date time value!", "alert");
            return false;
        }
        return !isError;
    }
    protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int searchIndex = int.Parse(searchBy.SelectedValue);
        if (searchIndex == -1)
        {
            LoadEmployees();
        }
        else if (searchIndex == 0)
        {
            searchByLastname();
        }
        else if (searchIndex == 1)
        {
            searchByFirstname();
        }
        else
        {
            searchByBirthday();
        }

        gvEmployee.PageIndex = e.NewPageIndex;
        gvEmployee.DataBind();
        AlertBox.Visible = false;
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}