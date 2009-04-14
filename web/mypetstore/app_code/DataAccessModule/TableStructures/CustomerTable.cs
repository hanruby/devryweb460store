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
/// Holds constants used for the Custoemr Database Table
/// </summary>
public static class CustomerTable
{
    //Table Name
    public const string TableName = "Customer";

    //Columns
    public const string IdColumn = "CustomerID";
    public const string IsActiveColumn = "IsActive";
    public const string UsernameColumn = "UserName";
    public const string FirstNameColumn = "FName";
    public const string LastNameColumn = "LName";
    public const string AddressColumn = "Address";
    public const string Address2Column = "Address2";
    public const string CityColumn = "City";
    public const string StateColumn = "State";
    public const string ZipColumn = "Zip";
    public const string CountryColumn = "Country";

    //Parameters
    public const string IdParam = "@CustomerID";
    public const string IsActiveParam = "@IsActive";
    public const string UsernameParam = "@UserName";
    public const string FirstNameParam = "@FName";
    public const string LastNameParam = "@LName";
    public const string AddressParam = "@Address";
    public const string Address2Param = "@Address2";
    public const string CityParam = "@City";
    public const string StateParam = "@State";
    public const string ZipParam = "@Zip";
    public const string CountryParam = "@Country";
}
