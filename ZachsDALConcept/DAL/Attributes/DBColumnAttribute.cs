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
/// Summary description for DBColumnAttribute
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class DBColumnAttribute : Attribute
{
    private string name;
    private int length;

    public DBColumnAttribute(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}
