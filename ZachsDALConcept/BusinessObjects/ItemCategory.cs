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
/// Summary description for ItemCategory
/// </summary>
[DBTable("ItemCategory")]
public class ItemCategory
{
    private Item item;
    private Vendor vendor;
    private Category category;
    
	public ItemCategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    [DBColumn("ItemID")]
    public int ProductID
    {
        get { return item.Id; }
    }

    public Item Product
    {
        get{ return item; }
        set{ item = value; }
    }

    

    [DBColumn("VendorID")]
    public int ProductVendorID
    {
        get { return vendor.Id; }
    }

    public Vendor ProductVendor
    {
        get{ return vendor; }
        set{ vendor = value; }
    }

    [DBColumn("CategoryID")]
    public int ProductCategoryID
    {
        get { return category.Id; }
    }

    public Category ProductCategory
    {
        get{ return category; }
        set{ category = value; }
    }

    
}
