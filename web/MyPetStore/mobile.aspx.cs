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

public partial class mobile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Mobile
        /// <summary>
        /// This SHOULD direct users to the regular site if viewing on Computer, BlackBerry and/or iPhone
        /// and SHOULD direct users to the mobile device enabled site if viewing on a mobile device
        /// Created By: Jonathan Sourp
        /// </summary>

        if (Request.UserAgent != null)
            if (Request.Headers["User-Agent"] != null &&
                (Request.Browser["IsMobileDevice"] == "true" ||
                 Request.Browser["BlackBerry"] == "true" ||
                 Request.UserAgent.ToUpper().Contains("MIDP") ||
                 Request.UserAgent.ToUpper().Contains("CLDC")) ||
                Request.UserAgent.ToLower().Contains("iphone"))
            {
                Response.Redirect("Mobile/Default.aspx");
            }
            else if (Request.Headers["User-Agent"] != null &&
                 Request.Browser["BlackBerry"] == "true" ||
                Request.UserAgent.ToLower().Contains("iphone"))
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        #endregion
    }
}
