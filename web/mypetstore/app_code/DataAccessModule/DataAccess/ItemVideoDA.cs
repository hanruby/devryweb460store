using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;


namespace DataAccessModule
{

    /// <summary>
    /// Summary description for ItemVideoDA
    /// </summary>
    public class ItemVideoDA : DataAccessBase<ItemVideo>
    {
        #region Constructors
        public ItemVideoDA() : base()
        {
            //use the ItemVideo mapper
            mapper = new ItemVideoMapper();
        }

        public ItemVideoDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new ItemVideoMapper();
        }
        #endregion

        #region Implemented DataAccessBase Methods

        protected override Collection<ItemVideo> GetBase(ItemVideo itemVideo, string whereSeperator, string whereOperator)
        {
            //return all rows if no object was given (SELECT * FROM TableName)
            if (itemVideo == null)
                return ExecuteQuery(null, BuildSQLSelectText(ItemVideoTable.TableName, null, "", ""));

            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(itemVideo);

            //Build a SELECT CommandText
            string selectQuery = base.BuildSQLSelectText(ItemVideoTable.TableName, parameters, whereSeperator, whereOperator);
            return ExecuteQuery(parameters, selectQuery);
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="itemVideo">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<ItemVideo> Get(ItemVideo itemVideo)
        {
            return GetBase(itemVideo, "AND", "=");
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="itemVideo">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<ItemVideo> GetLike(ItemVideo itemVideo)
        {
            return GetBase(itemVideo, "AND", "LIKE");
        }

        public override int Save(ItemVideo itemVideo)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(ItemVideoTable.IdParam, itemVideo.Id, ItemVideoTable.IdColumn);
            string commandText = base.BuildSQLSelectText(ItemVideoTable.TableName, checkParam, "", "=");
            Collection<ItemVideo> itemVideoCheck = ExecuteQuery(checkParam, commandText);


            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(itemVideo);
            

            if (itemVideoCheck.Count == 0)
            {
                //Row does not exist, do INSERT
                string insertCommandText = base.BuildSQLInsertText(ItemVideoTable.TableName, parameters);
                return base.ExecuteNonQuery(parameters, insertCommandText);
            }
            else
            {   //Row exists, do UPDATE
                
                //Build Parameters for WHERE clause using Primary Key
                List<DbParameter> whereParameters = new List<DbParameter>();
                whereParameters.Add(CreateParameter(ItemVideoTable.IdParam, itemVideo.Id, ItemVideoTable.IdColumn));

                string updateCommandText = base.BuildSQLUpdateText(ItemVideoTable.TableName, parameters, whereParameters.ToArray(), "AND", "=");
                return base.ExecuteNonQuery(parameters, updateCommandText);
            }
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override int Save(Collection<ItemVideo> items)
        {
            int rowsAffected = 0;

            foreach (var item in items)
            {
                rowsAffected += Save(item);
            }

            return rowsAffected;
        }

        public override int Delete(ItemVideo itemVideo)
        {
            //Build DELETE statement using Primary Key
            DbParameter[] whereParameters = new DbParameter[1];
            whereParameters[0] = (CreateParameter(ItemVideoTable.IdParam, itemVideo.Id, ItemVideoTable.IdColumn));

            string updateCommandText = base.BuildSQLDeleteText(ItemVideoTable.TableName, whereParameters, "AND", "=");
            return base.ExecuteNonQuery(whereParameters, updateCommandText);
        }
        public override int Delete(Collection<ItemVideo> categories)
        {
            int rowsDeleted = 0;
            
            foreach (var itemVideo in categories)
            {
                rowsDeleted += Delete(itemVideo);
            }
            
            return rowsDeleted;
        }


        protected override DbParameter[] CreateAllParameters(ItemVideo itemVideo)
        {
            //Build Parameters from Properties with Values
            List<DbParameter> parameters = new List<DbParameter>();

            if (itemVideo.Id != null)
                parameters.Add(CreateParameter(ItemVideoTable.IdParam, itemVideo.Id, ItemVideoTable.IdColumn));
            if (itemVideo.ItemId != null)
                parameters.Add(CreateParameter(ItemVideoTable.ItemIdParam, itemVideo.ItemId, ItemVideoTable.ItemIdColumn));
            if (itemVideo.VendorId != null)
                parameters.Add(CreateParameter(ItemVideoTable.VendorIdParam, itemVideo.VendorId, ItemVideoTable.VendorIdColumn));
            if (itemVideo.VideoName != null)
                parameters.Add(CreateParameter(ItemVideoTable.NameParam, itemVideo.VideoName, ItemVideoTable.NameColumn));
            if (itemVideo.Description != null)
                parameters.Add(CreateParameter(ItemVideoTable.DescriptionParam, itemVideo.Description, ItemVideoTable.DescriptionColumn));
            if (itemVideo.Url != null)
                parameters.Add(CreateParameter(ItemVideoTable.UrlParam, itemVideo.Url, ItemVideoTable.UrlColumn));
            if (itemVideo.Source != null)
                parameters.Add(CreateParameter(ItemVideoTable.SourceParam, itemVideo.Source, ItemVideoTable.SourceColumn));

            return parameters.ToArray();
        }

        #endregion
    }
}