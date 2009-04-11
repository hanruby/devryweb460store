using System;
using System.Collections.ObjectModel;
using System.Data;

namespace DataAccessModule
{
    [Serializable]
    public abstract class DataAccessBC<T>
    {
        protected abstract IDbConnection GetConnection();
        protected abstract string CommandText { get; }
        protected abstract CommandType CommandType { get; }
        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command);
        protected abstract MapperBase<T> GetMapper();

        public virtual Collection<T> Execute()
        {
            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = CommandText;
                command.CommandType = CommandType;

                foreach (IDataParameter param in GetParameters(command))
                {
                    command.Parameters.Add(param);
                }

                try
                {
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<T> mapper = GetMapper();
                            Collection<T> collection = mapper.MapAll(reader);

                            return(collection);
                        }

                        finally
                        {
                            reader.Close();
                        }
                    }
                }

                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
