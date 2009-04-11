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
    public class Item
    {
        private string id;
        private string name;
        private string description;
        private string size;

        private string code;
        private string upc;

        private int? vendorId;
        private Vendor vendor; //foreign key relationship


        private bool? isActive;
        private int? quantityAvailable;
        private int? minQuantity;
        

        private decimal? price;
        private decimal? costPrice;
        private decimal? recommendPrice;

        private string imageName;
        private string imageLocation;


        public Item()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Item(string id, string name, string description, string size, string code, string upc, int vendorId, bool isActive, int quantityAvailable, int minQuantity, decimal price, decimal costPrice, decimal recommendPrice, string imageName, string imageLocation)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.size = size;
            this.code = code;
            this.upc = upc;
            this.vendorId = vendorId;
            this.isActive = isActive;
            this.quantityAvailable = quantityAvailable;
            this.minQuantity = minQuantity;
            this.price = price;
            this.costPrice = costPrice;
            this.recommendPrice = recommendPrice;
            this.imageName = imageName;
            this.imageLocation = imageLocation;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Upc
        {
            get { return upc; }
            set { upc = value; }
        }

        public int? VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        public bool? IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public int? QuantityAvailable
        {
            get { return quantityAvailable; }
            set { quantityAvailable = value; }
        }

        public int? MinQuantity
        {
            get { return minQuantity; }
            set { minQuantity = value; }
        }

        public decimal? Price
        {
            get { return price; }
            set { price = value; }
        }

        public decimal? CostPrice
        {
            get { return costPrice; }
            set { costPrice = value; }
        }

        public decimal? RecommendPrice
        {
            get { return recommendPrice; }
            set { recommendPrice = value; }
        }

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }

        public string ImageLocation
        {
            get { return imageLocation; }
            set { imageLocation = value; }
        }

        public Vendor Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }


    }
}