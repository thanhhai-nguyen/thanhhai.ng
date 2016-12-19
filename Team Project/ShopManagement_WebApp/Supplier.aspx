<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Supplier.aspx.cs" Inherits="_Supplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shop Management - Supplier</title>

    <link rel="stylesheet" href="Content/main.css" />
    <link rel="stylesheet" href="Content/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <style type="text/css">
        .auto-style1 {
            width: 151px;
        }

        .auto-style2 {
            left: 2px;
            top: -16px;
        }

        .auto-style3 {
            width: 151px;
            height: 20px;
        }

        .auto-style4 {
            height: 20px;
            width: 342px;
        }

        .auto-style5 {
            width: 342px;
        }

        .auto-style6 {
            left: 2px;
            top: -16px;
            width: 151px;
        }

        .auto-style7 {
            left: 65px;
            top: 31px;
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

    <section id="main-body-wrapper" class="auto-style2">
        <div id="main-body-left">
            <div id="main-nav">
                <span class="nav-header">MAIN NAVIGATION</span>
                <a class="menu" href="Category.aspx"><i class="fa fa-folder-open" aria-hidden="true"></i>Category </a>
                <a class="menu" href="Customer.aspx"><i class="fa fa-user" aria-hidden="true"></i>Customers </a>
                <a class="menu" href="Product.aspx"><i class="fa fa-cubes" aria-hidden="true"></i>Products </a>
                <a class="menu" href="Employee.aspx"><i class="fa fa-users" aria-hidden="true"></i>Employees</a>
                <a class="menu" href="Shipper.aspx"><i class="fa fa-truck" aria-hidden="true"></i>Shippers </a>
                <a class="menu menu-active" href="Supplier.aspx"><i class="fa fa-home" aria-hidden="true"></i>Suppliers</a>
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

                <a class="menu" href="Product.aspx"><i class="fa fa-cubes" aria-hidden="true"></i>
                    <span class="menu-title">Products</span>
                </a>
                <a class="menu" href="Employee.aspx"><i class="fa fa-users" aria-hidden="true"></i>
                    <span class="menu-title">Employees</span>
                </a>
                <a class="menu" href="Shipper.aspx"><i class="fa fa-truck" aria-hidden="true"></i>
                    <span class="menu-title">Shippers</span>
                </a>
                <a class="menu menu-active" href="Supplier.aspx"><i class="fa fa-home" aria-hidden="true"></i>
                    <span class="menu-title">Suppliers</span>
                </a>
                <a class="menu" href="Order.aspx"><i class="fa fa-shopping-cart" aria-hidden="true"></i>
                    <span class="menu-title">Orders</span>
                </a>
            </div>
        </div>

        <div id="main-body-right" class="auto-style7">
            <form id="form1" runat="server">
                <asp:Panel ID="AlertBox" runat="server" CssClass="alert alert-success" Visible="false">
                    <span class="closebtn">&times;</span>
                    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                </asp:Panel>

                <span class="main-title">Supplier</span>

                <table class="row-info-wrapper">
                    <tr>
                        <td class="auto-style3"><strong>Supplier ID</strong></td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtSupID" CssClass="input-id form-control " runat="server" Style="margin-left: 0px" Enabled="False" Width="180px"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><strong>Company Name</strong></td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtCompName" runat="server" Style="margin-left: 0px" Width="305px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Company must be not empty" ControlToValidate="txtCompName" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><strong>Contact Name</strong></td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtContName" runat="server" Style="margin-left: 0px" Width="305px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Contact name must be not empty" ControlToValidate="txtContTitle" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><strong>Contact Title</strong></td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtContTitle" runat="server" Style="margin-left: 0px" Width="305px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Contact title must be not empty" ControlToValidate="txtContName" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><strong>Address</strong></td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtAddress" runat="server" Style="margin-left: 0px" Width="305px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Address must be not empty" ControlToValidate="txtAddress" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6"><strong>City</strong></td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtCity" runat="server" Style="margin-left: 0px" Width="305px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="City must be not empty" ControlToValidate="txtCity" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><strong>Region</strong></td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtRegion" runat="server" Style="margin-left: 0px" Width="305px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="auto-style3"><strong>Postal Code</strong></td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtPostalCode" runat="server" Style="margin-left: 0px" Width="305px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Postal Code must have 5 digits" ControlToValidate="txtPostalCode" ValidationExpression="\d{5}" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><strong>Country</strong></td>
                        <td class="auto-style5">
                            <asp:DropDownList ID="dlCountry" runat="server" Style="margin-left: 0px" Width="265px" CssClass="dropdown">
                                <asp:ListItem>Argentina</asp:ListItem>
                                <asp:ListItem>Austria</asp:ListItem>
                                <asp:ListItem>Belgium</asp:ListItem>
                                <asp:ListItem>Brazil</asp:ListItem>
                                <asp:ListItem>Canada</asp:ListItem>
                                <asp:ListItem>Denmark</asp:ListItem>
                                <asp:ListItem>Finland</asp:ListItem>
                                <asp:ListItem>France</asp:ListItem>
                                <asp:ListItem>Germany</asp:ListItem>
                                <asp:ListItem>Italy</asp:ListItem>
                                <asp:ListItem>Mexico</asp:ListItem>
                                <asp:ListItem>Portugal</asp:ListItem>
                                <asp:ListItem>Spain</asp:ListItem>
                                <asp:ListItem>Sweden</asp:ListItem>
                                <asp:ListItem>Switzerland</asp:ListItem>
                                <asp:ListItem>UK</asp:ListItem>
                                <asp:ListItem>Venezuela</asp:ListItem>
                            </asp:DropDownList>
                            <td></td>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6"><strong>Phone</strong></td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtPhone" runat="server" Style="margin-left: 0px" Width="305px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Phone must be not empty" ControlToValidate="txtPhone" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><strong>Fax</strong></td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtFax" runat="server" Style="margin-left: 0px" Width="305px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Button ID="btnSave" CssClass="btn btn-primary button-form" runat="server" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnReset" runat="server" CssClass="btn btn-default  " CausesValidation="False" OnClick="btnReset_Click" Text="Reset" />
                        </td>
                    </tr>

                </table>
                <br />
                <br />

                <asp:DropDownList ID="drSearch" runat="server">
                    <asp:ListItem Value="1">Company Name</asp:ListItem>
                    <asp:ListItem Value="2">Contact Name</asp:ListItem>
                    <asp:ListItem Value="3">Country</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtSearch" runat="server" Width="265px"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" CausesValidation="False" OnClick="btnSearch_Click" />
                <br />
                Sort By
                <asp:DropDownList ID="drSortItem" runat="server">
                    <asp:ListItem>Supplier ID</asp:ListItem>
                    <asp:ListItem>Company Name</asp:ListItem>
                    <asp:ListItem>Contact Name</asp:ListItem>
                    <asp:ListItem>Contact Title</asp:ListItem>
                    <asp:ListItem>Address</asp:ListItem>
                    <asp:ListItem>City</asp:ListItem>
                    <asp:ListItem>Region</asp:ListItem>
                    <asp:ListItem>Postal Code</asp:ListItem>
                    <asp:ListItem>Country</asp:ListItem>
                    <asp:ListItem>Phone</asp:ListItem>
                    <asp:ListItem>Fax</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnSort" runat="server" CssClass="btn btn-primary" CausesValidation="False" OnClick="btnSort_Click" Text="Sort" />
                <asp:Button ID="btnDefault" runat="server" CssClass="btn btn-default" CausesValidation="False" OnClick="btnDefault_Click" Text="Refresh" />
                <br />
                <br />
                <asp:GridView ID="gvSupplier" CssClass="table table-striped" runat="server" OnSelectedIndexChanged="gvSupplier_SelectedIndexChanged" OnRowDeleting="gvSupplier_RowDeleting" AutoGenerateColumns="False" OnSorting="gvSupplier_Sorting" AllowPaging="True" PageSize="8" OnPageIndexChanging="gvSupplier_PageIndexChanging" GridLines="None">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                        <asp:BoundField DataField="Supplier ID" HeaderText="Supplier ID" SortExpression="SupplierID" />
                        <asp:BoundField DataField="Company Name" HeaderText="Company Name" SortExpression="Company Name" />
                        <asp:BoundField DataField="Contact Name" HeaderText="Contact Name" SortExpression="Contact Name" />
                        <asp:BoundField DataField="Contact Title" HeaderText="Contact Title" SortExpression="Contact Title" />
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                        <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                        <asp:BoundField DataField="Postal Code" HeaderText="Postal Code" SortExpression="Postal Code" />
                        <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                        <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
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
