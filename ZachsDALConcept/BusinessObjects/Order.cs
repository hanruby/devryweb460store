using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Order
/// </summary>
[DBTable("Order")]
public class Order
{
    private int id;
    private Customer customer;
    private double grossTotal;
    private double tax;
    private double netTotal;

	public Order()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    [DBColumn("OrderID")]
    public int Id
    {
        get { return id; }
        set { id = value; }
    }


    [DBColumn("GrossTotal")]
    public double GrossTotal
    {
        get { return grossTotal; }
        set { grossTotal = value; }
    }

    [DBColumn("Tax")]
    public double Tax
    {
        get { return tax; }
        set { tax = value; }
    }

    [DBColumn("NetTotal")]
    public double NetTotal
    {
        get { return netTotal; }
        set { netTotal = value; }
    }

    
    //foreign key
    [DBColumn("CustomerID")]
    public int CustomerId
    {
        get { return OrderingCustomer.Id; }
    }

    //foreign table
    public Customer OrderingCustomer
    {
        get { return customer; }
        set { customer = value; }
    }
}
