using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FxConnectProxy.Samples.Examples
{
    abstract class BaseExample : IExample
    {
        protected string User { get; set; }
        protected string Password { get; set; }
        protected string Url { get; set; }
        protected string Account { get; set; }
        
        private Thread Thread { get; set; }
        private ManualResetEvent TerminateEvent { get; set; }

        public BaseExample()
        {
            this.Thread = new Thread(new ThreadStart(this.ThreadProc));
            this.TerminateEvent = new ManualResetEvent(false);
            this.TerminateEvent.Reset();
        }

        public void Start(string user, string pass, string url, string account)
        {
            this.Account = account;
            this.Password = pass;
            this.Url = url;
            this.User = user;

            try
            {
                this.StartInternal();
            }
            catch (Exception ex)
            {
                this.LogInternal("Error: {0}", ex.Message);
                this.Stop();
                return;
            }

            this.Thread.Start();
        }

        protected abstract void StartInternal();

        public void Stop()
        {
            this.TerminateEvent.Set();
        }

        protected abstract void StopInternal();

        protected abstract void Cycle();

        public event EventHandler Stopped;

        public event EventHandler<LogEventArgs> Log;

        private void ThreadProc()
        {
            while (true)
            {
                try
                {
                    this.Cycle();
                }
                catch (Exception ex)
                {
                    this.LogInternal("Error: {0}", ex.Message);
                    this.LogInternal("Stopping...");
                    this.TerminateEvent.Set();
                    break;
                }

                if (this.TerminateEvent.WaitOne(20))
                {
                    break;
                }
            }

            try
            {
                this.StopInternal();
            }
            catch (Exception ex)
            {
                this.LogInternal("Error: {0}", ex.Message);
            }

            if (this.Stopped != null)
            {
                this.Stopped(this, null);
            }
        }

        protected void LogInternal(string text)
        {
            if (this.Log != null)
            {
                this.Log(this, new LogEventArgs()
                {
                    Text = string.IsNullOrEmpty(text) ? text : string.Format("[{0}]  {1}", DateTime.Now.ToString("HH:mm:ss"), text),
                });
            }
        }

        protected void LogInternal(string format, params object[] args)
        {
            var text = string.Format(format, args);
            this.LogInternal(text);
        }

        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract int Order { get; }

        public virtual bool IsHidden
        {
            get { return false; }
        }
    }
}
