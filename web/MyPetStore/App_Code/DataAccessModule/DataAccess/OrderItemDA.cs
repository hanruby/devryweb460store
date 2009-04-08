using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;


namespace DataAccessModule
{

    /// <summary>
    /// Summary description for OrderItemDA
    /// </summary>
    public class OrderItemDA : DataAccessBase<OrderItem>
    {
        #region Constructors
        public OrderItemDA() : base()
        {
            //use the OrderItem mapper
            mapper = new OrderItemMapper();
        }

        public OrderItemDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new OrderItemMapper();
        }
        #endregion

        #region Implemented DataAccessBase Methods

        protected override Collection<OrderItem> GetBase(OrderItem orderItem, string whereSeperator, string whereOperator)
        {
            //return all rows if no object was given (SELECT * FROM TableName)
            if (orderItem == null)
                return ExecuteQuery(null, BuildSQLSelectText(OrderItemTable.TableName, null, "", ""));

            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(orderItem);

            //Build a SELECT CommandText
            string selectQuery = base.BuildSQLSelectText(OrderItemTable.TableName, parameters, whereSeperator, whereOperator);
            return ExecuteQuery(parameters, selectQuery);
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="orderItem">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<OrderItem> Get(OrderItem orderItem)
        {
            return GetBase(orderItem, "AND", "=");
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="orderItem">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<OrderItem> GetLike(OrderItem orderItem)
        {
            return GetBase(orderItem, "AND", "LIKE");
        }

        public override int Save(OrderItem orderItem)
        {
            //Check for the objects existsence in the database using the Primary key
            DbParameter[] checkParam = new DbParameter[3];
            checkParam[0] = CreateParameter(OrderItemTable.OrderIdParam, orderItem.OrderId, OrderItemTable.OrderIdColumn);
            checkParam[1] = CreateParameter(OrderItemTable.ItemIdParam, orderItem.ItemId, OrderItemTable.ItemIdColumn);
            checkParam[2] = CreateParameter(OrderItemTable.VendorIdParam, orderItem.VendorId, OrderItemTable.VendorIdColumn);

            string commandText = base.BuildSQLSelectText(OrderItemTable.TableName, checkParam, "", "=");
            Collection<OrderItem> orderItemCheck = ExecuteQuery(checkParam, commandText);


            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(orderItem);
            

            if (orderItemCheck.Count == 0)
            {
                //Row does not exist, do INSERT
                string insertCommandText = base.BuildSQLInsertText(OrderItemTable.TableName, parameters);
                return base.ExecuteNonQuery(parameters, insertCommandText);
            }
            else
            {   //Row exists, do UPDATE
                
                //Build Parameters for WHERE clause using Primary Key
                DbParameter[] whereParameters = new DbParameter[3];
                whereParameters[0] = CreateParameter(OrderItemTable.OrderIdParam, orderItem.OrderId, OrderItemTable.OrderIdColumn);
                whereParameters[1] = CreateParameter(OrderItemTable.ItemIdParam, orderItem.ItemId, OrderItemTable.ItemIdColumn);
                whereParameters[2] = CreateParameter(OrderItemTable.VendorIdParam, orderItem.VendorId, OrderItemTable.VendorIdColumn);

                string updateCommandText = base.BuildSQLUpdateText(OrderItemTable.TableName, parameters, whereParameters, "AND", "=");
                return base.ExecuteNonQuery(parameters, updateCommandText);
            }
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override int Save(Collection<OrderItem> items)
        {
            int rowsAffected = 0;

            foreach (var item in items)
            {
                rowsAffected += Save(item);
            }

            return rowsAffected;
        }

        public override int Delete(OrderItem orderItem)
        {
            //Build DELETE statement using Primary Key
            DbParameter[] whereParameters = new DbParameter[3];
            whereParameters[0] = CreateParameter(OrderItemTable.OrderIdParam, orderItem.OrderId, OrderItemTable.OrderIdColumn);
            whereParameters[1] = CreateParameter(OrderItemTable.ItemIdParam, orderItem.ItemId, OrderItemTable.ItemIdColumn);
            whereParameters[2] = CreateParameter(OrderItemTable.VendorIdParam, orderItem.VendorId, OrderItemTable.VendorIdColumn);

            

            string updateCommandText = base.BuildSQLDeleteText(OrderItemTable.TableName, whereParameters, "AND", "=");
            return base.ExecuteNonQuery(whereParameters, updateCommandText);
        }
        public override int Delete(Collection<OrderItem> categories)
        {
            int rowsDeleted = 0;
            
            foreach (var orderItem in categories)
            {
                rowsDeleted += Delete(orderItem);
            }
            
            return rowsDeleted;
        }


        protected override DbParameter[] CreateAllParameters(OrderItem orderItem)
        {
            //Build Parameters from Properties with Values
            List<DbParameter> parameters = new List<DbParameter>();

            if (orderItem.OrderId != null)
                parameters.Add(CreateParameter(OrderItemTable.OrderIdParam, orderItem.OrderId, OrderItemTable.OrderIdColumn));
            if (orderItem.ItemId != null)
                parameters.Add(CreateParameter(OrderItemTable.ItemIdParam, orderItem.ItemId, OrderItemTable.ItemIdColumn));
            if (orderItem.VendorId != null)
                parameters.Add(CreateParameter(OrderItemTable.VendorIdParam, orderItem.VendorId, OrderItemTable.VendorIdColumn));
            if (orderItem.Price != null)
                parameters.Add(CreateParameter(OrderItemTable.PriceParam, orderItem.Price, OrderItemTable.PriceColumn));
            if (orderItem.TotalPrice != null)
                parameters.Add(CreateParameter(OrderItemTable.TotalPriceParam, orderItem.TotalPrice, OrderItemTable.TotalPriceColumn));
            if (orderItem.Quantity != null)
                parameters.Add(CreateParameter(OrderItemTable.QuantityParam, orderItem.Quantity, OrderItemTable.QuantityColumn));

            return parameters.ToArray();
        }

        #endregion
    }
}