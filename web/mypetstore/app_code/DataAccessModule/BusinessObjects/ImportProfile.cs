﻿using System;
using System.Data;
using System.Configuration;
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
    public class ImportProfile
    {
        private int? id;
        
        private int? vendorId;
        private Vendor vendor;//foreign table

        private string ftpServer;
        private string ftpUsername;
        private string ftpPassword;
        private string ftpPath;
        
        private string fileName;
        private string delimiter;

        public ImportProfile()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ImportProfile(int id, int vendorId, string ftpServer, string ftpUsername, string ftpPassword, string ftpPath, string fileName, string delimiter)
        {
            this.id = id;
            this.vendorId = vendorId;
            this.ftpServer = ftpServer;
            this.ftpUsername = ftpUsername;
            this.ftpPassword = ftpPassword;
            this.ftpPath = ftpPath;
            this.fileName = fileName;
            this.delimiter = delimiter;
        }

        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        public int? VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        public string FtpServer
        {
            get { return ftpServer; }
            set { ftpServer = value; }
        }

        public string FtpUsername
        {
            get { return ftpUsername; }
            set { ftpUsername = value; }
        }

        public string FtpPassword
        {
            get { return ftpPassword; }
            set { ftpPassword = value; }
        }

        public string FtpPath
        {
            get { return ftpPath; }
            set { ftpPath = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string Delimiter
        {
            get { return delimiter; }
            set { delimiter = value; }
        }

        public Vendor Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }
    }
}
