using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// Summary description for DBColumnAttribute
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class DBColumnAttribute : Attribute
{
    private string name;
    //private int length;
    private bool isAutoIncrement;
    private bool isPrimaryKey;

    public DBColumnAttribute(string name)
    {
        this.name = name;
        this.isAutoIncrement = false;
        this.isPrimaryKey = false;
    }
    public DBColumnAttribute(string name, bool isAutoIncrement, bool isPrimaryKey)
    {
        this.name = name;
        this.isAutoIncrement = isAutoIncrement;
        this.isPrimaryKey = isPrimaryKey;
    }

    public string Name
    {
        get { return name; }
    }
    public bool IsAutoIncrement
    {
        get { return isAutoIncrement; }
    }
    public bool IsPrimaryKey
    {
        get { return isPrimaryKey; }
    }
    

}
