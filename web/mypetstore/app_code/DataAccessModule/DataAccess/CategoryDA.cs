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

        #region Overridden Methods
       

        #region Save & Get
        /// <summary>
        /// Saves an Item object to a Database
        /// </summary>
        /// <param name="category">Item to be saved in to the database(INSERTed or UPDATEd)</param>
        /// <returns></returns>
        public override int Save(Category category)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(CategoryTable.IdParam, category.Id);
            Collection<Category> categoryCheck = ExecuteQuery(checkParam, CategoryTable.SelectById);

            //Add parameters
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(CreateParameter(CategoryTable.IdParam, category.Id));
            parameters.Add(CreateParameter(CategoryTable.NameParam, category.Name));
            parameters.Add(CreateParameter(CategoryTable.ImageParam, category.ImageLocation));


            if (categoryCheck.Count == 0)
                //does not exist, do INSERT
                return base.ExecuteNonQuery(parameters.ToArray(), CategoryTable.Insert);
            else
                //exists, do UPDATE
                return base.ExecuteNonQuery(parameters.ToArray(), CategoryTable.UpdateById);
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override void Save(Collection<Category> items)
        {
            foreach (var item in items)
            {
                Save(item);
            }
        }


        public override Collection<Category> Get(Category category)
        {
            var parameters = new List<DbParameter>();

            #region Check each Property for a value, Add a parameter a value exists

            //Id
            if(category.Id != null)
                parameters.Add(CreateParameter(CategoryTable.IdParam, category.Id, CategoryTable.IdColumn));
            //Name
            if (category.Name != null)
            parameters.Add(CreateParameter(CategoryTable.NameParam, category.Name, CategoryTable.NameColumn ));
            //ImageLocation
            if (category.ImageLocation != null)
            parameters.Add(CreateParameter(CategoryTable.ImageParam, category.ImageLocation, CategoryTable.ImageColumn));
            #endregion

            //Build a WHERE Clause using AND
            string commandText = BuildSQLTextWhereAND(CategoryTable.Select, parameters.ToArray());
            return ExecuteQuery(parameters.ToArray(), commandText);
        }

        #endregion



        #endregion
    }
}