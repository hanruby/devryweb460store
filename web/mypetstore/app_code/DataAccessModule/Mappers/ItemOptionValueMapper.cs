using System;
using System.Data;
using System.Data.Common;
using DataAccessModule;

/// <summary>
/// Maps a Database record to a Category Object
/// </summary>
/// 
public class ItemOptionValueMapper : MapperBase<ItemOptionValue>
{

    public override ItemOptionValue Map(DbDataRecord record)
    {

        //all fields are null on construction (uses nullable types)
        var itemOptionValue = new ItemOptionValue();

        //check each column in the record and set a value if not null

        //Id
        if (record[ItemOptionValueTable.IdColumn] != DBNull.Value)
            itemOptionValue.Id = (int)record[ItemOptionValueTable.IdColumn];

        //ItemOptionId
        if (record[ItemOptionValueTable.ItemOptionIdColumn] != DBNull.Value)
            itemOptionValue.Id = (int)record[ItemOptionValueTable.ItemOptionIdColumn];

        //ItemId
        if (record[ItemOptionValueTable.ItemIdColumn] != DBNull.Value)
            itemOptionValue.Id = (int)record[ItemOptionValueTable.ItemIdColumn];

        //VenodrId
        if (record[ItemOptionValueTable.VendorIdColumn] != DBNull.Value)
            itemOptionValue.Id = (int)record[ItemOptionValueTable.VendorIdColumn];

        //OptionValue
        if (record[ItemOptionValueTable.OptionValueColumn] != DBNull.Value)
            itemOptionValue.Id = (int)record[ItemOptionValueTable.OptionValueColumn];

        return itemOptionValue;
    }
}
