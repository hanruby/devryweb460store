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
    /// Summary description for ItemOptionValueTable
    /// </summary>
    public class ItemOptionValueTable
    {
        //TableName
        public const string TableName = "ItemOptionValues";

        //Columns
        public const string IdColumn = "ItemOptionValueID";
        public const string ItemOptionIdColumn = "ItemOptionID";
        public const string ItemIdColumn = "ItemID";
        public const string VendorIdColumn = "VendorID";
        public const string OptionValueColumn = "OptionValue";

        //Parameters
        public const string IdParam = "@ItemOptionValueID";
        public const string ItemOptionIdParam = "@ItemOptionID";
        public const string ItemIdParam = "@ItemID";
        public const string VendorIdParam = "@VendorID";
        public const string OptionValueParam = "@OptionValue";
    }
}