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
/// /// Holds constants used for the Order Database Table
/// </summary>
public static class OrderTable
{
    //Table Name
    public const string TableName = "Orders";

    //Columns
    public const string IdColumn = "OrderID";
    public const string CustomerIdColumn = "CustomerID";
    public const string GrossTotalColumn = "GrossTotal";
    public const string TaxColumn = "Tax";
    public const string NetTotalColumn = "NetTotal";
    public const string TXNIDColumn = "TXNID";
    public const string DateColumn = "Date";

    //Parameters
    public const string IdParam = "@OrderID";
    public const string CustomerIdParam = "@CustomerID";
    public const string GrossTotalParam = "@GrossTotal";
    public const string TaxParam = "@Tax";
    public const string NetTotalParam = "@NetTotal";
    public const string TXNIDParam = "@TXNID";
    public const string DateParam = "@Date";
}
