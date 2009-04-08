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
    public class ItemCategory
    {
        private int? itemId;
        private Item item;//foreign table

        private int? vendorId;
        private Vendor vendor;//foreign table

        private int? categoryId;
        private Category category;//foreign table



        public ItemCategory()
        {
        }

        public ItemCategory(int itemId, int vendorId, int categoryId)
        {
            this.itemId = itemId;
            this.vendorId = vendorId;
            this.categoryId = categoryId;
        }

        public int? ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public int? VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        public int? CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }

        public Vendor Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }
    }
}
