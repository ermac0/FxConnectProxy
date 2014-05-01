// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class MarketDataRow : BaseRow
    {
        public override RowType RowType
        {
            get
            {
                return RowType.MarketData;
            }
        }

        public virtual string Instrument { get; set; }

        public virtual DateTime Time { get; set; }

        public virtual bool IsBar { get; set; }

        public virtual double Ask { get; set; }

        public virtual double Bid { get; set; }

        public virtual double AskOpen { get; set; }

        public virtual double AskClose { get; set; }

        public virtual double AskLow { get; set; }

        public virtual double AskHigh { get; set; }

        public virtual double BidOpen { get; set; }

        public virtual double BidClose { get; set; }

        public virtual double BidLow { get; set; }

        public virtual double BidHigh { get; set; }

        public virtual int Volume { get; set; }

        public MarketDataRow Clone()
        {
            return (MarketDataRow)this.MemberwiseClone();
        }
    }
}
