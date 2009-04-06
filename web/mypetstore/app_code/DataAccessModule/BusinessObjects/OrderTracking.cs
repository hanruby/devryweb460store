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
    public class OrderTracking
    {
        private int? id;
        private int? orderId;
        private int? itemId;
        private int? vendorId;
        private DateTime? shipDate;
        private DateTime? estimatedArrival;
        private string url;

        public OrderTracking()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public OrderTracking(int id, int orderId, int itemId, int vendorId, DateTime shipDate, DateTime estimatedArrival, string url)
        {
            this.id = id;
            this.orderId = orderId;
            this.itemId = itemId;
            this.vendorId = vendorId;
            this.shipDate = shipDate;
            this.estimatedArrival = estimatedArrival;
            this.url = url;
        }

        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        public int? OrderId
        {
            get { return orderId; }
            set { orderId = value; }
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

        public DateTime? ShipDate
        {
            get { return shipDate; }
            set { shipDate = value; }
        }

        public DateTime? EstimatedArrival
        {
            get { return estimatedArrival; }
            set { estimatedArrival = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
    }
}