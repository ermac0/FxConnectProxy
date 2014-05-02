// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FxConnectProxy.Interfaces;

namespace FxConnectProxy.ForexConnect.Tests.Validators
{
    [TestClass]
    public class TradingSettingsProviderValidatorTests
    {
        private const string __Type = "FxConnectProxy.ForexConnect.Validators.TradingSettingsProviderValidator";

        [TestMethod]
        public void ValidateInstrumentAccountBaseRequest()
        {
            // Null.
            {
                var v = Helpers.CreateInstance(__Type) as ITradingSettingsProviderValidator;
                InstrumentAccountBaseRequest r = null;
                
                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Instrument null.
            {
                var v = Helpers.CreateInstance(__Type) as ITradingSettingsProviderValidator;
                InstrumentAccountBaseRequest r = new InstrumentAccountBaseRequest();
                r.Instrument = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Instrument empty.
            {
                var v = Helpers.CreateInstance(__Type) as ITradingSettingsProviderValidator;
                InstrumentAccountBaseRequest r = new InstrumentAccountBaseRequest();
                r.Instrument = "";

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Account null.
            {
                var v = Helpers.CreateInstance(__Type) as ITradingSettingsProviderValidator;
                InstrumentAccountBaseRequest r = new InstrumentAccountBaseRequest();
                r.Instrument = "Test";
                r.Account = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Wrong account object type.
            {
                var v = Helpers.CreateInstance(__Type) as ITradingSettingsProviderValidator;
                InstrumentAccountBaseRequest r = new InstrumentAccountBaseRequest();
                r.Instrument = "Test";
                r.Account = new AccountRow();

                AssertEx.Throws<ArgumentException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Unable to test valid scenario, because instance of O2GAccountRow cannot be created
            // outside of ForexConnect.
        }
    }
}
