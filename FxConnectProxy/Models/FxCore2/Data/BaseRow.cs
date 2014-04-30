using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class BaseRow
    {
        public virtual RowType RowType
        {
            get { return RowType.Unknown; }
        }

        public UpdateType UpdateType { get; set; }
    }
}
