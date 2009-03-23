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
/// Summary description for Category
/// </summary>
public class Category
{
    private int id;
    private string name;

	public Category()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    [DBColumn("CategoryID")]
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    [DBColumn("CategoryName")]
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
