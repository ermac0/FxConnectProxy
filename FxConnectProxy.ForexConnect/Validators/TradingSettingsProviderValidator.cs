﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.ForexConnect.Validators
{
    class TradingSettingsProviderValidator : FxConnectProxy.Validators.TradingSettingsProviderValidator
    {
        public override void Validate(InstrumentAccountBaseRequest request)
        {
            base.Validate(request);

            this.ValidateAccountRow(request.Account);
        }

        private void ValidateAccountRow(AccountRow account)
        {
            if (account is AccountRowEx && (account as AccountRowEx)._FxAccountRow != null)
            {
                return;
            }

            if (account is AccountTableRowEx && (account as AccountTableRowEx)._FxAccountRow != null)
            {
                return;
            }

            throw new ArgumentException("Only AccountRow obtained from the client can be used.", "Account");
        }
    }
}
