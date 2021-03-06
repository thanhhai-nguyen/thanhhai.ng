USE [master]
GO
/****** Object:  Database [TSQLFundamentals2008]    Script Date: 18-12-2016 1:18:36 PM ******/
CREATE DATABASE [TSQLFundamentals2008]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TSQLFundamentals2008', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TSQLFundamentals2008.mdf' , SIZE = 4352KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TSQLFundamentals2008_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TSQLFundamentals2008_log.LDF' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TSQLFundamentals2008] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TSQLFundamentals2008].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TSQLFundamentals2008] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET ARITHABORT OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TSQLFundamentals2008] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TSQLFundamentals2008] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TSQLFundamentals2008] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TSQLFundamentals2008] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TSQLFundamentals2008] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TSQLFundamentals2008] SET  MULTI_USER 
GO
ALTER DATABASE [TSQLFundamentals2008] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TSQLFundamentals2008] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TSQLFundamentals2008] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TSQLFundamentals2008] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TSQLFundamentals2008] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TSQLFundamentals2008]
GO
/****** Object:  Schema [HR]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE SCHEMA [HR]
GO
/****** Object:  Schema [Production]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE SCHEMA [Production]
GO
/****** Object:  Schema [Sales]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE SCHEMA [Sales]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [smallint] NOT NULL,
	[ISO] [char](2) NULL,
	[Name] [varchar](80) NULL,
	[NiceName] [varchar](80) NULL,
	[ISO3] [char](3) NULL,
	[NumCode] [smallint] NULL,
	[PhoneCode] [smallint] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [HR].[Employees]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[Employees](
	[empid] [int] IDENTITY(1,1) NOT NULL,
	[lastname] [nvarchar](20) NOT NULL,
	[firstname] [nvarchar](10) NOT NULL,
	[title] [nvarchar](30) NOT NULL,
	[titleofcourtesy] [nvarchar](25) NOT NULL,
	[birthdate] [datetime] NOT NULL,
	[hiredate] [datetime] NOT NULL,
	[address] [nvarchar](60) NOT NULL,
	[city] [nvarchar](15) NOT NULL,
	[region] [nvarchar](15) NULL,
	[postalcode] [nvarchar](10) NULL,
	[country] [nvarchar](15) NOT NULL,
	[phone] [nvarchar](24) NOT NULL,
	[mgrid] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[empid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Production].[Categories]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Production].[Categories](
	[categoryid] [int] IDENTITY(1,1) NOT NULL,
	[categoryname] [nvarchar](15) NOT NULL,
	[description] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[categoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Production].[Products]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Production].[Products](
	[productid] [int] IDENTITY(1,1) NOT NULL,
	[productname] [nvarchar](40) NOT NULL,
	[supplierid] [int] NOT NULL,
	[categoryid] [int] NOT NULL,
	[unitprice] [money] NOT NULL CONSTRAINT [DFT_Products_unitprice]  DEFAULT ((0)),
	[discontinued] [bit] NOT NULL CONSTRAINT [DFT_Products_discontinued]  DEFAULT ((0)),
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[productid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Production].[Suppliers]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Production].[Suppliers](
	[supplierid] [int] IDENTITY(1,1) NOT NULL,
	[companyname] [nvarchar](40) NOT NULL,
	[contactname] [nvarchar](30) NOT NULL,
	[contacttitle] [nvarchar](30) NOT NULL,
	[address] [nvarchar](60) NOT NULL,
	[city] [nvarchar](15) NOT NULL,
	[region] [nvarchar](15) NULL,
	[postalcode] [nvarchar](10) NULL,
	[country] [nvarchar](15) NOT NULL,
	[phone] [nvarchar](24) NOT NULL,
	[fax] [nvarchar](24) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[supplierid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Sales].[Customers]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sales].[Customers](
	[custid] [int] IDENTITY(1,1) NOT NULL,
	[companyname] [nvarchar](40) NOT NULL,
	[contactname] [nvarchar](30) NOT NULL,
	[contacttitle] [nvarchar](30) NOT NULL,
	[address] [nvarchar](60) NOT NULL,
	[city] [nvarchar](15) NOT NULL,
	[region] [nvarchar](15) NULL,
	[postalcode] [nvarchar](10) NULL,
	[country] [nvarchar](15) NOT NULL,
	[phone] [nvarchar](24) NOT NULL,
	[fax] [nvarchar](24) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[custid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Sales].[OrderDetails]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sales].[OrderDetails](
	[orderid] [int] NOT NULL,
	[productid] [int] NOT NULL,
	[unitprice] [money] NOT NULL CONSTRAINT [DFT_OrderDetails_unitprice]  DEFAULT ((0)),
	[qty] [smallint] NOT NULL CONSTRAINT [DFT_OrderDetails_qty]  DEFAULT ((1)),
	[discount] [numeric](4, 3) NOT NULL CONSTRAINT [DFT_OrderDetails_discount]  DEFAULT ((0)),
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC,
	[productid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Sales].[Orders]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sales].[Orders](
	[orderid] [int] IDENTITY(1,1) NOT NULL,
	[custid] [int] NULL,
	[empid] [int] NOT NULL,
	[orderdate] [datetime] NOT NULL,
	[requireddate] [datetime] NOT NULL,
	[shippeddate] [datetime] NULL,
	[shipperid] [int] NOT NULL,
	[freight] [money] NOT NULL CONSTRAINT [DFT_Orders_freight]  DEFAULT ((0)),
	[shipname] [nvarchar](40) NOT NULL,
	[shipaddress] [nvarchar](60) NOT NULL,
	[shipcity] [nvarchar](15) NOT NULL,
	[shipregion] [nvarchar](15) NULL,
	[shippostalcode] [nvarchar](10) NULL,
	[shipcountry] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Sales].[Shippers]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sales].[Shippers](
	[shipperid] [int] IDENTITY(1,1) NOT NULL,
	[companyname] [nvarchar](40) NOT NULL,
	[phone] [nvarchar](24) NOT NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[shipperid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [Sales].[CustOrders]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Sales].[CustOrders]
  WITH SCHEMABINDING
AS

SELECT
  O.custid, 
  DATEADD(month, DATEDIFF(month, 0, O.orderdate), 0) AS ordermonth,
  SUM(OD.qty) AS qty
FROM Sales.Orders AS O
  JOIN Sales.OrderDetails AS OD
    ON OD.orderid = O.orderid
GROUP BY custid, DATEADD(month, DATEDIFF(month, 0, O.orderdate), 0);


GO
/****** Object:  View [Sales].[OrderTotalsByYear]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Sales].[OrderTotalsByYear]
  WITH SCHEMABINDING
AS

SELECT
  YEAR(O.orderdate) AS orderyear,
  SUM(OD.qty) AS qty
FROM Sales.Orders AS O
  JOIN Sales.OrderDetails AS OD
    ON OD.orderid = O.orderid
GROUP BY YEAR(orderdate);


GO
/****** Object:  View [Sales].[OrderValues]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------------------------------
-- Create Views
---------------------------------------------------------------------

CREATE VIEW [Sales].[OrderValues]
  WITH SCHEMABINDING
AS

SELECT O.orderid, O.custid, O.empid, O.shipperid, O.orderdate,
  CAST(SUM(OD.qty * OD.unitprice * (1 - discount))
       AS NUMERIC(12, 2)) AS val
FROM Sales.Orders AS O
  JOIN Sales.OrderDetails AS OD
    ON O.orderid = OD.orderid
GROUP BY O.orderid, O.custid, O.empid, O.shipperid, O.orderdate;


GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idx_nc_lastname]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_lastname] ON [HR].[Employees]
(
	[lastname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idx_nc_postalcode]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_postalcode] ON [HR].[Employees]
(
	[postalcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [categoryname]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [categoryname] ON [Production].[Categories]
(
	[categoryname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_nc_categoryid]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_categoryid] ON [Production].[Products]
(
	[categoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idx_nc_productname]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_productname] ON [Production].[Products]
(
	[productname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_nc_supplierid]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_supplierid] ON [Production].[Products]
(
	[supplierid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idx_nc_companyname]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_companyname] ON [Production].[Suppliers]
(
	[companyname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idx_nc_postalcode]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_postalcode] ON [Production].[Suppliers]
(
	[postalcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idx_nc_city]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_city] ON [Sales].[Customers]
(
	[city] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idx_nc_companyname]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_companyname] ON [Sales].[Customers]
(
	[companyname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idx_nc_postalcode]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_postalcode] ON [Sales].[Customers]
(
	[postalcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idx_nc_region]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_region] ON [Sales].[Customers]
(
	[region] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_nc_orderid]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_orderid] ON [Sales].[OrderDetails]
(
	[orderid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_nc_productid]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_productid] ON [Sales].[OrderDetails]
(
	[productid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_nc_custid]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_custid] ON [Sales].[Orders]
(
	[custid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_nc_empid]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_empid] ON [Sales].[Orders]
(
	[empid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_nc_orderdate]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_orderdate] ON [Sales].[Orders]
(
	[orderdate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_nc_shippeddate]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_shippeddate] ON [Sales].[Orders]
(
	[shippeddate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [idx_nc_shipperid]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_shipperid] ON [Sales].[Orders]
(
	[shipperid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [idx_nc_shippostalcode]    Script Date: 18-12-2016 1:18:37 PM ******/
