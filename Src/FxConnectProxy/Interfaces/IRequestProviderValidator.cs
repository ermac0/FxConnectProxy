// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface IRequestProviderValidator
    {
        void Validate(MarketDataSnapshotRequest request);

        void Validate(OrderRequest request);

        void Validate(RefreshTableRequest request);

        void Validate(RefreshTableByAccountRequest request);
    }
}
