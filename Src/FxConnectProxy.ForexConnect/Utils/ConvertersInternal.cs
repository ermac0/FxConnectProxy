using fxcore2;
// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.ForexConnect.Utils
{
    abstract class ConvertersInternal : Converters
    {
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

        public static O2GTableUpdateType GetUpdateType(UpdateType value)
        {
            switch (value)
            {
                case UpdateType.Delete:
                    return O2GTableUpdateType.Delete;

                case UpdateType.Insert:
                    return O2GTableUpdateType.Insert;

                case UpdateType.Update:
                    return O2GTableUpdateType.Update;
            }

            return O2GTableUpdateType.UpdateUnknown;
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

        public static O2GMarketStatus GetMarketStatus(MarketStatus value)
        {
            switch (value)
            {
                case MarketStatus.Closed:
                    return O2GMarketStatus.MarketStatusClosed;

                case MarketStatus.Open:
                    return O2GMarketStatus.MarketStatusOpen;
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

        public static O2GPermissionStatus GetPermissionStatus(PermissionStatus value)
        {
            switch (value)
            {
                case PermissionStatus.Disabled:
                    return O2GPermissionStatus.PermissionDisabled;

                case PermissionStatus.Enabled:
                    return O2GPermissionStatus.PermissionEnabled;

                case PermissionStatus.Hidden:
                    return O2GPermissionStatus.PermissionHidden;
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

        public static O2GSessionStatusCode GetSessionStatus(SessionStatus value)
        {
            switch (value)
            {
                case SessionStatus.Connected:
                    return O2GSessionStatusCode.Connected;

                case SessionStatus.Connecting:
                    return O2GSessionStatusCode.Connecting;

                case SessionStatus.Disconnected:
                    return O2GSessionStatusCode.Disconnected;

                case SessionStatus.Disconnecting:
                    return O2GSessionStatusCode.Disconnecting;

                case SessionStatus.PriceSessionReconnecting:
                    return O2GSessionStatusCode.PriceSessionReconnecting;

                case SessionStatus.Reconnecting:
                    return O2GSessionStatusCode.Reconnecting;

                case SessionStatus.SessionLost:
                    return O2GSessionStatusCode.SessionLost;

                case SessionStatus.TradingSessionRequested:
                    return O2GSessionStatusCode.TradingSessionRequested;

                case SessionStatus.Unknown:
                    return O2GSessionStatusCode.Unknown;
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

        public static O2GTableManagerStatus GetTableManagerStatus(TableManagerStatus value)
        {
            switch (value)
            {
                case TableManagerStatus.Loaded:
                    return O2GTableManagerStatus.TablesLoaded;

                case TableManagerStatus.LoadFailed:
                    return O2GTableManagerStatus.TablesLoadFailed;

                case TableManagerStatus.Loading:
                    return O2GTableManagerStatus.TablesLoading;
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

        public static RequestParam GetRequestParam(O2GRequestParamsEnum value)
        {
            switch (value)
            {
                case O2GRequestParamsEnum.AccountID:
                    return RequestParam.AccountID;

                case O2GRequestParamsEnum.AccountName:
                    return RequestParam.AccountName;

                case O2GRequestParamsEnum.Amount:
                    return RequestParam.Amount;

                case O2GRequestParamsEnum.BuySell:
                    return RequestParam.BuySell;

                case O2GRequestParamsEnum.ClientRate:
                    return RequestParam.ClientRate;

                case O2GRequestParamsEnum.Command:
                    return RequestParam.Command;

                case O2GRequestParamsEnum.ContingencyGroupType:
                    return RequestParam.ContingencyGroupType;

                case O2GRequestParamsEnum.ContingencyID:
                    return RequestParam.ContingencyID;

                case O2GRequestParamsEnum.CustomID:
                    return RequestParam.CustomID;

                case O2GRequestParamsEnum.Id:
                    return RequestParam.Id;

                case O2GRequestParamsEnum.Key:
                    return RequestParam.Key;

                case O2GRequestParamsEnum.NetQuantity:
                    return RequestParam.NetQuantity;

                case O2GRequestParamsEnum.OfferID:
                    return RequestParam.OfferID;

                case O2GRequestParamsEnum.OrderID:
                    return RequestParam.OrderID;

                case O2GRequestParamsEnum.OrderType:
                    return RequestParam.OrderType;

                case O2GRequestParamsEnum.PegOffset:
                    return RequestParam.PegOffset;

                case O2GRequestParamsEnum.PegOffsetLimit:
                    return RequestParam.PegOffsetLimit;

                case O2GRequestParamsEnum.PegOffsetStop:
                    return RequestParam.PegOffsetStop;

                case O2GRequestParamsEnum.PegType:
                    return RequestParam.PegType;

                case O2GRequestParamsEnum.PegTypeLimit:
                    return RequestParam.PegTypeLimit;

                case O2GRequestParamsEnum.PegTypeStop:
                    return RequestParam.PegTypeStop;

                case O2GRequestParamsEnum.PrimaryQID:
                    return RequestParam.PrimaryQID;

                case O2GRequestParamsEnum.Rate:
                    return RequestParam.Rate;

                case O2GRequestParamsEnum.RateLimit:
                    return RequestParam.RateLimit;

                case O2GRequestParamsEnum.RateMax:
                    return RequestParam.RateMax;

                case O2GRequestParamsEnum.RateMin:
                    return RequestParam.RateMin;

                case O2GRequestParamsEnum.RateStop:
                    return RequestParam.RateStop;

                case O2GRequestParamsEnum.SubscriptionStatus:
                    return RequestParam.SubscriptionStatus;

                case O2GRequestParamsEnum.TimeInForce:
                    return RequestParam.TimeInForce;

                case O2GRequestParamsEnum.TradeID:
                    return RequestParam.TradeID;

                case O2GRequestParamsEnum.TrailStep:
                    return RequestParam.TrailStep;

                case O2GRequestParamsEnum.TrailStepStop:
                    return RequestParam.TrailStepStop;

                case O2GRequestParamsEnum.UnknownParam:
                    return RequestParam.UnknownParam;
            }

            throw new ArgumentOutOfRangeException("value");
        }
    }
}
