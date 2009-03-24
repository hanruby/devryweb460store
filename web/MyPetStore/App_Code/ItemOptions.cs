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
/// API for ItemOptions table in MyPetsFW database
/// Created By: Richard Crouch
/// </summary>
public class ItemOptions : IBase
{
    // Constructors
    #region constructors
    public ItemOptions()
	{
        ItemOptionID = Guid.Empty;
        ItemID = Guid.Empty;
        VendorID = Guid.Empty;
        OptionName = "";
    }

    public ItemOptions(Guid ItemOptionID, Guid ItemID, Guid VendorID, string OptionName)
    {
        this.ItemOptionID = ItemOptionID;
        this.ItemID = ItemID;
        this.VendorID = VendorID;
        this.OptionName = OptionName;
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
        ItemOptionID = Guid.Empty;
        ItemID = Guid.Empty;
        VendorID = Guid.Empty;
        OptionName = "";
    }

    #endregion
    #endregion

    // Properties
    #region properties
    public Guid ItemOptionID { get; set; }
    public Guid ItemID { get; set; }
    public Guid VendorID { get; set; }
    public string OptionName { get; set; }
    #endregion
}
