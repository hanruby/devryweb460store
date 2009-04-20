using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;


namespace DataAccessModule
{

    /// <summary>
    /// Summary description for ItemCategoryDA
    /// </summary>
    public class ItemCategoryDA : DataAccessBase<ItemCategory>
    {
        #region Constructors
        public ItemCategoryDA() : base()
        {
            //use the ItemCategory mapper
            mapper = new ItemCategoryMapper();
        }

        public ItemCategoryDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new ItemCategoryMapper();
        }
        #endregion

        #region Implemented DataAccessBase Methods

        protected override Collection<ItemCategory> GetBase(ItemCategory itemCategory, string whereSeperator, string whereOperator)
        {
            //return all rows if no object was given (SELECT * FROM TableName)
            if (itemCategory == null)
                return ExecuteQuery(null, BuildSQLSelectText(ItemCategoryTable.TableName, null, "", ""));

            //Build Parameters for base query
            DatabaseParameter[] parameters = CreateAllParameters(itemCategory);

            //Build a SELECT CommandText
            string selectQuery = base.BuildSQLSelectText(ItemCategoryTable.TableName, parameters, whereSeperator, whereOperator);
            return ExecuteQuery(parameters, selectQuery);
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="itemCategory">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<ItemCategory> Get(ItemCategory itemCategory)
        {
            return GetBase(itemCategory, "AND", "=");
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="itemCategory">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<ItemCategory> GetLike(ItemCategory itemCategory)
        {
            return GetBase(itemCategory, "AND", "LIKE");
        }

        public override int Save(ItemCategory itemCategory)
        {
            //Check for the objects existsence in the database using the Primary key
            DatabaseParameter[] checkParam = new DatabaseParameter[3];
            checkParam[0] = CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.ItemIdParam, itemCategory.ItemId, ItemCategoryTable.ItemIdColumn);
            checkParam[1] = CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.VendorIdParam, itemCategory.VendorId, ItemCategoryTable.VendorIdColumn);
            checkParam[2] = CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.CategoryIdParam, itemCategory.CategoryId, ItemCategoryTable.CategoryIdColumn);

            string commandText = base.BuildSQLSelectText(ItemCategoryTable.TableName, checkParam, "", "=");
            Collection<ItemCategory> itemCategoryCheck = ExecuteQuery(checkParam, commandText);


            //Build Parameters for base query
            DatabaseParameter[] parameters = CreateAllParameters(itemCategory);
            

            if (itemCategoryCheck.Count == 0)
            {
                //Row does not exist, do INSERT
                string insertCommandText = base.BuildSQLInsertText(ItemCategoryTable.TableName, parameters);
                return base.ExecuteNonQuery(parameters, insertCommandText);
            }
            else
            {   //Row exists, do UPDATE
                
                //Build Parameters for WHERE clause using Primary Key
                DatabaseParameter[] whereParameters = new DatabaseParameter[3];
                whereParameters[0] = CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.ItemIdParam, itemCategory.ItemId, ItemCategoryTable.ItemIdColumn);
                whereParameters[1] = CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.VendorIdParam, itemCategory.VendorId, ItemCategoryTable.VendorIdColumn);
                whereParameters[2] = CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.CategoryIdParam, itemCategory.CategoryId, ItemCategoryTable.CategoryIdColumn);

                string updateCommandText = base.BuildSQLUpdateText(ItemCategoryTable.TableName, parameters, whereParameters, "AND", "=");
                return base.ExecuteNonQuery(parameters, updateCommandText);
            }
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override int Save(Collection<ItemCategory> items)
        {
            int rowsAffected = 0;

            foreach (var item in items)
            {
                rowsAffected += Save(item);
            }

            return rowsAffected;
        }

        public override int Delete(ItemCategory itemCategory)
        {
            //Build DELETE statement using Primary Key
            DatabaseParameter[] whereParameters = new DatabaseParameter[3];
            whereParameters[0] = CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.ItemIdParam, itemCategory.ItemId, ItemCategoryTable.ItemIdColumn);
            whereParameters[1] = CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.VendorIdParam, itemCategory.VendorId, ItemCategoryTable.VendorIdColumn);
            whereParameters[2] = CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.CategoryIdParam, itemCategory.CategoryId, ItemCategoryTable.CategoryIdColumn);

            string updateCommandText = base.BuildSQLDeleteText(ItemCategoryTable.TableName, whereParameters, "AND", "=");
            return base.ExecuteNonQuery(whereParameters, updateCommandText);
        }
        public override int Delete(Collection<ItemCategory> categories)
        {
            int rowsDeleted = 0;
            
            foreach (var itemCategory in categories)
            {
                rowsDeleted += Delete(itemCategory);
            }
            
            return rowsDeleted;
        }


        protected override DatabaseParameter[] CreateAllParameters(ItemCategory itemCategory)
        {
            //Build Parameters from Properties with Values
            List<DatabaseParameter> parameters = new List<DatabaseParameter>();

            if (itemCategory.ItemId != null)
                parameters.Add(CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.ItemIdParam, itemCategory.ItemId, ItemCategoryTable.ItemIdColumn));
            if (itemCategory.VendorId != null)
                parameters.Add(CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.VendorIdParam, itemCategory.VendorId, ItemCategoryTable.VendorIdColumn));
            if (itemCategory.CategoryId != null)
                parameters.Add(CreateParameter(ItemCategoryTable.TableName, ItemCategoryTable.CategoryIdParam, itemCategory.CategoryId, ItemCategoryTable.CategoryIdColumn));

            return parameters.ToArray();
        }

        #endregion
    }
}