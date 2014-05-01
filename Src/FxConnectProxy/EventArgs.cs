using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class EventArgs<T> : EventArgs
    {
        public T Value { get; set; }

        public EventArgs()
        {
        }

        public EventArgs(T arg)
        {
            this.Value = arg;
        }
    }
}
