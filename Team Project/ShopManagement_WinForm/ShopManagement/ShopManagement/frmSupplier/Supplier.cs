using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement
{
    class Supplier
    {
        string SupID, CompanyName, ContactName, ContactTitile, Address, City, Region, PostalCode, Country, Phone, Fax;
        public Supplier(string supID, string companyName, string contactName, string contactTitile, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            SupID = supID;
            CompanyName = companyName;
            ContactName = contactName;
            ContactTitile = contactTitile;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Fax = fax;
        }
        #region GetSet
        public string Address1
        {
            get
            {
                return Address;
            }

            set
            {
                Address = value;
            }
        }

        public string City1
        {
            get
            {
                return City;
            }

            set
            {
                City = value;
            }
        }

        public string CompanyName1
        {
            get
            {
                return CompanyName;
            }

            set
            {
                CompanyName = value;
            }
        }

        public string ContactName1
        {
            get
            {
                return ContactName;
            }

            set
            {
                ContactName = value;
            }
        }

        public string ContactTitile1
        {
            get
            {
                return ContactTitile;
            }

            set
            {
                ContactTitile = value;
            }
        }

        public string Country1
        {
            get
            {
                return Country;
            }

            set
            {
                Country = value;
            }
        }

        public string SupID1
        {
            get
            {
                return SupID;
            }

            set
            {
                SupID = value;
            }
        }

        public string Fax1
        {
            get
            {
                return Fax;
            }

            set
            {
                Fax = value;
            }
        }

        public string Phone1
        {
            get
            {
                return Phone;
            }

            set
            {
                Phone = value;
            }
        }

        public string PostalCode1
        {
            get
            {
                return PostalCode;
            }

            set
            {
                PostalCode = value;
            }
        }

        public string Region1
        {
            get
            {
                return Region;
            }

            set
            {
                Region = value;
            }
        } 
        #endregion

    }
}
