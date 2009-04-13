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
    /// Maps a Database record to a OrderItem Object
    /// </summary>
    public class OrderItemMapper : MapperBase<OrderItem>
    {
        public override OrderItem Map(DbDataRecord record)
        {

            //all fields are null on construction
            var orderItem = new OrderItem();


            //check each column in the record and set a value if not null

            //OrderId
            if (record[OrderItemTable.OrderIdColumn] != DBNull.Value)
                orderItem.OrderId = (int)record[OrderItemTable.OrderIdColumn];

            //ItemId
            if (record[OrderItemTable.ItemIdColumn] != DBNull.Value)
                orderItem.ItemId = (string)record[OrderItemTable.ItemIdColumn];

            //VendorId
            if (record[OrderItemTable.VendorIdColumn] != DBNull.Value)
                orderItem.VendorId = (int)record[OrderItemTable.VendorIdColumn];

            //Price
            if (record[OrderItemTable.PriceColumn] != DBNull.Value)
                orderItem.Price = (decimal)record[OrderItemTable.PriceColumn];

            //TotalPrice
            if (record[OrderItemTable.TotalPriceColumn] != DBNull.Value)
                orderItem.TotalPrice = (decimal)record[OrderItemTable.TotalPriceColumn];

            //Quantity
            if (record[OrderItemTable.QuantityColumn] != DBNull.Value)
                orderItem.Quantity = (int)record[OrderItemTable.QuantityColumn];

            return orderItem;
        }
    }
}
