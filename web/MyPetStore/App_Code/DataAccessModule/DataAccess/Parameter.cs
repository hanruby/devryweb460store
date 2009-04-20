using System;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Parameter
/// </summary>
public class DatabaseParameter
{
    private string tableName;
    private DbParameter parameter;

    public DatabaseParameter()
	{
	}

    public DatabaseParameter(string tableName, DbParameter parameter)
    {
        this.tableName = tableName;
        Parameter = parameter;
    }

    public string TableName
    {
        get { return tableName; }
        set { tableName = value; }
    }

    public DbParameter Parameter
    {
        get { return parameter; }
        set { parameter = value; }
    }
}
