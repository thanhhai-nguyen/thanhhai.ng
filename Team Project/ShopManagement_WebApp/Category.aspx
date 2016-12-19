<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shop Management - Category</title>

    <link rel="stylesheet" href="Content/main.css" />
    <link rel="stylesheet" href="Content/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <style type="text/css">
        .auto-style1 {
            width: 331px;
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
                <a class="menu menu-active" href="Category.aspx"><i class="fa fa-folder-open" aria-hidden="true"></i>Category </a>
                <a class="menu" href="Customer.aspx"><i class="fa fa-user" aria-hidden="true"></i>Customers </a>
                <a class="menu" href="Product.aspx"><i class="fa fa-cubes" aria-hidden="true"></i>Products </a>
                <a class="menu" href="Employee.aspx"><i class="fa fa-users" aria-hidden="true"></i>Employees</a>
                <a class="menu" href="Shipper.aspx"><i class="fa fa-truck" aria-hidden="true"></i>Shippers </a>
                <a class="menu" href="Supplier.aspx"><i class="fa fa-home" aria-hidden="true"></i>Suppliers</a>
                <a class="menu" href="Order.aspx"><i class="fa fa-shopping-cart" aria-hidden="true"></i>Orders</a>
            </div>

        </div>
        <div id="main-body-left-mini">
            <div id="main-nav-mini">
                <a class="menu menu-active" href="Category.aspx"><i class="fa fa-folder-open" aria-hidden="true"></i>
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
                <a class="menu" href="Order.aspx"><i class="fa fa-shopping-cart" aria-hidden="true"></i>
                    <span class="menu-title">Orders</span>
                </a>
            </div>
        </div>




        <div id="main-body-right">
            <form id="form1" runat="server">
                <!-- Alert Box -->
                <asp:Panel ID="AlertBox" runat="server" CssClass="alert alert-success" Visible="false">
                    <span class="closebtn">&times;</span>
                    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                </asp:Panel>

                <span class="main-title">Category</span>

                <!-- Input form -->
                <table class="row-info-wrapper">
                    <tr>
                        <td>Category ID:</td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtID" runat="server" CssClass="input-id " ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Category Name:</td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtCatName" runat="server" Width="305px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage="* Category name must be not empty" ForeColor="Red"
                                ControlToValidate="txtCatName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Description Name:</td>
                        <td class="auto-style1">
                            <asp:TextBox ID="txtDescription" runat="server" Height="84px" TextMode="MultiLine" Width="309px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ErrorMessage="* Description must be not empty" ForeColor="Red"
                                ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
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

                <!-- Search form -->

                <div class="search-form">
                    Search&nbsp;
                    <asp:DropDownList ID="cbbSearchType" runat="server">
                        <asp:ListItem Selected="True" Value="name">name</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:TextBox ID="txtSearchValue" runat="server" Width="223px"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" CausesValidation="False" />
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-default" OnClick="btnRefresh_Click" CausesValidation="False" />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=" "></asp:Label>

                </div>

              <!-- Data Table -->
                <asp:GridView ID="dgCategory" CssClass="table table-striped" GridLines="None" runat="server" AllowPaging="True" OnRowDeleting="dgCategory_RowDeleting" OnSelectedIndexChanged="dgCategory_SelectedIndexChanged" PageSize="5" OnPageIndexChanging="dgCategory_PageIndexChanging" >
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
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
