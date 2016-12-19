using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Category : System.Web.UI.Page
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
            LoadDatabase();
        }
    }

    void LoadDatabase()
    {
        DataTable stored = ViewState["storedView"] as DataTable;
        if (stored == null)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[tbCustomerLoad]";

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                ViewState.Add("storedView", dt);

                dgCustomer.AllowPaging = true;
                dgCustomer.DataSource = ViewState["storedView"];
                dgCustomer.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("ErrorPage.html");
            }
            finally
            {
                con.Close();
            }
        }
        else
        {
            dgCustomer.DataSource = ViewState["storedView"];
            dgCustomer.DataBind();
        }
    }

    void SetAlertBox(string title, string className)
    {
        lblMessage.Text = title;
        AlertBox.CssClass = className;
        AlertBox.Visible = true;
    }
    void SetInfo()
    {
        txtID.Text = "";
        txtCompName.Text = "";
        txtContName.Text = "";
        txtContTitile.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        txtRegion.Text = "";
        txtPostCode.Text = "";
        cbCountry.SelectedIndex = 0;
        txtPhone.Text = "";
        txtFax.Text = "";
    }
    void SetInfo(string id, string compName, string contName, string contTitile, string address, string city, string region,
        string postCode, string country, string phone, string fax)
    {
        txtID.Text = id;
        txtCompName.Text = compName;
        txtContName.Text = contName;
        txtContTitile.Text = contTitile;
        txtAddress.Text = address;
        txtCity.Text = city;
        txtRegion.Text = region;
        txtPostCode.Text = postCode;
        cbCountry.Text = country;
        txtPhone.Text = phone;
        txtFax.Text = fax;
    }


    #region Add, update, delete

    // Done
    void DeleteCusomer(int custID)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[DeleteCustomer]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@CustID";
            param.SqlDbType = SqlDbType.Int;
            param.Value = custID;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            // Show message
            SetAlertBox("Delete successfully!", "alert alert-success");
        }
        catch (Exception)
        {
            // Show message
            SetAlertBox("Delete failed. This customer is used in other table!", "alert");
        }
        finally
        {
            con.Close();
        }
    }
    //Done
    void AddNewCategory()
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
            param.Value = txtContTitile.Text;
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
            param.Value = txtPostCode.Text;
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
            param.Value = txtPhone.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Fax";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 24;
            param.Value = txtFax.Text;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            // Show Message successfully
            SetAlertBox("Add successfully!", "alert alert-success");
        }
        catch (Exception)
        {
            // Show Message fail
            SetAlertBox("Add failed!", "alert");
        }
        finally
        {
            con.Close();
        }

    }
    //Done
    void UpdateCurrentCategory()
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
            param.Value = txtID.Text;
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
            param.Value = txtContTitile.Text;
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
            param.Value = txtPostCode.Text;
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
            param.Value = txtPhone.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Fax";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 24;
            param.Value = txtFax.Text;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            LoadDatabase();
            SetAlertBox("Update successfully!", "alert alert-success");
        }
        catch (Exception)
        {
            // Show Message fail
            SetAlertBox("Update failed!", "alert");
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

    // Search

    #region Search Methods
    void SearchByCompanyName(string value)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[SearchCustomerByCompanyName]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "CompName";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 40;
            param.Value = value;
            cmd.Parameters.Add(param);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgCustomer.AllowPaging = true;
            dgCustomer.DataSource = dt;
            dgCustomer.DataBind();
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
    void SearchByContactName(string value)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[SearchCustomerByContactName]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "ContName";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 30;
            param.Value = value;
            cmd.Parameters.Add(param);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgCustomer.AllowPaging = true;
            dgCustomer.DataSource = dt;
            dgCustomer.DataBind();
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
    void SearchByCountry(string value)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[SearchCustomerByCountry]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "CountryName";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = value;
            cmd.Parameters.Add(param);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgCustomer.AllowPaging = true;
            dgCustomer.DataSource = dt;
            dgCustomer.DataBind();
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
    #endregion


    protected void dgCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow r = dgCustomer.SelectedRow;
        SetInfo(r.Cells[2].Text, Server.HtmlDecode(r.Cells[3].Text), Server.HtmlDecode(r.Cells[4].Text),
            Server.HtmlDecode(r.Cells[5].Text), Server.HtmlDecode(r.Cells[6].Text), Server.HtmlDecode(r.Cells[7].Text),
            Server.HtmlDecode(r.Cells[8].Text), Server.HtmlDecode(r.Cells[9].Text), Server.HtmlDecode(r.Cells[10].Text),
            Server.HtmlDecode(r.Cells[11].Text), Server.HtmlDecode(r.Cells[12].Text));
        ViewState["mode"] = false;

    }

    protected void dgCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadDatabase();
        dgCustomer.PageIndex = e.NewPageIndex;
        dgCustomer.DataBind();
        AlertBox.Visible = false;
    }

    protected void dgCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }
        ViewState["CurrentRow"] = e.RowIndex;
        DialogConfirm.Visible = true;

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        SetInfo();
        ViewState["mode"] = true;
        AlertBox.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool isNew = bool.Parse(ViewState["mode"] + "");
        if (isNew)
        {
            AddNewCategory();
        }
        else
        {
            UpdateCurrentCategory();
        }
        ViewState["storedView"] = null;
        LoadDatabase();
        btnClear_Click(sender, e);
        AlertBox.Visible = true;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AlertBox.Visible = false;
        string searchValue = txtSearchValue.Text.Trim();
        int searchType = cbbSearchType.SelectedIndex;
        if (searchValue.Length == 0)
        {
            lblError.Text = "* Search value is empty!";
            return;
        }
        lblError.Text = "";
        switch (searchType)
        {
            case 0: // company name
                SearchByCompanyName(searchValue);
                break;
            case 1: // contact name
                SearchByContactName(searchValue);
                break;
            case 2: // country
                SearchByCountry(searchValue);
                break;
        }

        btnClear_Click(sender, e);
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        ViewState["storedView"] = null;
        LoadDatabase();
        txtSearchValue.Text = "";
        lblError.Text = "";
        AlertBox.Visible = false;
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        int currRow = int.Parse(ViewState["CurrentRow"] + "");
        if (currRow < 0)
        {
            return;
        }
        GridViewRow r = dgCustomer.Rows[currRow];
        DeleteCusomer(int.Parse(r.Cells[2].Text));
        ViewState["storedView"] = null;
        LoadDatabase();
        //Clear
        btnClear_Click(sender, e);
        AlertBox.Visible = true;
        DialogConfirm.Visible = false;
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        DialogConfirm.Visible = false;
    }

    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection) ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }

    private void sortGridView(string sortExpression, string direction)
    {
        LoadDatabase();
        DataTable dt = dgCustomer.DataSource as DataTable;
        dt.DefaultView.Sort = sortExpression + direction;
        ViewState["storedView"] = dt.DefaultView.ToTable();
        dgCustomer.DataSource = ViewState["storedView"];
        dgCustomer.DataBind();
    }

    protected void dgCustomer_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            sortGridView(sortExpression, " ASC");
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            sortGridView(sortExpression, " DESC");
        }
    }
}