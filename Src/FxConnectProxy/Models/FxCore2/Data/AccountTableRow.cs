// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class AccountTableRow : AccountRow
    {
        public double GrossPL { get; set; }

        public double UsableMargin { get; set; }

        public double DayPL { get; set; }

        public double Equity { get; set; }

        public new AccountTableRow Clone()
        {
            return (AccountTableRow)this.MemberwiseClone();
        }
    }
}
