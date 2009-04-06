using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Summary description for VendorDA
    /// </summary>
    public class VendorDA : DataAccessBase<Vendor>
    {
        #region Constructors
        public VendorDA()
        {
            mapper = new VendorMapper();
        }

        public VendorDA(string connectionString, string providerInvariantName) : base(connectionString, providerInvariantName)
        {
            mapper = new VendorMapper();
        }
        #endregion

        #region Save & Get
        /// <summary>
        /// Saves an Item object to a Database
        /// </summary>
        /// <param name="item">Item to be saved in to the database(INSERTed or UPDATEd)</param>
        /// <returns></returns>
        public override int Save(Vendor vendor)
        {
            //Check for the objects existsence in the database using the Primary key
            var checkParam = new DbParameter[1];
            checkParam[0] = CreateParameter(VendorTable.IdParam, vendor.Id);
            Collection<Vendor> categoryCheck = ExecuteQuery(checkParam, VendorTable.SelectById);

            //Add parameters
            var parameters = new List<DbParameter>();
            parameters.Add(CreateParameter(VendorTable.IdParam, vendor.Id, VendorTable.IdColumn));
            parameters.Add(CreateParameter(VendorTable.IsActiveParam, vendor.IsActive, VendorTable.IsActiveColumn));
            parameters.Add(CreateParameter(VendorTable.NameParam, vendor.Name, VendorTable.NameColumn));
            parameters.Add(CreateParameter(VendorTable.MainPhoneParam, vendor.MainPhone, VendorTable.MainPhoneColumn));
            parameters.Add(CreateParameter(VendorTable.ContactNameParam, vendor.ContactName, VendorTable.ContactNameColumn));
            parameters.Add(CreateParameter(VendorTable.EmailParam, vendor.Email, VendorTable.EmailColumn));
            parameters.Add(CreateParameter(VendorTable.PhoneParam, vendor.Phone, VendorTable.PhoneColumn));
            parameters.Add(CreateParameter(VendorTable.WebsiteParam, vendor.Website, VendorTable.WebsiteColumn));
            parameters.Add(CreateParameter(VendorTable.AddressParam, vendor.Address, VendorTable.AddressColumn));
            parameters.Add(CreateParameter(VendorTable.Address2Param, vendor.Address2, VendorTable.Address2Column));
            parameters.Add(CreateParameter(VendorTable.CityParam, vendor.City, VendorTable.CityColumn));
            parameters.Add(CreateParameter(VendorTable.StateParam, vendor.State, VendorTable.StateColumn));
            parameters.Add(CreateParameter(VendorTable.ZipParam, vendor.Zip, VendorTable.ZipColumn));
            parameters.Add(CreateParameter(VendorTable.CountryParam, vendor.Country, VendorTable.CountryColumn));


            if (categoryCheck.Count == 0)
                //does not exist, do INSERT
                return base.ExecuteNonQuery(parameters.ToArray(), VendorTable.Insert);
            else
                //exists, do UPDATE
                return base.ExecuteNonQuery(parameters.ToArray(), VendorTable.UpdateById);
        }

        /// <summary>
        /// Saves a Collection of Item objects to a Database
        /// </summary>
        /// <param name="items"></param>
        public override void Save(Collection<Vendor> items)
        {
            foreach (var item in items)
            {
                Save(item);
            }
        }


        public override Collection<Vendor> Get(Vendor vendor)
        {
            var parameters = new List<DbParameter>();

            #region Check each Property for a value, Add a parameter a value exists
            
            if(vendor.Id != null)
                parameters.Add(CreateParameter(VendorTable.IdParam, vendor.Id, VendorTable.IdColumn));
            if (vendor.IsActive != null)
                parameters.Add(CreateParameter(VendorTable.IsActiveParam, vendor.IsActive, VendorTable.IsActiveColumn));
            if (vendor.Name != null)
                parameters.Add(CreateParameter(VendorTable.NameParam, vendor.Name, VendorTable.NameColumn));            
            if (vendor.MainPhone != null)
                parameters.Add(CreateParameter(VendorTable.MainPhoneParam, vendor.MainPhone, VendorTable.MainPhoneColumn));
            if (vendor.ContactName != null)
                parameters.Add(CreateParameter(VendorTable.ContactNameParam, vendor.ContactName, VendorTable.ContactNameColumn));
            if (vendor.Email != null)
                parameters.Add(CreateParameter(VendorTable.EmailParam, vendor.Email, VendorTable.EmailColumn));
            if (vendor.Phone != null)
                parameters.Add(CreateParameter(VendorTable.PhoneParam, vendor.Phone, VendorTable.PhoneColumn));
            if (vendor.Website != null)
                parameters.Add(CreateParameter(VendorTable.WebsiteParam, vendor.Website, VendorTable.WebsiteColumn));
            if (vendor.Address != null)
                parameters.Add(CreateParameter(VendorTable.AddressParam, vendor.Address, VendorTable.AddressColumn));
            if (vendor.Address2 != null)
                parameters.Add(CreateParameter(VendorTable.Address2Param, vendor.Address2, VendorTable.Address2Column));
            if (vendor.City != null)
                parameters.Add(CreateParameter(VendorTable.CityParam, vendor.City, VendorTable.CityColumn));
            if (vendor.State != null)
                parameters.Add(CreateParameter(VendorTable.StateParam, vendor.State, VendorTable.StateColumn));
            if (vendor.Zip != null)
                parameters.Add(CreateParameter(VendorTable.ZipParam, vendor.Zip, VendorTable.ZipColumn));
            if (vendor.Country != null)
                parameters.Add(CreateParameter(VendorTable.CountryParam, vendor.Country, VendorTable.CountryColumn));
            #endregion

            //Build a WHERE Clause using AND
            string commandText = BuildSQLTextWhereAND(VendorTable.Select, parameters.ToArray());
            return ExecuteQuery(parameters.ToArray(), commandText);
        }

        #endregion


       
    }
}