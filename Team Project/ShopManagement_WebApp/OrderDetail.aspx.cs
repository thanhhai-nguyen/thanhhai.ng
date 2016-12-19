using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OrderDetail : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr;
    DateTime shipDate;


    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

        string id = Request.QueryString["id"];
        txtOrderID.Text = id;

        Visible();
        if (this.IsPostBack == false)
        {
            LoadDatabase();
        }
        txtOrderID.Enabled = false;
        txtProductID.Enabled = false;
        txtUnitPrice.Enabled = false;
    }

    void Visible()
    {
        if (cbxSearch.Text != "Product Name (Order Detail)")
        {
            lbFrom.Visible = true;
            lbTo.Visible = true;
            txtFrom.Visible = true;
            txtTo.Visible = true;
            txtSearch.Visible = false;
        }
        else
        {
            lbFrom.Visible = false;
            lbTo.Visible = false;
            txtFrom.Visible = false;
            txtTo.Visible = false;
            txtSearch.Visible = true;
        }
        errSearch.Visible = false;
    }

    void LoadDatabase()
    {
        DataTable stored = ViewState["storedView"] as DataTable;
        if (stored == null)
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[OrderDetails.SelectAll]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();

            param = new SqlParameter();
            param.ParameterName = "@orderid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtOrderID.Text);
            cmd.Parameters.Add(param);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            ViewState.Add("storedView", dt);
            dgOrderDetail.AllowPaging = true;

            dgOrderDetail.DataSource = ViewState["storedView"];
            dgOrderDetail.DataBind();
        }
        if (stored != null)
        {
            dgOrderDetail.DataSource = ViewState["storedView"];
            dgOrderDetail.DataBind();
        }
    }

    #region Sort Methods
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }

    private void sortGridView(string sortExpression, string direction)
    {
        LoadDatabase();
        DataTable dt = dgOrderDetail.DataSource as DataTable;
        dt.DefaultView.Sort = sortExpression + direction;
        ViewState["storedView"] = dt.DefaultView.ToTable();
        dgOrderDetail.DataSource = ViewState["storedView"];
        dgOrderDetail.DataBind();
    }

    #endregion 

    protected void dgOrderDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LoadDatabase();
        dgOrderDetail.PageIndex = e.NewPageIndex;
        dgOrderDetail.DataBind();
    }

    protected bool checkShipDate(string orderID)
    {
        try
        {

            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[order.searchShipDate]";
            cmd.CommandType = CommandType.StoredProcedure;

            #region SQL param

            SqlParameter param = new SqlParameter();

            param = new SqlParameter();
            param.ParameterName = "@orderID";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(orderID);
            cmd.Parameters.Add(param);

            #endregion

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            return false;

        }
        catch (SqlException)
        {
            return true;
        }
        catch (Exception)
        {
            return true;
        }
        finally
        {
            con.Close();
        }

    }



    protected void dgOrderDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {


    }

    protected void dgOrderDetail_Sorting(object sender, GridViewSortEventArgs e)
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string search = cbxSearch.Text;
        string value = txtSearch.Text.Trim();
        if ((txtFrom.Text.Trim() == "" || txtTo.Text.Trim() == "") && txtSearch.Text.Trim() == "")
        {
            if ((txtFrom.Text.Trim() == "" || txtTo.Text.Trim() == "") && txtSearch.Visible == false)
            {
                errSearch.Text = "Please input 2 value before search !!!!";
            }
            if (txtSearch.Text == "" && (txtTo.Visible == false && txtFrom.Visible == false))
            {
                errSearch.Text = "Please input value before search !!!!";
            }
            errSearch.Visible = true;
            return;
        }


        if (search.Equals("Product Name (Order Detail)"))
        {
            if (txtSearch.Text.Trim() == "")
            {
                Response.Write("<script>alert('Please input value before search !!!')</script>");
                return;
            }
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[searchProductName]";
                cmd.CommandType = CommandType.StoredProcedure;


                #region SQL param
                SqlParameter param = new SqlParameter();

                param = new SqlParameter();
                param.ParameterName = "@search";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 30;
                param.Value = txtSearch.Text;
                cmd.Parameters.Add(param);

                #endregion
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgOrderDetail.DataSource = table;
                dgOrderDetail.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
        }
        if (search.Equals("Total Value"))
        {
            if (txtFrom.Text.Trim() == "" && txtTo.Text.Trim() == "")
            {
                Response.Write("<script>alert('Please input value before search !!!')</script>");
                return;
            }
            if (int.Parse(txtFrom.Text) < int.Parse(txtTo.Text))
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "[searchTotal]";
                    cmd.CommandType = CommandType.StoredProcedure;


                    #region SQL param
                    SqlParameter param = new SqlParameter();

                    param = new SqlParameter();
                    param.ParameterName = "@totalFrom";
                    param.SqlDbType = SqlDbType.Int;
                    param.Value = txtFrom.Text;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter();
                    param.ParameterName = "@totalTo";
                    param.SqlDbType = SqlDbType.Int;
                    param.Value = txtTo.Text;
                    cmd.Parameters.Add(param);

                    #endregion
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    dgOrderDetail.DataSource = table;
                    dgOrderDetail.DataBind();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                    con.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('To value must bigger than from From value !!!!')</script>");
                return;
            }
        }
    }

    protected void cbxSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbxSearch.Text != "Product Name (Order Detail)")
        {
            lbFrom.Visible = true;
            lbTo.Visible = true;
            txtFrom.Visible = true;
            txtTo.Visible = true;
            txtSearch.Visible = false;
        }
        else
        {
            lbFrom.Visible = false;
            lbTo.Visible = false;
            txtFrom.Visible = false;
            txtTo.Visible = false;
            txtSearch.Visible = true;
        }
    }

    protected void dgOrderDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }
        ViewState["CurrentRow"] = e.RowIndex;
        DialogConfirm.Visible = true;

    }

    void DeleteCategory(GridViewRow row)
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[OrderDetails.Delete]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@orderid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtOrderID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@productid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(row.Cells[2].Text);
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            con.Close();
            SetAlertBox("Delete successfully!", "alert alert-success");
            ViewState["storedView"] = null;
            LoadDatabase();
        }
        catch (Exception)
        {
            SetAlertBox("Delete failed!", "alert");
            con.Close();
        }
    }


    protected void btnYes_Click(object sender, EventArgs e)
    {
        int currRow = int.Parse(ViewState["CurrentRow"] + "");
        if (currRow < 0)
        {
            return;
        }
        if (checkShipDate(txtOrderID.Text) == true)
        {
            errSearch.Text = "Order has been ship";
            SetAlertBox("Order has been shipped! Can't modify this order detail", "alert");
            return;
        }
        GridViewRow r = dgOrderDetail.Rows[currRow];
        DeleteCategory(r);
        ViewState["storedView"] = null;
        LoadDatabase();
        //Clear
        DialogConfirm.Visible = false;
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        DialogConfirm.Visible = false;
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        ViewState["storedView"] = null;
        LoadDatabase();
    }

    #region orderDetailInput
    void LoadDatabase1()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[OrderDetails.SelectOrder]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();

            param = new SqlParameter();
            param.ParameterName = "@orderid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtOrderID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@productid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtProductID.Text);
            cmd.Parameters.Add(param);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtUnitPrice.Text = dr.GetSqlMoney(2).ToString();
                txtQuantity.Text = dr.GetInt16(3).ToString();
                txtDiscount.Text = dr.GetDecimal(4).ToString();

            }
        }
        catch (Exception e)
        {
            Response.Write("<script>alert('" + e.Message + "')</script>");
            return;
        }
    }

    protected void dgCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = dgProduct.SelectedRow;
        txtProductID.Text = r.Cells[1].Text;
        txtUnitPrice.Text = r.Cells[3].Text;
        dgProduct.Visible = false;
    }

    public void loadProductID()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[Product.GetSomeInfo]";
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            dgProduct.DataSource = table;
            dgProduct.AllowPaging = true;
            dgProduct.DataBind();

        }
        catch (Exception e)
        {
            Response.Write("<script>alert('" + e.Message + "')</script>"); ;
        }
        finally
        {
            con.Close();
        }
    }

    protected void dgCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        loadProductID();
        dgProduct.PageIndex = e.NewPageIndex;
        dgProduct.DataBind();
    }

    protected void btnCusID_Click(object sender, ImageClickEventArgs e)
    {
        oldProID.Text = txtProductID.Text;
        loadProductID();
        dgProduct.Visible = true;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtorder.Text = "";
        dgProduct.Visible = false;
        txtDiscount.Text = "";
        txtProductID.Text = "";
        txtQuantity.Text = "";
        txtUnitPrice.Text = "";
        AlertBox.Visible = false;
    }

    void SetAlertBox(string title, string className)
    {
        lblMessage.Text = title;
        AlertBox.CssClass = className;
        AlertBox.Visible = true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (checkShipDate(txtOrderID.Text) == true)
        {
            errSearch.Text = "Order has been ship";
            SetAlertBox("Order has been shipped! Can't modify this order detail", "alert");
            return;
        }
        if (txtorder.Text == "")
        {
            if (!IsDuplicatedOrderDetail())
            {
                AddNewOrderDetail();
                ViewState["storedView"] = null;
                LoadDatabase();
            }
            else
            {
                SetAlertBox("This order detail is existed", "alert");
            }
            return;
        }


        UpdateOrderDetail();
        ViewState["storedView"] = null;
        LoadDatabase();

    }

    bool IsDuplicatedOrderDetail()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[OrderDetails.SelectOrder]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "orderid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtOrderID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "productid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtProductID.Text);
            cmd.Parameters.Add(param);
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count++;
            }
            if (count == 0)
            {
                return false;
            }
            return true;

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
            return false;
        }
        finally
        {
            dr.Close();
            con.Close();
        }
    }

    void AddNewOrderDetail()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[OrderDetails.Insert]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@orderid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtOrderID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@productid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtProductID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@unitprice";
            param.SqlDbType = SqlDbType.Money;
            param.Value = float.Parse(txtUnitPrice.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@qty";
            param.SqlDbType = SqlDbType.SmallInt;
            param.Value = int.Parse(txtQuantity.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@discount";
            param.SqlDbType = SqlDbType.Float;
            param.Value = float.Parse(txtDiscount.Text);
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            SetAlertBox("Add successfully!", "alert alert-success");
            // Response.Redirect("OrderDetail.aspx?id=" + txtOrderID);
        }
        catch (Exception)
        {
            SetAlertBox("Add failed!", "alert");
        }
        finally
        {
            con.Close();
        }
    }

    void UpdateOrderDetail()
    {

        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[OrderDetails.Update]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@orderid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtOrderID.Text);
            cmd.Parameters.Add(param);

            if (oldProID.Text == "")
            {
                param = new SqlParameter();
                param.ParameterName = "@productid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtProductID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@newProductID";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtProductID.Text);
                cmd.Parameters.Add(param);
            }
            else
            {
                param = new SqlParameter();
                param.ParameterName = "@productid";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(oldProID.Text);
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@newProductID";
                param.SqlDbType = SqlDbType.Int;
                param.Value = int.Parse(txtProductID.Text);
                cmd.Parameters.Add(param);
            }


            param = new SqlParameter();
            param.ParameterName = "@unitprice";
            param.SqlDbType = SqlDbType.Money;
            param.Value = float.Parse(txtUnitPrice.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@qty";
            param.SqlDbType = SqlDbType.SmallInt;
            param.Value = int.Parse(txtQuantity.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@discount";
            param.SqlDbType = SqlDbType.Float;
            param.Value = float.Parse(txtDiscount.Text);
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
            con.Close();
            SetAlertBox("Update successfully!", "alert alert-success");
        }
        catch (Exception)
        {
            con.Close();
            SetAlertBox("Update failed", "alert");
        }
        finally
        {
            con.Close();
        }

    }

    #endregion




    protected void dgOrderDetail_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridViewRow r = dgOrderDetail.SelectedRow;
        txtorder.Text = txtOrderID.Text;
        txtProductID.Text = r.Cells[2].Text;
        oldProID.Text = r.Cells[2].Text;
        LoadDatabase1();
    }
}
