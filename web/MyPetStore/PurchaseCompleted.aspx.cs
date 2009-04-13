using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net;
using System.Data.SqlClient;
/*
 * Author: Daniel
 * 
 */
public partial class PurchaseCompleted : System.Web.UI.Page
{
    // attributes for paypal
    private string item_name;
    private string item_number;
    private string quantity;
    private string item_code;
    private string payment_status;
    private string payment_amount;         //full amount of payment. payment_gross in US
    private string payment_currency;
    private string txn_id;                   //unique transaction id
    private string receiver_email;    // our email
    private string payer_email;
    private double mc_fee;
    private string tax_cart;

    private string amount;
    private string orderID; // orderID of payment that goes in custom

    private string parent_txn_id; // original txnID used for canceled orders etc

    private object txnID;

    protected void Page_Load(object sender, EventArgs e)
    {

        //Post back to either sandbox or live
        string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
        string strLive = "https://www.paypal.com/cgi-bin/webscr";
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strSandbox);

        //Set values for the request back
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
        string strRequest = Encoding.ASCII.GetString(param);
        strRequest += "&cmd=_notify-validate";
        req.ContentLength = strRequest.Length;

        //for proxy
        //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
        //req.Proxy = proxy;

        //Send the request to PayPal and get the response
        StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
        streamOut.Write(strRequest);
        streamOut.Close();
        StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
        string strResponse = streamIn.ReadToEnd();
        streamIn.Close();

