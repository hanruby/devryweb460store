﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_ViewCustomers : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DAL.DataAccess da = new DAL.DataAccess(ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString, "System.Data.SqlClient");

        string sql = "select Customer.CustomerID,Customer.FName,Customer.LName,Customer.Address,Customer.Address2,Customer.City,Customer.State,Customer.Zip,Customer.Country,aspnet_Users.UserName, aspnet_Membership.Email " +
            "from Customer " +
            "inner join aspnet_Users on " +
            "Customer.UserName = aspnet_Users.UserName " +
            "inner join aspnet_Membership on " +
            "aspnet_Users.UserId = aspnet_Membership.UserId";

        DataSet ds = new DataSet();
        string[] s = { };
        ds = da.ExecuteQuery(sql, s, s);
        gvCustomers.DataSource = ds.Tables[0];
        gvCustomers.DataBind();

        //code for tablesorter ready gridviews
        if (this.gvCustomers.Rows.Count > 0)
        {
            gvCustomers.UseAccessibleHeader = true;
            gvCustomers.HeaderRow.TableSection = TableRowSection.TableHeader;
            gvCustomers.FooterRow.TableSection = TableRowSection.TableFooter;

        }
        //end

        s = null;
        sql = null;
    }   
}
