using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Globalization;

public partial class Order : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        if (this.IsPostBack == false)
        {
            LoadDatabase();
        }

        if (cbxSearch.Text != "Customer Name")
        {

            lbFrom.Visible = true;
            lbTo.Visible = true;
            dtpFrom.Visible = true;
            dtpTo.Visible = true;
            txtSearch.Visible = false;
        }
        else
        {
            lbFrom.Visible = false;
            lbTo.Visible = false;
            dtpFrom.Visible = false;
            dtpTo.Visible = false;
            txtSearch.Visible = true;
        }
        errSearch.Visible = false;
        errDate.Visible = false;
        restoreData();
    }

    void LoadDatabase()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[OrderGetAll]";

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            dgOrder.DataSource = dt;
            dgOrder.AllowPaging = true;

            dgOrder.DataBind();
            captureData();
            con.Close();
        }
        catch (Exception e)
        {
            Response.Write(e.Message);
        }

    }

    void SetAlertBox(string title, string className)
    {
        lblMessage.Text = title;
        AlertBox.CssClass = className;
        AlertBox.Visible = true;
    }
    protected void dgOrder_Sorting(object sender, GridViewSortEventArgs e)
    {
    }

    protected void restoreData()
    {
        DataTable data = ViewState["TABLE"] as DataTable;
        dgOrder.DataSource = data;
        dgOrder.DataBind();
    }

    protected void dgOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        restoreData();
        dgOrder.PageIndex = e.NewPageIndex;
        dgOrder.DataBind();
    }

    protected void dgOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = dgOrder.SelectedRow;
        string id = r.Cells[3].Text;

        Response.Redirect("OrderDetail.aspx?id=" + id);
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderInput.aspx?id=0");
    }

    protected void dgOrder_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow r = dgOrder.Rows[e.NewEditIndex];
        string id = r.Cells[3].Text;
        Response.Redirect("OrderInput.aspx?id=" + id);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string search = cbxSearch.Text;
        string value = txtSearch.Text.Trim();
        if ((dtpFrom.Value == "" || dtpTo.Value == "") && txtSearch.Text.Trim() == "")
        {
            if (dtpFrom.Value == "" || dtpTo.Value == "" && txtSearch.Visible == false)
            {
                errSearch.Text = "Please input date !!!!";
            }
            if (txtSearch.Text == "" && (dtpTo.Visible == false && dtpFrom.Visible == false))
            {
                errSearch.Text = "Please input value before search !!!!";
            }
            errSearch.Visible = true;
            return;
        }

        if (dtpFrom.Value != "" && dtpTo.Value != "")
        {
            try
            {
                string dateFrom = dtpFrom.Value;
                string dateTo = dtpTo.Value;
                int result = DateTime.Compare(DateTime.Parse(dateFrom), DateTime.Parse(dateTo));
                if (result != -1)
                {
                    errSearch.Text = "From date must bigger than To date !!!!";
                    errSearch.Visible = true;
                    return;
                }
            }catch(Exception ex)
            {
                errSearch.Text = "Input date not in correct format (dd/mm/yyyy)!!!!";
                errSearch.Visible = true;
                return;
            }
            
        }
        if (search.Equals("Customer Name"))
        {
            try
            {

                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[Order.searchByName]";
                cmd.CommandType = CommandType.StoredProcedure;

                #region SQL param

                SqlParameter param = new SqlParameter();

                param = new SqlParameter();
                param.ParameterName = "@name";
                param.SqlDbType = SqlDbType.NVarChar;
                param.Size = 30;
                param.Value = txtSearch.Text;
                cmd.Parameters.Add(param);

                #endregion

                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgOrder.DataSource = table;
                dgOrder.DataBind();
                captureData();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
        }
        if (search.Equals("Order Date"))
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[searchOrderDate]";
                cmd.CommandType = CommandType.StoredProcedure;


                #region SQL param
                SqlParameter param = new SqlParameter();

                param = new SqlParameter();
                param.ParameterName = "@dateFrom";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpFrom.Value;
                cmd.Parameters.Add(param);


                param = new SqlParameter();
                param.ParameterName = "@dateTo";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpTo.Value;
                cmd.Parameters.Add(param);

                #endregion
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgOrder.DataSource = table;
                dgOrder.DataBind();
                captureData();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
        }

        if (search.Equals("Require Date"))
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[searchRequireDate]";
                cmd.CommandType = CommandType.StoredProcedure;


                #region SQL param
                SqlParameter param = new SqlParameter();

                param = new SqlParameter();
                param.ParameterName = "@dateFrom";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpFrom.Value;
                
                cmd.Parameters.Add(param);


                param = new SqlParameter();
                param.ParameterName = "@dateTo";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpTo.Value;
                cmd.Parameters.Add(param);

                #endregion
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgOrder.DataSource = table;
                dgOrder.DataBind();
                captureData();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
        }
        if (search.Equals("Ship Date"))
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "[searchShipDate]";
                cmd.CommandType = CommandType.StoredProcedure;


                #region SQL param
                SqlParameter param = new SqlParameter();

                param = new SqlParameter();
                param.ParameterName = "@dateFrom";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpFrom.Value;
                cmd.Parameters.Add(param);


                param = new SqlParameter();
                param.ParameterName = "@dateTo";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpTo.Value;
                cmd.Parameters.Add(param);

                #endregion
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                dgOrder.DataSource = table;
                dgOrder.DataBind();
                captureData();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
        }
    }

    protected void captureData()
    {
        DataTable dt = dgOrder.DataSource as DataTable;
        ViewState["TABLE"] = dt;
    }

    protected void cbxSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbxSearch.Text != "Customer Name")
        {

            lbFrom.Visible = true;
            lbTo.Visible = true;
            dtpFrom.Visible = true;
            dtpTo.Visible = true;
            txtSearch.Visible = false;
        }
        else
        {
            lbFrom.Visible = false;
            lbTo.Visible = false;
            dtpFrom.Visible = false;
            dtpTo.Visible = false;
            txtSearch.Visible = true;
        }
    }

    protected void dgOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton del = e.Row.Cells[0].Controls[0] as LinkButton;
            del.Attributes.Add("onclick", "return confirm('Your delete is related to another table. \nDo you really want delete selected row ?')");
        }
    }

    protected void dgOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }
        ViewState["CurrentRow"] = e.RowIndex;
        DialogConfirm.Visible = true;
    }


    void DeleteCategory(int ID)
    {
        con.Open();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "[DeleteOrderDetail]";
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter param = new SqlParameter();
        #region orderID
        param.ParameterName = "@orderid";
        param.SqlDbType = SqlDbType.Int;
        param.Value = ID;
        cmd.Parameters.Add(param);
        #endregion
        cmd.ExecuteNonQuery();
        con.Close();

        con.Open();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "[DeleteOrder]";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter param1 = new SqlParameter();

        #region orderID
        param1.ParameterName = "@orderid";
        param1.SqlDbType = SqlDbType.Int;
        param1.Value = ID;
        cmd.Parameters.Add(param1);
        #endregion

        cmd.ExecuteNonQuery();
        con.Close();
        SetAlertBox("Delete successfully!", "alert alert-success");
    }


    protected void btnYes_Click(object sender, EventArgs e)
    {
        int currRow = int.Parse(ViewState["CurrentRow"] + "");
        if (currRow < 0)
        {
            return;
        }
        GridViewRow r = dgOrder.Rows[currRow];
        DeleteCategory(int.Parse(r.Cells[3].Text));
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
        LoadDatabase();
        AlertBox.Visible = false;
    }
}