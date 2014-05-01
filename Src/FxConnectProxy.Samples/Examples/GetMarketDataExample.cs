// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using FxConnectProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Samples.Examples
{
    class GetMarketDataExample : BaseExample
    {
        private IFxConnectProxy Client { get; set; }
        private SessionStatus Status { get; set; }
        private bool Connecting { get; set; }
        private bool AskingForData { get; set; }

        protected override void StartInternal()
        {
            this.Client = new FxConnectProxy.ForexConnect.FxServiceProxy();

            this.Client.Session.DataReceived += this.OnDataReceived;
            this.Client.Session.LoginFailed += this.OnLoginFailed;
            this.Client.Session.SessionStatusChanged += this.OnSessionStatusChanged;
            this.Client.Session.RequestFailed += this.OnRequestFailed;
        }

        void OnRequestFailed(object sender, EventArgs<RequestFailed> e)
        {
            this.LogInternal("Request failed: {0}", e.Value.Error);
        }

        void OnSessionStatusChanged(object sender, EventArgs<SessionStatusChanged> e)
        {
            this.Status = e.Value.Status;

            switch (e.Value.Status)
            {
                case SessionStatus.Connecting:
                    this.LogInternal("Connecting to the server...");
                    break;

                case SessionStatus.Connected:
                    this.Connecting = false;
                    this.LogInternal("Connected.");
                    break;
            }
        }

        void OnLoginFailed(object sender, EventArgs<LoginFailed> e)
        {
            this.LogInternal("Login failed: {0}", e.Value.Error);
        }

        void OnDataReceived(object sender, EventArgs<DataReceived> e)
        {
            this.ProcessRow(e.Value.Row);
        }

        protected override void StopInternal()
        {
            this.Client.Session.Logout();

            this.Client.Session.DataReceived -= this.OnDataReceived;
            this.Client.Session.LoginFailed -= this.OnLoginFailed;
            this.Client.Session.SessionStatusChanged -= this.OnSessionStatusChanged;
            this.Client = null;
        }

        protected override void Cycle()
        {
            if (this.Status == SessionStatus.Disconnected && !this.Connecting)
            {
                this.Connecting = true;

                this.Client.Session.Login(new LoginRequest()
                {
                    AccountType = this.Account,
                    Password = this.Password,
                    Url = this.Url,
                    Username = this.User,
                });
            }
            else if (this.Status == SessionStatus.Connected && !this.AskingForData)
            {
                this.AskingForData = true;
                this.Client.Requests.MarketDataSnapshotRequest(new MarketDataSnapshotRequest()
                {
                    Instrument = "UK100",
                    Timeframe = Timeframe.Minutes15,
                    MaxBars = 50,
                });

                this.Client.Requests.MarketDataSnapshotRequest(new MarketDataSnapshotRequest()
                {
                    Instrument = "US30",
                    Timeframe = Timeframe.Minutes15,
                    MaxBars = 50,
                });
            }
        }

        private void ProcessRow(BaseRow row)
        {
            if (row == null)
            {
                return;
            }

            switch (row.RowType)
            {
                case RowType.MarketData:
                    {
                        var sb = new StringBuilder();
                        var r = row as MarketDataRow;

                        if (r.IsBar)
                        {
                            sb.AppendFormat("MarketData Instrument={0}, Time={1}, AskOpen=<b>{2}</b>, AskHigh={3}, AskLow={4}, AskClose=<b>{5}</b>, Volume={6}",
                                r.Instrument, r.Time.ToString("HH:mm"), r.AskOpen, r.AskHigh, r.AskLow, r.AskClose, r.Volume);
                        }
                        else
                        {
                            sb.AppendFormat("MarketData Instrument={0}, Time={1}, Ask={2}, Bid={3}",
                                r.Instrument, r.Time.ToString("HH:mm:ss"), r.Ask, r.Bid);
                        }

                        this.LogInternal(sb.ToString());
                    }
                    break;
            }
        }

        public override string Name
        {
            get { return "Get Market Data"; }
        }

        public override string Description
        {
            get { return "Tries to get historical market data for an instrument."; }
        }

        public override int Order
        {
            get { return 20; }
        }
    }
}
