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

    // for calculating price method
    private Label price;
    private double addPrice;
    private double total;

    private int minQuantityInt;
    private int quantityAvailableInt;
    private int quantityInt;

    private int count;
    private int totalCount = 0;

    private string quantityWarning = "alert('Warning'): ";

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {
            // fill up the gridview with customer's order info
            BindGridView();


            // fill up the repeater with cusotmer's order info
            BindRepeater();
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
        // catch format exception and sql exception
        try
        {

            foreach (GridViewRow row in GridView1.Rows)
            {
                // Regex tagMatch = new Regex("<[^>]+>");

                quantity = (TextBox)row.FindControl("txtQuantity");
                itemID = (Label)row.FindControl("lblItemIDAnswer");
                orderID = (Label)row.FindControl("lblOrderIDHidden");
                minQuantity = (Label)row.FindControl("lblMinQuantityAnswer");
                quantityAvailable = (Label)row.FindControl("lblQuantityAvailableAnswer");
                price = (Label)row.FindControl("lblPrice");


                addPrice = double.Parse(price.Text, System.Globalization.NumberStyles.Currency);

                // quantityAvailable.Text = tagMatch.Replace(quantityAvailable.Text, "");
                //  strText = tagMatch.Replace(strText, "");

                minQuantityInt = int.Parse(minQuantity.Text, System.Globalization.NumberStyles.Integer);
                quantityAvailableInt = int.Parse(quantityAvailable.Text, System.Globalization.NumberStyles.Integer);
                quantityInt = int.Parse(quantity.Text, System.Globalization.NumberStyles.Integer);


                if (totalCount == 0)
                {
                    // call method to validate quantity amount
                    ValidateQuantity(minQuantityInt, quantityAvailableInt, quantityInt);
                }
                if (totalCount < 1)
                {
                    DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

                    string comm = "UPDATE OrderItem SET Quantity = @quantity WHERE ItemID = @itemID AND OrderID = @orderID";

                    // empty array
                    string[] p = { "@quantity", "@itemID", "@orderID" };
                    string[] v = { quantity.Text, itemID.Text, orderID.Text };


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

            string comm2 = "UPDATE Orders SET GrossTotal = @grossTotal, Tax = @tax WHERE OrderID = @orderID AND CustomerID = @customerID";

            string calculateTotal = CalculateTotal(total).ToString("n2");

            // empty array
            string[] p2 = { "@grossTotal", "@orderID", "@customerID", "@txnID", "@tax" };
            string[] v2 = { calculateTotal, orderID.Text, "1", "", CalculateTax(1.00).ToString() };


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
            "SELECT Orders.OrderID, Orders.CustomerID, Orders.TXNID, OrderItem.ItemID, OrderItem.Price, OrderItem.Quantity, Items.ItemID, Items.Description, Items.QuantityAvailable, Items.MinQuantity FROM Orders, OrderItem, Items WHERE Orders.OrderID = OrderItem.OrderID and OrderItem.ItemID = Items.ItemID and Orders.CustomerID = @customerID AND Orders.TXNID = @txnID AND Orders.CustomerID = @customerID";

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
        string comm = "SELECT Orders.OrderID, Orders.CustomerID, Orders.GrossTotal, Orders.Tax, Orders.NetTotal, OrderItem.OrderID FROM OrderItem INNER JOIN Orders ON Orders.OrderID = OrderItem.OrderID WHERE Orders.CustomerID = @customerID AND Orders.TXNID = @txnID";

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
    private double CalculateTotal(double total)
    {
        double tax = 2.00;


        return total + 3.00;
    }

    // calculates tax only
    private double CalculateTax(double tax)
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

        return tax;
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