CREATE NONCLUSTERED INDEX [idx_nc_shippostalcode] ON [Sales].[Orders]
(
	[shippostalcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [HR].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees] FOREIGN KEY([mgrid])
REFERENCES [HR].[Employees] ([empid])
GO
ALTER TABLE [HR].[Employees] CHECK CONSTRAINT [FK_Employees_Employees]
GO
ALTER TABLE [Production].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([categoryid])
REFERENCES [Production].[Categories] ([categoryid])
GO
ALTER TABLE [Production].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [Production].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([supplierid])
REFERENCES [Production].[Suppliers] ([supplierid])
GO
ALTER TABLE [Production].[Products] CHECK CONSTRAINT [FK_Products_Suppliers]
GO
ALTER TABLE [Sales].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([orderid])
REFERENCES [Sales].[Orders] ([orderid])
GO
ALTER TABLE [Sales].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [Sales].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([productid])
REFERENCES [Production].[Products] ([productid])
GO
ALTER TABLE [Sales].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [Sales].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([custid])
REFERENCES [Sales].[Customers] ([custid])
GO
ALTER TABLE [Sales].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [Sales].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employees] FOREIGN KEY([empid])
REFERENCES [HR].[Employees] ([empid])
GO
ALTER TABLE [Sales].[Orders] CHECK CONSTRAINT [FK_Orders_Employees]
GO
ALTER TABLE [Sales].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Shippers] FOREIGN KEY([shipperid])
REFERENCES [Sales].[Shippers] ([shipperid])
GO
ALTER TABLE [Sales].[Orders] CHECK CONSTRAINT [FK_Orders_Shippers]
GO
ALTER TABLE [HR].[Employees]  WITH CHECK ADD  CONSTRAINT [CHK_birthdate] CHECK  (([birthdate]<=getdate()))
GO
ALTER TABLE [HR].[Employees] CHECK CONSTRAINT [CHK_birthdate]
GO
ALTER TABLE [Sales].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [CHK_discount] CHECK  (([discount]>=(0) AND [discount]<=(1)))
GO
ALTER TABLE [Sales].[OrderDetails] CHECK CONSTRAINT [CHK_discount]
GO
ALTER TABLE [Sales].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [CHK_qty] CHECK  (([qty]>(0)))
GO
ALTER TABLE [Sales].[OrderDetails] CHECK CONSTRAINT [CHK_qty]
GO
ALTER TABLE [Sales].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [CHK_unitprice] CHECK  (([unitprice]>=(0)))
GO
ALTER TABLE [Sales].[OrderDetails] CHECK CONSTRAINT [CHK_unitprice]
GO
/****** Object:  StoredProcedure [dbo].[Categories.Delete]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories.Delete]
	@categoryid int
AS
BEGIN

	IF NOT EXISTS ( SELECT * FROM Production.Products WHERE categoryid = @categoryid)
		BEGIN 
			DELETE FROM Production.Categories
			WHERE categoryid = @categoryid
		END
	ELSE
		BEGIN
			THROW 50000, 'This category is in used', 1;
		END


END

GO
/****** Object:  StoredProcedure [dbo].[Categories.Insert]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories.Insert]
	@categoryname nvarchar(15),
	@description nvarchar(200)
AS
BEGIN
	INSERT INTO Production.Categories (categoryname, [description])
	VALUES(@categoryname, @description)
END





GO
/****** Object:  StoredProcedure [dbo].[Categories.OrderByID]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories.OrderByID]
AS
BEGIN
	SELECT * FROM Production.Categories 
	ORDER BY categoryid 
END




GO
/****** Object:  StoredProcedure [dbo].[Categories.OrderByName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories.OrderByName]
AS
BEGIN
	SELECT * FROM Production.Categories 
	ORDER BY categoryname 
END







GO
/****** Object:  StoredProcedure [dbo].[Categories.SearchByID]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories.SearchByID]
@categoryid int
AS
BEGIN
	SELECT * FROM Production.Categories
	WHERE categoryid = @categoryid
END


GO
/****** Object:  StoredProcedure [dbo].[Categories.SearchByName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories.SearchByName]
@categoryname nvarchar(15)
AS
BEGIN
	SELECT categoryid as 'CategoryID', categoryname as 'CategoryName', [description] as 'Description'
	FROM Production.Categories
	WHERE categoryname LIKE '%' + @categoryname + '%'
END


GO
/****** Object:  StoredProcedure [dbo].[Categories.SelectAll]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories.SelectAll]
AS
BEGIN
	SELECT categoryid as 'CategoryID', categoryname as 'CategoryName', [description] as 'Description'
	FROM Production.Categories
	
END


GO
/****** Object:  StoredProcedure [dbo].[Categories.SortByID]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories.SortByID]
AS
BEGIN
	SELECT categoryid as 'CategoryID', categoryname as 'CategoryName', [description] as 'Description'
	FROM Production.Categories
	ORDER BY categoryid
	
END


GO
/****** Object:  StoredProcedure [dbo].[Categories.SortByName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories.SortByName]
AS
BEGIN
	SELECT categoryid as 'CategoryID', categoryname as 'CategoryName', [description] as 'Description'
	FROM Production.Categories
	ORDER BY categoryname
	
END


GO
/****** Object:  StoredProcedure [dbo].[Categories.Update]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories.Update]
	@categoryid int,
	@categoryname nvarchar(15),
	@description nvarchar(200)
AS
BEGIN
	UPDATE Production.Categories SET categoryname=@categoryname,[description]=@description
	WHERE categoryid = @categoryid
END





GO
/****** Object:  StoredProcedure [dbo].[CustomerGetData]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CustomerGetData]
AS
BEGIN
	SELECT Sales.Customers.custid AS 'Customer ID',
		Sales.Customers.companyname AS 'Company Name',
		Sales.Customers.contactname AS 'Contact Name'
	FROM Sales.Customers 

END



GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCustomer] 
@CustID int
AS
BEGIN
delete from Sales.Customers where custid=@CustID
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteOrder]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteOrder]
@orderid int
AS
BEGIN
	DELETE FROM Sales.Orders WHERE orderid=@orderid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteOrderDetail]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteOrderDetail]
@orderid int
AS
BEGIN
	DELETE t FROM Sales.OrderDetails t WHERE t.orderid=@orderid
END



GO
/****** Object:  StoredProcedure [dbo].[EmployeeGetData]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EmployeeGetData]
AS
BEGIN
	SELECT HR.Employees.empid AS 'Employee ID',
		HR.Employees.lastname AS 'Last Name',
		HR.Employees.firstname AS 'First Name'
	FROM HR.Employees 

END



GO
/****** Object:  StoredProcedure [dbo].[getAllEmployee]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getAllEmployee]
AS
BEGIN
SELECT * FROM HR.Employees
END


GO
/****** Object:  StoredProcedure [dbo].[GetCountry]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCountry]
as
begin
	select c.nicename
	from Country c
end
GO
/****** Object:  StoredProcedure [dbo].[getEmployeeInfo]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getEmployeeInfo]
@curEmpId int
AS
BEGIN
SELECT empid AS 'ID', lastname AS 'Last name', firstname AS 'First name', birthdate AS 'Birthday', hiredate AS 'Hireday'
FROM HR.Employees
WHERE empid <> @curEmpId;
END


GO
/****** Object:  StoredProcedure [dbo].[GetOrderID]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderID] 
@CustID int
AS
BEGIN

	select o.orderid from Sales.Customers c, Sales.Orders o
	where c.custid=@CustID and o.custid=c.custid

END



GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCustomer] 
	
	@CompanyName nvarchar(40),
	@ContactName nvarchar(30),
	@ContactTitle nvarchar(30),
	@Address nvarchar (60),
	@City nvarchar(15),
	@Region nvarchar(15),
	@PostalCode nvarchar(10),
	@Country nvarchar(15),
	@Phone nvarchar(24),
	@Fax nvarchar(24)
AS
BEGIN
	
	INSERT INTO Sales.Customers(companyname,contactname,contacttitle,[address],city,region,postalcode,country,phone,fax)
	VALUES (@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax)
END




GO
/****** Object:  StoredProcedure [dbo].[insertEmployee]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertEmployee]
@lastname nvarchar(20),
@firstname nvarchar(10),
@title nvarchar(30),
@titleofcourtecy nvarchar(25),
@birthdate datetime,
@hiredate datetime,
@address nvarchar(60),
@city nvarchar(15),
@region nvarchar(15),
@postalcode nvarchar(10),
@country nvarchar(15),
@phone nvarchar(24),
@mgrid int 
AS
BEGIN
INSERT INTO HR.Employees(lastname,firstname,title,titleofcourtesy,birthdate,hiredate,[address],city,region,postalcode,country,phone,
mgrid) VALUES (@lastname,@firstname,@title,@titleofcourtecy,@birthdate,@hiredate,@address,@city,@region,@postalcode,@country,@phone,
@mgrid)
END


GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertOrder]
(
@custid int,
@empid int,
@orderdate datetime,
@requireddate datetime,
@shippeddate datetime,
@shipperid int,
@freight money,
@shipname nvarchar(50),
@shipaddress nvarchar(60),
@shipcity nvarchar(15),
@shipregion nvarchar(15),
@shippostalcode nvarchar(10),
@shipcountry nvarchar(15)
)
AS
BEGIN

		INSERT INTO Sales.Orders (custid,empid,orderdate,
		requireddate,shippeddate,shipperid,freight,
		shipname, shipaddress,shipcity,shipregion,
		shippostalcode,shipcountry)
		VALUES (@custid,@empid,@orderdate,@requireddate,
		@shippeddate,@shipperid,@freight,@shipname,
		@shipaddress,@shipcity,@shipregion,@shippostalcode,
		@shipcountry)
END




GO
/****** Object:  StoredProcedure [dbo].[Order.LoadOrder]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order.LoadOrder]
@orderid int
AS
BEGIN
	SELECT  Sales.Orders.custid AS 'Customer ID',
			Sales.Orders.empid AS 'Employee ID',
			Sales.Orders.orderdate AS 'Order Date',
			Sales.Orders.requireddate AS 'Require Date',
			Sales.Orders.shippeddate AS 'Ship Date',
			Sales.Orders.shipperid AS 'Shipper ID',
			Sales.Orders.freight AS 'Freight',
			Sales.Orders.shipname AS 'Ship Name',
			Sales.Orders.shipaddress AS 'Ship Address',
			Sales.Orders.shipcity AS 'Ship City',
			Sales.Orders.shipregion AS 'Ship Region',
			Sales.Orders.shippostalcode AS 'Ship Postal Code',
			Sales.Orders.shipcountry AS 'Ship Country'
	 
	FROM Sales.Orders 
	WHERE orderid = @orderid
END



GO
/****** Object:  StoredProcedure [dbo].[Order.MapCusAndEmp]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order.MapCusAndEmp]
AS
BEGIN

	select order1.orderid as 'OrderID', order1.companyname as 'CompanyName', order1.contactname as 'ContactName',  (em.lastname + ' ' + em.firstname) as 'Emp Name', order1.orderdate as 'Order Date'
	from  HR.Employees em,
		(select o.orderid as orderID, c.companyname as companyName, c.contactname as contactName, o.empid as empID, o.orderdate as orderDate
			from Sales.Orders o, Sales.Customers c
			where o.custid = c.custid) order1
Where em.empid = order1.empID 
END




GO
/****** Object:  StoredProcedure [dbo].[Order.MapCusAndEmp.SearchCompanyName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order.MapCusAndEmp.SearchCompanyName]
@companyName nvarchar(40)
AS
BEGIN
	SELECT * 
	FROM (select order1.orderid as 'OrderID', order1.companyname as 'CompanyName', order1.contactname as 'ContactName',  (em.lastname + ' ' + em.firstname) as 'Emp Name', order1.orderdate as 'Order Date'
			from  HR.Employees em,
						(select o.orderid as orderID, c.companyname as companyName, c.contactname as contactName, o.empid as empID, o.orderdate as orderDate
						from Sales.Orders o, Sales.Customers c
						where o.custid = c.custid) order1
			where em.empid = order1.empID ) orderall
	WHERE orderall.CompanyName LIKE @companyName 
END

GO
/****** Object:  StoredProcedure [dbo].[Order.MapCusAndEmp.SearchOrderID]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order.MapCusAndEmp.SearchOrderID]
@orderid int
AS
BEGIN
	SELECT * 
	FROM (select order1.orderid as 'OrderID', order1.companyname as 'CompanyName', order1.contactname as 'ContactName',  (em.lastname + ' ' + em.firstname) as 'Emp Name', order1.orderdate as 'Order Date'
			from  HR.Employees em,
						(select o.orderid as orderID, c.companyname as companyName, c.contactname as contactName, o.empid as empID, o.orderdate as orderDate
						from Sales.Orders o, Sales.Customers c
						where o.custid = c.custid) order1
			where em.empid = order1.empID ) orderall
	WHERE orderall.OrderID = @orderid
END

GO
/****** Object:  StoredProcedure [dbo].[Order.searchByName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Order.searchByName]
@name nvarchar(30)
AS
BEGIN
	SELECT Sales.Orders.orderid AS 'Order ID',
			Sales.Orders.custid AS 'Customer ID',
			Sales.Orders.empid AS 'Employee ID',
			Sales.Orders.orderdate AS 'Order Date',
			Sales.Orders.requireddate AS 'Require Date',
			Sales.Orders.shippeddate AS 'Ship Date',
			Sales.Orders.shipperid AS 'Shipper ID',
			Sales.Orders.freight AS 'Freight',
			Sales.Orders.shipname AS 'Ship Name',
			Sales.Orders.shipaddress AS 'Ship Address',
			Sales.Orders.shipcity AS 'Ship City',
			Sales.Orders.shipregion AS 'Ship Region',
			Sales.Orders.shippostalcode AS 'Ship Postal Code',
			Sales.Orders.shipcountry AS 'Ship Country'
	 
	FROM Sales.Orders join Sales.Customers t1 on Sales.Orders.custid = t1.custid
	where t1.contactname like '%' + @name + '%'
END






GO
/****** Object:  StoredProcedure [dbo].[order.searchShipDate]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[order.searchShipDate]
@orderID int
AS
BEGIN
	select Sales.Orders.shippeddate
	from Sales.Orders
	where Sales.Orders.orderid = @orderID and Sales.Orders.shippeddate is not null
END



GO
/****** Object:  StoredProcedure [dbo].[OrderDetails.Delete]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDetails.Delete]
	@orderid int,
	@productid int
AS
BEGIN
	DELETE FROM Sales.OrderDetails 
	WHERE orderid=@orderid AND productid=@productid 
END





GO
/****** Object:  StoredProcedure [dbo].[OrderDetails.Insert]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDetails.Insert]
	@orderid int,
	@productid int,
	@unitprice money,
	@qty smallint,
	@discount numeric(4,3)
AS
BEGIN
	INSERT INTO Sales.OrderDetails (orderid, productid, unitprice, qty, discount)
	VALUES (@orderid,@productid,@unitprice,	@qty, @discount)
END





GO
/****** Object:  StoredProcedure [dbo].[OrderDetails.SelectAll]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDetails.SelectAll]
@orderid int
AS
BEGIN
	SELECT Sales.OrderDetails.productid as 'Product ID',
			Sales.OrderDetails.unitprice as 'Unit Price',
			Sales.OrderDetails.qty as 'Quantity',
			Sales.OrderDetails.discount as 'Discount' 
		
	FROM Sales.OrderDetails WHERE Sales.OrderDetails.orderid = @orderid
END

GO
/****** Object:  StoredProcedure [dbo].[OrderDetails.SelectOrder]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDetails.SelectOrder]
@orderid int,
@productid int
AS
BEGIN
	SELECT * FROM Sales.OrderDetails
	WHERE orderid = @orderid AND productid = @productid
END




GO
/****** Object:  StoredProcedure [dbo].[OrderDetails.Update]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDetails.Update]
	@orderid int,
	@productid int,
	@newProductID int,
	@unitprice money,
	@qty smallint,
	@discount numeric(4,3)
AS
BEGIN
	UPDATE Sales.OrderDetails 
	SET unitprice=@unitprice, qty=@qty, discount=@discount, productid = @newProductID
	WHERE orderid=@orderid AND productid=@productid 
END








GO
/****** Object:  StoredProcedure [dbo].[OrderGetAll]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderGetAll]


AS
BEGIN
	SELECT Sales.Orders.orderid AS 'Order ID',
			Sales.Orders.custid AS 'Customer ID',
			Sales.Orders.empid AS 'Employee ID',
			Sales.Orders.orderdate AS 'Order Date',
			Sales.Orders.requireddate AS 'Require Date',
			Sales.Orders.shippeddate AS 'Ship Date',
			Sales.Orders.shipperid AS 'Shipper ID',
			Sales.Orders.freight AS 'Freight',
			Sales.Orders.shipname AS 'Ship Name',
			Sales.Orders.shipaddress AS 'Ship Address',
			Sales.Orders.shipcity AS 'Ship City',
			Sales.Orders.shipregion AS 'Ship Region',
			Sales.Orders.shippostalcode AS 'Ship Postal Code',
			Sales.Orders.shipcountry AS 'Ship Country'
	 
	FROM Sales.Orders 

END



GO
/****** Object:  StoredProcedure [dbo].[Product.Delete]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.Delete]
	@productid int
AS
BEGIN
	IF NOT EXISTS ( SELECT * FROM Sales.OrderDetails WHERE productid = @productid)
		BEGIN 
			DELETE FROM Production.Products 
			WHERE productid = @productid
		END
	ELSE
		BEGIN
			THROW 50000, 'This Product is used in order!', 1;
		END
END


GO
/****** Object:  StoredProcedure [dbo].[Product.GetSomeInfo]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.GetSomeInfo]
AS
BEGIN
	SELECT productid as 'ID', productname as 'ProductName', unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products
END




GO
/****** Object:  StoredProcedure [dbo].[Product.Insert]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.Insert]
	@productname nvarchar(40),
	@supplierid int,
	@categoryid int,
	@unitprice money,
	@discontinued bit
AS
BEGIN

			INSERT INTO Production.Products (productname, supplierid, categoryid, unitprice, discontinued)
			VALUES (@productname,@supplierid,@categoryid,@unitprice,@discontinued)
	
END


GO
/****** Object:  StoredProcedure [dbo].[Product.SearchByCategoryID]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.SearchByCategoryID]
@categoryid int
AS
BEGIN
	SELECT productid as 'ID', productname as 'ProductName', supplierid as 'SupplierID', categoryid as 'CategoryID' , unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products
	WHERE categoryid = @categoryid
END


GO
/****** Object:  StoredProcedure [dbo].[Product.SearchByCategoryName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.SearchByCategoryName]
@categoryname nvarchar(15)
AS
BEGIN
	SELECT
	 pr.productid as 'ID', pr.productname as 'ProductName',
	 pr.supplierid as 'SupplierID', pr.categoryid as 'CategoryID' , 
	 su.companyname as 'Supplier Company', ca.categoryname as 'CategoryName',
	 unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products pr, Production.Categories ca, Production.Suppliers su
	WHERE pr.categoryid = ca.categoryid AND pr.supplierid = su.supplierid AND ca.categoryname LIKE '%' + @categoryname + '%'
END




GO
/****** Object:  StoredProcedure [dbo].[Product.SearchByName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.SearchByName]
@productname nvarchar(40)
AS
BEGIN
	SELECT productid as 'ID', productname as 'ProductName', supplierid as 'SupplierID', categoryid as 'CategoryID' , unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products
	WHERE productname LIKE '%' + @productname + '%'
END


GO
/****** Object:  StoredProcedure [dbo].[Product.SearchByName2]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.SearchByName2]
@productname nvarchar(40)
AS
BEGIN
	SELECT
	 pr.productid as 'ID', pr.productname as 'ProductName',
	 pr.supplierid as 'SupplierID', pr.categoryid as 'CategoryID' , 
	 su.companyname as 'Supplier Company', ca.categoryname as 'CategoryName',
	 unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products pr, Production.Categories ca, Production.Suppliers su
	WHERE pr.categoryid = ca.categoryid AND pr.supplierid = su.supplierid AND pr.productname LIKE '%' + @productname + '%'
END


GO
/****** Object:  StoredProcedure [dbo].[Product.SearchBySupplierCompany]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.SearchBySupplierCompany]
@company nvarchar(40)
AS
BEGIN
	SELECT
	 pr.productid as 'ID', pr.productname as 'ProductName',
	 pr.supplierid as 'SupplierID', pr.categoryid as 'CategoryID' , 
	 su.companyname as 'Supplier Company', ca.categoryname as 'CategoryName',
	 unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products pr, Production.Categories ca, Production.Suppliers su
	WHERE pr.categoryid = ca.categoryid AND pr.supplierid = su.supplierid AND su.companyname LIKE '%' + @company + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Product.SearchBySupplierID]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.SearchBySupplierID]
@supplierid int
AS
BEGIN
	SELECT productid as 'ID', productname as 'ProductName', supplierid as 'SupplierID', categoryid as 'CategoryID' , unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products
	WHERE supplierid = @supplierid
END


GO
/****** Object:  StoredProcedure [dbo].[Product.SearchByUnitPrice]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.SearchByUnitPrice]
@fromprice money,
@toprice money
AS
BEGIN
	SELECT productid as 'ID', productname as 'ProductName', supplierid as 'SupplierID', categoryid as 'CategoryID' , unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products
	WHERE (@fromprice <= unitprice) AND (unitprice <= @toprice)
END


GO
/****** Object:  StoredProcedure [dbo].[Product.SearchByUnitPrice2]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.SearchByUnitPrice2]
@fromprice money,
@toprice money
AS
BEGIN
	SELECT
	 pr.productid as 'ID', pr.productname as 'ProductName',
	 pr.supplierid as 'SupplierID', pr.categoryid as 'CategoryID' , 
	 su.companyname as 'Supplier Company', ca.categoryname as 'CategoryName',
	 unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products pr, Production.Categories ca, Production.Suppliers su
	WHERE pr.categoryid = ca.categoryid AND pr.supplierid = su.supplierid AND (@fromprice <= pr.unitprice) AND (pr.unitprice <= @toprice)
END


GO
/****** Object:  StoredProcedure [dbo].[Product.SelectAll]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.SelectAll]
AS
BEGIN
	SELECT productid as 'ID', productname as 'ProductName', supplierid as 'SupplierID', categoryid as 'CategoryID' , unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products
END




GO
/****** Object:  StoredProcedure [dbo].[Product.SelectAll2]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.SelectAll2]
AS
BEGIN
	SELECT
	 pr.productid as 'ID', pr.productname as 'ProductName',
	 pr.supplierid as 'SupplierID', pr.categoryid as 'CategoryID' , 
	 su.companyname as 'Supplier Company', ca.categoryname as 'CategoryName',
	 unitprice as 'Unit Price', discontinued as 'Discontinued'
	FROM Production.Products pr, Production.Categories ca, Production.Suppliers su
	WHERE pr.categoryid = ca.categoryid AND pr.supplierid = su.supplierid
END




GO
/****** Object:  StoredProcedure [dbo].[Product.Update]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Product.Update]
	@productid int,
	@productname nvarchar(40),
	@supplierid int,
	@categoryid int,
	@unitprice money,
	@discontinued bit
AS
BEGIN
	UPDATE Production.Products SET productname=@productname, supplierid=@supplierid, categoryid=@categoryid, unitprice=@unitprice, discontinued=@discontinued
	WHERE productid=@productid
END





GO
/****** Object:  StoredProcedure [dbo].[removeEmployee]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[removeEmployee]
@empID int
AS
BEGIN
IF EXISTS (SELECT * FROM HR.Employees WHERE mgrid = @empID) 
	THROW 50000, 'Invalid request! This employee is managing emloyee(s)!',1;
ELSE IF EXISTS (SELECT * FROM Sales.Orders WHERE empid = @empID)
	THROW 50000, 'Invalid request! This employee is managing order(s)!',1;
ELSE 
	DELETE FROM HR.Employees WHERE empid = @empID
END

GO
/****** Object:  StoredProcedure [dbo].[searchByBirthday]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[searchByBirthday]
@fromDate datetime,
@toDate datetime
AS
BEGIN
SELECT * FROM HR.Employees WHERE birthdate BETWEEN @fromDate AND @toDate
END


GO
/****** Object:  StoredProcedure [dbo].[searchByFirstnameEmployee]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[searchByFirstnameEmployee]
@name nvarchar(20)
AS
BEGIN
SELECT * FROM HR.Employees WHERE firstname LIKE @name
END


GO
/****** Object:  StoredProcedure [dbo].[searchByLastnameEmployee]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[searchByLastnameEmployee]
@name nvarchar(20)
AS
BEGIN
SELECT * FROM HR.Employees WHERE lastname LIKE @name
END


GO
/****** Object:  StoredProcedure [dbo].[searchByNAME]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[searchByNAME]
@name nvarchar(20),
@curEmpId int
AS
BEGIN
SELECT empid AS 'ID', lastname AS 'Last name', firstname AS 'First name', birthdate AS 'Birthday', hiredate AS 'Hireday' 
FROM HR.Employees
WHERE (lastname LIKE @name OR firstname LIKE @name) AND (empid <> @curEmpId);
END


GO
/****** Object:  StoredProcedure [dbo].[searchByName_Cust]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[searchByName_Cust]
@contactname nvarchar(30)
AS
BEGIN
	SELECT Sales.Customers.custid AS 'Customer ID',
		Sales.Customers.companyname AS 'Company Name',
		Sales.Customers.contactname AS 'Contact Name'
	FROM Sales.Customers 
	WHERE Sales.Customers.contactname Like '%' + @contactname + '%'
END



GO
/****** Object:  StoredProcedure [dbo].[searchByName_Emp]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[searchByName_Emp]
@lastname nvarchar(20)
AS
BEGIN
	SELECT HR.Employees.empid AS 'Employee ID',
		HR.Employees.lastname AS 'Last Name',
		HR.Employees.firstname AS 'First Name'
	FROM HR.Employees 
	WHERE HR.Employees.lastname Like '%' + @lastname + '%'
END



GO
/****** Object:  StoredProcedure [dbo].[searchByName_Ship]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[searchByName_Ship]
@compname nvarchar(40)
AS
BEGIN
	SELECT Sales.Shippers.shipperid AS 'Shipper ID',
		Sales.Shippers.companyname AS 'Company Name',
		Sales.Shippers.phone AS 'Phone'
	FROM Sales.Shippers 
	WHERE Sales.Shippers.companyname Like '%' + @compname + '%'
END



GO
/****** Object:  StoredProcedure [dbo].[searchCustID]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[searchCustID]
(
@custid int
)
AS
BEGIN
	SELECT Sales.Orders.orderid AS 'Order ID',
			Sales.Orders.custid AS 'Customer ID',
			Sales.Orders.empid AS 'Employee ID',
			Sales.Orders.orderdate AS 'Order Date',
			Sales.Orders.requireddate AS 'Require Date',
			Sales.Orders.shippeddate AS 'Ship Date',
			Sales.Orders.shipperid AS 'Shipper ID',
			Sales.Orders.freight AS 'Freight',
			Sales.Orders.shipname AS 'Ship Name',
			Sales.Orders.shipaddress AS 'Ship Address',
			Sales.Orders.shipcity AS 'Ship City',
			Sales.Orders.shipregion AS 'Ship Region',
			Sales.Orders.shippostalcode AS 'Ship Postal Code',
			Sales.Orders.shipcountry AS 'Ship Country'
	FROM Sales.Orders  
	WHERE 
	custid = @custid 

END



GO
/****** Object:  StoredProcedure [dbo].[SearchCustomerByCompanyName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchCustomerByCompanyName] 
	-- Add the parameters for the stored procedure here
	@CompName Nvarchar(40)
AS
BEGIN
	select * from Sales.Customers where companyname like '%' + @CompName + '%'
END



GO
/****** Object:  StoredProcedure [dbo].[SearchCustomerByContactName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchCustomerByContactName] 
	-- Add the parameters for the stored procedure here
	@ContName Nvarchar(30)
AS
BEGIN
	select * from Sales.Customers where contactname like '%' + @ContName + '%'
END



GO
/****** Object:  StoredProcedure [dbo].[SearchCustomerByCountry]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchCustomerByCountry]
	@CountryName Nvarchar(15)
AS
BEGIN

  select * from Sales.Customers where country like '%' + @CountryName +'%'
	
END



GO
/****** Object:  StoredProcedure [dbo].[searchEmpID]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[searchEmpID]
(
@empid int
)
AS
BEGIN
	SELECT Sales.Orders.orderid AS 'Order ID',
			Sales.Orders.custid AS 'Customer ID',
			Sales.Orders.empid AS 'Employee ID',
			Sales.Orders.orderdate AS 'Order Date',
			Sales.Orders.requireddate AS 'Require Date',
			Sales.Orders.shippeddate AS 'Ship Date',
			Sales.Orders.shipperid AS 'Shipper ID',
			Sales.Orders.freight AS 'Freight',
			Sales.Orders.shipname AS 'Ship Name',
			Sales.Orders.shipaddress AS 'Ship Address',
			Sales.Orders.shipcity AS 'Ship City',
			Sales.Orders.shipregion AS 'Ship Region',
			Sales.Orders.shippostalcode AS 'Ship Postal Code',
			Sales.Orders.shipcountry AS 'Ship Country'
	FROM Sales.Orders  
	WHERE 
	empid = @empid

END



GO
/****** Object:  StoredProcedure [dbo].[searchOrderDate]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[searchOrderDate]
(
@dateFrom datetime,
@dateTo datetime
)
AS
BEGIN
	SELECT Sales.Orders.orderid AS 'Order ID',
			Sales.Orders.custid AS 'Customer ID',
			Sales.Orders.empid AS 'Employee ID',
			Sales.Orders.orderdate AS 'Order Date',
			Sales.Orders.requireddate AS 'Require Date',
			Sales.Orders.shippeddate AS 'Ship Date',
			Sales.Orders.shipperid AS 'Shipper ID',
			Sales.Orders.freight AS 'Freight',
			Sales.Orders.shipname AS 'Ship Name',
			Sales.Orders.shipaddress AS 'Ship Address',
			Sales.Orders.shipcity AS 'Ship City',
			Sales.Orders.shipregion AS 'Ship Region',
			Sales.Orders.shippostalcode AS 'Ship Postal Code',
			Sales.Orders.shipcountry AS 'Ship Country'
	FROM Sales.Orders  
	WHERE 
	orderdate BETWEEN @dateFrom AND @dateTo 

END

GO
/****** Object:  StoredProcedure [dbo].[searchProductName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[searchProductName]
@search nvarchar(30)
AS
BEGIN
	SELECT t.orderid AS 'Order ID',
			t.custid AS 'Customer ID',
			t.empid AS 'Employee ID',
			t.orderdate AS 'Order Date',
			t.requireddate AS 'Require Date',
			t.shippeddate AS 'Ship Date',
			t.shipperid AS 'Shipper ID',
			t.freight AS 'Freight',
			t.shipname AS 'Ship Name',
			t.shipaddress AS 'Ship Address',
			t.shipcity AS 'Ship City',
			t.shipregion AS 'Ship Region',
			t.shippostalcode AS 'Ship Postal Code',
			t.shipcountry AS 'Ship Country'
			
	FROM Sales.Orders t
		inner join Sales.Customers b on t.custid = b.custid
		inner join Sales.OrderDetails c on t.orderid = c.orderid
		inner join Production.Products d on c.productid = d.productid
	WHERE d.productname like '%' + @search + '%'
END



GO
/****** Object:  StoredProcedure [dbo].[searchRequireDate]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[searchRequireDate]
(
@dateFrom datetime,
@dateTo datetime
)
AS
BEGIN
	SELECT Sales.Orders.orderid AS 'Order ID',
			Sales.Orders.custid AS 'Customer ID',
			Sales.Orders.empid AS 'Employee ID',
			Sales.Orders.orderdate AS 'Order Date',
			Sales.Orders.requireddate AS 'Require Date',
			Sales.Orders.shippeddate AS 'Ship Date',
			Sales.Orders.shipperid AS 'Shipper ID',
			Sales.Orders.freight AS 'Freight',
			Sales.Orders.shipname AS 'Ship Name',
			Sales.Orders.shipaddress AS 'Ship Address',
			Sales.Orders.shipcity AS 'Ship City',
			Sales.Orders.shipregion AS 'Ship Region',
			Sales.Orders.shippostalcode AS 'Ship Postal Code',
			Sales.Orders.shipcountry AS 'Ship Country'
	FROM Sales.Orders  
	WHERE 
	requireddate BETWEEN @dateFrom AND @dateTo 

END



GO
/****** Object:  StoredProcedure [dbo].[searchShipDate]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[searchShipDate]
(
@dateFrom datetime,
@dateTo datetime
)
AS
BEGIN
	SELECT Sales.Orders.orderid AS 'Order ID',
			Sales.Orders.custid AS 'Customer ID',
			Sales.Orders.empid AS 'Employee ID',
			Sales.Orders.orderdate AS 'Order Date',
			Sales.Orders.requireddate AS 'Require Date',
			Sales.Orders.shippeddate AS 'Ship Date',
			Sales.Orders.shipperid AS 'Shipper ID',
			Sales.Orders.freight AS 'Freight',
			Sales.Orders.shipname AS 'Ship Name',
			Sales.Orders.shipaddress AS 'Ship Address',
			Sales.Orders.shipcity AS 'Ship City',
			Sales.Orders.shipregion AS 'Ship Region',
			Sales.Orders.shippostalcode AS 'Ship Postal Code',
			Sales.Orders.shipcountry AS 'Ship Country'
	FROM Sales.Orders  
	WHERE 
	shippeddate BETWEEN @dateFrom AND @dateTo 

END



GO
/****** Object:  StoredProcedure [dbo].[SearchSupplierByCompanyName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchSupplierByCompanyName]
@CompName nvarchar(40)
AS
BEGIN
select Production.Suppliers.supplierid as 'Supplier ID',
		Production.Suppliers.companyname as 'Company Name',
		Production.Suppliers.contactname as 'Contact Name',
		Production.Suppliers.contacttitle as 'Contact Title',
		Production.Suppliers.[address] as 'Address',
		Production.Suppliers.city as 'City',
		Production.Suppliers.region as 'Region',
		Production.Suppliers.postalcode as 'Postal Code',
		Production.Suppliers.country as 'Country',
		Production.Suppliers.phone as 'Phone',
		Production.Suppliers.fax as 'Fax'
	from Production.Suppliers
	where companyname LIKE '%' + @CompName + '%'
END




GO
/****** Object:  StoredProcedure [dbo].[SearchSupplierByContactName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchSupplierByContactName]
@ContName nvarchar(30)
AS
BEGIN
select Production.Suppliers.supplierid as 'Supplier ID',
		Production.Suppliers.companyname as 'Company Name',
		Production.Suppliers.contactname as 'Contact Name',
		Production.Suppliers.contacttitle as 'Contact Title',
		Production.Suppliers.[address] as 'Address',
		Production.Suppliers.city as 'City',
		Production.Suppliers.region as 'Region',
		Production.Suppliers.postalcode as 'Postal Code',
		Production.Suppliers.country as 'Country',
		Production.Suppliers.phone as 'Phone',
		Production.Suppliers.fax as 'Fax'
	from Production.Suppliers
	where contactname LIKE '%' + @ContName + '%'
END




GO
/****** Object:  StoredProcedure [dbo].[SearchSupplierByCountry]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchSupplierByCountry]
@CountryName nvarchar(15)
AS
BEGIN
select Production.Suppliers.supplierid as 'Supplier ID',
		Production.Suppliers.companyname as 'Company Name',
		Production.Suppliers.contactname as 'Contact Name',
		Production.Suppliers.contacttitle as 'Contact Title',
		Production.Suppliers.[address] as 'Address',
		Production.Suppliers.city as 'City',
		Production.Suppliers.region as 'Region',
		Production.Suppliers.postalcode as 'Postal Code',
		Production.Suppliers.country as 'Country',
		Production.Suppliers.phone as 'Phone',
		Production.Suppliers.fax as 'Fax'
	from Production.Suppliers
	where country LIKE '%' + @CountryName + '%'
END




GO
/****** Object:  StoredProcedure [dbo].[searchTotal]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[searchTotal]
(
@totalFrom int,
@totalTo int
)
AS
BEGIN
	SELECT o1.orderid AS 'Order ID',
			o1.custid AS 'Customer ID',
			o1.empid AS 'Employee ID',
			o1.orderdate AS 'Order Date',
			o1.requireddate AS 'Require Date',
			o1.shippeddate AS 'Ship Date',
			o1.shipperid AS 'Shipper ID',
			o1.freight AS 'Freight',
			o1.shipname AS 'Ship Name',
			o1.shipaddress AS 'Ship Address',
			o1.shipcity AS 'Ship City',
			o1.shipregion AS 'Ship Region',
			o1.shippostalcode AS 'Ship Postal Code',
			o1.shipcountry AS 'Ship Country',
			o2.Total AS 'Total'
			
	FROM Sales.Orders o1,
		(SELECT orderid, SUM(qty * unitprice * (1 - discount)) as 'Total'
		FROM Sales.OrderDetails
		GROUP BY orderid) o2
	WHERE o2.orderid = o1.orderid and o2.Total between @totalFrom and @totalTo 
END



GO
/****** Object:  StoredProcedure [dbo].[Shipper.DeleteOnOrder]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shipper.DeleteOnOrder]
(
@shipperid int
)
AS
BEGIN
	delete t2
	from  Sales.Orders t2
	where t2.shipperid = @shipperid 
END




GO
/****** Object:  StoredProcedure [dbo].[Shipper.DeleteOnShipper]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shipper.DeleteOnShipper]
(
@shipperid int
)
AS
BEGIN
	delete from Sales.Shippers
	where shipperid = @shipperid
	
END



GO
/****** Object:  StoredProcedure [dbo].[Shipper.DeleteRelateShipper]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shipper.DeleteRelateShipper]
@shipperid int
AS
BEGIN
	delete t2
	from Sales.Shippers t, Sales.Orders t1, Sales.OrderDetails t2
	where t.shipperid = @shipperid and t1.orderid = t2.orderid

	delete t1
	from Sales.Shippers t, Sales.Orders t1, Sales.OrderDetails t2
	where t.shipperid = @shipperid and t1.orderid = t2.orderid

	delete t
	from Sales.Shippers t, Sales.Orders t1, Sales.OrderDetails t2
	where t.shipperid = @shipperid 
	
END




GO
/****** Object:  StoredProcedure [dbo].[Shipper.Insert]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shipper.Insert]
(
@companyname nvarchar(40),
@phone nvarchar(24)
)
AS
BEGIN
	Insert into Sales.Shippers(companyname,phone)
	values(@companyname,@phone)
END



GO
/****** Object:  StoredProcedure [dbo].[Shipper.searchByPhone]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shipper.searchByPhone]
@phone nvarchar(24)
AS
BEGIN
	SELECT shipperid as 'Shipper ID', companyname as 'Company Name', phone as 'Phone'
	FROM Sales.Shippers 
	WHERE phone Like '%' + @phone + '%'



END

GO
/****** Object:  StoredProcedure [dbo].[Shipper.Update]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shipper.Update]
(
@shipperid int,
@companyname nvarchar(40),
@phone nvarchar(24)
)
AS
BEGIN
	update Sales.Shippers set companyname = @companyname, phone=@phone
	where shipperid = @shipperid
END



GO
/****** Object:  StoredProcedure [dbo].[ShipperGetData]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShipperGetData]
AS
BEGIN
	SELECT Sales.Shippers.shipperid AS 'Shipper ID',
		Sales.Shippers.companyname AS 'Company Name',
		Sales.Shippers.phone AS 'Phone'
	FROM Sales.Shippers 

END



GO
/****** Object:  StoredProcedure [dbo].[Supplier.Delete]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Supplier.Delete] 
@SupID int
AS
BEGIN
delete from Production.Suppliers where supplierid=@SupID
END



GO
/****** Object:  StoredProcedure [dbo].[Supplier.Insert]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Supplier.Insert] 
	
	@CompanyName nvarchar(40),
	@ContactName nvarchar(30),
	@ContactTitle nvarchar(30),
	@Address nvarchar (60),
	@City nvarchar(15),
	@Region nvarchar(15),
	@PostalCode nvarchar(10),
	@Country nvarchar(15),
	@Phone nvarchar(24),
	@Fax nvarchar(24)
AS
BEGIN
	
	INSERT INTO Production.Suppliers(companyname,contactname,contacttitle,[address],city,region,postalcode,country,phone,fax)
	VALUES (@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax)
END

/** UPDATE **/
SET ANSI_NULLS ON



