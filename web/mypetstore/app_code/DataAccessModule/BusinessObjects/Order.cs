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
        private Customer customer; //foreign table

        private decimal? grossTotal;
        private decimal? tax;
        private decimal? netTotal;
        private string txnId;
        private DateTime? date;


        public Order()
        {
        }

        public Order(int id, int customerId, decimal grossTotal, decimal tax, decimal netTotal, string txnId, DateTime date)
        {
            this.id = id;
            this.customerId = customerId;
            this.grossTotal = grossTotal;
            this.tax = tax;
            this.netTotal = netTotal;
            this.txnId = txnId;
            this.date = date;
        }

        #region Properties
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

        public string TxnId
        {
            get { return txnId; }
            set { txnId = value; }
        }

        public DateTime? Date
        {
            get { return date; }
            set { date = value; }
        }
    }
        #endregion
}