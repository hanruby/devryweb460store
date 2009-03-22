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
		//
		// TODO: Add constructor logic here
		//
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
        throw new NotImplementedException();
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
