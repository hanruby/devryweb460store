using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/**
 * Author: Daniel Aguayo
 * 
 */
public partial class ShoppingCart : System.Web.UI.Page
{


    // attributes
    public bool isEditMode = false;







    protected void Page_Load(object sender, EventArgs e)
    {
        // fill up the gridview with customer's order info
        BindGridView();

        // fill up the repeater with cusotmer's order info
        BindRepeater();
          
        
    }

    // button to go to Edit Mode
    protected void btnEditQuantity_Click(object sender, EventArgs e)
    {
        // set edit mode to true and call BindData
        isEditMode = true;
        BindGridView();
    }


    private void BindGridView()
    {
        // instantiate class
        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        // sql command
        
        string comm = "SELECT Orders.OrderID, Orders.CustomerID, Orders.GrossTotal, Orders.Tax, Orders.NetTotal, OrderItem.OrderID, OrderItem.ItemID, OrderItem.Price, OrderItem.Quantity FROM OrderItem INNER JOIN Orders ON Orders.OrderID = OrderItem.OrderID WHERE Orders.CustomerID = @customerID AND Orders.Verified = @verified";

        // data set
        DataSet ds = new DataSet();

        // empty array
        string[] p = { "@customerID", "@verified" };
        string[] v = { "1", "False"};

        ds = da.ExecuteQuery(comm, p, v);

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

        // clear
        p = null;
        v = null;
    }

    public void BindRepeater()
    {
        // instantiate class
        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        // sql command

        string comm = "SELECT Orders.OrderID, Orders.CustomerID, Orders.GrossTotal, Orders.Tax, Orders.NetTotal, OrderItem.OrderID FROM OrderItem INNER JOIN Orders ON Orders.OrderID = OrderItem.OrderID WHERE Orders.CustomerID = @customerID AND Orders.Verified = @verified";

        // data set
        DataSet ds = new DataSet();

        // empty array
        string[] p = { "@customerID", "@verified" };
        string[] v = { "1", "False" };

        ds = da.ExecuteQuery(comm, p, v);

        rptOne.DataSource = ds.Tables[0];
        rptOne.DataBind();

        // clear
        p = null;
        v = null;
      
    }


    // properties for IsEditMode
    protected bool IsInEditMode
    {

        get { return this.isEditMode; }

        set { this.isEditMode = value; }

    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        Response.Redirect("#");
    }
}
