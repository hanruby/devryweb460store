using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using Utilities;

namespace DataAccessModule
{
    public class ProductItemDA : SQLServerDataConnector<ProductItem>
    {
        public const string ParmVendorID = "@VendorID";
        public const string ParmItemID = "@ItemID";
        public const string ParmProductCode = "@ProductCode";
        public const string ParmSection = "@Section";
        public const string ParmCategory = "@Category";
        public const string ParmSubcategory = "@Subcategory";
        public const string ParmProductName = "@ProductName";
        public const string ParmProductDescription = "@ProductDescription";
        public const string ParmPicture = "@Picture";
        public const string ParmProductSize = "@ProductSize";
        public const string ParmUPC = "@UPC";
        public const string ParmSize = "@Size";
        public const string ParmPrice = "@Price";
        public const string ParmListPrice = "@ListPrice";
        public const string ParmCost = "@Cost";
        public const string ParmShippingSurcharge = "@ShippingSurcharge";
        public const string ParmQuantityAvailable = "@QuantityAvailable";
        public const string ParmMinQuantity = "@MinQuantity";
        public const string ParmIsActive = "@IsActive";

        public ProductItem WorkingItem { set; get; }
        public bool InsertUpdateData { set; get; }
        private bool DoUpdate { set; get; }
        public bool GetAll { set; get; }
        private bool DoExistCheck { set; get; }

        private ParmList m_parmList;


        protected override string CommandText
        {
            get
            {
                string cmd;

                if (GetAll)
                {
                    cmd = "Select * From Items Inner Join ItemCategories itemCat On Items.ItemID = itemCat.ItemID Inner Join Categories catData On catData.CategoryID = itemCat.CategoryID";
                }
                else if (!InsertUpdateData)
                {
                    string whereClause = DoExistCheck ?
                                        CreateSQLClause(true, true) :
                                        CreateSQLClause(true, false);

                    if (whereClause != "")
                    {
                        whereClause = String.Format(" Where {0}", whereClause);
                    }

                    cmd = String.Format("Select * from Items{0}", whereClause);
                }
                else
                {
                    if (DoUpdate)
                    {
                        cmd = String.Format("Update Items Set {0}",
                                    CreateSQLClause(false, false));
                    }
                    else
                    {
                        string cols = "", values = "";
                        CreateSQLInsert(ref cols, ref values);
                        cmd = String.Format("Insert into Items ({0}) Values ({1})",
                                                                cols, values);
                    }
                }

                string msg = String.Format("ProductItem DA: cmd \"{0}\"", cmd);
                SystemDebug.Log((int)TraceLevel.Verbose, msg);

                return (cmd);
            }
        }

        protected override CommandType CommandType
        {
            get
            {
                return CommandType.Text;
            }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            var collection = new Collection<IDataParameter>();

            if (GetAll)
            {
                return (collection);
            }

            string msg = String.Format("ProductItem DA: Arg:");
            SystemDebug.Log((int)TraceLevel.Verbose, msg);

            IDataParameter param;
            foreach (ParmObject obj in m_parmList.Items)
            {
                param = command.CreateParameter();
                param.ParameterName = obj.ParmName;
                param.Value = obj.ParmObj;
                msg = String.Format("   Name: \"{0}\", Value: {1}",
                                                obj.ParmName, obj.ParmObj);
                SystemDebug.Log((int)TraceLevel.Verbose, msg);
                collection.Add(param);
            }

            msg = String.Format("ProductItem DA: Arg Complete");
            SystemDebug.Log((int)TraceLevel.Verbose, msg);
            return (collection);
        }

        protected override MapperBase<ProductItem> GetMapper()
        {
            MapperBase<ProductItem> mapper = new ProductItemMapper();
            return(mapper);
        }