GO
/****** Object:  StoredProcedure [dbo].[Supplier.SearchCompanyName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Supplier.SearchCompanyName]
@companyName nvarchar(40)
AS
BEGIN

	SELECT supplierid as 'SupplierID', companyname as 'Company Name', contactname as 'Contact Name', country as 'Country', phone as 'Phone' 
	FROM Production.Suppliers
	WHERE companyname LIKE '%' + @companyName + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Supplier.SearchCustomerByCompanyName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Supplier.SearchCustomerByCompanyName]
@CompName nvarchar(40)
AS
BEGIN
select Production.Suppliers.supplierid as 'Supplier ID',
		Production.Suppliers.companyname as 'Company Name',
		Production.Suppliers.contactname as 'Contact Name',
		Production.Suppliers.contacttitle as 'Contact Title',
		Production.Suppliers.[address] as 'Address',
		Production.Suppliers.city as 'City',
		Production.Suppliers.region as 'Region',
		Production.Suppliers.postalcode as 'Postal Code',
		Production.Suppliers.country as 'Country',
		Production.Suppliers.phone as 'Phone',
		Production.Suppliers.fax as 'Fax'
	from Production.Suppliers
	where companyname LIKE '%' + @CompName + '%'
END




GO
/****** Object:  StoredProcedure [dbo].[Supplier.SearchCustomerByContactName]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Supplier.SearchCustomerByContactName]
@ContName nvarchar(30)
AS
BEGIN
select Production.Suppliers.supplierid as 'Supplier ID',
		Production.Suppliers.companyname as 'Company Name',
		Production.Suppliers.contactname as 'Contact Name',
		Production.Suppliers.contacttitle as 'Contact Title',
		Production.Suppliers.[address] as 'Address',
		Production.Suppliers.city as 'City',
		Production.Suppliers.region as 'Region',
		Production.Suppliers.postalcode as 'Postal Code',
		Production.Suppliers.country as 'Country',
		Production.Suppliers.phone as 'Phone',
		Production.Suppliers.fax as 'Fax'
	from Production.Suppliers
	where contactname LIKE '%' + @ContName + '%'
END




GO
/****** Object:  StoredProcedure [dbo].[Supplier.SearchCustomerByCountry]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Supplier.SearchCustomerByCountry]
@CountryName nvarchar(15)
AS
BEGIN
select Production.Suppliers.supplierid as 'Supplier ID',
		Production.Suppliers.companyname as 'Company Name',
		Production.Suppliers.contactname as 'Contact Name',
		Production.Suppliers.contacttitle as 'Contact Title',
		Production.Suppliers.[address] as 'Address',
		Production.Suppliers.city as 'City',
		Production.Suppliers.region as 'Region',
		Production.Suppliers.postalcode as 'Postal Code',
		Production.Suppliers.country as 'Country',
		Production.Suppliers.phone as 'Phone',
		Production.Suppliers.fax as 'Fax'
	from Production.Suppliers
	where country LIKE '%' + @CountryName + '%'
END




GO
/****** Object:  StoredProcedure [dbo].[Supplier.SelectAll]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Supplier.SelectAll]

AS
BEGIN
	select Production.Suppliers.supplierid as 'Supplier ID',
		Production.Suppliers.companyname as 'Company Name',
		Production.Suppliers.contactname as 'Contact Name',
		Production.Suppliers.contacttitle as 'Contact Title',
		Production.Suppliers.[address] as 'Address',
		Production.Suppliers.city as 'City',
		Production.Suppliers.region as 'Region',
		Production.Suppliers.postalcode as 'Postal Code',
		Production.Suppliers.country as 'Country',
		Production.Suppliers.phone as 'Phone',
		Production.Suppliers.fax as 'Fax'
	from Production.Suppliers
END


/**  INSERT ***/ 



