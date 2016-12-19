using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OrderInput : System.Web.UI.Page
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
            string id = Request.QueryString["id"];
            if (id != "" && id != "0")
            {
                txtOrderID.Text = id;
                loadOrderID();
            }
            else if (id == "0")
            {
            }
        }

        txtOrderID.Enabled = false;
        txtEmployeeID.Enabled = false;
        txtShipperID.Enabled = false;
        txtCustomerID.Enabled = false;
        errOrderDate.Visible = false;
        errRequireDate.Visible = false;
        errShipDate.Visible = false;
        if (ckNotShip.Checked == true)
        {
            dtpShipDate.Disabled = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (dtpOrderDate.Value == "" || dtpRequireDate.Value == "" || dtpShipDate.Value == "")
        {
            if (dtpOrderDate.Value == "")
            {
                errOrderDate.Visible = true;
                return;
            }
            if (dtpRequireDate.Value == "")
            {
                errRequireDate.Visible = true;
                return;
            }
            if (dtpShipDate.Disabled == false && dtpShipDate.Value == "")
            {
                ckNotShip.Checked = true;
                errShipDate.Visible = true;
                return;
            }
            else
            {
            }
        }
        if (dtpShipDate.Value == "" && dtpShipDate.Visible == true)
        {
            ckNotShip.Checked = true;
            errShipDate.Visible = true;
            return;
        }
        DateTime orderdate = DateTime.Parse(dtpOrderDate.Value);
        DateTime requiredate = DateTime.Parse(dtpRequireDate.Value);

        if (DateTime.Compare(orderdate, requiredate) != -1)
        {
            errRequireDate.Text = "Require date must be bigger than Order date";
            errRequireDate.Visible = true;
            return;
        }
        if (dtpShipDate.Value != "")
        {
            DateTime shipdate = DateTime.Parse(dtpShipDate.Value);
            if (DateTime.Compare(orderdate, shipdate) != -1)
            {
                errShipDate.Text = "Ship date must be bigger than Order date";
                errShipDate.Visible = true;
                return;
            }
        }

        if (txtOrderID.Text == "")
        {
            addNewOrder();
        }
        else
        {
            updateOrder();
        }

    }

    public void loadOrderID()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[Order.LoadOrder]";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();

            param = new SqlParameter();
            param.ParameterName = "@orderID";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtOrderID.Text);
            cmd.Parameters.Add(param);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtCustomerID.Text = dr.GetInt32(0).ToString();
                dtpOrderDate.Value = dr.GetDateTime(2).ToString("yyyy-MM-dd");
                dtpRequireDate.Value = dr.GetDateTime(3).ToString("yyyy-MM-dd");
                if (!dr.IsDBNull(4))
                {
                    dtpShipDate.Value = dr.GetDateTime(4).ToString("yyyy-MM-dd");
                    ckNotShip.Checked = false;
                }
                else
                {
                    ckNotShip.Checked = true;
                }
                txtEmployeeID.Text = dr.GetInt32(1).ToString();
                txtShipperID.Text = dr.GetInt32(5).ToString();
                txtFreight.Text = dr.GetDecimal(6).ToString("N2");
                txtShipName.Text = dr.GetString(7).ToString();
                txtShipAddress.Text = dr.GetString(8).ToString();
                txtShipCity.Text = dr.GetString(9).ToString();
                if (!dr.IsDBNull(10))
                {
                    txtShipRegion.Text = dr.GetString(10).ToString();
                }
                if (!dr.IsDBNull(11))
                {
                    txtShipPostalCode.Text = dr.GetString(11).ToString();
                }
                txtShipCountry.Text = dr.GetString(12).ToString();
            }

        }
        catch (Exception e)
        {
            Response.Write("<script>alert('" + e.Message + "')</script>");
        }
        finally
        {
            con.Close();
        }
    }

    public void updateOrder()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[UpdateOrder]";
            cmd.CommandType = CommandType.StoredProcedure;

            ///////
            #region SQL param

            SqlParameter param = new SqlParameter();

            #region orderID
            param.ParameterName = "@orderid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtOrderID.Text);
            cmd.Parameters.Add(param);
            #endregion

            param = new SqlParameter();
            param.ParameterName = "@custid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtCustomerID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@empid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtEmployeeID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@orderdate";
            param.SqlDbType = SqlDbType.DateTime;
            param.Value = dtpOrderDate.Value;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@requireddate";
            param.SqlDbType = SqlDbType.DateTime;
            param.Value = dtpRequireDate.Value;
            cmd.Parameters.Add(param);

            if (ckNotShip.Checked == true)
            {
                param = new SqlParameter();
                param.ParameterName = "@shippeddate";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = DBNull.Value;
                cmd.Parameters.Add(param);
            }
            else
            {
                param = new SqlParameter();
                param.ParameterName = "@shippeddate";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpShipDate.Value;
                cmd.Parameters.Add(param);
            }

            param = new SqlParameter();
            param.ParameterName = "@shipperid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtShipperID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@freight";
            param.SqlDbType = SqlDbType.Money;
            param.Value = txtFreight.Text;
            cmd.Parameters.Add(param);


            param = new SqlParameter();
            param.ParameterName = "@shipname";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 40;
            param.Value = txtShipName.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@shipaddress";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 60;
            param.Value = txtShipAddress.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@shipcity";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = txtShipCity.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@shipregion";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = txtShipRegion.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@shippostalcode";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 10;
            param.Value = txtShipPostalCode.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@shipcountry";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = txtShipCountry.Text;
            cmd.Parameters.Add(param);
            #endregion

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Update Success')</script>");
            Response.Redirect("Order.aspx");
        }
        catch (Exception e)
        {
            Response.Write("<script>alert('" + e.Message + "')</script>");
            con.Close();
            return;
        }
    }

    public void addNewOrder()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[InsertOrder]";
            cmd.CommandType = CommandType.StoredProcedure;


            #region SQL param
            SqlParameter param = new SqlParameter();

            param = new SqlParameter();
            param.ParameterName = "@custid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtCustomerID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@empid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtEmployeeID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@orderdate";
            param.SqlDbType = SqlDbType.DateTime;
            param.Value = dtpOrderDate.Value;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@requireddate";
            param.SqlDbType = SqlDbType.DateTime;
            param.Value = dtpRequireDate.Value;
            cmd.Parameters.Add(param);


            if (ckNotShip.Checked == true)
            {
                param = new SqlParameter();
                param.ParameterName = "@shippeddate";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = DBNull.Value;
                cmd.Parameters.Add(param);
            }
            else
            {
                param = new SqlParameter();
                param.ParameterName = "@shippeddate";
                param.SqlDbType = SqlDbType.DateTime;
                param.Value = dtpShipDate.Value;
                cmd.Parameters.Add(param);
            }

            param = new SqlParameter();
            param.ParameterName = "@shipperid";
            param.SqlDbType = SqlDbType.Int;
            param.Value = int.Parse(txtShipperID.Text);
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@freight";
            param.SqlDbType = SqlDbType.Money;
            param.Value = txtFreight.Text;
            cmd.Parameters.Add(param);


            param = new SqlParameter();
            param.ParameterName = "@shipname";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 40;
            param.Value = txtShipName.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@shipaddress";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 60;
            param.Value = txtShipAddress.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@shipcity";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = txtShipCity.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@shipregion";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = txtShipRegion.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@shippostalcode";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 10;
            param.Value = txtShipPostalCode.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@shipcountry";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 15;
            param.Value = txtShipCountry.Text;
            cmd.Parameters.Add(param);
            #endregion

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Add Success')</script>");
            Response.Redirect("Order.aspx");

        }
        catch (Exception e)
        {
            Response.Write("<script>alert('" + e.Message + "')</script>");
            con.Close();
        }
    }

    protected void btnCusID_Click(object sender, ImageClickEventArgs e)
    {
        loadCusID();
        dgCustomer.Visible = true;
        dgEmp.Visible = false;
        dgShipper.Visible = false;
    }

    public void loadCusID()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[CustomerGetData]";
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            dgCustomer.AllowPaging = true;
            dgCustomer.DataSource = table;
            dgCustomer.DataBind();

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

    public void loadEmpID()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[EmployeeGetData]";
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            dgEmp.DataSource = table;
            dgEmp.AllowPaging = true;
            dgEmp.DataBind();

        }
        catch (Exception e)
        {
            Response.Write("<script>alert('" + e.Message + "')</script>");
        }
        finally
        {
            con.Close();
        }
    }

    protected void btnEmpID_Click(object sender, ImageClickEventArgs e)
    {
        loadEmpID();
        dgCustomer.Visible = false;
        dgEmp.Visible = true;
        dgShipper.Visible = false;
    }

    public void loadShipperID()
    {
        try
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "[ShipperGetData]";
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            dgShipper.DataSource = table;
            dgShipper.AllowPaging = true;
            dgShipper.DataBind();

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

    protected void btnShipperID_Click(object sender, ImageClickEventArgs e)
    {
        loadShipperID();
        dgCustomer.Visible = false;
        dgEmp.Visible = false;
        dgShipper.Visible = true;
    }


    protected void dgCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = dgCustomer.SelectedRow;
        txtCustomerID.Text = r.Cells[1].Text;
    }

    protected void dgEmp_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = dgEmp.SelectedRow;
        txtEmployeeID.Text = r.Cells[1].Text;
    }

    protected void dgShipper_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = dgShipper.SelectedRow;
        txtShipperID.Text = r.Cells[1].Text;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        reset();
    }

    public void reset()
    {
        txtOrderID.Enabled = false;
        dtpOrderDate.Value = "";
        dtpRequireDate.Value = "";
        dtpShipDate.Value = "";
        txtCustomerID.Text = "";
        txtEmployeeID.Text = "";
        txtFreight.Text = "";
        txtOrderID.Text = "";
        txtShipAddress.Text = "";
        txtShipCity.Text = "";
        txtShipPostalCode.Text = "";
        txtShipCountry.SelectedIndex = 0;
        txtShipName.Text = "";
        txtShipperID.Text = "";
        txtShipRegion.Text = "";
    }

    protected void dgCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        loadCusID();
        dgCustomer.PageIndex = e.NewPageIndex;
        dgCustomer.DataBind();
    }

    protected void dgEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        loadEmpID();
        dgEmp.PageIndex = e.NewPageIndex;
        dgEmp.DataBind();
    }

    protected void dgShipper_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        loadShipperID();
        dgShipper.PageIndex = e.NewPageIndex;
        dgShipper.DataBind();
    }


}