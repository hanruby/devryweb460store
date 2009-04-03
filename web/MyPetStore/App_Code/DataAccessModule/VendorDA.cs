using System.Collections.ObjectModel;
using System.Data;

namespace DataAccessModule
{
    public class VendorDA : SQLServerDataConnector<Vendor>
    {
        protected override string CommandText
        {
            get { return("Select * from Vendor"); }
        }

        protected override CommandType CommandType
        {
            get { return(CommandType.Text); }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            var collection = new Collection<IDataParameter>();
            return collection;
        }

        protected override MapperBase<Vendor> GetMapper()
        {
            MapperBase<Vendor> mapper = new VendorMapper();
            return mapper;
        }
    }
}
