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

public partial class Pages_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUserName.Focus();
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text != "")
        {
            // get an user from the database using the username entered, then validate that the user exists
            MembershipUser user = Membership.GetUser(txtUserName.Text);
            if (user != null)
            {
                // user exists, redirect user to password reset screen
                Response.Redirect("ResetPassword.aspx?username=" + txtUserName.Text);
            }
            else
            {
                // username entered is not valid
                ErrorMessage.Text = "Invalid user name.";
                txtUserName.Text = "";
                txtUserName.Focus();
            }

        }
        else
        {
            // username field is blank
            ErrorMessage.Text = "You must enter an user name";
            txtUserName.Focus();
        }

    }
}
