using System;
using System.Configuration;
using System.Web.Security;

public partial class ViewProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // if user is logged in, display their profile
        if (Membership.GetUser() != null )
        {
            // get user information from database
            var dbConnect = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                "System.Data.SqlClient");
            const string sqlStatement = "select * from Customer where UserName = @UserName;";
            string[] parms = { "@UserName" };
            string[] value = { Membership.GetUser().UserName };

            // get the unique row based on username
            var customerInfo = dbConnect.ExecuteQuery(sqlStatement, parms, value);

            // required to get column ordinal value from the row returned
            var dr = customerInfo.CreateDataReader();

            // get collumn data and fill in text boxes if not null
            if (customerInfo.Tables[0].Rows[0]["FName"].ToString() != null)
                lblUserFName.Text = customerInfo.Tables[0].Rows[0]["FName"].ToString();
            if (customerInfo.Tables[0].Rows[0]["LName"].ToString() != null)
                lblUserLName.Text = customerInfo.Tables[0].Rows[0]["LName"].ToString();
            if (customerInfo.Tables[0].Rows[0]["Address"].ToString() != null)
                lblUserAddress.Text = customerInfo.Tables[0].Rows[0]["Address"].ToString();
            if (customerInfo.Tables[0].Rows[0]["Address2"].ToString() != null)
                lblUserAddress2.Text = customerInfo.Tables[0].Rows[0]["Address2"].ToString();
            if (customerInfo.Tables[0].Rows[0]["City"].ToString() != null)
                lblUserCity.Text = customerInfo.Tables[0].Rows[0]["City"].ToString();
            if (customerInfo.Tables[0].Rows[0]["State"].ToString() != null)
                lblUserState.Text = customerInfo.Tables[0].Rows[0]["State"].ToString();
            if (customerInfo.Tables[0].Rows[0]["Zip"].ToString() != null)
                lblUserZip.Text = customerInfo.Tables[0].Rows[0]["Zip"].ToString();
            if (customerInfo.Tables[0].Rows[0]["Country"].ToString() != null)
                lblUserCountry.Text = customerInfo.Tables[0].Rows[0]["Country"].ToString();
            lblUserEmail.Text = Membership.GetUser().Email;

            // dispose of the datareader and customerInfo dataset
            dr.Dispose();
            customerInfo.Dispose();
        }
        else
        {
            // user not logged in, redirect user to login page
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnEditProfile_Click(object sender, EventArgs e)
    {
        // redirect user to edit profile page
        Response.Redirect("EditProfile.aspx" );
    }
}
