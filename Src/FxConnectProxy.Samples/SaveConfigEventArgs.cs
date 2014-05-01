using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Samples
{
    class SaveConfigEventArgs : EventArgs
    {
        public Config Config { get; set; }
    }
}
