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
    public class Order
    {
        private int? id;
        private int? customerId;
        private decimal? grossTotal;
        private decimal? tax;
        private decimal? netTotal;
        private int? txnId; //wtf is this field?


        public Order()
        {
        }

        public Order(int id, int customerId, decimal grossTotal, decimal tax, decimal netTotal, int txnId)
        {
            this.id = id;
            this.customerId = customerId;
            this.grossTotal = grossTotal;
            this.tax = tax;
            this.netTotal = netTotal;
            this.txnId = txnId;
        }


        public int? Id
        {
            get { return id; }
            set { id = value; }
        }

        public int? CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public decimal? GrossTotal
        {
            get { return grossTotal; }
            set { grossTotal = value; }
        }

        public decimal? Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        public decimal? NetTotal
        {
            get { return netTotal; }
            set { netTotal = value; }
        }

        public int? TxnId
        {
            get { return txnId; }
            set { txnId = value; }
        }
    }
}