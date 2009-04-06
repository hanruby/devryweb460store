using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Summary description for OrderTrackingDA
    /// </summary>
    public class OrderTrackingDA : DataAccessBase<OrderTracking>
    {
        #region Constructors
        public OrderTrackingDA()
        {
            mapper = new OrderTrackingMapper();
        }

        public OrderTrackingDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new OrderTrackingMapper();
        }
        #endregion

        #region Save & Get
        public override int Save(OrderTracking orderTracking)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(OrderTrackingTable.IdParam, orderTracking.Id);
            Collection<OrderTracking> categoryCheck = ExecuteQuery(checkParam, OrderTrackingTable.SelectById);

            //Add parameters
            var parameters = new List<DbParameter>();
            parameters.Add(CreateParameter(OrderTrackingTable.IdParam, orderTracking.Id, OrderTrackingTable.IdColumn ));
            parameters.Add(CreateParameter(OrderTrackingTable.OrderIdParam, orderTracking.OrderId, OrderTrackingTable.OrderIdColumn));
            parameters.Add(CreateParameter(OrderTrackingTable.ItemIdParam, orderTracking.ItemId, OrderTrackingTable.ItemIdColumn));
            parameters.Add(CreateParameter(OrderTrackingTable.VendorIdParam, orderTracking.VendorId, OrderTrackingTable.VendorIdColumn));
            parameters.Add(CreateParameter(OrderTrackingTable.ShipDateParam, orderTracking.ShipDate, OrderTrackingTable.ShipDateColumn));
            parameters.Add(CreateParameter(OrderTrackingTable.EstimatedArrivalParam, orderTracking.EstimatedArrival, OrderTrackingTable.EstimatedArrivalColumn));
            parameters.Add(CreateParameter(OrderTrackingTable.UrlParam, orderTracking.Url, OrderTrackingTable.UrlColumn));

            if (categoryCheck.Count == 0)
                //does not exist, do INSERT
                return base.ExecuteNonQuery(parameters.ToArray(), OrderTrackingTable.Insert);
            else
                //exists, do UPDATE
                return base.ExecuteNonQuery(parameters.ToArray(), OrderTrackingTable.UpdateById);
        }

        public override void Save(Collection<OrderTracking> orderTrackings)
        {
            foreach (var tracking in orderTrackings)
            {
                Save(tracking);
            }
        }

        public override Collection<OrderTracking> Get(OrderTracking orderTracking)
        {
            var parameters = new List<DbParameter>();

            #region Check each Property for a value, Add a parameter a value exists
            if (orderTracking.Id != null)
                parameters.Add(CreateParameter(OrderTrackingTable.IdParam, orderTracking.Id, OrderTrackingTable.IdColumn));
            if( orderTracking.OrderId != null )
            parameters.Add(CreateParameter(OrderTrackingTable.OrderIdParam, orderTracking.OrderId, OrderTrackingTable.OrderIdColumn));
            if (orderTracking.ItemId != null)
            parameters.Add(CreateParameter(OrderTrackingTable.ItemIdParam, orderTracking.ItemId, OrderTrackingTable.ItemIdColumn));
            if (orderTracking.VendorId != null)
            parameters.Add(CreateParameter(OrderTrackingTable.VendorIdParam, orderTracking.VendorId, OrderTrackingTable.VendorIdColumn));
            if (orderTracking.ShipDate != null)
            parameters.Add(CreateParameter(OrderTrackingTable.ShipDateParam, orderTracking.ShipDate, OrderTrackingTable.ShipDateColumn));
            if (orderTracking.EstimatedArrival != null)
            parameters.Add(CreateParameter(OrderTrackingTable.EstimatedArrivalParam, orderTracking.EstimatedArrival, OrderTrackingTable.EstimatedArrivalColumn));
            if (orderTracking.Url != null)
            parameters.Add(CreateParameter(OrderTrackingTable.UrlParam, orderTracking.Url, OrderTrackingTable.UrlColumn));
            #endregion

            //Build a WHERE Clause using AND
            string commandText = BuildSQLTextWhereAND(OrderTrackingTable.Select, parameters.ToArray());
            return ExecuteQuery(parameters.ToArray(), commandText);
        }

        #endregion

    }
}