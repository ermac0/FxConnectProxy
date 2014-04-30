using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface IFxConnectProxy
    {
        ILoginRulesProvider LoginRules { get; }

        ITradingSettingsProvider TradingSettings { get; }

        IPermissionChecker PermissionChecker { get; }

        IRequestProvider Requests { get; }

        ISessionProvider Session { get; }

        ITableManager TableManager { get; }
    }
}
