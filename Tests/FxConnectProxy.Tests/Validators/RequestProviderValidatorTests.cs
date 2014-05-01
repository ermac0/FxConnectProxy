// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FxConnectProxy.Validators;

namespace FxConnectProxy.Tests.Validators
{
    [TestClass]
    public class RequestProviderValidatorTests
    {
        [TestMethod]
        public void ValidateMarketDataSnapshotRequest()
        {
            // Null.
            {
                var v = new RequestProviderValidator();
                MarketDataSnapshotRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                    {
                        v.Validate(r);
                    });
            }

            // Instrument null.
            {
                var v = new RequestProviderValidator();
                MarketDataSnapshotRequest r = new MarketDataSnapshotRequest();
                r.Instrument = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Instrument empty.
            {
                var v = new RequestProviderValidator();
                MarketDataSnapshotRequest r = new MarketDataSnapshotRequest();
                r.Instrument = "";

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Negative MaxBars.
            {
                var v = new RequestProviderValidator();
                MarketDataSnapshotRequest r = new MarketDataSnapshotRequest();
                r.Instrument = "Test";
                r.MaxBars = -5;

                AssertEx.Throws<ArgumentOutOfRangeException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid without CustomTimeframeId.
            {
                var v = new RequestProviderValidator();
                MarketDataSnapshotRequest r = new MarketDataSnapshotRequest();
                r.Instrument = "Test";
                r.MaxBars = 7;
                r.Timeframe = Timeframe.Hours2;

                v.Validate(r);
            }

            // CustomTimeframeId null.
            {
                var v = new RequestProviderValidator();
                MarketDataSnapshotRequest r = new MarketDataSnapshotRequest();
                r.Instrument = "Test";
                r.Timeframe = Timeframe.Custom;
                r.CustomTimeframeId = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // CustomTimeframeId empty.
            {
                var v = new RequestProviderValidator();
                MarketDataSnapshotRequest r = new MarketDataSnapshotRequest();
                r.Instrument = "Test";
                r.Timeframe = Timeframe.Custom;
                r.CustomTimeframeId = "";

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // valid with CustomTimeframeId.
            {
                var v = new RequestProviderValidator();
                MarketDataSnapshotRequest r = new MarketDataSnapshotRequest();
                r.Instrument = "Test";
                r.Timeframe = Timeframe.Custom;
                r.CustomTimeframeId = "Y1";

                v.Validate(r);
            }
        }

        [TestMethod]
        public void ValidateOrderRequest()
        {
            // Null.
            {
                var v = new RequestProviderValidator();
                OrderRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Map null.
            {
                var v = new RequestProviderValidator();
                OrderRequest r = new OrderRequest();
                r.Map = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                var v = new RequestProviderValidator();
                OrderRequest r = new OrderRequest();
                r.Map = new ValueMap();

                v.Validate(r);
            }
        }

        [TestMethod]
        public void ValidateRefreshTableRequest()
        {
            // Null.
            {
                var v = new RequestProviderValidator();
                RefreshTableRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Invalid tables.
            {
                foreach (var opt in new[] { TableType.Unknown, TableType.Summary })
                {
                    var v = new RequestProviderValidator();
                    RefreshTableRequest r = new RefreshTableRequest();
                    r.Table = opt;

                    AssertEx.Throws<ArgumentOutOfRangeException>(() =>
                    {
                        v.Validate(r);
                    });
                }
            }

            // Invalid order table.
            {
                var v = new RequestProviderValidator();
                RefreshTableRequest r = new RefreshTableRequest();
                r.Table = TableType.Orders;

                AssertEx.Throws<ArgumentException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                foreach (var opt in new[] { TableType.Accounts, TableType.ClosedTrades, TableType.Messages,
                    TableType.Offers, TableType.Trades })
                {
                    var v = new RequestProviderValidator();
                    RefreshTableRequest r = new RefreshTableRequest();
                    r.Table = opt;

                    v.Validate(r);
                }
            }
        }

        [TestMethod]
        public void ValidateRefreshTableByAccountRequest()
        {
            // Null.
            {
                var v = new RequestProviderValidator();
                RefreshTableByAccountRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Invalid tables.
            {
                foreach (var opt in new[] { TableType.Unknown, TableType.Summary })
                {
                    var v = new RequestProviderValidator();
                    RefreshTableByAccountRequest r = new RefreshTableByAccountRequest();
                    r.Table = opt;

                    AssertEx.Throws<ArgumentOutOfRangeException>(() =>
                    {
                        v.Validate(r);
                    });
                }
            }

            // AccountID null.
            {
                var v = new RequestProviderValidator();
                RefreshTableByAccountRequest r = new RefreshTableByAccountRequest();
                r.Table = TableType.Orders;
                r.AccountID = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // AccountID empty.
            {
                var v = new RequestProviderValidator();
                RefreshTableByAccountRequest r = new RefreshTableByAccountRequest();
                r.Table = TableType.Orders;
                r.AccountID = "";

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                foreach (var opt in new[] { TableType.Accounts, TableType.ClosedTrades, TableType.Messages,
                    TableType.Offers, TableType.Trades, TableType.Orders })
                {
                    var v = new RequestProviderValidator();
                    RefreshTableByAccountRequest r = new RefreshTableByAccountRequest();
                    r.Table = opt;
                    r.AccountID = "TEST";

                    v.Validate(r);
                }
            }

        }
    }
}
