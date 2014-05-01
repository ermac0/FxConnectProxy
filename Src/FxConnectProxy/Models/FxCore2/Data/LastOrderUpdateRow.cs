﻿// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
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
