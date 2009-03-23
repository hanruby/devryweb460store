using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net;
using System.Data.SqlClient;
/*
 * Comments:
 * 
 */
public partial class IPN : System.Web.UI.Page
{
    // variables for paypal
    private string item_name;
    private string item_number;
    private string quantity;
    private string item_code;
    private string payment_status;
    private string payment_amount;         //full amount of payment. payment_gross in US
    private string payment_currency;
    private string txn_id;                   //unique transaction id
    private string receiver_email;
    private string payer_email;
    private double mc_fee;
    private string tax_cart;

    private string amount;
    private string numberOfItems;


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
            payment_amount = double.Parse(Request.Form["mc_gross"]).ToString("n2");       //full amount of payment before transaction fee is subtracted
            mc_fee = double.Parse(Request.Form["mc_fee"]); // transaction fee
            payment_currency = Request.Form["mc_currency"];
            txn_id = Request.Form["txn_id"];                   //unique transaction id
            receiver_email = Request.Form["receiver_email"];
            payer_email = Request.Form["payer_email"];
            tax_cart = Request.Form["tax"]; // tax for the whole entire cart



            // custom info that we send,
            // user cannot see it 
            // used to run loop for as many items as there is
            numberOfItems = Request.Form["custom"];



            // check database what price of item is 
            // and compare it to price paid
            //string amountThatWasPaid = item_name;

            // if payment status is Completed put order in database
            // we got the money in our bank!
            if (payment_status == "Completed")
            {
                if (receiver_email == "akagon_1236919720_biz@yahoo.com") // make sure the receiver email is ours
                {



                    // make sure txn_id is unique
                    // if it is run the rest of the code
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString =
                        @"Server=Fancystud.db.3323383.hostedresource.com; Database=Fancystud; User ID=Fancystud; Password=Mlkj340885; Trusted_Connection=False";
                    SqlCommand comm = new SqlCommand();
                    conn.Open();
                    comm.Connection = conn;

                    comm.CommandText = "SELECT Count(*) FROM Order WHERE TXNID = '" + txn_id + "'";

                    int txn_idCount = int.Parse(comm.ExecuteScalar().ToString());


                    comm.Dispose();
                    conn.Close();
                    conn.Dispose();


                    if (txn_idCount == 0)
                    {

                        // paypal variables that are being returned
                        for (int i = 0; i < int.Parse(numberOfItems); i++)
                        {
                            quantity = Request.Form["quantity" + (i + 1)];
                            amount = Request.Form["amount" + (i + 1)];
                            item_number = Request.Form["item_number" + (i + 1)];







                            // Select the price of a specific item to multiply it by the quantity bought
                            // DBConnect dbconnect = new DBConnect(@"Server=Fancystud.db.3323383.hostedresource.com; Database=Fancystud; User ID=Fancystud; Password=Mlkj340885; Trusted_Connection=False");

                            SqlConnection conn2 = new SqlConnection();
                            conn2.ConnectionString =
                                @"Server=Fancystud.db.3323383.hostedresource.com; Database=Fancystud; User ID=Fancystud; Password=Mlkj340885; Trusted_Connection=False";
                            SqlCommand comm2 = new SqlCommand();
                            conn2.Open();
                            comm2.Connection = conn;

                            comm2.CommandText = "SELECT Price FROM Cars WHERE CarID = '" + item_number + "'";
                            double answer = Convert.ToDouble(comm2.ExecuteScalar());



                            // calculate totalAmount for each item
                            string price = Convert.ToDouble(answer).ToString("n2");
                            string totalAmount = (double.Parse(price) * int.Parse(quantity)).ToString("n2");

                            comm2.Dispose();
                            conn2.Close();
                            conn2.Dispose();




                            // insert to database each individual items information 
                            DBConnect dbconnect2 =
                                new DBConnect(
                                    @"Server=Fancystud.db.3323383.hostedresource.com; Database=Fancystud; User ID=Fancystud; Password=Mlkj340885; Trusted_Connection=False");



                            dbconnect2.ExecSQL("INSERT INTO OrderItem VALUES('" + txn_id + "' , '" + item_number +
                                               "' , '" + 155125 + "' , '" + totalAmount + "' , '" + quantity + "')");

                            dbconnect2.Close();

                        }



                        // subtract payment_amount by mc_fee
                        // to figure out total amount deposited in our bank
                        string totalBankDeposit = (double.Parse(payment_amount) - mc_fee).ToString("n2");


                        // subtract total amount deposited in our bank
                        // by the tax amount
                        string totalWithTaxDeducted =
                            (double.Parse(totalBankDeposit) - double.Parse(tax_cart)).ToString("n2");

                        // insert information to the database
                        DBConnect dbConnect3 =
                            new DBConnect(
                                @"Server=Fancystud.db.3323383.hostedresource.com; Database=Fancystud; User ID=Fancystud; Password=Mlkj340885; Trusted_Connection=False");

                        dbConnect3.ExecSQL("INSERT INTO Shipment VALUES('" + txn_id + "' , '" + 15545 + "' , '" +
                                           payment_amount + "' , '" + tax_cart + "' , '" + totalWithTaxDeducted + "')");

                        dbConnect3.Close();









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
