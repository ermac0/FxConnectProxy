using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class SummaryRow : BaseRow
    {
        public override RowType RowType
        {
            get { return RowType.Summary; }
        }

        public SummaryRow Clone()
        {
            return (SummaryRow)this.MemberwiseClone();
        }
    }
}
