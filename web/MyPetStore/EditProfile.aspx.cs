using System;
using System.Configuration;
using System.Web.Security;

public partial class EditProfile : System.Web.UI.Page
{
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Membership.GetUser() != null && !Page.IsPostBack)
        {
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

            // get user information from database
            var dbConnect = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                "System.Data.SqlClient");

            // create sql statement query string
            const string sqlStatement = "select * from Customer where UserName = @UserName;";
            string[] parms = { "@UserName" };
            string[] value = { Membership.GetUser().UserName };

            // get the unique row based on username
            var customerInfo = dbConnect.ExecuteQuery(sqlStatement, parms, value);

            // required to get column ordinal value from the row returned
            var dr = customerInfo.CreateDataReader();

            // get collumn data and fill in text boxes if not null
            if (customerInfo.Tables[0].Rows[0]["FName"].ToString() != null)
                txtFirstName.Text = customerInfo.Tables[0].Rows[0]["FName"].ToString();
            if (customerInfo.Tables[0].Rows[0]["LName"].ToString() != null)
                txtLastName.Text = customerInfo.Tables[0].Rows[0]["LName"].ToString();
            if (customerInfo.Tables[0].Rows[0]["Address"].ToString() != null)
                txtAddress.Text = customerInfo.Tables[0].Rows[0]["Address"].ToString();
            if (customerInfo.Tables[0].Rows[0]["Address2"].ToString() != null)
                txtAddress2.Text = customerInfo.Tables[0].Rows[0]["Address2"].ToString();
            if (customerInfo.Tables[0].Rows[0]["City"].ToString() != null)
                txtCity.Text = customerInfo.Tables[0].Rows[0]["City"].ToString();
            if (customerInfo.Tables[0].Rows[0]["State"].ToString() != null)
                cboState.Text = customerInfo.Tables[0].Rows[0]["State"].ToString();
            if (customerInfo.Tables[0].Rows[0]["Zip"].ToString() != null)
                txtZip.Text = customerInfo.Tables[0].Rows[0]["Zip"].ToString();
            if (customerInfo.Tables[0].Rows[0]["Country"].ToString() != null)
                cboCountry.Text = customerInfo.Tables[0].Rows[0]["Country"].ToString();
            txtEmail.Text = Membership.GetUser().Email;

            // Dispose of the datareader and customer info dataset
            dr.Dispose();
            customerInfo.Dispose();
        }
        else
        {
            // user not logged in, redirect user to login page
            if(!Page.IsPostBack)
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
        if(txtFirstName.Text == "" || txtFirstName.Text == "First Name")
        {
            ErrorText.Text = "First name required";
        }
        else if(txtLastName.Text == "" || txtLastName.Text == "Last Name")
        {
            ErrorText.Text = "Last name required";
        }
        else if(txtAddress.Text == "" || txtAddress.Text == "Address 1")
        {
            ErrorText.Text = "Address 1 required";
        }
        else if(txtCity.Text == "" || txtCity.Text == "City")
        {
            ErrorText.Text = "City name required";
        }
        else if(!int.TryParse(txtZip.Text,out result))
        {
            ErrorText.Text = "Invalid Zip";
        }
        else if(txtEmail.Text == "" || txtEmail.Text == "E-Mail")
        {
            ErrorText.Text = "E-Mail required";
        }
        else
        {
            // get new information from the text boxes
            var dataAccess = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString,
                                                "System.Data.SqlClient");

            //create sql Statement
            var sql = "UPDATE customer SET FName = @FName, LName = @LName, Address = @Address,"
                      + " Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country"
                      + " WHERE UserName = @UserName;";
            string[] parms = {
                                 "@FName", "@LName", "@Address", "@Address2", "@City", "@State", "@Zip",
                                 "@Country", "@UserName"
                             };
            string[] values = {
                                  txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtAddress2.Text,
                                  txtCity.Text, cboState.Text, txtZip.Text, cboCountry.Text,
                                  Membership.GetUser().UserName
                              };

            dataAccess.ExecuteNonQuery(sql, parms, values);

            // Update user e-mail
            var member = Membership.GetUser();
            member.Email = txtEmail.Text;
            Membership.UpdateUser(member);

            // redirect the user back to their profile
            Response.Redirect("ViewProfile.aspx");
        }
    }

    /// <summary>
    /// TextChanged event changes text to a default value if blank
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtFirstName_TextChanged(object sender, EventArgs e)
    {
        if (txtFirstName.Text == "")
        {
            txtFirstName.Attributes.CssStyle["color"] = "grey";
            txtFirstName.Text = "First Name";
        }
        else
        {
            txtFirstName.Attributes.CssStyle["color"] = "black";
        }
    }

    /// <summary>
    /// TextChanged event changes text to a default value if blank
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtLastName_TextChanged(object sender, EventArgs e)
    {
        if (txtLastName.Text == "")
        {
            txtLastName.Attributes.CssStyle["color"] = "grey";
            txtLastName.Text = "Last Name";
        }
        else
        {
            txtLastName.Attributes.CssStyle["color"] = "black";
        }
    }

    /// <summary>
    /// TextChanged event changes text to a default value if blank
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtAddress_TextChanged(object sender, EventArgs e)
    {
        if (txtAddress.Text == "")
        {
            txtAddress.Attributes.CssStyle["color"] = "grey";
            txtAddress.Text = "Address 1";
        }
        else
        {
            txtAddress.Attributes.CssStyle["color"] = "black";
        }
    }

    /// <summary>
    /// TextChanged event changes text to a default value if blank
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtAddress2_TextChanged(object sender, EventArgs e)
    {
        if (txtAddress2.Text == "")
        {
            txtAddress2.Attributes.CssStyle["color"] = "grey";
            txtAddress2.Text = "Address 2";
        }
        else
        {
            txtAddress2.Attributes.CssStyle["color"] = "black";
        }
    }

    /// <summary>
    /// TextChanged event changes text to a default value if blank
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtCity_TextChanged(object sender, EventArgs e)
    {
        if (txtCity.Text == "")
        {
            txtCity.Attributes.CssStyle["color"] = "grey";
            txtCity.Text = "City";
        }
        else
        {
            txtCity.Attributes.CssStyle["color"] = "black";
        }
    }

    /// <summary>
    /// TextChanged event changes text to a default value if blank
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtZip_TextChanged(object sender, EventArgs e)
    {
        if (txtZip.Text == "")
        {
            txtZip.Attributes.CssStyle["color"] = "grey";
            txtZip.Text = "Zip";
        }
        else
        {
            txtZip.Attributes.CssStyle["color"] = "black";
        }
    }

    /// <summary>
    /// TextChanged event changes text to a default value if blank
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        if (txtEmail.Text == "")
        {
            txtEmail.Attributes.CssStyle["color"] = "grey";
            txtEmail.Text = "E-Mail";
        }
        else
        {
            txtEmail.Attributes.CssStyle["color"] = "black";
        }
    }
}
