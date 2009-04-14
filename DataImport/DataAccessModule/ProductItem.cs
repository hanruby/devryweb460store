using System;

namespace DataAccessModule
{
    [Serializable]
    public class ProductItem
    {
        public int VendorID { get; set;}
        public int CategoryID { get; set;}
        public string ItemID { get; set;}
        public string ProductCode { get; set; }
        public string Section { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Picture { get; set; }
        public string ProductSize { get; set; }
        public string UPC { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Cost { get; set; }
        public decimal ShippingSurcharge { get; set; }
        public decimal QuantityAvailable { get; set; }
        public decimal MinQuantity { get; set; }
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

        public ProductItem()
        {
            VendorID = -1;
            Price = -1M;
            ListPrice = -1M;
            Cost = -1M;
            ShippingSurcharge = -1M;
            QuantityAvailable = -1M;
            MinQuantity = -1M;
        }
    }
}
