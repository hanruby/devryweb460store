﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RightColumn : System.Web.UI.UserControl
{
    private object customerID;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            ////code for tablesorter ready gridviews
            //if (this.gvShoppingCartItems.Rows.Count > 0)
            //{
            //    gvShoppingCartItems.UseAccessibleHeader = true;
            //    gvShoppingCartItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            //    gvShoppingCartItems.FooterRow.TableSection = TableRowSection.TableFooter;

            //}
            //end

            // bind grid view
            BindGridRepeater();
        }
    }

    private void BindGridRepeater()
    {

        // joing orders, orderitem, and item tables
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

            rpShoppingCartItems.DataSource = ds.Tables[0];
            rpShoppingCartItems.DataBind();

            // clear
            p = null;
            v = null;



        }
        else
        {
            lblNoShoppingCartItems.Text = "Your shopping cart is empty.";
        }


    }

    // get customerID
    protected string GetCustomerID()
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
            string[] v5 = { Membership.GetUser().UserName };
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

}
