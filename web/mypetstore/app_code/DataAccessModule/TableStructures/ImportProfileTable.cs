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
/// Holds constants used for the ImportProfile Database Table
/// </summary>
public static class ImportProfileTable
{
    //Table Name
    public const string TableName = "ImportProfile";

    //Columns
    public const string IdColumn = "ImportID";
    public const string VendorIdColumn = "VendorID";
    public const string FtpServerColumn = "FTPServer";
    public const string FtpUsernameColumn = "FTPUserID";
    public const string FtpPasswordColumn = "FTPUserPassword";
    public const string FtpPathColumn = "FTPPath";
    public const string FilenameColumn = "FileName";
    public const string DelimiterColumn = "Delimiter";

    //Parameters
    public const string IdParam = "@ImportID";
    public const string VendorIdParam = "@VendorID";
    public const string FtpServerParam = "@FTPServer";
    public const string FtpUsernameParam = "@FTPUserID";
    public const string FtpPasswordParam = "@FTPUserPassword";
    public const string FtpPathParam = "@FTPPath";
    public const string FilenameParam = "@FileName";
    public const string DelimiterParam = "@Delimiter";
}
