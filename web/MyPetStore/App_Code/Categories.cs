using System;
using System.Collections.Generic;
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
/// API for Categories DB Table
/// Jonathan Sourp
/// </summary>
public class Categories : IBase
{
    //attributes
    public string CategoryID { get; set; }

    public string CategoryName { get; set; }

    //behaviors
    #region IBase Members

    public IList<object> Get()
    {
        //dal logic here
        throw new NotImplementedException();
    }

    public bool Add()
    {
        //dal logic here
        throw new NotImplementedException();
    }

    public bool Delete()
    {
        //dal logic here
        throw new NotImplementedException();
    }

    public void Clear()
    {
        CategoryID = null;
        CategoryName = null;
    }

    #endregion

    //constructors            
    public Categories()
    {

    }
    public Categories(string sCatId, string sCatName)
    { 
    
    }

}