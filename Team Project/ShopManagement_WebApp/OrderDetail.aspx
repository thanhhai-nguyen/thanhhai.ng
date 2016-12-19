<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="OrderDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shop Management</title>
    <link rel="stylesheet" href="Content/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />
    <link rel="stylesheet" href="Content/main.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />

    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            width: 100%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }

        .auto-style2 {
            width: 220px;
        }

        .auto-style3 {
            left: 0;
            top: -405px;
        }

        .auto-style4 {
            width: 857px;
        }

        .auto-style5 {
            left: 0;
            top: -405px;
            width: 857px;
        }

        .auto-style6 {
            width: 854px;
        }

        .auto-style7 {
            left: 0;
            top: -405px;
            width: 854px;
        }

        .auto-style8 {
            width: 845px;
        }

        .auto-style9 {
            left: 0;
            top: -405px;
            width: 350px;
        }

        .auto-style10 {
            width: 350px;
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


        <div id="main-body-right" class="auto-style3">
            <form id="form1" runat="server">
             <asp:Panel ID="AlertBox" runat="server" CssClass="alert alert-success" Visible="false">
                    <span class="closebtn">&times;</span>
                    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                </asp:Panel>
            <span class="main-title">Order Detail</span>
            
                <table>
                    <tr>
                        <td class="col-lg-4">
                            <div style="padding-left: 30px;" class="auto-style2">
                                <asp:Label ID="Label1" runat="server" Text="Order ID:  " Font-Size="Large"></asp:Label>
                                <asp:Label ID="txtOrderID" runat="server" ReadOnly="True" Font-Size="XX-Large" Font-Bold="true" Width="107px"></asp:Label>
                                <div>
                                </div>
                        </td>
                        <td class="col-lg-10" style="padding-left: 650px">
                            <center>
                            <center>
                            </center>
                        </td>
                    </tr>
                </table>
                <br />
                <center style="font-size: large">
                            <div>
                                <asp:Label ID="Label2" runat="server" Text="Search" Font-Size="X-Large"></asp:Label>&nbsp;
                                <asp:DropDownList ID="cbxSearch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cbxSearch_SelectedIndexChanged" >
                                    <asp:ListItem>Product Name (Order Detail)</asp:ListItem>
                                    <asp:ListItem>Total Value</asp:ListItem>
                                </asp:DropDownList>
                    &nbsp;
                    <asp:TextBox ID="txtSearch" runat="server" ReadOnly="True" Font-Size="Large"></asp:TextBox>
                    &nbsp; &nbsp;
                                <asp:Label ID="lbFrom" runat="server" Text="From"></asp:Label>&nbsp;
                                <asp:TextBox ID="txtFrom" runat="server" ></asp:TextBox>&nbsp;
                                <asp:Label ID="lbTo" runat="server" Text="To"></asp:Label>&nbsp;
                                <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" Width="102px" Font-Size="Large" OnClick="btnSearch_Click"></asp:Button>&nbsp;&nbsp;
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-default" Font-Size="Large" OnClick="btnRefresh_Click" Width="102px"></asp:Button>
                            </div>
                            <div>
                                <asp:Label ID="errSearch" runat="server" Text="Label" Font-Size="Larger" ForeColor="Red"></asp:Label>
                            </div> 
                        </center>

                <br />

                <center class="col-lg-12">
                <div>
            <div class="col-lg-12">
                <table class="table table-striped">
                    <tr>
                        <td class="auto-style10">Order ID</td>
                        <td class="auto-style7">
                            <asp:TextBox ID="txtorder" runat="server" ReadOnly="True" Width="97px" BackColor="#EEEEEE"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Product ID</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtProductID" runat="server" Width="96px"></asp:TextBox>
                            <asp:ImageButton ID="btnCusID" runat="server" Height="23px" ImageUrl="~/Icon/search-loop-512.png" OnClick="btnCusID_Click" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductID" ErrorMessage="Please input value" ForeColor="Red" ValidationGroup="InputForm"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style9">Unit price</td>
                        <td class="auto-style6">
                            <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnitPrice" ErrorMessage="Please input value" ForeColor="Red" ValidationGroup="InputForm"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Quantity</td>
                        <td class="auto-style8">
                            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Please input value" ForeColor="Red" ValidationGroup="InputForm"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Discount</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtDiscount" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDiscount" ErrorMessage="Please input value" ForeColor="Red" ValidationGroup="InputForm"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                </div>

            <div class="col-lg-11">
                <table>
                    <tr>
                        <td colspan="10" class="auto-style5">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="179px" class="btn btn-info" Font-Size="Large" OnClick="btnSave_Click" ValidationGroup="InputForm"/>
                            &nbsp; &nbsp;
                                &nbsp; &nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="179px" class="btn btn-info" Font-Size="Large" OnClick="btnReset_Click" CssClass="btn btn-default"/>
                            &nbsp; &nbsp;<asp:Label ID="oldProID" runat="server" Visible="False"></asp:Label>
                    
                        </td>
                    </tr>
                </table>
            </div>
                    </div>
                <br />
                <br />
                <center><div class="col-lg-12">
                    <asp:GridView ID="dgProduct" runat="server" CssClass="table table-hover" GridLines="None" OnSelectedIndexChanged="dgCustomer_SelectedIndexChanged" OnPageIndexChanging="dgCustomer_PageIndexChanging">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>

                </center>
                </center>


                <div style="padding-left: 50px">

                    <div class="auto-style1">
                        <br />
                        <asp:GridView ID="dgOrderDetail" runat="server" CssClass="table table-striped table-hover table-condensed " GridLines="None" OnPageIndexChanging="dgOrderDetail_PageIndexChanging" AllowSorting="True" OnSorting="dgOrderDetail_Sorting" OnRowDeleting="dgOrderDetail_RowDeleting" OnSelectedIndexChanged="dgOrderDetail_SelectedIndexChanged1">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
        </div>





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
</body>
</html>
