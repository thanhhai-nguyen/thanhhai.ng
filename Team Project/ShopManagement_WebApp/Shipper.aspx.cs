using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Shipper : System.Web.UI.Page
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



    void ResetSearchViewState()
    {
        ViewState["SearchType"] = -1;
        ViewState["SearchValue"] = "";
    }


    void LoadDatabase()
    {

        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[ShipperGetData]";

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgShipper.AllowPaging = true;
            dgShipper.DataSource = dt;
            dgShipper.DataBind();
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

    void SetAlertBox(string title, string className)
    {
        lblMessage.Text = title;
        AlertBox.CssClass = className;
        AlertBox.Visible = true;
    }

    void SetInfo(string id, string name, string phone)
    {
        txtID.Text = id;
        txtComName.Text = name;
        txtPhone.Text = phone;
    }

    // Add update dete

    #region Add, update, delete

    void DeleteShipper(int shipID)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[Shipper.DeleteOnShipper]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "shipperid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = shipID;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            // Show message
            SetAlertBox("Delete successfully!", "alert alert-success");
        }
        catch (Exception)
        {
            // Show message
            SetAlertBox("Delete failed. This shipper is used in other table!", "alert");
        }
        finally
        {
            con.Close();
        }
    }

    void AddNewShipper()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[Shipper.Insert]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "companyname";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 40;
            param.Value = txtComName.Text.Trim();
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "phone";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 24;
            param.Value = txtPhone.Text;
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

    void UpdateCurrentShipper()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[Shipper.Update]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "shipperid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "companyname";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 40;
            param.Value = txtComName.Text.Trim();
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "phone";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 24;
            param.Value = txtPhone.Text.Trim();
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            // show message
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
    void SearchByName(string value)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[searchByName_Ship]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "compname";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 40;
            param.Value = value;
            cmd.Parameters.Add(param);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgShipper.AllowPaging = true;
            dgShipper.DataSource = dt;
            dgShipper.DataBind();
        }
        catch (Exception)
        {
            // Send redirect to 404
            Response.Redirect("ErrorPage.html");
        }
        finally
        {
            con.Close();
        }
    }
    void SearchByPhone(string value)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[Shipper.searchByPhone]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "phone";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 24;
            param.Value = value;
            cmd.Parameters.Add(param);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgShipper.AllowPaging = true;
            dgShipper.DataSource = dt;
            dgShipper.DataBind();
        }
        catch (Exception)
        {
            // Send redirect to 404
            Response.Redirect("ErrorPage.html");
        }
        finally
        {
            con.Close();
        }
    }
    #endregion

    protected void dgShipper_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = dgShipper.SelectedRow;
        SetInfo(r.Cells[2].Text, Server.HtmlDecode(r.Cells[3].Text), Server.HtmlDecode(r.Cells[4].Text));
        ViewState["mode"] = false;
    }

    protected void dgShipper_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["SearchType"] == null)
        {
            LoadDatabase();
        }
        else
        {
            int searchType = (int)ViewState["SearchType"];
            if (searchType == -1)
            {
                LoadDatabase();
            }
            else
            {
                string searchValue = (string)ViewState["SearchValue"];
                txtSearchValue.Text = searchValue;
                cbbSearchType.SelectedIndex = searchType;
                btnSearch_Click(sender, e);
            }
        }


        dgShipper.PageIndex = e.NewPageIndex;
        dgShipper.DataBind();
        AlertBox.Visible = false;
    }

    protected void dgShipper_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
        SetInfo("", "", "");
        ViewState["mode"] = true;
        AlertBox.Visible = false;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool isNew = bool.Parse(ViewState["mode"] + "");
        if (isNew)
        {
            AddNewShipper();

        }
        else
        {
            UpdateCurrentShipper();
        }
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
            case 0:
                SearchByName(searchValue);
                break;
            case 1:
                SearchByPhone(searchValue);
                break;
        }
        ViewState["SearchType"] = searchType;
        ViewState["SearchValue"] = searchValue;
        btnClear_Click(sender, e);
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadDatabase();
        txtSearchValue.Text = "";
        lblError.Text = "";
        AlertBox.Visible = false;
        ResetSearchViewState();
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        int currRow = int.Parse(ViewState["CurrentRow"] + "");
        if (currRow < 0)
        {
            return;
        }
        GridViewRow r = dgShipper.Rows[currRow];
        DeleteShipper(int.Parse(r.Cells[2].Text));
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
}