﻿using System;
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
/// /// Holds constants used for the Item Database Table
/// </summary>
public static class ItemTable
{
    //Table Name
    public const string TableName = "Items";

    //Columns
    public const string IdColumn = "ItemID";
    public const string VendorIdColumn = "VendorID";
    public const string IsActiveColumn = "IsActive";
    public const string DescriptionColumn = "Description";
    public const string QuantityAvailableColumn = "QuantityAvailable";
    public const string PriceColumn = "Price";
    public const string ImageNameColumn = "PhotoName";
    public const string ImageLocationColumn = "PhotoLocation";
    public const string MinQuantityColumn = "MinQuantity";
    public const string CostPriceColumn = "CostPrice";
    public const string RecommendedPriceColumn = "RecommendedPrice";
    public const string UPCColumn = "UPC";
    public const string NameColumn = "ProductName";
    public const string CodeColumn = "ProductCode";
    public const string SizeColumn = "Size";

    //Columns
    public const string IdParam = "@ItemID";
    public const string VendorIdParam = "@VendorID";
    public const string IsActiveParam = "@IsActive";
    public const string DescriptionParam = "@Description";
    public const string QuantityAvailableParam = "@QuantityAvailable";
    public const string PriceParam = "@Price";
    public const string ImageNameParam = "@PhotoName";
    public const string ImageLocationParam = "@PhotoLocation";
    public const string MinQuantityParam = "@MinQuantity";
    public const string CostPriceParam = "@CostPrice";
    public const string RecommendedPriceParam = "@RecommendedPrice";
    public const string UPCParam = "@UPC";
    public const string NameParam = "@ProductName";
    public const string CodeParam = "@ProductCode";
    public const string SizeParam = "@Size";

}
