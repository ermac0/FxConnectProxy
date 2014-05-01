// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface ITradingSettingsProvider
    {
        GetBaseUnitSizeResponse GetBaseUnitSize(InstrumentAccountBaseRequest request);
        GetDistanceResponse GetCondDistEntryLimit(InstrumentBaseRequest request);
        GetDistanceResponse GetCondDistEntryStop(InstrumentBaseRequest request);
        GetDistanceResponse GetCondDistLimitForTrade(InstrumentBaseRequest request);
        GetDistanceResponse GetCondDistStopForTrade(InstrumentBaseRequest request);
        GetMarginsResponse GetMargins(InstrumentAccountBaseRequest request);
        GetMarketStatusResponse GetMarketStatus(InstrumentBaseRequest request);
        GetQuantityResponse GetMaxQuantity(InstrumentAccountBaseRequest request);
        GetStepResponse GetMaxTrailingStep();
        GetQuantityResponse GetMinQuantity(InstrumentAccountBaseRequest request);
        GetStepResponse GetMinTrailingStep();
        GetMMRResponse GetMMR(InstrumentAccountBaseRequest request);
    }
}
