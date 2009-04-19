using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessModule;
/**
 * Author: Daniel Aguayo
 * 
 */
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

            // display number
            AddNumber();

            if (rpShoppingCartItems.Items.Count > 0)
            {

                // clear shoppingcartitems label
                lblNoShoppingCartItems.Text = "";

                // delete item with specific itemID, orderID, and VendorID 
                if (Request.QueryString["Delete"] == "true" && Request.QueryString["Delete"] != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated || Session["AnonymousUserName"] != null)
                {
                    try
                    {


                        // deletes orderItem from shopping cart
                        OrderItem orderItem = new OrderItem();
                        orderItem.ItemId = Request.QueryString["IID"];
                        orderItem.OrderId = int.Parse(Request.QueryString["OID"]);
                        orderItem.VendorId = int.Parse(Request.QueryString["VID"]);

                        OrderItemDA orderItemDA = new OrderItemDA();

                        orderItemDA.Delete(orderItem);

                        // clear
                        orderItem = null;
                        orderItemDA = null;

                        // redirects back to previous page
                        Response.Redirect(Request.UrlReferrer.ToString());
                    }
                    catch (NullReferenceException)
                    {

                    }
                    catch (Exception)
                    {

                    }
                }
            }
            else
            {
                lblNoShoppingCartItems.Text = "Your shopping cart is empty.";
            }
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




    }

    // get customerID
    protected string GetCustomerID()
    {
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
        {


            // get the customerID of the user who is logged on
            Customer customer = new Customer();
            customer.Username = Membership.GetUser().UserName;
            CustomerDA customerDA = new CustomerDA();

            Collection<Customer> getCustomers = customerDA.Get(customer);

            customerID = getCustomers[0].Id;


            // clear
            customer = null;
            customerDA = null;


            return customerID.ToString();
        }
        else
        {
            // get the customerID of the user who is not logged on

            Customer customer = new Customer();
            customer.Username = Session["AnonymousUserName"].ToString();
            CustomerDA customerDA = new CustomerDA();

            Collection<Customer> getCustomers = customerDA.Get(customer);

            customerID = getCustomers[0].Id;


            // clear
            customer = null;
            customerDA = null;

            return customerID.ToString();
        }
    }


    private void AddNumber()
    {
        int count = 1;

        foreach (RepeaterItem item in rpShoppingCartItems.Items)
        {


            Label itemNumber = (Label)item.FindControl("lblItemNumber");

            itemNumber.Text = count++.ToString();
        }


    }
}
