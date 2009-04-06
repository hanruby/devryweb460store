using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
/**
 * Author: Daniel Aguayo
 * 
 */
public partial class ShoppingCart : System.Web.UI.Page
{


    // attributes
    public bool isEditMode = false;

    private TextBox quantity;
    private Label minQuantity;
    private Label quantityAvailable;
    private Label itemID;
    private Label orderID;
    private Label vendorID;

    private Label totalIndividualItem;

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


        if (!Page.IsPostBack)
        {
            // fill up state dropdownlist
            string[] states = {"AL","AK","AS","AZ","AR","CA","CO","CT","DE","DC"
            ,"FM","FL","GA","GU","HI","ID","IL","IN","IA","KS","KY","LA","ME",
            "MH","MD","MA","MI","MN","MS","MO","MT","NE","NV","NH","NJ","NM","NY",
            "NC","ND","MP","OH","OK","OR","PW","PA","PR","RI","SC","SD","TN","TX",
            "UT","VT","VI","VA","WA","WV","WI","WY"};

            ddlState.DataSource = states;
            ddlState.DataBind();






            // fill up the gridview with customer's order info
            BindGridView();

            // fill up the repeater with cusotmer's order info
            BindRepeater();



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
                lblState.Visible = true;
                ddlState.Visible = true;
                btnUpdateQuantity.Visible = true;
                btnEditQuantity.Visible = true;
                btnProceed.Visible = true;


                // update gridview
                UpdateQuantity();

            }
            else
            {
                rptOne.Visible = false;
                lblState.Visible = false;
                ddlState.Visible = false;      
                btnUpdateQuantity.Visible = false;
                btnEditQuantity.Visible = false;
                btnProceed.Visible = false;
            }
            //end
        }






        // delete item with specific item ID and CustomerID 
        if (Request.QueryString["Delete"] == "true" && Request.QueryString["Delete"] != null)
        {
            // deletes orderItem from shopping cart
            DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

            string comm = "Delete FROM OrderItem WHERE ItemID = @itemID AND OrderID = @orderID AND VendorID = @vendorID";

            // array with itemID, orderID, and vendorID
            string[] p = { "@itemID", "@orderID", "@vendorID" };
            string[] v = { Request.QueryString["IID"], Request.QueryString["OID"], Request.QueryString["VID"] };


            da.ExecuteNonQuery(comm, p, v);

            // clear
            p = null;
            v = null;

            // call method to update the entire cart
            UpdateQuantity();

            Response.Redirect("ShoppingCart.aspx");
        }







    }

    // button to go to Edit Mode
    protected void btnEditQuantity_Click(object sender, EventArgs e)
    {
        // set edit mode to true and call BindData
        isEditMode = true;
        BindGridView();
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

                if (totalCount == 0)
                {
                    // call method to validate quantity amount
                    ValidateQuantity(minQuantityInt, quantityAvailableInt, quantityInt);
                }
                if (totalCount < 1)
                {
                    // calculate total price for each individual item
                    //   double totalPrice = totalIndividualItemPrice*int.Parse((quantity.Text));

                    DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    string comm = "UPDATE OrderItem SET TotalPrice = @totalPrice, Quantity = @quantity WHERE ItemID = @itemID AND OrderID = @orderID AND VendorID = @vendorID";

                    // array with quantity, itemID, orderiD, vendorID, and totalPrice
                    string[] p = { "@quantity", "@itemID", "@orderID", "@vendorID", "@totalPrice" };
                    string[] v = { quantity.Text, itemID.Text, orderID.Text, vendorID.Text, TotalPrice.ToString("n2") };


                    da.ExecuteNonQuery(comm, p, v);

                    // clear
                    p = null;
                    v = null;

                    // add the total
                    total += addPrice * Convert.ToDouble(quantity.Text);

                }

            }

            // update total of orders table for the customer
            DAL.DataAccess da2 = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

            string comm2 = "UPDATE Orders SET GrossTotal = @grossTotal, Tax = @tax, NetTotal = @netTotal WHERE OrderID = @orderID AND CustomerID = @customerID";

            string calculateTax = CalculateTax(total, tax).ToString("n2");
            string calculateTotal = CalculateTotal(total, double.Parse(calculateTax));

            // empty array
            string[] p2 = { "@grossTotal", "@orderID", "@customerID", "@txnID", "@tax", "@netTotal" };
            string[] v2 = { calculateTotal, orderID.Text, "1", "", calculateTax, total.ToString("n2") };


            da2.ExecuteNonQuery(comm2, p2, v2);

            // clear
            p2 = null;
            v2 = null;


            // set isEditMode to false and 
            // bind gridview and repeater to show changes
            isEditMode = false;
            BindGridView();
            BindRepeater();
        }
        catch (FormatException ex)
        {

            Alert.Show("Error: Either 1.) Quantity is not a number. 2.) Quantity was left blank.");
        }
        catch (SqlException ex)
        {
            // nothing?
            Alert.Show("Please contact our network administrator.");
        }
    }

    private void BindGridView()
    {
        // instantiate class
        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        // sql command

        string comm =
            "SELECT Orders.OrderID, Orders.CustomerID, Orders.TXNID, OrderItem.ItemID, OrderItem.Price, OrderItem.TotalPrice, OrderItem.Quantity, Items.ItemID, Items.ProductName, Items.Description, Items.PhotoLocation, Items.QuantityAvailable, Items.MinQuantity, Items.VendorID FROM Orders, OrderItem, Items WHERE Orders.OrderID = OrderItem.OrderID and OrderItem.ItemID = Items.ItemID and Orders.CustomerID = @customerID AND Orders.TXNID = @txnID AND Orders.CustomerID = @customerID";

        // data set
        DataSet ds = new DataSet();

        // empty array
        string[] p = { "@customerID", "@txnID" };
        string[] v = { "1", "" };

        ds = da.ExecuteQuery(comm, p, v);

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

        // clear
        p = null;
        v = null;
    }

    public void BindRepeater()
    {
        // instantiate class
        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        // sql command
        string comm = "SELECT OrderID, CustomerID, GrossTotal, Tax, NetTotal, OrderID FROM Orders WHERE CustomerID = @customerID AND TXNID = @txnID";

        // data set
        DataSet ds = new DataSet();

        // empty array
        string[] p = { "@customerID", "@txnID" };
        string[] v = { "1", "" };

        ds = da.ExecuteQuery(comm, p, v);

        rptOne.DataSource = ds.Tables[0];
        rptOne.DataBind();

        // clear
        p = null;
        v = null;

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
        //// check to see what state user is in
        //DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        //string comm = "SELECT Customer.CustomerID, aspnet_Users.UserName, Customer.UserName FROM Customer INNER JOIN Customer ON aspnet_Users.UserName = Customer.UserName WHERE UserName = @userName";

        //// empty array
        //string[] p = { "@UserName" };
        //string[] v = { "usernamegoeshere" };

        //da.ExecuteNonQuery(comm, p, v);

        //// clear
        //p = null;
        //v = null;

        double totalTax;

        if (ddlState.SelectedItem.Text == "AZ")
        {
            totalTax = total * 0.08;

        }
        else
        {
            totalTax = 0.00;
        }

        return totalTax;
    }

    private void ValidateQuantity(int minQuantityInt, int quantityAvailableInt, int quantityInt)
    {



        if (quantityInt < minQuantityInt || quantityInt > quantityAvailableInt || quantityInt < 1)
        {
            count++;

            totalCount = count++;

            Alert.Show("Error: 1.) Either quantity is less than minimum quantity. 2.) Quantity is less than 1. 3.) Quantity is greater than quantity available.");

        }



    }

    // properties for IsEditMode
    protected bool IsInEditMode
    {

        get { return this.isEditMode; }

        set { this.isEditMode = value; }

    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        Response.Redirect("CheckOut.aspx");
    }

}
