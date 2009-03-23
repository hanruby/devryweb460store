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
/// Summary description for Vendor
/// </summary>
[DBTable("Vendor")]
public class Vendor
{
    private int id;
    private bool isActive;
    private string name;
    private string mainPhone;
    private string contactName;
    private string contactEmail;
    private string contactPhone;
    private string website;
    private string address;
    private string address2;
    private string city;
    private string state;
    private string zip;
    private string country;

	public Vendor()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //change to PK
    [DBColumn("VendorID")]
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    [DBColumn("IsActive")]
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    [DBColumn("VendorName")]
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    [DBColumn("MainPhone")]
    public string MainPhone
    {
        get { return mainPhone; }
        set { mainPhone = value; }
    }

    [DBColumn("ContactName")]
    public string ContactName
    {
        get { return contactName; }
        set { contactName = value; }
    }
    [DBColumn("ContactEmail")]
    public string ContactEmail
    {
        get { return contactEmail; }
        set { contactEmail = value; }
    }

    [DBColumn("ContactPhone")]
    public string ContactPhone
    {
        get { return contactPhone; }
        set { contactPhone = value; }
    }

    [DBColumn("Website")]
    public string Website
    {
        get { return website; }
        set { website = value; }
    }

    [DBColumn("Address")]
    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    [DBColumn("Address2")]
    public string Address2
    {
        get { return address2; }
        set { address2 = value; }
    }

    [DBColumn("City")]
    public string City
    {
        get { return city; }
        set { city = value; }
    }

    [DBColumn("State")]
    public string State
    {
        get { return state; }
        set { state = value; }
    }

    [DBColumn("Zip")]
    public string Zip
    {
        get { return zip; }
        set { zip = value; }
    }

    [DBColumn("Country")]
    public string Country
    {
        get { return country; }
        set { country = value; }
    }
}
