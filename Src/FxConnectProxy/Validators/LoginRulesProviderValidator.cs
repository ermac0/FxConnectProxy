// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using FxConnectProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Validators
{
    public class LoginRulesProviderValidator : ILoginRulesProviderValidator
    {
        public void Validate(GetTableRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Table == TableType.Unknown)
            {
                throw new ArgumentOutOfRangeException("Table");
            }
        }
    }
}
