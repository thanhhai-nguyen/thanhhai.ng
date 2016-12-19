<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shop Management</title>

    <link rel="stylesheet" href="Content/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/main.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />

    <style type="text/css">
        .auto-style1 {
            left: -4px;
            top: 8px;
        }

    </style>

</head>
<body>
    <header id="main-header">
        <span id="normal-logo">Shop Management</span>
        <span id="mini-logo">SM</span>
        <span id="menu-toggle">
            <i class="fa fa-bars" aria-hidden="true"></i>
        </span>
    </header>
    <!-- Main body -->
    <section id="main-body-wrapper">
        <div id="main-body-left">

            <div id="main-nav">
                <span class="nav-header">MAIN NAVIGATION</span>
                <a class="menu" href="Category.aspx"><i class="fa fa-folder-open" aria-hidden="true"></i>Category </a>
                <a class="menu" href="Customer.aspx"><i class="fa fa-user" aria-hidden="true"></i>Customers </a>
                <a class="menu" href="Product.aspx"><i class="fa fa-cubes" aria-hidden="true"></i>Products </a>
                <a class="menu" href="Employee.aspx"><i class="fa fa-users" aria-hidden="true"></i>Employees</a>
                <a class="menu" href="Shipper.aspx"><i class="fa fa-truck" aria-hidden="true"></i>Shippers </a>
                <a class="menu" href="Supplier.aspx"><i class="fa fa-home" aria-hidden="true"></i>Suppliers</a>
                <a class="menu menu-active" href="Order.aspx"><i class="fa fa-shopping-cart" aria-hidden="true"></i>Orders</a>
            </div>

        </div>
        <div id="main-body-left-mini">
            <div id="main-nav-mini">
                <a class="menu" href="Category.aspx"><i class="fa fa-folder-open" aria-hidden="true"></i>
                    <span class="menu-title">Category</span>
                </a>
                <a class="menu" href="Customer.aspx"><i class="fa fa-user" aria-hidden="true"></i>
                    <span class="menu-title">Customers</span>
                </a>

                <a class="menu" href="Product.aspx"><i class="fa fa-cubes" aria-hidden="true"></i>
                    <span class="menu-title">Products</span>
                </a>
                <a class="menu" href="Employee.aspx"><i class="fa fa-users" aria-hidden="true"></i>
                    <span class="menu-title">Employees</span>
                </a>
                <a class="menu" href="Shipper.aspx"><i class="fa fa-truck" aria-hidden="true"></i>
                    <span class="menu-title">Shippers</span>
                </a>
                <a class="menu" href="Supplier.aspx"><i class="fa fa-home" aria-hidden="true"></i>
                    <span class="menu-title">Suppliers</span>
                </a>
                <a class="menu menu-active" href="Order.aspx"><i class="fa fa-shopping-cart" aria-hidden="true"></i>
                    <span class="menu-title">Orders</span>
                </a>
            </div>
        </div>


        <div id="main-body-right" class="auto-style1">

            <form id="form1" runat="server">
                <asp:Panel ID="AlertBox" runat="server" CssClass="alert alert-success" Visible="false">
                    <span class="closebtn">×</span>
                    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                </asp:Panel>
                <span class="main-title">Order</span>
                <table>
                    <tr>
                        <td>
                            <div style="padding-left: 8px; padding-bottom: 22px;">
                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" class="btn btn-info btn-add-new" OnClick="btnAddNew_Click" Width="209px" Height="39px" Font-Size="Larger"></asp:Button>
                            </div>
                        </td>
                    </tr>
                </table>
                <center style="font-size: large">
                            <div>
                                    <asp:Label ID="Label1" runat="server" Text="Search"></asp:Label>&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="cbxSearch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cbxSearch_SelectedIndexChanged" >
                                        <asp:ListItem Selected="True">Customer Name</asp:ListItem>
                                        <asp:ListItem>Order Date</asp:ListItem>
                                        <asp:ListItem>Require Date</asp:ListItem>
                                        <asp:ListItem>Ship Date</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;
                                    <asp:TextBox ID="txtSearch" runat="server" Font-Size="Large"></asp:TextBox>
                                    <asp:Label ID="lbFrom" runat="server" Text="From Date"></asp:Label>&nbsp;
                                    <input type="date" runat="server" id="dtpFrom"/>&nbsp;
                                    <asp:Label ID="lbTo" runat="server" Text="To Date"></asp:Label>&nbsp;
                                    <input type="date" runat="server" id="dtpTo"/>&nbsp;&nbsp;
                                    &nbsp;
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" Font-Size="Large" OnClick="btnSearch_Click" ValidationGroup="search" ></asp:Button>&nbsp;&nbsp;
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-default" Font-Size="Large" OnClick="btnRefresh_Click" Width="102px"></asp:Button>
                              </div>
                            <div>
                                <asp:Label ID="errSearch" runat="server" Text="Label" Font-Size="Larger" ForeColor="Red"></asp:Label>
                            &nbsp;
                                <asp:RegularExpressionValidator ID="errDate" runat="server" ErrorMessage="Invalid date format" ControlToValidate="dtpFrom" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" ValidationGroup="search"></asp:RegularExpressionValidator>
&nbsp;
                                </div>   
                        </center>

                <div class="col-lg-12">
                    <br />
                    <asp:GridView ID="dgOrder" runat="server" CssClass="table table-hover table-condensed table-striped" GridLines="None" OnPageIndexChanging="dgOrder_PageIndexChanging" OnRowEditing="dgOrder_RowEditing" AllowSorting="True" OnSelectedIndexChanged="dgOrder_SelectedIndexChanged" OnSorting="dgOrder_Sorting" AutoGenerateDeleteButton="True" OnRowDataBound="dgOrder_RowDataBound" OnRowDeleting="dgOrder_RowDeleting">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="View Details" />
                            <asp:CommandField EditText="Update" ShowCancelButton="False" ShowEditButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>

                <!-- Dialog delete confirm -->
                <asp:Panel ID="DialogConfirm" runat="server" CssClass="dialog-confirm" Visible="false" Width="301px">
                    <div id="dialog-confirm-header">
                        Warning
                    </div>
                    <div id="dialog-confirm-body">
                        <p>Do you want to remove?</p>
                    </div>
                    <div id="dialog-confirm-footer">
                        <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="btn btn-primary" OnClick="btnYes_Click" />
                        <asp:Button ID="btnNo" runat="server" Text="No" CssClass="btn btn-default" OnClick="btnNo_Click" />
                    </div>
                </asp:Panel>

            </form>
        </div>
    </section>

    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/app.js"></script>

    <script>
        function changeClick() {
            var value = cbxSearch.SelectedValue.ToString();
            var txtSearch = document.getElementById('txtSearch');
            if (value.ToString() == "Customer ID") {
                txtSearch.hidden = true;
            }

        }
    </script>

</body>
</html>
