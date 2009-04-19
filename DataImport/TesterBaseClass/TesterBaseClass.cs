#if TESTDRIVER

namespace TesterBC
{
    public class TesterBaseClass
    {
        static public string UserName
        {
            get
            {
                return("TestUser");
            }
        }

        static public string UserPassword
        {
            get
            {
                return ("testuser");
            }
        }

        static public string Server
        {
            get
            {
                return(@"DAVED\SQLEXPRESS");
            }
        }

        static public string Database
        {
            get
            {
                return("TestDatabase");
            }
        }
    }
}

#endif