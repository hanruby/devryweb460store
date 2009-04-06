using System;
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
using DataAccessModule;

namespace DataAccessModule
{


    /// <summary>
    /// Summary description for ItemCategoryMapper
    /// </summary>
    public class ItemCategoryMapper : MapperBase<ItemCategory>
    {
        /// <summary>
        /// Maps a Database record to a Category Object
        /// </summary>
        /// 

        public override ItemCategory Map(DbDataRecord record)
        {

            //all fields are null on construction (uses nullable types)
            var itemCategory = new ItemCategory();

            //check each column in the record and set a value if not null

            //ItemId
            if (record[ItemCategoryTable.ItemIdColumn] != DBNull.Value)
                itemCategory.ItemId = (int)record[ItemCategoryTable.ItemIdColumn];

            //VendorId
            if (record[ItemCategoryTable.VendorIdColumn] != DBNull.Value)
                itemCategory.VendorId = (int)record[ItemCategoryTable.VendorIdColumn];

            //CategoryId
            if (record[ItemCategoryTable.CategoryIdColumn] != DBNull.Value)
                itemCategory.CategoryId = (int)record[ItemCategoryTable.CategoryIdColumn];

            return itemCategory;
        }
    }
}