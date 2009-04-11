using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;


namespace DataAccessModule
{

    /// <summary>
    /// Summary description for OrderDA
    /// </summary>
    public class OrderDA : DataAccessBase<Order>
    {
        #region Constructors
        public OrderDA() : base()
        {
            //use the Order mapper
            mapper = new OrderMapper();
        }

        public OrderDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new OrderMapper();
        }
        #endregion

        #region Implemented DataAccessBase Methods

        protected override Collection<Order> GetBase(Order order, string whereSeperator, string whereOperator)
        {
            //return all rows if no object was given (SELECT * FROM TableName)
            if (order == null)
                return ExecuteQuery(null, BuildSQLSelectText(OrderTable.TableName, null, "", ""));

            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(order);

            //Build a SELECT CommandText
            string selectQuery = base.BuildSQLSelectText(OrderTable.TableName, parameters, whereSeperator, whereOperator);
            return ExecuteQuery(parameters, selectQuery);
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="order">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<Order> Get(Order order)
        {
            return GetBase(order, "AND", "=");
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="order">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<Order> GetLike(Order order)
        {
            return GetBase(order, "AND", "LIKE");
        }

        public override int Save(Order order)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(OrderTable.IdParam, order.Id, OrderTable.IdColumn);
            string commandText = base.BuildSQLSelectText(OrderTable.TableName, checkParam, "", "=");
            Collection<Order> orderCheck = ExecuteQuery(checkParam, commandText);


            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(order);
            

            if (orderCheck.Count == 0)
            {
                //Row does not exist, do INSERT
                string insertCommandText = base.BuildSQLInsertText(OrderTable.TableName, parameters);
                return base.ExecuteNonQuery(parameters, insertCommandText);
            }
            else
            {   //Row exists, do UPDATE
                
                //Build Parameters for WHERE clause using Primary Key
                List<DbParameter> whereParameters = new List<DbParameter>();
                whereParameters.Add(CreateParameter(OrderTable.IdParam, order.Id, OrderTable.IdColumn));

                string updateCommandText = base.BuildSQLUpdateText(OrderTable.TableName, parameters, whereParameters.ToArray(), "AND", "=");
                return base.ExecuteNonQuery(parameters, updateCommandText);
            }
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override int Save(Collection<Order> items)
        {
            int rowsAffected = 0;

            foreach (var item in items)
            {
                rowsAffected += Save(item);
            }

            return rowsAffected;
        }

        public override int Delete(Order order)
        {
            //Build DELETE statement using Primary Key
            DbParameter[] whereParameters = new DbParameter[1];
            whereParameters[0] = (CreateParameter(OrderTable.IdParam, order.Id, OrderTable.IdColumn));

            string updateCommandText = base.BuildSQLDeleteText(OrderTable.TableName, whereParameters, "AND", "=");
            return base.ExecuteNonQuery(whereParameters, updateCommandText);
        }
        public override int Delete(Collection<Order> categories)
        {
            int rowsDeleted = 0;
            
            foreach (var order in categories)
            {
                rowsDeleted += Delete(order);
            }
            
            return rowsDeleted;
        }


        protected override DbParameter[] CreateAllParameters(Order order)
        {
            //Build Parameters from Properties with Values
            List<DbParameter> parameters = new List<DbParameter>();

            if (order.Id != null)
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

            return parameters.ToArray();
        }

        #endregion
    }
}