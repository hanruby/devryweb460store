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
    /// Summary description for ImportProfileMapper
    /// </summary>
    public class ImportProfileMapper : MapperBase<ImportProfile>
    {
        public override ImportProfile Map(DbDataRecord record)
        {

            //all fields are null on construction
            var importProfile = new ImportProfile();

            //check each column in the record and set a value if not null

            //Id
            if (record[ImportProfileTable.IdColumn] != DBNull.Value)
                importProfile.Id = (int)record[ImportProfileTable.IdColumn];

            //VendorId
            if (record[ImportProfileTable.VendorIdColumn] != DBNull.Value)
                importProfile.VendorId = (int?)record[ImportProfileTable.VendorIdColumn];

            //FtpServer
            if (record[ImportProfileTable.FtpServerColumn] != DBNull.Value)
                importProfile.FtpServer = (string)record[ImportProfileTable.FtpServerColumn];

            //FtpUsername
            if (record[ImportProfileTable.FtpUsernameColumn] != DBNull.Value)
                importProfile.FtpUsername = (string)record[ImportProfileTable.FtpUsernameColumn];

            //FtpPassword
            if (record[ImportProfileTable.FtpPasswordColumn] != DBNull.Value)
                importProfile.FtpPassword = (string)record[ImportProfileTable.FtpPasswordColumn];

            //FtpPath
            if (record[ImportProfileTable.FtpPathColumn] != DBNull.Value)
                importProfile.FtpPath = (string)record[ImportProfileTable.FtpPathColumn];

            //Filename
            if (record[ImportProfileTable.FilenameColumn] != DBNull.Value)
                importProfile.FileName = (string)record[ImportProfileTable.FilenameColumn];

            //Delimiter
            if (record[ImportProfileTable.DelimiterColumn] != DBNull.Value)
                importProfile.Delimiter = (string)record[ImportProfileTable.DelimiterColumn];

            return importProfile;
        }
    }
}
