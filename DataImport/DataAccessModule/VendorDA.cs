using System;
using System.Collections.ObjectModel;
using System.Data;
using Utilities;

namespace DataAccessModule
{
    public class VendorDA : SQLServerDataConnector<Vendor>
    {
        public const string ParmVendorID = "@VendorID";
        public const string ParmVendorName = "@VendorName";
        public const string ParmIsActive = "@IsActive";
        public const string ParmMainPhone = "@MainPhone";
        public const string ParmContactName = "@ContactName";
        public const string ParmContactEmail = "@ContactEmail";
        public const string ParmContactPhone = "@ContactPhone";
        public const string ParmWebsite = "@Website";
        public const string ParmAddress = "@Address";
        public const string ParmAddress2 = "@Address2";
        public const string ParmCity = "@City";
        public const string ParmState = "@State";
        public const string ParmZip = "@Zip";
        public const string ParmCountry = "@Country";

        public Vendor WorkingItem { set; get; }
        public bool InsertUpdateData { set; get; }
        public bool GetAll { set; get; }
        private bool DoUpdate { set; get; }
        private bool DoExistCheck { set; get; }

        private ParmList m_parmList;

        protected override string CommandText
        {
            get
            {
                string cmd;

                if (GetAll)
                {
                    cmd = "Select * from Vendor";
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

                    cmd = String.Format("Select * from Vendor{0}", whereClause);
                }
                else
                {
                    if (DoUpdate)
                    {
                        cmd = String.Format("Update Vendor Set {0}",
                                    CreateSQLClause(false, false));
                    }
                    else
                    {
                        string cols = "", values = "";
                        CreateSQLInsert(ref cols, ref values);
                        cmd = String.Format("Insert into Vendor ({0}) Values ({1})",
                                                                cols, values);
                    }
                }

                return(cmd);
            }
        }

        protected override CommandType CommandType
        {
            get { return(CommandType.Text); }
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            var collection = new Collection<IDataParameter>();

            if (GetAll)
            {
                return(collection);
            }

            IDataParameter param;
            foreach (ParmObject obj in m_parmList.Items)
            {
                param = command.CreateParameter();
                param.ParameterName = obj.ParmName;
                param.Value = obj.ParmObj;
                collection.Add(param);
            }

            return(collection);
        }

        protected override MapperBase<Vendor> GetMapper()
        {
            MapperBase<Vendor> mapper = new VendorMapper();
            return(mapper);
        }

        public override Collection<Vendor> Execute()
        {
            if (GetAll)
            {
                return(base.Execute());
            }

            if (InsertUpdateData)
            {
                InsertUpdateData = false;
                DoExistCheck = true;
                Collection<Vendor> retList = base.Execute();
                if (retList.Count > 0)
                {
                    DoUpdate = true;
                }

                InsertUpdateData = true;
                DoExistCheck = false;
            }

            return(base.Execute());
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
                                        VendorMapper.DBDataColumnVendorID,
                                            ProductItemDA.ParmVendorID);
            }

            if (P_doExistCheck)
            {
                return(clause);
            }

