using System;
using System.Data;

namespace DataAccessModule
{
    public class ProductItemMapper : MapperBase<ProductItem>
    {
        public const string VendorColumn = "VendorID";
        public const string ProdCodeColumn = "ProdCode";
        public const string CategoryColumn = "Category";
        public const string SectionColumn = "Section";
        public const string ProdNameColumn = "ProdName";
        public const string DescriptionColumn = "Description";
        public const string PictureColumn = "Picture";
        public const string SizeColumn = "Size";
        public const string CostColumn = "Cost";
        public const string ShippingChargeColumn = "ShippingCharge";
        public const string UPCColumn = "UPC";

        protected override ProductItem Map(IDataRecord record)
        {
            var productItem = new ProductItem
                          {
                              VendorID = ((DBNull.Value == record[VendorColumn])
                                              ?
                                                  0
                                              : (int) record[VendorColumn]),
                              ProductCode = ((DBNull.Value == record[ProdCodeColumn])
                                                 ?
                                                     string.Empty
                                                 : (string) record[ProdCodeColumn]),
                              Category = ((DBNull.Value == record[CategoryColumn])
                                              ?
                                                  string.Empty
                                              : (string) record[CategoryColumn]),
                              Section = ((DBNull.Value == record[SectionColumn])
                                             ?
                                                 string.Empty
                                             : (string) record[SectionColumn]),
                              ProductName = ((DBNull.Value == record[ProdNameColumn])
                                                 ?
                                                     string.Empty
                                                 : (string) record[ProdNameColumn]),
                              ProductDescription = ((DBNull.Value == record[DescriptionColumn])
                                                        ?
                                                            string.Empty
                                                        : (string) record[DescriptionColumn]),
                              Picture = ((DBNull.Value == record[PictureColumn])
                                             ?
                                                 string.Empty
                                             : (string) record[PictureColumn]),
                              ProductSize = ((DBNull.Value == record[SizeColumn])
                                                 ?
                                                     string.Empty
                                                 : (string) record[SizeColumn]),
                              Cost = ((DBNull.Value == record[CostColumn])
                                          ?
                                              0.0M
                                          : (decimal) record[CostColumn]),
                              ShippingSurcharge = ((DBNull.Value == record[ShippingChargeColumn])
                                                       ?
                                                           0.0M
                                                       : (decimal) record[ShippingChargeColumn]),
                              UPC = ((DBNull.Value == record[UPCColumn])
                                         ?
                                             string.Empty
                                         : (string) record[UPCColumn])
                          };

            return(productItem);
        }
    }
}
