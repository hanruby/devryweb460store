﻿using System;
using System.Collections;
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

public partial class UserRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // create dropdownbox controls
        var cboState = (DropDownList) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboState");
        var cboCountry = (DropDownList) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboCountry");

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

    protected void UserRegistrationWizard_ContinueButtonClick(object sender, EventArgs e)
    {
        //var txtFirstName =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtFirstName");
        //var txtLastName =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtLastName");
        //var txtAddress =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtAddress");
        //var txtAddress2 =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtAddress2");
        //var txtCity =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtCity");
        //var cboState =
        //    (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboState");
        //var txtZip =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtZip");
        //var cboCountry =
        //    (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboCountry");
        //var txtEmail =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtEmail");

        //// get new information from the text boxes
        //var dataAccess = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
        //                                    "System.Data.SqlClient");

        ////create sql Statement
        //var sql = "UPDATE customer SET FName = @FName, LName = @LName, Address = @Address,"
        //          + " Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country"
        //          + " WHERE UserName = @UserName;";
        //string[] parms = {
        //                         "@FName", "@LName", "@Address", "@Address2", "@City", "@State", "@Zip",
        //                         "@Country", "@UserName"
        //                     };
        //string[] values = {
        //                          txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtAddress2.Text,
        //                          txtCity.Text, cboState.Text, txtZip.Text, cboCountry.Text,
        //                          Membership.GetUser().UserName
        //                      };

        //dataAccess.ExecuteNonQuery(sql, parms, values);

        //// Update user e-mail
        //var member = Membership.GetUser();
        //member.Email = txtEmail.Text;
        //Membership.UpdateUser(member);

        //Response.Redirect("Default.aspx");
    }

    protected void UserRegistrationWizard_CreateUser(object sender, EventArgs e)
    {

        //var txtFirstName =
        //    (TextBox) userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtFirstName");
        //var txtLastName =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtLastName");
        //var txtAddress =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtAddress");
        //var txtAddress2 =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtAddress2");
        //var txtCity =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtCity");
        //var cboState =
        //    (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboState");
        //var txtZip =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtZip");
        //var cboCountry =
        //    (DropDownList)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("cboCountry");
        //var txtEmail =
        //    (TextBox)userRegistrationWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtEmail");

        //// get new information from the text boxes
        //var dataAccess = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
        //                                    "System.Data.SqlClient");

        ////create sql Statement
        //var sql = "UPDATE customer SET FName = @FName, LName = @LName, Address = @Address,"
        //          + " Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country"
        //          + " WHERE UserName = @UserName;";
        //string[] parms = {
        //                         "@FName", "@LName", "@Address", "@Address2", "@City", "@State", "@Zip",
        //                         "@Country", "@UserName"
        //                     };
        //string[] values = {
        //                          txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtAddress2.Text,
        //                          txtCity.Text, cboState.Text, txtZip.Text, cboCountry.Text,
        //                          Membership.GetUser().UserName
        //                      };

        //dataAccess.ExecuteNonQuery(sql, parms, values);

        //// Update user e-mail
        //var member = Membership.GetUser();
        //member.Email = txtEmail.Text;
        //Membership.UpdateUser(member);       
    }
}
