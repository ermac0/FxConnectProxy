using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class InstrumentAccountBaseRequest : InstrumentBaseRequest
    {
        public AccountRow Account { get; set; }
    }
}
