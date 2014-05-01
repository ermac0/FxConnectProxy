// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface IRequestProvider
    {
        RequestResponse MarketDataSnapshotRequest(MarketDataSnapshotRequest request);

        RequestResponse OrderRequest(OrderRequest request);

        RequestResponse RefreshTableRequest(RefreshTableRequest request);

        RequestResponse RefreshTableByAccountRequest(RefreshTableByAccountRequest request);

        GetLastErrorResponse GetLastError();
    }
}
