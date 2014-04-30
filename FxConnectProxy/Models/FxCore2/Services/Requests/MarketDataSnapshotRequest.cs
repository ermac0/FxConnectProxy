using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class MarketDataSnapshotRequest
    {
        public string Instrument { get; set; }

        public Timeframe Timeframe { get; set; }

        public string CustomTimeframeId { get; set; }

        public int MaxBars { get; set; }

        public DateTime TimeFrom { get; set; }

        public DateTime TimeTo { get; set; }

        public bool IncludeWeekends { get; set; }
    }
}
