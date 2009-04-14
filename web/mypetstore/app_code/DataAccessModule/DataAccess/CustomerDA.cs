using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;


namespace DataAccessModule
{

    /// <summary>
    /// Summary description for CustomerDA
    /// </summary>
    public class CustomerDA : DataAccessBase<Customer>
    {
        #region Constructors
        public CustomerDA() : base()
        {
            //use the Customer mapper
            mapper = new CustomerMapper();
        }

        public CustomerDA(string connectionString, string providerInvariantName): base(connectionString, providerInvariantName)
        {
            mapper = new CustomerMapper();
        }
        #endregion

        #region Implemented DataAccessBase Methods

        protected override Collection<Customer> GetBase(Customer customer, string whereSeperator, string whereOperator)
        {
            //return all rows if no object was given (SELECT * FROM TableName)
            if (customer == null)
                return ExecuteQuery(null, BuildSQLSelectText(CustomerTable.TableName, null, "", ""));

            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(customer);

            //Build a SELECT CommandText
            string selectQuery = base.BuildSQLSelectText(CustomerTable.TableName, parameters, whereSeperator, whereOperator);
            return ExecuteQuery(parameters, selectQuery);
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="customer">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<Customer> Get(Customer customer)
        {
            return GetBase(customer, "AND", "=");
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="customer">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<Customer> GetLike(Customer customer)
        {
            return GetBase(customer, "AND", "LIKE");
        }

        public override int Save(Customer customer)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(CustomerTable.IdParam, customer.Id, CustomerTable.IdColumn);
            string commandText = base.BuildSQLSelectText(CustomerTable.TableName, checkParam, "", "=");
            Collection<Customer> customerCheck = ExecuteQuery(checkParam, commandText);


            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(customer);
            

            if (customerCheck.Count == 0)
            {
                //Row does not exist, do INSERT
                string insertCommandText = base.BuildSQLInsertText(CustomerTable.TableName, parameters);
                return base.ExecuteNonQuery(parameters, insertCommandText);
            }
            else
            {   //Row exists, do UPDATE
                
                //Build Parameters for WHERE clause using Primary Key
                List<DbParameter> whereParameters = new List<DbParameter>();
                whereParameters.Add(CreateParameter(CustomerTable.IdParam, customer.Id, CustomerTable.IdColumn));

                string updateCommandText = base.BuildSQLUpdateText(CustomerTable.TableName, parameters, whereParameters.ToArray(), "AND", "=");
                return base.ExecuteNonQuery(parameters, updateCommandText);
            }
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override int Save(Collection<Customer> items)
        {
            int rowsAffected = 0;

            foreach (var item in items)
            {
                rowsAffected += Save(item);
            }

            return rowsAffected;
        }

        public override int Delete(Customer customer)
        {
            //Build DELETE statement using Primary Key
            DbParameter[] whereParameters = new DbParameter[1];
            whereParameters[0] = (CreateParameter(CustomerTable.IdParam, customer.Id, CustomerTable.IdColumn));

            string updateCommandText = base.BuildSQLDeleteText(CustomerTable.TableName, whereParameters, "AND", "=");
            return base.ExecuteNonQuery(whereParameters, updateCommandText);
        }
        public override int Delete(Collection<Customer> categories)
        {
            int rowsDeleted = 0;
            
            foreach (var customer in categories)
            {
                rowsDeleted += Delete(customer);
            }
            
            return rowsDeleted;
        }


        protected override DbParameter[] CreateAllParameters(Customer customer)
        {
            //Build Parameters from Properties with Values
            List<DbParameter> parameters = new List<DbParameter>();

            if (customer.Id != null)
                parameters.Add(CreateParameter(CustomerTable.IdParam, customer.Id, CustomerTable.IdColumn));
            if (customer.IsActive != null)
                parameters.Add(CreateParameter(CustomerTable.IsActiveParam, customer.IsActive, CustomerTable.IsActiveColumn));
            if (customer.Username != null)
                parameters.Add(CreateParameter(CustomerTable.UsernameParam, customer.Username, CustomerTable.UsernameColumn));
            if (customer.FirstName != null)
                parameters.Add(CreateParameter(CustomerTable.FirstNameParam, customer.FirstName, CustomerTable.FirstNameColumn));
            if (customer.LastName != null)
                parameters.Add(CreateParameter(CustomerTable.LastNameParam, customer.LastName, CustomerTable.LastNameColumn));
            if (customer.Address != null)
                parameters.Add(CreateParameter(CustomerTable.AddressParam, customer.Address, CustomerTable.AddressColumn));
            if (customer.Address2 != null)
                parameters.Add(CreateParameter(CustomerTable.Address2Param, customer.Address2, CustomerTable.Address2Column));
            if (customer.City != null)
                parameters.Add(CreateParameter(CustomerTable.CityParam, customer.City, CustomerTable.CityColumn));
            if (customer.State != null)
                parameters.Add(CreateParameter(CustomerTable.StateParam, customer.State, CustomerTable.StateColumn));
            if (customer.Zip != null)
                parameters.Add(CreateParameter(CustomerTable.ZipParam, customer.Zip, CustomerTable.ZipColumn));
            if (customer.Country != null)
                parameters.Add(CreateParameter(CustomerTable.CountryParam, customer.Country, CustomerTable.CountryColumn));

            return parameters.ToArray();
        }

        #endregion
    }
}