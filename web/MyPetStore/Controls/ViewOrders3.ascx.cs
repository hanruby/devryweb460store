using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_ViewOrders3 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool CheckAuth(string p_CustomerUserNameOfOrder)
    {
        bool auth = false;

        if (System.Web.HttpContext.Current.User.IsInRole("Administrator"))
        {
            auth = true;
        }
        else if (System.Web.HttpContext.Current.User.ToString() == p_CustomerUserNameOfOrder)
        {
            auth = true;
        }

        return auth;
    }

    private void GetOrderInfo()
    {


        if (this.gvOrders1.Rows.Count > 0)
        {
            gvOrders1.UseAccessibleHeader = true;
            gvOrders1.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvOrders1.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }


    protected void btnLookUp_Click(object sender, EventArgs e)
    {
        GetOrderInfo();
    }
}
