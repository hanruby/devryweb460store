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

public partial class Pages_IPN : System.Web.UI.Page
{
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

            // after a customer makes a purchase and they get redirected back if I add
            // code to enter the information to the database or to a file an error occurs.
          

            string paymentStatus = HttpUtility.UrlDecode(Request.Form["payment_status"].ToString());
            if (paymentStatus == "Completed")
            {

                Response.Write("" + paymentStatus);

               

            }

        }
        else if (strResponse == "INVALID")
        {
            //log for manual investigation
         
         
            
        }
        else
        {
            
        }

    }
}