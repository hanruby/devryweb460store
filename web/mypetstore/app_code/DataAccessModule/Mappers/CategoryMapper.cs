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
    public class CategoryMapper : MapperBase<Category>
    {
        /// <summary>
        /// Maps a Database record to a Category Object
        /// </summary>
        /// 

        public override Category Map(DbDataRecord record)
        {

            //all fields are null on construction (uses nullable types)
            var category = new Category();

            //check each column in the record and set a value if not null
            
            //Id
            if (record[CategoryTable.IdColumn] != DBNull.Value)
                category.Id = (int)record[CategoryTable.IdColumn];

            //Name
            if (record[CategoryTable.NameColumn] != DBNull.Value)
                category.Name = (string)record[CategoryTable.NameColumn];

            //ImageLocation
            if (record[CategoryTable.ImageColumn] != DBNull.Value)
                category.ImageLocation = (string)record[CategoryTable.ImageColumn];
            
            return category;
        }
    }
}