using System;
using System.Data;

namespace DataAccessModule
{
    public class CategoryMapper : MapperBase<Category>
    {
        public const string CategoryIDColumn = "CategoryID";
        public const string CategoryNameColumn = "CategoryName";
        public const string CategoryPhotoColumn = "CategoryPhoto";

        protected override Category Map(IDataRecord record)
        {
            Category category;
            if (record.FieldCount > 1)
            {
                category = new Category
                {
                    CategoryID = ((DBNull.Value == record[CategoryIDColumn])
                                    ?
                                        0
                                    : (int)record[CategoryIDColumn]),
                    Name = ((DBNull.Value == record[CategoryNameColumn])
                                      ?
                                          string.Empty
                                      : ((string)record[CategoryNameColumn]).Trim()),
                    Picture = ((DBNull.Value == record[CategoryPhotoColumn])
                                      ?
                                          string.Empty
                                      : ((string)record[CategoryPhotoColumn]).Trim())
                };
            }
            else
            {
                category = new Category
                {
                    CategoryID = ((DBNull.Value == record[CategoryIDColumn])
                                    ?
                                        0
                                    : (int)record[CategoryIDColumn])
                };
            }

            return (category);
        }
    }
}
