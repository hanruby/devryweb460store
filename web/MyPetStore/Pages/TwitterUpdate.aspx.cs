using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Pages_TwitterUpdate : System.Web.UI.Page
{
       

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    // validates length of comment
    protected void valUpdateTwitterAccount(object sender, ServerValidateEventArgs args)
    {
       
        if (IsValid)
        { 
            
            int maxLenght = 140;

            if (txtTwitterComment.Text.Length > maxLenght)
            {
                args.IsValid = false;
            }
        }
    }

    // post twit
     protected void UpdateTwitterAccount_Click(object sender, EventArgs e)
    {
         // variable
        string txttwittercomment = Server.HtmlEncode(txtTwitterComment.Text);

        // sends values to method for twitter post 
        Twitter.PostTweet("username of company", "password of company", txttwittercomment);
    }

    // convert regular url into a tiny url
    protected void btnGetTinyUrl_Click(object sender, EventArgs e)
    {

        // inserts variables to method
        string strShortURL = ConvertURL.ShortenURL(Server.HtmlEncode(txtUrl.Text), ConvertURL.ShortURLProvider.Tinyurl);

        // sets tiny url to txtTinyUrl textbox
        txtTinyUrl.Text = strShortURL;


    }
}
