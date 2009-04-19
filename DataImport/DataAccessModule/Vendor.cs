using System;

namespace DataAccessModule
{
    [Serializable]
    public class Vendor
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string MainPhone { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool UseIsActive { get; set; }

        public bool IsActive
        {
            get
            {
                return(isActive);
            }
            set
            {
                isActive = value;
                UseIsActive = true;
            }
        }

        private bool isActive;

        public Vendor()
        {
            VendorID = -1;
        }
    }
}
