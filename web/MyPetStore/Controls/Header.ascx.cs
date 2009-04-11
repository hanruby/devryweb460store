using System;

using System.Data;
using System.Configuration;
using System.Drawing;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Controls_Header : System.Web.UI.UserControl
{
    private object orderCount;
    private object items;
    private object customerID;
    private object orderID;
    protected void Page_Load(object sender, EventArgs e)
    {



        lblItemsInCart.Text = "0";

        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            // get the customerID of the user who is logged on
            DAL.DataAccess da5 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

            // make command statement 
            string comm5 = "SELECT CustomerID FROM Customer WHERE UserName = @username";
            //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

            DataSet ds5 = new DataSet();


            // make arrays for paramaters and input
            string[] s5 = { "@username" };
            string[] v5 = { Membership.GetUser().UserName };
            ds5 = da5.ExecuteQuery(comm5, s5, v5);


            // returns one item
            customerID = ds5.Tables[0].Rows[0].ItemArray[0];


            //clear
            s5 = null;
            v5 = null;


            // get the current orderID if any if not make shopping cart items 0
            DAL.DataAccess da9 =
              new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                 "System.Data.SqlClient");

            // make command statement 
            string comm9 = "SELECT Count(*) FROM Orders WHERE CustomerID = @customerID AND TxnID = @txnID";


            DataSet ds9 = new DataSet();

            // make arrays for paramaters and input
            string[] s9 = { "@customerID", "@txnID" };
            string[] v9 = { customerID.ToString(), "" };
            ds9 = da9.ExecuteQuery(comm9, s9, v9);

            // returns one item
            orderCount = ds9.Tables[0].Rows[0].ItemArray[0];

            //clear
            s9 = null;
            v9 = null;

            if (int.Parse(orderCount.ToString()) == 0)
            {
                // display answer on label       
                lblItemsInCart.Text = "0";
            }
            else
            {

                // get the orderID of the order that has a txnid = "" of the customer
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




                //count how many items are in the shopping cart for the user
                //and display them 
                //instantiate class
                DAL.DataAccess da8 =
                    new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                       "System.Data.SqlClient");

                // make command statement 
                string comm8 = "SELECT Count(*) FROM OrderItem WHERE OrderID = @orderID";


                DataSet ds8 = new DataSet();

                // make arrays for paramaters and input
                string[] s8 = { "@orderID" };
                string[] v8 = { orderID.ToString() };
                ds8 = da8.ExecuteQuery(comm8, s8, v8);

                // returns one item
                items = ds8.Tables[0].Rows[0].ItemArray[0];

                //clear
                s8 = null;
                v8 = null;

                // display answer on label       
                lblItemsInCart.Text = items.ToString();
            }






        }
        else
        {
            // if the customer is not logged on but has an item in there cart
            if (Session["AnonymousUserName"] != null)
            {


                // get the customerID

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




                // get the current orderID if any if not make shopping cart items 0
                DAL.DataAccess da9 =
                  new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                     "System.Data.SqlClient");

                // make command statement 
                string comm9 = "SELECT Count(*) FROM Orders WHERE CustomerID = @customerID AND TxnID = @txnID";


                DataSet ds9 = new DataSet();

                // make arrays for paramaters and input
                string[] s9 = { "@customerID", "@txnID" };
                string[] v9 = { customerID.ToString(), "" };
                ds9 = da9.ExecuteQuery(comm9, s9, v9);

                // returns one item
                orderCount = ds9.Tables[0].Rows[0].ItemArray[0];

                //clear
                s9 = null;
                v9 = null;

                if (int.Parse(orderCount.ToString()) == 0)
                {
                    // display answer on label       
                    lblItemsInCart.Text = "0";
                }
                else
                {

                    // get the customerID

                    DAL.DataAccess da20 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    // make command statement 
                    string comm20 = "SELECT CustomerID FROM Customer WHERE UserName = @username";
                    //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                    DataSet ds20 = new DataSet();


                    // make arrays for paramaters and input
                    string[] s20 = { "@username" };
                    string[] v20 = { Session["AnonymousUserName"].ToString() };
                    ds20 = da20.ExecuteQuery(comm20, s20, v20);


                    customerID = ds20.Tables[0].Rows[0].ItemArray[0].ToString();



                    //clear
                    s20 = null;
                    v20 = null;

                    // get the orderID of the order with the txnid = "" for the anonyomous user
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



                    //count how many items are in the shopping cart for the anonymous user
                    //and display them 
                    //instantiate class
                    DAL.DataAccess da15 =
                        new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                           "System.Data.SqlClient");

                    // make command statement 
                    string comm15 = "SELECT Count(*) FROM OrderItem WHERE OrderID = @orderID";


                    DataSet ds15 = new DataSet();

                    // make arrays for paramaters and input
                    string[] s15 = { "@orderID" };
                    string[] v15 = { orderID.ToString() };
                    ds15 = da15.ExecuteQuery(comm15, s15, v15);

                    // returns one item
                    items = ds15.Tables[0].Rows[0].ItemArray[0];

                    //clear
                    s15 = null;
                    v15 = null;

                    // display answer on label       
                    lblItemsInCart.Text = items.ToString();
                }
            }

        }

    }


}
