using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Web.Security;
using DataAccessModule;

public partial class EditProfile : System.Web.UI.Page
{
    // private attributes
    private int customerID;

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Membership.GetUser() != null && !Page.IsPostBack)
        {
            // create customer object to search for
            Customer customerSearchObject = new Customer(null,null,Membership.GetUser().UserName,null,null,null,
                null,null,null,null,null);

            // get current user customer account information from the database
            CustomerDA customerDA = new CustomerDA();
            Collection<Customer> customerInfo = customerDA.GetLike(customerSearchObject);

            // place customer ID into a variable for updating the customer
            customerID = (int)customerInfo[0].Id;

            // put the user information into the form
            txtFirstName.Text = customerInfo[0].FirstName;
            txtLastName.Text = customerInfo[0].LastName;
            txtAddress.Text = customerInfo[0].Address;
            if (customerInfo[0].Address2 != null)
                txtAddress2.Text = customerInfo[0].Address2;
            txtCity.Text = customerInfo[0].City;
            cboState.Text = customerInfo[0].State;
            txtZip.Text = customerInfo[0].Zip;
            cboCountry.Text = customerInfo[0].Country;
            txtEmail.Text = Membership.GetUser().Email;
        }
        else
        {
            // user not logged in, redirect user to login page
            if (!Page.IsPostBack)
                Response.Redirect("Login.aspx");
        }
    }

    /// <summary>
    /// Checks user input for errors, then commits changes to customer info 
    /// in the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmitChanges_Click(object sender, EventArgs e)
    {
        // used for zip TryParse
        int result = 0;

        // check values of the textboxes, displaying the appropriate values, then
        // commit changes to the DB
        if (txtFirstName.Text == "" || txtFirstName.Text == "First Name")
        {
            ErrorText.Text = "First name required";
        }
        else if (txtLastName.Text == "" || txtLastName.Text == "Last Name")
        {
            ErrorText.Text = "Last name required";
        }
        else if (txtAddress.Text == "" || txtAddress.Text == "Address 1")
        {
            ErrorText.Text = "Address 1 required";
        }
        else if (txtCity.Text == "" || txtCity.Text == "City")
        {
            ErrorText.Text = "City name required";
        }
        else if (!int.TryParse(txtZip.Text, out result))
        {
            ErrorText.Text = "Invalid Zip";
        }
        else if (txtEmail.Text == "" || txtEmail.Text == "E-Mail")
        {
            ErrorText.Text = "E-Mail required";
        }
        else
        {
            // create customer data access object
            CustomerDA customerDA = new CustomerDA();

            // get references to the textboxes on the page
            MembershipUser currentUser = Membership.GetUser();

            try
            {
                // create a customer business object
                Customer customerObj = new Customer(customerID, true, currentUser.UserName, txtFirstName.Text, 
                    txtLastName.Text, txtAddress.Text, txtAddress2.Text, txtCity.Text, cboState.Text, txtZip.Text, cboCountry.Text);

                // commit customer business object to the DB using the CustomerDA
                customerDA.Save(customerObj);
                
                // Update user e-mail
                currentUser.Email = txtEmail.Text;
                Membership.UpdateUser(currentUser);
            }
            catch (Exception ex)
            {
                // there was an error in updating the users account
                Response.Redirect("~/404.aspx");
            }

            // redirect the user back to their profile
            Response.Redirect("ViewProfile.aspx");
        }
    }

    /// <summary>
    /// Returns user back to ViewProfile
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewProfile.aspx");
    }
}
