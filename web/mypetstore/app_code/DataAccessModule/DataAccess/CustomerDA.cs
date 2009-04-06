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
        public CustomerDA()
        {
            mapper = new CustomerMapper();
        }

        public CustomerDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new CustomerMapper();
        }

        
        #region Save & Get
        public override int Save(Customer customer)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(CustomerTable.IdParam, customer.Id);
            var categoryCheck = ExecuteQuery(checkParam, CustomerTable.SelectById);

            //Add parameters
            var parameters = new List<DbParameter>();
            parameters.Add(CreateParameter(CustomerTable.IdParam, customer.Id, CustomerTable.IdColumn));
            parameters.Add(CreateParameter(CustomerTable.IsActiveParam, customer.IsActive, CustomerTable.IsActiveColumn));
            parameters.Add(CreateParameter(CustomerTable.UsernameParam, customer.Username, CustomerTable.UsernameColumn));
            parameters.Add(CreateParameter(CustomerTable.FirstNameParam, customer.FirstName, CustomerTable.FirstNameColumn));
            parameters.Add(CreateParameter(CustomerTable.LastNameParam, customer.LastName, CustomerTable.LastNameColumn));
            parameters.Add(CreateParameter(CustomerTable.AddressParam, customer.Address, CustomerTable.AddressColumn));
            parameters.Add(CreateParameter(CustomerTable.Address2Param, customer.Address2, CustomerTable.Address2Column));
            parameters.Add(CreateParameter(CustomerTable.CityParam, customer.City, CustomerTable.CityColumn));
            parameters.Add(CreateParameter(CustomerTable.StateParam, customer.State, CustomerTable.StateColumn));
            parameters.Add(CreateParameter(CustomerTable.ZipParam, customer.Zip, CustomerTable.ZipColumn));
            parameters.Add(CreateParameter(CustomerTable.CountryParam, customer.Country, CustomerTable.CountryColumn));


            if (categoryCheck.Count == 0)
                //does not exist, do INSERT
                return base.ExecuteNonQuery(parameters.ToArray(), CustomerTable.Insert);
            else
                //exists, do UPDATE
                return base.ExecuteNonQuery(parameters.ToArray(), CustomerTable.UpdateById);
        }

        public override void Save(Collection<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Save(customer);  
            }
        }

        public override Collection<Customer> Get(Customer customer)
        {
            var parameters = new List<DbParameter>();

            #region Check each Property for a value, Add a parameter a value exists
            if(customer.Id != null)
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
            #endregion

            //Build a WHERE Clause using AND
            string commandText = BuildSQLTextWhereAND(CustomerTable.Select, parameters.ToArray());
            return ExecuteQuery(parameters.ToArray(), commandText);
        }

        #endregion

    }
}