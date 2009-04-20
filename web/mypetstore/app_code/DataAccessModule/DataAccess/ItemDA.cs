using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;


namespace DataAccessModule
{

    /// <summary>
    /// Summary description for ItemDA
    /// </summary>
    public class ItemDA : DataAccessBase<Item>
    {
        #region Constructors
        public ItemDA() : base()
        {
            //use the Item mapper
            mapper = new ItemMapper();
        }

        public ItemDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new ItemMapper();
        }
        #endregion

        #region Implemented DataAccessBase Methods

        protected override Collection<Item> GetBase(Item item, string whereSeperator, string whereOperator)
        {
            //return all rows if no object was given (SELECT * FROM TableName)
            if (item == null)
                return ExecuteQuery(null, BuildSQLSelectText(ItemTable.TableName, null, "", ""));

            //Build Parameters for base query
            DatabaseParameter[] parameters = CreateAllParameters(item);

            //Build a SELECT CommandText
            string selectQuery = base.BuildSQLSelectText(ItemTable.TableName, parameters, whereSeperator, whereOperator);
            return ExecuteQuery(parameters, selectQuery);
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="item">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<Item> Get(Item item)
        {
            return GetBase(item, "AND", "=");
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="item">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<Item> GetLike(Item item)
        {
            return GetBase(item, "AND", "LIKE");
        }

        public override int Save(Item item)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DatabaseParameter[1];
            checkParam[0] = CreateParameter(ItemTable.TableName, ItemTable.IdParam, item.Id, ItemTable.IdColumn);
            string commandText = base.BuildSQLSelectText(ItemTable.TableName, checkParam, "", "=");
            Collection<Item> itemCheck = ExecuteQuery(checkParam, commandText);


            //Build Parameters for base query
            DatabaseParameter[] parameters = CreateAllParameters(item);
            

            if (itemCheck.Count == 0)
            {
                //Row does not exist, do INSERT
                string insertCommandText = base.BuildSQLInsertText(ItemTable.TableName, parameters);
                return base.ExecuteNonQuery(parameters, insertCommandText);
            }
            else
            {   //Row exists, do UPDATE
                
                //Build Parameters for WHERE clause using Primary Key
                List<DatabaseParameter> whereParameters = new List<DatabaseParameter>();
                whereParameters.Add(CreateParameter(ItemTable.TableName, ItemTable.IdParam, item.Id, ItemTable.IdColumn));

                string updateCommandText = base.BuildSQLUpdateText(ItemTable.TableName, parameters, whereParameters.ToArray(), "AND", "=");
                return base.ExecuteNonQuery(parameters, updateCommandText);
            }
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override int Save(Collection<Item> items)
        {
            int rowsAffected = 0;

            foreach (var item in items)
            {
                rowsAffected += Save(item);
            }

            return rowsAffected;
        }

        public override int Delete(Item item)
        {
            //Build DELETE statement using Primary Key
            DatabaseParameter[] whereParameters = new DatabaseParameter[1];
            whereParameters[0] = (CreateParameter(ItemTable.TableName, ItemTable.IdParam, item.Id, ItemTable.IdColumn));

            string updateCommandText = base.BuildSQLDeleteText(ItemTable.TableName, whereParameters, "AND", "=");
            return base.ExecuteNonQuery(whereParameters, updateCommandText);
        }
        public override int Delete(Collection<Item> categories)
        {
            int rowsDeleted = 0;
            
            foreach (var item in categories)
            {
                rowsDeleted += Delete(item);
            }
            
            return rowsDeleted;
        }


        protected override DatabaseParameter[] CreateAllParameters(Item item)
        {
            //Build Parameters from Properties with Values
            List<DatabaseParameter> parameters = new List<DatabaseParameter>();

            //Id
            if (item.Id != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.IdParam, item.Id, ItemTable.IdColumn));
            //VendorId
            if (item.VendorId != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.VendorIdParam, item.VendorId, ItemTable.VendorIdColumn));
            //IsActive
            if (item.IsActive != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.IsActiveParam, item.IsActive, ItemTable.IsActiveColumn));
            //Description
            if (item.Description != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.DescriptionParam, item.Description, ItemTable.DescriptionColumn));
            //QuantityAvailable
            if (item.QuantityAvailable != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.QuantityAvailableParam, item.QuantityAvailable, ItemTable.QuantityAvailableColumn));
            //Price
            if (item.Price != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.PriceParam, item.Price, ItemTable.PriceColumn));
            //ImageName
            if (item.ImageName != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.ImageNameParam, item.ImageName, ItemTable.ImageNameColumn));
            //ImageLocation
            if (item.ImageLocation != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.ImageLocationParam, item.ImageLocation, ItemTable.ImageLocationColumn));
            //MinQuantity
            if (item.MinQuantity != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.MinQuantityParam, item.MinQuantity, ItemTable.MinQuantityColumn));
            //CostPrice
            if (item.CostPrice != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.CostPriceParam, item.CostPrice, ItemTable.CostPriceColumn));
            //RecommendedPrice
            if (item.RecommendPrice != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.RecommendedPriceParam, item.RecommendPrice, ItemTable.RecommendedPriceColumn));
            //UPC
            if (item.Upc != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.UPCParam, item.Upc, ItemTable.UPCColumn));
            //Name
            if (item.Name != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.NameParam, item.Name, ItemTable.NameColumn));
            //Code
            if (item.Code != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.CodeParam, item.Code, ItemTable.CodeColumn));
            //Size
            if (item.Size != null)
                parameters.Add(CreateParameter(ItemTable.TableName, ItemTable.SizeParam, item.Size, ItemTable.SizeColumn));

            return parameters.ToArray();
        }

        #endregion
    }
}