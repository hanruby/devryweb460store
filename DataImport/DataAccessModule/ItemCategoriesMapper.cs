using System;
using System.Data;

namespace DataAccessModule
{
    public class ItemCategoriesMapper : MapperBase<ItemCategories>
    {
        public const string CategoryIDColumn = "CategoryID";
        public const string ItemIDColumn = "ItemID";
        public const string VendorIDColumn = "VendorID";

        protected override ItemCategories Map(IDataRecord record)
        {
            var category = new ItemCategories
            {
                CategoryID = ((DBNull.Value == record[CategoryIDColumn])
                                ?
                                    0
                                : (int)record[CategoryIDColumn]),
                VendorID = ((DBNull.Value == record[VendorIDColumn])
                                  ?
                                      0
                                  : ((int)record[VendorIDColumn])),
                ItemID = ((DBNull.Value == record[ItemIDColumn])
                                  ?
                                      string.Empty
                                  : ((string)record[ItemIDColumn]).Trim())
            };

            return (category);
        }
    }
}
