// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using FxConnectProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Samples.Examples
{
    class LoginListenExample : BaseExample
    {
        private IFxConnectProxy Client { get; set; }
        private SessionStatus Status { get; set; }
        private bool Connecting { get; set; }
        private bool ObtainingAccount { get; set; }

        protected override void StartInternal()
        {
            this.Client = new FxConnectProxy.ForexConnect.FxServiceProxy();

            this.Client.Session.DataReceived += this.OnDataReceived;
            this.Client.Session.LoginFailed += this.OnLoginFailed;
            this.Client.Session.SessionStatusChanged += this.OnSessionStatusChanged;
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
                this.Client.Session.UseTableManager(new UseTableManagerRequest()
                {
                    UseTableManager = true,
                });

                this.Client.Session.Login(new LoginRequest()
                {
                    AccountType = this.Account,
                    Password = this.Password,
                    Url = this.Url,
                    Username = this.User,
                });
            }
            else if (this.Status == SessionStatus.Connected && this.Client.Session.TableManagerStatus == TableManagerStatus.Loaded && !this.ObtainingAccount)
            {
                this.ObtainingAccount = true;
                var data = this.Client.TableManager.GetTable(new GetTableRequest()
                {
                    Table = TableType.Accounts,
                });
            }
        }

        private void ProcessRow(BaseRow row)
        {
            if (row == null)
            {
                return;
            }

            var sb = new StringBuilder();

            sb.AppendFormat("Data received ({0}) ", row.RowType);

            switch (row.RowType)
            {
                case RowType.Offer:
                    {
                        var r = row as OfferRow;
                        sb.AppendFormat("Instrument={0}, Ask={1}, Bid={2}", r.Instrument, r.Ask, r.Bid);
                    }
                    break;

                case RowType.ClosedTrade:
                    {
                        var r = row as ClosedTradeRow;
                        sb.AppendFormat("TradeID={0}, Buy/Sell={1}, OpenRate={2}, CloseRate={3}, Profit/Loss={4}", r.TradeID, r.BuySell, r.OpenRate, r.CloseRate, r.GrossPL);
                    }
                    break;
            }

            this.LogInternal(sb.ToString());
        }

        public override string Name
        {
            get { return "Log-in and Listen"; }
        }

        public override string Description
        {
            get { return "Establishes a session and listens to all messages sent its way. Does not engage in any trades."; }
        }

        public override int Order
        {
            get { return 10; }
        }
    }
}