        public override Collection<ProductItem> Execute()
        {
            if (GetAll)
            {
                return(base.Execute());
            }

            Collection<ProductItem> retList;
            if (InsertUpdateData)
            {
                var category = new Category {Name = WorkingItem.Category};
                var categoryReader = new CategoryDA
                {
                    WorkingItem = category,
                    InsertUpdateData = true
                };
                categoryReader.SetupConnectionString(m_connectStr);
                categoryReader.Execute();
                categoryReader.InsertUpdateData = false;
                categoryReader.DoExistCheck = true;
                var list = categoryReader.Execute();
                WorkingItem.CategoryID = list[0].CategoryID;

                InsertUpdateData = false;
                DoExistCheck = true;
                retList = base.Execute();
                if (retList.Count > 0)
                {
                    DoUpdate = true;
                }

                InsertUpdateData = true;
                DoExistCheck = false;
                retList = base.Execute();

                var item = new ItemCategories
                {
                    ItemID = WorkingItem.ItemID,
                    VendorID = WorkingItem.VendorID,
                    CategoryID = WorkingItem.CategoryID
                };

                var itemCategoryReader = new ItemCategoriesDA
                {
                    WorkingItem = item,
                    InsertUpdateData = true
                };
                itemCategoryReader.SetupConnectionString(m_connectStr);
                itemCategoryReader.Execute();
            }
            else
            {
                retList = base.Execute();

                var item = new ItemCategories
                {
                    ItemID = WorkingItem.ItemID,
                };

                var itemCategoryReader = new ItemCategoriesDA
                {
                    WorkingItem = item,
                    InsertUpdateData = false
                };
                itemCategoryReader.SetupConnectionString(m_connectStr);
                var itemCatList = itemCategoryReader.Execute();

                var category = new Category
                {
                    CategoryID = itemCatList[0].CategoryID
                };
                var categoryReader = new CategoryDA
                {
                    WorkingItem = category,
                    InsertUpdateData = false
                };
                categoryReader.SetupConnectionString(m_connectStr);
                var catList = categoryReader.Execute();
                retList[0].CategoryID = catList[0].CategoryID;
                retList[0].Category = catList[0].Name;
            }

            return(retList);
        }

        private string CreateSQLClause(bool P_useAndSeperator, bool P_doExistCheck)
        {
            var clause = "";
            m_parmList = new ParmList();

            string seperatorStr = P_useAndSeperator ? " And" : ",";

            if (WorkingItem.VendorID != -1)
            {
                m_parmList.Add(ParmVendorID, WorkingItem.VendorID);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        ProductItemMapper.VendorIDColumn,
                                            ParmVendorID);
            }

            if (WorkingItem.ItemID != null)
            {
                m_parmList.Add(ParmItemID, WorkingItem.ItemID);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    ProductItemMapper.ItemIDColumn,
                                                ParmItemID);
            }

            if (P_doExistCheck)
            {
                return(clause);
            }

