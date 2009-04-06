using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Summary description for ItemVideoDA
    /// </summary>
    public class ItemVideoDA : DataAccessBase<ItemVideo>
    {
        #region Constructors
        public ItemVideoDA()
        {
            mapper = new ItemVideoMapper();
        }

        public ItemVideoDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new ItemVideoMapper();
        }
        #endregion


        #region Save & Get
        public override int Save(ItemVideo itemVideo)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(ItemVideoTable.IdParam, itemVideo.Id);
            Collection<ItemVideo> itemVideoCheck = ExecuteQuery(checkParam, ItemVideoTable.SelectById);

            //Add parameters
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(CreateParameter(ItemVideoTable.IdParam, itemVideo.Id, ItemVideoTable.IdColumn ));
            parameters.Add(CreateParameter(ItemVideoTable.ItemIdParam, itemVideo.ItemId, ItemVideoTable.ItemIdColumn));
            parameters.Add(CreateParameter(ItemVideoTable.VendorIdParam, itemVideo.VendorId, ItemVideoTable.VendorIdColumn));
            parameters.Add(CreateParameter(ItemVideoTable.NameParam, itemVideo.VideoName, ItemVideoTable.NameColumn));
            parameters.Add(CreateParameter(ItemVideoTable.DescriptionParam, itemVideo.Description, ItemVideoTable.DescriptionColumn));
            parameters.Add(CreateParameter(ItemVideoTable.UrlParam, itemVideo.Url, ItemVideoTable.UrlColumn));
            parameters.Add(CreateParameter(ItemVideoTable.SourceParam, itemVideo.Source, ItemVideoTable.SourceColumn));


            if (itemVideoCheck.Count == 0)
                //does not exist, do INSERT
                return base.ExecuteNonQuery(parameters.ToArray(), ItemVideoTable.Insert);
            else
                //exists, do UPDATE
                return base.ExecuteNonQuery(parameters.ToArray(), ItemVideoTable.UpdateById);
        }

        public override void Save(Collection<ItemVideo> itemVideos)
        {
            foreach (var video in itemVideos)
            {
                Save(video);
            }
        }

         public override Collection<ItemVideo> Get(ItemVideo itemVideo)
         {
             var parameters = new List<DbParameter>();

             #region Check each Property for a value, Add a parameter a value exists
             if (itemVideo.Id != null)
                 parameters.Add(CreateParameter(ItemVideoTable.IdParam, itemVideo.Id, ItemVideoTable.IdColumn));
             if(itemVideo.ItemId != null)
                parameters.Add(CreateParameter(ItemVideoTable.ItemIdParam, itemVideo.ItemId, ItemVideoTable.ItemIdColumn));
             if(itemVideo.VendorId != null)
                parameters.Add(CreateParameter(ItemVideoTable.VendorIdParam, itemVideo.VendorId,ItemVideoTable.VendorIdColumn));
             if(itemVideo.VideoName != null)
                parameters.Add(CreateParameter(ItemVideoTable.NameParam, itemVideo.VideoName, ItemVideoTable.NameColumn));
             if(itemVideo.Description != null)
                parameters.Add(CreateParameter(ItemVideoTable.DescriptionParam, itemVideo.Description,ItemVideoTable.DescriptionColumn));
             if(itemVideo.Url != null)
                parameters.Add(CreateParameter(ItemVideoTable.UrlParam, itemVideo.Url, ItemVideoTable.UrlColumn));
             if(itemVideo.Source != null)
                parameters.Add(CreateParameter(ItemVideoTable.SourceParam, itemVideo.Source, ItemVideoTable.SourceColumn));
             #endregion

             //Build a WHERE Clause using AND
             string commandText = BuildSQLTextWhereAND(ItemVideoTable.Select, parameters.ToArray());
             return ExecuteQuery(parameters.ToArray(), commandText);
         }
        #endregion

    }
}