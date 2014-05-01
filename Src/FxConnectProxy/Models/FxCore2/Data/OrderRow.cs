// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxConnectProxy.Utils;

namespace FxConnectProxy
{
    public class OrderRow : BaseRow
    {
        public override RowType RowType
        {
            get { return RowType.Order; }
        }

        public string Parties { get; set; }

        public string ValueDate { get; set; }

        public System.DateTime ExpireDate { get; set; }

        public double PegOffset { get; set; }

        public string PegType { get; set; }

        public bool WorkingIndicator { get; set; }

        public int FilledAmount { get; set; }

        public int OriginAmount { get; set; }

        public string PrimaryID { get; set; }

        public ContingencyType ContingencyType { get; set; }

        public string ContingentOrderID { get; set; }

        public string RequestTXT { get; set; }

        public AccountKind AccountKind { get; set; }

        public TimeInForce TimeInForce { get; set; }

        public double TrailRate { get; set; }

        public int TrailStep { get; set; }

        public double AtMarket { get; set; }

        public double Lifetime { get; set; }

        public int Amount { get; set; }

        public System.DateTime StatusTime { get; set; }

        public OrderStatus Status { get; set; }

        public OrderType Type { get; set; }

        public OrderStage Stage { get; set; }

        public BuySellEnum BuySell { get; set; }

        public bool NetQuantity { get; set; }

        public string OfferID { get; set; }

        public string AccountName { get; set; }

        public string AccountID { get; set; }

        public string TradeID { get; set; }

        public double RateMax { get; set; }

        public double RateMin { get; set; }

        public double ExecutionRate { get; set; }

        public double Rate { get; set; }

        public string RequestID { get; set; }

        public string OrderID { get; set; }

        public OrderRow Clone()
        {
            return (OrderRow)this.MemberwiseClone();
        }
    }
}
