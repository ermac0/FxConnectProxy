using FxConnectProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Validators
{
    public class SessionProviderValidator : ISessionProviderValidator
    {
        public void Validate(LoginRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (string.IsNullOrEmpty(request.Username))
            {
                throw new ArgumentNullException("Username");
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException("Password");
            }

            if (string.IsNullOrEmpty(request.Url))
            {
                throw new ArgumentNullException("Url");
            }

            if (string.IsNullOrEmpty(request.AccountType))
            {
                throw new ArgumentNullException("AccountType");
            }
        }

        public void Validate(SetNumberOfReconnectionsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
        }

        public void Validate(SetProxyRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (string.IsNullOrEmpty(request.Host))
            {
                throw new ArgumentNullException("Host");
            }

            if (request.Port < 1 || request.Port > 65535)
            {
                throw new ArgumentOutOfRangeException("Port", "Port should be between 1 and 65535.");
            }
        }

        public virtual void Validate(GetReportURLRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Account == null)
            {
                throw new ArgumentNullException("Account");
            }
        }

        public void Validate(SetPriceUpdateModeRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
        }

        public void Validate(SetTradingSessionRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (string.IsNullOrEmpty(request.SessionId))
            {
                throw new ArgumentNullException("SessionId");
            }
        }

        public void Validate(UseTableManagerRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
        }
    }
}
