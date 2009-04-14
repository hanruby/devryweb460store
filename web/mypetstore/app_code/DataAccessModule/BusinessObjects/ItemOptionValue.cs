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
    /// <summary>
    /// Summary description for ImportColumnValue
    /// </summary>
    public class ItemOptionValue
    {
        private int? id;
        
        private int? itemOptionId;
        private ItemOption itemOption;//foreign table

        private int? itemId;
        private Item item; //foreign table

        private int? vendorId;
        private Vendor vendor;//foreign table

        private string optionValue;

        public ItemOptionValue()
        {
        }

        public ItemOptionValue(int id, int itemOptionId, int itemId, int vendorId, string optionValue)
        {
            this.id = id;
            this.itemOptionId = itemOptionId;
            this.itemId = itemId;
            this.vendorId = vendorId;
            this.optionValue = optionValue;
        }

        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        public int? ItemOptionId
        {
            get { return itemOptionId; }
            set { itemOptionId = value; }
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

        public string OptionValue
        {
            get { return optionValue; }
            set { optionValue = value; }
        }

        public ItemOption ItemOption
        {
            get { return itemOption; }
            set { itemOption = value; }
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
    }
}