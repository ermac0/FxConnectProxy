using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.ForexConnect
{
    /// <summary>
    /// Used to store instrument for historical price requests, because they (response) don't contain
    /// that information.
    /// </summary>
    class MarketDataRequestItem
    {
        public string RequestID { get; set; }

        public DateTime Time { get; set; }

        public string Instrument { get; set; }
    }
}
