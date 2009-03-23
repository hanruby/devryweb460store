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
/// Summary description for Items
/// </summary>

[DBTable("Item")]
public class Item
{
    private int id;
    private bool isActive;
    private string description;
    private int quantityAvailable;
    private double price;
    private string photoName;
    private string photoLocation; //we could just store this in the DB
    private int minQuantity;
    private double costPrice; //what is the difference between this and price
    private double recomendedPrice;

    private Vendor vendor;
	public Item()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    [DBColumn("ItemID")]
    public int Id
    {
        get { return id; }
        set { id = value;}
    }

    [DBColumn("IsActive")]
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value;}
    }

    [DBColumn("Description")]
    public string Description
    {
        get { return description; }
        set { description = value;}
    }

    [DBColumn("QuantityAvailable")]
    public int QuantityAvailable
    {
        get { return quantityAvailable; }
        set { quantityAvailable = value;}
    }

    [DBColumn("Price")]
    public double Price
    {
        get { return price; }
        set { price = value;}
    }

    [DBColumn("PhotoName")]
    public string PhotoName
    {
        get { return photoName; }
        set { photoName = value;}
    }

    [DBColumn("PhotoLocation")]
    public string PhotoLocation //we could just store this in the DB
    {
        get { return photoLocation; }
        set { photoLocation = value;}
    }

    [DBColumn("MinQuantity")]
    public int MinQuantity
    {
        get { return minQuantity; }
        set { minQuantity = value;}
    }

    [DBColumn("CostPrice")]
    public double CostPrice //what is the difference between this and price
    {
        get { return costPrice; }
        set { costPrice = value;}
    }

    [DBColumn("RecomendedPrice")]
    public double RecomendedPrice
    {
        get { return recomendedPrice ; }
        set { recomendedPrice = value;}
    }


    [DBColumn("")] //fkey make appropriate changes
    public int VendorID
    {
        get { return vendor.Id; }
    }

    public Vendor ItemVendor
    {
        get { return vendor; }
        set { vendor = value; }
    }
}
