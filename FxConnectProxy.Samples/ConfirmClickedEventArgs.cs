using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Samples
{
    class ConfirmClickedEventArgs : EventArgs
    {
        public string Password { get; set; }
    }
}
