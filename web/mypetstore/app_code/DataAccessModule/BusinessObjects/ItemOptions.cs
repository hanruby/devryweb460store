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
    /// Summary description for ItemOptions
    /// </summary>
    public class ItemOption
    {
        private int? id;
        private int? itemId;
        private int? vendorId;
        private string optionName;

        public ItemOption()
        {
        }

        public ItemOption(int id, int itemId, int vendorId, string optionName)
        {
            this.id = id;
            this.itemId = itemId;
            this.vendorId = vendorId;
            this.optionName = optionName;
        }

        public int? Id
        {
            get { return id; }
            set { id = value; }
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

        public string OptionName
        {
            get { return optionName; }
            set { optionName = value; }
        }
    }
}