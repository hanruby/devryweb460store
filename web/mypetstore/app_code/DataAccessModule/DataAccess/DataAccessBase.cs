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
        #region abstract Members
        //performs SELECT query
        //and returns a list of business objects
        public abstract Collection<T> Get(T businessObject);

        //performs INSERT or UPDATE
        //returns rows affected when single object
        public abstract void Save(Collection<T> businessObjectList);
        public abstract int Save(T businessObject);
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        public virtual int ExecuteNonQuery(DbParameter[] parameters, string commandText)
        {
            using (DbConnection connection = CreateConnection())
            {
                DbCommand command = CreateCommand(commandText, connection);
                command.Parameters.AddRange(parameters);

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
        public virtual Collection<T> ExecuteQuery(DbParameter[] parameters, string commandText)
        {
            using (DbConnection connection = CreateConnection())
            {
                DbCommand command = CreateCommand(commandText, connection);
                command.Parameters.AddRange(parameters);
                
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
        /// <returns></returns>
        public DbParameter CreateParameter(string paramName, object paramValue)
        {
            DbParameter parameter = dbProviderFactory.CreateParameter();
            parameter.ParameterName = paramName;
            parameter.Value = paramValue;
            return parameter;
        }

        public DbParameter CreateParameter(string paramName, object paramValue, string columnName)
        {
            DbParameter parameter = dbProviderFactory.CreateParameter();
            parameter.ParameterName = paramName;
            parameter.Value = paramValue;
            parameter.SourceColumn = columnName;
            return parameter;
        }
        #endregion

        #region SQL CommandText Builders
        protected string BuildSQLTextSET(string commandText, DbParameter[] parameters)
        {
            StringBuilder builder = new StringBuilder(commandText);

            //add first parameter
            builder.AppendFormat("SET {0} = {1}", parameters[0].SourceColumn, parameters[0].ParameterName);

            //start at index 1 (0 was already added)
            for (int i = 1; i < parameters.Length; i++)
            {
                //add additional parameters
                builder.AppendFormat(", {0} = {1}", parameters[i].SourceColumn, parameters[i].ParameterName);
            }
            return builder.ToString();
        }

        protected string BuildSQLTextWhereAND(string commandText, DbParameter[] parameters)
        {
            StringBuilder builder = new StringBuilder(commandText);

            //add first parameter
            builder.AppendFormat("WHERE {0} = {1}", parameters[0].SourceColumn, parameters[0].ParameterName);

            //start at index 1 (0 was already added)
            for (int i = 1; i < parameters.Length; i++)
            {
                //add additional parameters
                builder.AppendFormat(" AND {0} = {1}", parameters[i].SourceColumn, parameters[i].ParameterName);
            }
            return builder.ToString();
        }

        protected string BuildSQLTextWhereOR(string commandText, DbParameter[] parameters)
        {
            StringBuilder builder = new StringBuilder(commandText);

            //add first parameter
            builder.AppendFormat("WHERE {0} = {1}", parameters[0].SourceColumn, parameters[0].ParameterName);

            //start at index 1 (0 was already added)
            for (int i = 1; i < parameters.Length; i++)
            {
                //add additional parameters
                builder.AppendFormat(" OR {0} = {1}", parameters[i].SourceColumn, parameters[i].ParameterName);
            }
            return builder.ToString();
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