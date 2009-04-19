
namespace Utilities
{
    public class Utils
    {
        public static void AddToSQLClause(ref string P_str, string P_seperator,
                                string P_columnName, string P_parmValue)
        {
            var seperatorStr = "";
            if (P_str != "")
            {
                seperatorStr = string.Format("{0} ", P_seperator);
            }

            P_str = string.Format("{0}{1}{2} = {3}", P_str, seperatorStr,
                                                P_columnName, P_parmValue);
        }

        public static void AddToSQLString(ref string P_str,
                                                string P_addStr)
        {
            var commaStr = "";
            if (P_str != "")
            {
                commaStr = ", ";
            }

            P_str = string.Format("{0}{1}{2}", P_str, commaStr, P_addStr);
        }

        public static void AddToSQLInsertStrings(ref string P_column,
                    ref string P_valueStr, string P_colStr, string P_valStr)
        {
            AddToSQLString(ref P_column, P_colStr);
            AddToSQLString(ref P_valueStr, P_valStr);
        }
    }
}
