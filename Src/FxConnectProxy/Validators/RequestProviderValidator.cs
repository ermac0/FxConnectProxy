// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using FxConnectProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Validators
{
    public class RequestProviderValidator : IRequestProviderValidator
    {
        public void Validate(MarketDataSnapshotRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (string.IsNullOrEmpty(request.Instrument))
            {
                throw new ArgumentNullException("Instrument");
            }

            if (request.MaxBars < 0)
            {
                throw new ArgumentOutOfRangeException("MaxBars", "MaxBars should not be negative.");
            }

            if (request.Timeframe == Timeframe.Custom && string.IsNullOrEmpty(request.CustomTimeframeId))
            {
                throw new ArgumentNullException("CustomTimeframe", "CustomTimeframe has to be specified.");
            }
        }

        public void Validate(OrderRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Map == null)
            {
                throw new ArgumentNullException("Map");
            }
        }

        public void Validate(RefreshTableRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Table == TableType.Orders)
            {
                throw new ArgumentException("Use RefreshTableByAccountRequest() to refresh Orders table.", "Table");
            }

            if (request.Table == TableType.Unknown || request.Table == TableType.Summary)
            {
                throw new ArgumentOutOfRangeException("Table");
            }
        }


        public void Validate(RefreshTableByAccountRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Table == TableType.Unknown || request.Table == TableType.Summary)
            {
                throw new ArgumentOutOfRangeException("Table");
            }

            if (string.IsNullOrEmpty(request.AccountID))
            {
                throw new ArgumentNullException("AccountID");
            }
        }
    }
}
