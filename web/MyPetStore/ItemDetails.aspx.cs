using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using DataAccessModule; //IMPORTANT: Remember to add this line.
/*
 * Authors: Daniel Aguayo 
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
    //private int itemID;
    private Label vendorID;
    private Label QuantityAvailable;

    // price2 is label price
    // price is the amount that actually gets 
    // inserted into the database
    private Label price2;
    private double price;
    private Label minQuantity;
    private Label costPrice;
    private Label recommendedPrice;
    private Label itemID;

    private TextBox quantity;
    private Label successful;
    private Label error;

    private Label salePriceAnswer;
    private double salePriceAnswerDouble;

    private Label salePrice;


    private object customerID;
    private object orderID;
    private object countOrders;
    private object orders;
    private int usernameID;
    private object max;
    private string anonymousUserName;
    private int countItems;

    protected void Page_Load(object sender, EventArgs e)
    {


        // method that gets items in controls and
        // checks weather the sales price label is invisible or not
        GetItems();

        try
        {
            if (Request.QueryString["ItemID"] != null)
            {


                // get item information based on itemID
                Item item = new Item();
                item.Id = Request.QueryString["ItemID"];
                ItemDA itemDA = new ItemDA();
                Collection<Item> getItem = itemDA.Get(item);

                RangeValidator range = (RangeValidator)FormView1.FindControl("rvQuantity");




                //  if quantity available is less than minquanitity make txtQuantity and btnAddToCart invisible
                // and display Item is on Back order message.
                if (getItem[0].QuantityAvailable < getItem[0].MinQuantity)
                {
                    range.MaximumValue = "0";

                    range.MinimumValue = "0";

                    quantity.ReadOnly = true;

                    Button addtocart = (Button)FormView1.FindControl("btnAddToCart");

                    addtocart.Visible = false;

                    error.Text = "Item is on backorder!";
                    error.Visible = true;

                    quantity.Visible = false;

                    Label lblquantity = (Label)FormView1.FindControl("lblQuantity");
                    lblquantity.Visible = false;

                }
                else
                {
                    range.MaximumValue = getItem[0].QuantityAvailable.ToString();

                    range.MinimumValue = getItem[0].MinQuantity.ToString();
                }




                //clear 
                item = null;
                itemDA = null;
                getItem = null;
            }
        }
        catch (HttpException)
        {

        }
        catch (SqlException)
        {

        }




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
                // get the id of the user that I just created 
                Customer customer = new Customer();
                customer.Username = User.Identity.Name;
                CustomerDA customerIDDA = new CustomerDA();

                Collection<Customer> getCustomersID = customerIDDA.Get(customer);

                customerID = getCustomersID[0].Id;


                // clear
                customer = null;
                customerIDDA = null;


                // count how many orders that have not been verified exist in the orders table
                Order order = new Order();
                order.CustomerId = int.Parse(customerID.ToString());
                order.TxnId = "";

                OrderDA orderDA = new OrderDA();
                Collection<Order> getOrders = orderDA.Get(order);



                // returns one item
                countOrders = getOrders.Count;


                //clear
                order = null;
                orderDA = null;
                getOrders = null;


                // if there are no orders with a txnID = "" then add a new order
                // then get the OrderID of the Order to add items to the shopping
                // cart using that OrderID
                // if there are orders with a txnID = "" then select the OrderID
                // and add orders to the shopping cart using that OrderID
                if (int.Parse(countOrders.ToString()) == 0)
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
                    // insert sale price
                    Order orderIID = new Order();
                    orderIID.CustomerId = int.Parse(customerID.ToString());
                    orderIID.TxnId = "";

                    OrderDA orderIDDA = new OrderDA();

                    Collection<Order> getOrder = orderIDDA.Get(orderIID);
                    orderID = getOrder[0].Id;

                    //clear
                    orderIID = null;
                    getOrder = null;

                    // see if item is on sale
                    if (isItemOnSale() == true)
                    {
                        // insert item into the database using the OrderID that was created
                        // instantiate class
                        // insert sale price
                        OrderItem orderItem = new OrderItem();
                        orderItem.OrderId = int.Parse(orderID.ToString());
                        orderItem.ItemId = itemID.Text;
                        orderItem.VendorId = int.Parse(vendorID.Text);
                        orderItem.Price = decimal.Parse(salePriceAnswerDouble.ToString("n2"));
                        orderItem.TotalPrice = decimal.Parse(salePriceAnswerDouble.ToString("n2"));
                        orderItem.Quantity = int.Parse(quantity.Text);

                        OrderItemDA orderItemDA = new OrderItemDA();

                        //Save the Objects to the Database
                        orderItemDA.Save(orderItem);

                        // clear
                        orderItem = null;
                        orderItemDA = null;


                        //// tell user the item was added to their cart successfully
                        successful.Text = "Added to shopping cart successfully!";
                        successful.Visible = true;


                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {

                        // insert regular price
                        OrderItem orderItem = new OrderItem();
                        orderItem.OrderId = int.Parse(orderID.ToString());
                        orderItem.ItemId = itemID.Text;
                        orderItem.VendorId = int.Parse(vendorID.Text);
                        orderItem.Price = decimal.Parse(price.ToString("n2"));
                        orderItem.TotalPrice = decimal.Parse(price.ToString("n2"));
                        orderItem.Quantity = int.Parse(quantity.Text);

                        OrderItemDA orderItemDA = new OrderItemDA();

                        //Save the Objects to the Database
                        orderItemDA.Save(orderItem);

                        // clear
                        orderItem = null;
                        orderItemDA = null;

                        // tell user the item was added to their cart successfully
                        successful.Text = "Added to shopping cart successfully!";
                        successful.Visible = true;


                        // refresh page
                        Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                        // Response.Redirect(Request.RawUrl);
                    }


                }
                else
                {

                    // get the orderID of the user that has a txnID = ""
                    // instantiate class
                    Order orderIID = new Order();
                    orderIID.CustomerId = int.Parse(customerID.ToString());
                    orderIID.TxnId = "";

                    OrderDA orderIDDA = new OrderDA();

                    Collection<Order> getOrder = orderIDDA.Get(orderIID);
                    orderID = getOrder[0].Id;

                    //clear
                    orderIID = null;
                    getOrder = null;


                    // check to see if the customer has the item in their cart already.
                    // if they do, do not insert item into database
                    OrderItem orderItemExistence = new OrderItem();
                    orderItemExistence.OrderId = int.Parse(orderID.ToString());
                    orderItemExistence.ItemId = itemID.Text;


                    OrderItemDA orderItemExistenceDA = new OrderItemDA();

                    Collection<OrderItem> getOrderItemExistence = orderItemExistenceDA.Get(orderItemExistence);

                    countItems = getOrderItemExistence.Count;


                    if (countItems > 0)
                    {
                        error.Text = "This item is in your shopping cart.";
                        error.Visible = true;
                    }
                    else
                    {
                        // see if item is on sale
                        if (isItemOnSale() == true)
                        {

                            // insert sale price
                            OrderItem orderItem = new OrderItem();
                            orderItem.OrderId = int.Parse(orderID.ToString());
                            orderItem.ItemId = itemID.Text;
                            orderItem.VendorId = int.Parse(vendorID.Text);
                            orderItem.Price = decimal.Parse(salePriceAnswerDouble.ToString("n2"));
                            orderItem.TotalPrice = decimal.Parse(salePriceAnswerDouble.ToString("n2"));
                            orderItem.Quantity = int.Parse(quantity.Text);

                            OrderItemDA orderItemDA = new OrderItemDA();

                            //Save the Objects to the Database
                            orderItemDA.Save(orderItem);

                            // tell user the item was added to their cart successfully
                            successful.Text = "Added to shopping cart successfully!";
                            successful.Visible = true;


                            // refresh page
                            Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                        }
                        else
                        {

                            // insert regular price
                            OrderItem orderItem = new OrderItem();
                            orderItem.OrderId = int.Parse(orderID.ToString());
                            orderItem.ItemId = itemID.Text;
                            orderItem.VendorId = int.Parse(vendorID.Text);
                            orderItem.Price = decimal.Parse(price.ToString("n2"));
                            orderItem.TotalPrice = decimal.Parse(price.ToString("n2"));
                            orderItem.Quantity = int.Parse(quantity.Text);

                            OrderItemDA orderItemDA = new OrderItemDA();

                            //Save the Objects to the Database
                            orderItemDA.Save(orderItem);


                            // tell user the item was added to their cart successfully
                            successful.Text = "Added to shopping cart successfully!";
                            successful.Visible = true;


                            // refresh page
                            Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);

                        }


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



                    // get all rows to get maximum customerID
                    CustomerDA customerDA = new CustomerDA();

                    //We will be returned a collection so lets Declare that and fill it using Get()
                    Collection<Customer> getCustomers = customerDA.Get(null);

                    // gets max customerID in table 
                    // adds one and combines websites domain name
                    // with the anonymousID

                    max = (int)getCustomers[getCustomers.Count - 1].Id;

                    usernameID = int.Parse(max.ToString()) + 1;

                    anonymousUserName = "mypetsfw.com" + usernameID;

                    //clear           
                    customerDA = null;
                    getCustomers = null;





                    // insert the anonymousCustomerID into the customer table with the username of
                    // and the usernameID/customerID
                    // mypetsfw.com + customerID
                    Customer customer = new Customer(usernameID, true, anonymousUserName, "Fill In", "Fill In", "Fill In", "Fill In", "Fill In", "", "Fill In", "");

                    CustomerDA customerDA1 = new CustomerDA();
                    customerDA1.Save(customer);

                    // clear
                    customer = null;
                    customerDA = null;




                    // put the anonymoususername in a session
                    Session["AnonymousUserName"] = anonymousUserName.ToString();




                    // create a new order of the anonymous user
                    // add a new order to the order table
                    // instantiate class
                    Order oID1 = new Order();
                    oID1.Id = GetOrderIDPlusOne();
                    oID1.CustomerId = usernameID;
                    oID1.GrossTotal = 0;
                    oID1.Tax = 0;
                    oID1.NetTotal = 0;
                    // for payment status
                    oID1.TxnId = "";

                    OrderDA orderIDDA1 = new OrderDA();

                    // save
                    orderIDDA1.Save(oID1);

                    //DAL.DataAccess da11 =
                    //    new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                    //                       "System.Data.SqlClient");

                    //// make command statement 
                    //string comm11 = "INSERT INTO Orders VALUES (@customerID, @grossTotal, @tax, @netTotal, @txnID,  @paymentStatus)";

                    //// make arrays for paramaters and input
                    //string[] s11 = { "@customerID", "@grossTotal", "@tax", "@netTotal", "@txnID", "@paymentStatus" };
                    //string[] v11 = { usernameID.ToString(), "0", "0", "0", "", "" };

                    //da11.ExecuteNonQuery(comm11, s11, v11);

                    //clear
                    oID1 = null;
                    orderIDDA1 = null;


                    // get the orderID of the anonymoususer 
                    // get the id of the user that I just created 
                    Order oID = new Order();
                    oID.CustomerId = usernameID;
                    oID.TxnId = "";
                    OrderDA orderIDDA = new OrderDA();

                    Collection<Order> getOrderID = orderIDDA.Get(oID);

                    orderID = getOrderID[0].Id;



                    //clear
                    oID = null;
                    getOrderID = null;



                    // see if item is on sale
                    if (isItemOnSale() == true)
                    {
                        // insert item into the database using the OrderID that was created
                        // instantiate class


                        OrderItem orderItem = new OrderItem();
                        orderItem.OrderId = int.Parse(orderID.ToString());
                        orderItem.ItemId = itemID.Text;
                        orderItem.VendorId = int.Parse(vendorID.Text);
                        orderItem.Price = decimal.Parse(salePriceAnswerDouble.ToString());
                        orderItem.TotalPrice = decimal.Parse(salePriceAnswerDouble.ToString());
                        orderItem.Quantity = int.Parse(quantity.Text);

                        OrderItemDA orderItemDA = new OrderItemDA();

                        //Save the Objects to the Database
                        orderItemDA.Save(orderItem);





                        // clear
                        orderItem = null;
                        orderItemDA = null;

                        // tell anonymous the item was added to their cart successfully
                        successful.Text = "Added to shopping cart successfully!";
                        successful.Visible = true;

                        // refresh page
                        Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                    }
                    else
                    {
                        // insert item into the database using the OrderID that was created
                        // instantiate class


                        OrderItem orderItem = new OrderItem();
                        orderItem.OrderId = int.Parse(orderID.ToString());
                        orderItem.ItemId = itemID.Text;
                        orderItem.VendorId = int.Parse(vendorID.Text);
                        orderItem.Price = decimal.Parse(price.ToString());
                        orderItem.TotalPrice = decimal.Parse(price.ToString());
                        orderItem.Quantity = int.Parse(quantity.Text);

                        OrderItemDA orderItemDA = new OrderItemDA();

                        //Save the Objects to the Database
                        orderItemDA.Save(orderItem);

                        // clear
                        orderItem = null;
                        orderItemDA = null;

                        // tell anonymous the item was added to their cart successfully
                        successful.Text = "Added to shopping cart successfully!";
                        successful.Visible = true;


                        // refresh page
                        Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                    }






                }
                // if the session doesn't != null
                else
                {
                    // get the customerID of the user that I just created 



                    Customer customer2 = new Customer();
                    customer2.Username = Session["AnonymousUserName"].ToString();
                    CustomerDA customerDA2 = new CustomerDA();

                    Collection<Customer> getCustomers2 = customerDA2.Get(customer2);

                    customerID = getCustomers2[0].Id;


                    // clear
                    customer2 = null;
                    customerDA2 = null;
                    getCustomers2 = null;


                    // see if an order doesn't already exist for the anonymousUser
                    // count how many orderIDs that have not been verified exist in the orders table


                    Order orders = new Order();
                    orders.CustomerId = int.Parse(customerID.ToString());
                    orders.TxnId = "";

                    OrderDA orderDA = new OrderDA();
                    Collection<Order> getOrder = orderDA.Get(orders);



                    // returns one item
                    countOrders = getOrder.Count;


                    //clear
                    orders = null;
                    orderDA = null;
                    getOrder = null;

                    // if there are no orders with a txnID = "" then add a new order
                    // then get the OrderID of the Order to add items to the shopping
                    // cart using that OrderID
                    // if there are orders with a txnID = "" then select the OrderID
                    // and add orders to the shopping cart using that OrderID
                    if (int.Parse(countOrders.ToString()) == 0)
                    {
                        // get the customerID of the user that I just created 


                        Customer customerIDID = new Customer();
                        customerIDID.Username = Session["AnonymousUserName"].ToString();
                        CustomerDA customerIDDA = new CustomerDA();

                        Collection<Customer> getCustomers3 = customerIDDA.Get(customerIDID);

                        customerID = getCustomers3[0].Id;


                        // clear
                        customerIDID = null;
                        customerIDDA = null;
                        getCustomers3 = null;



                        // create a new order of the anonymous user
                        // add a new order to the order table
                        // instantiate class
                        Order oID1 = new Order();
                        oID1.Id = GetOrderIDPlusOne();
                        oID1.CustomerId = usernameID;
                        oID1.GrossTotal = 0;
                        oID1.Tax = 0;
                        oID1.NetTotal = 0;
                        // for payment status
                        oID1.TxnId = "";

                        OrderDA orderIDDA1 = new OrderDA();

                        // save
                        orderIDDA1.Save(oID1);

                        //DAL.DataAccess da11 =
                        //    new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                        //                       "System.Data.SqlClient");

                        //// make command statement 
                        //string comm11 = "INSERT INTO Orders VALUES (@customerID, @grossTotal, @tax, @netTotal, @txnID, @paymentStatus)";

                        //// make arrays for paramaters and input
                        //string[] s11 = { "@customerID", "@grossTotal", "@tax", "@netTotal", "@txnID", "@paymentStatus" };
                        //string[] v11 = { customerID.ToString(), "0", "0", "0", "", "" };

                        //da11.ExecuteNonQuery(comm11, s11, v11);

                        //clear
                        oID1 = null;
                        orderIDDA1 = null;




                        // get the orderid for the anonymous users new order

                        Order oID = new Order();
                        oID.CustomerId = int.Parse(customerID.ToString());
                        oID.TxnId = "";
                        OrderDA orderIDDA = new OrderDA();

                        Collection<Order> getOrderID = orderIDDA.Get(oID);

                        orderID = int.Parse(getOrderID[0].Id.ToString());



                        //clear
                        oID = null;
                        orderIDDA = null;
                        getOrderID = null;





                        // see if item is on sale
                        if (isItemOnSale() == true)
                        {


                            // insert item into the database using the OrderID that was created
                            // instantiate class
                            OrderItem orderItem = new OrderItem();
                            orderItem.OrderId = int.Parse(orderID.ToString());
                            orderItem.ItemId = itemID.Text;
                            orderItem.VendorId = int.Parse(vendorID.Text);
                            orderItem.Price = decimal.Parse(salePriceAnswerDouble.ToString());
                            orderItem.TotalPrice = decimal.Parse(salePriceAnswerDouble.ToString());
                            orderItem.Quantity = int.Parse(quantity.Text);

                            OrderItemDA orderItemDA = new OrderItemDA();

                            //Save the Objects to the Database
                            orderItemDA.Save(orderItem);



                            // clear
                            orderItem = null;
                            orderItemDA = null;


                            // tell user the item was added to their cart successfully
                            successful.Text = "Added to shopping cart successfully!";
                            successful.Visible = true;

                            // refresh page
                            Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                        }
                        else
                        {
                            // insert item into the database using the OrderID that was created
                            // instantiate class

                            OrderItem orderItem = new OrderItem();
                            orderItem.OrderId = int.Parse(orderID.ToString());
                            orderItem.ItemId = itemID.Text;
                            orderItem.VendorId = int.Parse(vendorID.Text);
                            orderItem.Price = decimal.Parse(price.ToString());
                            orderItem.TotalPrice = decimal.Parse(price.ToString());
                            orderItem.Quantity = int.Parse(quantity.Text);

                            OrderItemDA orderItemDA = new OrderItemDA();

                            //Save the Objects to the Database
                            orderItemDA.Save(orderItem);



                            // clear
                            orderItem = null;
                            orderItemDA = null;

                            // tell user the item was added to their cart successfully
                            successful.Text = "Added to shopping cart successfully!";
                            successful.Visible = true;


                            // refresh page
                            Response.AppendHeader("Refresh", "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                        }

                    }
                    // if an order is open and exists for the anonymous user
                    else
                    {


                        // get the customerID of the user that I just created 
                        Customer customerIDID = new Customer();
                        customerIDID.Username = Session["AnonymousUserName"].ToString();
                        CustomerDA customerIDDA = new CustomerDA();

                        Collection<Customer> getCustomers3 = customerIDDA.Get(customerIDID);

                        customerID = getCustomers3[0].Id;


                        // clear
                        customerIDID = null;
                        customerIDDA = null;
                        getCustomers3 = null;


                        // get the orderID of the anonymoususer that has a txnID = ""
                        // instantiate class

                        Order oID = new Order();
                        oID.CustomerId = int.Parse(customerID.ToString());
                        oID.TxnId = "";
                        OrderDA orderIDDA = new OrderDA();

                        Collection<Order> getOrderID = orderIDDA.Get(oID);

                        orderID = getOrderID[0].Id;



                        //clear
                        oID = null;
                        orderIDDA = null;
                        getOrderID = null;


                        // check to see if the anonymous user has the item in their cart already.
                        // if they do, do not insert item into database
                        OrderItem orderItemExistence = new OrderItem();
                        orderItemExistence.OrderId = int.Parse(orderID.ToString());
                        orderItemExistence.ItemId = itemID.Text;


                        OrderItemDA orderItemExistenceDA = new OrderItemDA();

                        Collection<OrderItem> getOrderItemExistence = orderItemExistenceDA.Get(orderItemExistence);

                        countItems = getOrderItemExistence.Count;


                        if (countItems > 0)
                        {
                            error.Text = "This item is in your shopping cart.";
                            error.Visible = true;
                        }
                        else
                        {





                            // see if item is on sale
                            if (isItemOnSale() == true)
                            {
                                // insert item into the database using the existing OrdersID
                                // instantiate class
                                OrderItem orderItem = new OrderItem();
                                orderItem.OrderId = int.Parse(orderID.ToString());
                                orderItem.ItemId = itemID.Text;
                                orderItem.VendorId = int.Parse(vendorID.Text);
                                orderItem.Price = decimal.Parse(salePriceAnswerDouble.ToString());
                                orderItem.TotalPrice = decimal.Parse(salePriceAnswerDouble.ToString());
                                orderItem.Quantity = int.Parse(quantity.Text);

                                OrderItemDA orderItemDA = new OrderItemDA();

                                //Save the Objects to the Database
                                orderItemDA.Save(orderItem);



                                // clear
                                orderItem = null;
                                orderItemDA = null;


                                // tell user the item was added to their cart successfully
                                successful.Text = "Added to shopping cart successfully!";
                                successful.Visible = true;


                                // refresh page
                                Response.AppendHeader("Refresh",
                                                      "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                            }
                            else
                            {
                                // insert item into the database using the existing OrdersID
                                // instantiate class
                                OrderItem orderItem = new OrderItem();
                                orderItem.OrderId = int.Parse(orderID.ToString());
                                orderItem.ItemId = itemID.Text;
                                orderItem.VendorId = int.Parse(vendorID.Text);
                                orderItem.Price = decimal.Parse(price.ToString());
                                orderItem.TotalPrice = decimal.Parse(price.ToString());
                                orderItem.Quantity = int.Parse(quantity.Text);

                                OrderItemDA orderItemDA = new OrderItemDA();

                                //Save the Objects to the Database
                                orderItemDA.Save(orderItem);

                                // tell user the item was added to their cart successfully
                                successful.Text = "Added to shopping cart successfully!";
                                successful.Visible = true;


                                // refresh page
                                Response.AppendHeader("Refresh",
                                                      "0;URL=ItemDetails.aspx?ItemID=" + Request.QueryString["ItemID"]);
                            }
                        }

                    }
                }

            }
        }
        catch (SqlException)
        {
            // error.Text = "The item is in your shopping cart already.";
            // error.Visible = true;
        }
        catch (Exception)
        {

        }
    }

    // gets values from for labels and textboxes
    private void GetItems()
    {
        try
        {
            successful = (Label)FormView1.FindControl("lblSuccessful");
            error = (Label)FormView1.FindControl("lblError");
            itemID = (Label)FormView1.FindControl("lblItemID");
            vendorID = (Label)FormView1.FindControl("lblVendorID");
            QuantityAvailable = (Label)FormView1.FindControl("lblQuantityAvailable");
            price2 = (Label)FormView1.FindControl("lblPrice");
            minQuantity = (Label)FormView1.FindControl("lblMinQuantity");
            costPrice = (Label)FormView1.FindControl("lblCostPrice");
            recommendedPrice = (Label)FormView1.FindControl("lblRecommendedPrice");
            quantity = (TextBox)FormView1.FindControl("txtQuantity");

            // make sure price is not empty
            if (price2.Text == "")
            {
            }
            else
            {
                price = double.Parse(price2.Text, System.Globalization.NumberStyles.Currency);
                //itemID = int.Parse(itemIDLabel.Text, System.Globalization.NumberStyles.Integer);
            }


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
        catch (NullReferenceException)
        {

        }
        catch (FormatException)
        {
            try
            {
                salePrice.Visible = false;
                salePriceAnswer.Visible = false;
            }
            catch (NullReferenceException)
            {

            }
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

    // gets orderID plus one to enter a new order
    private int GetOrderIDPlusOne()
    {

        // get orderID + 1
        Order orderID = new Order();

        OrderDA orderIDDA = new OrderDA();

        Collection<Order> getOrderID = orderIDDA.Get(null);

        int orderIDPlusOne = (int)getOrderID[getOrderID.Count - 1].Id + 1;

        // clear
        orderID = null;
        orderIDDA = null;
        getOrderID = null;


        return orderIDPlusOne;
    }

}
