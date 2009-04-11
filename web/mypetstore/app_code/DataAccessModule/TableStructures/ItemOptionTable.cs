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
    /// Summary description for ItemOptionTable
    /// </summary>
    public class ItemOptionTable
    {
        //TableName
        public const string TableName = "ItemOptions";

        //Columns
        public const string IdColumn = "ItemOptionID";
        public const string ItemIdColumn = "ItemID";
        public const string VendorIdColumn = "VendorID";
        public const string OptionNameColumn = "OptionName";

        //Parameters
        public const string IdParam = "@ItemOptionID";
        public const string ItemIdParam = "@ItemID";
        public const string VendorIdParam = "@VendorID";
        public const string OptionNameParam = "@OptionName";
    }
}