using System;
using System.Collections.ObjectModel;
using System.Data;

namespace DataAccessModule
{
    public class ProductListDA : SQLServerDataConnector<ProductItem>
    {
        public int VendorID { private get; set;}
        public string ProductCode { private get; set; }
        public string Section { private get; set; }
        public string Category { private get; set; }
        public string Subcategory { private get; set; }
        public string ProductName { private get; set; }
        public string ProductDescription { private get; set; }
        public string Picture { private get; set; }
        public string ProductSize { private get; set; }
        public decimal Cost { private get; set; }
        public decimal ShippingSurcharge { private get; set; }
        public string UPC { private get; set; }

        public ProductItem WorkingItem { set; get; }
        private ParmList m_parmList;

        public ProductListDA()
        {
            VendorID = -1;
            Cost = -1M;
            ShippingSurcharge = -1M;
        }

        protected override string CommandText
        {
            get
            {
                string whereClause = "";
                m_parmList = new ParmList();

                if (VendorID != -1)
                {
                    m_parmList.Add(ProductItemDA.ParmVendorID, VendorID);
                    AddToWhereClause(ref whereClause, ProductItemMapper.VendorColumn,
                                                    ProductItemDA.ParmVendorID);
                }

                if (ProductCode != null)
                {
                    m_parmList.Add(ProductItemDA.ParmProdCode, ProductCode);
                    AddToWhereClause(ref whereClause, ProductItemMapper.ProdCodeColumn,
                                                    ProductItemDA.ParmProdCode);
                }

                if (Section != null)
                {
                    m_parmList.Add(ProductItemDA.ParmSection, Section);
                    AddToWhereClause(ref whereClause, ProductItemMapper.SectionColumn,
                                                    ProductItemDA.ParmSection);
                }

                if (Category != null)
                {
                    m_parmList.Add(ProductItemDA.ParmCategory, Category);
                    AddToWhereClause(ref whereClause, ProductItemMapper.CategoryColumn,
                                                    ProductItemDA.ParmCategory);
                }

                if (Subcategory != null)
                {
                    m_parmList.Add(ProductItemDA.ParmSubcategory, Subcategory);
                    AddToWhereClause(ref whereClause, ProductItemMapper.SubcategoryColumn,
                                                    ProductItemDA.ParmSubcategory);
                }

                if (ProductName != null)
                {
                    m_parmList.Add(ProductItemDA.ParmProductName, ProductName);
                    AddToWhereClause(ref whereClause, ProductItemMapper.ProdNameColumn,
                                                    ProductItemDA.ParmProductName);
                }

                if (ProductDescription != null)
                {
                    m_parmList.Add(ProductItemDA.ParmDescription, ProductDescription);
                    AddToWhereClause(ref whereClause, ProductItemMapper.DescriptionColumn,
                                                    ProductItemDA.ParmDescription);
                }

                if (Picture != null)
                {
                    m_parmList.Add(ProductItemDA.ParmPicture, Picture);
                    AddToWhereClause(ref whereClause, ProductItemMapper.PictureColumn,
                                                        ProductItemDA.ParmPicture);
                }

                if (ProductSize != null)
                {
                    m_parmList.Add(ProductItemDA.ParmProductSize, ProductSize);
                    AddToWhereClause(ref whereClause, ProductItemMapper.SizeColumn,
                                                        ProductItemDA.ParmProductSize);
                }

                if (Cost != -1M)
                {
                    m_parmList.Add(ProductItemDA.ParmCost, Cost);
                    AddToWhereClause(ref whereClause, ProductItemMapper.CostColumn,
                                                        ProductItemDA.ParmCost);
                }

                if (ShippingSurcharge != -1M)
                {
                    m_parmList.Add(ProductItemDA.ParmShippingSurcharge, ShippingSurcharge);
                    AddToWhereClause(ref whereClause, ProductItemMapper.ShippingChargeColumn,
                                                ProductItemDA.ParmShippingSurcharge);
                }

                if (UPC != null)
                {
                    m_parmList.Add(ProductItemDA.ParmUPC, UPC);
                    AddToWhereClause(ref whereClause, ProductItemMapper.UPCColumn,
                                                            ProductItemDA.ParmUPC);
                }

                if (whereClause != "")
                {
                    whereClause = String.Format(" Where {0}", whereClause);
                }

                return (String.Format("Select * from Product{0}", whereClause));
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

            foreach (ParmObject obj in m_parmList.Items)
            {
                IDataParameter param = command.CreateParameter();
                param.ParameterName = obj.ParmName;
                param.Value = obj.ParmObj;
                collection.Add(param);
            }

            return(collection);
        }

        protected override MapperBase<ProductItem> GetMapper()
        {
            MapperBase<ProductItem> mapper = new ProductItemMapper();
            return(mapper);
        }

        private static void AddToWhereClause(ref string P_str,
                                string P_columnName, string P_parmValue)
        {
            string commaStr = "";
            if (P_str != "")
            {
                commaStr = ", ";
            }

            P_str = string.Format("{0}{1}{2} = {3}", P_str, commaStr,
                                                P_columnName, P_parmValue);
        }
    }
}
