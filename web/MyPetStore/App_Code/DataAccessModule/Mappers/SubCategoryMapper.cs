using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DataAccessModule
{
    public class SubCategoryMapper : MapperBase<SubCategory>
    {
        /// <summary>
        /// Maps a Database record to a Category Object
        /// </summary>
        /// 

        public override SubCategory Map(DbDataRecord record)
        {

            //all fields are null on construction (uses nullable types)
            var subCategory = new SubCategory();

            //check each column in the record and set a value if not null
            
            //Id
            if (record[SubCategoryTable.IdColumn] != DBNull.Value)
                subCategory.Id = (int)record[SubCategoryTable.IdColumn];
            //Name
            if (record[SubCategoryTable.NameColumn] != DBNull.Value)
                subCategory.Name = (string)record[SubCategoryTable.NameColumn];

            //ImageLocation
            if (record[SubCategoryTable.ImageColumn] != DBNull.Value)
                subCategory.ImageLocation = (string)record[SubCategoryTable.ImageColumn];

            //Category Table
            CategoryMapper categoryMapper = new CategoryMapper();
            Category category = categoryMapper.Map(record);
            subCategory.ParentCategory = category;
            

            return subCategory;
        }
    }
}