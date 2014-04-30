using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class RequestFailed
    {
        public string RequestID { get; set; }

        public string Error { get; set; }
    }
}
