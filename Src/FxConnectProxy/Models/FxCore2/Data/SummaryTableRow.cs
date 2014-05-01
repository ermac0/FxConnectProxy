using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class SummaryTableRow : SummaryRow
    {
        public double NetPL { get; set; }

        public double GrossPL { get; set; }

        public double Amount { get; set; }

        public double BuyNetPL { get; set; }

        public double BuyAmount { get; set; }

        public double BuyAvgOpen { get; set; }

        public double SellClose { get; set; }

        public double BuyClose { get; set; }

        public double SellAvgOpen { get; set; }

        public double SellAmount { get; set; }

        public double SellNetPL { get; set; }

        public string Instrument { get; set; }

        public int DefaultSortOrder { get; set; }

        public string OfferID { get; set; }

        public new SummaryTableRow Clone()
        {
            return (SummaryTableRow)this.MemberwiseClone();
        }
    }
}
