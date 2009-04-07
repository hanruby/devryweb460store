using System;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DataAccessModule
{
    /// <summary>
    /// Maps a Database record to a OrderTracking Object
    /// </summary>

    public class OrderTrackingMapper : MapperBase<OrderTracking>
    {
        public override OrderTracking Map(DbDataRecord record)
        {

            //all fields are null on construction
            var orderTracking = new OrderTracking();


            //check each column in the record and set a value if not null

            //Id
            if (record[OrderTrackingTable.IdColumn] != DBNull.Value)
                orderTracking.Id = (int)record[OrderTable.IdColumn];

            //OrderId
            if (record[OrderTrackingTable.OrderIdColumn] != DBNull.Value)
                orderTracking.OrderId = (int)record[OrderTrackingTable.OrderIdColumn];

            //ItemId
            if (record[OrderTrackingTable.ItemIdColumn] != DBNull.Value)
                orderTracking.OrderId = (int)record[OrderTrackingTable.ItemIdColumn];

            //VendorId
            if (record[OrderTrackingTable.VendorIdColumn] != DBNull.Value)
                orderTracking.OrderId = (int)record[OrderTrackingTable.VendorIdColumn];

            //ShipDate
            if (record[OrderTrackingTable.ShipDateColumn] != DBNull.Value)
                orderTracking.OrderId = (int)record[OrderTrackingTable.ShipDateColumn];

            //EstimatedArrival
            if (record[OrderTrackingTable.EstimatedArrivalColumn] != DBNull.Value)
                orderTracking.OrderId = (int)record[OrderTrackingTable.EstimatedArrivalColumn];

            //Url
            if (record[OrderTrackingTable.UrlColumn] != DBNull.Value)
                orderTracking.OrderId = (int)record[OrderTrackingTable.UrlColumn];

            return orderTracking;
        }

    }
}

