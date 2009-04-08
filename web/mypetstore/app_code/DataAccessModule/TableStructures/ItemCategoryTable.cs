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

/// <summary>
/// Summary description for ItemCategoryTable
/// </summary>
public class ItemCategoryTable
{
    //TableName
    public const string TableName = "ItemCategories";

    //Columns
    public const string ItemIdColumn = "ItemID";
    public const string VendorIdColumn = "VendorID";
    public const string CategoryIdColumn = "CategoryID";

    //Parameters
    public const string ItemIdParam = "@ItemID";
    public const string VendorIdParam = "@VendorID";
    public const string CategoryIdParam = "@CategoryID";
}
