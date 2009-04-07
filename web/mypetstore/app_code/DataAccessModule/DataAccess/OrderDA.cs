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
    /// Summary description for OrderDA
    /// </summary>
    public class OrderDA : DataAccessBase<Order>
    {
        #region Constructors
        public OrderDA()
        {
            mapper = new OrderMapper();
        }

        public OrderDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new OrderMapper();
        }
        #endregion

        #region Save & Get
        /// <summary>
        /// Saves an Item object to a Database
        /// </summary>
        /// <param name="order">Order to be saved in to the database(INSERTed or UPDATEd)</param>
        /// <returns></returns>

        public override int Save(Order order)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(OrderTable.IdParam, order.Id);
            Collection<Order> categoryCheck = ExecuteQuery(checkParam, OrderTable.SelectById);

            //Add parameters
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(CreateParameter(OrderTable.IdParam, order.Id, OrderTable.IdColumn));
            parameters.Add(CreateParameter(OrderTable.CustomerIdParam, order.CustomerId, OrderTable.CustomerIdColumn));
            parameters.Add(CreateParameter(OrderTable.GrossTotalParam, order.GrossTotal, OrderTable.GrossTotalColumn));
            parameters.Add(CreateParameter(OrderTable.TaxParam, order.Tax, OrderTable.TaxColumn));
            parameters.Add(CreateParameter(OrderTable.NetTotalParam, order.NetTotal, OrderTable.NetTotalColumn));
            parameters.Add(CreateParameter(OrderTable.TXNIDParam, order.TxnId, OrderTable.TXNIDColumn));

            if (categoryCheck.Count == 0)
                //does not exist, do INSERT
                return base.ExecuteNonQuery(parameters.ToArray(), OrderTable.Insert);
            else
                //exists, do UPDATE
                return base.ExecuteNonQuery(parameters.ToArray(), OrderTable.UpdateById);
        }

        /// <summary>
        /// Saves a Collection of Order objects to a Database
        /// </summary>
        /// <param name="orders"></param>
        public override void Save(Collection<Order> orders)
        {
            foreach (var order in orders)
            {
                Save(order);
            }
        }


        public override Collection<Order> Get(Order order)
        {
            var parameters = new List<DbParameter>();

            #region Check each Property for a value, Add a parameter a value exists

            if(order.Id != null)
                parameters.Add(CreateParameter(OrderTable.IdParam, order.Id, OrderTable.IdColumn));
            if (order.CustomerId != null)
                parameters.Add(CreateParameter(OrderTable.CustomerIdParam, order.CustomerId, OrderTable.CustomerIdColumn));
            if (order.GrossTotal != null)
                parameters.Add(CreateParameter(OrderTable.GrossTotalParam, order.GrossTotal, OrderTable.GrossTotalColumn));
            if (order.Tax != null)
                parameters.Add(CreateParameter(OrderTable.TaxParam, order.Tax, OrderTable.TaxColumn));
            if (order.NetTotal != null)
                parameters.Add(CreateParameter(OrderTable.NetTotalParam, order.NetTotal, OrderTable.NetTotalColumn));
            if (order.TxnId != null)
                parameters.Add(CreateParameter(OrderTable.TXNIDParam, order.TxnId, OrderTable.TXNIDColumn));
            #endregion

            //Build a WHERE Clause using AND
            string commandText = BuildSQLTextWhereAND(OrderTable.Select, parameters.ToArray());
            return ExecuteQuery(parameters.ToArray(), commandText);
        }

        #endregion


    }
}