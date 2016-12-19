<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shop Management - Product</title>

    <link rel="stylesheet" href="Content/main.css" />
    <link rel="stylesheet" href="Content/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <style type="text/css">
        .auto-style1 {
            width: 383px;
        }

        .auto-style2 {
            left: 2px;
            top: -16px;
        }
    </style>

</head>
<body>
    <!-- Header -->

    <header id="main-header">
        <span id="normal-logo">Shop Management</span>
        <span id="mini-logo">SM</span>
        <span id="menu-toggle">
            <i class="fa fa-bars" aria-hidden="true"></i>
        </span>
    </header>
    <!-- Main body -->
    <section id="main-body-wrapper" class="auto-style2">
        <div id="main-body-left">
            <div id="main-nav">
                <span class="nav-header">MAIN NAVIGATION</span>
                <a class="menu" href="Category.aspx"><i class="fa fa-folder-open" aria-hidden="true"></i>Category </a>
                <a class="menu" href="Customer.aspx"><i class="fa fa-user" aria-hidden="true"></i>Customers </a>
                <a class="menu menu-active" href="Product.aspx"><i class="fa fa-cubes" aria-hidden="true"></i>Products </a>
                <a class="menu" href="Employee.aspx"><i class="fa fa-users" aria-hidden="true"></i>Employees</a>
                <a class="menu" href="Shipper.aspx"><i class="fa fa-truck" aria-hidden="true"></i>Shippers </a>
                <a class="menu" href="Supplier.aspx"><i class="fa fa-home" aria-hidden="true"></i>Suppliers</a>
                <a class="menu" href="Order.aspx"><i class="fa fa-shopping-cart" aria-hidden="true"></i>Orders</a>
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

                <a class="menu menu-active" href="Product.aspx"><i class="fa fa-cubes" aria-hidden="true"></i>
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
                <a class="menu" href="Order.aspx"><i class="fa fa-shopping-cart" aria-hidden="true"></i>
                    <span class="menu-title">Orders</span>
                </a>
            </div>
        </div>




        <div id="main-body-right">
            <form id="form1" runat="server">
                <!-- Alert Box -->
                <asp:Panel ID="AlertBox" runat="server" CssClass="alert alert-success">
                    <span class="closebtn">&times;</span>
                    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                </asp:Panel>

                <span class="main-title">Product</span>

                <!-- Input form -->
                <table class="row-info-wrapper">
                    <tr>
                        <td>Product ID:</td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtProductID" runat="server" CssClass="input-id " ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Product Name:</td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtProductName" runat="server" Width="305px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage="* Name must be not empty" ForeColor="Red"
                                ControlToValidate="txtProductName"></asp:RequiredFieldValidator>
                        </td>

                    </tr>
                    <tr>
                        <td>Supplier ID:</td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtSupID" runat="server" Width="86px" BackColor="#EEEEEE" ReadOnly="True"></asp:TextBox>
                            <asp:ImageButton ID="btnSupID" runat="server" Height="23px" ImageUrl="./Icon/search-loop-512.png" CausesValidation="false" OnClick="btnSupID_Click" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ErrorMessage="* Supplier ID must be not empty" ForeColor="Red"
                                ControlToValidate="txtSupID"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Category ID:</td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtCatID" runat="server" Width="86px" BackColor="#EEEEEE" ReadOnly="True"></asp:TextBox>
                            <asp:ImageButton ID="btnCatID" runat="server" Height="23px" ImageUrl="./Icon/search-loop-512.png" CausesValidation="false" OnClick="btnCatID_Click" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ErrorMessage="* Category ID must be not empty" ForeColor="Red"
                                ControlToValidate="txtCatID"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Unit price:</td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtUPrice" runat="server" Width="107px"></asp:TextBox>
                            <asp:Label ID="errUnitPrice" runat="server" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ErrorMessage="* Unit price must be not empty" ForeColor="Red"
                                ControlToValidate="txtUPrice"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Status:</td>
                        <td class="auto-style1">
                            <asp:CheckBox ID="chkDiscontinued" runat="server" Text="Discontinued" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary button-form" Height="43px" Width="77px" OnClick="btnSave_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default button-form" Height="44px" Width="76px" OnClick="btnClear_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>


                <asp:Panel ID="supplierPanel" runat="server" CssClass="supplier-panel">
                    <asp:GridView ID="dgSupplier" runat="server" CssClass="table table-striped" GridLines="None" AllowPaging="True" OnPageIndexChanging="dgSupplier_PageIndexChanging" OnSelectedIndexChanged="dgSupplier_SelectedIndexChanged" PageSize="5">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <HeaderStyle ForeColor="#0066FF" />
                    </asp:GridView>
                </asp:Panel>

                <asp:Panel ID="categoryPanel" runat="server" CssClass="category-panel">
                    <asp:GridView ID="dgCategory" runat="server" CssClass="table table-striped" GridLines="None" AllowPaging="True" PageSize="5" OnPageIndexChanging="dgCategory_PageIndexChanging" OnSelectedIndexChanged="dgCategory_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <HeaderStyle ForeColor="#0066FF" />
                    </asp:GridView>
                </asp:Panel>



                <!-- Search form -->

                <div class="search-form">
                    Search&nbsp;
                    <asp:DropDownList ID="cbbSearchType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbbSearchType_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="product name">product name</asp:ListItem>
                        <asp:ListItem>category  name</asp:ListItem>
                        <asp:ListItem>supplier name</asp:ListItem>
                        <asp:ListItem>unit price</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:TextBox ID="txtSearchValue" runat="server" Width="141px"></asp:TextBox>
                    <asp:Label ID="lblTo" runat="server" Text="To" Visible="False"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtSearchValue2" runat="server" Width="141px" Visible="False"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" CausesValidation="False" />
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-default" OnClick="btnRefresh_Click" CausesValidation="False" />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=" "></asp:Label>

                </div>

                <!-- Data Table -->
                <asp:GridView ID="dgProduct" CssClass="table table-striped" GridLines="None" runat="server" AllowPaging="True" OnRowDeleting="dgProduct_RowDeleting" OnSelectedIndexChanged="dgProduct_SelectedIndexChanged" OnPageIndexChanging="dgProduct_PageIndexChanging" OnRowCreated="dgProduct_RowCreated">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle ForeColor="#0066FF" />
                </asp:GridView>


                <!-- Dialog delete confirm -->
                <asp:Panel ID="DialogConfirm" runat="server" CssClass="dialog-confirm" Visible="false">
                    <div id="dialog-confirm-header">
                        Warning
                    </div>
                    <div id="dialog-confirm-body">
                        <p>Do you want to remove?</p>
                    </div>
                    <div id="dialog-confirm-footer">
                        <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="btn btn-primary" OnClick="btnYes_Click" CausesValidation="False" />
                        <asp:Button ID="btnNo" runat="server" Text="No" CssClass="btn btn-default" OnClick="btnNo_Click" CausesValidation="False" />
                    </div>
                </asp:Panel>

            </form>
        </div>
    </section>



    <!-- For javascript -->
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script src="Scripts/app.js"></script>



</body>
</html>
