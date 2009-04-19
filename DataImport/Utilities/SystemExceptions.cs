using System;

namespace Utilities
{
    public class XMLLoadError : Exception
    {
        private string m_message;

        public void SetMessage(string P_message)
        {
            m_message = P_message;
        }

        public string GetMessage()
        {
            return(m_message);
        }
    }

    public class XMLMissingSection : Exception
    {
        private string m_message;

        public void SetMessage(string P_message)
        {
            m_message = P_message;
        }

        public string GetMessage()
        {
            return(m_message);
        }
    }

    public class DataBaseConnectError : Exception
    {
        private string m_message;

        public void SetMessage(string P_message)
        {
            m_message = P_message;
        }

        public string GetMessage()
        {
            return(m_message);
        }
    }

    public class MissingConfigurationItem : Exception
    {
        private string m_message;

        public void SetMessage(string P_message)
        {
            m_message = P_message;
        }

        public string GetMessage()
        {
            return(m_message);
        }
    }
}
