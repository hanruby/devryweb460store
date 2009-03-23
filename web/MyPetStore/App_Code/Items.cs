using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for Items
/// Author: Daniel Aguayo
/// </summary>
public class Items : IBase
{
    // attributes
    private string itemID;
    private int vendorID;
    private bool isActive;
    private string description;
    private int quantityAvailable;
    private double price;
    private string photoName;
    private string photoLocation;
    private int minQuantity;
    private double costPrice;
    private double recommendedPrice;










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
    public const string ParmRecomendation = "@recommendedPrice";


    // constructors
    public Items()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Items(string itemID, int vendorID, bool isActive, string description, int quantityAvailable,
        double price, string photoName, string photoLocation, int minQuantity, double costPrice, double recommendedPrice)
    {
        this.itemID = itemID;
        this.vendorID = vendorID;
        this.isActive = isActive;
        this.description = description;
        this.quantityAvailable = quantityAvailable;
        this.price = price;
        this.photoName = photoName;
        this.photoLocation = photoLocation;
        this.minQuantity = minQuantity;
        this.costPrice = costPrice;
        this.recommendedPrice = recommendedPrice;

    }


    // behaviors
    #region IBase Members

    public System.Collections.Generic.IList<object> Get()
    {
        List<object> list = new List<object>();

        return list;
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
        
        itemID = null;
        vendorID = -1;
        price = -1;
        description = null;
        quantityAvailable = -1;
        price = -1;
        photoName = null;
        photoLocation = null;
        minQuantity = -1;
        costPrice = -1;
        recommendedPrice = -1;
    }

    #endregion

    // properties
    public string ItemID
    {
        get
        {
            return itemID;
        }
        set
        {
            this.itemID = value;
        }
    }

    public int VendorID
    {
        get
        {
            return vendorID;
        }
        set
        {
            this.vendorID = value;
        }
    }

    public bool IsActive
    {
        get
        {
            return isActive;
        }
        set
        {
            this.isActive = value;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            this.description = value;
        }
    }

    public int QuantityAvailable
    {
        get
        {
            return quantityAvailable;
        }
        set
        {
            this.quantityAvailable = value;
        }
    }

    public double Price
    {
        get
        {
            return price;
        }
        set
        {
            price = value;
        }
    }

    public string PhotoName
    {
        get
        {
            return photoName;
        }
        set
        {
            this.photoName = value;
        }
    }

    public string PhotoLocation
    {
        get
        {
            return photoLocation;
        }
        set
        {
            this.photoLocation = value;
        }
    }

    public int MinQuantity
    {
        get
        {
            return minQuantity;
        }
        set
        {
            this.minQuantity = value;
        }
    }

    public double CostPrice
    {
        get
        {
            return costPrice;
        }
        set
        {
            this.costPrice = value;
        }
    }

    public double RecommendedPrice
    {
        get
        {
            return recommendedPrice;
        }
        set
        {
            this.recommendedPrice = value;
        }
    }
}
