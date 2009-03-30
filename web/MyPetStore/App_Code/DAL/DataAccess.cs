using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Configuration;
using System.Reflection;
using System.Data.SqlClient;
using System.ComponentModel;
    public class DataAccess
    {
        #region Attributes
        private string connectionString;
        private string providerInvariantName;
        private DbProviderFactory dbProviderFactory;
        #endregion


        //Constructors
        #region Constructors
        public DataAccess(string connectionString, string providerInvariantName)
        {
            this.dbProviderFactory = DbProviderFactories.GetFactory(providerInvariantName);
            this.connectionString = connectionString;
            this.providerInvariantName = providerInvariantName;
        }
        #endregion


        #region CRUD Operations
        public void Add(List<object> objects)
        {

        }

        public void Add(object obj)
        {
            string[] columns = GetColumnsFromObject(obj);
            object[] values = GetValuesFromObject(obj);
            
            List<DbParameter> parameters = new List<DbParameter>();


            DbCommand command;


            //UPDATE


            //get Primary key details
            //if Primary key is AUTO INCREMENT ADD to Database

            //if Primary key is NOT AUTO and has VALUE, ADD to Database
            //if Primary key is NOT AUTO but VALUE IS NULL throw ERROR

            //if a Primary key exists in Database do UPDATE

            //INSERT
            command = CreateCommandInsert(columns);
            
            //Create parameters and all parameters to command
            command.Parameters.AddRange(CreateParameters(columns, values));

            //open connection and execute SQL
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public void GetByPrimaryKey(object obj)
        {
            string primaryKeyColumn = GetPrimaryKeyColumnFromObject(obj);
            object primaryKeyValue = GetPrimaryKeyValueFromObjects(obj);

            //create command and add parameter
            DbCommand command;
            command = CreateCommandSelectByPrimaryKey(primaryKeyColumn);
            command.Parameters.Add(CreateParameter(primaryKeyColumn, primaryKeyValue));
            
            //open connection and execute SQL
            command.Connection.Open();
            //command.ExecuteNonQuery();
            command.Connection.Close();

        }
        public void Get(object obj)
        {
            string[] columns = GetColumnsFromObject(obj);
            object[] values = GetValuesFromObject(obj);
            
            List<DbParameter> parameters = new List<DbParameter>();

            //create command with AND command text
            DbCommand command;
            command = CreateCommandAndSelect(columns);
            
            //Create parameters and add all to command
            command.Parameters.AddRange(CreateParameters(columns, values));

            //open connection and execute SQL
            command.Connection.Open();
            
            //perform query
            //build class
            
            command.Connection.Close();
        }

        public DbParameter[] CreateParameters(string[] columns, object[] values)
        {
            List<DbParameter> parameters = new List<DbParameter>();

            for (int i = 0; i < values.Length; i++)
            {
                //get parameter from factory
                DbParameter dbParameter = dbProviderFactory.CreateParameter();

                //set parameter properties
                dbParameter.ParameterName = "@" + columns[i];
                dbParameter.Value = values[i];

                parameters.Add(dbParameter);
            }
            DbParameter[] parametersArray = parameters.ToArray();
            return parametersArray;
        }
        public DbParameter CreateParameter(string column, object value)
        {
            //get parameter from factory
            DbParameter dbParameter = dbProviderFactory.CreateParameter();

            //set parameter
            dbParameter.ParameterName = "@" + column;
            dbParameter.Value = value;
            return dbParameter;
        }
        #endregion

        #region Database Access Related Methods
        private DbConnection CreateConnection()
        {
            DbConnection connection = dbProviderFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        private DbCommand CreateCommand(string commandText, DbConnection connection)
        {
            DbCommand command = dbProviderFactory.CreateCommand();
            command.Connection = connection;
            command.CommandText = commandText;
            return command;
        }
        private DbCommand CreateCommand(string commandText)
        {
            DbCommand command = dbProviderFactory.CreateCommand();
            command.CommandText = commandText;
            command.Connection = CreateConnection();
            return command;
            
        }
        #endregion


        #region Column and Value Building Methods
        public string[] GetColumnsFromObject(object obj)
        {
            List<string> columns = new List<string>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);

            for (int i = 0; i < properties.Count; i++)
            {
                //get the property's column attribute
                DBColumnAttribute columnAttribute = (DBColumnAttribute)properties[i].Attributes[typeof(DBColumnAttribute)];

                //make sure values exist and is not auto incrementing before adding columns
                if (columnAttribute != null && columnAttribute.IsAutoIncrement == false)
                {
                    columns.Add(columnAttribute.Name);
                }
            }
            string[] columnsArray = columns.ToArray();
            return columnsArray;
        }

        public string GetPrimaryKeyColumnFromObject(object obj)
        {
            string primaryKeyColumn = null;
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);

            for (int i = 0; i < properties.Count; i++)
            {
                //get the property's column attribute
                DBColumnAttribute columnAttribute = (DBColumnAttribute)properties[i].Attributes[typeof(DBColumnAttribute)];

                //make sure values exist and is not auto incrementing before adding columns
                if (columnAttribute.IsPrimaryKey ==true)
                {
                    primaryKeyColumn = columnAttribute.Name;
                }
            }
            return primaryKeyColumn;
        }

        public object[] GetValuesFromObject(object obj)
        {
            List<object> values = new List<object>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);


            for (int i = 0; i < properties.Count; i++)
            {
                //get the column attribute of the property
                DBColumnAttribute columnAttribute = (DBColumnAttribute)properties[i].Attributes[typeof(DBColumnAttribute)];

                //get the property's value
                object value = properties[i].GetValue(obj);

                //check if the property has a column attribute
                if (columnAttribute != null && columnAttribute.IsAutoIncrement == false)
                {
                    values.Add(value);
                }
            }

            object[] valuesArray = values.ToArray();
            return valuesArray;
        }

        public object[] GetValuesFromObjects(List<object> obj)
        {
            
            List<object> values = new List<object>(obj.Capacity);
            int capacity = obj.Count;
            for (int i = 0; i < obj.Count; i++)
            {
                values.Add(GetValuesFromObject(obj[i]));
            }

            object[] valuesArray = values.ToArray();
            return valuesArray;
        }
        #endregion

        public object GetPrimaryKeyValueFromObjects(object obj)
        {
            object value = null;
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);

            for (int i = 0; i < properties.Count; i++)
            {
                //get the column attribute of the property
                DBColumnAttribute columnAttribute = (DBColumnAttribute)properties[i].Attributes[typeof(DBColumnAttribute)];

                //check if the property has a column attribute with a primary key
                if (columnAttribute.IsPrimaryKey == true)
                {
                    //get the property's value
                    value = properties[i].GetValue(obj);
                }
            }
            return value;
        }

        public object[] GetPrimaryKeyValueFromObjects(List<object> obj)
        {
            
            List<object> values = new List<object>(obj.Count);
            for (int i = 0; i < obj.Count; i++)
            {
                values.Add(GetPrimaryKeyValueFromObjects(obj[i]));
            }

            object[] valuesArray = values.ToArray();
            return valuesArray;
        }

        #region CRUD Command builder Methods
        private DbCommand CreateCommandAndSelect(string[] columns)
        {
            //create SELECT command text with WHERE AND clause
            string commandText = "SELECT * FROM Table" + CreateWhereAndClause(columns);

            DbCommand command = CreateCommand(commandText);
            return command;
        }
        private DbCommand CreateCommandOrSelect(string[] columns)
        {
            //create SELECT command text with WHERE AND clause
            string commandText = "SELECT * FROM Table" + CreateWhereOrClause(columns);

            DbCommand command = CreateCommand(commandText);
            return command;
        }
        private DbCommand CreateCommandSelectByPrimaryKey(string primaryKeyColumn)
        {
            //create SELECT command text with WHERE AND clause
            string commandText = "SELECT * FROM" + "Table" + "WHERE" + CreateWherePrimaryKeyClause(primaryKeyColumn);

            DbCommand command = CreateCommand(commandText);
            return command;
        }
        private DbCommand CreateCommandInsert(string[] columns)
        {
            //create SELECT command text with WHERE AND clause
            string sqlColumns = String.Join(",", columns);
            string sqlParameters = "@" + String.Join(", @", columns);
            string commandText = "INSERT INTO ORDERS(" + sqlColumns + ")" + " VALUES(" + sqlParameters + ");";
            
            DbCommand command = CreateCommand(commandText);            
            return command;
        }
        #endregion

        #region CreateWhereClause Methods
        private string CreateWherePrimaryKeyClause(string primaryKeyColumn)
        {
            string whereClause = null;
            whereClause = "WHERE" + primaryKeyColumn + "=" + "@" + primaryKeyColumn;
            return whereClause;
        }
        private string CreateWhereAndClause(string[] columns)
        {
            string whereClause = null;

            for (int i = 0; i < columns.Length; i++)
            {
                if (i != 0)
                    //AND columnName = @columnName
                    whereClause += " AND" + columns[i] + "=" + "@" + columns[i];
                else
                    //For the first entry we need it to be columnName = @columnName
                    whereClause = "WHERE" + columns[i] + "=" + "@" + columns[i];
            }
            return whereClause;
        }
        private string CreateWhereOrClause(string[] columns)
        {
            string whereClause = null;

            for (int i = 0; i < columns.Length; i++)
            {
                if (i != 0)
                    //AND columnName = @columnName
                    whereClause += " OR" + columns[i] + "=" + "@" + columns[i];
                else
                    //For the first entry we need it to be columnName = @columnName
                    whereClause = "WHERE" + columns[i] + "=" + "@" + columns[i];
            }
            return whereClause;
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














        //public DataSet ExecuteQuery()
        //{
        //    string providerInvariantName = "System.Data.SqlClient";
        //    DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(providerInvariantName);
        //    //create connection
        //    DbConnection connection = dbProviderFactory.CreateConnection();
        //    connection.ConnectionString = ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString;
        //    DbCommand command = dbProviderFactory.CreateCommand();
        //    command.Connection = connection;

        //    string cmdText = "Select * FROM Orders WHERE OrderID = @test";
        //    command.CommandText = cmdText;


        //    DbParameter param = dbProviderFactory.CreateParameter();
        //    param.Value = 237;
        //    param.ParameterName = "";

        //    command.Parameters.Add(param);
        //    connection.Open();

        //    DbDataAdapter adapter = dbProviderFactory.CreateDataAdapter();
        //    DataSet ds = new DataSet();
        //    adapter.SelectCommand = command;
        //    adapter.Fill(ds);
        //    connection.Close();
        //    return ds;
        //    //command.ExecuteNonQuery();
        //}
    }