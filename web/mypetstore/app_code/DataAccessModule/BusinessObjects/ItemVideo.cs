using System;
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
    public class ItemVideo
    {
        private int? id;
        
        private int? itemId;
        private Item item; //foreign table

        private int? vendorId;
        private Vendor vendor; //foreign table

        private string videoName;
        private string description;
        private string url;
        private string source; //difference between this and link column?



        public ItemVideo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public ItemVideo(int id, int itemId, int vendorId, string videoName, string description, string url, string source)
        {
            this.id = id;
            this.itemId = itemId;
            this.vendorId = vendorId;
            this.videoName = videoName;
            this.description = description;
            this.url = url;
            this.source = source;
        }

        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        public int? ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public int? VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        public string VideoName
        {
            get { return videoName; }
            set { videoName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }

        public Vendor Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }
    }
}