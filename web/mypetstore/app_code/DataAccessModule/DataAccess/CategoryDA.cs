using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;


namespace DataAccessModule
{

    /// <summary>
    /// Summary description for CategoryDA
    /// </summary>
    public class CategoryDA : DataAccessBase<Category>
    {
        #region Constructors
        public CategoryDA() : base()
        {
            //use the Category mapper
            mapper = new CategoryMapper();
        }

        public CategoryDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new CategoryMapper();
        }
        #endregion

        #region Implemented DataAccessBase Methods

        protected override Collection<Category> GetBase(Category category, string whereSeperator, string whereOperator)
        {
            //return all rows if no object was given (SELECT * FROM TableName)
            if (category == null)
                return ExecuteQuery(null, BuildSQLSelectText(CategoryTable.TableName, null, "", ""));

            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(category);

            //Build a SELECT CommandText
            string selectQuery = base.BuildSQLSelectText(CategoryTable.TableName, parameters, whereSeperator, whereOperator);
            return ExecuteQuery(parameters, selectQuery);
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="category">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<Category> Get(Category category)
        {
            return GetBase(category, "AND", "=");
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="category">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<Category> GetLike(Category category)
        {
            return GetBase(category, "AND", "LIKE");
        }

        public override int Save(Category category)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(CategoryTable.IdParam, category.Id, CategoryTable.IdColumn);
            string commandText = base.BuildSQLSelectText(CategoryTable.TableName, checkParam, "", "=");
            Collection<Category> categoryCheck = ExecuteQuery(checkParam, commandText);


            //Build Parameters for base query
            DbParameter[] parameters = CreateAllParameters(category);
            

            if (categoryCheck.Count == 0)
            {
                //Row does not exist, do INSERT
                string insertCommandText = base.BuildSQLInsertText(CategoryTable.TableName, parameters);
                return base.ExecuteNonQuery(parameters, insertCommandText);
            }
            else
            {   //Row exists, do UPDATE
                
                //Build Parameters for WHERE clause using Primary Key
                List<DbParameter> whereParameters = new List<DbParameter>();
                whereParameters.Add(CreateParameter(CategoryTable.IdParam, category.Id, CategoryTable.IdColumn));

                string updateCommandText = base.BuildSQLUpdateText(CategoryTable.TableName, parameters, whereParameters.ToArray(), "AND", "=");
                return base.ExecuteNonQuery(parameters, updateCommandText);
            }
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override int Save(Collection<Category> items)
        {
            int rowsAffected = 0;

            foreach (var item in items)
            {
                rowsAffected += Save(item);
            }

            return rowsAffected;
        }

        public override int Delete(Category category)
        {
            //Build DELETE statement using Primary Key
            DbParameter[] whereParameters = new DbParameter[1];
            whereParameters[0] = (CreateParameter(CategoryTable.IdParam, category.Id, CategoryTable.IdColumn));

            string updateCommandText = base.BuildSQLDeleteText(CategoryTable.TableName, whereParameters, "AND", "=");
            return base.ExecuteNonQuery(whereParameters, updateCommandText);
        }
        public override int Delete(Collection<Category> categories)
        {
            int rowsDeleted = 0;
            
            foreach (var category in categories)
            {
                rowsDeleted += Delete(category);
            }
            
            return rowsDeleted;
        }


        protected override DbParameter[] CreateAllParameters(Category category)
        {
            //Build Parameters from Properties with Values
            List<DbParameter> parameters = new List<DbParameter>();

            //Id
            if (category.Id != null)
                parameters.Add(CreateParameter(CategoryTable.IdParam, category.Id, CategoryTable.IdColumn));
            //Name
            if (category.Name != null)
                parameters.Add(CreateParameter(CategoryTable.NameParam, category.Name, CategoryTable.NameColumn));
            //ImageLocation
            if (category.ImageLocation != null)
                parameters.Add(CreateParameter(CategoryTable.ImageParam, category.ImageLocation, CategoryTable.ImageColumn));

            return parameters.ToArray();
        }

        #endregion
    }
}