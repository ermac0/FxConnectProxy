// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using FxConnectProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.ForexConnect.Models
{
    class SessionFeedbackContext
    {
        public Action<ILoginRulesProvider> SetLoginRulesProvider { get; set; }

        public Action<IPermissionChecker> SetPermissionChecker { get; set; }

        public Action<IRequestProvider> SetRequestProvider { get; set; }

        public Action<ITradingSettingsProvider> SetTradingSettingsProvider { get; set; }

        public Action<ITableManager> SetTableManager { get; set; }
    }
}
