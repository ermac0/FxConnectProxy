// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class OfferTableRow : OfferRow
    {
        public double PipCost { get; set; }

        public new OfferTableRow Clone()
        {
            return (OfferTableRow)this.MemberwiseClone();
        }
    }
}
