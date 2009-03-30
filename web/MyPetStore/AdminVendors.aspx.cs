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

        txtVendorID.ReadOnly = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string s1;
        string[] p1 = { "@VendorID", "@IsActive","@VendorName","@MainPhone","@ContactName","@ContactEmail", "@ContactPhone",
                          "@Website", "@Address", "@Address2", "@City", "@State", "@Zip", "@Country" };
        string[] v1 = { txtVendorID.Text, Convert.ToString(cboxIsActive.Checked), txtVendorName.Text,
                          txtMainPhone.Text,txtContactName.Text,txtContactEmail.Text,txtContactPhone.Text,
                          txtWebsite.Text,txtAddress.Text,txtAddress2.Text,txtCity.Text,txtState.Text,
                          txtZip.Text,txtCountry.Text };

        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        s1 = "UPDATE Vendor " +
            "SET IsActive = @IsActive, VendorName = @VendorName, MainPhone = @MainPhone, ContactName = @ContactName, " +
            "ContactEmail = @ContactEmail, ContactPhone = @ContactPhone, Website = @Website, Address = @Address, " +
            "Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country " +
            "WHERE VendorID = @VendorID";

        da.ExecuteNonQuery(s1, p1, v1);

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string s1;
        string[] p1 = { "@VendorID" };
        string[] v1 = { txtVendorID.Text };

        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        s1 = "DELETE FROM Vendor WHERE VendorID = @VendorID";

        da.ExecuteNonQuery(s1, p1, v1);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtVendorID.ReadOnly = false;

        txtVendorID.Text = "";
        cboxIsActive.Checked = false;
        txtVendorName.Text = "";
        txtMainPhone.Text = "";
        txtContactName.Text = "";
        txtContactEmail.Text = "";
        txtContactPhone.Text = "";
        txtWebsite.Text = "";
        txtAddress.Text = "";
        txtAddress2.Text = "";
        txtCity.Text = "";
        txtState.Text = "";
        txtZip.Text = "";
        txtCountry.Text = "";

    }
}
