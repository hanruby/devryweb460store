using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessModule;

public partial class PurchaseCancelled : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AnonymousUserName"] != null)
        {

            CustomerDA customerDA2 = new CustomerDA();

            // check to see if user has items in their cart
            //Create an Object that specifies what we want to Get
            Customer customer2 = new Customer();

            //gets customer info based on customer username

            customer2.Username = Session["AnonymousUserName"].ToString();

            //We will be returned a collection so lets Declare that and fill it using Get()
            Collection<Customer> getCustomer2 = customerDA2.Get(customer2);

     



            // get orderID of anonymous user
            //Create an Object that specifies what we want to Get
            Order ordersID = new Order();

            //gets order info based on customerID
            ordersID.CustomerId = getCustomer2[0].Id;
            ordersID.TxnId = "";

            OrderDA ordersIDDA = new OrderDA();


            // deletes the order with that customerID
            Collection<Order> getOrder2 = ordersIDDA.Get(ordersID);



      



            // delete orderItem(s)
            DAL.DataAccess da5 =
                                         new DAL.DataAccess(
                                             ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                             "System.Data.SqlClient");

            string comm5 =
                "Delete FROM OrderItem WHERE OrderID = @orderID";

            // array with orderID
            string[] p5 = { "@orderID" };
            string[] v5 = { getOrder2[0].Id.ToString() };


            da5.ExecuteNonQuery(comm5, p5, v5);

            // clear
            p5 = null;
            v5 = null;

            // delete order
            OrderDA deleteOrderDA = new OrderDA();

            //Create an Object that specifies what we want to Get
            Order deleteOrder = new Order();

            //gets order info based on customerID

            deleteOrder.Id = int.Parse(getOrder2[0].Id.ToString());

            // deletes the order with that customerID
            deleteOrderDA.Delete(deleteOrder);


            // delete anonymous customer from customer table
            Customer customers = new Customer();
            customers.Id = getCustomer2[0].Id;

            CustomerDA customersDA = new CustomerDA();

            customersDA.Delete(customers);

            // clear
            customers = null;
            customersDA = null;




            //abandon session
            Session.Abandon();
            Session.Clear();  
        }

       
    }
}
