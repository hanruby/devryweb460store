using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessModule;

public partial class ViewOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Request.QueryString["OrderID"] != "" && Request.QueryString["OrderID"] != null)
        {
            lblNoOrder.Text = "There is no Order for that ID";
            lblNoOrder.Visible = false;

            Order o = new Order();
            OrderDA oDA = new OrderDA();

            Customer c = new Customer();
            OrderItem oi = new OrderItem();
            OrderTracking ot = new OrderTracking();
            Item i = new Item();

            string oid = Request.QueryString["OrderID"];

            o.Id = int.Parse(oid);
            Collection<Order> col_o = oDA.Get(o);

            Repeater1.DataSource = col_o;
            Repeater1.DataBind();


            //string s1;
            //string s2;
            //string[] p1 = { "@OrderID" };
            //string oid = Request.QueryString["OrderID"];

            //DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");
            //DataSet ds = new DataSet();

            //s1 = "SELECT c.FName,c.LName,o.GrossTotal,o.Tax,o.NetTotal " +
            //    "FROM dbo.ORDERS o " +
            //    "INNER JOIN dbo.Customer c on o.CustomerID = c.CustomerID " +
            //    "WHERE o.OrderID = @OrderID";

            //s2 = "SELECT i.Description,oi.Quantity,oi.Price,ot.TrackingURL,ot.ShipDate,ot.EstArrival " +
            //    "FROM dbo.ORDERS o " +
            //    "INNER JOIN dbo.OrderItem oi ON o.OrderID = oi.OrderID " +
            //    "LEFT OUTER JOIN dbo.OrderTracking ot on oi.OrderID = ot.OrderID and oi.ItemID = ot.ItemID and oi.VendorID = ot.VendorID " +
            //    "INNER JOIN dbo.Items i on i.ItemID = oi.ItemID and i.VendorID = oi.VendorID " +
            //    "WHERE o.OrderID = @OrderID";

            //string[] v1 = { oid };

            //ds = da.ExecuteQuery(s1, p1, v1);

            //FormView1.DataSource = ds.Tables[0];
            //if (ds.Tables[0].Rows.Count == 0)
            //{
            //    lblNoOrder.Visible = true;
            //}
            //else
            //{
            //    FormView1.DataBind();
            //}
            //FormView1.DataBind();

            //ds = da.ExecuteQuery(s2, p1, v1);
            //Repeater1.DataSource = ds.Tables[0];
            //Repeater1.DataBind();

        }
    }
    protected void btnLookUp_Click(object sender, EventArgs e)
    {

        Order o = new Order();
        OrderDA oDA = new OrderDA();
        Customer c = new Customer();
        CustomerDA cDA = new CustomerDA();
        OrderItem oi = new OrderItem();
        OrderItemDA oiDA = new OrderItemDA();
        OrderTracking ot = new OrderTracking();
        OrderTrackingDA otDA = new OrderTrackingDA();
        Item i = new Item();
        ItemDA iDA = new ItemDA();

        int oid = int.Parse(txtOrderID.Text);

        o.Id = oid;
        Collection<Order> col_o = oDA.Get(o);

        c.Id = Convert.ToInt32(col_o[0].CustomerId);
        Collection<Customer> col_c = cDA.Get(c);

        oi.OrderId = oid;
        Collection<OrderItem> col_oi = oiDA.Get(oi);

        //i.Id = col_oi[0].ItemId; // Get first item id
        //Collection<Item> col_i = iDA.Get(i); // Add item to collection

        for (int x = 0; x <= col_oi.Count; x++)
        {
            i.Id = col_oi[x].ItemId;
            //col_i.Add(iDA.Get(i)); //Error: cannot convert from 'System.Collections.ObjectmOdel.Collection<DataAccessModule.Item>' to 'DataAccessModule.Item>'
        }




        FormView1.DataSource = col_c;
        FormView1.DataBind();

        Repeater1.DataSource = col_o;
        Repeater1.DataBind();

        //string s1;
        //string s2;
        //string s3;
        //string[] p1 = {"@OrderID"};
        //string customers_username = "";

        //lblNoOrder.Text = "There is no Order for that ID";
        //lblNoOrder.Visible = false;

        //DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");
        //DataSet ds = new DataSet();

        //s1 = "SELECT c.FName,c.LName,o.GrossTotal,o.Tax,o.NetTotal " +
        //    "FROM dbo.ORDERS o " +
        //    "INNER JOIN dbo.Customer c on o.CustomerID = c.CustomerID " +
        //    "WHERE o.OrderID = @OrderID";

        //s2 = "SELECT i.Description,oi.Quantity,oi.Price,ot.TrackingURL,ot.ShipDate,ot.EstArrival " +
        //    "FROM dbo.ORDERS o " +
        //    "INNER JOIN dbo.OrderItem oi ON o.OrderID = oi.OrderID " +
        //    "LEFT OUTER JOIN dbo.OrderTracking ot on oi.OrderID = ot.OrderID and oi.ItemID = ot.ItemID and oi.VendorID = ot.VendorID " +
        //    "INNER JOIN dbo.Items i on i.ItemID = oi.ItemID and i.VendorID = oi.VendorID " +
        //    "WHERE o.OrderID = @OrderID";
        
        //s3 = "SELECT DISTINCT c.UserName FROM dbo.ORDERS o " +
        //    "INNER JOIN dbo.Customer c on o.CustomerID = c.CustomerID " +
        //    "WHERE o.OrderID = @OrderID";

        //string[] v1 = { txtOrderID.Text };

        //ds = da.ExecuteQuery(s3, p1, v1);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    customers_username = ds.Tables[0].Rows[0]["UserName"].ToString();
        //}

        //if (CheckAuth(customers_username) == true)
        //{
        //    ds = da.ExecuteQuery(s1, p1, v1);

        //    FormView1.DataSource = ds.Tables[0];
        //    if (ds.Tables[0].Rows.Count == 0)
        //    {
        //        lblNoOrder.Visible = true;
        //    }
        //    else
        //    {
        //        FormView1.DataBind();
        //    }
        //    FormView1.DataBind();

        //    ds = da.ExecuteQuery(s2, p1, v1);
        //    Repeater1.DataSource = ds.Tables[0];
        //    Repeater1.DataBind();
        //}
        //else
        //{
        //    lblNoOrder.Text = "You are not authorized to view this order";
        //    lblNoOrder.Visible = true;
        //}
    }

    private bool CheckAuth(string p_CustomerUserNameOfOrder)
    {
        bool auth = false;
        
        if (User.IsInRole("Administrator"))
        {
            auth = true;
        }
        else if (User.ToString() == p_CustomerUserNameOfOrder)
        {
            auth = true;
        }

        return auth;
    }
}