GO
/****** Object:  StoredProcedure [dbo].[Supplier.SelectSomeInfo]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Supplier.SelectSomeInfo]
AS
BEGIN
	SELECT supplierid as 'SupplierID', companyname as 'Company Name', contactname as 'Contact Name', country as 'Country', phone as 'Phone' 
	FROM Production.Suppliers
	
END


GO
/****** Object:  StoredProcedure [dbo].[Supplier.SelectSomeInfo2]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Supplier.SelectSomeInfo2]
AS
BEGIN
	SELECT supplierid as 'SupplierID', companyname as 'Company Name', contactname as 'Contact Name', phone as 'Phone' 
	FROM Production.Suppliers
	
END


GO
/****** Object:  StoredProcedure [dbo].[Supplier.Update]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Supplier.Update]
	@SupID int,
	@CompanyName nvarchar(40),
	@ContactName nvarchar(30),
	@ContactTitle nvarchar(30),
	@Address nvarchar (60),
	@City nvarchar(15),
	@Region nvarchar(15),
	@PostalCode nvarchar(10),
	@Country nvarchar(15),
	@Phone nvarchar(24),
	@Fax nvarchar(24)
AS
BEGIN
	update Production.Suppliers set companyname=@CompanyName, contactname=@ContactName, contacttitle=@ContactTitle, [address]=@Address,
	city=@City, region=@Region, postalcode=@PostalCode, country=@Country, phone=@Phone, fax=@Fax
	where supplierid=@SupID
END

/** DELETE **/

