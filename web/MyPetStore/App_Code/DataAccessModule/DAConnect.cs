//
//  DAConnect.cs - This is the base class for all connection objects.
//      This will allow replacement for different databases.
//
//  03-10-2009  dd  creation
//

using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
//using Utilities;

namespace DataAccessModule
{
    [Serializable]
    public abstract class DAConnect
    {
        public int DatabaseCommandTimeOut { set; get;}

            /// <summary>
            /// This method will get the connection information and store it
            /// for later use.
            /// </summary>
            /// <param name="P_user">
            /// User name used to connect to the database
            /// </param>
            /// <param name="P_password">
            /// Password to connect to the database with
            /// </param>
            /// <param name="P_server">
            /// Name of the server where the database is
            /// </param>
            /// <param name="P_database">
            /// Name of the database to use when connected
            /// </param>

        public abstract void SetupConnectionString(string P_user,
            string P_password, string P_server, string P_database);

            /// <summary>
            /// This is the conncetion string for an Integrated Security connection
            /// </summary>
            /// <param name="P_server">
            /// Name of the server
            /// </param>
            /// <param name="P_database">
            /// name of database
            /// </param>

        public abstract void SetupConnectionString(string P_server,
                                                string P_database);

            /// <summary>
            /// This is the conncetion string for an Integrated Security connection
            /// </summary>
            /// <param name="P_ConnectionStr">
            /// Connection String
            /// </param>

        public abstract void SetupConnectionString(string P_ConnectionStr);

        public abstract string GetConnectionString();

            /// <summary>
            /// This method will execute a command in the database. This can
            /// be any command that the database can execute, select, insert,
            /// update, exec, etc.
            /// </summary>
            /// <param name="P_storedProcedureCall">
            /// Command to execute
            /// </param>

        public void ExecuteStoredProc(string P_storedProcedureCall)
        {
            var sqlConnection = new SqlConnection(GetConnectionString());
            var cmd = new SqlCommand
                          {
                              CommandText = P_storedProcedureCall,
                              Connection = sqlConnection,
                              CommandTimeout = DatabaseCommandTimeOut
                          };

            string msg = String.Format("Exec Call: \"{0}\"", P_storedProcedureCall);
            //SystemDebug.Log((int)TraceLevel.Verbose, msg);
            DateTime now = DateTime.Now;
            msg = String.Format("Start Processing: {0}", now);
            //SystemDebug.Log((int)TraceLevel.Verbose, msg);

            var sqlAdapter = new SqlDataAdapter(cmd);
            var dtResults = new DataTable();
            sqlAdapter.Fill(dtResults);

            now = DateTime.Now;
            msg = String.Format("End Processing: {0}\r\n", now);
            //SystemDebug.Log((int)TraceLevel.Info, msg);
        }

            /// <summary>
            /// This method will take in a stored procedure call
            /// and return a SqlDataReader
            /// </summary>
            /// <param name="P_cmd">
            /// Stored Procedure to execute
            /// </param>
            /// <param name="P_parmList">
            /// List of parameters
            /// </param>
            /// <returns>
            /// Datareader returned
            /// </returns>

        public DataTable ReturnSQLDataReader(string P_cmd, ParmList P_parmList)
        {
            var dtResults = new DataTable();
            var sqlConnection = new SqlConnection(GetConnectionString());
            var cmd = new SqlCommand
                          {
                              CommandText = P_cmd,
                              Connection = sqlConnection,
                              CommandTimeout = DatabaseCommandTimeOut
                          };

            if ((P_parmList != null) && (P_parmList.Items.Count > 0))
            {
                foreach (ParmObject obj in P_parmList.Items)
                {
                    cmd.Parameters.AddWithValue(obj.ParmName, obj.ParmObj);
                }
            }
            var sqlAdapter = new SqlDataAdapter(cmd);
            sqlAdapter.Fill(dtResults);

            return (dtResults);
        }

            /// <summary>
            /// This method will take in a stored procedure call
            /// and return a SqlDataReader
            /// </summary>
            /// <param name="P_cmd">
            /// Stored Procedure to execute
            /// </param>
            /// <param name="P_parmList">
            /// List of parameters
            /// </param>

        public void ExecuteCmd(string P_cmd, ParmList P_parmList)
        {
            var dtResults = new DataTable();
            var sqlConnection = new SqlConnection(GetConnectionString());
            var cmd = new SqlCommand
                          {
                              CommandText = P_cmd,
                              Connection = sqlConnection,
                              CommandTimeout = DatabaseCommandTimeOut
                          };

            if ((P_parmList != null) && (P_parmList.Items.Count > 0))
            {
                foreach (ParmObject obj in P_parmList.Items)
                {
                    cmd.Parameters.AddWithValue(obj.ParmName, obj.ParmObj);
                }
            }

            var sqlAdapter = new SqlDataAdapter(cmd);
            sqlAdapter.Fill(dtResults);
        }
    }
}
