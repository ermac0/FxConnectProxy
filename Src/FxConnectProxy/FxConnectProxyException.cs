using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    [Serializable]
    public class FxConnectProxyException : Exception
    {
        public FxConnectProxyExceptionCode ErrorCode { get; private set; }

        public FxConnectProxyException()
        {
            this.ErrorCode = FxConnectProxyExceptionCode.Default;
        }

        public FxConnectProxyException(string message)
            : base(message)
        {
        }

        public FxConnectProxyException(FxConnectProxyExceptionCode code)
        {
            this.ErrorCode = code;
        }

        public FxConnectProxyException(string message, FxConnectProxyExceptionCode code)
            : base(message)
        {
            this.ErrorCode = code;
        }
    }

    public enum FxConnectProxyExceptionCode
    {
        Default = 0,
        TableManagerNotInitialized = 1,
        CannotChangeOnActiveSession = 2,
    }
}
