using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using Utilities;

namespace DataAccessModule
{
    public class CategoryDA : SQLServerDataConnector<Category>
    {
        public const string ParmCategoryID = "@CategoryID";
        public const string ParmName = "@Name";
        public const string ParmPicture = "@Picture";

        public Category WorkingItem { set; get; }
        public bool InsertUpdateData { set; get; }
        public bool GetAll { set; get; }
        private bool DoUpdate { set; get; }
        public bool DoExistCheck { set; get; }
        private bool GetMaxID { set; get; }

        private ParmList m_parmList;

        protected override string CommandText
        {
            get
            {
                string cmd;
                string whereClause;

                if (GetAll)
                {
                    cmd = "Select * from Categories";
                }
                else if (!InsertUpdateData)
                {
                    whereClause = DoExistCheck ?
                                        CreateSQLClause(true, true, false) :
                                        CreateSQLClause(true, false, false);

                    if (whereClause != "")
                    {
                        whereClause = String.Format(" Where {0}", whereClause);
                    }

                    cmd = String.Format("Select * from Categories{0}", whereClause);
                }
                else
                {
                    if (DoUpdate)
                    {
                        whereClause = CreateSQLClause(true, false, true);
                        cmd = String.Format("Update Categories Set {0} Where {1}",
                                    CreateSQLClause(false, false, false),
                                    whereClause);
                    }
                    else
                    {
                        if (!GetMaxID)
                        {
                            cmd = String.Format("Select MAX(CategoryID) as CategoryID from Categories");
                            GetMaxID = true;
                        }
                        else
                        {
                            string cols = "", values = "";
                            CreateSQLInsert(ref cols, ref values);
                            cmd = String.Format("Insert into Categories ({0}) Values ({1})",
                                                                    cols, values);
                        }
                    }
                }

                string msg = String.Format("Category DA: cmd \"{0}\"", cmd);
                SystemDebug.Log((int)TraceLevel.Verbose, msg);

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

            string msg = String.Format("Category DA: Arg:");
            SystemDebug.Log((int)TraceLevel.Verbose, msg);

            IDataParameter param;
            foreach (ParmObject obj in m_parmList.Items)
            {
                param = command.CreateParameter();
                param.ParameterName = obj.ParmName;
                param.Value = obj.ParmObj;
                msg = String.Format("   Name: \"{0}\", Value: {1}",
                                                obj.ParmName, obj.ParmObj);
                SystemDebug.Log((int)TraceLevel.Verbose, msg);
                collection.Add(param);
            }

            msg = String.Format("Category DA: Arg Complete");
            SystemDebug.Log((int)TraceLevel.Verbose, msg);
            return (collection);
        }

        protected override MapperBase<Category> GetMapper()
        {
            MapperBase<Category> mapper = new CategoryMapper();
            return(mapper);
        }

        public override Collection<Category> Execute()
        {
            if (GetAll)
            {
                return(base.Execute());
            }

            Collection<Category> retList;
            if (InsertUpdateData)
            {
                InsertUpdateData = false;
                DoExistCheck = true;
                retList = base.Execute();
                if (retList.Count > 0)
                {
                    DoUpdate = true;
                    WorkingItem.CategoryID = retList[0].CategoryID;
                }

                InsertUpdateData = true;
                DoExistCheck = false;
            }

            retList = base.Execute();
            if (GetMaxID)
            {
                WorkingItem.CategoryID = ++ retList[0].CategoryID;
                retList = base.Execute();
            }

            return (retList);
        }

        private string CreateSQLClause(bool P_useAndSeperator,
                bool P_doExistCheck, bool P_doUpdate)
        {
            string seperatorStr = P_useAndSeperator ? " And" : ",";
            var clause = "";
            m_parmList = new ParmList();

            if (P_doExistCheck)
            {
                m_parmList.Add(ParmName, WorkingItem.Name);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    CategoryMapper.CategoryNameColumn,
                                                ParmName);
                return (clause);
            }

            if (P_doUpdate)
            {
                if (WorkingItem.CategoryID != -1)
                {
                    m_parmList.Add(ParmCategoryID, WorkingItem.CategoryID);
                    Utils.AddToSQLClause(ref clause, seperatorStr,
                                            CategoryMapper.CategoryIDColumn,
                                                ParmCategoryID);
                }
                return (clause);
            }

            if (WorkingItem.Name != null)
            {
                m_parmList.Add(ParmName, WorkingItem.Name);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    CategoryMapper.CategoryNameColumn,
                                                ParmName);
            }

            if (WorkingItem.CategoryID != -1)
            {
                m_parmList.Add(ParmCategoryID, WorkingItem.CategoryID);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                        CategoryMapper.CategoryIDColumn,
                                            ParmCategoryID);
            }

            if (WorkingItem.Picture != null)
            {
                m_parmList.Add(ParmPicture, WorkingItem.Picture);
                Utils.AddToSQLClause(ref clause, seperatorStr,
                                    CategoryMapper.CategoryPhotoColumn,
                                                ParmPicture);
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
                                        CategoryMapper.CategoryIDColumn,
                                        ParmCategoryID);
            }

            if (WorkingItem.Name != null)
            {
                m_parmList.Add(ParmName, WorkingItem.Name);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        CategoryMapper.CategoryNameColumn,
                                        ParmName);
            }

            if (WorkingItem.Picture != null)
            {
                m_parmList.Add(ParmPicture, WorkingItem.Picture);
                Utils.AddToSQLInsertStrings(ref P_cols, ref P_values,
                                        CategoryMapper.CategoryPhotoColumn,
                                        ParmPicture);
            }
        }
    }
}
