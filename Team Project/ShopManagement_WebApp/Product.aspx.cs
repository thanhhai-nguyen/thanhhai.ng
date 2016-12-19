using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Product : System.Web.UI.Page
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

            supplierPanel.Visible = false;
            categoryPanel.Visible = false;
            LoadSupplier();
            LoadCategory();
        }

    }

    void LoadSupplier()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[Supplier.SelectSomeInfo2]";

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            AlertBox.Visible = false;
            dgSupplier.AllowPaging = true;
            dgSupplier.DataSource = dt;
            dgSupplier.DataBind();
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

    void LoadCategory()
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

    void LoadDatabase()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[Product.SelectAll2]";
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            dgProduct.AllowPaging = true;
            dgProduct.DataSource = dt;
            dgProduct.DataBind();
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

    void SetInfo(string proId, string proName, string supID, string catID, string unitprice, bool status)
    {
        txtProductID.Text = proId;
        txtProductName.Text = proName;
        txtSupID.Text = supID;
        txtCatID.Text = catID;
        txtUPrice.Text = unitprice;
        chkDiscontinued.Checked = status;
    }

    // Add update dete

    #region Add, update, delete

    void DeleteProduct(int proID)
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
            param.Value = proID;
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            // Show message
            SetAlertBox("Delete successfully!", "alert alert-success");
        }
        catch (Exception)
        {
            // Show message
            SetAlertBox("Delete failed. This product is used in other table!", "alert");
        }
        finally
        {
            con.Close();
        }
    }

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
            param.Value = Server.HtmlDecode(txtProductName.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "supplierid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtSupID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "categoryid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtCatID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "unitprice";
            param.SqlDbType = SqlDbType.Money;
            param.Value = float.Parse(txtUPrice.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "discontinued";
            param.SqlDbType = SqlDbType.Bit;
            param.Value = chkDiscontinued.Checked;
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

    void UpdateCurrentProduct()
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
            param.Value = Server.HtmlDecode(txtProductName.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "supplierid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtSupID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "categoryid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtCatID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "unitprice";
            param.SqlDbType = SqlDbType.Money;
            param.Value = float.Parse(txtUPrice.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "discontinued";
            param.SqlDbType = SqlDbType.Bit;
            param.Value = chkDiscontinued.Checked;
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

    void SearchByProductName(string value)
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
            param.Size = 15;
            param.Value = value;
            cmd.Parameters.Add(param);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgProduct.AllowPaging = true;
            dgProduct.DataSource = dt;
            dgProduct.DataBind();
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
            param.ParameterName = "@fromprice";
            param.SqlDbType = SqlDbType.Money;
            param.Value = float.Parse(value1);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@toprice";
            param.SqlDbType = SqlDbType.Money;
            param.Value = float.Parse(value2);
            cmd.Parameters.Add(param);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgProduct.AllowPaging = true;
            dgProduct.DataSource = dt;
            dgProduct.DataBind();
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

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgProduct.AllowPaging = true;
            dgProduct.DataSource = dt;
            dgProduct.DataBind();
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

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgProduct.AllowPaging = true;
            dgProduct.DataSource = dt;
            dgProduct.DataBind();
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
    #endregion

    // Validation
    bool isFloatNumber(string fl)
    {
        try
        {
            float.Parse(fl);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    bool isValidData()
    {
        bool isError = false;
        string tPrice = txtUPrice.Text.Trim();
        if (!isFloatNumber(tPrice))
        {
            errUnitPrice.Text = "* Must be number";
            isError = true;
        }
        else
        {
            float price = float.Parse(tPrice);
            if (price <= 0)
            {
                errUnitPrice.Text = "* Must be positive number";
                isError = true;
            }
            else
                errUnitPrice.Text = "";
        }
        return !isError;
    }
    bool isIntegerNumber(string num)
    {
        try
        {
            int.Parse(num);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    protected void dgProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = dgProduct.SelectedRow;
        CheckBox status = r.Cells[9].Controls[0] as CheckBox;
        SetInfo(r.Cells[2].Text, Server.HtmlDecode(r.Cells[3].Text), r.Cells[4].Text, r.Cells[5].Text, r.Cells[8].Text, status.Checked);
        ViewState["mode"] = false;

    }

    void ResetSearchViewState()
    {
        ViewState["SearchType"] = -1;
        ViewState["SearchValue"] = "";
        ViewState["SearchValue1"] = "";
        ViewState["SearchValue2"] = "";
    }

    protected void dgProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
                if (searchType < 3)
            {
                string searchValue = (string)ViewState["SearchValue"];
                txtSearchValue.Text = searchValue;
                cbbSearchType.SelectedIndex = searchType;
                btnSearch_Click(sender, e);
            }
            else
            {
                string searchValue1 = (string)ViewState["SearchValue1"];
                string searchValue2 = (string)ViewState["SearchValue2"];
                txtSearchValue.Text = searchValue1;
                txtSearchValue2.Text = searchValue2;
                cbbSearchType.SelectedIndex = searchType;
                btnSearch_Click(sender, e);
            }
        }
        dgProduct.PageIndex = e.NewPageIndex;
        dgProduct.DataBind();
        AlertBox.Visible = false;


    }

    protected void dgProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
        SetInfo("", "", "", "", "", false);
        ViewState["mode"] = true;
        errUnitPrice.Text = "";
        AlertBox.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (isValidData())
        {
            bool isNew = bool.Parse(ViewState["mode"] + "");
            if (isNew)
            {
                AddNewProduct();
            }
            else
            {
                UpdateCurrentProduct();
            }
            btnRefresh_Click(sender, e);
            btnClear_Click(sender, e);
            AlertBox.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        AlertBox.Visible = false;
        int searchType = cbbSearchType.SelectedIndex;
        if (searchType < 3)
        {
            string searchValue = txtSearchValue.Text.Trim();
            if (searchValue.Length == 0)
            {
                lblError.Text = "* Search value is empty!";
                return;
            }

            lblError.Text = "";
            ViewState["SearchType"] = searchType;
            ViewState["SearchValue"] = searchValue;
            switch (searchType)
            {
                case 0:
                    SearchByProductName(searchValue);
                    break;
                case 1:
                    SearchByCatName(searchValue);
                    break;
                case 2:
                    SearchBySupName(searchValue);
                    break;
            }
        }
        else if (searchType == 3)
        {
            string searchValue1 = txtSearchValue.Text.Trim();
            string searchValue2 = txtSearchValue2.Text.Trim();
            if (searchValue1.Length == 0 || searchValue2.Length == 0)
            {
                lblError.Text = "* Search price is empty!";
                return;
            }
            if (!isFloatNumber(searchValue1) || !isFloatNumber(searchValue2))
            {
                lblError.Text = "* Search price must be number!";
                return;
            }
            float num1 = float.Parse(searchValue1);
            float num2 = float.Parse(searchValue2);
            if (num1 > num2)
            {
                lblError.Text = "* Price from must be less than price to!";
                return;
            }
            lblError.Text = "";
            ViewState["SearchType"] = searchType;
            ViewState["SearchValue1"] = searchValue1;
            ViewState["SearchValue2"] = searchValue2;
            SearchByUnitPrice(searchValue1, searchValue2);
        }


        btnClear_Click(sender, e);
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadDatabase();
        txtSearchValue.Text = "";
        txtSearchValue2.Text = "";
        ResetSearchViewState();
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
        GridViewRow r = dgProduct.Rows[currRow];
        DeleteProduct(int.Parse(r.Cells[2].Text));
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

    protected void dgSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadSupplier();
        dgSupplier.PageIndex = e.NewPageIndex;
        dgSupplier.DataBind();
    }

    protected void dgSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = dgSupplier.SelectedRow;
        txtSupID.Text = row.Cells[1].Text;
        supplierPanel.Visible = false;
    }

    protected void btnSupID_Click(object sender, ImageClickEventArgs e)
    {
        if (categoryPanel.Visible)
        {
            categoryPanel.Visible = false;
        }
        supplierPanel.Visible = true;
    }

    protected void dgCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadCategory();
        dgCategory.PageIndex = e.NewPageIndex;
        dgCategory.DataBind();
    }

    protected void dgCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = dgCategory.SelectedRow;
        txtCatID.Text = row.Cells[1].Text;
        categoryPanel.Visible = false;
    }

    protected void btnCatID_Click(object sender, ImageClickEventArgs e)
    {
        if (supplierPanel.Visible)
        {
            supplierPanel.Visible = false;
        }
        categoryPanel.Visible = true;
    }

    protected void cbbSearchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int searchType = cbbSearchType.SelectedIndex;
        ResetSearchViewState();

        if (searchType == 3)
        {
            txtSearchValue2.Visible = true;
        }
        else
        {
            txtSearchValue2.Visible = false;
        }
    }




    protected void dgProduct_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > 1)
        {
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
        }

    }
}