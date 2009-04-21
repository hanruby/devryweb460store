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
 * Author: Daniel Aguayo
 * 
 */
public partial class CheckOut : System.Web.UI.Page
{
    // attributes


    private TextBox quantity;
    private Label minQuantity;
    private Label quantityAvailable;
    private Label itemID;
    private Label orderID;
    private Label vendorID;
    private Label totalIndividualItem;

    // for getting customer'sID method
    private object customerID;

    // for calculating price method
    private Label price;
    private double addPrice;
    private double total;
    private double tax;




    // used to warn user if quantity entered is invalid
    // count and totalCount are used for counting 
    // the total price in the shopping cart
    private int minQuantityInt;
    private int quantityAvailableInt;
    private int quantityInt;
    private int count;
    private int totalCount;

    protected void Page_Load(object sender, EventArgs e)
    {

        // clear lblError
        lblError.Text = "";
        lblQuantityError.Text = "";


        // for registration
        // create dropdownbox controls
        var cboState = (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboState");
        // var cboCountry = (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboCountry");

        // set the abbreviated name for the states to prevent the user from typing it in
        string[] states = {"AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC",               
                              "DE", "FL", "GA", "HI", "IA", "ID", "IL", "IN", "KS", "KY",               
                              "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS", "MT", "NC",               
                              "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR",               
                              "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", 
                              "WI", "WV", "WY"};
        cboState.DataSource = states;
        cboState.DataBind();

        // set the abbreviated name for the country to prevent the user from typing it in
        // string[] countries = CountryArrays.Abbreviations;
        // cboCountry.DataSource = countries;
        // cboCountry.DataBind();














        // if all querystrings are all left blank redirect user to checkOut
        if (Request.QueryString["Shipping"] == null && Request.QueryString["CheckOut"] == null && Request.QueryString["OrderReview"] == null)
        {
            Response.Redirect("~/CheckOut.aspx?CheckOut=true");
        }

        // if one of the querystrings != true
        // redirect user to checkout
        if (Request.QueryString["Shipping"] != "true" && Request.QueryString["CheckOut"] != "true" && Request.QueryString["OrderReview"] != "true")
        {
            Response.Redirect("~/CheckOut.aspx?CheckOut=true");
        }

        // if the user is logged in and Checkout = true
        if (Request.QueryString["CheckOut"] == "true" && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/CheckOut.aspx?Shipping=true");
        }

        // for getting customer's shipping information
        if (Request.QueryString["Shipping"] == "true" && Request.QueryString["CheckOut"] == null && Request.QueryString["OrderReview"] == null)
        {


            if (!Page.IsPostBack)
            {

                // gets shipping information for all users 
                // online or not
                GetShippingInformation();
            }







            // if user is not logged in or has not active session
            // redirect them to the shoppingcart
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated || Session["AnonymousUserName"] != null)
            {
                billingInfo.Visible = true;
                registerOrLogin.Visible = false;
                btnUpdateQuantity.Visible = false;
                orderReview.Visible = false;
            }
            else
            {
                Response.Redirect("ShoppingCart.aspx");
            }

        }
        // check what is is querystrings
        if (Request.QueryString["Shipping"] == null && Request.QueryString["CheckOut"] == "true" && Request.QueryString["OrderReview"] == null)
        {

            if (!Page.IsPostBack)
            {
                // bind gridview and repeater
                BindGridRepeater();

                // redirect user/customer if their shopping cart is empty
                if (this.GridView1.Rows.Count > 0)
                {
                    billingInfo.Visible = false;
                    registerOrLogin.Visible = true;
                    btnUpdateQuantity.Visible = false;
                    orderReview.Visible = false;
                }
                else
                {
                    Response.Redirect("ShoppingCart.aspx");
                }
            }
        }

        if (Request.QueryString["Shipping"] == null && Request.QueryString["CheckOut"] == null && Request.QueryString["OrderReview"] == "true")
        {
            billingInfo.Visible = false;
            registerOrLogin.Visible = false;
            orderReview.Visible = true;
            btnUpdateQuantity.Visible = true;


            if (!Page.IsPostBack)
            {
                // bind gridview and repeater
                BindGridRepeater();

                // bind rptShipping
                BindRPTShipping();


                // check to see if any information is missing on OrderReview Page. If there is
                // redirect the user.
                EmptyShippingInfo();

                //code for tablesorter ready gridviews
                // check to see if gridview has data in it
                // if gridview has data in it set everything
                // visible if not set it unvinsible
                // and tell user they have nothing in their
                // shopping cart
                if (this.GridView1.Rows.Count > 0)
                {
                    GridView1.UseAccessibleHeader = true;
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    rptOne.Visible = true;

                    btnUpdateQuantity.Visible = true;


                    // update gridview and repeater
                    UpdateQuantity();

                }

                else
                {
                    rptOne.Visible = false;

                    btnUpdateQuantity.Visible = false;


                    Response.Redirect("ShoppingCart.aspx");
                }
                //end


            }

        }


    }

