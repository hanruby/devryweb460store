using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// API for Order DB Table
/// </summary>
public class Order : IBase
{
    //attributes and properties
    private int orderID;
    public int OrderID
    {
        get
        { return this.orderID; }
        set
        { this.orderID = value; }
    }
    private int customerID;
    public int CustomerID
    {
        get
        { return this.customerID; }
        set
        { this.customerID = value; }
    }
    private double grossTotal;
    public double GrossTotal
    {
        get
        { return this.grossTotal; }
        set
        { this.grossTotal = value; }
    }
    private double tax;
    public double Tax
    {
        get
        { return this.tax; }
        set
        { this.tax = value; }
    }
    private double netTotal;
    public double NetTotal
    {
        get
        { return this.netTotal; }
        set
        { this.netTotal = value; }
    }

    //behaviors
    #region IBase Members

    public IList<object> Get()
    {
        //DAL logic here
        throw new NotImplementedException();
    }

    public bool Add()
    {
        //DAL logic here
        throw new NotImplementedException();
    }

    public bool Delete()
    {
        //DAL logic here
        throw new NotImplementedException();
    }

    public void Clear()
    {
        //DAL logic here
        throw new NotImplementedException();
    }

    #endregion

    //constructors
	public Order()
	{

	}


}
