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

public partial class TwitterUpdate : System.Web.UI.Page
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
        string TwitterComment = Server.HtmlEncode(txtTwitterComment.Text);

        // sends values to method for twitter post 
        Twitter.PostTweet("mypetsfw", "", TwitterComment);
    }

    // creates random enum 
    // I took out the -1 after items.Length, it doesn't seem to be needed
    // http://stackoverflow.com/questions/319814/generate-random-enum-in-c-2-0
    public provider RandomEnum<provider>()
    {
        string[] items = Enum.GetNames(typeof(provider));
        Random r = new Random();
        string e = items[r.Next(0, items.Length)];
        return (provider)Enum.Parse(typeof(provider), e, true);
    }

    // convert regular url into a tiny url
    protected void btnGetTinyUrl_Click(object sender, EventArgs e)
    {
        // ConvertURL.ShortURLProvider.Tinyurl;
        // inserts txtUrl.Text, and a random enum to method
        string strShortURL = ConvertURL.ShortenURL(Server.HtmlEncode(txtUrl.Text), RandomEnum<ConvertURL.ShortURLProvider>());

        // sets tiny url to txtTinyUrl textbox
        txtTinyUrl.Text = strShortURL;

    }
}
