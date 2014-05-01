using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class LastOrderUpdateRow : OrderRow
    {
        public override RowType RowType
        {
            get { return RowType.LastOrderUpdate; }
        }

        public new LastOrderUpdateRow Clone()
        {
            return (LastOrderUpdateRow)this.MemberwiseClone();
        }
    }
}
