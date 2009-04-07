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
/// Holds constants used for the Category Database Table
/// </summary>
public static class CategoryTable
{
    //TableName
    public const string TableName = "Categories";

    //Columns
    public const string IdColumn = "CategoryID";
    public const string NameColumn = "CategoryName";
    public const string ImageColumn = "CategoryPhoto";

    //Parameters
    public const string IdParam = "@CategoryID";
    public const string NameParam = "@CategoryName";
    public const string ImageParam = "@CategoryPhoto";

    //SQL Statements
    public const string Insert = "INSERT INTO " + TableName + "("
                                 + IdColumn + ", "
                                 + NameColumn + ", "
                                 + ImageColumn + ")"
                                 
                                 + " Values("
                                 + IdParam + ", "
                                 + NameParam + ", "
                                 + ImageParam + ")";

    
    public const string Update = "UPDATE " + TableName + " SET ";
    public const string UpdateById = "UPDATE " + TableName + " SET "
                                     + IdColumn + "=" + IdParam + ", "
                                     + NameColumn + "=" + NameParam + ", "
                                     + ImageColumn + "=" + ImageParam
                                     + " WHERE " + IdColumn + "=" + IdParam;

 
    public const string Delete = "DELETE FROM " + TableName + " ";
    public const string DeleteById = "DELETE FROM " + TableName + " WHERE " + IdColumn + "=" + IdParam;

    public const string Select = "SELECT * FROM " + TableName + " ";
    public const string SelectById = "SELECT * FROM " + TableName + " WHERE " + IdColumn + "=" + IdParam;
}

