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
    public class Category
    {
        private int? id;
        private string name;
        private string imageLocation;

        public Category()
        {
        }

        public Category(int id, string name, string imageLocation)
        {
            this.id = id;
            this.name = name;
            this.imageLocation = imageLocation;
        }

        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ImageLocation
        {
            get { return imageLocation; }
            set { imageLocation = value; }
        }

         


    }
}