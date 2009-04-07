using System;
using System.Data;
using System.Data.Common;

namespace DataAccessModule
{
    public class VendorMapper : MapperBase<Vendor>
    {
        /// <summary>
        /// Maps a Database record to a Vendor Object
        /// </summary>
		public override Vendor Map(DbDataRecord record)
        {

            //all fields are null on construction
            var vendor = new Vendor();


            //check each column in the record and set a value if not null

            //Id
            if (record[VendorTable.IdColumn] != DBNull.Value)
                vendor.Id = (int)record[VendorTable.IdColumn];

            //IsActive
            if (record[VendorTable.IsActiveColumn] != DBNull.Value)
                vendor.IsActive = (bool)record[VendorTable.IsActiveColumn];

            //VendorName
            if (record[VendorTable.NameColumn] != DBNull.Value)
                vendor.Name = (string)record[VendorTable.NameColumn];

            //MainPhone
            if (record[VendorTable.MainPhoneColumn] != DBNull.Value)
                vendor.MainPhone = (string)record[VendorTable.MainPhoneColumn];

            //ContactName
            if (record[VendorTable.ContactNameColumn] != DBNull.Value)
                vendor.ContactName = (string)record[VendorTable.ContactNameColumn];

            //Email
            if (record[VendorTable.EmailColumn] != DBNull.Value)
                vendor.Email = (string)record[VendorTable.EmailColumn];

            //Phone
            if (record[VendorTable.PhoneColumn] != DBNull.Value)
                vendor.Phone = (string)record[VendorTable.PhoneColumn];

            //Website
            if (record[VendorTable.WebsiteColumn] != DBNull.Value)
                vendor.Website = (string)record[VendorTable.WebsiteColumn];

            //Address
            if (record[VendorTable.AddressColumn] != DBNull.Value)
                vendor.Address = (string)record[VendorTable.AddressColumn];

            //Address2
            if (record[VendorTable.Address2Column] != DBNull.Value)
                vendor.Address2 = (string)record[VendorTable.Address2Column];

            //City
            if (record[VendorTable.CityColumn] != DBNull.Value)
                vendor.City = (string)record[VendorTable.CityColumn];

            //State
            if (record[VendorTable.StateColumn] != DBNull.Value)
                vendor.State = (string)record[VendorTable.StateColumn];

            //Zip
            if (record[VendorTable.ZipColumn] != DBNull.Value)
                vendor.Zip = (string)record[VendorTable.ZipColumn];

            //Country
            if (record[VendorTable.CountryColumn] != DBNull.Value)
                vendor.Country = (string)record[VendorTable.CountryColumn];

            return vendor;
        }
    }
}
