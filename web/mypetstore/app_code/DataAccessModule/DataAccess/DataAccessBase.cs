using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Configuration;
using System.Reflection;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DataAccessModule
{


    public abstract class DataAccessBase<T>
    {
        #region Abstract Members

        /// <summary>
        /// This Method is not meant for external use
        /// Used By other Get*() Methods; Performs SELECT Query based on values set in the Business Object 
        /// </summary>
        /// <param name="businessObject">Object used to build SELECT Query (null will return all rows in the Table)</param>
        /// <param name="whereSeperator">the string used to seperate statements (AND/OR) in the WHERE cluase</param>
        /// <param name="whereOperator">the operator (=, LIKE, ..etc) used in the WHERE cluase</param>
        /// <returns>Collection of Business Objects matching the generated SELECT Query</returns>
        protected abstract Collection<T> GetBase(T businessObject, string whereSeperator, string whereOperator);
        
        /// <summary>
        ///Performs SELECT AND Query based on values set in the Business Object (uses AND in the WHERE statement)
        /// </summary>
        /// <param name="businessObject">Object used to build SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of Business Objects matching the generated SELECT Query: SELECT * FROM TableName WHERE col1 = @val1 AND col2 = @val2</returns>
        public abstract Collection<T> Get(T businessObject);

        /// <summary>
        /// Performs SELECT LIKE Query based on values set in the Business Object
        /// </summary>
        /// <param name="businessObject">Object used to build SELECT Query (null will return all rows in the Table)</param>
        /// <returns>Collection of Business Objects matching the generated SELECT Query: SELECT * FROM TableName WHERE col1 LIKE @pattern1 AND col2 LIKE @pattern2)</returns>
        public abstract Collection<T> GetLike(T businessObject);

        /// <summary>
        /// INSERTs or UPDATEs the Database
        /// </summary>
        /// <param name="businessObjectList">Business objects to be INSERTED or UPDATED</param>        
        /// <returns>Rows affected</returns>
        public abstract int Save(Collection<T> businessObjectList);

        /// <summary>
        /// INSERTs or UPDATEs the Database
        /// </summary>
        /// <param name="businessObject">Business object to be INSERTED or UPDATED</param>
        /// <returns>Rows affected</returns>
        public abstract int Save(T businessObject);

        /// <summary>
        /// DELETEs the row matching the Business Object
        /// </summary>
        /// <param name="businessObject">Used to build DELETE statement: DELETE FROM TableName WHERE col1 = @val1 AND col2 = @val2</param>
        /// <returns>Rows affected</returns>
        public abstract int Delete(T businessObject);

        /// <summary>
        /// DELETEs the rows matching the Business Objects
        /// </summary>
        /// <param name="businessObjects">Used to build DELETE statements: DELETE FROM TableName WHERE col1 = @val1 AND col2 = @val2</param>
        /// <returns>Rows affected</returns>
        public abstract int Delete(Collection<T> businessObjects);


        /// <summary>
        /// Creates parameters from the Properties of a Business Object
        /// </summary>
        /// <returns>Generated parameters</returns>
        protected abstract DatabaseParameter[] CreateAllParameters(T businessObject);
        #endregion

        #region Attributes
        protected string connectionString;
        protected string providerInvariantName;
        protected DbProviderFactory dbProviderFactory;
        protected MapperBase<T> mapper;
        #endregion


        //Constructors
        #region Constructors

        /// <summary>
        /// Automatically gets the connection string and provider Name from web.config
        /// Creates a factory based on those values
        /// </summary>
        public DataAccessBase()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString;
            providerInvariantName = ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ProviderName;
            dbProviderFactory = DbProviderFactories.GetFactory(providerInvariantName);
        }

        public DataAccessBase(string connectionString, string providerInvariantName)
        {
            this.connectionString = connectionString;
            this.providerInvariantName = providerInvariantName;
            dbProviderFactory = DbProviderFactories.GetFactory(providerInvariantName);
        }
        #endregion

        //Methods
        #region Connection and Command Methods

        /// <summary>
        /// Creates a connection using the class's connection string
        /// </summary>
        /// <returns>DbConnection</returns>
        protected DbConnection CreateConnection()
        {
            DbConnection connection = dbProviderFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        /// <summary>
        /// Creates a command with a current connection
        /// </summary>
        /// <param name="commandText">SQL statement command text</param>
        /// <param name="connection">connection to be used</param>
        /// <returns>DbCommand</returns>
        protected DbCommand CreateCommand(string commandText, DbConnection connection)
        {
            DbCommand command = dbProviderFactory.CreateCommand();
            command.Connection = connection;
            command.CommandText = commandText;
            return command;
        }

        /// <summary>
        /// Creates a command with a new connection
        /// </summary>
        /// <param name="commandText">SQL statement command text</param>
        /// <returns>DbCommand</returns>
        protected DbCommand CreateCommand(string commandText)
        {
            DbCommand command = dbProviderFactory.CreateCommand();
            command.CommandText = commandText;
            command.Connection = CreateConnection();
            return command;
        }
        #endregion

        #region ExecuteNonQuery/Query Methods
        /// <summary>
        /// Executes a Non Query (Insert/Update/Delete)
        /// </summary>
        /// <param name="parameters">Parameters to use against the commandText</param>
        /// <param name="commandText">SQL statement commandText</param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(DatabaseParameter[] parameters, string commandText)
        {
            using (DbConnection connection = CreateConnection())
            {
                DbCommand command = CreateCommand(commandText, connection);
                foreach (DatabaseParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter.Parameter);
                }
                
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Executes a Query (SELECT)
        /// </summary>
        /// <param name="parameters">Parameters to use against the commandText</param>
        /// <param name="commandText">SQL statement commandText</param>
        /// <returns>Collection of Business Objects created by the mapper</returns>
        public virtual Collection<T> ExecuteQuery(DatabaseParameter[] parameters, string commandText)
        {
            using (DbConnection connection = CreateConnection())
            {
                DbCommand command = CreateCommand(commandText, connection);

                if(parameters != null)
                    foreach (DatabaseParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter.Parameter);
                    }
                    

                try
                {
                    connection.Open();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            Collection<T> collection = mapper.MapAll(reader);
                            return (collection);
                        }

                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        #endregion


        #region Parameter Methods
        /// <summary>
        /// Creates a parameter using DbProviderFactory
        /// </summary>
        /// <param name="paramName">Name of the parameter ex: @parametername</param>
        /// <param name="paramValue">Value to be inserted or used with the parameter</param>
        /// <param name="columnName">Name of the Column in the Database</param>
        /// <returns></returns>
        public DatabaseParameter CreateParameter(string tableName, string paramName, object paramValue, string columnName)
        {
            
            DbParameter dbParameter = dbProviderFactory.CreateParameter();
            dbParameter.ParameterName = paramName;
            dbParameter.Value = paramValue;
            dbParameter.SourceColumn = columnName;

            DatabaseParameter parameter = new DatabaseParameter(tableName, dbParameter);
            return parameter;
        }
        #endregion

        #region SQL CommandText Builders

        /// <summary>
        /// Creates INSERT command text
        /// </summary>
        /// <param name="tableName">Database Table INSERT is being performed on</param>
        /// <param name="parameters">Properties .ParameterName and .SourceColumn must be set</param>
        /// <returns>Generated INSERT command text</returns>
        protected virtual string BuildSQLInsertText(string tableName, DatabaseParameter[] parameters)
        {
            //INSERT INTO TableName
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("INSERT INTO [{0}]", tableName);

            //(col1, col2, col3)
            builder.AppendFormat("({0}", parameters[0].Parameter.SourceColumn);
            for (int i = 1; i < parameters.Length; i++)
            {
                builder.AppendFormat(", {0}", parameters[i].Parameter.SourceColumn);
            }
            builder.Append(")");

            //VALUES(@param1, @param2, @param3)
            builder.AppendFormat(" VALUES({0}", parameters[0].Parameter.ParameterName);
            for (int i = 1; i < parameters.Length; i++)
            {
                builder.AppendFormat(", {0}", parameters[i].Parameter.ParameterName);
            }
            builder.Append(")");

            return builder.ToString();
        }

        /// <summary>
        /// Creates UPDATE command text
        /// </summary>
        /// <param name="tableName">Database Table Update is being performed on</param>
        /// <param name="parameters">Parameters used to build the SET clause IMPORTANT(Properties .ParameterName and .SourceColumn must be set)</param>
        /// <param name="whereParameters">Parameters used to build the WHERE clause IMPORTANT(Properties .ParameterName and .SourceColumn must be set)</param>
        /// <param name="whereSeperator">the string used to seperate statements (AND/OR) in the WHERE cluase</param>
        /// <param name="whereOperator">the operator (=, LIKE, ..etc) used in the WHERE cluase</param>
        /// <returns>Generated UPDATE command text</returns>
        protected virtual string BuildSQLUpdateText(string tableName, DatabaseParameter[] parameters, DatabaseParameter[] whereParameters, string whereSeperator, string whereOperator)
        {
            //UPDATE TableName
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("UPDATE {0}", tableName);

            //SET col1 = @param1, col2 = @param2, col3 = @param3
            builder.AppendFormat(" SET {0} = {1}", parameters[0].Parameter.SourceColumn, parameters[0].Parameter.ParameterName);
            for (int i = 1; i < parameters.Length; i++)
            {
                builder.AppendFormat(", {0} = {1}", parameters[i].Parameter.SourceColumn, parameters[i].Parameter.ParameterName);
            }

            //WHERE pk1Col = @pk1Param
            builder.AppendFormat(" WHERE {0} {1} {2}", whereParameters[0].Parameter.SourceColumn, whereOperator, whereParameters[0].Parameter.ParameterName);

            //AND pk2Col = @pk2Param
            if (whereParameters.Length > 1)
            {
                for (int i = 1; i < whereParameters.Length; i++)
                {
                    builder.AppendFormat(" {0} {1} {2} {3}", whereSeperator, whereParameters[i].Parameter.SourceColumn, whereOperator, whereParameters[i].Parameter.ParameterName);
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Creates DELETE command text
        /// </summary>
        /// <param name="tableName">Database Table DELETE is being performed on</param>
        /// <param name="whereParameters">Parameters used to build the WHERE clause IMPORTANT(Properties .ParameterName and .SourceColumn must be set)</param>
        /// <param name="whereSeperator">the string used to seperate statements (AND/OR) in the WHERE cluase</param>
        /// <param name="whereOperator">the operator (=, LIKE, ..etc) used in the WHERE cluase</param>
        /// <returns>Generated DELETE command text</returns>
        protected virtual string BuildSQLDeleteText(string tableName, DatabaseParameter[] whereParameters, string whereSeperator, string whereOperator)
        {
            //DELETE FROM TableName
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("DELETE FROM {0}", tableName);

            //WHERE whereCol1 = @whereParam1
            builder.AppendFormat(" WHERE {0} {1} {2}", whereParameters[0].Parameter.SourceColumn, whereOperator, whereParameters[0].Parameter.ParameterName);

            //AND whereCol2 = @whereParam2, whereCol3 = @whereParam3, ...
            if (whereParameters.Length > 1)
            {
                for (int i = 1; i < whereParameters.Length; i++)
                {
                    builder.AppendFormat(" {0} {1} {2} {3}", whereSeperator, whereParameters[i].Parameter.SourceColumn, whereOperator, whereParameters[i].Parameter.ParameterName);
                }
            }

            return builder.ToString();
        }

        /// <summary>
        /// Creates SELECT command text
        /// </summary>
        /// <param name="tableNames">Database Table SELECT is being performed on</param>
        /// <param name="whereParameters">Parameters used to build the WHERE clause IMPORTANT(Properties .ParameterName and .SourceColumn must be set)</param>
        /// <param name="whereSeperator">the string used to seperate statements (AND/OR) in the WHERE cluase</param>
        /// <param name="whereOperator">the operator (=, LIKE, ..etc) used in the WHERE cluase</param>
        /// <returns>Generated SELECT AND command text</returns>
        protected virtual string BuildSQLSelectText(string[] tableNames, DatabaseParameter[] whereParameters, string whereSeperator, string whereOperator)
        {
            //SELECT FROM TableName
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("SELECT * FROM {0}", String.Join(", ", tableNames));

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

        /// <summary>
        /// Creates SELECT command text
        /// </summary>
        /// <param name="tableName">Database Table SELECT is being performed on</param>
        /// <param name="whereParameters">Parameters used to build the WHERE clause IMPORTANT(Properties .ParameterName and .SourceColumn must be set)</param>
        /// <param name="whereSeperator">the string used to seperate statements (AND/OR) in the WHERE cluase</param>
        /// <param name="whereOperator">the operator (=, LIKE, ..etc) used in the WHERE cluase</param>
        /// <returns>Generated SELECT AND command text</returns>
        protected virtual string BuildSQLSelectText(string tableName, DatabaseParameter[] whereParameters, string whereSeperator, string whereOperator)
        {
            string[] table = new string[1];
            table[0] = tableName;
            
            return BuildSQLSelectText(table, whereParameters, whereSeperator, whereOperator);
        }


        #endregion

        #region Properties
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        public string ProviderInvariantName
        {
            get { return providerInvariantName; }
        }
        public DbProviderFactory ProviderFactory
        {
            get { return dbProviderFactory; }
        }

        #endregion
    }
}