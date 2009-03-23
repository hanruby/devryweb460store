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
/// Used to determine the table a business object class belongs to, as well as other attributes that may apply.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DBTableAttribute : Attribute
{
    private string name;

    public DBTableAttribute(string name)
    {
        this.name = name;

    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}
