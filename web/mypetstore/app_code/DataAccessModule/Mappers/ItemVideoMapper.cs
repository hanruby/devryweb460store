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
    /// Summary description for ItemVideoMapper
    /// </summary>
    public class ItemVideoMapper : MapperBase<ItemVideo>
    {
        public override ItemVideo Map(DbDataRecord record)
        {

            //all fields are null on construction
            var itemVideo = new ItemVideo();


            //check each column in the record and set a value if not null

            //Id
            if (record[ItemVideoTable.IdColumn] != DBNull.Value)
                itemVideo.Id = (int)record[ItemVideoTable.IdColumn];

            //ItemId
            if (record[ItemVideoTable.ItemIdColumn] != DBNull.Value)
                itemVideo.ItemId = (int)record[ItemVideoTable.ItemIdColumn];

            //VendorId
            if (record[ItemVideoTable.VendorIdColumn] != DBNull.Value)
                itemVideo.VendorId = (int)record[ItemVideoTable.VendorIdColumn];

            //VideoName
            if (record[ItemVideoTable.NameColumn] != DBNull.Value)
                itemVideo.VideoName = (string)record[ItemVideoTable.NameColumn];

            //Description
            if (record[ItemVideoTable.DescriptionColumn] != DBNull.Value)
                itemVideo.Description = (string)record[ItemVideoTable.DescriptionColumn];

            //Url
            if (record[ItemVideoTable.UrlColumn] != DBNull.Value)
                itemVideo.Url = (string)record[ItemVideoTable.UrlColumn];

            //Source
            if (record[ItemVideoTable.SourceColumn] != DBNull.Value)
                itemVideo.Source = (string)record[ItemVideoTable.SourceColumn];

            return itemVideo;
        }
    }
}
