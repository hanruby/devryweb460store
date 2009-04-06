using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
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
    /// Summary description for ItemDA
    /// </summary>
    public class ItemDA : DataAccessBase<Item>
    {
        public ItemDA()
        {
            mapper = new ItemMapper();
        }

        public ItemDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new ItemMapper();
        }

        #region Save & Get
        /// <summary>
        /// Saves an Item object to a Database
        /// </summary>
        /// <param name="item">Item to be saved in to the database(INSERTed or UPDATEd)</param>
        /// <returns></returns>
        public override int Save(Item item)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(ItemTable.IdParam, item.Id);
            Collection<Item> categoryCheck = ExecuteQuery(checkParam, ItemTable.SelectById);

            //Add parameters
            var parameters = new List<DbParameter>();
            parameters.Add(CreateParameter(ItemTable.IdParam, item.Id));
            parameters.Add(CreateParameter(ItemTable.VendorIdParam, item.VendorId));
            parameters.Add(CreateParameter(ItemTable.IsActiveParam, item.IsActive));
            parameters.Add(CreateParameter(ItemTable.DescriptionParam, item.Description));
            parameters.Add(CreateParameter(ItemTable.QuantityAvailableParam, item.QuantityAvailable));
            parameters.Add(CreateParameter(ItemTable.PriceParam, item.Price));
            parameters.Add(CreateParameter(ItemTable.ImageNameParam, item.ImageName));
            parameters.Add(CreateParameter(ItemTable.ImageLocationParam, item.ImageLocation));
            parameters.Add(CreateParameter(ItemTable.MinQuantityParam, item.MinQuantity));
            parameters.Add(CreateParameter(ItemTable.CostPriceParam, item.CostPrice));
            parameters.Add(CreateParameter(ItemTable.RecommendedPriceParam, item.RecommendPrice));
            parameters.Add(CreateParameter(ItemTable.UPCParam, item.Upc));
            parameters.Add(CreateParameter(ItemTable.NameParam, item.Name));
            parameters.Add(CreateParameter(ItemTable.CodeParam, item.Code));
            parameters.Add(CreateParameter(ItemTable.SizeParam, item.Size));

            if (categoryCheck.Count == 0)
                //does not exist, do INSERT
                return base.ExecuteNonQuery(parameters.ToArray(), ItemTable.Insert);
            else
                //exists, do UPDATE
                return base.ExecuteNonQuery(parameters.ToArray(), ItemTable.UpdateById);
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override void Save(Collection<Item> items)
        {
            foreach (var item in items)
            {
                Save(item);
            }
        }


        public override Collection<Item> Get(Item item)
        {
            var parameters = new List<DbParameter>();

            #region Check each Property for a value, Add a parameter a value exists
            //Id
            if (item.Id != null)
                parameters.Add(CreateParameter(ItemTable.IdParam, item.Id, ItemTable.IdColumn));
            //VendorId
            if (item.VendorId != null)
                parameters.Add(CreateParameter(ItemTable.VendorIdParam, item.VendorId, ItemTable.VendorIdColumn));
            //IsActive
            if (item.IsActive != null)
                parameters.Add(CreateParameter(ItemTable.IsActiveParam, item.IsActive, ItemTable.IsActiveColumn));
            //Description
            if (item.Description != null)
                parameters.Add(CreateParameter(ItemTable.DescriptionParam, item.Description, ItemTable.DescriptionColumn));
            //QuantityAvailable
            if (item.QuantityAvailable != null)
                parameters.Add(CreateParameter(ItemTable.QuantityAvailableParam, item.QuantityAvailable, ItemTable.QuantityAvailableColumn));
            //Price
            if (item.Price != null)
                parameters.Add(CreateParameter(ItemTable.PriceParam, item.Price, ItemTable.PriceColumn));
            //ImageName
            if (item.ImageName != null)
                parameters.Add(CreateParameter(ItemTable.ImageNameParam, item.ImageName, ItemTable.ImageNameColumn));
            //ImageLocation
            if (item.ImageLocation != null)
                parameters.Add(CreateParameter(ItemTable.ImageLocationParam, item.ImageLocation, ItemTable.ImageLocationColumn));
            //MinQuantity
            if (item.MinQuantity != null)
                parameters.Add(CreateParameter(ItemTable.MinQuantityParam, item.MinQuantity, ItemTable.MinQuantityColumn));
            //CostPrice
            if (item.CostPrice != null)
                parameters.Add(CreateParameter(ItemTable.CostPriceParam, item.CostPrice, ItemTable.CostPriceColumn));
            //RecommendedPrice
            if (item.RecommendPrice != null)
                parameters.Add(CreateParameter(ItemTable.RecommendedPriceParam, item.RecommendPrice, ItemTable.RecommendedPriceColumn));
            //UPC
            if (item.Upc != null)
                parameters.Add(CreateParameter(ItemTable.UPCParam, item.Upc, ItemTable.UPCColumn));
            //Name
            if (item.Name != null)
                parameters.Add(CreateParameter(ItemTable.NameParam, item.Name, ItemTable.NameColumn));
            //Code
            if (item.Code != null)
                parameters.Add(CreateParameter(ItemTable.CodeParam, item.Code, ItemTable.CodeColumn));
            //Size
            if (item.Size != null)
                parameters.Add(CreateParameter(ItemTable.SizeParam, item.Size, ItemTable.SizeColumn));
            #endregion

            //Build a WHERE Clause using AND
            string commandText = BuildSQLTextWhereAND(ItemTable.Select, parameters.ToArray());
            return ExecuteQuery(parameters.ToArray(), commandText);
        }
        #endregion

    }
}