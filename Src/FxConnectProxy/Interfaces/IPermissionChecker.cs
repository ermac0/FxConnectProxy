// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface IPermissionChecker
    {
        PermissionStatusResponse CanAcceptQuote(InstrumentBaseRequest request);
        PermissionStatusResponse CanChangeEntryOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanChangeMarketCloseOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanChangeMarketOpenOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanChangeNetCloseOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanChangeNetStopLimitOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanChangeOfferSubscription(InstrumentBaseRequest request);
        PermissionStatusResponse CanChangeStopLimitOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanCreateEntryOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanCreateMarketCloseOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanCreateMarketOpenOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanCreateNetCloseOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanCreateNetStopLimitOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanCreateOCO(InstrumentBaseRequest request);
        PermissionStatusResponse CanCreateOTO(InstrumentBaseRequest request);
        PermissionStatusResponse CanCreateStopLimitOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanDeleteEntryOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanDeleteMarketCloseOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanDeleteMarketOpenOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanDeleteNetCloseOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanDeleteNetStopLimitOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanDeleteQuote(InstrumentBaseRequest request);
        PermissionStatusResponse CanDeleteStopLimitOrder(InstrumentBaseRequest request);
        PermissionStatusResponse CanJoinToExistingContingencyGroup(InstrumentBaseRequest request);
        PermissionStatusResponse CanJoinToNewContingencyGroup(InstrumentBaseRequest request);
        PermissionStatusResponse CanRemoveFromContingencyGroup(InstrumentBaseRequest request);
        PermissionStatusResponse CanRequestQuote(InstrumentBaseRequest request);
        PermissionStatusResponse CanUseDynamicTrailingForEntryLimit();
        PermissionStatusResponse CanUseDynamicTrailingForEntryStop();
        PermissionStatusResponse CanUseDynamicTrailingForLimit();
        PermissionStatusResponse CanUseDynamicTrailingForStop();
        PermissionStatusResponse CanUseFluctuateTrailingForEntryLimit();
        PermissionStatusResponse CanUseFluctuateTrailingForEntryStop();
        PermissionStatusResponse CanUseFluctuateTrailingForLimit();
        PermissionStatusResponse CanUseFluctuateTrailingForStop();
    }
}
