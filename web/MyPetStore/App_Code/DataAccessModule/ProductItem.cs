using System;

namespace DataAccessModule
{
    [Serializable]
    public class ProductItem
    {
        public int VendorID { get; set;}
        public string ProductCode { get; set; }
        public string Section { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Picture { get; set; }
        public string ProductSize { get; set; }
        public decimal Cost { get; set; }
        public decimal ShippingSurcharge { get; set; }
        public string UPC { get; set; }
    }
}
