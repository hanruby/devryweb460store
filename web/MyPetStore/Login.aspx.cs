using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataAccessModule; //IMPORTANT: Remember to add this line.
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // focus in the login name textbox
        var userNameTB = (TextBox) UserLogin.FindControl("UserName");
        userNameTB.Focus();
    }

    // on logged in
    protected void LoggedIn(object sender, EventArgs e)
    {

        // seeing if there is an order just in case I missed something
        if (Session["AnonymousUserName"] != null)
        {
            // if the user has an order on going delete it and replace it
            // with the items that the anonymous user just made(which is really a customer) 
            //Instantiate our Category specific DataAccess Class
            CustomerDA customerDA = new CustomerDA();

            // check to see if user has items in their cart
            //Create an Object that specifies what we want to Get
            Customer customer = new Customer();

            //gets customer info based on customer username

            customer.Username = UserLogin.UserName;

            //We will be returned a collection so lets Declare that and fill it using Get()
            Collection<Customer> getCustomer = customerDA.Get(customer);


            // count orders with customerid = @customerid and txtnid = @txnid
            // instantiate class
            DAL.DataAccess da2 =
                new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                   "System.Data.SqlClient");

            // sql command
            string comm2 =
                "SELECT Count(*) FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";

            // data set
            DataSet ds2 = new DataSet();

            // empty array
            string[] p2 = { "@customerID", "@txnID" };
            string[] v2 = { getCustomer[0].Id.ToString(), "" };

            ds2 = da2.ExecuteQuery(comm2, p2, v2);

            object getOrder = ds2.Tables[0].Rows[0].ItemArray[0];

            // clear
            p2 = null;
            v2 = null;

            // if the user who is logged has items in his cart as an anonymous user
            // delete the items he had previously on his cart and add the new items and order
            // that they just put into his cart
            if (int.Parse(getOrder.ToString()) > 0)
            {





                // get the orderID of the customer that he had on going order
                // instantiate class
                DAL.DataAccess da3 =
                    new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                       "System.Data.SqlClient");

                // sql command
                string comm3 =
                    "SELECT OrderID FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";

                // data set
                DataSet ds3 = new DataSet();

                // empty array
                string[] p3 = { "@customerID", "@txnID" };
                string[] v3 = { getCustomer[0].Id.ToString(), "" };

                ds3 = da3.ExecuteQuery(comm3, p3, v3);

                object getOrderID = ds3.Tables[0].Rows[0].ItemArray[0];

                // clear
                p3 = null;
                v3 = null;




                // delete items from the orderItem table associated with that order if any
                //Instantiate our Category specific DataAccess Class
                //OrderDA deleteOrderItemDA = new OrderDA();

                ////Create an Object that specifies what we want to Get
                //Order deleteOrderItem = new Order();

                ////gets orderItem info based on customerID

                //deleteOrderItem.Id = int.Parse(getOrderID.ToString());

                //// deletes the orderItems with that customerID
                //deleteOrderItemDA.Delete(deleteOrderItem);
                DAL.DataAccess da5 =
                                              new DAL.DataAccess(
                                                  ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                                  "System.Data.SqlClient");

                string comm5 =
                    "Delete FROM OrderItem WHERE OrderID = @orderID";

                // array with orderID
                string[] p5 = { "@orderID" };
                string[] v5 = { getOrderID.ToString() };


                da5.ExecuteNonQuery(comm5, p5, v5);

                // clear
                p5 = null;
                v5 = null;





                // delete the order and items that involve the order above 
                //Instantiate our Category specific DataAccess Class
                //  OrderDA deleteOrderDA = new OrderDA();

                //  //Create an Object that specifies what we want to Get
                //  Order deleteOrder = new Order();

                //  //gets order info based on customerID

                //  deleteOrder.Id = int.Parse(GetCustomerID());

                //// deletes the order with that customerID
                // deleteOrderDA.Delete(deleteOrder);
                DAL.DataAccess da7 =
                                                 new DAL.DataAccess(
                                                         ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                                         "System.Data.SqlClient");

                string comm7 =
                    "Delete FROM Orders WHERE OrderID = @orderID";

                // array with orderID
                string[] p7 = { "@orderID" };
                string[] v7 = { getOrderID.ToString() };


                da7.ExecuteNonQuery(comm7, p7, v7);

                // clear
                p7 = null;
                v7 = null;




                // get cusotmerID of anonymous user
                //Instantiate our Category specific DataAccess Class
                CustomerDA customerDA2 = new CustomerDA();

                // check to see if user has items in their cart
                //Create an Object that specifies what we want to Get
                Customer customer2 = new Customer();

                //gets customer info based on customer username

                customer2.Username = Session["AnonymousUserName"].ToString();

                //We will be returned a collection so lets Declare that and fill it using Get()
                Collection<Customer> getCustomer2 = customerDA2.Get(customer2);

                //for (int i = 0; i < getCustomer2.Count; i++)
                //{
                //    getCustomer2[i].Id;
                //}


                // get orderID of anonymous user
                OrderDA orderDA = new OrderDA();


                //Create an Object that specifies what we want to Get
                Order order = new Order();

                //gets order info based on customerID

                order.CustomerId = getCustomer2[0].Id;

                // deletes the order with that customerID
                Collection<Order> getOrder2 = orderDA.Get(order);



                // update the customerid of the anonymous order to the customer, of the user who just logged on

                DAL.DataAccess da4 =
                    new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                       "System.Data.SqlClient");

                string comm4 =
                    "UPDATE Orders SET CustomerID = @customerID WHERE OrderID = @orderID  AND TXNID = @txnID";


                // empty array
                string[] p4 = { "@customerID", "@orderID", "@txnID" };
                string[] v4 = { getCustomer[0].Id.ToString(), getOrder2[0].Id.ToString(), "" };
                // new cus old get order

                da4.ExecuteNonQuery(comm4, p4, v4);

                // clear
                p4 = null;
                v4 = null;


                // clear session and abandon it
                Session.Clear();
                Session.Abandon();

            }
            // if user doesn't have an on going order just
            // change the customer ID on the order
            else
            {
                // get cusotmerID of anonymous user
                //Instantiate our Category specific DataAccess Class
                CustomerDA customerDA2 = new CustomerDA();

                // check to see if user has items in their cart
                //Create an Object that specifies what we want to Get
                Customer customer2 = new Customer();

                //gets customer info based on customer username

                customer2.Username = Session["AnonymousUserName"].ToString();

                //We will be returned a collection so lets Declare that and fill it using Get()
                Collection<Customer> getCustomer2 = customerDA2.Get(customer2);

                //for (int i = 0; i < getCustomer2.Count; i++)
                //{
                //    getCustomer2[i].Id;
                //}


                // get orderID of anonymous user based on customerID
                OrderDA orderDA = new OrderDA();


                //Create an Object that specifies what we want to Get
                Order order = new Order();

                //gets order info based on customerID

                order.CustomerId = getCustomer2[0].Id;

                // deletes the order with that customerID
                Collection<Order> getOrder2 = orderDA.Get(order);



                // update the customerid of the anonymous order to the customer, of the user who just logged on

                DAL.DataAccess da4 =
                    new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                       "System.Data.SqlClient");

                string comm4 =
                    "UPDATE Orders SET CustomerID = @customerID WHERE OrderID = @orderID  AND TXNID = @txnID";


                // empty array
                string[] p4 = { "@customerID", "@orderID", "@txnID" };
                string[] v4 = { getCustomer[0].Id.ToString(), getOrder2[0].Id.ToString(), "" };
                // new cus old get order

                da4.ExecuteNonQuery(comm4, p4, v4);

                // clear
                p4 = null;
                v4 = null;


                // clear session and abandon it
                Session.Clear();
                Session.Abandon();
            }

        }
    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        // redirect user to the homepage
        Response.Redirect("~/Default.aspx");
    }
}
