using System.Collections.ObjectModel;
using System.Data;

namespace DataAccessModule
{
    public abstract class MapperBase<T>
    {
        protected abstract T Map(IDataRecord record);

        public Collection<T> MapAll(IDataReader reader)
        {
            var collection = new Collection<T>();

            while (reader.Read())
            {
                collection.Add(Map(reader));
            }

            return( collection);
        }
    }
}
