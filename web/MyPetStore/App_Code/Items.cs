using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Items
/// Author: Daniel Aguayo
/// </summary>
public class Items : IBase
{
    // attributes
    public const string ItemIDColumn = "ItemID";
    public const string VendorIDColumn = "VendorID";
    public const string IsActiveColumn = "IsActive";
    public const string DescriptionColumn = "Description";
    public const string QuantityAvailableColumn = "QuantityAvailable";
    public const string PriceColumn = "Price";
    public const string PhotoNameColumn = "PhotoName";
    public const string PhotoLocationColumn = "PhotoLocation";
    public const string MinQuantityColumn = "MinQuantity";
    public const string CostPriceColumn = "CostPrice";
    public const string RecomendationColumn = "Recomendation";

    public const string ParmItemID = "@itemID";
    public const string ParmVendorID = "@vendorID";
    public const string ParmIsActive = "@isActive";
    public const string ParmDescription = "@description";
    public const string ParmQuantityAvailable = "@quantityAvailable";
    public const string ParmPrice = "@price";
    public const string ParmPhotoName = "@photoName";
    public const string ParmPhotoLocation = "@photoLocation";
    public const string ParmMinQuantity = "@minQuantity";
    public const string ParmCostPrice = "@costPrice";
    public const string ParmRecomendation = "@recommendation";
    

    // constructors
	public Items()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    // behaviors
    #region IBase Members

    public System.Collections.Generic.IList<object> Get()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public bool Add()
    {
       
        ParmList parm = new ParmList();

        parm.Add(ParmItemID, ItemID);
        parm.Add(ParmVendorID, VendorID);
        parm.Add(ParmIsActive, IsActive);
        parm.Add(ParmDescription, Description);
        parm.Add(ParmQuantityAvailable, QuantityAvailable);

        // connect to database
        DBConnect dbConnect = new DBConnect("connectionString", parm);

       

        // build insert command
         string comm = String.Format("INSERT INTO Items VALUES({0} = {1},{2} = {3}, {4} = {5}, {6} = {7})",
            ItemIDColumn, ParmItemID, VendorIDColumn, ParmVendorID, VendorIDColumn, ParmVendorID, PriceColumn, ParmPrice
            );


       

        // execute command
        dbConnect.ExecSQL(comm);

        // clear commands
        Clear();

        return true;
    }

    public bool Delete()
    {
        ParmList parm = new ParmList();


        parm.Add(ParmItemID, ItemID);
        parm.Add(ParmVendorID, VendorID);
        parm.Add(ParmIsActive, IsActive);
        parm.Add(ParmDescription, Description);
        parm.Add(ParmQuantityAvailable, QuantityAvailable);


        // connect to database
        DBConnect dbConnect = new DBConnect("connectionString", parm);

        // build insert command
        string comm = String.Format("DELETE FROM Items WHERE({0} = {1},{2} = {3}, {4} = {5}, {6} = {7})",
            ItemIDColumn, ParmItemID, ItemIDColumn, ParmItemID, VendorIDColumn, ParmVendorID, PriceColumn, ParmPrice
            );

        // execute command
        dbConnect.ExecSQL(comm);

        return true;
    }

    public void Clear()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    // properties
    public string ItemID
    {
        get
        {
            return ItemID;
        }
        set
        {
            ItemID = value;
        }
    }

    public string VendorID
    {
        get
        {
            return VendorID;
        }
        set
        {
            VendorID = value;
        }
    }

    public string IsActive
    {
        get
        {
            return IsActive;
        }
        set
        {
            IsActive = value;
        }
    }

    public string Description
    {
        get
        {
            return Description;
        }
        set
        {
            Description = value;
        }
    }

    public string QuantityAvailable
    {
        get
        {
            return QuantityAvailable;
        }
        set
        {
            QuantityAvailable = value;
        }
    }

    public string Price
    {
        get
        {
            return Price;
        }
        set
        {
            Price = value;
        }
    }

    public string PhotoName
    {
        get
        {
            return PhotoName;
        }
        set
        {
            PhotoName = value;
        }
    }

    public string PhotoLocation
    {
        get
        {
            return PhotoLocation;
        }
        set
        {
            PhotoLocation = value;
        }
    }

    public string MinQuantity
    {
        get
        {
            return MinQuantity;
        }
        set
        {
            MinQuantity = value;
        }
    }

    public string CostPrice
    {
        get
        {
            return CostPrice;
        }
        set
        {
            CostPrice = value;
        }
    }

    public string Recommendation
    {
        get
        {
            return Recommendation;
        }
        set
        {
            Recommendation = value;
        }
    }
}