        if (strResponse == "VERIFIED")
        {
            //check the payment_status is Completed
            //check that txn_id has not been previously processed
            //check that receiver_email is your Primary PayPal email
            //check that payment_amount/payment_currency are correct
            //process payment





            payment_status = Request.Form["payment_status"];
            //  payment_amount = double.Parse(Request.Form["mc_gross"]).ToString("n2");       //full amount of payment before transaction fee is subtracted
            //  mc_fee = double.Parse(Request.Form["mc_fee"]); // transaction fee
            //  payment_currency = Request.Form["mc_currency"];
            txn_id = Request.Form["txn_id"];                   //unique transaction id
            receiver_email = Request.Form["receiver_email"];
            //  payer_email = Request.Form["payer_email"];
            //  tax_cart = Request.Form["tax"]; // tax for the whole entire cart
            parent_txn_id = Request.Form["parent_txn_id"]; // original transaction ID


            // custom info that we send,
            // user cannot see it 
            // used to run loop for as many items as there is
            orderID = Request.Form["custom"];



            // check database what price of item is 
            // and compare it to price paid
            //string amountThatWasPaid = item_name;

            // if payment status is Completed put order in database
            // we got the money in our bank!

            if (receiver_email == "akagon_1236919720_biz@yahoo.com") // make sure the receiver email is ours
            {



                // count how many orderIDs that have not been verified exist in the orders table
                DAL.DataAccess da5 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                // make command statement 
                string comm5 = "SELECT COUNT(OrderID) FROM Orders WHERE TXNID = @txnID";
                //"SELECT Count(*) FROM Orders"; //WHERE CustomerID = @customerID AND TXNID = @txnID";

                DataSet ds5 = new DataSet();


                // make arrays for paramaters and input
                string[] s5 = { "@txnID" };
                string[] v5 = { txn_id };
                ds5 = da5.ExecuteQuery(comm5, s5, v5);


                // returns one item
                txnID = ds5.Tables[0].Rows[0].ItemArray[0];


                //clear
                s5 = null;
                v5 = null;


                if (int.Parse(txnID.ToString()) == 0)
                {
                    if (payment_status == "Completed")
                    {
                        // update total of orders table for the customer
                        DAL.DataAccess da2 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        string comm2 =
                            "UPDATE Orders SET TXNID = @txnID, PaymentStatus = @paymentStatus WHERE OrderID = @orderID";



                        // empty array
                        string[] p2 = { "@txnID", "@paymentStatus", "@orderID" };
                        string[] v2 = { txn_id, "Completed", orderID };


                        da2.ExecuteNonQuery(comm2, p2, v2);

                        // clear
                        p2 = null;
                        v2 = null;


                    }

                    // if payment status is pending
                    if (payment_status == "Pending")
                    {
                        // update total of orders table for the customer
                        DAL.DataAccess da2 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        string comm2 =
                            "UPDATE Orders SET TXNID = @txnID, PaymentStatus = @paymentStatus WHERE OrderID = @orderID";


                        // empty array
                        string[] p2 = { "@txnID", "@paymentStatus", "@orderID" };
                        string[] v2 = { txn_id, "Pending", orderID };


                        da2.ExecuteNonQuery(comm2, p2, v2);

                        // clear
                        p2 = null;
                        v2 = null;
                    }
                    // if payment status is Processed
                    if (payment_status == "Processed")
                    {
                        // update total of orders table for the customer
                        DAL.DataAccess da2 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        string comm2 =
                            "UPDATE Orders SET TXNID = @txnID, PaymentStatus = @paymentStatus WHERE OrderID = @orderID";


                        // empty array
                        string[] p2 = { "@txnID", "@paymentStatus", "@orderID" };
                        string[] v2 = { txn_id, "Processed", orderID };


                        da2.ExecuteNonQuery(comm2, p2, v2);

                        // clear
                        p2 = null;
                        v2 = null;
                    }
                    // if payment status is Refunded 
                    //  parent_txn_id = old txn_id
                    if (payment_status == "Refunded")
                    {
                        // update total of orders table for the customer
                        DAL.DataAccess da2 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        string comm2 =
                            "UPDATE Orders SET TXNID = @txnID, PaymentStatus = @paymentStatus WHERE OrderID = @orderID";


                        // empty array
                        string[] p2 = { "@txnID", "@paymentStatus", "@orderID" };
                        string[] v2 = { txn_id, "Refunded", orderID };


                        da2.ExecuteNonQuery(comm2, p2, v2);

                        // clear
                        p2 = null;
                        v2 = null;
                    }
                    // if payment status is Reversed
                    //  parent_txn_id = old txn_id
                    if (payment_status == "Reversed")
                    {
                        // update total of orders table for the customer
                        DAL.DataAccess da2 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        string comm2 =
                            "UPDATE Orders SET TXNID = @txnID, PaymentStatus = @paymentStatus WHERE OrderID = @orderID";


                        // empty array
                        string[] p2 = { "@txnID", "@paymentStatus", "@orderID" };
                        string[] v2 = { txn_id, "Reversed", orderID };


                        da2.ExecuteNonQuery(comm2, p2, v2);

                        // clear
                        p2 = null;
                        v2 = null;
                    }
                    // if payment status is Canceled_Reversal
                    //  parent_txn_id = old txn_id
                    if (payment_status == "Canceled_Reversal")
                    {
                        // update total of orders table for the customer
                        DAL.DataAccess da2 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        string comm2 =
                            "UPDATE Orders SET TXNID = @txnID, PaymentStatus = @paymentStatus WHERE OrderID = @orderID";


                        // empty array
                        string[] p2 = { "@txnID", "@paymentStatus", "@orderID" };
                        string[] v2 = { txn_id, "Canceled Reversal", orderID };


                        da2.ExecuteNonQuery(comm2, p2, v2);

                        // clear
                        p2 = null;
                        v2 = null;
                    }
                    // if payment status is Voided
                    if (payment_status == "Voided")
                    {
                        // update total of orders table for the customer
                        DAL.DataAccess da2 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        string comm2 =
                            "UPDATE Orders SET TXNID = @txnID, PaymentStatus = @paymentStatus WHERE OrderID = @orderID";


                        // empty array
                        string[] p2 = { "@txnID", "@paymentStatus", "@orderID" };
                        string[] v2 = { txn_id, "Voided", orderID };


                        da2.ExecuteNonQuery(comm2, p2, v2);

                        // clear
                        p2 = null;
                        v2 = null;
                    }
                    // if payment status is Denied
                    if (payment_status == "Denied")
                    {
                        // update total of orders table for the customer
                        DAL.DataAccess da2 =
                            new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                               "System.Data.SqlClient");

                        string comm2 =
                            "UPDATE Orders SET TXNID = @txnID, PaymentStatus = @paymentStatus WHERE OrderID = @orderID";


                        // empty array
                        string[] p2 = { "@txnID", "@paymentStatus", "@orderID" };
                        string[] v2 = { txn_id, "Denied", orderID };


                        da2.ExecuteNonQuery(comm2, p2, v2);

                        // clear
                        p2 = null;
                        v2 = null;
                    }

                }
            }

            //   string paymentStatus = HttpUtility.UrlDecode(Request.Form["payment_status"].ToString());
        }
        else if (strResponse == "INVALID")
        {
            //log for manual investigation



        }

    }
}
