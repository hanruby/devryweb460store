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
/*
 * Authors: Daniel Aguayo and Zach
 * 
 */
public partial class ItemDetails : System.Web.UI.Page
{
    Label itemID;
    Label vendorID;
    Label IsActive;
    Label Description;
    Label QuantityAvailable;
    Label price;
    Label photoname ;
    Label photoLocation ;
    Label minQuantity;
    Label costPrice;
    Label recommendedPrice;

    protected void Page_Load(object sender, EventArgs e)
    {

        // code will be used in the future   
        //// instantiate class
        //        DAL.DataAccess da3 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        //        // make command statement 
        //        string comm3 = "select OrderID from Orders WHERE CustomerID = @customerID AND TXNID = @txnID";
        //            //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

        //         DataSet ds = new DataSet(); 




        //        // make arrays for paramaters and input
        //        string[] s3 = { "@customerID", "@txnID" };
        //        string[] v3 = { "1", "" };
        //           ds = da3.ExecuteQuery(comm3, s3, v3);


        //         //we usually use just one table

        //         //  tbl.Columns.Add("CustomerID");

        //         // counts total rows in the table
        //         //  int intCount = ds.Tables["Orders"].Rows.Count;

        //        // returns specific column
        //        // object first = ds.Tables[0].Rows[0]["CustomerID"];

        //        // returns one item
        //        object first = ds.Tables[0].Rows[0].ItemArray[0];

        //         Response.Write("" + first.ToString());

        // //clear
        //        s3 = null;
        //        v3 = null;
      
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        //// instantiate class
        //DAL.DataAccess dataAccess = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        //// make command statement 
        //string comm = "Insert Into OrderItem VALUES (@orderID, @itemID, @vendorID, @price, @quantity)";

        //// call method to get values from for labels and textboxes
        //GetItems();

        //string[] s1 = { "@orderID", "@itemid", "@vendorid", "@price",
        //    "@quantity" };
        //string[] v1 = { "235", itemID.Text, vendorID.Text, Convert.ToDouble(price.Text).ToString(), "1" };

        //dataAccess.ExecuteNonQuery(comm, s1, v1);

        //// clear
        //s1 = null;
        //v1 = null;


        // instantiate class
        DAL.DataAccess dataAccess2 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        // make command statement 
        string comm2 = "INSERT INTO Orders (CustomerID, GrossTotal, Tax, NetTotal, TXNID) VALUES(@customerID, @grossTotal, @tax, @netTotal, @txnID)";

        string[] s2 = {"@customerID", "@grossTotal", "@tax", "@netTotal", "@txnID" };
        string[] v2 = {"1", "0.00", "0.00", "0.00", "" };

        dataAccess2.ExecuteNonQuery(comm2, s2, v2);

        //clear
        s2 = null;
        v2 = null;


        //// instantiate class
        //DAL.DataAccess dataAccess3 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        //// make command statement 
        //string comm3 = "SELECT GrossTotal FROM Orders WHERE CustomerID = @customerID)";

        //// make arrays for paramaters and input
        //string[] s3 = { "@customerID" };
        //string[] v3 = { "1" };

        //dataAccess3.ExecuteQuery(comm3, s3, v3);

        ////clear
        //s3 = null;
        //v3 = null;



    }

    // gets values from for labels and textboxes
    public void GetItems()
    {
         itemID = (Label)FormView1.FindControl("lblItemID");
         vendorID = (Label)FormView1.FindControl("lblVendorID");
         IsActive = (Label)FormView1.FindControl("lblIsActive");
         Description = (Label)FormView1.FindControl("lblDescription");
         QuantityAvailable = (Label)FormView1.FindControl("lblQuantityAvailable");
         price = (Label)FormView1.FindControl("lblPrice");
         photoname = (Label)FormView1.FindControl("lblPhotoName");
         photoLocation = (Label)FormView1.FindControl("lblPhotoLocation");
         minQuantity = (Label)FormView1.FindControl("lblMinQuantity");
         costPrice = (Label)FormView1.FindControl("lblCostPrice");
         recommendedPrice = (Label)FormView1.FindControl("lblRecommendedPrice");
    }
}
