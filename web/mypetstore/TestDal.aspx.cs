using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccessModule;

public partial class TestDal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var category1  = new Category(1, "name", "image");
        var category2 = new Category(2, "name", "image");
        var category3 = new Category(3, "name", "image");
        var category4 = new Category(4, "name", "image");
        var category5 = new Category(5, "name", "image");
        var category6 = new Category(6, "name", "image");
        var category7 = new Category(7, "name", "image");

        //var categories = new Collection<Category>();
        

        CategoryDA categoryDA = new CategoryDA();

        categoryDA.Save(category1);
        categoryDA.Save(category2);
        categoryDA.Save(category3);
        categoryDA.Save(category4);
        categoryDA.Save(category5);
        categoryDA.Save(category6);
        categoryDA.Save(category7);

        
        
        Category category8 = new Category();
        category8.Name = "name";
        Collection<Category> categories = categoryDA.Get(category8);

        Repeater1.DataSource = categories;
        Repeater1.DataBind();

        GridView1.DataSource = categories;
        GridView1.DataBind();
    }
}
