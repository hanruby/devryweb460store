using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ViewOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { lblNoOrder.Visible = false; }
    }
    protected void btnLookUp_Click(object sender, EventArgs e)
    {
        string s1;
        string s2;
        string[] p1 = {"@OrderID"};


        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");
        DataSet ds = new DataSet();

        s1 = "SELECT c.FName,c.LName,o.GrossTotal,o.Tax,o.NetTotal " +
            "FROM dbo.ORDERS o " +
            "INNER JOIN dbo.Customer c on o.CustomerID = c.CustomerID " +
            "WHERE o.OrderID = @OrderID";

        s2 = "SELECT i.Description,oi.Quantity,oi.Price,ot.TrackingURL,ot.ShipDate,ot.EstArrival " +
            "FROM dbo.ORDERS o " +
            "INNER JOIN dbo.OrderItem oi ON o.OrderID = oi.OrderID " +
            "LEFT OUTER JOIN dbo.OrderTracking ot on oi.OrderID = ot.OrderID and oi.ItemID = ot.ItemID and oi.VendorID = ot.VendorID " +
            "INNER JOIN dbo.Items i on i.ItemID = oi.ItemID and i.VendorID = oi.VendorID " +
            "WHERE o.OrderID = @OrderID";

        string[] v1 = { txtOrderID.Text };

        ds = da.ExecuteQuery(s1, p1, v1);

        FormView1.DataSource = ds.Tables[0];
        //if ds.
        //{
        //    lblNoOrder.Visible = true;
        //}
        //else
        //{
        //    FormView1.DataBind();
        //}
        FormView1.DataBind();

        ds = da.ExecuteQuery(s2, p1, v1);
        Repeater1.DataSource = ds.Tables[0];
        Repeater1.DataBind();
       
    }
}
