// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class SystemPropertyRow : BaseRow
    {
        public override RowType RowType
        {
            get { return RowType.SystemProperty; }
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public SystemPropertyRow Clone()
        {
            return (SystemPropertyRow)this.MemberwiseClone();
        }
    }
}
