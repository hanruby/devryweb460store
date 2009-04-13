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
        if (!Page.IsPostBack)
        {
            // create dropdownbox controls
            var cboState = (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboState");
            var cboCountry = (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboCountry");

            // set the abbreviated name for the states to prevent the user from typing it in
            string[] states = {"AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC",               
                              "DE", "FL", "GA", "HI", "IA", "ID", "IL", "IN", "KS", "KY",               
                              "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS", "MT", "NC",               
                              "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR",               
                              "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", 
                              "WI", "WV", "WY"};
            cboState.DataSource = states;
            cboState.DataBind();

            // set the abbreviated name for the country to prevent the user from typing it in
            string[] countries = CountryArrays.Abbreviations;
            cboCountry.DataSource = countries;
            cboCountry.DataBind();
        }
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
        var txtEmail =
            (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtEmail");

        // get access to the database
        DataAccess dataAccess = new DAL.DataAccess();

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
        }finally
        {
            // user should be redirected to an error page
        }
    }
}
