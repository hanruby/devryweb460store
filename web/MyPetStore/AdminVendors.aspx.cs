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
        
        s1 = "SELECT VendorID,IsActive,VendorName,MainPhone,ContactName,ContactEmail, " +
            "ContactPhone, Website, Address, Address2, City, State, Zip, Country " +
            "FROM Vendor WHERE VendorID = @VendorID";

        ds = da.ExecuteQuery(s1, p1, v1);

        cboxIsActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"].ToString());
        txtVendorName.Text = ds.Tables[0].Rows[0]["VendorName"].ToString();
        txtMainPhone.Text = ds.Tables[0].Rows[0]["MainPhone"].ToString();
        txtContactName.Text = ds.Tables[0].Rows[0]["ContactName"].ToString();
        txtContactEmail.Text = ds.Tables[0].Rows[0]["ContactEmail"].ToString();
        txtContactPhone.Text = ds.Tables[0].Rows[0]["ContactPhone"].ToString();
        txtWebsite.Text = ds.Tables[0].Rows[0]["Website"].ToString();
        txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
        txtAddress2.Text = ds.Tables[0].Rows[0]["Address2"].ToString();
        txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
        txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
        txtZip.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
        txtCountry.Text = ds.Tables[0].Rows[0]["Country"].ToString();
    }
}
