// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fxcore2;
using FxConnectProxy.Validators;
using FxConnectProxy.Interfaces;
using FxConnectProxy.ForexConnect.Utils;

namespace FxConnectProxy.ForexConnect
{
    class LoginRulesProvider : ILoginRulesProvider
    {
        private O2GLoginRules Rules { get; set; }
        private ILoginRulesProviderValidator Validator { get; set; }
        private ResponseReader Reader { get; set; }

        public LoginRulesProvider(O2GLoginRules rules, ResponseReader reader, ILoginRulesProviderValidator validator = null)
        {
            if (rules == null)
            {
                throw new ArgumentNullException("rules");
            }

            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            this.Rules = rules;
            this.Reader = reader;
            this.Validator = validator ?? new LoginRulesProviderValidator();
        }

        public GetTableResponse GetTableRefresh(GetTableRequest request)
        {
            this.Validator.Validate(request);

            var response = this.Rules.getTableRefreshResponse(Converters.GetTableType(request.Table));

            return new GetTableResponse()
            {
                Rows = this.Reader.ReadResponse(response),
            };
        }

        public IsTableLoadedByDefaultResponse IsTableLoadedByDefault(GetTableRequest request)
        {
            this.Validator.Validate(request);

            var result = this.Rules.isTableLoadedByDefault(Converters.GetTableType(request.Table));

            return new IsTableLoadedByDefaultResponse()
            {
                IsLoaded = result,
            };
        }

        public GetTableResponse GetSystemProperties()
        {
            var response = this.Rules.getSystemPropertiesResponse();
            
            return new GetTableResponse()
            {
                Rows = this.Reader.ReadResponse(response),
            };
        }
    }
}
