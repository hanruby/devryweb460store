using System;

namespace DataAccessModule
{
    [Serializable]
    public class Vendor
    {
        private int? id;
        private bool? isActive;
        private string name;
        private string mainPhone;
        private string contactName;
        private string email;
        private string phone;
        private string website;
        private string address;
        private string address2;
        private string city;
        private string state;
        private string zip;
        private string country;

        public Vendor()
        {
        }

        public Vendor(int id, bool isActive, string name, string mainPhone, string contactName, string email, string phone, string website, string address, string address2, string city, string state, string zip, string country)
        {
            this.id = id;
            this.isActive = isActive;
            this.name = name;
            this.mainPhone = mainPhone;
            this.contactName = contactName;
            this.email = email;
            this.phone = phone;
            this.website = website;
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

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string MainPhone
        {
            get { return mainPhone; }
            set { mainPhone = value; }
        }

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
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
