using System;
using System.Collections.ObjectModel;
using System.Data;

namespace DataAccessModule
{
    public class ProductItemDA : SQLServerDataConnector<ProductItem>
    {
        public const string ParmVendorID = "@vendorID";
        public const string ParmProdCode = "@prodCode";
        public const string ParmUPC = "@UPC";
        public const string ParmSection = "@section";
        public const string ParmCategory = "@category";
        public const string ParmProductName = "@productName";
        public const string ParmDescription = "@productDescription";
        public const string ParmPicture = "@picture";
        public const string ParmProductSize = "@productSize";
        public const string ParmCost = "@cost";
        public const string ParmShippingSurcharge = "@shippingSurcharge";

        public ProductItem WorkingItem { set; get; }
        private bool InsertUpdateData { set; get; }
        private bool DoUpdate { set; get; }

        protected override string CommandText
        {
            get
            {
                string cmd;

                if (!InsertUpdateData)
                {
                    cmd = String.Format("Select * from Product Where VendorID = {0} and ProdCode = {1} and UPC = {2}",
                                                ParmVendorID, ParmProdCode, ParmUPC);
                }
                else
                {
                    if (DoUpdate)
                    {
                        cmd = String.Format("Update Product Set {0} = {1}, {2} = {3}, {4} = {5}, {6} = {7}, {8} = {9}, {10} = {11}, {12} = {13}, {14} = {15}, {16} = {17}, {18} = {19}, {20} = {21} Where {0} = {1} and {2} = {3} and {20} = {21}",
                                ProductItemMapper.VendorColumn, ParmVendorID,
                                ProductItemMapper.ProdCodeColumn, ParmProdCode,
                                ProductItemMapper.SectionColumn, ParmSection,
                                ProductItemMapper.CategoryColumn, ParmCategory,
                                ProductItemMapper.ProdNameColumn, ParmProductName,
                                ProductItemMapper.DescriptionColumn, ParmDescription,
                                ProductItemMapper.PictureColumn, ParmPicture,
                                ProductItemMapper.SizeColumn, ParmProductSize,
                                ProductItemMapper.CostColumn, ParmCost,
                                ProductItemMapper.ShippingChargeColumn, ParmShippingSurcharge,
                                ProductItemMapper.UPCColumn, ParmUPC);
                        DoUpdate = true;
                    }
                    else
                    {
                        cmd = String.Format("Insert into Product ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}) Values ({11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21})",
                                    ProductItemMapper.VendorColumn,
                                    ProductItemMapper.ProdCodeColumn,
                                    ProductItemMapper.CategoryColumn,
                                    ProductItemMapper.SectionColumn,
                                    ProductItemMapper.ProdNameColumn,
                                    ProductItemMapper.DescriptionColumn,
                                    ProductItemMapper.PictureColumn,
                                    ProductItemMapper.SizeColumn,
                                    ProductItemMapper.CostColumn,
                                    ProductItemMapper.ShippingChargeColumn,
                                    ProductItemMapper.UPCColumn,
                                    ParmVendorID, ParmProdCode, ParmCategory, ParmSection,
                                    ParmProductName, ParmDescription, ParmPicture,
                                    ParmProductSize, ParmCost, ParmShippingSurcharge,
                                    ParmUPC);
                        DoUpdate = false;
                    }
                }

                return(cmd);
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

            IDataParameter param = command.CreateParameter();
            if (!InsertUpdateData)
            {
                param.ParameterName = ParmVendorID;
                param.Value = WorkingItem.VendorID;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmProdCode;
                param.Value = WorkingItem.ProductCode;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmUPC;
                param.Value = WorkingItem.UPC;
                collection.Add(param);
            }
            else
            {
                param.ParameterName = ParmVendorID;
                param.Value = WorkingItem.VendorID;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmProdCode;
                param.Value = WorkingItem.ProductCode;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmSection;
                param.Value = WorkingItem.Section;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmCategory;
                param.Value = WorkingItem.Category;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmProductName;
                param.Value = WorkingItem.ProductName;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmDescription;
                param.Value = WorkingItem.ProductDescription;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmPicture;
                param.Value = WorkingItem.Picture;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmProductSize;
                param.Value = WorkingItem.ProductSize;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmCost;
                param.Value = WorkingItem.Cost;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmShippingSurcharge;
                param.Value = WorkingItem.ShippingSurcharge;
                collection.Add(param);

                param = command.CreateParameter();
                param.ParameterName = ParmUPC;
                param.Value = WorkingItem.UPC;
                collection.Add(param);
            }

            return(collection);
        }

        protected override MapperBase<ProductItem> GetMapper()
        {
            MapperBase<ProductItem> mapper = new ProductItemMapper();
            return(mapper);
        }

        public override Collection<ProductItem> Execute()
        {
            InsertUpdateData = false;
            Collection<ProductItem> retList = base.Execute();
            if (retList.Count > 0)
            {
                DoUpdate = true;
            }

            InsertUpdateData = true;
            return(base.Execute());
        }
    }
}
