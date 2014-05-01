// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FxConnectProxy.Samples
{
    static class Helpers
    {
        public static TimeoutHandle SetTimeout(Action action, int timeout)
        {
            return new TimeoutHandle(action, timeout);
        }

        public class TimeoutHandle
        {
            private readonly object _Sync = new object();

            private Thread Thread { get; set; }

            public bool HasFinished { get; private set; }

            public bool HasStarted { get; private set; }

            public TimeoutHandle(Action action, int timeout)
            {
                this.Thread = new Thread(() =>
                {
                    Thread.Sleep(timeout);

                    lock (this._Sync)
                    {
                        this.HasStarted = true;
                        try
                        {
                            action();
                        }
                        catch { }
                        this.HasFinished = true;
                    }
                });

                this.Thread.IsBackground = true;

                this.Thread.Start();
            }

            public void Stop()
            {
                lock (this._Sync)
                {
                    if (!this.HasStarted && !this.HasFinished)
                    {
                        if (this.Thread != null)
                        {
                            this.Thread.Abort();
                            this.Thread = null;
                        }
                    }
                }
            }
        }
    }
}
