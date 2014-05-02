using FxConnectProxy.ForexConnect.Utils;
// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using FxConnectProxy.Interfaces;
using fxcore2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.ForexConnect.Models
{
    class RequestProviderSettings
    {
        public O2GSession Session { get; set; }
        
        public O2GRequestFactory RequestFactory { get; set; }
        
        public ResponseReader Reader { get; set; }
        
        public IRequestProviderValidator Validator { get; set; }

        public Action CleanupMarketDataRequests { get; set; }

        public Action<MarketDataRequestItem> AddMakrtedDataRequestItem { get; set; }
    }
}
