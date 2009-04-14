using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;


namespace DataAccessModule
{

    /// <summary>
    /// Summary description for VendorDA
    /// </summary>
    public class VendorDA : DataAccessBase<Vendor>
    {
        #region Constructors
        public VendorDA() : base()
        {
            //use the Vendor mapper
            mapper = new VendorMapper();
        }

        public VendorDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new VendorMapper();
        }
        #endregion

        #region Implemented DataAccessBase Methods

        protected override Collection<Vendor> GetBase(Vendor vendor, string whereSeperator, string whereOperator)
        {
            //return all rows if no object was given (SELECT * FROM TableName)
            if (vendor == null)
                return ExecuteQuery(null, BuildSQLSelectText(VendorTable.TableName, null, "", ""));

            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(vendor);

            //Build a SELECT CommandText
            string selectQuery = base.BuildSQLSelectText(VendorTable.TableName, parameters, whereSeperator, whereOperator);
            return ExecuteQuery(parameters, selectQuery);
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="vendor">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<Vendor> Get(Vendor vendor)
        {
            return GetBase(vendor, "AND", "=");
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="vendor">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<Vendor> GetLike(Vendor vendor)
        {
            return GetBase(vendor, "AND", "LIKE");
        }

        public override int Save(Vendor vendor)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(VendorTable.IdParam, vendor.Id, VendorTable.IdColumn);
            string commandText = base.BuildSQLSelectText(VendorTable.TableName, checkParam, "", "=");
            Collection<Vendor> vendorCheck = ExecuteQuery(checkParam, commandText);


            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(vendor);
            

            if (vendorCheck.Count == 0)
            {
                //Row does not exist, do INSERT
                string insertCommandText = base.BuildSQLInsertText(VendorTable.TableName, parameters);
                return base.ExecuteNonQuery(parameters, insertCommandText);
            }
            else
            {   //Row exists, do UPDATE
                
                //Build Parameters for WHERE clause using Primary Key
                List<DbParameter> whereParameters = new List<DbParameter>();
                whereParameters.Add(CreateParameter(VendorTable.IdParam, vendor.Id, VendorTable.IdColumn));

                string updateCommandText = base.BuildSQLUpdateText(VendorTable.TableName, parameters, whereParameters.ToArray(), "AND", "=");
                return base.ExecuteNonQuery(parameters, updateCommandText);
            }
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override int Save(Collection<Vendor> items)
        {
            int rowsAffected = 0;

            foreach (var item in items)
            {
                rowsAffected += Save(item);
            }

            return rowsAffected;
        }

        public override int Delete(Vendor vendor)
        {
            //Build DELETE statement using Primary Key
            DbParameter[] whereParameters = new DbParameter[1];
            whereParameters[0] = (CreateParameter(VendorTable.IdParam, vendor.Id, VendorTable.IdColumn));

            string updateCommandText = base.BuildSQLDeleteText(VendorTable.TableName, whereParameters, "AND", "=");
            return base.ExecuteNonQuery(whereParameters, updateCommandText);
        }
        public override int Delete(Collection<Vendor> categories)
        {
            int rowsDeleted = 0;
            
            foreach (var vendor in categories)
            {
                rowsDeleted += Delete(vendor);
            }
            
            return rowsDeleted;
        }


        protected override DbParameter[] CreateAllParameters(Vendor vendor)
        {
            //Build Parameters from Properties with Values
            List<DbParameter> parameters = new List<DbParameter>();

            if (vendor.Id != null)
                parameters.Add(CreateParameter(VendorTable.IdParam, vendor.Id, VendorTable.IdColumn));
            if (vendor.IsActive != null)
                parameters.Add(CreateParameter(VendorTable.IsActiveParam, vendor.IsActive, VendorTable.IsActiveColumn));
            if (vendor.Name != null)
                parameters.Add(CreateParameter(VendorTable.NameParam, vendor.Name, VendorTable.NameColumn));
            if (vendor.MainPhone != null)
                parameters.Add(CreateParameter(VendorTable.MainPhoneParam, vendor.MainPhone, VendorTable.MainPhoneColumn));
            if (vendor.ContactName != null)
                parameters.Add(CreateParameter(VendorTable.ContactNameParam, vendor.ContactName, VendorTable.ContactNameColumn));
            if (vendor.Email != null)
                parameters.Add(CreateParameter(VendorTable.EmailParam, vendor.Email, VendorTable.EmailColumn));
            if (vendor.Phone != null)
                parameters.Add(CreateParameter(VendorTable.PhoneParam, vendor.Phone, VendorTable.PhoneColumn));
            if (vendor.Website != null)
                parameters.Add(CreateParameter(VendorTable.WebsiteParam, vendor.Website, VendorTable.WebsiteColumn));
            if (vendor.Address != null)
                parameters.Add(CreateParameter(VendorTable.AddressParam, vendor.Address, VendorTable.AddressColumn));
            if (vendor.Address2 != null)
                parameters.Add(CreateParameter(VendorTable.Address2Param, vendor.Address2, VendorTable.Address2Column));
            if (vendor.City != null)
                parameters.Add(CreateParameter(VendorTable.CityParam, vendor.City, VendorTable.CityColumn));
            if (vendor.State != null)
                parameters.Add(CreateParameter(VendorTable.StateParam, vendor.State, VendorTable.StateColumn));
            if (vendor.Zip != null)
                parameters.Add(CreateParameter(VendorTable.ZipParam, vendor.Zip, VendorTable.ZipColumn));
            if (vendor.Country != null)
                parameters.Add(CreateParameter(VendorTable.CountryParam, vendor.Country, VendorTable.CountryColumn));

            return parameters.ToArray();
        }

        #endregion
    }
}