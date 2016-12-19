using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement
{
    public class Lib
    {
        string orderID, customerID, employeeID, orderDate, requireDate;
        string shipDate, shipID, freight, shipName, shipAddress;
        string shipCity, shipRegion, shipPostalCode, shipCountry;

        #region getset
        public string OrderID1
        {
            get
            {
                return orderID;
            }

            set
            {
                orderID = value;
            }
        }

        public string CustomerID1
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public string EmployeeID1
        {
            get
            {
                return employeeID;
            }

            set
            {
                employeeID = value;
            }
        }

        public string OrderDate1
        {
            get
            {
                return orderDate;
            }

            set
            {
                orderDate = value;
            }
        }

        public string RequireDate1
        {
            get
            {
                return requireDate;
            }

            set
            {
                requireDate = value;
            }
        }

        public string ShipDate1
        {
            get
            {
                return shipDate;
            }

            set
            {
                shipDate = value;
            }
        }

        public string ShipID1
        {
            get
            {
                return shipID;
            }

            set
            {
                shipID = value;
            }
        }

        public string Freight1
        {
            get
            {
                return freight;
            }

            set
            {
                freight = value;
            }
        }

        public string ShipName1
        {
            get
            {
                return shipName;
            }

            set
            {
                shipName = value;
            }
        }

        public string ShipAddress1
        {
            get
            {
                return shipAddress;
            }

            set
            {
                shipAddress = value;
            }
        }

        public string ShipCity1
        {
            get
            {
                return shipCity;
            }

            set
            {
                shipCity = value;
            }
        }

        public string ShipRegion1
        {
            get
            {
                return shipRegion;
            }

            set
            {
                shipRegion = value;
            }
        }

        public string ShipPostalCode1
        {
            get
            {
                return shipPostalCode;
            }

            set
            {
                shipPostalCode = value;
            }
        }

        public string ShipCountry1
        {
            get
            {
                return shipCountry;
            }

            set
            {
                shipCountry = value;
            }
        }
        #endregion

        #region constructor
        public Lib(string orderID, string customerID, string employeeID, string orderDate, string requireDate, string shipDate, string shipID, string freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            this.OrderID1 = orderID;
            this.CustomerID1 = customerID;
            this.EmployeeID1 = employeeID;
            this.OrderDate1 = orderDate;
            this.RequireDate1 = requireDate;
            this.ShipDate1 = shipDate;
            this.ShipID1 = shipID;
            this.Freight1 = freight;
            this.ShipName1 = shipName;
            this.ShipAddress1 = shipAddress;
            this.ShipCity1 = shipCity;
            this.ShipRegion1 = shipRegion;
            this.ShipPostalCode1 = shipPostalCode;
            this.ShipCountry1 = shipCountry;
        }
        #endregion
    }
    
}
