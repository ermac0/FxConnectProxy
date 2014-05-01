using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Samples
{
    interface IExample
    {
        string Name { get; }
        string Description { get; }
        bool IsHidden { get; }
        int Order { get; }

        void Start(string user, string pass, string url, string account);
        void Stop();

        event EventHandler Stopped;
        event EventHandler<LogEventArgs> Log;
    }
}
