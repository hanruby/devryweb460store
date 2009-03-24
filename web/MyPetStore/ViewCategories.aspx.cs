using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class MyPetStore_ViewCategories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");
            string sql = "select * from categories;";
            DataSet ds = new DataSet();
            string[] s = { };
            ds = da.ExecuteQuery(sql, s, s);
            repeater1.DataSource = ds.Tables[0];
            repeater1.DataBind();

            s = null;
            sql = null;
        }
    }
    protected void btnClickMe_Click(object sender, EventArgs e)
    {
        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");
        string sql = "select * from categories where categoryName = @categoryname";
        DataSet ds = new DataSet();
        string[] s = {"@categoryname"};
        string[] r = {txtsearch.Text};
        ds = da.ExecuteQuery(sql, s, r);
        repeater1.DataSource = ds.Tables[0];
        repeater1.DataBind();

        s = null;
        sql = null;
    }
}
