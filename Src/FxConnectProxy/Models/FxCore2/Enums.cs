// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public enum AccountMaintenanceType
    {
        Hedging = 1,
        NoHedging = 2,
        Netting = 3,
        DayNetting = 4,
        FIFO = 5,
    }

    public enum AccountKind
    {
        SelfTradedAccount = 1,
        FundsManagerAccount = 2,
        ManagedAccount = 3,
    }

    public enum BuySellEnum
    {
        Buy = 1,
        Sell = 2,
    }

    public enum MessageFeature
    {
        Plain = 1,
        TradingHours = 2,
        Questions = 3,
        Information = 4,
        MarketConditions = 5,
        SoftwareUpdate = 6,
        Emergency = 7,
        System = 8,
    }

    public enum MessageType
    {
        Plain = 0,
        Popup = 1,
        Prompt = 2,
    }

    public enum InstrumentType
    {
        Forex = 1,
        Indices = 2,
        Commodities = 3,
        Treasuries = 4,
        Bullion = 5,
    }

    public enum PriceTradable
    {
        Tradable = 1,
        ViewOnly = 2,
        NotTradable = 3,
    }

    public enum InstrumentTradingStatus
    {
        Open = 1,
        Closed = 2,
    }

    public enum ContingencyType
    {
        None = 0,
        OCO = 1,
        OTO = 2,
        ELS = 3,
    }

    public enum OrderStage
    {
        Open = 1,
        Close = 2,
    }

    public enum OrderStatus
    {
        Waiting = 1,
        InProcess = 2,
        DealerIntervention = 3,
        Requoted = 4,
        PendingCalculated = 5,
        Executing = 6,
        Canceled = 7,
        Rejected = 8,
        Expired = 9,
        Executed = 10,
        NotAvailable = 11,
    }

    public enum TimeInForce
    {
        GoodTillCancelled = 1,
        ImmediateOrCancel = 2,
        FillOrKill = 3,
        DayOrder = 4,
    }

    public enum OrderType
    {
        Stop = 1,
        TrailingStop = 2,
        Limit = 3,
        EntryStop = 4,
        EntryLimit = 5,
        TrailingEntryStop = 6,
        TrailingEntryLimit = 7,
        Close = 8,
        CloseMarket = 9,
        CloseRange = 10,
        Open = 11,
        OpenMarket = 12,
        OpenRange = 13,
        MarginCall = 14,
        CloseLimit = 15,
        Entry = 16,
        OpenLimit = 17,
    }

    public enum UpdateType
    {
        /// <summary>
        /// Received via RequestCompleted event.
        /// </summary>
        Default = 0,

        // Below updates received via TableUpdate event.
        Update = 1,
        Insert = 2,
        Delete = 3,
    }

    public enum RowType
    {
        Unknown = 0,
        Account = 1,
        ClosedTrade = 2,
        LastOrderUpdate = 3,
        Message = 4,
        Offer = 5,
        Order = 6,
        Summary = 7,
        SystemProperty = 8,
        Trade = 9,
        MarketData = 10,
    }

    public enum SessionStatus
    {
        Disconnected = 0,
        Connecting = 1,
        TradingSessionRequested = 2,
        Connected = 3,
        Reconnecting = 4,
        Disconnecting = 5,
        SessionLost = 6,
        PriceSessionReconnecting = 7,
        Unknown = 8,
    }

    public enum ResponseType
    {
        CommandResponse = 10,
        CreateOrderResponse = 8,
        GetAccounts = 2,
        GetClosedTrades = 6,
        GetLastOrderUpdate = 12,
        GetMessages = 7,
        GetOffers = 3,
        GetOrders = 4,
        GetSystemProperties = 9,
        GetTrades = 5,
        MarginRequirementsResponse = 11,
        MarketDataSnapshot = 1,
        ResponseUnknown = -1,
        TablesUpdates = 0
    }

    public enum TableType
    {
        Unknown = 0,
        Accounts = 1,
        ClosedTrades = 2,
        Messages = 3,
        Offers = 4,
        Orders = 5,
        Summary = 6,
        Trades = 7,
    }

    public enum MarketStatus
    {
        Open = 0,
        Closed = 1,
    }

    public enum TableManagerStatus
    {
        Loading = 0,
        Loaded = 1,
        LoadFailed = 2,
    }

    public enum PermissionStatus
    {
        Disabled = 0,
        Enabled = 1,
        Hidden = 2,
    }

    public enum PriceUpdateMode
    {
        Default = 0,
        NoPrice = 1,
    }

    public enum ReportFormat
    {
        HTML = 0,
        XML = 1,
        PDF = 2,
        XLS = 3,
    }

    public enum ReportType
    {
        Default = 0,
        PAMM = 1,
    }

    public enum ReportLanguage
    {
        English = 0,
        Japanese = 1,
        French = 2,
        Spanish = 3,
        ChineseTraditional = 4,
        ChineseSimplified = 5,
        Russian = 6,
    }

    public enum Timeframe
    {
        Tick = 0,
        Minutes1 = 1,
        Minutes5 = 2,
        Minutes15 = 3,
        Minutes30 = 4,
        Hours1 = 5,
        Hours2 = 6,
        Hours3 = 7,
        Hours4 = 8,
        Hours6 = 9,
        Hours8 = 10,
        Days1 = 11,
        Weeks1 = 12,
        Months1 = 13,
        Custom = 14,
    }

    public enum RequestParam
    {
        AccountID = 2,
        AccountName = 30,
        Amount = 6,
        BuySell = 5,
        ClientRate = 0x1b,
        Command = 1,
        ContingencyGroupType = 0x1c,
        ContingencyID = 0x19,
        CustomID = 13,
        Id = 0x20,
        Key = 0x1f,
        NetQuantity = 0x15,
        OfferID = 3,
        OrderID = 14,
        OrderType = 0x16,
        PegOffset = 0x13,
        PegOffsetLimit = 0x10,
        PegOffsetStop = 15,
        PegType = 20,
        PegTypeLimit = 0x12,
        PegTypeStop = 0x11,
        PrimaryQID = 0x1d,
        Rate = 7,
        RateLimit = 9,
        RateMax = 0x18,
        RateMin = 0x17,
        RateStop = 8,
        SubscriptionStatus = 0x1a,
        TimeInForce = 12,
        TradeID = 4,
        TrailStep = 11,
        TrailStepStop = 10,
        UnknownParam = -1
    }

    public enum RequestCommand
    {
        CreateOCO = 1,
        CreateOrder = 2,
        CreateOTO = 3,
        DeleteOrder = 4,
        EditOrder = 5,
        GetLastOrderUpdate = 6,
        JoinToExistingContingencyGroup = 7,
        JoinToNewContingencyGroup = 8,
        RemoveFromContingencyGroup = 9,
        SetSubscriptionStatus = 10,
        UpdateMarginRequirements = 11,
    }
}
