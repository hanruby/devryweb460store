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
/// Summary description for Customer
/// </summary>

[DBTable("Customer")]
public class Customer
{
    private int id;
    private bool isActive;
    private string password;
    private string firstName;
    private string lastName;
    private string address;
    private string address2;
    private string city;
    private string state;
    private string zip;
    private string country;
    private string email;

	public Customer()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //change to PK
    [DBColumn("CustomerID")]
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    [DBColumn("IsActive")]
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    [DBColumn("Password")]
    public string Password
    {
        get { return password; }
        set {password = value; }
    }

    [DBColumn("FName")]
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    [DBColumn("LName")]
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    [DBColumn("Address")]
    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    [DBColumn("Address2")]
    public string Address2
    {
        get { return address2; }
        set { address2 = value; }
    }

    [DBColumn("City")]
    public string City
    {
        get { return city; }
        set { city = value; }
    }

    [DBColumn("State")]
    public string State
    {
        get { return state; }
        set { state = value; }
    }

    [DBColumn("Zip")]
    public string Zip
    {
        get { return zip; }
        set { zip = value; }
    }

    [DBColumn("Country")]
    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    [DBColumn("Email")]
    public string Email
    {
        get { return email; }
        set { email = value; }
    }


}
