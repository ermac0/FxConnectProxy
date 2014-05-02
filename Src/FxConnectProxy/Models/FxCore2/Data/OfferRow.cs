// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxConnectProxy.Utils;

namespace FxConnectProxy
{
    public class OfferRow : BaseRow
    {
        public override RowType RowType
        {
            get { return RowType.Offer; }
        }

        public bool IsValueDateValid { get; set; }

        public string ValueDate { get; set; }

        public bool IsTradingStatusValid { get; set; }

        public InstrumentTradingStatus TradingStatus { get; set; }

        public bool IsContractMultiplierValid { get; set; }

        public double ContractMultiplier { get; set; }

        public bool IsInstrumentTypeValid { get; set; }

        public InstrumentType InstrumentType { get; set; }

        public bool IsSubscriptionStatusValid { get; set; }

        public SubscriptionStatus SubscriptionStatus { get; set; }

        public bool IsPointSizeValid { get; set; }

        public double PointSize { get; set; }

        public bool IsDigitsValid { get; set; }

        public int Digits { get; set; }

        public bool IsContractCurrencyValid { get; set; }

        public string ContractCurrency { get; set; }

        public bool IsBuyInterestValid { get; set; }

        public double BuyInterest { get; set; }

        public bool IsSellInterestValid { get; set; }

        public double SellInterest { get; set; }

        public bool IsAskTradableValid { get; set; }

        public PriceTradable AskTradable { get; set; }

        public bool IsBidTradableValid { get; set; }

        public PriceTradable BidTradable { get; set; }

        public bool IsTimeValid { get; set; }

        public System.DateTime Time { get; set; }

        public bool IsVolumeValid { get; set; }

        public int Volume { get; set; }

        public bool IsHighValid { get; set; }

        public double High { get; set; }

        public bool IsLowValid { get; set; }

        public double Low { get; set; }

        public bool IsAskValid { get; set; }

        public double Ask { get; set; }

        public bool IsBidValid { get; set; }

        public double Bid { get; set; }

        public bool IsQuoteIDValid { get; set; }

        public string QuoteID { get; set; }

        public bool IsInstrumentValid { get; set; }

        public string Instrument { get; set; }

        public bool IsOfferIDValid { get; set; }

        public string OfferID { get; set; }

        public OfferRow Clone()
        {
            return (OfferRow)this.MemberwiseClone();
        }
    }

}
