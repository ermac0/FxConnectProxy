using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fxcore2;

namespace FxConnectProxy
{
    static class Converters
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

        public static UpdateType GetUpdateType(O2GTableUpdateType value)
        {
            switch (value)
            {
                case O2GTableUpdateType.Delete:
                    return UpdateType.Delete;

                case O2GTableUpdateType.Insert:
                    return UpdateType.Insert;

                case O2GTableUpdateType.Update:
                    return UpdateType.Update;
            }

            return UpdateType.Default;
        }

        public static O2GTableType GetTableType(TableType value)
        {
            switch (value)
            {
                case TableType.Accounts:
                    return O2GTableType.Accounts;

                case TableType.ClosedTrades:
                    return O2GTableType.ClosedTrades;

                case TableType.Messages:
                    return O2GTableType.Messages;

                case TableType.Offers:
                    return O2GTableType.Offers;

                case TableType.Orders:
                    return O2GTableType.Orders;

                case TableType.Summary:
                    return O2GTableType.Summary;

                case TableType.Trades:
                    return O2GTableType.Trades;

                case TableType.Unknown:
                    return O2GTableType.TableUnknown;

            }

            return O2GTableType.TableUnknown;
        }

        public static TableType GetTableType(O2GTableType value)
        {
            switch (value)
            {
                case O2GTableType.Accounts:
                    return TableType.Accounts;

                case O2GTableType.ClosedTrades:
                    return TableType.ClosedTrades;

                case O2GTableType.Messages:
                    return TableType.Messages;

                case O2GTableType.Offers:
                    return TableType.Offers;

                case O2GTableType.Orders:
                    return TableType.Orders;

                case O2GTableType.Summary:
                    return TableType.Summary;

                case O2GTableType.Trades:
                    return TableType.Trades;

                case O2GTableType.TableUnknown:
                    return TableType.Unknown;

            }

            return TableType.Unknown;
        }

