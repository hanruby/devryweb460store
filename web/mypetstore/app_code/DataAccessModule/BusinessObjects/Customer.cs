using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DataAccessModule
{
    public class Customer
    {
        private int? id;
        private bool? isActive;
        private string username;
        private string firstName;
        private string lastName;
        private string address;
        private string address2;
        private string city;
        private string state;
        private string zip;
        private string country;

        public Customer()
        {
            this.isActive = null;
            this.username = null;
            this.firstName = null;
            this.lastName = null;
            this.address = null;
            this.address2 = null;
            this.city = null;
            this.state = null;
            this.zip = null;
            this.country = null;
        }

        public Customer(int id, bool isActive, string username, string firstName, string lastName, string address, string address2, string city, string state, string zip, string country)
        {
            this.id = id;
            this.isActive = isActive;
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.address2 = address2;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.country = country;
        }

        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool? IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
    }
}