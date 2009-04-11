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
/// /// Holds constants used for the Vendor Database Table
/// </summary>
public static class VendorTable
{
    //Table Name
    public const string TableName = "Vendor";
    
    //Columns
    public const string IdColumn = "VendorID";
    public const string IsActiveColumn = "IsActive";
    public const string NameColumn = "VendorName";
    public const string MainPhoneColumn = "MainPhone";
    public const string ContactNameColumn = "ContactName";
    public const string EmailColumn = "ContactEmail";
    public const string PhoneColumn = "ContactPhone";
    public const string WebsiteColumn = "Website";
    public const string AddressColumn = "Address";
    public const string Address2Column = "Address2";
    public const string CityColumn = "City";
    public const string StateColumn = "State";
    public const string ZipColumn = "Zip";
    public const string CountryColumn = "Country";

    //Parameters
    public const string IdParam = "@VendorID";
    public const string IsActiveParam = "@IsActive";
    public const string NameParam = "@VendorName";
    public const string MainPhoneParam = "@MainPhone";
    public const string ContactNameParam = "@ContactName";
    public const string EmailParam = "@ContactEmail";
    public const string PhoneParam = "@ContactPhone";
    public const string WebsiteParam = "@Website";
    public const string AddressParam = "@Address";
    public const string Address2Param = "@Address2";
    public const string CityParam = "@City";
    public const string StateParam = "@State";
    public const string ZipParam = "@Zip";
    public const string CountryParam = "@Country";
}
