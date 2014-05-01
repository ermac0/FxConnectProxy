using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface ISessionProviderValidator
    {
        void Validate(LoginRequest request);

        void Validate(SetNumberOfReconnectionsRequest request);

        void Validate(SetProxyRequest request);

        void Validate(GetReportURLRequest request);

        void Validate(SetPriceUpdateModeRequest request);

        void Validate(SetTradingSessionRequest request);

        void Validate(UseTableManagerRequest request);
    }
}
