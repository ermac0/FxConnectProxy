// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxConnectProxy.Tests.Data
{
    [TestClass]
    public class AccountRowTests : BaseRowTests<AccountRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Account; }
        }
    }

    [TestClass]
    public class AccountTableRowTests : BaseRowTests<AccountTableRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Account; }
        }
    }

    [TestClass]
    public class ClosedTradeRowTests : BaseRowTests<ClosedTradeRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.ClosedTrade; }
        }
    }

    [TestClass]
    public class ClosedTradeTableRowTests : BaseRowTests<ClosedTradeTableRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.ClosedTrade; }
        }
    }

    [TestClass]
    public class LastOrderUpdateRowTests : BaseRowTests<LastOrderUpdateRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.LastOrderUpdate; }
        }
    }

    [TestClass]
    public class MarketDataRowTests : BaseRowTests<MarketDataRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.MarketData; }
        }
    }

    [TestClass]
    public class MessageRowTests : BaseRowTests<MessageRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Message; }
        }
    }

    [TestClass]
    public class MessageTableRowTests : BaseRowTests<MessageTableRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Message; }
        }
    }

    [TestClass]
    public class OfferRowTests : BaseRowTests<OfferRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Offer; }
        }
    }

    [TestClass]
    public class OfferTableRowTests : BaseRowTests<OfferTableRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Offer; }
        }
    }

    [TestClass]
    public class OrderRowTests : BaseRowTests<OrderRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Order; }
        }
    }

    [TestClass]
    public class OrderTableRowTests : BaseRowTests<OrderTableRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Order; }
        }
    }

    [TestClass]
    public class SummaryRowTests : BaseRowTests<SummaryRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Summary; }
        }
    }

    [TestClass]
    public class SummaryTableRowTests : BaseRowTests<SummaryTableRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Summary; }
        }
    }

    [TestClass]
    public class SystemPropertyRowTests : BaseRowTests<SystemPropertyRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.SystemProperty; }
        }
    }

    [TestClass]
    public class TradeRowTests : BaseRowTests<TradeRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Trade; }
        }
    }

    [TestClass]
    public class TradeTableRowTests : BaseRowTests<TradeTableRow>
    {
        protected override RowType ExpectedRowType
        {
            get { return RowType.Trade; }
        }
    }
}
