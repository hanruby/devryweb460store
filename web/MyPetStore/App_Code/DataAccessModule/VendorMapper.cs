using System;
using System.Data;

namespace DataAccessModule
{
    public class VendorMapper : MapperBase<Vendor>
    {
        public const string DBDataColumnVendorID = "ID";
        public const string DBDataColumnVendorName = "Name";

        protected override Vendor Map(IDataRecord record)
        {
            var vendor = new Vendor
                 {
                     VendorID = ((DBNull.Value == record[DBDataColumnVendorID])
                                     ?
                                         0
                                     : (int) record[DBDataColumnVendorID]),
                     VendorName = ((DBNull.Value == record[DBDataColumnVendorName])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnVendorName]).Trim())
                 };

            return(vendor);
        }
    }
}
