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

    // price2 is label price
    // price is the amount that actually gets 
    // inserted into the database
    private Label price2;
    private double price;
    private Label photoname;
    private Label photoLocation;
    private Label minQuantity;
    private Label costPrice;
    private Label recommendedPrice;

    private TextBox quantity;

    private Label salePriceAnswer;
    private double salePriceAnswerDouble;

    private Label salePrice;


    private object customerID;
    private object orderID;
    private object countOrderID;
    private object orders;
    private int usernameID;
    private object max;
    private string anonymousUserName;
    //  private int anonymousCustomerID;

    protected void Page_Load(object sender, EventArgs e)
    {


        // set labels to visible = false and text = ""
        lblSuccessful.Text = "";
        lblError.Text = "";


        // method that gets items in controls and
        // checks weather the sales price label is invisible or not
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
                    DAL.DataAccess da6 =
                        new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                           "System.Data.SqlClient");

                    // make command statement 
                    string comm6 = "INSERT INTO Orders VALUES (@customerID, @grossTotal, @tax, @netTotal, @txnID, @paymentStatus)";

                    // make arrays for paramaters and input
                    string[] s6 = { "@customerID", "@grossTotal", "@tax", "@netTotal", "@txnID", "@paymentStatus" };
                    string[] v6 = { customerID.ToString(), "0", "0", "0", "", "" };

                    da6.ExecuteNonQuery(comm6, s6, v6);

                    //clear
                    s6 = null;
                    v6 = null;


                    // get the orderID of the order that was just created
                    DAL.DataAccess da3 =
                        new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                           "System.Data.SqlClient");

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

                    // see if item is on sale
                    if (isItemOnSale() == true)
                    {
                        // insert item into the database using the OrderID that was created
                        // instantiate class
                        DAL.DataAccess da2 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                        // make command statement 
                        string comm2 = "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price,  @totalPrice, @quantity)";



                        string[] s2 = { "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                    "@quantity" };
                        string[] v2 = { orderID.ToString(), itemID.Text, vendorID.Text, salePriceAnswerDouble.ToString(), salePriceAnswerDouble.ToString(), quantity.Text };

                        da2.ExecuteNonQuery(comm2, s2, v2);

                        // clear
                        s2 = null;
                        v2 = null;



                        //// tell user the item was added to their cart successfully
                        lblSuccessful.Visible = true;
                        lblSuccessful.Text = "Added to shopping cart successfully!";
                    }
                    else
                    {
                        // insert item into the database using the OrderID that was created
                        // instantiate class
                        DAL.DataAccess da2 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                        // make command statement 
                        string comm2 = "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price,  @totalPrice, @quantity)";



                        string[] s2 = { "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                    "@quantity" };
                        string[] v2 = { orderID.ToString(), itemID.Text, vendorID.Text, price.ToString("n2"), price.ToString("n2"), quantity.Text };

                        da2.ExecuteNonQuery(comm2, s2, v2);

                        // clear
                        s2 = null;
                        v2 = null;



                        //// tell user the item was added to their cart successfully
                        lblSuccessful.Visible = true;
                        lblSuccessful.Text = "Added to shopping cart successfully!";

                        // refresh page
                        // Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                        Response.Redirect(Request.RawUrl);
                    }


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

                    // see if item is on sale
                    if (isItemOnSale() == true)
                    {
                        // insert item into the database using the existing OrdersID
                        // instantiate class
                        DAL.DataAccess da7 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                        // make command statement 
                        string comm7 = "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price, @totalPrice, @quantity)";

                        string[] s7 = { "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                    "@quantity" };
                        string[] v7 = { orderID.ToString(), itemID.Text, vendorID.Text, salePriceAnswerDouble.ToString(), salePriceAnswerDouble.ToString(), quantity.Text };

                        da7.ExecuteNonQuery(comm7, s7, v7);

                        // clear
                        s7 = null;
                        v7 = null;

                        // tell user the item was added to their cart successfully
                        lblSuccessful.Visible = true;
                        lblSuccessful.Text = "Added to shopping cart successfully!";

                        // refresh page
                        Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                    }
                    else
                    {
                        // insert item into the database using the existing OrdersID
                        // instantiate class
                        DAL.DataAccess da7 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                        // make command statement 
                        string comm7 = "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price, @totalPrice, @quantity)";

                        string[] s7 = { "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                    "@quantity" };
                        string[] v7 = { orderID.ToString(), itemID.Text, vendorID.Text, price.ToString("n2"), price.ToString("n2"), quantity.Text };

                        da7.ExecuteNonQuery(comm7, s7, v7);

                        // clear
                        s7 = null;
                        v7 = null;

                        // tell user the item was added to their cart successfully
                        lblSuccessful.Visible = true;
                        lblSuccessful.Text = "Added to shopping cart successfully!";

                        // refresh page
                        Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);

                    }









                }

            }
            // if user is not logged on make up and account
            else
            {
                // if the anonymous session anonymouscustomerID is empty
                // create a new username and customerID
                if (Session["AnonymousUserName"] == null)
                {


                    // get the max customerID that exists
                    DAL.DataAccess da4 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm4 = "SELECT Max(CustomerID) FROM Customer";
                    //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                    DataSet ds4 = new DataSet();


                    // make arrays for paramaters and input
                    string[] s4 = { "" };
                    string[] v4 = { "" };
                    ds4 = da4.ExecuteQuery(comm4, s4, v4);


                    // gets max customerID in table 
                    // adds one and combines websites domain name
                    // with the anonymousID


                    max = ds4.Tables[0].Rows[0].ItemArray[0];

                    usernameID = int.Parse(max.ToString()) + 1;

                    anonymousUserName = "mypetsfw.com" + usernameID;

                    //clear
                    s4 = null;
                    v4 = null;





                    // insert the anonymousCustomerID into the customer table with the username of
                    // mypetsfw.com + customerID
                    DAL.DataAccess da10 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    // make command statement 
                    string comm10 = "INSERT INTO Customer VALUES (@isActive, @userName, @fName, @lName, @address, @address2, @city, @state, @zip, @country)";

                    string[] s10 = { "@isActive", "@userName", "@fName", "@lName", "@address", "@address2", "@city", "@state", "@zip", "@country" };


                    string[] v10 = { "True", anonymousUserName, "Anonymous", "Anonymous", "Anonymous", "Anonymous", "Anonymous", "", "", "Anonymous" };

                    DataSet ds10 = new DataSet();

                    ds10 = da10.ExecuteQuery(comm10, s10, v10);


                    //clear
                    s10 = null;
                    v10 = null;




                    // put the anonymousCustomerID in a session
                    Session["AnonymousUserName"] = anonymousUserName.ToString();


                    // get the id of the user that I just created and put it
                    // into the session
                    DAL.DataAccess da19 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm19 = "SELECT CustomerID FROM Customer WHERE UserName = @username";
                    //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                    DataSet ds19 = new DataSet();


                    // make arrays for paramaters and input
                    string[] s19 = { "@username" };
                    string[] v19 = { Session["AnonymousUserName"].ToString() };
                    ds19 = da19.ExecuteQuery(comm19, s19, v19);


                    customerID = ds19.Tables[0].Rows[0].ItemArray[0];



                    //clear
                    s19 = null;
                    v19 = null;




                    // create a new order of the anonymous user
                    // add a new order to the order table
                    // instantiate class
                    DAL.DataAccess da11 =
                        new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                           "System.Data.SqlClient");

                    // make command statement 
                    string comm11 = "INSERT INTO Orders VALUES (@customerID, @grossTotal, @tax, @netTotal, @txnID,  @paymentStatus)";

                    // make arrays for paramaters and input
                    string[] s11 = { "@customerID", "@grossTotal", "@tax", "@netTotal", "@txnID", "@paymentStatus" };
                    string[] v11 = { customerID.ToString(), "0", "0", "0", "", "" };

                    da11.ExecuteNonQuery(comm11, s11, v11);

                    //clear
                    s11 = null;
                    v11 = null;


                    // get the orderID of the anonymoususer 
                    // instantiate class
                    DAL.DataAccess da13 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm13 = "SELECT OrderID FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";
                    //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                    DataSet ds13 = new DataSet();

                    // make arrays for paramaters and input
                    string[] s13 = { "@customerID", "@txnID" };
                    string[] v13 = { customerID.ToString(), "" };
                    ds13 = da13.ExecuteQuery(comm13, s13, v13);

                    // returns one item
                    orderID = ds13.Tables[0].Rows[0].ItemArray[0];

                    //clear
                    s13 = null;
                    v13 = null;



                    // see if item is on sale
                    if (isItemOnSale() == true)
                    {
                        // insert item into the database using the OrderID that was created
                        // instantiate class
                        DAL.DataAccess da17 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        // make command statement 
                        string comm17 =
                            "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price,  @totalPrice, @quantity)";


                        string[] s17 = {
                                       "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                                       "@quantity"
                                   };
                        string[] v17 = {
                                       orderID.ToString(), itemID.Text, vendorID.Text, salePriceAnswerDouble.ToString(), salePriceAnswerDouble.ToString(),
                                       quantity.Text
                                   };

                        da17.ExecuteNonQuery(comm17, s17, v17);

                        // clear
                        s17 = null;
                        v17 = null;

                        // tell anonymous the item was added to their cart successfully
                        lblSuccessful.Visible = true;
                        lblSuccessful.Text = "Added to shopping cart successfully!";

                        // refresh page
                        Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                    }
                    else
                    {
                        // insert item into the database using the OrderID that was created
                        // instantiate class
                        DAL.DataAccess da17 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        // make command statement 
                        string comm17 =
                            "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price,  @totalPrice, @quantity)";


                        string[] s17 = {
                                       "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                                       "@quantity"
                                   };
                        string[] v17 = {
                                       orderID.ToString(), itemID.Text, vendorID.Text, price.ToString(),price.ToString(),
                                       quantity.Text
                                   };

                        da17.ExecuteNonQuery(comm17, s17, v17);

                        // clear
                        s17 = null;
                        v17 = null;

                        // tell anonymous the item was added to their cart successfully
                        lblSuccessful.Visible = true;
                        lblSuccessful.Text = "Added to shopping cart successfully!";

                        // refresh page
                        Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                    }






                }
                // if the session doesn't == null
                else
                {
                    // get the customerID of the user that I just created 
                    DAL.DataAccess da19 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm19 = "SELECT CustomerID FROM Customer WHERE UserName = @username";
                    //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                    DataSet ds19 = new DataSet();


                    // make arrays for paramaters and input
                    string[] s19 = { "@username" };
                    string[] v19 = { Session["AnonymousUserName"].ToString() };
                    ds19 = da19.ExecuteQuery(comm19, s19, v19);


                    customerID = ds19.Tables[0].Rows[0].ItemArray[0];



                    //clear
                    s19 = null;
                    v19 = null;




                    // see if an order doesn't already exist for the anonymousUser

                    // count how many orderIDs that have not been verified exist in the orders table
                    DAL.DataAccess da12 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm12 = "SELECT COUNT(OrderID) FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";
                    //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                    DataSet ds12 = new DataSet();


                    // make arrays for paramaters and input
                    string[] s12 = { "@customerID", "@txnID" };
                    string[] v12 = { customerID.ToString(), "" };
                    ds12 = da12.ExecuteQuery(comm12, s12, v12);


                    // returns one item
                    countOrderID = ds12.Tables[0].Rows[0].ItemArray[0];


                    //clear
                    s12 = null;
                    v12 = null;

                    // if there are no orders with a txnID = "" then add a new order
                    // then get the OrderID of the Order to add items to the shopping
                    // cart using that OrderID
                    // if there are orders with a txnID = "" then select the OrderID
                    // and add orders to the shopping cart using that OrderID
                    if (int.Parse(countOrderID.ToString()) == 0)
                    {

                        // get the customerID of the user that I just created 
                        DAL.DataAccess da20 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                        // make command statement 
                        string comm20 = "SELECT CustomerID FROM Customer WHERE UserName = @username";
                        //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                        DataSet ds20 = new DataSet();


                        // make arrays for paramaters and input
                        string[] s20 = { "@username" };
                        string[] v20 = { Session["AnonymousUserName"].ToString() };
                        ds20 = da20.ExecuteQuery(comm20, s20, v20);


                        customerID = ds20.Tables[0].Rows[0].ItemArray[0];



                        //clear
                        s20 = null;
                        v20 = null;




                        // create a new order of the anonymous user
                        // add a new order to the order table
                        // instantiate class
                        DAL.DataAccess da11 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        // make command statement 
                        string comm11 = "INSERT INTO Orders VALUES (@customerID, @grossTotal, @tax, @netTotal, @txnID, @paymentStatus)";

                        // make arrays for paramaters and input
                        string[] s11 = { "@customerID", "@grossTotal", "@tax", "@netTotal", "@txnID", "@paymentStatus" };
                        string[] v11 = { customerID.ToString(), "0", "0", "0", "", "" };

                        da11.ExecuteNonQuery(comm11, s11, v11);

                        //clear
                        s11 = null;
                        v11 = null;




                        // get the orderid for the anonymous users new order

                        // instantiate class
                        DAL.DataAccess da13 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                        // make command statement 
                        string comm13 = "SELECT OrderID FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";
                        //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                        DataSet ds13 = new DataSet();

                        // make arrays for paramaters and input
                        string[] s13 = { "@customerID", "@txnID" };
                        string[] v13 = { customerID.ToString(), "" };
                        ds13 = da13.ExecuteQuery(comm13, s13, v13);

                        // returns one item
                        orderID = ds13.Tables[0].Rows[0].ItemArray[0];

                        //clear
                        s13 = null;
                        v13 = null;


                        // see if item is on sale
                        if (isItemOnSale() == true)
                        {
                            // insert item into the database using the OrderID that was created
                            // instantiate class
                            DAL.DataAccess da17 =
                                new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                                   "System.Data.SqlClient");

                            // make command statement 
                            string comm17 =
                                "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price,  @totalPrice, @quantity)";


                            string[] s17 = {
                                       "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                                       "@quantity"
                                   };
                            string[] v17 = {
                                       orderID.ToString(), itemID.Text, vendorID.Text, salePriceAnswerDouble.ToString(), salePriceAnswerDouble.ToString(),
                                       quantity.Text
                                   };

                            da17.ExecuteNonQuery(comm17, s17, v17);

                            // clear
                            s17 = null;
                            v17 = null;

                            // tell user the item was added to their cart successfully
                            lblSuccessful.Visible = true;
                            lblSuccessful.Text = "Added to shopping cart successfully!";

                            // refresh page
                            Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                        }
                        else
                        {
                            // insert item into the database using the OrderID that was created
                            // instantiate class
                            DAL.DataAccess da17 =
                                new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                                   "System.Data.SqlClient");

                            // make command statement 
                            string comm17 =
                                "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price,  @totalPrice, @quantity)";


                            string[] s17 = {
                                       "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                                       "@quantity"
                                   };
                            string[] v17 = {
                                       orderID.ToString(), itemID.Text, vendorID.Text, price.ToString(), price.ToString(),
                                       quantity.Text
                                   };

                            da17.ExecuteNonQuery(comm17, s17, v17);

                            // clear
                            s17 = null;
                            v17 = null;

                            // tell user the item was added to their cart successfully
                            lblSuccessful.Visible = true;
                            lblSuccessful.Text = "Added to shopping cart successfully!";

                            // refresh page
                            Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                        }

                    }
                    // if an order is open and exists for the anonymous user
                    else
                    {


                        // get the customerID of the user that I just created 
                        DAL.DataAccess da20 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                        // make command statement 
                        string comm20 = "SELECT CustomerID FROM Customer WHERE UserName = @username";
                        //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                        DataSet ds20 = new DataSet();


                        // make arrays for paramaters and input
                        string[] s20 = { "@username" };
                        string[] v20 = { Session["AnonymousUserName"].ToString() };
                        ds20 = da20.ExecuteQuery(comm20, s20, v20);


                        customerID = ds20.Tables[0].Rows[0].ItemArray[0];



                        //clear
                        s20 = null;
                        v20 = null;



                        // get the orderID of the anonymoususer that has a txnID = ""
                        // instantiate class
                        DAL.DataAccess da13 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                        // make command statement 
                        string comm13 = "SELECT OrderID FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";
                        //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                        DataSet ds13 = new DataSet();

                        // make arrays for paramaters and input
                        string[] s13 = { "@customerID", "@txnID" };
                        string[] v13 = { customerID.ToString(), "" };
                        ds13 = da13.ExecuteQuery(comm13, s13, v13);

                        // returns one item
                        orderID = ds13.Tables[0].Rows[0].ItemArray[0];

                        //clear
                        s13 = null;
                        v13 = null;

                        // see if item is on sale
                        if (isItemOnSale() == true)
                        {
                            // insert item into the database using the existing OrdersID
                            // instantiate class
                            DAL.DataAccess da14 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                            // make command statement 
                            string comm14 = "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price, @totalPrice, @quantity)";

                            string[] s14 = { "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                    "@quantity" };
                            string[] v14 = { orderID.ToString(), itemID.Text, vendorID.Text, salePriceAnswerDouble.ToString(), salePriceAnswerDouble.ToString(), quantity.Text };

                            da14.ExecuteNonQuery(comm14, s14, v14);

                            // clear
                            s14 = null;
                            v14 = null;

                            // tell user the item was added to their cart successfully
                            lblSuccessful.Visible = true;
                            lblSuccessful.Text = "Added to shopping cart successfully!";

                            // refresh page
                            Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                        }
                        else
                        {
                            // insert item into the database using the existing OrdersID
                            // instantiate class
                            DAL.DataAccess da14 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                            // make command statement 
                            string comm14 = "INSERT INTO OrderItem VALUES (@orderID, @itemID, @vendorID, @price, @totalPrice, @quantity)";

                            string[] s14 = { "@orderID", "@itemID", "@vendorID", "@price", "@totalPrice",
                    "@quantity" };
                            string[] v14 = { orderID.ToString(), itemID.Text, vendorID.Text, price.ToString(), price.ToString(), quantity.Text };

                            da14.ExecuteNonQuery(comm14, s14, v14);

                            // clear
                            s14 = null;
                            v14 = null;

                            // tell user the item was added to their cart successfully
                            lblSuccessful.Visible = true;
                            lblSuccessful.Text = "Added to shopping cart successfully!";

                            // refresh page
                            Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                        }


                    }
                }

            }
        }
        catch (SqlException)
        {
            lblError.Visible = true;
            lblError.Text = "The item is in your shopping cart already.";

        }
    }

    // gets values from for labels and textboxes
    private void GetItems()
    {
        try
        {
            itemID = (Label)FormView1.FindControl("lblItemID");
            vendorID = (Label)FormView1.FindControl("lblVendorID");
            IsActive = (Label)FormView1.FindControl("lblIsActive");
            Description = (Label)FormView1.FindControl("lblDescription");
            QuantityAvailable = (Label)FormView1.FindControl("lblQuantityAvailable");
            price2 = (Label)FormView1.FindControl("lblPrice");
            photoname = (Label)FormView1.FindControl("lblPhotoName");
            photoLocation = (Label)FormView1.FindControl("lblPhotoLocation");
            minQuantity = (Label)FormView1.FindControl("lblMinQuantity");
            costPrice = (Label)FormView1.FindControl("lblCostPrice");
            recommendedPrice = (Label)FormView1.FindControl("lblRecommendedPrice");
            quantity = (TextBox)FormView1.FindControl("txtQuantity");


            price = double.Parse(price2.Text, System.Globalization.NumberStyles.Currency);

            salePriceAnswer = (Label)FormView1.FindControl("lblSalePriceAnswer");
            salePrice = (Label)FormView1.FindControl("lblSalePrice");
            salePriceAnswerDouble = double.Parse(salePriceAnswer.Text, System.Globalization.NumberStyles.Currency);

            // makes labels invisible if the item is not on sale
            if (salePriceAnswerDouble > 0)
            {

                salePriceAnswer.Visible = true;
                salePrice.Visible = true;


            }
            else
            {
                salePrice.Visible = false;

                salePriceAnswer.Visible = false;
            }


        }
        catch (FormatException)
        {
            salePrice.Visible = false;
            salePriceAnswer.Visible = false;



        }
        catch (Exception)
        {
            // nothing

        }
    }

    // check to see if item is on sale
    private bool isItemOnSale()
    {

        GetItems();


        // get the customerID of the user who is logged on
        DAL.DataAccess da4 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        // make command statement 
        string comm4 = "SELECT DiscountedPrice FROM Items WHERE ItemID = @itemid";
        //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

        DataSet ds4 = new DataSet();


        // make arrays for paramaters and input
        string[] s4 = { "@itemID" };
        string[] v4 = { itemID.Text };
        ds4 = da4.ExecuteQuery(comm4, s4, v4);


        // returns one item
        object item = ds4.Tables[0].Rows[0].ItemArray[0];

        //clear
        s4 = null;
        v4 = null;

        // if the items discounted price
        // is blank the item is not discounted
        if (item.ToString() == "")
        {
            return false;
        }

        return true;
    }


}
