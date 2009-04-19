using System.IO;
using System.Diagnostics;

namespace Utilities
{
    public class Logging
    {
        private const string LoggingListenerName = "LoggingListener";

        private readonly string m_logName;
        private FileStream m_logFileStream;

            /// <summary>
            /// Create a logging object
            /// </summary>
            /// <param name="P_logFile">
            /// Name of the logfile to create and use
            /// </param>

        public Logging(string P_logFile)
        {
            m_logName = P_logFile;
        }

            /// <summary>
            /// This method will set up the loggin so that the converters
            /// will be able to write to a log file.
            /// </summary>

        public void StartLoging()
        {
            string dir = Path.GetDirectoryName(m_logName);

                //
                //  If the directory does not exist, then create it. Otherwise
                //      remove the log file if it exists.
                //

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            else
            {
                    //
                    //  If the log file exists remove it.
                    //

                if (File.Exists(m_logName))
                {
                    File.Delete(m_logName);
                }
            }

            m_logFileStream = new FileStream(m_logName, FileMode.OpenOrCreate);
            var traceListener = new TextWriterTraceListener(m_logFileStream,
                                                        LoggingListenerName);
            Trace.Listeners.Add(traceListener);
        }

            /// <summary>
            /// This will trun off the logging.
            /// </summary>

        public void EndLoging()
        {
            Trace.Flush();
            m_logFileStream.Close();
            Trace.Listeners.Remove(LoggingListenerName);
        }
    }
}
