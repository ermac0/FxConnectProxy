using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.ForexConnect
{
    class AccountRowEx : AccountRow
    {
        /// <summary>
        /// FxCore2 requires O2GAccountRow to be passed to some methods, so we need to retain that.
        /// </summary>
        internal fxcore2.O2GAccountRow _FxAccountRow { get; set; }
    }
}
