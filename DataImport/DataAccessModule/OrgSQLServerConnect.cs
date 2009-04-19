//
//  SQLServerConnect.cs - This is the SQL Server connection class.
//
//  03-10-2009  dd  creation
//

using System;
using System.Xml;
using Utilities;

namespace DataAccessModule
{
    public class SQLServerConnect : DAConnect
    {
        private const string BaseCfgPath = "/BaseConfig/";
        private const string UserTag = "User";
        private const string PasswordTag = "Password";
        private const string ServerTag = "Server";
        private const string DatabaseTag = "Database";

        private string m_cfgFileName;
        private string m_connectStr;
        private string m_user;
        private string m_password;
        private string m_server;
        private string m_database;

        public SQLServerConnect(string P_configFile)
        {
            m_cfgFileName = P_configFile;
            ReadConfiguration(m_cfgFileName);
        }

        public override string GetConnectionString()
        {
            string retVal = "";

            return (retVal);
        }

            /// <summary>
            /// This method will read the configuration file and set
            /// all the internal attributes needed to process the
            /// file.
            /// </summary>
            /// <param name="P_configFile">
            /// Fully qualifed path to the configuration file
            /// </param>

        public void ReadConfiguration(string P_configFile)
        {
            string errStr;
            var configFileDoc = new XmlDocument();
            XmlNode node = configFileDoc.DocumentElement;

            string workStr = String.Format("{0}{1}", BaseCfgPath, UserTag);
            XmlNodeList nodeList = node.SelectNodes(workStr);
            XmlNode workNode = nodeList.Item(0);
            if (workNode == null)
            {
                var err = new MissingConfigurationItem();

                errStr = "Missing TLog File Name/List from Configuration File.";
                SystemDebug.Log(0, errStr);
                err.SetMessage(errStr);
                throw(err);
            }
            m_user = workNode.InnerText.Trim();

            workStr = String.Format("{0}{1}", BaseCfgPath, PasswordTag);
            nodeList = node.SelectNodes(workStr);
            workNode = nodeList.Item(0);
            if (workNode == null)
            {
                var err = new MissingConfigurationItem();

                errStr = "Missing Bulk Output from Configuration File.";
                SystemDebug.Log(0, errStr);
                err.SetMessage(errStr);
                throw(err);
            }
            m_password = workNode.InnerText.Trim();

            workStr = String.Format("{0}{1}", BaseCfgPath, ServerTag);
            nodeList = node.SelectNodes(workStr);
            workNode = nodeList.Item(0);
            if (workNode == null)
            {
                var err = new MissingConfigurationItem();

                errStr = "Missing TLog File Name/List from Configuration File.";
                SystemDebug.Log(0, errStr);
                err.SetMessage(errStr);
                throw (err);
            }
            m_server = workNode.InnerText.Trim();

            workStr = String.Format("{0}{1}", BaseCfgPath, DatabaseTag);
            nodeList = node.SelectNodes(workStr);
            workNode = nodeList.Item(0);
            if (workNode == null)
            {
                var err = new MissingConfigurationItem();

                errStr = "Missing Bulk Output from Configuration File.";
                SystemDebug.Log(0, errStr);
                err.SetMessage(errStr);
                throw (err);
            }
            m_database = workNode.InnerText.Trim();
        }
    }
}
