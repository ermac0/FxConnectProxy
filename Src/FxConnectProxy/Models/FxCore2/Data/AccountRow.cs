// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxConnectProxy.Utils;

namespace FxConnectProxy
{
    public class AccountRow : BaseRow
    {
        public override RowType RowType
        {
            get { return RowType.Account; }
        }

        public string LeverageProfileID { get; set; }

        public string ManagerAccountID { get; set; }

        public bool MaintenanceFlag { get; set; }

        public int BaseUnitSize { get; set; }

        public int AmountLimit { get; set; }

        public AccountMaintenanceType MaintenanceType { get; set; }

        public DateTime LastMarginCallDate { get; set; }

        public string MarginCallFlag { get; set; }

        public double UsedMargin3 { get; set; }

        public double UsedMargin { get; set; }

        public double M2MEquity { get; set; }

        public double NonTradeEquity { get; set; }

        public double Balance { get; set; }

        public AccountKind AccountKind { get; set; }

        public string AccountName { get; set; }

        public string AccountID { get; set; }

        public AccountRow Clone()
        {
            return (AccountRow)this.MemberwiseClone();
        }
    }
}
