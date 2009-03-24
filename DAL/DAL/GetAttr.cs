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
using System.Reflection;
using System.Collections;
using System.Web.UI.MobileControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for GetAttr
/// </summary>
public class GetAttr
{
    public GetAttr()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public void GetTableName(object o)
    {
        Type type = o.GetType();
        DBTableAttribute[] dataTables = (DBTableAttribute[])type.GetCustomAttributes(typeof(DBTableAttribute), true);
    }

    public void GetColumnsAndValues(object o)
    {
        List<object> values = new List<object>();
        List<DBColumnAttribute[]> columnAttributes = new List<DBColumnAttribute[]>();

        PropertyInfo[] properties = o.GetType().GetProperties();

        //loop through the properties of the object
        for (int i = 0; i < properties.Length; i++)
        {

            //add the DBColumnAttributes for each property
            DBColumnAttribute[] attribute = (DBColumnAttribute[])properties[i].GetCustomAttributes(typeof(DBColumnAttribute), true);
            

            //make sure the property has a column attribute
            if (attribute.Length > 0)
            {
                //add the columnAttribute to the List
                columnAttributes.Add(attribute);

                //add the value of the current property to the List
                values.Add(properties[i].GetValue(o, null));
            }
        }


    }
}