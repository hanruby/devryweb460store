using System;

using System.Data;
using System.Configuration;
using System.Drawing;

using System.Web.UI.WebControls;
using System.Data.SqlClient;

using DAL;

/**
 * Author: Daniel Aguayo
 * 
 */
public partial class ShoppingCart : System.Web.UI.Page
{


    // attributes


    private TextBox quantity;
    private Label minQuantity;
    private Label quantityAvailable;
    private Label itemID;
    private Label orderID;
    private Label vendorID;
    private Label totalIndividualItem;

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

        // clear labels
        lblQuantityError.Text = "";
        lblError.Text = "";



        if (!Page.IsPostBack)
        {


            // fill up the gridview with customer's order info
            BindGridRepeater();


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
                lbltax.Visible = true;
                btnUpdateQuantity.Visible = true;
                btnContinueShopping.Visible = true;
                btnProceed.Visible = true;


                // update gridview and repeater
                UpdateQuantity();

            }
            else
            {

                rptOne.Visible = false;
                lbltax.Visible = false;
                btnUpdateQuantity.Visible = false;
                //   btnContinueShopping.Visible = false;
                btnProceed.Visible = false;
            }
            //end




        }

    }

    protected void btnUpdateQuantity_Click(object sender, EventArgs e)
    {
        // call method to update the quantity, nettotal, grosstotal, totalprice
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

                //if (quantityInt < minQuantityInt || quantityInt > quantityAvailableInt || quantityInt < 1)
                //{
                //    quantity.BackColor = Color.Red;

                //}
                //else
                //{
                //    // set quantity color back to original color
                //    quantity.BackColor = Color.White;
                //}


                if (totalCount < 1)
                {



                    // calculate total price for each individual item
                    //   double totalPrice = totalIndividualItemPrice*int.Parse((quantity.Text));

                    DAL.DataAccess da =
                        new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                           "System.Data.SqlClient");

                    string comm =
                        "UPDATE OrderItem SET TotalPrice = @totalPrice, Quantity = @quantity WHERE ItemID = @itemID AND OrderID = @orderID AND VendorID = @vendorID";

                    // array with quantity, itemID, orderiD, vendorID, and totalPrice
                    string[] p = { "@quantity", "@itemID", "@orderID", "@vendorID", "@totalPrice" };
                    string[] v = {
                                         quantity.Text, itemID.Text, orderID.Text, vendorID.Text, TotalPrice.ToString("n2")
                                     };


                    da.ExecuteNonQuery(comm, p, v);

                    // clear
                    p = null;
                    v = null;

                    // add to total to calculate total 
                    total += addPrice * Convert.ToDouble(quantity.Text);

                    // access the checkbox
                    CheckBox cb = (CheckBox)row.FindControl("ItemSelector");
                    if (cb != null && cb.Checked)
                    {



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
                    BindGridRepeater();
                }
            }

            if (totalCount < 1)
            {
                // update total of orders table for the customer
                DAL.DataAccess da2 =
                    new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                       "System.Data.SqlClient");

                string comm2 =
                    "UPDATE Orders SET  Tax = @tax, NetTotal = @netTotal WHERE OrderID = @orderID AND CustomerID = @customerID AND TXNID = @txnid";

                // string calculateTax = CalculateTax(total, tax).ToString("n2");
                //  string calculateTotal = CalculateTotal(total, double.Parse(calculateTax));

                // empty array
                string[] p2 = { "@orderID", "@customerID", "@txnID", "@tax", "@netTotal" };
                string[] v2 = { orderID.Text, GetCustomerID(), "", "", total.ToString("n2") };


                da2.ExecuteNonQuery(comm2, p2, v2);

                // clear
                p2 = null;
                v2 = null;



                // bind gridview and repeater to show changes
                BindGridRepeater();

                //redirect using if page ispost back so when user deletes
                //items from shopping cart grosstotal, tax, and nettotal get updated.
                if (Page.IsPostBack)
                {
                    Response.Redirect(Request.RawUrl);
                    //  UpdateQuantity();
                    //  Response.AppendHeader("Refresh", "0;URL=ShoppingCart.aspx");
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
                "SELECT Orders.OrderID, Orders.CustomerID, Orders.TXNID, OrderItem.Price, OrderItem.TotalPrice, OrderItem.Quantity, Items.ItemID, Items.ProductName, Items.Description, Items.PhotoLocation, Items.QuantityAvailable, Items.MinQuantity, Items.VendorID FROM Orders, OrderItem, Items WHERE Orders.OrderID = OrderItem.OrderID and OrderItem.ItemID = Items.ItemID and Orders.CustomerID = @customerID AND Orders.TXNID = @txnID";

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
            DAL.DataAccess da2 =
                new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                   "System.Data.SqlClient");

            // sql command
            string comm2 =
                "SELECT OrderID, CustomerID, GrossTotal, Tax, NetTotal, OrderID FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";

            // data set
            DataSet ds2 = new DataSet();

            // empty array
            string[] p2 = { "@customerID", "@txnID" };
            string[] v2 = { GetCustomerID(), "" };

            ds2 = da2.ExecuteQuery(comm2, p2, v2);

            rptOne.DataSource = ds2.Tables[0];
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



    protected void btnProceed_Click(object sender, EventArgs e)
    {
        Response.Redirect("CheckOut.aspx?CheckOut=true");
    }



    private string GetCustomerID()
    {

        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {

            // get the customerID of the user who is logged on
            DAL.DataAccess da5 =
                new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                   "System.Data.SqlClient");

            // make command statement 
            string comm5 = "SELECT CustomerID FROM Customer WHERE UserName = @username";

            DataSet ds5 = new DataSet();


            // make arrays for paramaters and input
            string[] s5 = { "@username" };
            string[] v5 = { User.Identity.Name };
            ds5 = da5.ExecuteQuery(comm5, s5, v5);


            // returns one item
            customerID = ds5.Tables[0].Rows[0].ItemArray[0];


            //clear
            s5 = null;
            v5 = null;

            return customerID.ToString();
        }
        else
        {
            // get the customerID of the user who is logged on
            DAL.DataAccess da5 =
                new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                   "System.Data.SqlClient");

            // make command statement 
            string comm5 = "SELECT CustomerID FROM Customer WHERE UserName = @username";

            DataSet ds5 = new DataSet();


            // make arrays for paramaters and input
            string[] s5 = { "@username" };
            string[] v5 = { Session["AnonymousUserName"].ToString() };
            ds5 = da5.ExecuteQuery(comm5, s5, v5);


            // returns one item
            customerID = ds5.Tables[0].Rows[0].ItemArray[0];


            //clear
            s5 = null;
            v5 = null;

            return customerID.ToString();
        }


    }
    protected void btnContinueShopping_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }


}

