// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public abstract class Constants
    {
        public const uint INFINITE = uint.MaxValue;

        public abstract class Orders
        {
            public const string TrailingEntryLimit = "LTE";
            public const string TrailingStop = "ST";
            public const string TrailingEntryStop = "STE";
            public const string MarginCall = "M";
        }

        public abstract class AccountMaintenanceType
        {
            public const string Hedging = "Y";
            public const string NoHedging = "N";
            public const string Netting = "O";
            public const string DayNetting = "D";
            public const string FIFO = "F";
        }

        public abstract class AccountType
        {
            public const string SelfTraded = "32";
            public const string FundsManager = "36";
            public const string Managed = "38";
        }

        public abstract class TradingStatus
        {
            public const string Open = "O";
            public const string Closed = "C";
        }

        public abstract class PriceTradable
        {
            public const string Tradable = "T";
            public const string ViewOnly = "I";
            public const string NotTradable = "N";
        }

        public abstract class OrderStage
        {
            public const string Open = "O";
            public const string Close = "C";
        }

        public abstract class OrderStatus
        {
            public const string Waiting = "W";
            public const string InProcess = "P";
            public const string DealerIntervention = "I";
            public const string Requoted = "Q";
            public const string PendingCalculated = "U";
            public const string Executing = "E";
            public const string Canceled = "C";
            public const string Rejected = "R";
            public const string Expired = "T";
            public const string Executed = "F";
            public const string NotAvailable = "G";
        }

        public abstract class ReportFormat
        {
            public const string HTML = "HTML";
            public const string XML = "XML";
            public const string PDF = "PDF";
            public const string XLS = "XLS";
        }

        public abstract class ReportType
        {
            public const string Default = "REPORT_NAME_CUSTOMER_ACCOUNT_STATEMENT";
            public const string PAMM = "REPORT_NAME_CUSTOMER_ACCOUNT_STATEMENT_PAMM";
        }

        public abstract class ReportLanguage
        {
            public const string English = "enu";
            public const string Japanese = "jpn";
            public const string French = "fra";
            public const string Spanish = "esp";
            public const string ChineseTraditional = "cht";
            public const string ChineseSimplified = "chs";
            public const string Russian = "rus";
        }

        public abstract class TimeframeId
        {
            public const string Tick = "t1";
            public const string Days1 = "D1";
            public const string Weeks1 = "W1";
            public const string Months1 = "M1";
            public const string Minutes1 = "m1";
            public const string Minutes5 = "m5";
            public const string Minutes15 = "m15";
            public const string Minutes30 = "m30";
            public const string Hours1 = "H1";
            public const string Hours2 = "H2";
            public const string Hours3 = "H3";
            public const string Hours4 = "H4";
            public const string Hours6 = "H6";
            public const string Hours8 = "H8";
        }
    }
}
