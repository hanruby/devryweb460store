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
     //   Category category = new Category(4, "upadted", "updated");
       // CategoryDA categoryDA = new CategoryDA();
       // categoryDA.Save(category);



        Category category1 = new Category(1, "insertedByDal", "insertedByDal");
        Category category2 = new Category(2, "insertedByDal", "insertedByDal");
        Category category3 = new Category(3, "insertedByDal", "insertedByDal");
        Category category4 = new Category(4, "insertedByDal", "insertedByDal");
        Category category5 = new Category(5, "insertedByDal", "insertedByDal");
        Category category6 = new Category(6, "insertedByDal", "insertedByDal");
        Category category7 = new Category(7, "insertedByDal", "insertedByDal");
        Category category8 = new Category(8, "insertedByDal", "insertedByDal");
        

        CategoryDA categoryDA = new CategoryDA();
        categoryDA.Save(category1);
        categoryDA.Save(category2);
        categoryDA.Save(category3);
        categoryDA.Save(category4);
        categoryDA.Save(category5);
        categoryDA.Save(category6);
        categoryDA.Save(category7);
        categoryDA.Save(category8);

        Category category9 = new Category();
        category9.Name = "insertedByDal";


        Customer customer1 = new Customer(99, true, "Zorro", "Zach", "Brown", "Adress", "Address2", "City", "State", "Zip", "Country");
        Customer customer2 = new Customer(2, true, "Zorro", "Zach", "Brown", "Adress", "Address2", "City", "State", "Zip", "Country");

        CustomerDA customerDA = new CustomerDA();
        customerDA.Save(customer1);
        customerDA.Save(customer2);

        Collection<Customer> customers = customerDA.Get(new Customer(){State = "AZ"});


        Collection<Category> categories = categoryDA.Get(category9);

        List<Category> cats = new List<Category>();
        cats.Add(category1);
        cats.Add(category2);
        Repeater1.DataSource = customers;
        Repeater1.DataBind();

        GridView1.DataSource = customers;
        GridView1.DataBind();

    }
}
