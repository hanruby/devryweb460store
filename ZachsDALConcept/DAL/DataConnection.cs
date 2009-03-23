using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Configuration;
using System.Reflection;

public class DataAccess
{
    private string connectionString;
    private string providerName;
    private DbProviderFactory factory;

    public DataAccess()
    {
        connectionString = ConfigurationManager.AppSettings["DATA.CONNECTIONSTRING"];
        providerName = ConfigurationManager.AppSettings["DATA.PROVIDER"];
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

    public void CreateObjectFromDB(Type objType)
    {
       
        
        //instantiate an object of the type specified
        object instance = Activator.CreateInstance(objType, true);

        //get all properties of the class specified
        PropertyInfo[] properties = objType.GetProperties();

        for (int i = 0; i < properties.Length; i++)
        {
            //add the DBColumnAttributes for each property
            DBColumnAttribute[] attribute = (DBColumnAttribute[])properties[i].GetCustomAttributes(typeof(DBColumnAttribute), true);

            //make sure the property has a column attribute
            if (attribute.Length > 0)
            {
                //fill in the value for the property
                object value = reader[attribute[0].Name];
                properties[i].SetValue(instance, value, null);
            }
        }
    }

    private void ExecuteQuery()
    {

        //command text to be paramatized
        string cmdText = "SELECT col1, col2, col3 WHERE col1 = @col1";

        //create connection
        using (DbConnection conn = CreateConnection())
        {
            //create cmd
            using (DbCommand cmd = CreateCommand(cmdText, conn))
            {
                //add parameters
                col1 = "whatever";
                cmd.Parameters.Add("@col1", col1);

                conn.Open();
                //create and execute reader
                using (DbDataReader reader = cmd.ExecuteReader())
                {

                }
                conn.Close();
            }
        }
    }
}


