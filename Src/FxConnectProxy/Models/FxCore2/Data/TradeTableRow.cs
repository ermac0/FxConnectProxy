using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class TradeTableRow : TradeRow
    {
        public double Limit { get; set; }

        public double Stop { get; set; }

        public double Close { get; set; }

        public double GrossPL { get; set; }

        public double PL { get; set; }

        public new TradeTableRow Clone()
        {
            return (TradeTableRow)this.MemberwiseClone();
        }
    }
}
