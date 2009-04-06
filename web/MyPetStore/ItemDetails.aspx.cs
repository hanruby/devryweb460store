using System;
using System.Data;
using System.Data.SqlClient;
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
     // for reference
     // adds a new column to the table
     //  tbl.Columns.Add("CustomerID");
     // counts total rows in the table
     //  int intCount = ds.Tables["Orders"].Rows.Count;
     // returns specific column
     // object first = ds.Tables[0].Rows[0]["CustomerID"];
 */
public partial class ItemDetails : System.Web.UI.Page
{
    private Label itemID;
    private Label vendorID;
    private Label IsActive;
    private Label Description;
    private Label QuantityAvailable;
    private Label price;
    private Label photoname;
    private Label photoLocation;
    private Label minQuantity;
    private Label costPrice;
    private Label recommendedPrice;

    private TextBox quantity;

    private Label salePriceAnswer;
    private int salePriceAnswerInt;

    private Label salePrice;


    private object customerID;
    private object orderID;
    private object countOrderID;
    private object orders;

    protected void Page_Load(object sender, EventArgs e)
    {


        // set labels to visible = false and text = ""
        lblSuccessful.Text = "";
        lblError.Text = "";

        // call method to get values from the labels and textboxes
        // on the formview
        GetItems();

       

    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        // try catch for notifying the user when they
        // try to enter an item to their shopping cart
        // that is already in their shopping cart
        try
        {


            // call method to get values from the labels and textboxes
            // on the formview
            GetItems();

            // check to see if user is logged on
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                // get the customerID of the user who is logged on
                DAL.DataAccess da4 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                // make command statement 
                string comm4 = "SELECT CustomerID FROM Customer WHERE UserName = @username";
                //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                DataSet ds4 = new DataSet();


                // make arrays for paramaters and input
                string[] s4 = { "@username" };
                string[] v4 = { User.Identity.Name };
                ds4 = da4.ExecuteQuery(comm4, s4, v4);


                // returns one item
                customerID = ds4.Tables[0].Rows[0].ItemArray[0];


                //clear
                s4 = null;
                v4 = null;




                // count how many orderIDs that have not been verified exist in the orders table
                DAL.DataAccess da5 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                // make command statement 
                string comm5 = "SELECT COUNT(OrderID) FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";
                //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                DataSet ds5 = new DataSet();


                // make arrays for paramaters and input
                string[] s5 = { "@customerID", "@txnID" };
                string[] v5 = { customerID.ToString(), "" };
                ds5 = da5.ExecuteQuery(comm5, s5, v5);


                // returns one item
                countOrderID = ds5.Tables[0].Rows[0].ItemArray[0];


                //clear
                s5 = null;
                v5 = null;

                // if there are no orders with a txnID = "" then add a new order
                // then get the OrderID of the Order to add items to the shopping
                // cart using that OrderID
                // if there are orders with a txnID = "" then select the OrderID
                // and add orders to the shopping cart using that OrderID
                if (int.Parse(countOrderID.ToString()) == 0)
                {
                    // add a new order to the order table
                    // instantiate class
                    DAL.DataAccess da6 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm6 = "INSERT INTO Orders VALUES (@customerID, @grossTotal, @tax, @netTotal, @txnID)";

                    // make arrays for paramaters and input
                    string[] s6 = { "@customerID", "@grossTotal", "@tax", "@netTotal", "@txnID" };
                    string[] v6 = { customerID.ToString(), "0", "0", "0", "" };

                    da6.ExecuteNonQuery(comm6, s6, v6);

                    //clear
                    s6 = null;
                    v6 = null;


                    // get the orderID of the order that was just created
                    DAL.DataAccess da3 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm3 = "SELECT OrderID FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";

                    DataSet ds3 = new DataSet();

                    // make arrays for paramaters and input
                    string[] s3 = { "@customerID", "@txnID" };
                    string[] v3 = { customerID.ToString(), "" };
                    ds3 = da3.ExecuteQuery(comm3, s3, v3);

                    // returns one item
                    orderID = ds3.Tables[0].Rows[0].ItemArray[0];

                    //clear
                    s3 = null;
                    v3 = null;


                    // insert item into the database using the OrderID that was created
                    // instantiate class
                    DAL.DataAccess da2 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm2 = "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price,  @totalPrice, @quantity)";



                    string[] s2 = { "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                    "@quantity" };
                    string[] v2 = { orderID.ToString(), itemID.Text, vendorID.Text, price.Text, price.Text, quantity.Text };

                    da2.ExecuteNonQuery(comm2, s2, v2);

                    // clear
                    s2 = null;
                    v2 = null;


                    // count how many items are in the shopping cart for the user
                    // and display them 
                    // instantiate class
                    //DAL.DataAccess da8 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    //// make command statement 
                    //string comm8 = "SELECT Count(*) FROM OrderItem WHERE CustomerID = @customerID AND TXNID = @txnID";


                    //DataSet ds8 = new DataSet();

                    //// make arrays for paramaters and input
                    //string[] s8 = { "@customerID", "@txnID" };
                    //string[] v8 = { customerID.ToString(), "" };
                    //ds8 = da8.ExecuteQuery(comm8, s8, v8);

                    //// returns one item
                    //orders = ds8.Tables[0].Rows[0].ItemArray[0];

                    ////clear
                    //s3 = null;
                    //v3 = null;

                    //// display answer on label
                    //Label items = (Label)Header.FindControl("lblItemsInCart");
                    //items.Text = orders.ToString();

                    //// tell user the item was added to their cart successfully
                    //lblSuccessful.Visible = true;
                    //lblSuccessful.Text = "Added to shopping cart successfully!";
                }
                else
                {

                    // get the orderID of the user that has a txnID = ""
                    // instantiate class
                    DAL.DataAccess da3 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm3 = "SELECT OrderID FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";
                    //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                    DataSet ds3 = new DataSet();

                    // make arrays for paramaters and input
                    string[] s3 = { "@customerID", "@txnID" };
                    string[] v3 = { customerID.ToString(), "" };
                    ds3 = da3.ExecuteQuery(comm3, s3, v3);

                    // returns one item
                    orderID = ds3.Tables[0].Rows[0].ItemArray[0];

                    //clear
                    s3 = null;
                    v3 = null;



                    // insert item into the database using the existing OrdersID
                    // instantiate class
                    DAL.DataAccess da7 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm7 = "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price, @totalPrice, @quantity)";

                    string[] s7 = { "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                    "@quantity" };
                    string[] v7 = { orderID.ToString(), itemID.Text, vendorID.Text, price.Text, price.Text, quantity.Text };

                    da7.ExecuteNonQuery(comm7, s7, v7);

                    // clear
                    s7 = null;
                    v7 = null;

                  


                    // count how many items are in the shopping cart for the user
                    // get the orderID of the user that has a txnID = ""
                    // instantiate class
                    //DAL.DataAccess da8 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    //// make command statement 
                    //string comm8 = "SELECT Count(*) FROM OrderItem WHERE CustomerID = @customerID AND TXNID = @txnID";
                    

                    //DataSet ds8 = new DataSet();

                    //// make arrays for paramaters and input
                    //string[] s8 = { "@customerID", "@txnID" };
                    //string[] v8 = { customerID.ToString(), "" };
                    //ds8 = da8.ExecuteQuery(comm8, s8, v8);

                    //// returns one item
                    //orders = ds8.Tables[0].Rows[0].ItemArray[0];

                    ////clear
                    //s3 = null;
                    //v3 = null;

                    //// display answer on label
                    //Label items2 = (Label)Header.FindControl("lblItemsInCart");
                    //items2.Text = orders.ToString();

                    // tell user the item was added to their cart successfully
                    lblSuccessful.Visible = true;
                    lblSuccessful.Text = "Added to shopping cart successfully!";
                }

            }
        }
        catch (SqlException ex)
        {
            lblError.Visible = true;
            lblError.Text = "The item is in your shopping cart already.";
        }
    }

    // gets values from for labels and textboxes
    public void GetItems()
    {
        try
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
            quantity = (TextBox)FormView1.FindControl("txtQuantity"); 
            salePriceAnswer = (Label)FormView1.FindControl("lblSalePriceAnswer");
            salePrice = (Label)FormView1.FindControl("lblSalePrice");
            salePriceAnswerInt = int.Parse(salePriceAnswer.Text, System.Globalization.NumberStyles.Integer);

            // makes labels invisible if the item is not on sale
            if (salePriceAnswerInt > 0)
            {
               
                salePriceAnswer.Visible = true;
                salePrice.Visible = true;
            }
            else
            {
               
                salePriceAnswer.Visible = false;
                salePrice.Visible = false;
            }
        
        }
        catch (Exception ex)
        {
            // nothing
        }
    }


}
