// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fxcore2;
using FxConnectProxy.Utils;

namespace FxConnectProxy.ForexConnect.Utils
{
    static class Mappings
    {
        public static void RegisterMappings(ObjectMapper mapper)
        {
            mapper.AddMapping<O2GAccountRow, AccountRowEx>((Action<O2GAccountRow, AccountRowEx, ObjectMapper>)((from, to, m) =>
            {
                to._FxAccountRow = from;

                to.LeverageProfileID = from.LeverageProfileID;
                to.ManagerAccountID = from.ManagerAccountID;
                to.MaintenanceFlag = from.MaintenanceFlag;
                to.BaseUnitSize = from.BaseUnitSize;
                to.AmountLimit = from.AmountLimit;
                to.MaintenanceType = Converters.GetAccountMaintenanceType(from.MaintenanceType);
                to.LastMarginCallDate = from.LastMarginCallDate;
                to.MarginCallFlag = from.MarginCallFlag;
                to.UsedMargin3 = from.UsedMargin3;
                to.UsedMargin = from.UsedMargin;
                to.M2MEquity = from.M2MEquity;
                to.NonTradeEquity = from.NonTradeEquity;
                to.Balance = from.Balance;
                to.AccountKind = Converters.GetAccountKind(from.AccountKind);
                to.AccountName = from.AccountName;
                to.AccountID = from.AccountID;
            }));


            mapper.AddMapping<O2GAccountTableRow, AccountTableRowEx>((Action<O2GAccountTableRow, AccountTableRowEx, ObjectMapper>)((from, to, m) =>
            {
                to._FxAccountRow = from;

                to.GrossPL = from.GrossPL;
                to.UsableMargin = from.UsableMargin;
                to.DayPL = from.DayPL;
                to.Equity = from.Equity;
                to.LeverageProfileID = from.LeverageProfileID; 
                to.ManagerAccountID = from.ManagerAccountID;
                to.MaintenanceFlag = from.MaintenanceFlag;
                to.BaseUnitSize = from.BaseUnitSize;
                to.AmountLimit = from.AmountLimit;
                to.MaintenanceType = Converters.GetAccountMaintenanceType(from.MaintenanceType);
                to.LastMarginCallDate = from.LastMarginCallDate;
                to.MarginCallFlag = from.MarginCallFlag;
                to.UsedMargin3 = from.UsedMargin3;
                to.UsedMargin = from.UsedMargin;
                to.M2MEquity = from.M2MEquity;
                to.NonTradeEquity = from.NonTradeEquity;
                to.Balance = from.Balance;
                to.AccountKind = Converters.GetAccountKind(from.AccountKind);
                to.AccountName = from.AccountName;
                to.AccountID = from.AccountID;
            }));


            mapper.AddMapping<O2GClosedTradeRow, ClosedTradeRow>((Action<O2GClosedTradeRow, ClosedTradeRow, ObjectMapper>)((from, to, m) =>
            {
                to.ValueDate = from.ValueDate;
                to.TradeIDRemain = from.TradeIDRemain;
                to.TradeIDOrigin = from.TradeIDOrigin;
                to.CloseOrderParties = from.CloseOrderParties;
                to.CloseOrderRequestTXT = from.CloseOrderRequestTXT;
                to.CloseOrderReqID = from.CloseOrderReqID;
                to.CloseOrderID = from.CloseOrderID;
                to.CloseTime = from.CloseTime;
                to.CloseQuoteID = from.CloseQuoteID;
                to.CloseRate = from.CloseRate;
                to.OpenOrderParties = from.OpenOrderParties;
                to.OpenOrderRequestTXT = from.OpenOrderRequestTXT;
                to.OpenOrderReqID = from.OpenOrderReqID;
                to.OpenOrderID = from.OpenOrderID;
                to.OpenTime = from.OpenTime;
                to.OpenQuoteID = from.OpenQuoteID;
                to.OpenRate = from.OpenRate;
                to.RolloverInterest = from.RolloverInterest;
                to.Commission = from.Commission;
                to.GrossPL = from.GrossPL;
                to.BuySell = Converters.GetBuySell(from.BuySell);
                to.Amount = from.Amount;
                to.OfferID = from.OfferID;
                to.AccountKind = Converters.GetAccountKind(from.AccountKind);
                to.AccountName = from.AccountName;
                to.AccountID = from.AccountID;
                to.TradeID = from.TradeID;
            }));

            mapper.AddMapping<O2GMessageRow, MessageRow>((Action<O2GMessageRow, MessageRow, ObjectMapper>)((from, to, m) =>
            {
                to.HTMLFragmentFlag = from.HTMLFragmentFlag;
                to.Subject = from.Subject;
                to.Text = from.Text;
                to.Feature = Converters.GetMessaageFeature(from.Feature);
                to.Type = Converters.GetMessageType(from.Type);
                to.From = from.From;
                to.Time = from.Time;
                to.MsgID = from.MsgID;
            }));


            mapper.AddMapping<O2GMessageTableRow, MessageTableRow>((Action<O2GMessageTableRow, MessageTableRow, ObjectMapper>)((from, to, m) =>
            {
                to.HTMLFragmentFlag = from.HTMLFragmentFlag;
                to.Subject = from.Subject;
                to.Text = from.Text;
                to.Feature = Converters.GetMessaageFeature(from.Feature);
                to.Type = Converters.GetMessageType(from.Type);
                to.From = from.From;
                to.Time = from.Time;
                to.MsgID = from.MsgID;
            }));


            mapper.AddMapping<O2GOfferRow, OfferRow>((Action<O2GOfferRow, OfferRow, ObjectMapper>)((from, to, m) =>
            {
                to.IsValueDateValid = from.isValueDateValid;
                to.ValueDate = from.ValueDate;
                to.IsTradingStatusValid = from.isTradingStatusValid;
                to.TradingStatus = from.isTradingStatusValid ? Converters.GetInstrumentTradingStatus(from.TradingStatus) : InstrumentTradingStatus.Closed;
                to.IsContractMultiplierValid = from.isContractMultiplierValid;
                to.ContractMultiplier = from.ContractMultiplier;
                to.IsInstrumentTypeValid = from.isInstrumentTypeValid;
                to.InstrumentType = from.isInstrumentTypeValid ? Converters.GetInstrumentType(from.InstrumentType) : InstrumentType.Forex;
                to.IsSubscriptionStatusValid = from.isSubscriptionStatusValid;
                to.SubscriptionStatus = from.isSubscriptionStatusValid ? Converters.GetSubscriptionStatus(from.SubscriptionStatus) : SubscriptionStatus.NotAvailable;
                to.IsPointSizeValid = from.isPointSizeValid;
                to.PointSize = from.PointSize;
                to.IsDigitsValid = from.isDigitsValid;
                to.Digits = from.Digits;
                to.IsContractCurrencyValid = from.isContractCurrencyValid;
                to.ContractCurrency = from.ContractCurrency;
                to.IsBuyInterestValid = from.isBuyInterestValid;
                to.BuyInterest = from.BuyInterest;
                to.IsSellInterestValid = from.isSellInterestValid;
                to.SellInterest = from.SellInterest;
                to.IsAskTradableValid = from.isAskTradableValid;
                to.AskTradable = from.isAskTradableValid ? Converters.GetPriceTradable(from.AskTradable) : PriceTradable.NotTradable;
                to.IsBidTradableValid = from.isBidTradableValid;
                to.BidTradable = from.isBidTradableValid ? Converters.GetPriceTradable(from.BidTradable) : PriceTradable.NotTradable;
                to.IsTimeValid = from.isTimeValid;
                to.Time = from.Time;
                to.IsVolumeValid = from.isVolumeValid;
                to.Volume = from.Volume;
                to.IsHighValid = from.isHighValid;
                to.High = from.High;
                to.IsLowValid = from.isLowValid;
                to.Low = from.Low;
                to.IsAskValid = from.isAskValid;
                to.Ask = from.Ask;
                to.IsBidValid = from.isBidValid;
                to.Bid = from.Bid;
                to.IsQuoteIDValid = from.isQuoteIDValid;
                to.QuoteID = from.QuoteID;
                to.IsInstrumentValid = from.isInstrumentValid;
                to.Instrument = from.Instrument;
                to.IsOfferIDValid = from.isOfferIDValid;
                to.OfferID = from.OfferID;
            }));


            mapper.AddMapping<O2GOfferTableRow, OfferTableRow>((Action<O2GOfferTableRow, OfferTableRow, ObjectMapper>)((from, to, m) =>
            {
                to.PipCost = from.PipCost;
                to.IsValueDateValid = from.isValueDateValid;
                to.ValueDate = from.ValueDate;
                to.IsTradingStatusValid = from.isTradingStatusValid;
                to.TradingStatus = from.isTradingStatusValid ? Converters.GetInstrumentTradingStatus(from.TradingStatus) : InstrumentTradingStatus.Closed;
                to.IsContractMultiplierValid = from.isContractMultiplierValid;
                to.ContractMultiplier = from.ContractMultiplier;
                to.IsInstrumentTypeValid = from.isInstrumentTypeValid;
                to.InstrumentType = from.isInstrumentTypeValid ? Converters.GetInstrumentType(from.InstrumentType) : InstrumentType.Forex;
                to.IsSubscriptionStatusValid = from.isSubscriptionStatusValid;
                to.SubscriptionStatus = from.isSubscriptionStatusValid ? Converters.GetSubscriptionStatus(from.SubscriptionStatus) : SubscriptionStatus.NotAvailable;
                to.IsPointSizeValid = from.isPointSizeValid;
                to.PointSize = from.PointSize;
                to.IsDigitsValid = from.isDigitsValid;
                to.Digits = from.Digits;
                to.IsContractCurrencyValid = from.isContractCurrencyValid;
                to.ContractCurrency = from.ContractCurrency;
                to.IsBuyInterestValid = from.isBuyInterestValid;
                to.BuyInterest = from.BuyInterest;
                to.IsSellInterestValid = from.isSellInterestValid;
                to.SellInterest = from.SellInterest;
                to.IsAskTradableValid = from.isAskTradableValid;
                to.AskTradable = from.isAskTradableValid ? Converters.GetPriceTradable(from.AskTradable) : PriceTradable.NotTradable;
                to.IsBidTradableValid = from.isBidTradableValid;
                to.BidTradable = from.isBidTradableValid ? Converters.GetPriceTradable(from.BidTradable) : PriceTradable.NotTradable;
                to.IsTimeValid = from.isTimeValid;
                to.Time = from.Time;
                to.IsVolumeValid = from.isVolumeValid;
                to.Volume = from.Volume;
                to.IsHighValid = from.isHighValid;
                to.High = from.High;
                to.IsLowValid = from.isLowValid;
                to.Low = from.Low;
                to.IsAskValid = from.isAskValid;
                to.Ask = from.Ask;
                to.IsBidValid = from.isBidValid;
                to.Bid = from.Bid;
                to.IsQuoteIDValid = from.isQuoteIDValid;
                to.QuoteID = from.QuoteID;
                to.IsInstrumentValid = from.isInstrumentValid;
                to.Instrument = from.Instrument;
                to.IsOfferIDValid = from.isOfferIDValid;
                to.OfferID = from.OfferID;
            }));


            mapper.AddMapping<O2GOrderRow, OrderRow>((Action<O2GOrderRow, OrderRow, ObjectMapper>)((from, to, m) =>
            {
                to.Parties = from.Parties;
                to.ValueDate = from.ValueDate;
                to.ExpireDate = from.ExpireDate;
                to.PegOffset = from.PegOffset;
                to.PegType = from.PegType;
                to.WorkingIndicator = from.WorkingIndicator;
                to.FilledAmount = from.FilledAmount;
                to.OriginAmount = from.OriginAmount;
                to.PrimaryID = from.PrimaryID;
                to.ContingencyType = Converters.GetContingencyType(from.ContingencyType);
                to.ContingentOrderID = from.ContingentOrderID;
                to.RequestTXT = from.RequestTXT;
                to.AccountKind = Converters.GetAccountKind(from.AccountKind);
                to.TimeInForce = Converters.GetTimeInForce(from.TimeInForce);
                to.TrailRate = from.TrailRate;
                to.TrailStep = from.TrailStep;
                to.AtMarket = from.AtMarket;
                to.Lifetime = from.Lifetime;
                to.Amount = from.Amount;
                to.StatusTime = from.StatusTime;
                to.Status = Converters.GetOrderStatus(from.Status);
                to.Type = Converters.GetOrderType(from.Type);
                to.Stage = Converters.GetOrderStage(from.Stage);
                to.BuySell = Converters.GetBuySell(from.BuySell);
                to.NetQuantity = from.NetQuantity;
                to.OfferID = from.OfferID;
                to.AccountName = from.AccountName;
                to.AccountID = from.AccountID;
                to.TradeID = from.TradeID;
                to.RateMax = from.RateMax;
                to.RateMin = from.RateMin;
                to.ExecutionRate = from.ExecutionRate;
                to.Rate = from.Rate;
                to.RequestID = from.RequestID;
                to.OrderID = from.OrderID;
            }));


            mapper.AddMapping<O2GOrderTableRow, OrderTableRow>((Action<O2GOrderTableRow, OrderTableRow, ObjectMapper>)((from, to, m) =>
            {
                to.StopTrailRate = from.StopTrailRate;
                to.StopTrailStep = from.StopTrailStep;
                to.Limit = from.Limit;
                to.Stop = from.Stop;
                to.Parties = from.Parties;
                to.ValueDate = from.ValueDate;
                to.ExpireDate = from.ExpireDate;
                to.PegOffset = from.PegOffset;
                to.PegType = from.PegType;
                to.WorkingIndicator = from.WorkingIndicator;
                to.FilledAmount = from.FilledAmount;
                to.OriginAmount = from.OriginAmount;
                to.PrimaryID = from.PrimaryID;
                to.ContingencyType = Converters.GetContingencyType(from.ContingencyType);
                to.ContingentOrderID = from.ContingentOrderID;
                to.RequestTXT = from.RequestTXT;
                to.AccountKind = Converters.GetAccountKind(from.AccountKind);
                to.TimeInForce = Converters.GetTimeInForce(from.TimeInForce);
                to.TrailRate = from.TrailRate;
                to.TrailStep = from.TrailStep;
                to.AtMarket = from.AtMarket;
                to.Lifetime = from.Lifetime;
                to.Amount = from.Amount;
                to.StatusTime = from.StatusTime;
                to.Status = Converters.GetOrderStatus(from.Status);
                to.Type = Converters.GetOrderType(from.Type);
                to.Stage = Converters.GetOrderStage(from.Stage);
                to.BuySell = Converters.GetBuySell(from.BuySell);
                to.NetQuantity = from.NetQuantity;
                to.OfferID = from.OfferID;
                to.AccountName = from.AccountName;
                to.AccountID = from.AccountID;
                to.TradeID = from.TradeID;
                to.RateMax = from.RateMax;
                to.RateMin = from.RateMin;
                to.ExecutionRate = from.ExecutionRate;
                to.Rate = from.Rate;
                to.RequestID = from.RequestID;
                to.OrderID = from.OrderID;
            }));


            mapper.AddMapping<O2GSummaryRow, SummaryRow>((Action<O2GSummaryRow, SummaryRow, ObjectMapper>)((from, to, m) =>
            {
            }));


            mapper.AddMapping<O2GSummaryTableRow, SummaryTableRow>((Action<O2GSummaryTableRow, SummaryTableRow, ObjectMapper>)((from, to, m) =>
            {
                to.NetPL = from.NetPL;
                to.GrossPL = from.GrossPL;
                to.Amount = from.Amount;
                to.BuyNetPL = from.BuyNetPL;
                to.BuyAmount = from.BuyAmount;
                to.BuyAvgOpen = from.BuyAvgOpen;
                to.SellClose = from.SellClose;
                to.BuyClose = from.BuyClose;
                to.SellAvgOpen = from.SellAvgOpen;
                to.SellAmount = from.SellAmount;
                to.SellNetPL = from.SellNetPL;
                to.Instrument = from.Instrument;
                to.DefaultSortOrder = from.DefaultSortOrder;
                to.OfferID = from.OfferID;
            }));


            mapper.AddMapping<O2GTradeRow, TradeRow>((Action<O2GTradeRow, TradeRow, ObjectMapper>)((from, to, m) =>
            {
                to.Parties = from.Parties;
                to.ValueDate = from.ValueDate;
                to.UsedMargin = from.UsedMargin;
                to.TradeIDOrigin = from.TradeIDOrigin;
                to.RolloverInterest = from.RolloverInterest;
                to.Commission = from.Commission;
                to.OpenOrderRequestTXT = from.OpenOrderRequestTXT;
                to.OpenOrderReqID = from.OpenOrderReqID;
                to.OpenOrderID = from.OpenOrderID;
                to.OpenQuoteID = from.OpenQuoteID;
                to.OpenTime = from.OpenTime;
                to.OpenRate = from.OpenRate;
                to.BuySell = Converters.GetBuySell(from.BuySell);
                to.Amount = from.Amount;
                to.OfferID = from.OfferID;
                to.AccountKind = Converters.GetAccountKind(from.AccountKind);
                to.AccountName = from.AccountName;
                to.AccountID = from.AccountID;
                to.TradeID = from.TradeID;
            }));


            mapper.AddMapping<O2GTradeTableRow, TradeTableRow>((Action<O2GTradeTableRow, TradeTableRow, ObjectMapper>)((from, to, m) =>
            {
                to.Limit = from.Limit;
                to.Stop = from.Stop;
                to.Close = from.Close;
                to.GrossPL = from.GrossPL;
                to.PL = from.PL;
                to.Parties = from.Parties;
                to.ValueDate = from.ValueDate;
                to.UsedMargin = from.UsedMargin;
                to.TradeIDOrigin = from.TradeIDOrigin;
                to.RolloverInterest = from.RolloverInterest;
                to.Commission = from.Commission;
                to.OpenOrderRequestTXT = from.OpenOrderRequestTXT;
                to.OpenOrderReqID = from.OpenOrderReqID;
                to.OpenOrderID = from.OpenOrderID;
                to.OpenQuoteID = from.OpenQuoteID;
                to.OpenTime = from.OpenTime;
                to.OpenRate = from.OpenRate;
                to.BuySell = Converters.GetBuySell(from.BuySell);
                to.Amount = from.Amount;
                to.OfferID = from.OfferID;
                to.AccountKind = Converters.GetAccountKind(from.AccountKind);
                to.AccountName = from.AccountName;
                to.AccountID = from.AccountID;
                to.TradeID = from.TradeID;
            }));
        }
    }
}
