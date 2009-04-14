using System;
using System.Collections.ObjectModel;
using System.Data;
using Utilities;

namespace DataAccessModule
{
    public class ItemCategoriesDA : SQLServerDataConnector<ItemCategories>
    {
        public const string ParmCategoryID = "@CategoryID";
        public const string ParmVendorID = "@VendorID";
        public const string ParmItemID = "@ItemID";

        public ItemCategories WorkingItem { set; get; }
        public bool InsertUpdateData { set; get; }
        public bool GetAll { set; get; }
        private bool DoExistCheck { set; get; }
        private bool DoUpdate { set; get; }

        private ParmList m_parmList;

        protected override string CommandText
        {
            get
            {
                string cmd;

                if (GetAll)
                {
                    cmd = "Select * from ItemCategories";
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

                    cmd = String.Format("Select * from ItemCategories{0}", whereClause);
                }
                else
                {
                    if (DoUpdate)
                    {
                        cmd = String.Format("Update ItemCategories Set {0}",
                                    CreateSQLClause(false, false));
                    }
                    else
                    {
                        string cols = "", values = "";
                        CreateSQLInsert(ref cols, ref values);
                        cmd = String.Format("Insert into ItemCategories ({0}) Values ({1})",
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

        protected override MapperBase<ItemCategories> GetMapper()
        {
            MapperBase<ItemCategories> mapper = new ItemCategoriesMapper();
            return(mapper);
        }

        public override Collection<ItemCategories> Execute()
        {
            if (GetAll)
            {
                return(base.Execute());
            }

            Collection<ItemCategories> retList;
            if (InsertUpdateData)
            {
                InsertUpdateData = false;
                DoExistCheck = true;
                retList = base.Execute();
                if (retList.Count > 0)
                {
                    DoUpdate = true;
                }

                InsertUpdateData = true;
                DoExistCheck = false;
            }

            return (base.Execute());
        }

        private string CreateSQLClause(bool P_useAndSeperator, bool P_doExistCheck)
        {
            var clause = "";
            m_parmList = new ParmList();

            string seperatorStr = P_useAndSeperator ? " And" : ",";

            if (WorkingItem.CategoryID != -1)
            {
                m_parmList.Add(ParmCategoryID, WorkingItem.CategoryID);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        ItemCategoriesMapper.CategoryIDColumn,
                                            ParmCategoryID);
            }

            if (WorkingItem.VendorID != -1)
            {
                m_parmList.Add(ParmVendorID, WorkingItem.VendorID);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    ItemCategoriesMapper.VendorIDColumn,
                                                ParmVendorID);
            }

            if (WorkingItem.ItemID != null)
            {
                m_parmList.Add(ParmItemID, WorkingItem.ItemID);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    ItemCategoriesMapper.ItemIDColumn,
                                                ParmItemID);
            }

            if (P_doExistCheck)
            {
                return (clause);
            }

            return(clause);
        }

        private void CreateSQLInsert(ref string P_cols, ref string P_values)
        {
            m_parmList = new ParmList();

            if (WorkingItem.CategoryID != -1)
            {
                m_parmList.Add(ParmCategoryID, WorkingItem.CategoryID);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ItemCategoriesMapper.CategoryIDColumn,
                                        ParmCategoryID);
            }

            if (WorkingItem.VendorID != -1)
            {
                m_parmList.Add(ParmVendorID, WorkingItem.VendorID);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ItemCategoriesMapper.VendorIDColumn,
                                        ParmVendorID);
            }

            if (WorkingItem.ItemID != null)
            {
                m_parmList.Add(ParmItemID, WorkingItem.ItemID);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        ItemCategoriesMapper.ItemIDColumn,
                                        ParmItemID);
            }
        }
    }
}