SET ANSI_NULLS ON



GO
/****** Object:  StoredProcedure [dbo].[tbCustomerLoad]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[tbCustomerLoad]

AS
BEGIN
	select Sales.Customers.custid as 'Customer ID',
		Sales.Customers.companyname as 'Company Name',
		Sales.Customers.contactname as 'Contact Name',
		Sales.Customers.contacttitle as 'Contact Title',
		Sales.Customers.[address] as 'Address',
		Sales.Customers.city as 'City',
		Sales.Customers.region as 'Region',
		Sales.Customers.postalcode as 'Postal Code',
		Sales.Customers.country as 'Country',
		Sales.Customers.phone as 'Phone',
		Sales.Customers.fax as 'Fax'
	from Sales.Customers
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCustomer]
	@CustID int,
	@CompanyName nvarchar(40),
	@ContactName nvarchar(30),
	@ContactTitle nvarchar(30),
	@Address nvarchar (60),
	@City nvarchar(15),
	@Region nvarchar(15),
	@PostalCode nvarchar(10),
	@Country nvarchar(15),
	@Phone nvarchar(24),
	@Fax nvarchar(24)
AS
BEGIN
	update Sales.Customers set companyname=@CompanyName, contactname=@ContactName, contacttitle=@ContactTitle, [address]=@Address,
	city=@City, region=@Region, postalcode=@PostalCode, country=@Country, phone=@Phone, fax=@Fax
	where custid=@CustID
END



GO
/****** Object:  StoredProcedure [dbo].[updateEmployee]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateEmployee]
@lastname nvarchar(20),
@firstname nvarchar(10),
@title nvarchar(30),
@titleofcourtecy nvarchar(25),
@birthdate datetime,
@hiredate datetime,
@address nvarchar(60),
@city nvarchar(15),
@region nvarchar(15),
@postalcode nvarchar(10),
@country nvarchar(15),
@phone nvarchar(24),
@mgrid int, 
@empid int
AS
BEGIN
UPDATE HR.Employees SET lastname=@lastname,firstname = @firstname,title = @title,titleofcourtesy = @titleofcourtecy,
birthdate = @birthdate,hiredate = @hiredate,[address] = @address,city = @city,region = @region,postalcode = @postalcode,
country = @country,phone = @phone, mgrid = @mgrid
WHERE empid = @empid
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 18-12-2016 1:18:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateOrder]
(
@orderid int,
@custid int,
@empid int,
@orderdate datetime,
@requireddate datetime,
@shippeddate datetime,
@shipperid int,
@freight money,
@shipname nvarchar(50),
@shipaddress nvarchar(60),
@shipcity nvarchar(15),
@shipregion nvarchar(15),
@shippostalcode nvarchar(10),
@shipcountry nvarchar(15)
)
AS

BEGIN

	UPDATE Sales.Orders  SET custid =@custid ,empid=@empid,orderdate=@orderdate,
	requireddate=@requireddate,shippeddate=@shippeddate,shipperid=@shipperid,freight=@freight,
	shipname=@shipname, shipaddress=@shipaddress,shipcity=@shipcity,shipregion=@shipregion,
	shippostalcode=@shippostalcode,shipcountry=@shipcountry
	WHERE 
	orderid=@orderid
END




GO
USE [master]
GO
ALTER DATABASE [TSQLFundamentals2008] SET  READ_WRITE 
GO
