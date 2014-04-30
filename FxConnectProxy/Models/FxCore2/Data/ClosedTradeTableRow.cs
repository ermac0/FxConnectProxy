using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class ClosedTradeTableRow : ClosedTradeRow
    {
        public double PL { get; set; }

        public new ClosedTradeTableRow Clone()
        {
            return (ClosedTradeTableRow)this.MemberwiseClone();
        }
    }
}
