﻿using System;
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
/// API for ItemCategories DB Table
/// </summary>
public class ItemCategories : IBase
{
    //attributes
    public string ItemID { get; set; }

    public string VendorID { get; set; }

    public string CategoryID { get; set; }

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
        //dal logic here
        throw new NotImplementedException();
    }

    #endregion

    //constructors            
    public ItemCategories()
    {

    }
}