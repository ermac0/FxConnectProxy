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
