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
/// /// Holds constants used for the OrderTracking Database Table
/// </summary>
public static class OrderTrackingTable
{
    //Table Name
    public const string TableName = "OrderTracking";

    //Columns
    public const string IdColumn = "TrackingID";
    public const string OrderIdColumn = "OrderID";
    public const string ItemIdColumn = "ItemID";
    public const string VendorIdColumn = "VendorID";
    public const string ShipDateColumn = "ShipDate";
    public const string EstimatedArrivalColumn = "EstArrival";
    public const string UrlColumn = "TrackingUrl";

    //Parameters
    public const string IdParam = "TrackingID";
    public const string OrderIdParam = "OrderID";
    public const string ItemIdParam = "ItemID";
    public const string VendorIdParam = "VendorID";
    public const string ShipDateParam = "ShipDate";
    public const string EstimatedArrivalParam = "EstArrival";
    public const string UrlParam = "TrackingUrl";
}
