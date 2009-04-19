using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DataAccessModule;

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
            // update customer information      
            Customer customerIDID = new Customer();
            customerIDID.Username = Membership.GetUser().UserName;



            //Instantiate our Category specific DataAccess Class
            CustomerDA customerDA = new CustomerDA();

            Collection<Customer> getCustomerID = customerDA.Get(customerIDID);




            // returns one item
            // customerID = ds5.Tables[0].Rows[0].ItemArray[0];
            // if statement added by Ethan, will set customerID = 0 if no rows returned.
            if (getCustomerID.Count > 0)
            {
                customerID = getCustomerID[0].Id; ;
            }
            else
            {
                customerID = 0;
            }



            //clear
            customerIDID = null;
            customerDA = null;
            getCustomerID = null;


            // count how many orders exists from the user that is logged on 
            Order oID = new Order();
            oID.CustomerId = int.Parse(customerID.ToString());
            oID.TxnId = "";
            OrderDA orderIDDA = new OrderDA();

            Collection<Order> getOrderID = orderIDDA.Get(oID);


            orderCount = getOrderID.Count;


            // clear
            oID = null;
            orderIDDA = null;
            getOrderID = null;


            if (int.Parse(orderCount.ToString()) == 0)
            {
                // display answer on label       
                lblItemsInCart.Text = "0";
            }
            else
            {

                // get the orderID of the order that has a txnid = "" of the customer
                Order orderIDID = new Order();
                orderIDID.CustomerId = int.Parse(customerID.ToString());
                orderIDID.TxnId = "";
                OrderDA orderDA = new OrderDA();

                Collection<Order> getOrderIDID = orderDA.Get(orderIDID);


                orderID = getOrderIDID[0].Id;


                // clear
                oID = null;
                orderIDDA = null;
                getOrderID = null;


                //count how many items are in the shopping cart for the user
                //and display them 
                //instantiate class
                OrderItem orderItemCount = new OrderItem();
                orderItemCount.OrderId = int.Parse(orderID.ToString());

                OrderItemDA orderItemCountDA = new OrderItemDA();

                Collection<OrderItem> getOrderItemCount = orderItemCountDA.Get(orderItemCount);

                items = getOrderItemCount.Count;


                // clear
                orderItemCount = null;
                orderItemCountDA = null;
                getOrderItemCount = null;


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
                Customer customerIDID = new Customer();
                customerIDID.Username = Session["AnonymousUserName"].ToString();



                //Instantiate our Category specific DataAccess Class
                CustomerDA customerDA = new CustomerDA();

                Collection<Customer> getCustomerID = customerDA.Get(customerIDID);

                customerID = getCustomerID[0].Id.ToString();


                //clear
                customerIDID = null;
                customerDA = null;
                getCustomerID = null;




                // get the current orderID if any if not make shopping cart items 0
                // count how many orders exists from the user that is logged on 
                Order oID = new Order();
                oID.CustomerId = int.Parse(customerID.ToString());
                oID.TxnId = "";
                OrderDA orderIDDA = new OrderDA();

                Collection<Order> getOrderID = orderIDDA.Get(oID);


                orderCount = getOrderID.Count;


                // clear
                oID = null;
                orderIDDA = null;
                getOrderID = null;


                if (int.Parse(orderCount.ToString()) == 0)
                {
                    // display answer on label       
                    lblItemsInCart.Text = "0";
                }
                else
                {

                    // get the customerID
                    // get the customerID
                    Customer customerIDID2 = new Customer();
                    customerIDID2.Username = Session["AnonymousUserName"].ToString();



                    //Instantiate our Category specific DataAccess Class
                    CustomerDA customerDA2 = new CustomerDA();

                    Collection<Customer> getCustomerID2 = customerDA2.Get(customerIDID2);

                    customerID = getCustomerID2[0].Id;


                    //clear
                    customerIDID2 = null;
                    customerDA2 = null;
                    getCustomerID2 = null;


                    // get the orderID of the order with the txnid = "" for the anonyomous user
                    Order oID2 = new Order();
                    oID2.CustomerId = int.Parse(customerID.ToString());
                    oID2.TxnId = "";
                    OrderDA orderIDDA2 = new OrderDA();

                    Collection<Order> getOrderID2 = orderIDDA2.Get(oID2);


                    orderID = getOrderID2[0].Id;


                    // clear
                    oID2 = null;
                    orderIDDA2 = null;
                    getOrderID2 = null;


                    //count how many items are in the shopping cart for the anonymous user
                    //and display them 
                    //instantiate class
                    OrderItem orderItemCount = new OrderItem();
                    orderItemCount.OrderId = int.Parse(orderID.ToString());

                    OrderItemDA orderItemCountDA = new OrderItemDA();

                    Collection<OrderItem> getOrderItemCount = orderItemCountDA.Get(orderItemCount);

                    items = getOrderItemCount.Count;


                    // clear
                    orderItemCount = null;
                    orderItemCountDA = null;
                    getOrderItemCount = null;

                    // display answer on label       
                    lblItemsInCart.Text = items.ToString();
                }
            }

        }

    }

    // for search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Items.aspx?Search=" + Server.HtmlEncode(txtSearch.Text));
    }

}
