using System;
using System.Data;
using System.Configuration;


/// <summary>
/// Used to determine the table a business object class belongs to, as well as other attributes that may apply.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DBTableAttribute : Attribute
{
    private string name;

    public DBTableAttribute(string name)
    {
        this.name = name;

    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}
