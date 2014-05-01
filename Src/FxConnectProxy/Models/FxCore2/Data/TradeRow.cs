// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxConnectProxy.Utils;

namespace FxConnectProxy
{
    public class TradeRow : BaseRow
    {
        public override RowType RowType
        {
            get { return RowType.Trade; }
        }

        public string Parties { get; set; }

        public string ValueDate { get; set; }

        public double UsedMargin { get; set; }

        public string TradeIDOrigin { get; set; }

        public double RolloverInterest { get; set; }

        public double Commission { get; set; }

        public string OpenOrderRequestTXT { get; set; }

        public string OpenOrderReqID { get; set; }

        public string OpenOrderID { get; set; }

        public string OpenQuoteID { get; set; }

        public System.DateTime OpenTime { get; set; }

        public double OpenRate { get; set; }

        public BuySellEnum BuySell { get; set; }

        public int Amount { get; set; }

        public string OfferID { get; set; }

        public AccountKind AccountKind { get; set; }

        public string AccountName { get; set; }

        public string AccountID { get; set; }

        public string TradeID { get; set; }

        public TradeRow Clone()
        {
            return (TradeRow)this.MemberwiseClone();
        }
    }
}
