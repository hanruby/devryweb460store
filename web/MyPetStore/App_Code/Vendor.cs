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
/// API for Vendor table in MyPetsFW database
/// Created By: Richard Crouch
/// </summary>
public class Vendor : IBase
{
    // Constructors
    #region constructors
    public Vendor()
	{
        VendorID = Guid.Empty;
        IsActive = false;
        VendorName = "";
        MainPhone = "";
        ContactName = "";
        ContactEmail = "";
        ContactPhone = "";
        Website = "";
        Address = "";
        Address2 = "";
        City = "";
        State = "";
        Zip = "";
        Country = "";
    }

    public Vendor(Guid VendorID, bool IsActive, string VendorName, string MainPhone, string ContactName,
        string ContactEmail, string ContactPhone, string Website, string Address, string Address2,
        string City, string State, string Zip, string Country)
    {
        this.VendorID = VendorID;
        this.IsActive = IsActive;
        this.VendorName = VendorName;
        this.MainPhone = MainPhone;
        this.ContactName = ContactName;
        this.ContactEmail = ContactEmail;
        this.ContactPhone = ContactPhone;
        this.Website = Website;
        this.Address = Address;
        this.Address2 = Address2;
        this.City = City;
        this.State = State;
        this.Zip = Zip;
        this.Country = Country;
    }
    #endregion

    // Behaviors
    #region behaviors
    #region IBase Members

    public System.Collections.Generic.IList<object> Get()
    {
        throw new NotImplementedException();
    }

    public bool Add()
    {
        throw new NotImplementedException();
    }

    public bool Delete()
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        VendorID = Guid.Empty;
        IsActive = false;
        VendorName = "";
        MainPhone = "";
        ContactName = "";
        ContactEmail = "";
        ContactPhone = "";
        Website = "";
        Address = "";
        Address2 = "";
        City = "";
        State = "";
        Zip = "";
        Country = "";
    }

    #endregion
    #endregion

    // Properties
    #region properties
    public Guid VendorID { get; set; }
    public bool IsActive { get; set; }
    public string VendorName { get; set; }
    public string MainPhone { get; set; }
    public string ContactName { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public string Website { get; set; }
    public string Address { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    #endregion
}
