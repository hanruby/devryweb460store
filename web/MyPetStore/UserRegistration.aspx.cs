using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DAL;
using DataAccessModule;

public partial class UserRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    /// <summary>
    /// This code is reached after all the steps are completed and the user clicks continue
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void UserRegistrationWizard_ContinueButtonClick(object sender, EventArgs e)
    {
        // user is done, redirect user to homepage.
        Response.Redirect("Default.aspx");
    }

    /// <summary>
    /// This method sets up addition user registration information. This code runs after
    /// the user has been registered to the ASP.Net tables.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void userRegistrationWizard_CreatedUser(object sender, EventArgs e)
    {
        // get references to the textboxes on the page
        MembershipUser newUser = Membership.GetUser(userRegistrationWizard.UserName);
        var txtFirstName =
            (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtFirstName");
        var txtLastName =
            (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtLastName");
        var txtAddress =
            (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtAddress");
        var txtAddress2 =
            (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtAddress2");
        var txtCity =
            (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtCity");
        var cboState =
            (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboState");
        var txtZip =
            (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtZip");
        var cboCountry =
            (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboCountry");

        // create a customer dataaccess object
        CustomerDA customerDA = new CustomerDA();

        try
        {
            // get a collection of the current list of rows in the DB
            Collection<Customer> customerCollection = customerDA.Get(null);

            // get the last user ID in the table
            int? newUserID = customerCollection[customerCollection.Count - 1].Id + 1;

            // create a customer business object
            Customer customerObj = new Customer(newUserID, true, newUser.UserName, txtFirstName.Text, txtLastName.Text, txtAddress.Text,
                txtAddress2.Text, txtCity.Text, cboState.Text, txtZip.Text, cboCountry.Text);

            // commit customer business object to the DB using the CustomerDA
            customerDA.Save(customerObj);
        }catch(Exception ex)
        {
            // there was an error creating the users account, delete the users account
            Membership.DeleteUser(newUser.UserName);
        }


        if (Session["AnonymousUserName"] != null)
        {

            // get customerid of user to use customer id
            // for updating user information

            //Instantiate our customer specific DataAccess Class
            CustomerDA customerDA2 = new CustomerDA();


            //Create an Object that specifies what we want to Get
            Customer customer2 = new Customer();

            //gets customer info based on customer username

            customer2.Username = Session["AnonymousUserName"].ToString();

            //We will be returned a collection so lets Declare that and fill it using Get()
            Collection<Customer> getCustomer2 = customerDA.Get(customer2);



            TextBox userName =
                (TextBox) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("UserName");

            TextBox firstName =
                (TextBox) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtFirstName");

            TextBox lastName =
                (TextBox) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtLastName");
            TextBox address =
                (TextBox) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtAddress");
            TextBox address2 =
                (TextBox) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtAddress2");
            TextBox city =
                (TextBox) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtCity");
            DropDownList state =
                (DropDownList) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboState");
            TextBox zipCode =
                (TextBox) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("RtxtZip");
            DropDownList country =
                (DropDownList) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboCountry");


            // update customer information      
            Customer customerShipping = new Customer();
            customerShipping.Id = getCustomer2[0].Id;
            customerShipping.IsActive = true;
            customerShipping.Username = userName.Text;
            customerShipping.FirstName = firstName.Text;
            customerShipping.LastName = lastName.Text;
            customerShipping.Address = address.Text;
            customerShipping.Address2 = address2.Text;
            customerShipping.City = city.Text;
            customerShipping.State = state.Text;
            customerShipping.Zip = zipCode.Text;
            customerShipping.Country = country.Text;


            //Instantiate our customer specific DataAccess Class
            CustomerDA customerDAShipping = new CustomerDA();


            // save customer information
            customerDAShipping.Save(customerShipping);

            // clear
            customerShipping = null;
            customerDAShipping = null;


            // LogIn User
            System.Web.Security.FormsAuthentication.SetAuthCookie(userName.Text, false);


            //abandon session
            Session.Abandon();
            Session.Clear();
        }


    }
}
