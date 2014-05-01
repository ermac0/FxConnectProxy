// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FxConnectProxy.Validators;

namespace FxConnectProxy.Tests.Validators
{
    [TestClass]
    public class SessionProviderValidatorTests
    {
        [TestMethod]
        public void ValidateLoginRequest()
        {
            // Null.
            {
                var v = new SessionProviderValidator();
                LoginRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                    {
                        v.Validate(r);
                    });
            }

            // Username null.
            {
                var v = new SessionProviderValidator();
                LoginRequest r = new LoginRequest();
                r.Username = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Username empty.
            {
                var v = new SessionProviderValidator();
                LoginRequest r = new LoginRequest();
                r.Username = "";

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Password null.
            {
                var v = new SessionProviderValidator();
                LoginRequest r = new LoginRequest();
                r.Username = "user";
                r.Password = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Password empty.
            {
                var v = new SessionProviderValidator();
                LoginRequest r = new LoginRequest();
                r.Username = "user";
                r.Password = "";

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Url null.
            {
                var v = new SessionProviderValidator();
                LoginRequest r = new LoginRequest();
                r.Username = "user";
                r.Password = "pass";
                r.Url = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Url empty.
            {
                var v = new SessionProviderValidator();
                LoginRequest r = new LoginRequest();
                r.Username = "user";
                r.Password = "pass";
                r.Url = "";

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // AccountType null.
            {
                var v = new SessionProviderValidator();
                LoginRequest r = new LoginRequest();
                r.Username = "user";
                r.Password = "pass";
                r.Url = "http://example.org";
                r.AccountType = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // AccountType empty.
            {
                var v = new SessionProviderValidator();
                LoginRequest r = new LoginRequest();
                r.Username = "user";
                r.Password = "pass";
                r.Url = "http://example.org";
                r.AccountType = "";

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                var v = new SessionProviderValidator();
                LoginRequest r = new LoginRequest();
                r.Username = "user";
                r.Password = "pass";
                r.Url = "http://example.org";
                r.AccountType = "Demo";

                v.Validate(r);
            }
        }

        [TestMethod]
        public void ValidateSetNumberOfReconnectionsRequest()
        {
            // Null.
            {
                var v = new SessionProviderValidator();
                SetNumberOfReconnectionsRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                var v = new SessionProviderValidator();
                SetNumberOfReconnectionsRequest r = new SetNumberOfReconnectionsRequest();
                r.Number = 10;

                v.Validate(r);
            }
        }

        [TestMethod]
        public void ValidateSetProxyRequest()
        {
            // Null.
            {
                var v = new SessionProviderValidator();
                SetProxyRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Host null.
            {
                var v = new SessionProviderValidator();
                SetProxyRequest r = new SetProxyRequest();
                r.Host = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Host empty.
            {
                var v = new SessionProviderValidator();
                SetProxyRequest r = new SetProxyRequest();
                r.Host = "";

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Port less than 1.
            {
                var v = new SessionProviderValidator();
                SetProxyRequest r = new SetProxyRequest();
                r.Host = "example.org";
                r.Port = 0;

                AssertEx.Throws<ArgumentOutOfRangeException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Port greater than 65535.
            {
                var v = new SessionProviderValidator();
                SetProxyRequest r = new SetProxyRequest();
                r.Host = "example.org";
                r.Port = 66536;

                AssertEx.Throws<ArgumentOutOfRangeException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                var v = new SessionProviderValidator();
                SetProxyRequest r = new SetProxyRequest();
                r.Host = "example.org";
                r.Port = 7777;

                v.Validate(r);
            }
        }

        [TestMethod]
        public void ValidateGetReportURLRequest()
        {
            // Null.
            {
                var v = new SessionProviderValidator();
                GetReportURLRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Account null.
            {
                var v = new SessionProviderValidator();
                GetReportURLRequest r = new GetReportURLRequest();
                r.Account = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                var v = new SessionProviderValidator();
                GetReportURLRequest r = new GetReportURLRequest();
                r.Account = new AccountRow();

                v.Validate(r);
            }
        }

        [TestMethod]
        public void ValidateSetPriceUpdateModeRequest()
        {
            // Null.
            {
                var v = new SessionProviderValidator();
                SetPriceUpdateModeRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                var v = new SessionProviderValidator();
                SetPriceUpdateModeRequest r = new SetPriceUpdateModeRequest();

                v.Validate(r);
            }
        }

        [TestMethod]
        public void ValidateSetTradingSessionRequest()
        {
            // Null.
            {
                var v = new SessionProviderValidator();
                SetTradingSessionRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // SessionId null.
            {
                var v = new SessionProviderValidator();
                SetTradingSessionRequest r = new SetTradingSessionRequest();
                r.SessionId = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // SessionId empty.
            {
                var v = new SessionProviderValidator();
                SetTradingSessionRequest r = new SetTradingSessionRequest();
                r.SessionId = "";

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                var v = new SessionProviderValidator();
                SetTradingSessionRequest r = new SetTradingSessionRequest();
                r.SessionId = "qwerty";

                v.Validate(r);
            }
        }

        [TestMethod]
        public void ValidateUseTableManagerRequest()
        {
            // Null.
            {
                var v = new SessionProviderValidator();
                UseTableManagerRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                var v = new SessionProviderValidator();
                UseTableManagerRequest r = new UseTableManagerRequest();

                v.Validate(r);
            }
        }
    }
}
