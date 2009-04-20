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

public partial class Controls_ViewOrders3 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (CheckAuth() == true)
            {
                DisableFields(false);
            }
            else
            {
                DisableFields(true);
            }
        }
    }

    protected void btnLookUp_Click(object sender, EventArgs e)
    {
        GetOrderInfo();
    }

    private bool CheckAuth()
    {
        bool auth = false;

        if (System.Web.HttpContext.Current.User.IsInRole("Administrator"))
        {
            auth = true;
        }

        return auth;
    }

    private void GetOrderInfo()
    {
        string Orders_OrderDate_Start = txtOrders_OrderDate_Start.Text;
        string Orders_OrderDate_End = txtOrders_OrderDate_End.Text;
        string Orders_NetTotal_Start = txtOrders_NetTotal_Start.Text;
        string Orders_NetTotal_End = txtOrders_NetTotal_End.Text;
        string Customer_CustomerID = txtCustomer_CustomerID.Text;
        string Customer_FName = txtCustomer_FName.Text;
        string Customer_LName = txtCustomer_LName.Text;
        string Customer_UserName = txtCustomer_UserName.Text;
        string Customer_City = txtCustomer_City.Text;
        string Customer_State = txtCustomer_State.Text;
        string Items_ProductName = txtItems_ProductName.Text;

        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");
        DataSet ds = new DataSet();

        string s1;
        string s2 = "";
        int fields = CountUsedFields();
        int p;
        string[] p1 = new string[fields];
        string[] v1 = new string[fields];
        

        s1 = "SELECT o.* FROM Orders o " +
            "RIGHT OUTER JOIN Customer c ON o.CustomerID = c.CustomerID ";
        if (Items_ProductName != "")
        {
            s1 += "RIGHT OUTER JOIN OrderItems oi ON o.ORDERID = oi.OrderID " +
                "INNER JOIN Items i ON oi.ItemID = i.ItemID AND oi.VendorID = i.VendorID ";
        }

        s1 += "WHERE ";

        if (Orders_OrderDate_Start != "")
        {
            s2 += "AND o.OrderDate >= @OrderDate ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@OrderDate";
            v1[p] = Orders_OrderDate_Start;
        }

        if (Orders_OrderDate_End != "")
        {
            s2 += "AND o.OrderDate <= @OrderDate ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@OrderDate";
            v1[p] = Orders_OrderDate_End;
        }

        if (Orders_NetTotal_Start != "")
        {
            s2 += "AND o.NetTotal >= @NetTotal ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@NetTotal, ";
            v1[p] = Orders_NetTotal_Start + ", ";
        }

        if (Orders_NetTotal_End != "")
        {
            s2 += "AND o.NetTotal <= @NetTotal ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@NetTotal, ";
            v1[p] = Orders_NetTotal_End + ", ";
        }

        if (Customer_CustomerID != "")
        {
            s2 += "AND c.CustomerID = @CustomerID ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@CustomerID, ";
            v1[p] = Customer_CustomerID + ", ";
        }

        if (Customer_FName != "")
        {
            s2 += "AND c.FName = @FName ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@FName, ";
            v1[p] = Customer_FName + ", ";
        }

        if (Customer_LName != "")
        {
            s2 += "AND c.LName = @LName ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@LName, ";
            v1[p] = Customer_LName + ", ";
        }

        if (Customer_UserName != "")
        {
            s2 += "AND c.UserName = @UserName ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@UserName, ";
            v1[p] = Customer_UserName + ", ";
        }

        if (Customer_City != "")
        {
            s2 += "AND c.City = @City ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@City, ";
            v1[p] = Customer_City + ", ";
        }

        if (Customer_State != "")
        {
            s2 += "AND c.State = @State ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@State, ";
            v1[p] = Customer_State + ", ";
        }

        if (Items_ProductName != "")
        {
            s2 += "AND i.ProductName = @ProductName ";
            p = 0;
            while (p1[p] != "")
            {
                p += 1;
            }
            p1[p] = "@ProductName, ";
            v1[p] = Items_ProductName + ", ";
        }

        s2 = s2.TrimStart('A', 'N', 'D', ' ');
        s1 += s2;
        
        ds = da.ExecuteQuery(s1, p1, v1);

        gvOrders1.DataSource = ds.Tables[0];
        gvOrders1.DataBind();

        if (this.gvOrders1.Rows.Count > 0)
        {
            gvOrders1.UseAccessibleHeader = true;
            gvOrders1.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvOrders1.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        
    }

    private void DisableFields(bool param_disable)
    {
        if (param_disable == true)
        {
            txtOrders_OrderDate_Start.Enabled = false;
            txtOrders_OrderDate_End.Enabled = false;
            txtOrders_NetTotal_Start.Enabled = false;
            txtOrders_NetTotal_End.Enabled = false;
            txtCustomer_CustomerID.Enabled = false;
            txtCustomer_FName.Enabled = false;
            txtCustomer_LName.Enabled = false;
            txtCustomer_UserName.Enabled = false;
            txtCustomer_City.Enabled = false;
            txtCustomer_State.Enabled = false;
            txtItems_ProductName.Enabled = false;
            btnLookUp.Enabled = false;

            txtOrders_OrderDate_Start.Text = null;
            txtOrders_OrderDate_End.Text = null;
            txtOrders_NetTotal_Start.Text = null;
            txtOrders_NetTotal_End.Text = null;
            txtCustomer_CustomerID.Text = null;
            txtCustomer_FName.Text = null;
            txtCustomer_LName.Text = null;
            txtCustomer_UserName.Text = null;
            txtCustomer_City.Text = null;
            txtCustomer_State.Text = null;
            txtItems_ProductName.Text = null;
        }

        if (param_disable == false)
        {
            txtOrders_OrderDate_Start.Enabled = true;
            txtOrders_OrderDate_End.Enabled = true;
            txtOrders_NetTotal_Start.Enabled = true;
            txtOrders_NetTotal_End.Enabled = true;
            txtCustomer_CustomerID.Enabled = true;
            txtCustomer_FName.Enabled = true;
            txtCustomer_LName.Enabled = true;
            txtCustomer_UserName.Enabled = true;
            txtCustomer_City.Enabled = true;
            txtCustomer_State.Enabled = true;
            txtItems_ProductName.Enabled = true;
            btnLookUp.Enabled = true;
        }
    }

    private int CountUsedFields()
    {
        int x = 0;

        if (txtOrders_OrderDate_Start.Text != "") { x += 1; }
        if (txtOrders_OrderDate_End.Text != "") { x += 1; }
        if (txtOrders_NetTotal_Start.Text != "") { x += 1; }
        if (txtOrders_NetTotal_End.Text != "") { x += 1; }
        if (txtCustomer_CustomerID.Text != "") { x += 1; }
        if (txtCustomer_FName.Text != "") { x += 1; }
        if (txtCustomer_LName.Text != "") { x += 1; }
        if (txtCustomer_UserName.Text != "") { x += 1; }
        if (txtCustomer_City.Text != "") { x += 1; }
        if (txtCustomer_State.Text != "") { x += 1; }
        if (txtItems_ProductName.Text != "") { x += 1; }

        return x;
    }
}
