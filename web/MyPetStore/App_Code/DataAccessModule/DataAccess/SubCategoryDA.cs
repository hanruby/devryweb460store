using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Text;


namespace DataAccessModule
{

    /// <summary>
    /// Summary description for CategoryDA
    /// </summary>
    public class SubCategoryDA : DataAccessBase<SubCategory>
    {
        #region Constructors
        public SubCategoryDA() : base()
        {
            //use the Category mapper
            mapper = new SubCategoryMapper();
        }
        
        public SubCategoryDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new SubCategoryMapper();
        }
        #endregion

        #region Implemented DataAccessBase Methods

        protected override Collection<SubCategory> GetBase(SubCategory subCategory, string whereSeperator, string whereOperator)
        {
            //return all rows if no object was given (SELECT * FROM TableName)
            if (subCategory == null)
                return ExecuteQuery(null, BuildSQLSelectText(SubCategoryTable.TableName, CategoryTable.TableName, null, "", ""));

            //Build Parameters for base query
            DatabaseParameter[] parameters = CreateAllParameters(subCategory);

            //Build SELECT CommandText
            string selectQuery = BuildSQLSelectText(SubCategoryTable.TableName, CategoryTable.TableName, parameters, whereSeperator, whereOperator);
            return ExecuteQuery(parameters, selectQuery);
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="subCategory">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<SubCategory> Get(SubCategory subCategory)
        {
            return GetBase(subCategory, "AND", "=");
        }

        /// <summary>
        /// Performs SELECT Query against Database based on the Values in the Business Object
        /// </summary>
        /// <param name="subCategory">business object used to form SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of business objects matching the SELECT Query</returns>
        /// <remarks></remarks>
        public override Collection<SubCategory> GetLike(SubCategory subCategory)
        {
            return GetBase(subCategory, "AND", "LIKE");
        }

        public override int Save(SubCategory subCategory)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DatabaseParameter[1];
            checkParam[0] = CreateParameter(SubCategoryTable.TableName, SubCategoryTable.IdParam, subCategory.Id, SubCategoryTable.IdColumn);

            string commandText = base.BuildSQLSelectText(SubCategoryTable.TableName, checkParam, "", "=");
            Collection<SubCategory> subCategoryCheck = ExecuteQuery(checkParam, commandText);


            //Build Parameters for base query
            DatabaseParameter[] parameters = CreateAllParameters(subCategory);
            

            if (subCategoryCheck.Count == 0)
            {
                int rowsAffected;
                //Row does not exist, do INSERT

                //INSERT SubCategory
                DatabaseParameter[] subCategoryParameters = CreateAllParameters(subCategory);
                string insertSubCategoryCommandText = base.BuildSQLInsertText(SubCategoryTable.TableName, parameters);
                rowsAffected = base.ExecuteNonQuery(parameters, insertSubCategoryCommandText);

                //INSERT Category
                DatabaseParameter[] categoryParameters = CreateAllParameters(subCategory);
                string insertCategoryCommandText = base.BuildSQLInsertText(SubCategoryTable.TableName, parameters);
                rowsAffected += base.ExecuteNonQuery(parameters, insertCategoryCommandText);

                return rowsAffected;

            }
            else
            {   //Row exists, do UPDATE
                
                //Build Parameters for WHERE clause using Primary Key
                List<DatabaseParameter> whereParameters = new List<DatabaseParameter>();
                whereParameters.Add(CreateParameter(SubCategoryTable.TableName, SubCategoryTable.IdParam, subCategory.Id, SubCategoryTable.IdColumn));

                string updateCommandText = base.BuildSQLUpdateText(SubCategoryTable.TableName, parameters, whereParameters.ToArray(), "AND", "=");
                return base.ExecuteNonQuery(parameters, updateCommandText);
            }
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override int Save(Collection<SubCategory> items)
        {
            int rowsAffected = 0;

            foreach (var item in items)
            {
                rowsAffected += Save(item);
            }

            return rowsAffected;
        }

        public override int Delete(SubCategory subCategory)
        {
            //Build DELETE statement using Primary Key
            DatabaseParameter[] whereParameters = new DatabaseParameter[1];
            whereParameters[0] = (CreateParameter(SubCategoryTable.TableName, SubCategoryTable.IdParam, subCategory.Id, SubCategoryTable.IdColumn));

            string updateCommandText = base.BuildSQLDeleteText(SubCategoryTable.TableName, whereParameters, "AND", "=");
            return base.ExecuteNonQuery(whereParameters, updateCommandText);
        }
        public override int Delete(Collection<SubCategory> categories)
        {
            int rowsDeleted = 0;
            
            foreach (var subCategory in categories)
            {
                rowsDeleted += Delete(subCategory);
            }
            
            return rowsDeleted;
        }


        protected override DatabaseParameter[] CreateAllParameters(SubCategory subCategory)
        {
            //Build Parameters from Properties with Values
            List<DatabaseParameter> parameters = new List<DatabaseParameter>();

            parameters.AddRange(CreateCategoryParameters(subCategory));
            parameters.AddRange(CreateSubCategoryParameters(subCategory));
            
            return parameters.ToArray();
        }
        protected DatabaseParameter[] CreateCategoryParameters(SubCategory subCategory)
        {
            //Build Parameters from Properties with Values
            List<DatabaseParameter> parameters = new List<DatabaseParameter>();

            //Id
            if (subCategory.Id != null)
                parameters.Add(CreateParameter(CategoryTable.TableName, CategoryTable.IdParam, subCategory.ParentCategory.Id, CategoryTable.IdColumn));
            //Name
            if (subCategory.Name != null)
                parameters.Add(CreateParameter(CategoryTable.TableName, CategoryTable.NameParam, subCategory.ParentCategory.Name, CategoryTable.NameColumn));
            //ImageLocation
            if (subCategory.ImageLocation != null)
                parameters.Add(CreateParameter(CategoryTable.TableName, CategoryTable.ImageParam, subCategory.ParentCategory.ImageLocation, CategoryTable.ImageColumn));

            return parameters.ToArray();
        }

        protected DatabaseParameter[] CreateSubCategoryParameters(SubCategory subCategory)
        {
            //Build Parameters from Properties with Values
            List<DatabaseParameter> parameters = new List<DatabaseParameter>();

            //Id
            if (subCategory.Id != null)
                parameters.Add(CreateParameter(SubCategoryTable.TableName, SubCategoryTable.IdParam, subCategory.Id, SubCategoryTable.IdColumn));
            //CategoryId
            if (subCategory.Id != null)
                parameters.Add(CreateParameter(CategoryTable.TableName, CategoryTable.IdParam, subCategory.ParentCategory.Id, CategoryTable.IdColumn));
            //Name
            if (subCategory.Name != null)
                parameters.Add(CreateParameter(SubCategoryTable.TableName, SubCategoryTable.NameParam, subCategory.Name, SubCategoryTable.NameColumn));
            //ImageLocation
            if (subCategory.ImageLocation != null)
                parameters.Add(CreateParameter(SubCategoryTable.TableName, SubCategoryTable.ImageParam, subCategory.ImageLocation, SubCategoryTable.ImageColumn));

            return parameters.ToArray();
        }
        protected string BuildSQLSelectText(string subCategoryTable, string categoryTable, DatabaseParameter[] whereParameters, string whereSeperator, string whereOperator)
        {
            //SELECT FROM TableName
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("SELECT * FROM {0} LEFT JOIN {1} ON {2} = {3}", subCategoryTable, categoryTable, SubCategoryTable.ParentCategoryIdColumn, CategoryTable.IdColumn);

            //No parameters were given, do SELECT * FROM TableName
            if (whereParameters == null)
                return builder.ToString();

            //WHERE whereCol1 = @whereParam1
            builder.AppendFormat(" WHERE {0}.{1} {2} {3}", whereParameters[0].TableName, whereParameters[0].Parameter.SourceColumn, whereOperator, whereParameters[0].Parameter.ParameterName);

            //AND whereCol2 = @whereParam2, whereCol3 = @whereParam3, ...
            if (whereParameters.Length > 1)
            {
                for (int i = 1; i < whereParameters.Length; i++)
                {
                    builder.AppendFormat(" {0} {1}.{2} {3} {4}", whereSeperator, whereParameters[i].TableName, whereParameters[i].Parameter.SourceColumn, whereOperator, whereParameters[i].Parameter.ParameterName);
                }
            }

            return builder.ToString();
        }
        #endregion
    }
}