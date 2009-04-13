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
    public class OrderItem
    {
        private int? orderId;
        private Order order; //foreign table

        private string itemId;
        private Item item; //foreign table

        private int? vendorId;
        private Vendor vendor; //foreign table

        private decimal? price;
        private decimal? totalPrice;
        private int? quantity;

        public OrderItem()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public OrderItem(int orderId, string itemId, int vendorId, decimal price, decimal totalPrice, int quantity)
        {
            this.orderId = orderId;
            this.itemId = itemId;
            this.vendorId = vendorId;
            this.price = price;
            this.totalPrice = totalPrice;
            this.quantity = quantity;
        }

        public int? OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public string ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public int? VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        public decimal? Price
        {
            get { return price; }
            set { price = value; }
        }

        public decimal? TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public int? Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Order Order
        {
            get { return order; }
            set { order = value; }
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