        public static MarketStatus GetMarketStatus(O2GMarketStatus value)
        {
            switch (value)
            {
                case O2GMarketStatus.MarketStatusClosed:
                    return MarketStatus.Closed;

                case O2GMarketStatus.MarketStatusOpen:
                    return MarketStatus.Open;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static PermissionStatus GetPermissionStatus(O2GPermissionStatus value)
        {
            switch (value)
            {
                case O2GPermissionStatus.PermissionDisabled:
                    return PermissionStatus.Disabled;

                case O2GPermissionStatus.PermissionEnabled:
                    return PermissionStatus.Enabled;
                
                case O2GPermissionStatus.PermissionHidden:
                    return PermissionStatus.Hidden;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static PriceUpdateMode GetPriceUpdateMode(O2GPriceUpdateMode value)
        {
            switch (value)
            {
                case O2GPriceUpdateMode.Default:
                    return PriceUpdateMode.Default;

                case O2GPriceUpdateMode.NoPrice:
                    return PriceUpdateMode.NoPrice;
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

        public static O2GPriceUpdateMode GetPriceUpdateMode(PriceUpdateMode value)
        {
            switch (value)
            {
                case PriceUpdateMode.Default:
                    return O2GPriceUpdateMode.Default;

                case PriceUpdateMode.NoPrice:
                    return O2GPriceUpdateMode.NoPrice;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static SessionStatus GetSessionStatus(O2GSessionStatusCode value)
        {
            switch (value)
            {
                case O2GSessionStatusCode.Connected:
                    return SessionStatus.Connected;

                case O2GSessionStatusCode.Connecting:
                    return SessionStatus.Connecting;

                case O2GSessionStatusCode.Disconnected:
                    return SessionStatus.Disconnected;

                case O2GSessionStatusCode.Disconnecting:
                    return SessionStatus.Disconnecting;

                case O2GSessionStatusCode.PriceSessionReconnecting:
                    return SessionStatus.PriceSessionReconnecting;

                case O2GSessionStatusCode.Reconnecting:
                    return SessionStatus.Reconnecting;

                case O2GSessionStatusCode.SessionLost:
                    return SessionStatus.SessionLost;

                case O2GSessionStatusCode.TradingSessionRequested:
                    return SessionStatus.TradingSessionRequested;

                case O2GSessionStatusCode.Unknown:
                    return SessionStatus.Unknown;
            }

            throw new ArgumentOutOfRangeException("value");
        }

        public static TableManagerStatus GetTableManagerStatus(O2GTableManagerStatus value)
        {
            switch (value)
            {
                case O2GTableManagerStatus.TablesLoaded:
                    return TableManagerStatus.Loaded;

                case O2GTableManagerStatus.TablesLoadFailed:
                    return TableManagerStatus.LoadFailed;
                
                case O2GTableManagerStatus.TablesLoading:
                    return TableManagerStatus.Loading;
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

        public static O2GRequestParamsEnum GetRequestParam(RequestParam value)
        {
            switch (value)
            {
                case RequestParam.AccountID:
                    return O2GRequestParamsEnum.AccountID;
                
                case RequestParam.AccountName:
                    return O2GRequestParamsEnum.AccountName;
                
                case RequestParam.Amount:
                    return O2GRequestParamsEnum.Amount;
                
                case RequestParam.BuySell:
                    return O2GRequestParamsEnum.BuySell;
                
                case RequestParam.ClientRate:
                    return O2GRequestParamsEnum.ClientRate;
                
                case RequestParam.Command:
                    return O2GRequestParamsEnum.Command;
                
                case RequestParam.ContingencyGroupType:
                    return O2GRequestParamsEnum.ContingencyGroupType;
                
                case RequestParam.ContingencyID:
                    return O2GRequestParamsEnum.ContingencyID;
                
                case RequestParam.CustomID:
                    return O2GRequestParamsEnum.CustomID;
                
                case RequestParam.Id:
                    return O2GRequestParamsEnum.Id;
                
                case RequestParam.Key:
                    return O2GRequestParamsEnum.Key;
                
                case RequestParam.NetQuantity:
                    return O2GRequestParamsEnum.NetQuantity;
                
                case RequestParam.OfferID:
                    return O2GRequestParamsEnum.OfferID;
                
                case RequestParam.OrderID:
                    return O2GRequestParamsEnum.OrderID;
                
                case RequestParam.OrderType:
                    return O2GRequestParamsEnum.OrderType;
                
                case RequestParam.PegOffset:
                    return O2GRequestParamsEnum.PegOffset;
                
                case RequestParam.PegOffsetLimit:
                    return O2GRequestParamsEnum.PegOffsetLimit;
                
                case RequestParam.PegOffsetStop:
                    return O2GRequestParamsEnum.PegOffsetStop;
                
                case RequestParam.PegType:
                    return O2GRequestParamsEnum.PegType;
                
                case RequestParam.PegTypeLimit:
                    return O2GRequestParamsEnum.PegTypeLimit;

                case RequestParam.PegTypeStop:
                    return O2GRequestParamsEnum.PegTypeStop;

                case RequestParam.PrimaryQID:
                    return O2GRequestParamsEnum.PrimaryQID;

                case RequestParam.Rate:
                    return O2GRequestParamsEnum.Rate;

                case RequestParam.RateLimit:
                    return O2GRequestParamsEnum.RateLimit;

                case RequestParam.RateMax:
                    return O2GRequestParamsEnum.RateMax;

                case RequestParam.RateMin:
                    return O2GRequestParamsEnum.RateMin;

                case RequestParam.RateStop:
                    return O2GRequestParamsEnum.RateStop;

                case RequestParam.SubscriptionStatus:
                    return O2GRequestParamsEnum.SubscriptionStatus;

                case RequestParam.TimeInForce:
                    return O2GRequestParamsEnum.TimeInForce;

                case RequestParam.TradeID:
                    return O2GRequestParamsEnum.TradeID;

                case RequestParam.TrailStep:
                    return O2GRequestParamsEnum.TrailStep;

                case RequestParam.TrailStepStop:
                    return O2GRequestParamsEnum.TrailStepStop;

                case RequestParam.UnknownParam:
                    return O2GRequestParamsEnum.UnknownParam;
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
    }
}
