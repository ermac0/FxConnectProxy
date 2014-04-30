using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface ISessionProvider
    {
        void Login(LoginRequest request);

        void Logout();

        void SetNumberOfReconnections(SetNumberOfReconnectionsRequest request);

        void SetProxy(SetProxyRequest request);

        GetPriceUpdateModeResponse GetPriceUpdateMode();

        GetReportURLResponse GetReportURL(GetReportURLRequest request);

        GetServerTimeResponse GetServerTime();

        void SetPriceUpdateMode(SetPriceUpdateModeRequest request);

        void SetTradingSession(SetTradingSessionRequest request);

        void UseTableManager(UseTableManagerRequest request);

        event EventHandler<EventArgs<LoginFailed>> LoginFailed;

        event EventHandler<EventArgs<DataReceived>> DataReceived;

        event EventHandler<EventArgs<RequestFailed>> RequestFailed;

        event EventHandler<EventArgs<SessionStatusChanged>> SessionStatusChanged;

        event EventHandler<EventArgs<TableManagerStatusChanged>> TableManagerStatusChanged;

        SessionStatus SessionStatus { get; }

        TableManagerStatus TableManagerStatus { get; }

        bool UsingTableManager { get; }
    }
}