            if (WorkingItem.VendorName != null)
            {
                m_parmList.Add(ParmVendorName, WorkingItem.VendorName);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    VendorMapper.DBDataColumnVendorName,
                                                ParmVendorName);
            }

            if (WorkingItem.UseIsActive)
            {
                m_parmList.Add(ParmIsActive, WorkingItem.IsActive);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    VendorMapper.DBDataColumnIsActive,
                                                ParmIsActive);
            }

            if (WorkingItem.MainPhone != null)
            {
                m_parmList.Add(ParmMainPhone, WorkingItem.MainPhone);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    VendorMapper.DBDataColumnMainPhone,
                                                ParmMainPhone);
            }

            if (WorkingItem.ContactName != null)
            {
                m_parmList.Add(ParmContactName, WorkingItem.ContactName);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    VendorMapper.DBDataColumnContactName,
                                                ParmContactName);
            }

            if (WorkingItem.ContactEmail != null)
            {
                m_parmList.Add(ParmContactEmail, WorkingItem.ContactEmail);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    VendorMapper.DBDataColumnContactEmail,
                                                ParmContactEmail);
            }

            if (WorkingItem.ContactPhone != null)
            {
                m_parmList.Add(ParmContactPhone, WorkingItem.ContactPhone);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        VendorMapper.DBDataColumnContactPhone,
                                                ParmContactPhone);
            }

            if (WorkingItem.Website != null)
            {
                m_parmList.Add(ParmWebsite, WorkingItem.Website);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        VendorMapper.DBDataColumnWebSite,
                                                    ParmWebsite);
            }

            if (WorkingItem.Address != null)
            {
                m_parmList.Add(ParmAddress, WorkingItem.Address);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        VendorMapper.DBDataColumnAddress,
                                                    ParmAddress);
            }

            if (WorkingItem.Address2 != null)
            {
                m_parmList.Add(ParmAddress2, WorkingItem.Address2);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        VendorMapper.DBDataColumnAddress2,
                                                    ParmAddress2);
            }

            if (WorkingItem.City != null)
            {
                m_parmList.Add(ParmCity, WorkingItem.City);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        VendorMapper.DBDataColumnCity,
                                            ParmCity);
            }

            if (WorkingItem.State != null)
            {
                m_parmList.Add(ParmState, WorkingItem.State);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        VendorMapper.DBDataColumnState,
                                                        ParmState);
            }

            if (WorkingItem.Zip != null)
            {
                m_parmList.Add(ParmZip, WorkingItem.Zip);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        VendorMapper.DBDataColumnZip,
                                            ParmZip);
            }

            if (WorkingItem.Country != null)
            {
                m_parmList.Add(ParmCountry, WorkingItem.Country);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    VendorMapper.DBDataColumnCountry,
                                                        ParmCountry);
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
                                        VendorMapper.DBDataColumnVendorID,
                                        ParmVendorID);
            }

            if (WorkingItem.VendorName != null)
            {
                m_parmList.Add(ParmVendorName, WorkingItem.VendorName);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnVendorName,
                                        ParmVendorName);
            }

            if (WorkingItem.UseIsActive)
            {
                m_parmList.Add(ParmIsActive, WorkingItem.IsActive);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnIsActive,
                                        ParmIsActive);
            }

            if (WorkingItem.MainPhone != null)
            {
                m_parmList.Add(ParmMainPhone, WorkingItem.MainPhone);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnMainPhone,
                                        ParmMainPhone);
            }

            if (WorkingItem.ContactName != null)
            {
                m_parmList.Add(ParmContactName, WorkingItem.ContactName);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnContactName,
                                        ParmContactName);
            }

            if (WorkingItem.ContactEmail != null)
            {
                m_parmList.Add(ParmContactEmail, WorkingItem.ContactEmail);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnContactEmail,
                                        ParmContactEmail);
            }

            if (WorkingItem.ContactPhone != null)
            {
                m_parmList.Add(ParmContactPhone, WorkingItem.ContactPhone);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnContactPhone,
                                        ParmContactPhone);
            }

            if (WorkingItem.Website != null)
            {
                m_parmList.Add(ParmWebsite, WorkingItem.Website);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnWebSite,
                                        ParmWebsite);
            }

            if (WorkingItem.Address != null)
            {
                m_parmList.Add(ParmAddress, WorkingItem.Address);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnAddress,
                                        ParmAddress);
            }

            if (WorkingItem.Address2 != null)
            {
                m_parmList.Add(ParmAddress2, WorkingItem.Address2);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnAddress2,
                                        ParmAddress2);
            }

            if (WorkingItem.City != null)
            {
                m_parmList.Add(ParmCity, WorkingItem.City);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnCity,
                                        ParmCity);
            }

            if (WorkingItem.State != null)
            {
                m_parmList.Add(ParmState, WorkingItem.State);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnState,
                                        ParmState);
            }

            if (WorkingItem.Zip != null)
            {
                m_parmList.Add(ParmZip, WorkingItem.Zip);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnZip,
                                        ParmZip);
            }

            if (WorkingItem.Country != null)
            {
                m_parmList.Add(ParmCountry, WorkingItem.Country);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        VendorMapper.DBDataColumnCountry,
                                        ParmCountry);
            }
        }
    }
}
