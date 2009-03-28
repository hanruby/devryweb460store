using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// DBAPI for OrderTracking table.
/// Created By: Ethan Drotning
/// </summary>
public partial class OrderTracking : IBase
{
#region Attributes
    private string _TrackingID;
    private int _OrderID;
    private string _ItemID;
    private int _VendorID;
    private DateTime _ShipDate;
    private DateTime _EstArrival;
    private string _TrackingURL;
#endregion

#region Constructors
    public OrderTracking()
    {
        // Default Constructor
    }
    
    public OrderTracking(string p_TrackingID, int p_OrderID, string p_ItemID, int p_VendorID,
        DateTime p_ShipDate, DateTime p_EstArrival, string p_TrackingURL)
    {
        //DBConnect dbc = new DBConnect(ConfigurationManager.AppSettings["MyPetStoreDB"]);
        _TrackingID = p_TrackingID;
        _OrderID = p_OrderID;
        _ItemID = p_ItemID;
        _VendorID = p_VendorID;
        _ShipDate = p_ShipDate;
        _EstArrival = p_EstArrival;
        _TrackingURL = p_TrackingURL;
    }



#endregion

#region Methods
    public IList<object> Get()
    {
        List<object> ot = new List<object>();

        return ot;
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
        _TrackingID = null;
        _OrderID = -1;
        _ItemID = null;
        _VendorID = -1;
        _ShipDate = DateTime.MinValue;
        _EstArrival = DateTime.MinValue;
        _TrackingURL = null;
    }
#endregion

#region Properties
    public string TrackingID
    {
        get{return _TrackingID;}
        set{_TrackingID = value;}
    }

    public int OrderID
    {
        get{return _OrderID;}
        set{_OrderID = value;}
    }

    public string ItemID
    {
        get{return _ItemID;}
        set{_ItemID = value;}
    }

    public int VendorID
    {
        get{return _VendorID;}
        set{_VendorID = value;}
    }

    public DateTime ShipDate
    {
        get{return _ShipDate;}
        set{_ShipDate = value;}
    }

    public DateTime EstArrival
    {
        get{return _EstArrival;}
        set{_EstArrival = value;}
    }

    public string TrackingURL
    {
        get{return _TrackingID;}
        set{_TrackingURL = value;}
    }
#endregion

}
