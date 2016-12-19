<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderInput.aspx.cs" Inherits="OrderInput" %>

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
            height: 40px;
        }

        .auto-style2 {
            height: 44px;
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


        <div id="main-body-right">
            <form id="form1" runat="server">
                <br />
                <span class="main-title">Order Input</span>
                <div class="container">
                    <div class="row">

                        <div class="col-md-6">
                            <table class="table table-striped">
                                <tr>
                                    <td class="auto-style1">Order ID</td>
                                    <td>
                                        <asp:TextBox ID="txtOrderID" runat="server" ReadOnly="True" Width="97px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Customer ID</td>
                                    <td>
                                        <asp:TextBox ID="txtCustomerID" runat="server" Width="96px"></asp:TextBox>
                                        <asp:ImageButton ID="btnCusID" runat="server" Height="23px" ImageUrl="~/Icon/search-loop-512.png" OnClick="btnCusID_Click" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerID" ErrorMessage="Please input value" ValidationGroup="InputForm" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="auto-style1">Order Date</td>
                                    <td>
                                        <input type="date" id="dtpOrderDate" runat="server" />
                                        <asp:Label ID="errOrderDate" runat="server" Text="Please input Order Date" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Require Date</td>
                                    <td>
                                        <input type="date" id="dtpRequireDate" runat="server" />
                                        <asp:Label ID="errRequireDate" runat="server" Text="Please input Require Date" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Shipped Date</td>
                                    <td class="auto-style2">
                                        <input type="date" id="dtpShipDate" runat="server" />
                                        <input type="checkbox" id="ckNotShip" onclick="onClickckNotShip()" value="Not Ship" runat="server" />
                                        <asp:Label ID="Label1" runat="server" Text="Not Ship"></asp:Label>&nbsp;&nbsp;
                                <asp:Label ID="errShipDate" runat="server" Text="Please input Ship Date" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5">Employee ID</td>
                                    <td class="auto-style6">
                                        <asp:TextBox ID="txtEmployeeID" runat="server" Width="97px"></asp:TextBox>
                                        <asp:ImageButton ID="btnEmpID" runat="server" Height="23px" ImageUrl="~/Icon/search-loop-512.png" OnClick="btnEmpID_Click" CausesValidation="false" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmployeeID" ErrorMessage="Please input value" ValidationGroup="InputForm" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Shipper ID</td>
                                    <td>
                                        <asp:TextBox ID="txtShipperID" runat="server" Width="97px"></asp:TextBox>
                                        <asp:ImageButton ID="btnShipperID" runat="server" Height="23px" ImageUrl="~/Icon/search-loop-512.png" OnClick="btnShipperID_Click" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtShipperID" ErrorMessage="Please input value" ValidationGroup="InputForm" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-md-6">
                            <table class="table table-striped">

                                <tr>
                                    <td class="auto-style2">Freight</td>
                                    <td>
                                        <asp:TextBox ID="txtFreight" runat="server" Width="92px" TextMode="Number" step="any" min="1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFreight" ErrorMessage="Please input value" ValidationGroup="InputForm" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Ship Name</td>
                                    <td>
                                        <asp:TextBox ID="txtShipName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtShipName" ErrorMessage="Please input value" ValidationGroup="InputForm" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Ship Address</td>
                                    <td>
                                        <asp:TextBox ID="txtShipAddress" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtShipAddress" ErrorMessage="Please input value" ValidationGroup="InputForm" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Ship City</td>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtShipCity" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtShipCity" ErrorMessage="Please input value" ValidationGroup="InputForm" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Ship Region</td>
                                    <td>
                                        <asp:TextBox ID="txtShipRegion" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtShipRegion" ErrorMessage="Please input value" ValidationGroup="InputForm" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Ship Postal Code</td>
                                    <td>
                                        <asp:TextBox ID="txtShipPostalCode" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtShipPostalCode" ErrorMessage="Postal Code is 5 digit" ValidationExpression="\d{5}" ValidationGroup="InputForm" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style2">Ship Country
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="txtShipCountry" runat="server" DataSourceID="xmlCountry" DataTextField="name">
                                        </asp:DropDownList>
                                        <asp:XmlDataSource ID="xmlCountry" runat="server" DataFile="~/App_Data/Countries.xml" XPath="Countries/Country"></asp:XmlDataSource>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtShipCountry" ErrorMessage="Please input value" ValidationGroup="InputForm" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <center>
                <div class="col-lg-12">

                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="264px" class="btn btn-info" OnClick="btnSave_Click" Font-Size="Large" ValidationGroup="InputForm" />
                    &nbsp; &nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="264px" class="btn btn-default" OnClick="btnReset_Click" Font-Size="Large"/>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </div>
            </center>
                </div>
                <br />
                <br />
                <center>
            <div>
                <div class="col-lg-12">
                    <asp:GridView ID="dgCustomer" runat="server" CssClass="table table-hover" GridLines="None" OnSelectedIndexChanged="dgCustomer_SelectedIndexChanged" OnPageIndexChanging="dgCustomer_PageIndexChanging">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </center>
                <center>
            <div>
                <div class="col-lg-12">
                    <asp:GridView ID="dgEmp" runat="server" CssClass="table table-hover" GridLines="None" OnSelectedIndexChanged="dgEmp_SelectedIndexChanged" OnPageIndexChanging="dgEmp_PageIndexChanging">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </center>
                <center>
            <div>
                <div class="col-lg-12">
                    <asp:GridView ID="dgShipper" runat="server" CssClass="table table-hover" GridLines="None" OnSelectedIndexChanged="dgShipper_SelectedIndexChanged" OnPageIndexChanging="dgShipper_PageIndexChanging">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </center>

            </form>
        </div>
    </section>

    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/app.js"></script>

    <script>
        function onClickckNotShip() {
            var checked = document.getElementById('ckNotShip').checked;
            var dtpShipDate = document.getElementById('dtpShipDate');
            if (checked === true) {
                dtpShipDate.disabled = true;
            } else {
                dtpShipDate.disabled = false;
            }
        }
    </script>
</body>
</html>
