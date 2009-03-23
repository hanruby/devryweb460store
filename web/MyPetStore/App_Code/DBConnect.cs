using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DBConnect
/// </summary>
public class DBConnect
{
    private SqlConnection conn;
    private SqlCommand comm;
    private string _sConnectionString;
    private ParmList _paramList;
    
    #region Constructors
    public DBConnect()
    {
        //Default constructor.  Will need to set _sConnectionString manually in the calling class.
    }

    public DBConnect(string p_sConnectionString)
    {
        _sConnectionString = p_sConnectionString;
        conn = new SqlConnection();
        comm = new SqlCommand();
        OpenConnection();
    }

    public DBConnect(string p_sConnectionString, ParmList p_paramList)
    {
       _sConnectionString = p_sConnectionString;
        conn = new SqlConnection();
        comm = new SqlCommand();

        _paramList = p_paramList;


        if (_paramList.Items.Count > 0)
        {
            // add paramaters
            foreach (ParmObject obj in _paramList.Items)
            {
                comm.Parameters.AddWithValue(obj.ParmName, obj.ParmObj);
            }
        }


        OpenConnection();
    }
    #endregion

    #region Methods
    public void OpenConnection()
    {
        conn.ConnectionString = _sConnectionString;
        conn.Open();
        comm.Connection = conn;
    }

    public void ExecSQL(string sSQL)
    {
        comm.CommandText = sSQL;
        comm.ExecuteNonQuery();
    }

    public SqlDataReader GetDR(string sSQL)
    {
        comm.CommandText = sSQL;
        return comm.ExecuteReader();       
    }

    public void Close()
    {
        comm.Dispose();
        conn.Close();
        conn.Dispose();
    }

    #endregion

    
    #region Properties
    public string ConnectionString
    {
        get { return _sConnectionString; }
        set { _sConnectionString = value; }
    }

    
    #endregion
}
