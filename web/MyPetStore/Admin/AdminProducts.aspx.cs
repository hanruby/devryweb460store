using System;
using DataAccessModule;

public partial class Admin_AdminProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["itemid"] != null && Request.Params["vendorid"] != null && !IsPostBack )
        { 
        //they passed in a product ID and a vendorid I can continue
            Item myItem = new Item();
            myItem.Id = Request.Params["itemid"];
            myItem.VendorId = int.Parse(Request.Params["vendorid"]);

            ItemDA myIDA = new ItemDA();
            txtID.Text = myIDA.Get(myItem)[0].Id;
            txtPrice.Text = myIDA.Get(myItem)[0].Price.ToString(); 

            //myIDA.dispose();
            //myItem.dispose();
            myIDA = null;
            myItem = null;

        }
    }

    protected void cmdSave_Click(object sender, EventArgs e)
    {
        Item myItem = new Item();
        myItem.Id = Request.Params["itemid"];
        myItem.VendorId = int.Parse(Request.Params["vendorid"]);
        myItem.Price = decimal.Parse(txtPrice.Text);

        ItemDA myIDA = new ItemDA();
        myIDA.Save(myItem);

    }
}
