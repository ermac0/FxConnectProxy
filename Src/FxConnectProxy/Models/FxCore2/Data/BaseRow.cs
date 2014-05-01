using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public abstract class BaseRow
    {
        public abstract RowType RowType { get; }

        public UpdateType UpdateType { get; set; }
    }
}
