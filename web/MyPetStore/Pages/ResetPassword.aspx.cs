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

public partial class Pages_ResetPassword : System.Web.UI.Page
{
    // attributes
    private string userName; // stores the username from the query string

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["username"] != null)
        //if(PreviousPage != null && PreviousPage.IsCrossPagePostBack)
        {
            txtQuestionAnswer.Focus();
            userName = Request.QueryString["username"].ToString();
            //userName = PreviousPage.PP_UserName.Text;
            lblUserNameLiteral.Text = userName;
            lblUserQuestion.Text = Membership.GetUser(userName).PasswordQuestion;
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string questionAnswer = txtQuestionAnswer.Text;
        string newPassword = txtNewPassword.Text;
        string retypedNewPassword = txtRetypeNewPassword.Text;

        // get user to be updated
        MembershipUser user = Membership.GetUser(userName);
        //user.UnlockUser();

        // validate user input. If valid, reset password with users new password
        if (questionAnswer != "")
        {
            // if both passwords are typed correctly, update password
            if (newPassword == retypedNewPassword)
            {
                try
                {
                    // reset password using new password
                    string tempPassword = user.ResetPassword(questionAnswer);
                    user.ChangePassword(tempPassword, newPassword);
                    Response.Redirect("PasswordSuccess.aspx");
                }
                catch (MembershipPasswordException ex)
                {
                    // user entered an invalid question answer
                    ErrorMessage.Text = "Error: Check fields.";
                    txtQuestionAnswer.Text = "";
                    txtNewPassword.Text = "";
                    txtRetypeNewPassword.Text = "";
                    txtQuestionAnswer.Focus();
                }
                catch (ArgumentException ex)
                {
                    // password entered is invalid
                    ErrorMessage.Text = "Error: Invalid password.";
                    ClearPasswordFields();
                }
            }
            else
            {
                // password fields do not match
                ErrorMessage.Text = "Error: Passwords do not match.";
                ClearPasswordFields();
            }
        }
        else
        {
            // user did not type an answer
            ErrorMessage.Text = "Error: Check fields.";
            ClearPasswordFields();
        }
    }

    /// <summary>
    /// Clears password fields
    /// </summary>
    private void ClearPasswordFields()
    {
        txtNewPassword.Text = "";
        txtRetypeNewPassword.Text = "";
        txtNewPassword.Focus();
    }
}
