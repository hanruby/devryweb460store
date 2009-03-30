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
using System.Data.SqlClient;


public partial class AdminVendors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string s1;
        string[] p1 = { "@VendorID" };
        string[] v1 = { txtVendorID.Text };

        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter();

        s1 = "SELECT VendorID,IsActive,VendorName,MainPhone,ContactName,ContactEmail, " +
            "ContactPhone, Website, Address, Address2, City, State, Zip, Country " +
            "FROM Vendor WHERE VendorID = @VendorID";

        //sda.Fill(da.ExecuteQuery(s1, p1, v1);
        //dt.

        //lblVendorName.Text = ds.
        

    }
}
