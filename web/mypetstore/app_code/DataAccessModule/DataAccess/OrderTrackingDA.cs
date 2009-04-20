using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;


namespace DataAccessModule
{

    /// <summary>
    /// Summary description for OrderTrackingDA
    /// </summary>
    public class OrderTrackingDA : DataAccessBase<OrderTracking>
    {
        #region Constructors
        public OrderTrackingDA() : base()
        {
            //use the OrderTracking mapper
            mapper = new OrderTrackingMapper();
        }

        public OrderTrackingDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new OrderTrackingMapper();
        }
        #endregion

        #region Implemented DataAccessBase Methods

        protected override Collection<OrderTracking> GetBase(OrderTracking orderTracking, string whereSeperator, string whereOperator)
        {
            //return all rows if no object was given (SELECT * FROM TableName)
            if (orderTracking == null)
                return ExecuteQuery(null, BuildSQLSelectText(OrderTrackingTable.TableName, null, "", ""));

            //Build Parameters for base query
            DatabaseParameter[] parameters = CreateAllParameters(orderTracking);

            //Build a SELECT CommandText
            string selectQuery = base.BuildSQLSelectText(OrderTrackingTable.TableName, parameters, whereSeperator, whereOperator);
            return ExecuteQuery(parameters, selectQuery);
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="orderTracking">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<OrderTracking> Get(OrderTracking orderTracking)
        {
            return GetBase(orderTracking, "AND", "=");
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="orderTracking">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<OrderTracking> GetLike(OrderTracking orderTracking)
        {
            return GetBase(orderTracking, "AND", "LIKE");
        }

        public override int Save(OrderTracking orderTracking)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DatabaseParameter[1];
            checkParam[0] = CreateParameter(OrderTrackingTable.TableName, OrderTrackingTable.IdParam, orderTracking.Id, OrderTrackingTable.IdColumn);
            string commandText = base.BuildSQLSelectText(OrderTrackingTable.TableName, checkParam, "", "=");
            Collection<OrderTracking> orderTrackingCheck = ExecuteQuery(checkParam, commandText);


            //Build Parameters for base query
            DatabaseParameter[] parameters = CreateAllParameters(orderTracking);
            

            if (orderTrackingCheck.Count == 0)
            {
                //Row does not exist, do INSERT
                string insertCommandText = base.BuildSQLInsertText(OrderTrackingTable.TableName, parameters);
                return base.ExecuteNonQuery(parameters, insertCommandText);
            }
            else
            {   //Row exists, do UPDATE
                
                //Build Parameters for WHERE clause using Primary Key
                List<DatabaseParameter> whereParameters = new List<DatabaseParameter>();
                whereParameters.Add(CreateParameter(OrderTrackingTable.TableName, OrderTrackingTable.IdParam, orderTracking.Id, OrderTrackingTable.IdColumn));

                string updateCommandText = base.BuildSQLUpdateText(OrderTrackingTable.TableName, parameters, whereParameters.ToArray(), "AND", "=");
                return base.ExecuteNonQuery(parameters, updateCommandText);
            }
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override int Save(Collection<OrderTracking> items)
        {
            int rowsAffected = 0;

            foreach (var item in items)
            {
                rowsAffected += Save(item);
            }

            return rowsAffected;
        }

        public override int Delete(OrderTracking orderTracking)
        {
            //Build DELETE statement using Primary Key
            DatabaseParameter[] whereParameters = new DatabaseParameter[1];
            whereParameters[0] = (CreateParameter(OrderTrackingTable.TableName, OrderTrackingTable.IdParam, orderTracking.Id, OrderTrackingTable.IdColumn));

            string updateCommandText = base.BuildSQLDeleteText(OrderTrackingTable.TableName, whereParameters, "AND", "=");
            return base.ExecuteNonQuery(whereParameters, updateCommandText);
        }
        public override int Delete(Collection<OrderTracking> categories)
        {
            int rowsDeleted = 0;
            
            foreach (var orderTracking in categories)
            {
                rowsDeleted += Delete(orderTracking);
            }
            
            return rowsDeleted;
        }


        protected override DatabaseParameter[] CreateAllParameters(OrderTracking orderTracking)
        {
            //Build Parameters from Properties with Values
            List<DatabaseParameter> parameters = new List<DatabaseParameter>();

            if (orderTracking.Id != null)
                parameters.Add(CreateParameter(OrderTrackingTable.TableName, OrderTrackingTable.IdParam, orderTracking.Id, OrderTrackingTable.IdColumn));
            if (orderTracking.OrderId != null)
                parameters.Add(CreateParameter(OrderTrackingTable.TableName, OrderTrackingTable.OrderIdParam, orderTracking.OrderId, OrderTrackingTable.OrderIdColumn));
            if (orderTracking.ItemId != null)
                parameters.Add(CreateParameter(OrderTrackingTable.TableName, OrderTrackingTable.ItemIdParam, orderTracking.ItemId, OrderTrackingTable.ItemIdColumn));
            if (orderTracking.VendorId != null)
                parameters.Add(CreateParameter(OrderTrackingTable.TableName, OrderTrackingTable.VendorIdParam, orderTracking.VendorId, OrderTrackingTable.VendorIdColumn));
            if (orderTracking.ShipDate != null)
                parameters.Add(CreateParameter(OrderTrackingTable.TableName, OrderTrackingTable.ShipDateParam, orderTracking.ShipDate, OrderTrackingTable.ShipDateColumn));
            if (orderTracking.EstimatedArrival != null)
                parameters.Add(CreateParameter(OrderTrackingTable.TableName, OrderTrackingTable.EstimatedArrivalParam, orderTracking.EstimatedArrival, OrderTrackingTable.EstimatedArrivalColumn));
            if (orderTracking.Url != null)
                parameters.Add(CreateParameter(OrderTrackingTable.TableName, OrderTrackingTable.UrlParam, orderTracking.Url, OrderTrackingTable.UrlColumn));

            return parameters.ToArray();
        }

        #endregion
    }
}