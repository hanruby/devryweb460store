using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessModule
{
    public class ProductList
    {
        public int VendorID { private get; set;}
        public string ProductCode { private get; set; }
        public string Section { private get; set; }
        public string Category { private get; set; }
        public string ProductName { private get; set; }
        public string ProductDescription { private get; set; }
        public string Picture { private get; set; }
        public string ProductSize { private get; set; }
        public decimal Cost { private get; set; }
        public decimal ShippingSurcharge { private get; set; }
        public string UPC { private get; set; }

        public ProductList()
        {
            VendorID = -1;
            Cost = -1M;
            ShippingSurcharge = -1M;
        }

            /// <summary>
            /// This method will get a list of products. Any attributes set
            /// will be use for the where clause. If no attributes are selected
            /// then all products will be returned.
            /// </summary>
            /// <returns>
            /// List of products selected
            /// </returns>

        public List<ProductItem> GetProductList(DAConnect P_connection)
        {
            var retVal = new List<ProductItem>();
            string whereClause = "";
            var parmList = new ParmList();

            if (VendorID != -1)
            {
                parmList.Add(ProductItem.ParmVendorID, VendorID);
                AddToWhereClause(ref whereClause, ProductItem.VendorColumn,
                                                ProductItem.ParmVendorID);
            }

            if (ProductCode != null)
            {
                parmList.Add(ProductItem.ParmProdCode, ProductCode);
                AddToWhereClause(ref whereClause, ProductItem.ProdCodeColumn,
                                                ProductItem.ParmProdCode);
            }

            if (Section != null)
            {
                parmList.Add(ProductItem.ParmSection, Section);
                AddToWhereClause(ref whereClause, ProductItem.SectionColumn,
                                                ProductItem.ParmSection);
            }

            if (Category != null)
            {
                parmList.Add(ProductItem.ParmCategory, Category);
                AddToWhereClause(ref whereClause, ProductItem.CategoryColumn,
                                                ProductItem.ParmCategory);
            }

            if (ProductName != null)
            {
                parmList.Add(ProductItem.ParmProductName, ProductName);
                AddToWhereClause(ref whereClause, ProductItem.ProdNameColumn,
                                                ProductItem.ParmProductName);
            }

            if (ProductDescription != null)
            {
                parmList.Add(ProductItem.ParmDescription, ProductDescription);
                AddToWhereClause(ref whereClause, ProductItem.DescriptionColumn,
                                                ProductItem.ParmDescription);
            }

            if (Picture != null)
            {
                parmList.Add(ProductItem.ParmPicture, Picture);
                AddToWhereClause(ref whereClause, ProductItem.PictureColumn,
                                                    ProductItem.ParmPicture);
            }

            if (ProductSize != null)
            {
                parmList.Add(ProductItem.ParmProductSize, ProductSize);
                AddToWhereClause(ref whereClause, ProductItem.SizeColumn,
                                                    ProductItem.ParmProductSize);
            }

            if (Cost != -1M)
            {
                parmList.Add(ProductItem.ParmCost, Cost);
                AddToWhereClause(ref whereClause, ProductItem.CostColumn,
                                                    ProductItem.ParmCost);
            }

            if (ShippingSurcharge != -1M)
            {
                parmList.Add(ProductItem.ParmShippingSurcharge, ShippingSurcharge);
                AddToWhereClause(ref whereClause, ProductItem.ShippingChargeColumn,
                                            ProductItem.ParmShippingSurcharge);
            }

            if (UPC != null)
            {
                parmList.Add(ProductItem.ParmUPC, UPC);
                AddToWhereClause(ref whereClause, ProductItem.UPCColumn,
                                                        ProductItem.ParmUPC);
            }

            if (whereClause != "")
            {
                whereClause = String.Format(" Where {0}", whereClause);
            }

            string cmd = String.Format("Select * from Product{0}", whereClause);
            DataTable data = P_connection.ReturnSQLDataReader(cmd, parmList);
            foreach (DataRow row in data.Rows)
            {
                var item = new ProductItem();

                item.Category = row[ProductItem.CategoryColumn].ToString().Trim();
                item.Cost = (decimal)row[ProductItem.CostColumn];
                item.Picture = row[ProductItem.PictureColumn].ToString().Trim();
                item.ProductCode = row[ProductItem.ProdCodeColumn].ToString().Trim();
                item.ProductDescription = row[ProductItem.DescriptionColumn].ToString().Trim();
                item.ProductName = row[ProductItem.ProdNameColumn].ToString().Trim();
                item.ProductSize = row[ProductItem.SizeColumn].ToString().Trim();
                item.Section = row[ProductItem.SectionColumn].ToString().Trim();
                item.ShippingSurcharge = (decimal) row[ProductItem.ShippingChargeColumn];
                item.UPC = row[ProductItem.UPCColumn].ToString().Trim();

                retVal.Add(item);
            }

            return(retVal);
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
