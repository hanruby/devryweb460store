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
        //This should be easy but it is not working, it is setting the textboxes to the column names.
        //cboxIsActive.Checked = Convert.ToBoolean(Convert.ToInt32(ds.Tables[0].Columns["IsActive"].ToString()));
        txtVendorName.Text = ds.Tables[0].Columns["VendorName"].ToString();
        txtMainPhone.Text = ds.Tables[0].Columns["MainPhone"].ToString();
        txtContactName.Text = ds.Tables[0].Columns["ContactName"].ToString();
        txtContactEmail.Text = ds.Tables[0].Columns["ContactEmail"].ToString();
        txtContactPhone.Text = ds.Tables[0].Columns["ContactPhone"].ToString();
        txtWebsite.Text = ds.Tables[0].Columns["Website"].ToString();
        txtAddress.Text = ds.Tables[0].Columns["Address"].ToString();
        txtAddress2.Text = ds.Tables[0].Columns["Address2"].ToString();
        txtCity.Text = ds.Tables[0].Columns["City"].ToString();
        txtState.Text = ds.Tables[0].Columns["State"].ToString();
        txtZip.Text = ds.Tables[0].Columns["Zip"].ToString();
        txtCountry.Text = ds.Tables[0].Columns["Country"].ToString();
    }
}
