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
/// /// Holds constants used for the OrderItem Database Table
/// </summary>
public static class OrderItemTable
{

    //Table Name
    public const string TableName = "OrderItem";

    //Columns
    public const string OrderIdColumn = "OrderID";
    public const string ItemIdColumn = "ItemID";
    public const string VendorIdColumn = "VendorID";
    public const string PriceColumn = "Price";
    public const string TotalPriceColumn = "TotalPrice";
    public const string QuantityColumn = "Quantity";

    //Parameters
    public const string OrderIdParam = "@OrderID";
    public const string ItemIdParam = "@ItemID";
    public const string VendorIdParam = "@VendorID";
    public const string PriceParam = "@Price";
    public const string TotalPriceParam = "@TotalPrice";
    public const string QuantityParam = "@Quantity";
}
