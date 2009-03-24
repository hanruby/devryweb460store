using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Configuration;
using System.Reflection;
using System.Data.SqlClient;

public class DataAccess
{
    private string connectionString;
    private string providerName;
    private DbProviderFactory factory;

    public DataAccess()
    {
        factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        connectionString = ConfigurationManager.AppSettings["DATA.CONNECTIONSTRING"];
        providerName = ConfigurationManager.AppSettings["DATA.PROVIDER"];
    }
    public DataAccess(string factory, string connectionString, string providerName)
    {
        this.factory = DbProviderFactories.GetFactory(factory);
        this.connectionString = connectionString;
        this.providerName = providerName;
    }

    private DbConnection CreateConnection()
    {
        DbConnection connection = factory.CreateConnection();
        connection.ConnectionString = connectionString;
        return connection;
    }

    private DbCommand CreateCommand(string commandText, DbConnection connection)
    {

        DbCommand command = factory.CreateCommand();
        command.Connection = connection;
        command.CommandText = commandText;
        return command;
    }

    //public void CreateObjectFromDB(Type objType)
    //{


    //    //instantiate an object of the type specified
    //    object instance = Activator.CreateInstance(objType, true);

    //    //get all properties of the class specified
    //    PropertyInfo[] properties = objType.GetProperties();

    //    for (int i = 0; i < properties.Length; i++)
    //    {
    //        //add the DBColumnAttributes for each property
    //        DBColumnAttribute[] attribute = (DBColumnAttribute[])properties[i].GetCustomAttributes(typeof(DBColumnAttribute), true);

    //        //make sure the property has a column attribute
    //        if (attribute.Length > 0)
    //        {
    //            //fill in the value for the property
    //            object value = reader[attribute[0].Name];
    //            properties[i].SetValue(instance, value, null);
    //        }
    //    }
    //}

    public void ExecuteNonQuery(string sql, string[] paramters, string[] values)
    {
        //create connection
        using (DbConnection conn = CreateConnection())
        {
            //create cmd
            using (DbCommand cmd = CreateCommand(sql, conn))
            {
                //add parameters
                for (int i = 0; i < values.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(values[i], paramters[i]));
                }

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }

    public DataSet ExecuteQuery(string sql, string[] paramters, string[] values)
    {
        //create connection
        using (DbConnection conn = CreateConnection())
        {
            //create cmd
            using (DbCommand cmd = CreateCommand(sql, conn))
            {
                //add parameters
                for (int i = 0; i < values.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(values[i], paramters[i]));
                }

                conn.Open();
                DbDataAdapter adapter = factory.CreateDataAdapter();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();
                return ds;
            }
        }
    }

    public string ConnectionString
    {
        get { return connectionString; }
        set { connectionString = value; }
    }
    public string ProviderName
    {
        get { return providerName; }
        set { providerName = value; }
    }
}