    // button to update order review cart
    protected void btnUpdateQuantity_Click(object sender, EventArgs e)
    {
        UpdateQuantity();
    }
    private void UpdateQuantity()
    {


        // catch format exception and sql exception
        try
        {


            foreach (GridViewRow row in GridView1.Rows)
            {
                // Regex tagMatch = new Regex("<[^>]+>");
                // gets the text of the control from the gridview
                quantity = (TextBox)row.FindControl("txtQuantity");
                itemID = (Label)row.FindControl("lblItemIDHidden");
                orderID = (Label)row.FindControl("lblOrderIDHidden");
                minQuantity = (Label)row.FindControl("lblMinQuantityAnswer");
                quantityAvailable = (Label)row.FindControl("lblQuantityAvailableAnswer");
                price = (Label)row.FindControl("lblPrice");
                totalIndividualItem = (Label)row.FindControl("lblTotaIndividualPrice");
                vendorID = (Label)row.FindControl("lblVendorIDHidden");
                // make text from labels double types
                addPrice = double.Parse(price.Text, System.Globalization.NumberStyles.Currency);

                // quantityAvailable.Text = tagMatch.Replace(quantityAvailable.Text, "");
                //  strText = tagMatch.Replace(strText, "");


                minQuantityInt = int.Parse(minQuantity.Text, System.Globalization.NumberStyles.Integer);
                quantityAvailableInt = int.Parse(quantityAvailable.Text, System.Globalization.NumberStyles.Integer);
                quantityInt = int.Parse(quantity.Text, System.Globalization.NumberStyles.Integer);

                double TotalPrice = addPrice * quantityInt;




                // call method to validate quantity amount
                ValidateQuantity(minQuantityInt, quantityAvailableInt, quantityInt);

                if (quantityInt < minQuantityInt || quantityInt > quantityAvailableInt || quantityInt < 1)
                {
                    quantity.BackColor = Color.Red;

                }
                else
                {
                    // set quantity color back to original color
                    quantity.BackColor = Color.White;
                }


                if (totalCount < 1)
                {



                    // calculate total price for each individual item

                    OrderItem orderItem = new OrderItem();
                    orderItem.OrderId = int.Parse(orderID.Text);
                    orderItem.ItemId = itemID.Text;
                    orderItem.VendorId = int.Parse(vendorID.Text);
                    orderItem.TotalPrice = decimal.Parse(TotalPrice.ToString("n2"));
                    orderItem.Quantity = int.Parse(quantity.Text);

                    OrderItemDA orderItemDA = new OrderItemDA();

                    //Save the Objects to the Database
                    orderItemDA.Save(orderItem);


                    //DAL.DataAccess da =
                    //new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                    //         "System.Data.SqlClient");

                    //string comm =
                    //    "UPDATE OrderItem SET TotalPrice = @totalPrice, Quantity = @quantity WHERE ItemID = @itemID AND OrderID = @orderID AND VendorID = @vendorID";

                    //// array with quantity, itemID, orderiD, vendorID, and totalPrice
                    //string[] p = { "@quantity", "@itemID", "@orderID", "@vendorID", "@totalPrice" };
                    //string[] v = {
                    //                 quantity.Text, itemID.Text, orderID.Text, vendorID.Text, TotalPrice.ToString("n2")
                    //             };


                    //da.ExecuteNonQuery(comm, p, v);

                    // clear
                    orderItem = null;
                    orderItemDA = null;



                    // add to total to calculate total 
                    total += addPrice * Convert.ToDouble(quantity.Text);

                    // access the checkbox
                    CheckBox cb = (CheckBox)row.FindControl("ItemSelector");
                    if (cb != null && cb.Checked)
                    {

                        // delete item with specific itemID, orderId, and vendorId
                        //OrderItem myOrderItemDelete = new OrderItem();

                        //myOrderItemDelete.ItemId = itemID.Text;
                        //myOrderItemDelete.OrderId = Convert.ToInt32(orderID.Text);
                        //myOrderItemDelete.VendorId = Convert.ToInt32(vendorID.Text);

                        //OrderItemDA orderItemDADelete = new OrderItemDA();
                        //orderItemDADelete.Delete(myOrderItemDelete);

                        DAL.DataAccess da3 =
                       new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                          "System.Data.SqlClient");

                        string comm3 =
                            "Delete FROM OrderItem WHERE ItemID = @itemID AND OrderID = @orderID AND VendorID = @vendorID";

                        // array with itemID, orderID, and vendorID
                        string[] p3 = { "@itemID", "@orderID", "@vendorID" };
                        string[] v3 = { itemID.Text, orderID.Text, vendorID.Text };


                        da3.ExecuteNonQuery(comm3, p3, v3);

                        // clear
                        p3 = null;
                        v3 = null;
                    }
                    // bind repeater and gridview
                    BindGridRepeater();
                }




                if (totalCount < 1)
                {
                    // update total of orders table for the customer
                    DAL.DataAccess da2 =
                        new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                           "System.Data.SqlClient");

                    string comm2 =
                        "UPDATE Orders SET GrossTotal = @grossTotal, Tax = @tax, NetTotal = @netTotal WHERE OrderID = @orderID AND CustomerID = @customerID";

                    string calculateTax = CalculateTax(total, tax).ToString("n2");
                    string calculateTotal = CalculateTotal(total, double.Parse(calculateTax));

                    // empty array
                    string[] p2 = { "@grossTotal", "@orderID", "@customerID", "@txnID", "@tax", "@netTotal" };
                    string[] v2 = { calculateTotal, orderID.Text, GetCustomerID(), "", calculateTax, total.ToString("n2") };


                    da2.ExecuteNonQuery(comm2, p2, v2);

                    // clear
                    p2 = null;
                    v2 = null;



                    // bind gridview and repeater to show changes
                    BindGridRepeater();

                    // redirect using if page ispost back so when user deletes
                    // items from shopping cart grosstotal, tax, and nettotal get updated.
                    //if (Page.IsPostBack)
                    //{
                    //    Response.Redirect("CheckOut.aspx?OrderReview=true");
                    //    // UpdateQuantity();
                    //    //Response.AppendHeader("Refresh", "0;URL=CheckOut.aspx?OrderReview=true");
                    //}



                }


            }


        }
        catch (FormatException ex)
        {

            lblError.Text = "Shopping Cart could not be updated: quantity must not have alphabetical characters, special characters, and periods, or be left blank.";
        }
        catch (SqlException ex)
        {

            lblError.Text = "Please contact your network administrator.";
        }
    }



    private void BindGridRepeater()
    {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated || Session["AnonymousUserName"] != null)
        {


            // fill up gridview
            // instantiate class
            DAL.DataAccess da =
                new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                   "System.Data.SqlClient");

            // sql command
            string comm =
                "SELECT Orders.OrderID, Orders.CustomerID, OrderItem.ItemID, OrderItem.Price, OrderItem.TotalPrice, OrderItem.Quantity, Items.ItemID, Items.ProductName, Items.Description, Items.PhotoLocation, Items.QuantityAvailable, Items.MinQuantity, Items.VendorID FROM Orders, OrderItem, Items WHERE Orders.OrderID = OrderItem.OrderID and OrderItem.ItemID = Items.ItemID and Orders.CustomerID = @customerID AND Orders.TXNID = @txnID";

            // data set
            DataSet ds = new DataSet();

            // empty array
            string[] p = { "@customerID", "@txnID" };
            string[] v = { GetCustomerID(), "" };

            ds = da.ExecuteQuery(comm, p, v);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

            // clear
            p = null;
            v = null;


            // fill up repeater
            // instantiate class

            Order order = new Order();
            order.CustomerId = int.Parse(GetCustomerID());
            order.TxnId = "";
            OrderDA orderDA = new OrderDA();
            Collection<Order> getOrder = orderDA.Get(order);



            rptOne.DataSource = getOrder;
            rptOne.DataBind();

            // clear
            p = null;
            v = null;
        }
        else
        {
            items.InnerHtml = "<h1>" + "Your Shopping Cart is Empty." + "</h1>";
        }


    }

    // calculates total plus tax
    private string CalculateTotal(double total, double tax)
    {



        if (tax == 0.0)
        {
            return total.ToString("n2");
        }


        return (tax + total).ToString("n2");



    }

    // calculates tax only
    private double CalculateTax(double total, double tax)
    {



        double totalTax = 0.000;


        if (GetState() == "")
        {
            // do nothing
        }
        // get shipping from billing page
        else if (GetState() == "AZ")
        {
            // 2009 sales tax 6.1%
            // can charge up to 6 percent more
            totalTax = total * 0.061;

        }

        return totalTax;




    }


    private void ValidateQuantity(int minQuantityInt, int quantityAvailableInt, int quantityInt)
    {

        if (totalCount < 1)
        {
            if (quantityInt < minQuantityInt || quantityInt > quantityAvailableInt || quantityInt < 1)
            {
                // count
                count++;
                totalCount = count++;

                lblQuantityError.Text = "<br />" +
                "Shopping Cart couldn't be updated: quantity cannot be less than minimum quantity, quantity cannot be less than 1, and  quantity cannot be greater than quantity available" +
                ".";

            }



            else
            {
                lblError.Text = "";
            }
        }


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
            Order orders = new Order();
            orders.CustomerId = getCustomer[0].Id;
            orders.TxnId = "";

            OrderDA orderDA = new OrderDA();
            Collection<Order> getOrders = orderDA.Get(orders);



            // returns number of orders
            object getOrder = getOrders.Count;


            //clear
            orders = null;
            orderDA = null;
            getOrders = null;


            // if the user who is logged has items in his cart as an anonymous user
            // delete the items he had previously on his cart and add the new items and order
            // that they just put into his cart
            if (int.Parse(getOrder.ToString()) > 0)
            {





                // get the orderID of the customer that he had on going order
                // instantiate class
                Order oID = new Order();
                oID.CustomerId = getCustomer[0].Id;
                oID.TxnId = "";

                OrderDA ordersDA = new OrderDA();
                Collection<Order> getOID = ordersDA.Get(oID);



                // returns one item
                object getOrderID = getOID[0].Id;


                //clear
                oID = null;
                ordersDA = null;
                getOID = null;



                // delete the order and items that involve the order above 
                // delete items from the orderItem table associated with that order if any

                //Create an Object that specifies what we want to Get
                // OrderItem deleteOrderItem = new OrderItem(); 

                //OrderItemDA deleteOrderItemDA = new OrderItemDA();

                ////gets orderItem info based on customerID

                //deleteOrderItem.OrderId = int.Parse(getOrderID.ToString());

                //// deletes the orderItems with that customerID
                //deleteOrderItemDA.Delete(deleteOrderItem);

                //// clear
                //deleteOrderItemDA = null;
                //deleteOrderItem = null;
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




                // delete order
                //Instantiate our Order specific DataAccess Class
                OrderDA deleteOrderDA = new OrderDA();

                //Create an Object that specifies what we want to Get
                Order deleteOrder = new Order();

                //gets order info based on customerID

                deleteOrder.Id = int.Parse(getOrderID.ToString());

                // deletes the order with that customerID
                deleteOrderDA.Delete(deleteOrder);


                // clear
                deleteOrderDA = null;
                deleteOrder = null;




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
                //Create an Object that specifies what we want to Get
                Order ordersID = new Order();

                //gets order info based on customerID
                ordersID.CustomerId = getCustomer2[0].Id;
                ordersID.TxnId = "";

                OrderDA ordersIDDA = new OrderDA();


                // deletes the order with that customerID
                Collection<Order> getOrder2 = ordersIDDA.Get(ordersID);



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
                OrderDA ordersIDDA = new OrderDA();


                //Create an Object that specifies what we want to Get
                Order ordersID = new Order();

                //gets order info based on customerID

                ordersID.CustomerId = getCustomer2[0].Id;

                // deletes the order with that customerID
                Collection<Order> getOrder2 = ordersIDDA.Get(ordersID);


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



                // delete anonymous customer from customer table
                Customer customers = new Customer();
                customers.Id = getCustomer2[0].Id;

                CustomerDA customersDA = new CustomerDA();

                customersDA.Delete(customers);

                // clear
                customers = null;
                customersDA = null;

                //DAL.DataAccess da8 =
                //                                 new DAL.DataAccess(
                //                                         ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                //                                         "System.Data.SqlClient");

                //string comm8 =
                //    "Delete FROM Customer WHERE CustomerID = @customerID";

                //// array with customerID
                //string[] p8 = { "@customerID" };
                //string[] v8 = { getCustomer2[0].Id.ToString() };


                //da8.ExecuteNonQuery(comm8, p8, v8);

                //// clear
                //p8 = null;
                //v8 = null;

                //abandon session
                Session.Abandon();
                Session.Clear();
            }

        }


        // when user logs in redirect them
        Response.Redirect("~/CheckOut.aspx?Shipping=true");

    }

    protected void btnSubmitDetails_Click(object sender, EventArgs e)
    {


        // update info for anonymous users of orders table for the customer / anonymous user

        Customer customers = new Customer();
        customers.Id = int.Parse(GetCustomerID());
        customers.FirstName = txtFirstName.Text;
        customers.LastName = txtLastName.Text;
        customers.Address = txtAddress1.Text;
        customers.Address2 = txtAddress2.Text;
        customers.City = txtCity.Text;
        customers.State = ddlState.SelectedItem.Text;
        customers.Zip = txtZipCode.Text;
        customers.Country = ddlCountry.SelectedItem.Text;

        CustomerDA customersDA = new CustomerDA();

        customersDA.Save(customers);



        //DAL.DataAccess da1 =
        //    new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
        //                       "System.Data.SqlClient");

        //string comm1 =
        //    "UPDATE Customer SET FName = @fName, LName = @lName, Address = @address, Address2 = @address2, City = @city, State = @state, Zip = @zip, Country = @country  WHERE CustomerID = @customerID";

        //// empty array
        //string[] p1 = { "@fName", "@lName", "@address", "@address2", "@city", "@state", "@zip", "@country", "@customerID" };
        //string[] v1 = { txtFirstName.Text, txtLastName.Text, txtAddress1.Text, txtAddress2.Text, txtCity.Text, ddlState.SelectedItem.Text, txtZipCode.Text, ddlCountry.SelectedItem.Text, GetCustomerID() };


        //da1.ExecuteNonQuery(comm1, p1, v1);

        // clear
        customers = null;
        customersDA = null;


        // redirect the user       
        Response.Redirect("~/CheckOut.aspx?OrderReview=true");
    }

    protected void GetShippingInformation()
    {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated || Session["AnonymousUserName"] != null)
        {

            //gets customer info based on customer id


            Customer customer = new Customer();


            customer.Id = int.Parse(GetCustomerID());

            CustomerDA customerDA = new CustomerDA();

            //We will be returned a collection so lets Declare that and fill it using Get()
            Collection<Customer> getCustomer = customerDA.Get(customer);

            // makes sure vales are not empty to avoid nullreference exception
            if (getCustomer[0].FirstName != "")
            {
                txtFirstName.Text = getCustomer[0].FirstName;
            }

            if (getCustomer[0].LastName != "")
            {
                txtLastName.Text = getCustomer[0].LastName;
            }

            if (getCustomer[0].Address != "")
            {
                txtAddress1.Text = getCustomer[0].Address;
            }
            if (getCustomer[0].Address2 != "")
            {
                txtAddress2.Text = getCustomer[0].Address2;
            }

            if (getCustomer[0].City != "")
            {
                txtCity.Text = getCustomer[0].City;
            }

            if (getCustomer[0].State != "")
            {
                ddlState.Text = getCustomer[0].State;
            }
            if (getCustomer[0].Zip != "")
            {
                txtZipCode.Text = getCustomer[0].Zip;
            }

            if (getCustomer[0].Country != "")
            {
                ddlCountry.Text = getCustomer[0].Country;
            }
        }
    }

    // if shipping details are empty redirect the user to shipping=true
    public void EmptyShippingInfo()
    {
        // makes sure vales are not empty to avoid nullreference exception
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated || Session["AnonymousUserName"] != null)
        {
            //Instantiate our customer specific DataAccess Class
            CustomerDA customerDA = new CustomerDA();

            // check to see if user has items in their cart
            //Create an Object that specifies what we want to Get
            Customer customer = new Customer();

            //gets customer info based on customer id

            customer.Id = int.Parse(GetCustomerID());

            //We will be returned a collection so lets Declare that and fill it using Get()
            Collection<Customer> getCustomer = customerDA.Get(customer);

            // makes sure vales are not empty to avoid nullreference exception
            if (getCustomer[0].FirstName == "")
            {
                Response.Redirect("CheckOut.aspx?Shipping=true");
            }

            if (getCustomer[0].LastName == "")
            {
                Response.Redirect("CheckOut.aspx?Shipping=true");
            }

            if (getCustomer[0].Address == "")
            {
                Response.Redirect("CheckOut.aspx?Shipping=true");
            }
            if (getCustomer[0].Address2 == "")
            {
                Response.Redirect("CheckOut.aspx?Shipping=true");
            }

            if (getCustomer[0].City == "")
            {
                Response.Redirect("CheckOut.aspx?Shipping=true");
            }

            if (getCustomer[0].State == "")
            {
                Response.Redirect("CheckOut.aspx?Shipping=true");
            }
            if (getCustomer[0].Zip == "")
            {
                Response.Redirect("CheckOut.aspx?Shipping=true");
            }

            if (getCustomer[0].Country == "")
            {
                Response.Redirect("CheckOut.aspx?Shipping=true");
            }
        }
    }

    // method for binding RPTShipping
    private void BindRPTShipping()
    {
        //Instantiate our Category specific DataAccess Class
        CustomerDA customerDA = new CustomerDA();

        // check to see if user has items in their cart
        //Create an Object that specifies what we want to Get
        Customer customer = new Customer();

        //gets customer info based on customer id

        customer.Id = int.Parse(GetCustomerID());

        //We will be returned a collection so lets Declare that and fill it using Get()
        Collection<Customer> getCustomer = customerDA.Get(customer);

        rptShippingAddress.DataSource = getCustomer;
        rptShippingAddress.DataBind();

    }

    // gets state of user that is logged in or has a session to calculate the tax
    public string GetState()
    {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated || Session["AnonymousUserName"] != null)
        {
            //Instantiate our Category specific DataAccess Class
            CustomerDA customerDA = new CustomerDA();

            // check to see if user has items in their cart
            //Create an Object that specifies what we want to Get
            Customer customer = new Customer();

            //gets customer info based on customer id

            customer.Id = int.Parse(GetCustomerID());

            //We will be returned a collection so lets Declare that and fill it using Get()
            Collection<Customer> getCustomer = customerDA.Get(customer);

            return getCustomer[0].State;
        }

        return "";

    }

    // on user created
    // get the customerid of the user who is making an account
    // register user using the customerID
    // redirect user to shipping
    protected void ReconfigureOrder(object sender, EventArgs e)
    {

        if (Session["AnonymousUserName"] != null)
        {

            // get customerid of user to use customer id
            // for updating user information

            //Instantiate our customer specific DataAccess Class
            CustomerDA customerDA = new CustomerDA();


            //Create an Object that specifies what we want to Get
            Customer customer = new Customer();

            //gets customer info based on customer username

            customer.Username = Session["AnonymousUserName"].ToString();

            //We will be returned a collection so lets Declare that and fill it using Get()
            Collection<Customer> getCustomer = customerDA.Get(customer);



            TextBox userName =
               (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("UserName");

            TextBox firstName =
                (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtFirstName");

            TextBox lastName =
                (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtLastName");
            TextBox address =
                       (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtAddress");
            TextBox address2 =
                       (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtAddress2");
            TextBox city =
                       (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtCity");
            DropDownList state =
                       (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboState");
            TextBox zipCode =
                       (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtZip");
            DropDownList country =
                       (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboCountry");


            // update customer information      
            Customer customerShipping = new Customer();
            customerShipping.Id = getCustomer[0].Id;
            customerShipping.IsActive = true;
            customerShipping.Username = userName.Text;
            customerShipping.FirstName = firstName.Text;
            customerShipping.LastName = lastName.Text;
            customerShipping.Address = address.Text;
            customerShipping.Address2 = address2.Text;
            customerShipping.City = city.Text;
            customerShipping.State = state.Text;
            customerShipping.Zip = zipCode.Text;
            customerShipping.Country = country.Text;


            //Instantiate our customer specific DataAccess Class
            CustomerDA customerDAShipping = new CustomerDA();


            // save customer information
            customerDAShipping.Save(customerShipping);

            // clear
            customerShipping = null;
            customerDAShipping = null;


            // LogIn User
            System.Web.Security.FormsAuthentication.SetAuthCookie(userName.Text, false);


            //abandon session
            Session.Abandon();
            Session.Clear();

            // redirect user to shipping=true
            Response.Redirect("CheckOut.aspx?Shipping=true");





        }




    }


    // retrieves customerID of anonymous and customer 
    public string GetCustomerID()
    {

        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {

            // get the customerID of the user who is logged on
            Customer customerIDID = new Customer();
            customerIDID.Username = User.Identity.Name;
            CustomerDA customerIDDA = new CustomerDA();

            Collection<Customer> getCustomers3 = customerIDDA.Get(customerIDID);

            customerID = getCustomers3[0].Id;


            // clear
            customerIDID = null;
            customerIDDA = null;
            getCustomers3 = null;


            return customerID.ToString();
        }
        else
        {
            // get the customerID of the user who is logged on
            // get the customerID of the user who is logged on
            Customer customerIDID = new Customer();
            customerIDID.Username = Session["AnonymousUserName"].ToString();

            CustomerDA customerIDDA = new CustomerDA();

            Collection<Customer> getCustomers3 = customerIDDA.Get(customerIDID);

            customerID = getCustomers3[0].Id;

            // clear
            customerIDID = null;
            customerIDDA = null;
            getCustomers3 = null;

            return customerID.ToString();
        }


    }

}
