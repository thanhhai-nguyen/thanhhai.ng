<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shop Management - Category</title>

    <link rel="stylesheet" href="Content/main.css" />
    <link rel="stylesheet" href="Content/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <style type="text/css">
        .auto-style2 {
            left: 2px;
            top: -16px;
        }

        .auto-style3 {
            width: 376px;
        }

        .auto-style5 {
            height: 50px;
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
                <a class="menu menu-active" href="Customer.aspx"><i class="fa fa-user" aria-hidden="true"></i>Customers </a>
                <a class="menu" href="Product.aspx"><i class="fa fa-cubes" aria-hidden="true"></i>Products </a>
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
                <a class="menu menu-active" href="Customer.aspx"><i class="fa fa-user" aria-hidden="true"></i>
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

                <span class="main-title">Customer</span>

                <!-- Input form -->
                <table class="row-info-wrapper">
                    <tr>
                        <td>Customer ID</td>
                        <td>
                            <asp:TextBox ID="txtID" runat="server" CssClass="input-id " Height="35px"></asp:TextBox>
                        </td>

                        <td><b>Region</b></td>
                        <td>
                            <asp:TextBox ID="txtRegion" runat="server" Height="35px" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Company Name</td>
                        <td>
                            <asp:TextBox ID="txtCompName" runat="server" Width="305px" Height="35px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Company must be not empty" ControlToValidate="txtCompName" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td><b>Postal Code</b></td>
                        <td>
                            <asp:TextBox ID="txtPostCode" runat="server" Height="35px" Width="250px"></asp:TextBox>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="* Postal Code must have 5 digits" ControlToValidate="txtPostCode" ValidationExpression="\d{5}" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Contact Name</td>
                        <td>
                            <asp:TextBox ID="txtContName" runat="server" Height="35px" Width="305px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Contact name must be not empty" ControlToValidate="txtContName" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td><b>Country</b></td>
                        <td>
                            <asp:DropDownList ID="cbCountry" runat="server" DataSourceID="XmlCountrySoucre" ViewStateMode="Enabled" DataTextField="name" DataValueField="name" Height="35px" Width="250px">
                            </asp:DropDownList>
                            <asp:XmlDataSource ID="XmlCountrySoucre" runat="server" DataFile="~/App_Data/Countries.xml"></asp:XmlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Contact Title</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtContTitile" runat="server" Width="305px" Height="35px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Contact title must be not empty" ControlToValidate="txtContTitile" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style5"><b>Phone</b></td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtPhone" runat="server" Height="35px" Width="250px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPhone" ErrorMessage="* Phone must be not empty" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Address</td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" Width="310px" Height="35px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Address must be not empty" ControlToValidate="txtAddress" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td><b>Fax</b></td>
                        <td>
                            <asp:TextBox ID="txtFax" runat="server" Height="35px" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><b>City</b></td>
                        <td class="auto-style3">
                            <asp:TextBox ID="txtCity" runat="server" Height="35px" Width="308px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* City must be not empty" ControlToValidate="txtCity" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style3">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary button-form" Height="43px" Width="77px" OnClick="btnSave_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default button-form" Height="44px" Width="76px" OnClick="btnClear_Click" CausesValidation="False" />
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>

                <!-- Search form -->

                <div class="search-form">
                    Search&nbsp;
                    <asp:DropDownList ID="cbbSearchType" runat="server">
                        <asp:ListItem Selected="True" Value="compname">Company Name</asp:ListItem>
                        <asp:ListItem Value="contname">Contact Name</asp:ListItem>
                        <asp:ListItem Value="country">Country</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:TextBox ID="txtSearchValue" runat="server" Width="223px"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" CausesValidation="False" />
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-default" OnClick="btnRefresh_Click" CausesValidation="False" />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=" "></asp:Label>

                </div>

                <!-- Data Table -->
                <asp:GridView ID="dgCustomer" CssClass="table table-striped" GridLines="None" runat="server" AllowPaging="True" AllowSorting="True" OnRowDeleting="dgCustomer_RowDeleting" OnSelectedIndexChanged="dgCustomer_SelectedIndexChanged" PageSize="15" OnSorting="dgCustomer_Sorting" OnPageIndexChanging="dgCustomer_PageIndexChanging">
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
