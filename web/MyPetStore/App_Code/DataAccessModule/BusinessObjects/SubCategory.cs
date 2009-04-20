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
    public class SubCategory : Category
    {
        private Category parentCategory;

        public SubCategory()
        {
        }

        public SubCategory(int? id, string name, string imageLocation, Category parentCategory) : base(id, name, imageLocation)
        {
            this.parentCategory = parentCategory;
        }

        public Category ParentCategory
        {
            get { return parentCategory; }
            set { parentCategory = value; }
        }
    }
}