using System;
using System.Data;

namespace DataAccessModule
{
    public class VendorMapper : MapperBase<Vendor>
    {
        public const string DBDataColumnVendorID = "VendorID";
        public const string DBDataColumnVendorName = "VendorName";
        public const string DBDataColumnIsActive = "IsActive";
        public const string DBDataColumnMainPhone = "MainPhone";
        public const string DBDataColumnContactName = "ContactName";
        public const string DBDataColumnContactEmail = "ContactEmail";
        public const string DBDataColumnContactPhone = "ContactPhone";
        public const string DBDataColumnWebSite = "Website";
        public const string DBDataColumnAddress = "Address";
        public const string DBDataColumnAddress2 = "Address2";
        public const string DBDataColumnCity = "City";
        public const string DBDataColumnState = "State";
        public const string DBDataColumnZip = "Zip";
        public const string DBDataColumnCountry = "Country";

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
                                       : ((string)record[DBDataColumnVendorName]).Trim()),
                     IsActive = ((DBNull.Value == record[DBDataColumnIsActive])
                                     ?
                                         false
                                     : (bool)record[DBDataColumnIsActive]),
                     MainPhone = ((DBNull.Value == record[DBDataColumnMainPhone])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnMainPhone]).Trim()),

                     ContactName = ((DBNull.Value == record[DBDataColumnContactName])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnContactName]).Trim()),
                     ContactEmail = ((DBNull.Value == record[DBDataColumnContactEmail])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnContactEmail]).Trim()),
                     Website = ((DBNull.Value == record[DBDataColumnWebSite])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnWebSite]).Trim()),

                     Address = ((DBNull.Value == record[DBDataColumnAddress])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnAddress]).Trim()),
                     Address2 = ((DBNull.Value == record[DBDataColumnAddress2])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnAddress2]).Trim()),
                     City = ((DBNull.Value == record[DBDataColumnCity])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnCity]).Trim()),
                     State = ((DBNull.Value == record[DBDataColumnState])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnState]).Trim()),

                     Zip = ((DBNull.Value == record[DBDataColumnZip])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnZip]).Trim()),
                     Country = ((DBNull.Value == record[DBDataColumnCountry])
                                       ?
                                           string.Empty
                                       : ((string)record[DBDataColumnCountry]).Trim()),
                 };

            return(vendor);
        }
    }
}
