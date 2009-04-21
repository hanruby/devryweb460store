using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Web.Security;
using DataAccessModule;

public partial class ViewProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Membership.GetUser() != null && !Page.IsPostBack)
        {
            // create customer object to search for
            Customer customerSearchObject = new Customer(null, null, Membership.GetUser().UserName, null, null, null,
                null, null, null, null, null);

            // get current user customer account information from the database
            CustomerDA customerDA = new CustomerDA();
            Collection<Customer> customerInfo = customerDA.GetLike(customerSearchObject);

            // put the user information into the form
            lblUserFName.Text = customerInfo[0].FirstName;
            lblUserLName.Text = customerInfo[0].LastName;
            lblUserAddress.Text = customerInfo[0].Address;
            if (customerInfo[0].Address2 != null)
                lblUserAddress2.Text = customerInfo[0].Address2;
            lblUserCity.Text = customerInfo[0].City;
            lblUserState.Text = customerInfo[0].State;
            lblUserZip.Text = customerInfo[0].Zip;
            lblUserCountry.Text = customerInfo[0].Country;
            lblUserEmail.Text = Membership.GetUser().Email;
        }
        else
        {
            // user not logged in, redirect user to login page
            if (!Page.IsPostBack)
                Response.Redirect("Login.aspx");
        }
    }
    protected void btnEditProfile_Click(object sender, EventArgs e)
    {
        // redirect user to edit profile page
        Response.Redirect("EditProfile.aspx");
    }
}