            if (WorkingItem.UPC != null)
            {
                m_parmList.Add(ParmUPC, WorkingItem.UPC);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    ProductItemMapper.UPCColumn,
                                                ParmUPC);
            }

            if (WorkingItem.UseIsActive)
            {
                m_parmList.Add(ParmIsActive, WorkingItem.IsActive);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    ProductItemMapper.IsActiveColumn,
                                                ParmIsActive);
            }

            if (WorkingItem.ProductDescription != null)
            {
                m_parmList.Add(ParmProductDescription, WorkingItem.ProductDescription);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    ProductItemMapper.DescriptionColumn,
                                                ParmProductDescription);
            }

            if (WorkingItem.QuantityAvailable != -1M)
            {
                m_parmList.Add(ParmQuantityAvailable, WorkingItem.QuantityAvailable);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    ProductItemMapper.QuantityAvailableColumn,
                                                ParmQuantityAvailable);
            }

            if (WorkingItem.Price != -1M)
            {
                m_parmList.Add(ParmPrice, WorkingItem.Price);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        ProductItemMapper.PriceColumn,
                                                ParmPrice);
            }

            if (WorkingItem.Picture != null)
            {
                m_parmList.Add(ParmPicture, WorkingItem.Picture);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        ProductItemMapper.PhotoNameColumn,
                                                    ParmPicture);
            }

            if (WorkingItem.MinQuantity != -1M)
            {
                m_parmList.Add(ParmMinQuantity, WorkingItem.MinQuantity);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        ProductItemMapper.MinQuantityColumn,
                                                    ParmMinQuantity);
            }

            if (WorkingItem.Cost != -1M)
            {
                m_parmList.Add(ParmCost, WorkingItem.Cost);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        ProductItemMapper.CostPriceColumn,
                                                    ParmCost);
            }

            if (WorkingItem.ListPrice != -1M)
            {
                m_parmList.Add(ParmListPrice, WorkingItem.ListPrice);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        ProductItemMapper.RecommendedPriceColumn,
                                            ParmListPrice);
            }

            if (WorkingItem.ProductName != null)
            {
                m_parmList.Add(ParmProductName, WorkingItem.ProductName);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        ProductItemMapper.ProductNameColumn,
                                                        ParmProductName);
            }

            if (WorkingItem.ProductCode != null)
            {
                m_parmList.Add(ParmProductCode, WorkingItem.ProductCode);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        ProductItemMapper.ProductCodeColumn,
                                            ParmProductCode);
            }

            if (WorkingItem.Size != null)
            {
                m_parmList.Add(ParmSize, WorkingItem.Size);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    ProductItemMapper.SizeColumn,
                                                        ParmSize);
            }

            return(clause);
        }

        private void CreateSQLInsert(ref string P_cols, ref string P_values)
        {
            m_parmList = new ParmList();

            if (WorkingItem.VendorID != -1)
            {
                m_parmList.Add(ParmVendorID, WorkingItem.VendorID);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.VendorIDColumn,
                                        ParmVendorID);
            }

            if (WorkingItem.UPC != null)
            {
                m_parmList.Add(ParmUPC, WorkingItem.UPC);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.UPCColumn,
                                        ParmUPC);
            }

            if (WorkingItem.UseIsActive)
            {
                m_parmList.Add(ParmIsActive, WorkingItem.IsActive);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.IsActiveColumn,
                                        ParmIsActive);
            }

            if (WorkingItem.ItemID != null)
            {
                m_parmList.Add(ParmItemID, WorkingItem.ItemID);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.ItemIDColumn,
                                        ParmItemID);
            }

            if (WorkingItem.ProductDescription != null)
            {
                m_parmList.Add(ParmProductDescription, WorkingItem.ProductDescription);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.DescriptionColumn,
                                        ParmProductDescription);
            }

            if (WorkingItem.QuantityAvailable != -1M)
            {
                m_parmList.Add(ParmQuantityAvailable, WorkingItem.QuantityAvailable);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.QuantityAvailableColumn,
                                        ParmQuantityAvailable);
            }

            if (WorkingItem.Price != -1M)
            {
                m_parmList.Add(ParmPrice, WorkingItem.Price);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.PriceColumn,
                                        ParmPrice);
            }

            if (WorkingItem.Picture != null)
            {
                m_parmList.Add(ParmPicture, WorkingItem.Picture);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.PhotoNameColumn,
                                        ParmPicture);
            }

            if (WorkingItem.MinQuantity != -1)
            {
                m_parmList.Add(ParmMinQuantity, WorkingItem.MinQuantity);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.MinQuantityColumn,
                                        ParmMinQuantity);
            }

            if (WorkingItem.Cost != -1M)
            {
                m_parmList.Add(ParmCost, WorkingItem.Cost);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.CostPriceColumn,
                                        ParmCost);
            }

            if (WorkingItem.ListPrice != -1M)
            {
                m_parmList.Add(ParmListPrice, WorkingItem.ListPrice);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.CostPriceColumn,
                                        ParmListPrice);
            }

            if (WorkingItem.ProductName != null)
            {
                m_parmList.Add(ParmProductName, WorkingItem.ProductName);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.ProductNameColumn,
                                        ParmProductName);
            }

            if (WorkingItem.ProductCode != null)
            {
                m_parmList.Add(ParmProductCode, WorkingItem.ProductCode);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.ProductCodeColumn,
                                        ParmProductCode);
            }

            if (WorkingItem.Size != null)
            {
                m_parmList.Add(ParmSize, WorkingItem.Size);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ProductItemMapper.SizeColumn,
                                        ParmSize);
            }
        }
    }
}
