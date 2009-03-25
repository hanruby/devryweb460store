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

public partial class ItemDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        //// initiate class
        //DAL.DataAccess dataAccess = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");


        //// make command statement 
        //string comm = "Insert Into OrderItem VALUES (@orderID, @itemID, @vendorID, @price, @quantity)";


        //// get values from form labels 

        //Label itemID = (Label)FormView1.FindControl("lblItemID");

        //Label vendorID = (Label)FormView1.FindControl("lblVendorID");

        //Label IsActive = (Label)FormView1.FindControl("lblIsActive");
        //Label Description = (Label)FormView1.FindControl("lblDescription");
        //Label QuantityAvailable = (Label)FormView1.FindControl("lblQuantityAvailable");
        //Label price = (Label)FormView1.FindControl("lblPrice");
        //Label photoname = (Label)FormView1.FindControl("lblPhotoName");
        //Label photoLocation = (Label)FormView1.FindControl("lblPhotoLocation");
        //Label minQuantity = (Label)FormView1.FindControl("lblMinQuantity");
        //Label costPrice = (Label)FormView1.FindControl("lblCostPrice");
        //Label recommendedPrice = (Label)FormView1.FindControl("lblRecommendedPrice");


        //string[] s1 = { "@orderID", "@itemid", "@vendorid", "@price",
        //    "@quantity" };

       

        //string[] v1 = { "25", itemID.Text, vendorID.Text, price.ToString(), "1" };

        //dataAccess.ExecuteNonQuery(comm, s1, v1);


        //s1 = null;
        //v1 = null;


        // initiate class
        DAL.DataAccess dataAccess2 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");


        // make command statement 
        string comm2 = "INSERT INTO Orders VALUES(@orderID, @customerID, @grossTotal, @tax, @netTotal)";


        // get values from form labels and textboxes
        Label itemID2 = (Label)FormView1.FindControl("lblItemID");

        Label vendorID2 = (Label)FormView1.FindControl("lblVendorID");

        Label IsActive2 = (Label)FormView1.FindControl("lblIsActive");
        Label Description2 = (Label)FormView1.FindControl("lblDescription");
        Label QuantityAvailable2 = (Label)FormView1.FindControl("lblQuantityAvailable");
        Label price2 = (Label)FormView1.FindControl("lblPrice");
        Label photoname2 = (Label)FormView1.FindControl("lblPhotoName");
        Label photoLocation2 = (Label)FormView1.FindControl("lblPhotoLocation");
        Label minQuantity2 = (Label)FormView1.FindControl("lblMinQuantity");
        Label costPrice2 = (Label)FormView1.FindControl("lblCostPrice");
        Label recommendedPrice2 = (Label)FormView1.FindControl("lblRecommendedPrice");


        string[] s2 = { "@orderID", "@customerID", "@grossTotal", "@tax", "@netTotal" };



        string[] v2 = { "235", "1", "1", "2", "2" };

        dataAccess2.ExecuteNonQuery(comm2, s2, v2);


        s2 = null;
        v2 = null;
    }
}
