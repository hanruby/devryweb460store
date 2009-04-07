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
/// /// Holds constants used for the ItemVideo Database Table
/// </summary>
public static class ItemVideoTable
{
    //Table Name
    public const string TableName = "IteamVideo";

    //Columns
    public const string IdColumn = "VideoID";
    public const string ItemIdColumn = "ItemID";
    public const string VendorIdColumn = "VendorID";
    public const string NameColumn = "VideoName";
    public const string DescriptionColumn = "VideoDescription";
    public const string UrlColumn = "Link";
    public const string SourceColumn = "VideoSource";

    //Parameters
    public const string IdParam = "@VideoID";
    public const string ItemIdParam = "@ItemID";
    public const string VendorIdParam = "@VendorID";
    public const string NameParam = "@VideoName";
    public const string DescriptionParam = "@VideoDescription";
    public const string UrlParam = "@Link";
    public const string SourceParam = "@VideoSource";

    //SQL Statements
    public const string Insert = "INSERT INTO " + TableName + "("
                                 + IdColumn + ", "
                                 + ItemIdColumn + ", "
                                 + VendorIdColumn + ", "
                                 + NameColumn + ", "
                                 + DescriptionColumn + ", "
                                 + UrlColumn + ", "
                                 + SourceColumn + ")"

                                 + " VALUES("
                                 + IdParam + ", "
                                 + ItemIdParam + ", "
                                 + VendorIdParam + ", "
                                 + NameParam + ", "
                                 + DescriptionParam + ", "
                                 + UrlParam + ", "
                                 + SourceParam + ")";

    public const string Update = "UPDATE " + TableName + " SET ";
    public const string UpdateById = "UPDATE " + TableName + " SET "
                                     + IdColumn + "=" + IdParam + ", "
                                     + ItemIdColumn + "=" + ItemIdParam + ", "
                                     + VendorIdColumn + "=" + VendorIdParam + ", "
                                     + NameColumn + "=" + NameParam + ", "
                                     + DescriptionColumn + "=" + DescriptionParam + ", "
                                     + UrlColumn + "=" + UrlParam + ", "
                                     + SourceColumn + "=" + SourceParam
                                     + " WHERE " + IdColumn + "=" + IdParam;

    public const string Delete = "DELETE FROM " + TableName + " ";
    public const string DeleteById = "DELETE FROM " + TableName + " WHERE " + IdColumn + "=" + IdParam;

    public const string Select = "SELECT * FROM " + TableName + " ";
    public const string SelectById = "SELECT * FROM " + TableName + " WHERE " + IdColumn + "=" + IdParam;
    
}
