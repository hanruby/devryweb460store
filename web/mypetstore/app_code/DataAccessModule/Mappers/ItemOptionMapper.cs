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

namespace DataAccessModule
{

    /// <summary>
    /// Summary description for ItemOptionMapper
    /// </summary>
    public class ItemOptionMapper : MapperBase<ItemOption>
    {
        public override ItemOption Map(DbDataRecord record)
        {
            //all fields are null on construction (uses nullable types)
            var itemOption = new ItemOption();

            //check each column in the record and set a value if not null

            //Id
            if (record[ItemOptionTable.IdColumn] != DBNull.Value)
                itemOption.Id = (int)record[ItemOptionTable.IdColumn];

            //ItemId
            if (record[ItemOptionTable.ItemIdColumn] != DBNull.Value)
                itemOption.Id = (int)record[ItemOptionTable.ItemIdColumn];

            //VenodrId
            if (record[ItemOptionTable.VendorIdColumn] != DBNull.Value)
                itemOption.Id = (int)record[ItemOptionTable.VendorIdColumn];

            //OptionName
            if (record[ItemOptionTable.OptionNameColumn] != DBNull.Value)
                itemOption.Id = (int)record[ItemOptionTable.OptionNameColumn];

            return itemOption;
        }
    }
}