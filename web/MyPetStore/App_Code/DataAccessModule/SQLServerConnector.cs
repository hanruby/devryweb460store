using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessModule
{
    [Serializable]
    public class SQLServerDataConnector<T> : DataAccessBC<T>
    {
        protected string m_connectStr;

        protected override IDbConnection GetConnection()
        {
            // update to get your connection here

            IDbConnection connection = new SqlConnection(m_connectStr);
            return connection;
        }
        protected override string CommandText
        {
            get { throw new NotImplementedException(); }
        }
        protected override CommandType CommandType
        {
            get { throw new NotImplementedException(); }
        }
        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            throw new NotImplementedException();
        }
        protected override MapperBase<T> GetMapper()
        {
            throw new NotImplementedException();
        }

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

        public void SetupConnectionString(string P_user,
                string P_password, string P_server, string P_database)
        {
            m_connectStr = String.Format(
                "Data Source='{0}'; database={1}; user id={2}; password={3}",
                P_server, P_database, P_user, P_password);
        }

            /// <summary>
            /// This is the conncetion string for an Integrated Security connection
            /// </summary>
            /// <param name="P_server">
            /// Name of the server
            /// </param>
            /// <param name="P_database">
            /// name of database
            /// </param>

        public void SetupConnectionString(string P_server,
                                                    string P_database)
        {
            m_connectStr = String.Format(
                "Data Source='{0}';Initial Catalog={1};Integrated Security=SSPI;",
                P_server, P_database);
        }

            /// <summary>
            /// Set the complete connection string
            /// </summary>
            /// <param name="P_connectStr">
            /// Full connection string to use
            /// </param>

        public void SetupConnectionString(string P_connectStr)
        {
            m_connectStr = P_connectStr;
        }

        public string GetConnectionString()
        {
            return (m_connectStr);
        }
    }
}
