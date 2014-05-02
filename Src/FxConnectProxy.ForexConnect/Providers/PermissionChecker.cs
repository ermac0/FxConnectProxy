// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fxcore2;
using FxConnectProxy.Interfaces;
using FxConnectProxy.Validators;
using FxConnectProxy.ForexConnect.Utils;

namespace FxConnectProxy.ForexConnect
{
    class PermissionChecker : IPermissionChecker
    {
        private O2GPermissionChecker Checker { get; set; }
        private IPermissionCheckerValidator Validator { get; set; }

        public PermissionChecker(O2GPermissionChecker checker, IPermissionCheckerValidator validator = null)
        {
            if (checker == null)
            {
                throw new ArgumentNullException("checker");
            }

            this.Checker = checker;
            this.Validator = validator ?? new PermissionCheckerValidator();    
        }

        public PermissionStatusResponse CanAcceptQuote(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canAcceptQuote(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanChangeEntryOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canChangeEntryOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanChangeMarketCloseOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canChangeMarketCloseOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanChangeMarketOpenOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canChangeMarketOpenOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanChangeNetCloseOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canChangeNetCloseOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanChangeNetStopLimitOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canChangeNetStopLimitOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanChangeOfferSubscription(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canChangeOfferSubscription(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanChangeStopLimitOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canChangeStopLimitOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanCreateEntryOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canCreateEntryOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanCreateMarketCloseOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canCreateMarketCloseOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanCreateMarketOpenOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canCreateMarketOpenOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanCreateNetCloseOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canCreateNetCloseOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanCreateNetStopLimitOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canCreateNetStopLimitOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanCreateOCO(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canCreateOCO(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanCreateOTO(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canCreateOTO(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanCreateStopLimitOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canCreateStopLimitOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanDeleteEntryOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canDeleteEntryOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanDeleteMarketCloseOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canDeleteMarketCloseOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanDeleteMarketOpenOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canDeleteMarketOpenOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanDeleteNetCloseOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canDeleteNetCloseOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanDeleteNetStopLimitOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canDeleteNetStopLimitOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanDeleteQuote(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canDeleteQuote(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanDeleteStopLimitOrder(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canDeleteStopLimitOrder(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanJoinToExistingContingencyGroup(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canJoinToExistingContingencyGroup(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanJoinToNewContingencyGroup(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canJoinToNewContingencyGroup(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanRemoveFromContingencyGroup(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canRemoveFromContingencyGroup(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanRequestQuote(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Checker.canRequestQuote(request.Instrument);

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanUseDynamicTrailingForEntryLimit()
        {
            var result = this.Checker.canUseDynamicTrailingForEntryLimit();

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanUseDynamicTrailingForEntryStop()
        {
            var result = this.Checker.canUseDynamicTrailingForEntryStop();

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanUseDynamicTrailingForLimit()
        {
            var result = this.Checker.canUseDynamicTrailingForLimit();

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanUseDynamicTrailingForStop()
        {
            var result = this.Checker.canUseDynamicTrailingForStop();

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanUseFluctuateTrailingForEntryLimit()
        {
            var result = this.Checker.canUseFluctuateTrailingForEntryLimit();

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanUseFluctuateTrailingForEntryStop()
        {
            var result = this.Checker.canUseFluctuateTrailingForEntryStop();

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanUseFluctuateTrailingForLimit()
        {
            var result = this.Checker.canUseFluctuateTrailingForLimit();

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }

        public PermissionStatusResponse CanUseFluctuateTrailingForStop()
        {
            var result = this.Checker.canUseFluctuateTrailingForStop();

            return new PermissionStatusResponse()
            {
                Status = Converters.GetPermissionStatus(result),
            };
        }
    }
}
