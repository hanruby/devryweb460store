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
/// Holds constants used for the SubCategory Database Table
/// </summary>
public static class SubCategoryTable
{
    //TableName
    public const string TableName = "SubCategories";

    //Columns
    public const string IdColumn = "SubCategoryID";
    public const string ParentCategoryIdColumn = "ParentCategoryID";
    public const string NameColumn = "SubCategoryName";
    public const string ImageColumn = "SubCategoryPhoto";


    //Parameters
    public const string IdParam = "@CategoryID";
    public const string ParentCategoryIdParam = "@ParentCategoryID";
    public const string NameParam = "@CategoryName";
    public const string ImageParam = "@CategoryPhoto";
}

