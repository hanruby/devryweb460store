using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderVideos
/// Created By: Ethan Drotning
/// </summary>
public partial class OrderVideos : IBase
{
#region Attributes
    private int _VideoID;
    private string _ItemID;
    private int _VendorID;
    private string _VideoName;
    private string _VideoDescription;
    private string _Link;
    private string _VideoSource;
#endregion

#region Constructors
    public OrderVideos()
	{
		// Default Constructor
	}

    public OrderVideos(int p_VideoID, string p_ItemID, int p_VendorID, string p_VideoName,
        string p_VideoDescription, string p_Link, string p_VideoSource)
    {
        _VideoID = p_VideoID;
        _ItemID = p_ItemID;
        _VendorID = p_VendorID;
        _VideoName = p_VideoName;
        _VideoDescription = p_VideoDescription;
        _Link = p_Link;
        _VideoSource = p_VideoSource;
    }
#endregion

#region Methods
    public IList<object> Get()
    {
        List<object> ov = new List<object>();

        return ov;
    }

    public bool Add()
    {
        bool s = false;

        return s;
    }

    public bool Delete()
    {
        bool s = false;

        return s;
    }

    public void Clear()
    {
        _VideoID = -1;
        _ItemID = null;
        _VendorID = -1;
        _VideoName = null;
        _VideoDescription = null;
        _Link = null;
        _VideoSource = null;
        // List(T).Clear()??
    }
#endregion

#region Properties
    public int VideoID
    {
        get { return _VideoID; }
        set { _VideoID = value; }
    }

    public string ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }

    public int VendorID
    {
        get { return _VendorID; }
        set { _VendorID = value; }
    }

    public string VideoName
    {
        get { return _VideoName; }
        set { _VideoName = value; }
    }

    public string VideoDescription
    {
        get { return _VideoDescription; }
        set { _VideoDescription = value; }
    }

    public string Link
    {
        get { return _Link; }
        set { _Link = value; }
    }

    public string VideoSource
    {
        get { return _VideoSource; }
        set { _VideoSource = value; }
    }
#endregion

}
