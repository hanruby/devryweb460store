using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// API for Customer DB Table
/// Created By: Rob Robbins
/// </summary>
public class Customer : IBase
{
	//attributes and properties
 
    private int customerID;
    public int CustomerID
    {
        get
        { return this.customerID; }
        set
        { this.customerID = value; }
    }

    private bool isActive;
    public bool IsActive
    {
        get
        { return this.isActive; }
        set
        { this.isActive = value; }
    }
    private string userName;
    public string UserName
    {
        get
        { return this.userName; }
        set
        { this.userName = value; }
    }
    private string fName;
    public string Fname
    {
        get
        { return this.fName; }
        set
        { this.fName = value; }
    }
    private string lName;
    public string Lname
    {
        get
        { return this.lName; }
        set
        { this.lName = value; }
    }
    private string address;
    public string Address
    {
        get
        { return this.address; }
        set
        { this.address = value; }
    }
    private string address2;
    public string Address2
    {
        get
        { return this.address2; }
        set
        { this.address2 = value; }
    }
    private string city;
    public string City
    {
        get
        { return this.city; }
        set
        { this.city = value; }
    }
    private string state;
    public string State
    {
        get
        { return this.state; }
        set
        { this.state= value; }
    }
    private string zip;
    public string Zip
    {
        get
        { return this.zip; }
        set
        { this.zip = value; }
    }
    private string country;
    public string Country
    {
        get
        { return this.country; }
        set
        { this.country = value; }
    }

    //behaviors

    #region IBase Members 

    public IList<object> Get()
    {
        //dal logic here
        throw new NotImplementedException();
       
    }

    public bool Add()
    {
        //dal logic here
        throw new NotImplementedException();
    }

    public bool Delete()
    {
        //dal logic here
        throw new NotImplementedException();
    }

    public void Clear()
    {
        this.CustomerID = -1;
        this.IsActive = false;
        this.UserName = null;
        this.Fname = null;
        this.Lname = null;
        this.Address = null;
        this.Address2 = null;
        this.City = null;
        this.state = null;
        this.Zip = null;
    }

    #endregion

    //constructors
    public Customer()
    {

    }
    //with a username passed via the page.identity.name prop
    public Customer(string uName)
    {
        this.UserName = uName;
    }
}
