using System;
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
using DAL;
using System.Data.SqlClient;

public partial class EditProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Membership.GetUser() != null)
        {
            // set the values for the states to prevent the user from typing it in
            string[] states = {"AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC",               
                              "DE", "FL", "GA", "HI", "IA", "ID", "IL", "IN", "KS", "KY",               
                              "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS", "MT", "NC",               
                              "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR",               
                              "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", 
                              "WI", "WV", "WY"};
            cboState.DataSource = states;
            cboState.DataBind();

            // get user information from database and fill in the textboxes
            var dbConnect = new DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");
            const string sqlStatement = "select * from Customer where UserName = @UserName;";
            string[] parms = { "@UserName" };
            string[] value = { Membership.GetUser().UserName };

            //var customerInfo = new DataSet();
            //customerInfo = dbConnect.ExecuteQuery(sqlStatement, parms, value);
            var customerInfo = (DataSet)dbConnect.ExecuteQuery(sqlStatement, parms, value);

            txtFirstName.Text = customerInfo.ExtendedProperties["FName"].ToString();
            txtLastName.Text = customerInfo.ExtendedProperties["LName"].ToString();
            txtAddress.Text = customerInfo.ExtendedProperties["Address"].ToString();
            txtAddress2.Text = customerInfo.ExtendedProperties["Address2"].ToString();
            txtCity.Text = customerInfo.ExtendedProperties["City"].ToString();
            cboState.Text = customerInfo.ExtendedProperties["State"].ToString();
            txtZip.Text = customerInfo.ExtendedProperties["Zip"].ToString();
            txtCountry. Text = customerInfo.ExtendedProperties["Country"].ToString();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}
