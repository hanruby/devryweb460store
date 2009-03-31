using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Configuration;
using System.Reflection;
using System.Data.SqlClient;
namespace DAL
{
public class DataAccess
{
    private string connectionString;
    private string providerName;
    private DbProviderFactory factory;

    public DataAccess()
    {
        factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        connectionString = ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ConnectionString;
        providerName = ConfigurationManager.ConnectionStrings["MyPetStoreDB"].ProviderName;
    }

    public DataAccess(string connectionString, string providerName)
    {
        this.factory = DbProviderFactories.GetFactory(providerName);
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
                    cmd.Parameters.Add(new SqlParameter(paramters[i],values[i]));
                }

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }

    public DataSet ExecuteQuery(string sql, string[] parameters, string[] values)
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
                    cmd.Parameters.Add(new SqlParameter(parameters[i], values[i]));
                }

                conn.Open();
                DbDataAdapter adapter = factory.CreateDataAdapter();
                DataSet ds = new DataSet();
                cmd.CommandText = sql;
                adapter.SelectCommand = cmd;
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
}
