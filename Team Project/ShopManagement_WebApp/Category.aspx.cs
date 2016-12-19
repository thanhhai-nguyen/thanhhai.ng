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
            cmd.CommandText = "[Categories.SelectAll]";

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgCategory.AllowPaging = true;
            dgCategory.DataSource = dt;
            dgCategory.DataBind();
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

    void SetInfo(string id, string name, string description)
    {
        txtID.Text = id;
        txtCatName.Text = name;
        txtDescription.Text = description;
    }

    // Add update dete

    #region Add, update, delete

    void DeleteCategory(int catID)
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
            param.Value = catID;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            // Show message
            SetAlertBox("Delete successfully!", "alert alert-success");
        }
        catch (Exception)
        {
            // Show message
            SetAlertBox("Delete failed. This category is used in other table!", "alert");
        }
        finally
        {
            con.Close();
        }
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
            param.Value = txtCatName.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "description";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 200;
            param.Value = txtDescription.Text;
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
            param.Value = int.Parse(txtID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "categoryname";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = txtCatName.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "description";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 200;
            param.Value = txtDescription.Text;
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
            cmd.CommandText = "[Categories.SearchByName]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "categoryname";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = value;
            cmd.Parameters.Add(param);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgCategory.AllowPaging = true;
            dgCategory.DataSource = dt;
            dgCategory.DataBind();
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

    protected void dgCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = dgCategory.SelectedRow;
        SetInfo(r.Cells[2].Text, Server.HtmlDecode(r.Cells[3].Text), Server.HtmlDecode(r.Cells[4].Text));
        ViewState["mode"] = false;
    }

    protected void dgCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
    

        dgCategory.PageIndex = e.NewPageIndex;
        dgCategory.DataBind();
        AlertBox.Visible = false;
    }

    protected void dgCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
            AddNewCategory();

        }
        else
        {
            UpdateCurrentCategory();
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
        GridViewRow r = dgCategory.Rows[currRow];
        DeleteCategory(int.Parse(r.Cells[2].Text));
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