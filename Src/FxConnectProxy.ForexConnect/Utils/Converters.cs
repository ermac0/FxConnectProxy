// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.ForexConnect.Utils
{
    public abstract class Converters
    {
        public static AccountMaintenanceType GetAccountMaintenanceType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("value");
            }

            value = value.ToUpper();
            switch (value)
            {
                case Constants.AccountMaintenanceType.Hedging:
                    return AccountMaintenanceType.Hedging;

                case Constants.AccountMaintenanceType.NoHedging:
                    return AccountMaintenanceType.NoHedging;

                case Constants.AccountMaintenanceType.Netting:
                    return AccountMaintenanceType.Netting;

                case Constants.AccountMaintenanceType.DayNetting:
                    return AccountMaintenanceType.DayNetting;

                case Constants.AccountMaintenanceType.FIFO:
                    return AccountMaintenanceType.FIFO;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetAccountMaintenanceType(AccountMaintenanceType value)
        {
            switch (value)
            {
                case AccountMaintenanceType.DayNetting:
                    return Constants.AccountMaintenanceType.DayNetting;

                case AccountMaintenanceType.FIFO:
                    return Constants.AccountMaintenanceType.FIFO;

                case AccountMaintenanceType.Hedging:
                    return Constants.AccountMaintenanceType.Hedging;

                case AccountMaintenanceType.Netting:
                    return Constants.AccountMaintenanceType.Netting;

                case AccountMaintenanceType.NoHedging:
                    return Constants.AccountMaintenanceType.NoHedging;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static AccountKind GetAccountKind(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("value");
            }

            value = value.ToUpper();
            switch (value)
            {
                case Constants.AccountType.FundsManager:
                    return AccountKind.FundsManagerAccount;

                case Constants.AccountType.Managed:
                    return AccountKind.ManagedAccount;

                case Constants.AccountType.SelfTraded:
                    return AccountKind.SelfTradedAccount;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetAccountKind(AccountKind value)
        {
            switch (value)
            {
                case AccountKind.FundsManagerAccount:
                    return Constants.AccountType.FundsManager;

                case AccountKind.ManagedAccount:
                    return Constants.AccountType.Managed;

                case AccountKind.SelfTradedAccount:
                    return Constants.AccountType.SelfTraded;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static BuySellEnum GetBuySell(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("value");
            }

            value = value.ToUpper();
            switch (value)
            {
                case fxcore2.Constants.Buy:
                    return BuySellEnum.Buy;

                case fxcore2.Constants.Sell:
                    return BuySellEnum.Sell;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetBuySell(BuySellEnum value)
        {
            switch (value)
            {
                case BuySellEnum.Buy:
                    return fxcore2.Constants.Buy;

                case BuySellEnum.Sell:
                    return fxcore2.Constants.Sell;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static MessageFeature GetMessaageFeature(string value)
        {
            MessageFeature result;

            var i = 0;
            if (int.TryParse(value, out i))
            {
                try
                {
                    result = (MessageFeature)i;
                    return result;
                }
                catch
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetMessaageFeature(MessageFeature value)
        {
            return ((int)value).ToString();
        }

        public static MessageType GetMessageType(string value)
        {
            try
            {
                return (MessageType)int.Parse(value);
            }
            catch { }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetMessageType(MessageType value)
        {
            return ((int)value).ToString();
        }

        public static InstrumentType GetInstrumentType(int value)
        {
            try
            {
                return (InstrumentType)value;
            }
            catch { }

            throw new ArgumentOutOfRangeException("value");
        }

        public static int GetInstrumentType(InstrumentType value)
        {
            return ((int)value);
        }

        public static InstrumentTradingStatus GetInstrumentTradingStatus(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("value");
            }

            value = value.ToUpper();
            switch (value)
            {
                case Constants.TradingStatus.Closed:
                    return InstrumentTradingStatus.Closed;

                case Constants.TradingStatus.Open:
                    return InstrumentTradingStatus.Open;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetInstrumentTradingStatus(InstrumentTradingStatus value)
        {
            switch (value)
            {
                case InstrumentTradingStatus.Closed:
                    return Constants.TradingStatus.Closed;

                case InstrumentTradingStatus.Open:
                    return Constants.TradingStatus.Open;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static PriceTradable GetPriceTradable(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("value");
            }

            value = value.ToUpper();
            switch (value)
            {
                case Constants.PriceTradable.NotTradable:
                    return PriceTradable.NotTradable;

                case Constants.PriceTradable.Tradable:
                    return PriceTradable.Tradable;

                case Constants.PriceTradable.ViewOnly:
                    return PriceTradable.ViewOnly;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetPriceTradable(PriceTradable value)
        {
            switch (value)
            {
                case PriceTradable.NotTradable:
                    return Constants.PriceTradable.NotTradable;

                case PriceTradable.Tradable:
                    return Constants.PriceTradable.Tradable;

                case PriceTradable.ViewOnly:
                    return Constants.PriceTradable.ViewOnly;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static ContingencyType GetContingencyType(int value)
        {
            try
            {
                return (ContingencyType)value;
            }
            catch { }

            throw new ArgumentOutOfRangeException("value");
        }

        public static int GetContingencyType(ContingencyType value)
        {
            return ((int)value);
        }

        public static OrderStage GetOrderStage(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("value");
            }

            value = value.ToUpper();
            switch (value)
            {
                case Constants.OrderStage.Close:
                    return OrderStage.Close;

                case Constants.OrderStage.Open:
                    return OrderStage.Open;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetOrderStage(OrderStage value)
        {
            switch (value)
            {
                case OrderStage.Close:
                    return Constants.OrderStage.Close;

                case OrderStage.Open:
                    return Constants.OrderStage.Open;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static OrderStatus GetOrderStatus(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("value");
            }

            value = value.ToUpper();
            switch (value)
            {
                case Constants.OrderStatus.Canceled:
                    return OrderStatus.Canceled;

                case Constants.OrderStatus.DealerIntervention:
                    return OrderStatus.DealerIntervention;

                case Constants.OrderStatus.Executed:
                    return OrderStatus.Executed;

                case Constants.OrderStatus.Executing:
                    return OrderStatus.Executing;

                case Constants.OrderStatus.Expired:
                    return OrderStatus.Expired;

                case Constants.OrderStatus.InProcess:
                    return OrderStatus.InProcess;

                case Constants.OrderStatus.NotAvailable:
                    return OrderStatus.NotAvailable;

                case Constants.OrderStatus.PendingCalculated:
                    return OrderStatus.PendingCalculated;

                case Constants.OrderStatus.Rejected:
                    return OrderStatus.Rejected;

                case Constants.OrderStatus.Requoted:
                    return OrderStatus.Requoted;

                case Constants.OrderStatus.Waiting:
                    return OrderStatus.Waiting;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetOrderStatus(OrderStatus value)
        {
            switch (value)
            {
                case OrderStatus.Canceled:
                    return Constants.OrderStatus.Canceled;

                case OrderStatus.DealerIntervention:
                    return Constants.OrderStatus.DealerIntervention;

                case OrderStatus.Executed:
                    return Constants.OrderStatus.Executed;

                case OrderStatus.Executing:
                    return Constants.OrderStatus.Executing;

                case OrderStatus.Expired:
                    return Constants.OrderStatus.Expired;

                case OrderStatus.InProcess:
                    return Constants.OrderStatus.InProcess;

                case OrderStatus.NotAvailable:
                    return Constants.OrderStatus.NotAvailable;

                case OrderStatus.PendingCalculated:
                    return Constants.OrderStatus.PendingCalculated;

                case OrderStatus.Rejected:
                    return Constants.OrderStatus.Rejected;

                case OrderStatus.Requoted:
                    return Constants.OrderStatus.Requoted;

                case OrderStatus.Waiting:
                    return Constants.OrderStatus.Waiting;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static TimeInForce GetTimeInForce(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("value");
            }

            value = value.ToUpper();
            switch (value)
            {
                case fxcore2.Constants.TIF.GTC:
                    return TimeInForce.GoodTillCancelled;

                case fxcore2.Constants.TIF.IOC:
                    return TimeInForce.ImmediateOrCancel;

                case fxcore2.Constants.TIF.FOK:
                    return TimeInForce.FillOrKill;

                case fxcore2.Constants.TIF.DAY:
                    return TimeInForce.DayOrder;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetTimeInForce(TimeInForce value)
        {
            switch (value)
            {
                case TimeInForce.DayOrder:
                    return fxcore2.Constants.TIF.DAY;

                case TimeInForce.FillOrKill:
                    return fxcore2.Constants.TIF.FOK;

                case TimeInForce.GoodTillCancelled:
                    return fxcore2.Constants.TIF.GTC;

                case TimeInForce.ImmediateOrCancel:
                    return fxcore2.Constants.TIF.IOC;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static OrderType GetOrderType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("value");
            }

            value = value.ToUpper();
            switch (value)
            {
                case fxcore2.Constants.Orders.CloseLimit:
                    return OrderType.CloseLimit;

                case fxcore2.Constants.Orders.Entry:
                    return OrderType.Entry;

                case fxcore2.Constants.Orders.Limit:
                    return OrderType.Limit;

                case fxcore2.Constants.Orders.LimitEntry:
                    return OrderType.EntryLimit;

                case Constants.Orders.TrailingEntryLimit:
                    return OrderType.TrailingEntryLimit;

                case fxcore2.Constants.Orders.MarketClose:
                    return OrderType.Close;

                case fxcore2.Constants.Orders.MarketCloseRange:
                    return OrderType.CloseRange;

                case fxcore2.Constants.Orders.MarketOpen:
                    return OrderType.Open;

                case fxcore2.Constants.Orders.MarketOpenRange:
                    return OrderType.OpenRange;

                case fxcore2.Constants.Orders.OpenLimit:
                    return OrderType.OpenLimit;

                case fxcore2.Constants.Orders.Stop:
                    return OrderType.Stop;

                case fxcore2.Constants.Orders.StopEntry:
                    return OrderType.EntryStop;

                case Constants.Orders.TrailingStop:
                    return OrderType.TrailingStop;

                case Constants.Orders.TrailingEntryStop:
                    return OrderType.TrailingEntryStop;

                case fxcore2.Constants.Orders.TrueMarketClose:
                    return OrderType.CloseMarket;

                case fxcore2.Constants.Orders.TrueMarketOpen:
                    return OrderType.OpenMarket;

                case Constants.Orders.MarginCall:
                    return OrderType.MarginCall;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetOrderType(OrderType value)
        {
            switch (value)
            {
                case OrderType.Close:
                    return fxcore2.Constants.Orders.MarketClose;

                case OrderType.CloseLimit:
                    return fxcore2.Constants.Orders.CloseLimit;

                case OrderType.CloseMarket:
                    return fxcore2.Constants.Orders.TrueMarketClose;

                case OrderType.CloseRange:
                    return fxcore2.Constants.Orders.MarketCloseRange;

                case OrderType.Entry:
                    return fxcore2.Constants.Orders.Entry;

                case OrderType.EntryLimit:
                    return fxcore2.Constants.Orders.LimitEntry;

                case OrderType.EntryStop:
                    return fxcore2.Constants.Orders.StopEntry;

                case OrderType.Limit:
                    return fxcore2.Constants.Orders.Limit;

                case OrderType.MarginCall:
                    return Constants.Orders.MarginCall;

                case OrderType.Open:
                    return fxcore2.Constants.Orders.MarketOpen;

                case OrderType.OpenLimit:
                    return fxcore2.Constants.Orders.OpenLimit;

                case OrderType.OpenMarket:
                    return fxcore2.Constants.Orders.TrueMarketOpen;

                case OrderType.OpenRange:
                    return fxcore2.Constants.Orders.MarketOpenRange;

                case OrderType.Stop:
                    return fxcore2.Constants.Orders.Stop;

                case OrderType.TrailingEntryLimit:
                    return Constants.Orders.TrailingEntryLimit;

                case OrderType.TrailingEntryStop:
                    return Constants.Orders.TrailingEntryStop;

                case OrderType.TrailingStop:
                    return Constants.Orders.TrailingStop;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetReportFormat(ReportFormat value)
        {
            switch (value)
            {
                case ReportFormat.HTML:
                    return Constants.ReportFormat.HTML;

                case ReportFormat.PDF:
                    return Constants.ReportFormat.PDF;

                case ReportFormat.XLS:
                    return Constants.ReportFormat.XLS;

                case ReportFormat.XML:
                    return Constants.ReportFormat.XML;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static ReportFormat GetReportFormat(string value)
        {
            switch (value)
            {
                case Constants.ReportFormat.HTML:
                    return ReportFormat.HTML;

                case Constants.ReportFormat.PDF:
                    return ReportFormat.PDF;

                case Constants.ReportFormat.XLS:
                    return ReportFormat.XLS;

                case Constants.ReportFormat.XML:
                    return ReportFormat.XML;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetReportType(ReportType value)
        {
            switch (value)
            {
                case ReportType.Default:
                    return Constants.ReportType.Default;

                case ReportType.PAMM:
                    return Constants.ReportType.PAMM;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static ReportType GetReportType(string value)
        {
            switch (value)
            {
                case Constants.ReportType.Default:
                    return ReportType.Default;

                case Constants.ReportType.PAMM:
                    return ReportType.PAMM;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetReportLanguage(ReportLanguage value)
        {
            switch (value)
            {
                case ReportLanguage.ChineseSimplified:
                    return Constants.ReportLanguage.ChineseSimplified;

                case ReportLanguage.ChineseTraditional:
                    return Constants.ReportLanguage.ChineseTraditional;

                case ReportLanguage.English:
                    return Constants.ReportLanguage.English;

                case ReportLanguage.French:
                    return Constants.ReportLanguage.French;

                case ReportLanguage.Japanese:
                    return Constants.ReportLanguage.Japanese;

                case ReportLanguage.Russian:
                    return Constants.ReportLanguage.Russian;

                case ReportLanguage.Spanish:
                    return Constants.ReportLanguage.Spanish;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static ReportLanguage GetReportLanguage(string value)
        {
            switch (value)
            {
                case Constants.ReportLanguage.ChineseSimplified:
                    return ReportLanguage.ChineseSimplified;

                case Constants.ReportLanguage.ChineseTraditional:
                    return ReportLanguage.ChineseTraditional;

                case Constants.ReportLanguage.English:
                    return ReportLanguage.English;

                case Constants.ReportLanguage.French:
                    return ReportLanguage.French;

                case Constants.ReportLanguage.Japanese:
                    return ReportLanguage.Japanese;

                case Constants.ReportLanguage.Russian:
                    return ReportLanguage.Russian;

                case Constants.ReportLanguage.Spanish:
                    return ReportLanguage.Spanish;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetTimeframeId(Timeframe value)
        {
            switch (value)
            {
                case Timeframe.Custom:
                    return null;

                case Timeframe.Days1:
                    return Constants.TimeframeId.Days1;
                
                case Timeframe.Hours1:
                    return Constants.TimeframeId.Hours1;
                
                case Timeframe.Hours2:
                    return Constants.TimeframeId.Hours2;
                
                case Timeframe.Hours3:
                    return Constants.TimeframeId.Hours3;
                
                case Timeframe.Hours4:
                    return Constants.TimeframeId.Hours4;
                
                case Timeframe.Hours6:
                    return Constants.TimeframeId.Hours6;
                
                case Timeframe.Hours8:
                    return Constants.TimeframeId.Hours8;
                
                case Timeframe.Minutes1:
                    return Constants.TimeframeId.Minutes1;
                
                case Timeframe.Minutes15:
                    return Constants.TimeframeId.Minutes15;
                
                case Timeframe.Minutes30:
                    return Constants.TimeframeId.Minutes30;
                
                case Timeframe.Minutes5:
                    return Constants.TimeframeId.Minutes5;
                
                case Timeframe.Months1:
                    return Constants.TimeframeId.Months1;
                
                case Timeframe.Tick:
                    return Constants.TimeframeId.Tick;
                
                case Timeframe.Weeks1:
                    return Constants.TimeframeId.Weeks1;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static Timeframe GetTimeframeId(string value)
        {
            switch (value)
            {
                case "":
                case null:
                    return Timeframe.Custom;

                case Constants.TimeframeId.Days1:
                    return Timeframe.Days1;

                case Constants.TimeframeId.Hours1:
                    return Timeframe.Hours1;

                case Constants.TimeframeId.Hours2:
                    return Timeframe.Hours2;

                case Constants.TimeframeId.Hours3:
                    return Timeframe.Hours3;

                case Constants.TimeframeId.Hours4:
                    return Timeframe.Hours4;

                case Constants.TimeframeId.Hours6:
                    return Timeframe.Hours6;

                case Constants.TimeframeId.Hours8:
                    return Timeframe.Hours8;

                case Constants.TimeframeId.Minutes1:
                    return Timeframe.Minutes1;

                case Constants.TimeframeId.Minutes15:
                    return Timeframe.Minutes15;

                case Constants.TimeframeId.Minutes30:
                    return Timeframe.Minutes30;

                case Constants.TimeframeId.Minutes5:
                    return Timeframe.Minutes5;

                case Constants.TimeframeId.Months1:
                    return Timeframe.Months1;

                case Constants.TimeframeId.Tick:
                    return Timeframe.Tick;

                case Constants.TimeframeId.Weeks1:
                    return Timeframe.Weeks1;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetRequestCommand(RequestCommand value)
        {
            switch (value)
            {
                case RequestCommand.CreateOCO:
                    return fxcore2.Constants.Commands.CreateOCO;
                
                case RequestCommand.CreateOrder:
                    return fxcore2.Constants.Commands.CreateOrder;
                
                case RequestCommand.CreateOTO:
                    return fxcore2.Constants.Commands.CreateOTO;
                
                case RequestCommand.DeleteOrder:
                    return fxcore2.Constants.Commands.DeleteOrder;
                
                case RequestCommand.EditOrder:
                    return fxcore2.Constants.Commands.EditOrder;
                
                case RequestCommand.GetLastOrderUpdate:
                    return fxcore2.Constants.Commands.GetLastOrderUpdate;
                
                case RequestCommand.JoinToExistingContingencyGroup:
                    return fxcore2.Constants.Commands.JoinToExistingContingencyGroup;
                
                case RequestCommand.JoinToNewContingencyGroup:
                    return fxcore2.Constants.Commands.JoinToNewContingencyGroup;
                
                case RequestCommand.RemoveFromContingencyGroup:
                    return fxcore2.Constants.Commands.RemoveFromContingencyGroup;
                
                case RequestCommand.SetSubscriptionStatus:
                    return fxcore2.Constants.Commands.SetSubscriptionStatus;
                
                case RequestCommand.UpdateMarginRequirements:
                    return fxcore2.Constants.Commands.UpdateMarginRequirements;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static RequestCommand GetRequestCommand(string value)
        {
            switch (value)
            {
                case fxcore2.Constants.Commands.CreateOCO:
                    return RequestCommand.CreateOCO;

                case fxcore2.Constants.Commands.CreateOrder:
                    return RequestCommand.CreateOrder;

                case fxcore2.Constants.Commands.CreateOTO:
                    return RequestCommand.CreateOTO;

                case fxcore2.Constants.Commands.DeleteOrder:
                    return RequestCommand.DeleteOrder;

                case fxcore2.Constants.Commands.EditOrder:
                    return RequestCommand.EditOrder;

                case fxcore2.Constants.Commands.GetLastOrderUpdate:
                    return RequestCommand.GetLastOrderUpdate;

                case fxcore2.Constants.Commands.JoinToExistingContingencyGroup:
                    return RequestCommand.JoinToExistingContingencyGroup;

                case fxcore2.Constants.Commands.JoinToNewContingencyGroup:
                    return RequestCommand.JoinToNewContingencyGroup;

                case fxcore2.Constants.Commands.RemoveFromContingencyGroup:
                    return RequestCommand.RemoveFromContingencyGroup;

                case fxcore2.Constants.Commands.SetSubscriptionStatus:
                    return RequestCommand.SetSubscriptionStatus;

                case fxcore2.Constants.Commands.UpdateMarginRequirements:
                    return RequestCommand.UpdateMarginRequirements;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static SubscriptionStatus GetSubscriptionStatus(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException("value");
            }

            switch (value)
            {
                case fxcore2.Constants.SubscriptionStatuses.Disable:
                    return SubscriptionStatus.NotAvailable;

                case fxcore2.Constants.SubscriptionStatuses.Tradable:
                    return SubscriptionStatus.Available;

                case fxcore2.Constants.SubscriptionStatuses.ViewOnly:
                    return SubscriptionStatus.ViewOnly;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static string GetSubscriptionStatus(SubscriptionStatus value)
        {
            switch (value)
            {
                case SubscriptionStatus.NotAvailable:
                    return fxcore2.Constants.SubscriptionStatuses.Disable;

                case SubscriptionStatus.Available:
                    return fxcore2.Constants.SubscriptionStatuses.Tradable;

                case SubscriptionStatus.ViewOnly:
                    return fxcore2.Constants.SubscriptionStatuses.ViewOnly;
            }

            throw new ArgumentOutOfRangeException("value");
        }
    }
}
