using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class RefreshTableByAccountRequest
    {
        public TableType Table { get; set; }

        public string AccountID { get; set; }
    }
}
