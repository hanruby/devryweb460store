using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataAccessModule;
using Utilities;

namespace DataImporter
{
    [Serializable]
    public abstract class Engine
    {
        protected List<ProductItemDA> m_productList = new List<ProductItemDA>();

        public int VendorID { get; set; }
        public string LogFile { get; set; }
        public int DebugLevel { get; set; }

        public abstract bool ReadFile(string P_fileName);
        public abstract bool CreateProductList();

        protected Engine()
        {
            VendorID = -1;
        }

        public bool DoImport(string P_fileName, DAConnect P_connection)
        {
            var log = new Logging(LogFile);
            SystemDebug.Level = DebugLevel;

            log.StartLoging();

            try
            {
                var msg = String.Format("Start Processing for Customer ID: {0}",
                                        VendorID);
                SystemDebug.Log((int) TraceLevel.Info, msg);

                var now = DateTime.Now;
                msg = String.Format("Start Processing \"{0}\": {1}", P_fileName,
                                    now);
                SystemDebug.Log((int) TraceLevel.Info, msg);

                if (!ReadFile(P_fileName))
                {
                    return (false);
                }
                now = DateTime.Now;
                msg = String.Format("Ended Processing: {0}", now);
                SystemDebug.Log((int) TraceLevel.Info, msg);

                now = DateTime.Now;
                msg = String.Format("Start Creating Product List: {0}", now);
                SystemDebug.Log((int) TraceLevel.Info, msg);
                if (!CreateProductList())
                {
                    return (false);
                }
                now = DateTime.Now;
                msg = String.Format("Ended Product List: {0}", now);
                SystemDebug.Log((int) TraceLevel.Info, msg);

                now = DateTime.Now;
                msg = String.Format("Start Data Load: {0}", now);
                SystemDebug.Log((int) TraceLevel.Info, msg);

                foreach (ProductItemDA rec in m_productList)
                {
                    rec.SetupConnectionString(P_connection.GetConnectionString());
                    rec.Execute();
                }

                now = DateTime.Now;
                msg = String.Format("Ended Data Load: {0}", now);
                SystemDebug.Log((int) TraceLevel.Info, msg);
            }

            finally
            {
                log.EndLoging();
            }

            return(true);
        }
    }
}
