using System.Diagnostics;

namespace Utilities
{
    public class SystemDebug
    {
        #region Attributes

            /// <summary>
            /// Property Accessor for Level
            /// </summary>

        public static int Level { set; get;}

        #endregion

        #region PublicMethods

            /// <summary>
            /// Since the WriteLineIf and WriteIf needs a boolean flag to
            /// know to output line, this method will calculate that boolean flag.
            /// This method will have to be called for all log output.
            /// </summary>
            /// <param name="P_msgLevel">
            /// Current message level
            /// </param>
            /// <returns>
            /// true to output the line, false not to output line
            /// </returns>

        static public bool DebugOutput(int P_msgLevel)
        {
            bool retVal = (P_msgLevel <= Level);

            return(retVal);
        }

            /// <summary>
            /// This method will log all messages to the Trace Log. This will
            /// be done by calling the WriteLine, or WriteLineIf and then doing
            /// the flush to ensure all data is going to the log. If a value of
            /// 0 is passed in then the message will always be logged.
            /// </summary>
            /// <param name="P_msgLevel">
            /// Message level of the message
            /// </param>
            /// <param name="P_msg">
            /// Message to output if debug level is correct
            /// </param>

        static public void Log(int P_msgLevel, string P_msg)
        {
            if (P_msgLevel == 0)
            {
                Trace.WriteLine(P_msg);
            }
            else
            {
                Trace.WriteLineIf(DebugOutput(P_msgLevel), P_msg);
            }

            Trace.Flush();
        }

        #endregion
    }
}
