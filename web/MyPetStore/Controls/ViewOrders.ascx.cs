using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_ViewOrders : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOrderInfo_Click(object sender, EventArgs e)
    {
        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        //eventually going to need something like a 'where shipdate > datetime.now' for pending orders
        string sql = "select Orders.OrderID, Orders.CustomerID, Orders.GrossTotal, Orders.Tax, Orders.NetTotal from orders";

        DataSet ds = new DataSet();
        string[] s = { };
        ds = da.ExecuteQuery(sql, s, s);
        gvOrders.DataSource = ds.Tables[0];
        gvOrders.DataBind();

        //code for tablesorter ready gridviews
        if (this.gvOrders.Rows.Count > 0)
        {
            gvOrders.UseAccessibleHeader = true;
            gvOrders.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvOrders.FooterRow.TableSection = TableRowSection.TableFooter;

        }
        //end

        s = null;
        sql = null;
    }
    protected void btnShipStatus_Click(object sender, EventArgs e)//table not ready yet
    {
        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        //eventually going to need something like a 'where shipdate > datetime.now' for pending orders
        string sql = "select * from orders";

        DataSet ds = new DataSet();
        string[] s = { };
        ds = da.ExecuteQuery(sql, s, s);
        gvShipStatus.DataSource = ds.Tables[0];
        gvShipStatus.DataBind();

        //code for tablesorter ready gridviews
        if (this.gvShipStatus.Rows.Count > 0)
        {
            gvShipStatus.UseAccessibleHeader = true;
            gvShipStatus.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvShipStatus.FooterRow.TableSection = TableRowSection.TableFooter;

        }
        //end

        s = null;
        sql = null;
    }
}
