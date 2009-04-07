using System;
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
    /// Maps a Database record to a Customer Object
    /// </summary>
    public class CustomerMapper : MapperBase<Customer>
    {
        public override Customer Map(DbDataRecord record)
        {

            //all fields are null on construction
            var customer = new Customer();


            //check each column in the record and set a value if not null

            //Id
            if (record[CustomerTable.IdColumn] != DBNull.Value)
                customer.Id = (int)record[CustomerTable.IdColumn];

            //IsActive
            if (record[CustomerTable.IsActiveColumn] != DBNull.Value)
                customer.IsActive = (bool?)record[CustomerTable.IsActiveColumn];

            //Username
            if (record[CustomerTable.UsernameColumn] != DBNull.Value)
                customer.Username = (string)record[CustomerTable.UsernameColumn];

            //FirstName
            if (record[CustomerTable.FirstNameColumn] != DBNull.Value)
                customer.FirstName = (string)record[CustomerTable.FirstNameColumn];

            //LastName
            if (record[CustomerTable.LastNameColumn] != DBNull.Value)
                customer.LastName = (string)record[CustomerTable.LastNameColumn];

            //Address
            if (record[CustomerTable.AddressColumn] != DBNull.Value)
                customer.Address = (string)record[CustomerTable.AddressColumn];

            //Address2
            if (record[CustomerTable.Address2Column] != DBNull.Value)
                customer.Address2 = (string)record[CustomerTable.Address2Column];

            //City
            if (record[CustomerTable.CityColumn] != DBNull.Value)
                customer.City = (string)record[CustomerTable.CityColumn];

            //State
            if (record[CustomerTable.StateColumn] != DBNull.Value)
                customer.State = (string)record[CustomerTable.StateColumn];

            //Zip
            if (record[CustomerTable.ZipColumn] != DBNull.Value)
                customer.Zip = (string)record[CustomerTable.ZipColumn];

            //Country
            if (record[CustomerTable.CountryColumn] != DBNull.Value)
                customer.Country = (string)record[CustomerTable.CountryColumn];

            return customer;
        }
    }
}
