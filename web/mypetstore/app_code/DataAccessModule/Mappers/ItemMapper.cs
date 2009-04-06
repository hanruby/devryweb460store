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
    /// Summary description for ItemMapper
    /// </summary>
    public class ItemMapper : MapperBase<Item>
    {
        public override Item Map(DbDataRecord record)
        {

            //all fields are null on construction
            var item = new Item();


            //check each column in the record and set a value if not null

            //Id
            if (record[ItemTable.IdColumn] != DBNull.Value)
                item.Id = (int)record[ItemTable.IdColumn];

            //VendorId
            if (record[ItemTable.VendorIdColumn] != DBNull.Value)
                item.VendorId = (int)record[ItemTable.VendorIdColumn];

            //IsActive
            if (record[ItemTable.IsActiveColumn] != DBNull.Value)
                item.IsActive = (bool)record[ItemTable.IsActiveColumn];

            //Description
            if (record[ItemTable.DescriptionColumn] != DBNull.Value)
                item.Description = (string)record[ItemTable.DescriptionColumn];

            //QuantityAvailable
            if (record[ItemTable.QuantityAvailableColumn] != DBNull.Value)
                item.QuantityAvailable = (int)record[ItemTable.QuantityAvailableColumn];

            //Price
            if (record[ItemTable.PriceColumn] != DBNull.Value)
                item.Price = (decimal)record[ItemTable.PriceColumn];

            //ImageName
            if (record[ItemTable.ImageNameColumn] != DBNull.Value)
                item.ImageName = (string)record[ItemTable.ImageNameColumn];

            //ImageLocation
            if (record[ItemTable.ImageLocationColumn] != DBNull.Value)
                item.ImageLocation = (string)record[ItemTable.ImageLocationColumn];

            //MinQuantity
            if (record[ItemTable.MinQuantityColumn] != DBNull.Value)
                item.MinQuantity = (int)record[ItemTable.MinQuantityColumn];

            //CostPrice
            if (record[ItemTable.CostPriceColumn] != DBNull.Value)
                item.CostPrice = (decimal)record[ItemTable.CostPriceColumn];

            //RecommendedPrice
            if (record[ItemTable.RecommendedPriceColumn] != DBNull.Value)
                item.RecommendPrice = (decimal)record[ItemTable.RecommendedPriceColumn];

            //UPC
            if (record[ItemTable.UPCColumn] != DBNull.Value)
                item.Upc = (string)record[ItemTable.UPCColumn];

            //Name
            if (record[ItemTable.NameColumn] != DBNull.Value)
                item.Name = (string)record[ItemTable.NameColumn];

            //Code
            if (record[ItemTable.CodeColumn] != DBNull.Value)
                item.Code = (string)record[ItemTable.CodeColumn];

            //Size
            if (record[ItemTable.SizeColumn] != DBNull.Value)
                item.Size = (string)record[ItemTable.SizeColumn];

            return item;
        }
    }
}