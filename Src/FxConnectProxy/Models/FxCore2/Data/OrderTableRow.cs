// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class OrderTableRow : OrderRow
    {
        public double StopTrailRate { get; set; }

        public int StopTrailStep { get; set; }

        public double Limit { get; set; }

        public double Stop { get; set; }

        public new OrderTableRow Clone()
        {
            return (OrderTableRow)this.MemberwiseClone();
        }
    }

}
