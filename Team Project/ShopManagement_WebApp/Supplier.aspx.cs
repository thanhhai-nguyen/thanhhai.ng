using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Supplier : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        loadData();
    }

    #region Utility
    public void loadData()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[Supplier.SelectAll]";
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            gvSupplier.DataSource = table;
            gvSupplier.DataBind();
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

    private void resetInput()
    {
        txtSupID.Text = "";
        txtCompName.Text = "";
        txtContName.Text = "";
        txtContTitle.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        txtRegion.Text = "";
        txtPostalCode.Text = "";
        dlCountry.SelectedIndex = 0;
        txtPhone.Text = "";
        txtFax.Text = "";

    }
    void SetAlertBox(string title, string className)
    {
        lblMessage.Text = title;
        AlertBox.CssClass = className;
        AlertBox.Visible = true;
    }
    public void addNewSupplier()
    {
        try
        {
            con.Open();
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
            param.Value = txtPostalCode.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Country";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = dlCountry.Text;
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
            con.Close();
            SetAlertBox("Add successfully!", "alert alert-success");
            this.loadData();
        }
        catch (Exception)
        {
            SetAlertBox("Add failed!", "alert");
        }

    }

    public void updateNewSupplier()
    {
        try
        {
            con.Open();
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
            param.Value = txtPostalCode.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Country";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = dlCountry.Text;
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
            con.Close();
            SetAlertBox("Update successfully!", "alert alert-success");
            this.loadData();
        }
        catch (Exception)
        {
            SetAlertBox("Update failed!", "alert");
        }
    }

    public void deleteSupplier(GridViewRow row)
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
            param.Value = int.Parse(row.Cells[2].Text);
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            con.Close();
            SetAlertBox("Delete successfully!", "alert alert-success");
            this.loadData();
        }
        catch (Exception)
        {
            SetAlertBox("Supplier is using in another table!", "alert");
        }
        finally
        {
            con.Close();
        }
    }

    private void setInfo(GridViewRow row)
    {
        txtSupID.Text = Server.HtmlDecode(row.Cells[2].Text);
        txtCompName.Text = Server.HtmlDecode(row.Cells[3].Text);
        txtContName.Text = Server.HtmlDecode(row.Cells[4].Text);
        txtContTitle.Text = Server.HtmlDecode(row.Cells[5].Text);
        txtAddress.Text = Server.HtmlDecode(row.Cells[6].Text);
        txtCity.Text = Server.HtmlDecode(row.Cells[7].Text);
        txtRegion.Text = Server.HtmlDecode(row.Cells[8].Text);
        txtPostalCode.Text = Server.HtmlDecode(row.Cells[9].Text);
        dlCountry.SelectedItem.Text = Server.HtmlDecode(row.Cells[10].Text);
        txtPhone.Text = Server.HtmlDecode(row.Cells[11].Text);
        txtFax.Text = Server.HtmlDecode(row.Cells[12].Text);
    }


    private void searchByCompanyName()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[SearchSupplierByCompanyName]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@CompName";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 40;
            param.Value = txtSearch.Text;
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            gvSupplier.DataSource = table;
            gvSupplier.DataBind();
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

    private void searchByContactName()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[SearchSupplierByContactName]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@ContName";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 30;
            param.Value = txtSearch.Text;
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            gvSupplier.DataSource = table;
            gvSupplier.DataBind();
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

    private void searchByCountry()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[SearchSupplierByCountry]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@CountryName";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = txtSearch.Text;
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            gvSupplier.DataSource = table;
            gvSupplier.DataBind();
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

    private void search()
    {
        switch (drSearch.SelectedValue)
        {
            case "1":
                searchByCompanyName();
                break;
            case "2":
                searchByContactName();
                break;
            case "3":
                searchByCountry();
                break;
        }
        gvSupplier.Sort(drSortItem.SelectedValue, SortDirection.Ascending);
    }
    #endregion

    #region Button_Click



    protected void gvSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvSupplier.SelectedRow;
        setInfo(row);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtSupID.Text.Equals(""))
        {
            this.addNewSupplier();
        }
        else
        {
            this.updateNewSupplier();
        }
        resetInput();
        gvSupplier.Sort(drSortItem.SelectedValue, SortDirection.Ascending);

    }

    protected void gvSupplier_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }
        ViewState["CurrentRow"] = e.RowIndex;
        DialogConfirm.Visible = true;
    }

    protected void btnSort_Click(object sender, EventArgs e)
    {
        gvSupplier.Sort(drSortItem.SelectedValue, SortDirection.Ascending);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AlertBox.Visible = false;
        search();
    }
    #endregion



    protected void gvSupplier_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable table = (DataTable)gvSupplier.DataSource;
        table.DefaultView.Sort = e.SortExpression;
        gvSupplier.DataSource = table;
        gvSupplier.DataBind();
    }

    protected void gvSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        loadData();
        
        gvSupplier.PageIndex = e.NewPageIndex;
        gvSupplier.DataBind();
        gvSupplier.Sort(drSortItem.SelectedValue, SortDirection.Ascending);

    }





    protected void btnDefault_Click(object sender, EventArgs e)
    {
        loadData();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.resetInput();
        AlertBox.Visible = false;
    }


    protected void btnYes_Click(object sender, EventArgs e)
    {
        int currRow = int.Parse(ViewState["CurrentRow"] + "");
        if (currRow < 0)
        {
            return;
        }
        GridViewRow r = gvSupplier.Rows[currRow];
        deleteSupplier(r);
        loadData();
        //Clear
        resetInput();
        
        DialogConfirm.Visible = false;
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        DialogConfirm.Visible = false;
    }
}