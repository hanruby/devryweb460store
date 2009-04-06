using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;

namespace DataAccessModule
{
    /// <summary>
    /// Maps a Database record to an Object
    /// </summary>
    public abstract class MapperBase<T>
    {
        public abstract T Map(DbDataRecord record);

        public Collection<T> MapAll(DbDataReader reader)
        {
            var collection = new Collection<T>();

            foreach (DbDataRecord record in reader)
            {
                collection.Add(Map(record));
            }
            return( collection);
        }
    }
}
