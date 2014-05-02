// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fxcore2;
using FxConnectProxy.Interfaces;
using FxConnectProxy.ForexConnect.Validators;
using FxConnectProxy.ForexConnect.Utils;

namespace FxConnectProxy.ForexConnect
{
    class TradingSettingsProvider : ITradingSettingsProvider
    {
        private O2GTradingSettingsProvider Provider { get; set; }
        private ITradingSettingsProviderValidator Validator { get; set; }

        public TradingSettingsProvider(O2GTradingSettingsProvider provider, ITradingSettingsProviderValidator validator = null)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            this.Provider = provider;
            this.Validator = validator ?? new TradingSettingsProviderValidator();
        }

        public GetBaseUnitSizeResponse GetBaseUnitSize(InstrumentAccountBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Provider.getBaseUnitSize(request.Instrument, Helpers.GetAccountRow(request.Account));

            return new GetBaseUnitSizeResponse()
            {
                BaseUnitSize = result,
            };
        }

        public GetDistanceResponse GetCondDistEntryLimit(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Provider.getCondDistEntryLimit(request.Instrument);

            return new GetDistanceResponse()
            {
                Distance = result,
            };
        }

        public GetDistanceResponse GetCondDistEntryStop(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Provider.getCondDistEntryStop(request.Instrument);

            return new GetDistanceResponse()
            {
                Distance = result,
            };
        }

        public GetDistanceResponse GetCondDistLimitForTrade(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Provider.getCondDistLimitForTrade(request.Instrument);

            return new GetDistanceResponse()
            {
                Distance = result,
            };
        }

        public GetDistanceResponse GetCondDistStopForTrade(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Provider.getCondDistStopForTrade(request.Instrument);

            return new GetDistanceResponse()
            {
                Distance = result,
            };
        }

        public GetMarginsResponse GetMargins(InstrumentAccountBaseRequest request)
        {
            this.Validator.Validate(request);

            double mmr = 0;
            double emr = 0;
            double lmr = 0;

            var result = this.Provider.getMargins(request.Instrument, Helpers.GetAccountRow(request.Account), ref mmr, ref emr, ref lmr);

            return new GetMarginsResponse()
            {
                EMR = emr,
                LMR = lmr,
                MMR = mmr,
                ThreeMarginPolicy = result,
            };
        }

        public GetMarketStatusResponse GetMarketStatus(InstrumentBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Provider.getMarketStatus(request.Instrument);

            return new GetMarketStatusResponse()
            {
                Status = ConvertersInternal.GetMarketStatus(result),
            };
        }

        public GetQuantityResponse GetMaxQuantity(InstrumentAccountBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Provider.getMaxQuantity(request.Instrument, Helpers.GetAccountRow(request.Account));

            return new GetQuantityResponse()
            {
                Quantity = result,
            };
        }

        public GetStepResponse GetMaxTrailingStep()
        {
            var result = this.Provider.getMaxTrailingStep();

            return new GetStepResponse()
            {
                Step = result,
            };
        }

        public GetQuantityResponse GetMinQuantity(InstrumentAccountBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Provider.getMinQuantity(request.Instrument, Helpers.GetAccountRow(request.Account));

            return new GetQuantityResponse()
            {
                Quantity = result,
            };
        }

        public GetStepResponse GetMinTrailingStep()
        {
            var result = this.Provider.getMinTrailingStep();

            return new GetStepResponse()
            {
                Step = result,
            };
        }

        public GetMMRResponse GetMMR(InstrumentAccountBaseRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Provider.getMMR(request.Instrument, Helpers.GetAccountRow(request.Account));

            return new GetMMRResponse()
            {
                MMR = result,
            };
        }
    }
}
