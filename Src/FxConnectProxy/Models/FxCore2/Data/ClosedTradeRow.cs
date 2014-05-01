using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxConnectProxy.Utils;

namespace FxConnectProxy
{
    public class ClosedTradeRow : BaseRow
    {
        public override RowType RowType
        {
            get { return RowType.ClosedTrade; }
        }

        public string ValueDate { get; set; }

        public string TradeIDRemain { get; set; }

        public string TradeIDOrigin { get; set; }

        public string CloseOrderParties { get; set; }

        public string CloseOrderRequestTXT { get; set; }

        public string CloseOrderReqID { get; set; }

        public string CloseOrderID { get; set; }

        public System.DateTime CloseTime { get; set; }

        public string CloseQuoteID { get; set; }

        public double CloseRate { get; set; }

        public string OpenOrderParties { get; set; }

        public string OpenOrderRequestTXT { get; set; }

        public string OpenOrderReqID { get; set; }

        public string OpenOrderID { get; set; }

        public System.DateTime OpenTime { get; set; }

        public string OpenQuoteID { get; set; }

        public double OpenRate { get; set; }

        public double RolloverInterest { get; set; }

        public double Commission { get; set; }

        public double GrossPL { get; set; }

        public BuySellEnum BuySell { get; set; }

        public int Amount { get; set; }

        public string OfferID { get; set; }

        public AccountKind AccountKind { get; set; }

        public string AccountName { get; set; }

        public string AccountID { get; set; }

        public string TradeID { get; set; }

        public ClosedTradeRow Clone()
        {
            return (ClosedTradeRow)this.MemberwiseClone();
        }
    }
}
