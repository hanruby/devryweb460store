using System;
using System.Data;

namespace DataAccessModule
{
    public class ProductItemMapper : MapperBase<ProductItem>
    {
        public const string ItemIDColumn = "ItemID";
        public const string VendorIDColumn = "VendorID";
        public const string IsActiveColumn = "IsActive";
        public const string DescriptionColumn = "Description";
        public const string QuantityAvailableColumn = "QuantityAvailable";
        public const string PriceColumn = "Price";
        public const string PhotoNameColumn = "PhotoName";
        public const string MinQuantityColumn = "MinQuantity";
        public const string CostPriceColumn = "CostPrice";
        public const string RecommendedPriceColumn = "RecommendedPrice";
        public const string UPCColumn = "UPC";
        public const string ProductNameColumn = "ProductName";
        public const string ProductCodeColumn = "ProductCode";
        public const string SizeColumn = "Size";
        public const string CategoryNameColumn = "CategoryName";
        public const string CategoryIDColumn = "CategoryID";

        protected override ProductItem Map(IDataRecord record)
        {
            var productItem = new ProductItem
                  {
                      VendorID = ((DBNull.Value == record[VendorIDColumn])
                                      ?
                                          0
                                      : (int)record[VendorIDColumn]),
                      ItemID = ((DBNull.Value == record[ItemIDColumn])
                                      ?
                                          string.Empty
                                      : (string)record[ItemIDColumn]),
                      IsActive = ((DBNull.Value == record[IsActiveColumn])
                                      ?
                                          false
                                      : (bool)record[IsActiveColumn]),
                      ProductDescription = ((DBNull.Value == record[DescriptionColumn])
                                         ?
                                             string.Empty
                                         : (string)record[DescriptionColumn]),
                      QuantityAvailable = ((DBNull.Value == record[QuantityAvailableColumn])
                                      ?
                                          0.0M
                                      : (decimal)record[QuantityAvailableColumn]),
                      Price = ((DBNull.Value == record[PriceColumn])
                                      ?
                                          0.0M
                                      : (decimal)record[PriceColumn]),
                      Picture = ((DBNull.Value == record[PhotoNameColumn])
                                     ?
                                         string.Empty
                                     : (string)record[PhotoNameColumn]),
                      MinQuantity = ((DBNull.Value == record[MinQuantityColumn])
                                         ?
                                             0.0M
                                         : (decimal)record[MinQuantityColumn]),
                      ProductCode = ((DBNull.Value == record[ProductCodeColumn])
                                                ?
                                                    string.Empty
                                                : (string)record[ProductCodeColumn]),
                      Cost = ((DBNull.Value == record[CostPriceColumn])
                                     ?
                                         0.0M
                                     : (decimal)record[CostPriceColumn]),
                      ProductSize = ((DBNull.Value == record[SizeColumn])
                                         ?
                                             string.Empty
                                         : (string) record[SizeColumn]),
                      ListPrice = ((DBNull.Value == record[RecommendedPriceColumn])
                                  ?
                                      0.0M
                                  : (decimal)record[RecommendedPriceColumn]),
                      UPC = ((DBNull.Value == record[UPCColumn])
                                 ?
                                     string.Empty
                                 : (string)record[UPCColumn]),
                      ProductName = ((DBNull.Value == record[ProductNameColumn])
                                         ?
                                             string.Empty
                                         : (string)record[ProductNameColumn]),
                      Category = ((DBNull.Value == record[CategoryNameColumn])
                                         ?
                                             string.Empty
                                         : (string)record[CategoryNameColumn]),
                      CategoryID = ((DBNull.Value == record[CategoryIDColumn])
                                         ?
                                             -1
                                         : (int)record[CategoryIDColumn]),
                  };

            return(productItem);
        }
    }
}
