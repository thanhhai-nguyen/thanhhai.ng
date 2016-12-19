<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="Employee" %>

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
                <a class="menu" href="Product.aspx"><i class="fa fa-cubes" aria-hidden="true"></i>Products </a>
                <a class="menu menu-active" href="Employee.aspx"><i class="fa fa-users" aria-hidden="true"></i>Employees</a>
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

                <a class="menu" href="Product.aspx"><i class="fa fa-cubes" aria-hidden="true"></i>
                    <span class="menu-title">Products</span>
                </a>
                <a class="menu menu-active" href="Employee.aspx"><i class="fa fa-users" aria-hidden="true"></i>
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

                <span class="main-title">Employee</span>

                <!-- Input form -->
                <table class="row-info-wrapper">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>EmpID:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtID" runat="server" CssClass="input-id" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Last name:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtLaName" runat="server" Width="297px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lblLastName" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>First Name:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtFirName" runat="server" Width="300px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lblFirstName" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Courtesy title:</td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="ddlCourtesy" runat="server" Width="150px">
                                            <asp:ListItem Text="Ms." Value="Ms." />
                                            <asp:ListItem Text="Mrs." Value="Mrs." />
                                            <asp:ListItem Text="Mr." Value="Mr." />
                                            <asp:ListItem Text="Dr." Value="Dr." />
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Title:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lblTitle" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Date of birth:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtDOB" runat="server" Width="300px" TextMode="Date"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lblDate" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Hired date:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtHiredate" runat="server" Width="300px" TextMode="Date"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lblHired" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style2">
                            <table>
                                <tr>
                                    <td>Phone number:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lblPhone" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Address:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtAddress" runat="server" Width="300px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lblAddress" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>City:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtCity" runat="server" Width="300px"></asp:TextBox>
                                        <br />
                                        <asp:Label ID="lblCity" runat="server" ForeColor="#FF3300" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Country:</td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="ddlCountry" runat="server" Width="300px" DataSourceID="XmlCountryEmp" DataTextField="name" DataValueField="name" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/Countries.xml" XPath="Countries/Country"></asp:XmlDataSource>
                                        <asp:XmlDataSource ID="XmlCountryEmp" runat="server" DataFile="~/App_Data/Countries.xml" XPath="Countries/Country"></asp:XmlDataSource>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Region:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtRegion" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Postal code:</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtPostal" runat="server" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Manager ID:</td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="ddlManagerID" runat="server" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="auto-style2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary button-form" Height="43px" Width="77px" OnClick="btnSave_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default button-form" Height="44px" Style="margin-top: 10" Width="76px" OnClick="btnClear_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>


                <!-- Search form -->

                <div class="search-form">
                    Search&nbsp;
                    <asp:DropDownList ID="searchBy" runat="server" Height="30px" Width="150px" OnSelectedIndexChanged="searchBy_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="-1">--Search by--</asp:ListItem>
                        <asp:ListItem Value="0">Last name</asp:ListItem>
                        <asp:ListItem Value="1">First name</asp:ListItem>
                        <asp:ListItem Value="2">Date of birth</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Label ID="lblFromDate" runat="server" Text="Search value:"></asp:Label>
                    <asp:TextBox ID="txtSearchVl1" runat="server" Width="150px"></asp:TextBox>
                    <asp:Label ID="lblToDate" runat="server" Text="to:" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtSearchVl2" runat="server" Width="145px" TextMode="Date" Visible="False"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary button-form" Height="43px" Width="77px" OnClick="btnSearch_Click" CausesValidation="False" />
                    <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-default button-form" Height="44px" OnClick="btnRefresh_Click" Style="margin-top: 10" Text="Refresh" Width="76px" CausesValidation="False" />
                    <asp:Label ID="lblSearchError" runat="server" ForeColor="#FF3300" Text="lblSearchError" Visible="False"></asp:Label>
                </div>

                <!-- Data Table -->
                <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-striped" GridLines="None" AutoGenerateColumns="False" OnRowDeleting="gvEmployee_RowDeleting" OnSelectedIndexChanged="gvEmployee_SelectedIndexChanged" Width="968px" OnPageIndexChanging="gvEmployee_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="empid" HeaderText="ID" />
                        <asp:BoundField DataField="firstname" HeaderText="First name" />
                        <asp:BoundField DataField="lastname" HeaderText="Last name" />
                        <asp:BoundField DataField="titleofcourtesy" HeaderText="Courtesy" />
                        <asp:BoundField DataField="title" HeaderText="Title" />
                        <asp:BoundField DataField="birthdate" DataFormatString="{0:d}" HeaderText="Birthdate" Visible="False" />
                        <asp:BoundField DataField="hiredate" DataFormatString="{0:d}" HeaderText="Hiredate" Visible="False" />
                        <asp:BoundField DataField="phone" HeaderText="Phone" Visible="False" />
                        <asp:BoundField DataField="address" HeaderText="Address" Visible="False" />
                        <asp:BoundField DataField="city" HeaderText="City" Visible="False" />
                        <asp:BoundField DataField="country" HeaderText="Country" Visible="False" />
                        <asp:BoundField DataField="region" HeaderText="Region" Visible="False" />
                        <asp:BoundField DataField="postalcode" HeaderText="PostalCode" Visible="False" />
                        <asp:BoundField DataField="mgrid" HeaderText="ManagerID" Visible="False" />
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

