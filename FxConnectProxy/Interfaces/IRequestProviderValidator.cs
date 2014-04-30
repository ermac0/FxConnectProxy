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
