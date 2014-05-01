﻿// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using FxConnectProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Validators
{
    public class PermissionCheckerValidator : IPermissionCheckerValidator
    {
        public virtual void Validate(InstrumentBaseRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (string.IsNullOrEmpty(request.Instrument))
            {
                throw new ArgumentNullException("Instrument");
            }
        }
    }
}
