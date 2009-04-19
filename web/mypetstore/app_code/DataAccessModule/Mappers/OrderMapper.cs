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
    /// Maps a Database record to an Order Object
    /// </summary>
    public class OrderMapper : MapperBase<Order>
    {
        public override Order Map(DbDataRecord record)
        {

            //all fields are null on construction
            var order = new Order();


            //check each column in the record and set a value if not null

            //Id
            if (record[OrderTable.IdColumn] != DBNull.Value)
                order.Id = (int)record[OrderTable.IdColumn];

            //CustomerId
            if (record[OrderTable.CustomerIdColumn] != DBNull.Value)
                order.CustomerId = (int)record[OrderTable.CustomerIdColumn];

            //GrossTotal
            if (record[OrderTable.GrossTotalColumn] != DBNull.Value)
                order.GrossTotal = (decimal)record[OrderTable.GrossTotalColumn];

            //Tax
            if (record[OrderTable.TaxColumn] != DBNull.Value)
                order.Tax = (decimal)record[OrderTable.TaxColumn];

            //NetTotal
            if (record[OrderTable.NetTotalColumn] != DBNull.Value)
                order.NetTotal = (decimal)record[OrderTable.NetTotalColumn];

            //TXNID
            if (record[OrderTable.TXNIDColumn] != DBNull.Value)
                order.TxnId = (string)record[OrderTable.TXNIDColumn];

            //Date
            if (record[OrderTable.DateColumn] != DBNull.Value)
                order.Date = (string)record[OrderTable.DateColumn];

            return order;
        }
    }
}