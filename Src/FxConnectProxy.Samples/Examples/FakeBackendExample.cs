using FxConnectProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Samples.Examples
{
    class FakeBackendExample : BaseExample
    {
        private IFxConnectProxy Client { get; set; }
        private SessionStatus Status { get; set; }
        private bool Connecting { get; set; }
        private FakeBackend Backend { get; set; }

        protected override void StartInternal()
        {
            this.Backend = new FakeBackend();
            this.Client = this.Backend;

            this.Client.Session.DataReceived += this.OnDataReceived;
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

        void OnDataReceived(object sender, EventArgs<DataReceived> e)
        {
            this.ProcessRow(e.Value.Row);
        }

        protected override void StopInternal()
        {
            this.Client.Session.Logout();

            this.Client.Session.DataReceived -= this.OnDataReceived;
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

            this.Backend.Cycle();
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
                        sb.AppendFormat("Instrument={0}, Ask={1}, Bid={2}, Volume={3}, High={4}, Low={5}", r.Instrument, r.Ask, r.Bid, r.Volume, r.High, r.Low);
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
            get { return "Fake backend for testing"; }
        }

        public override string Description
        {
            get { return "Shows how to set up an instance of fake back end for testing. Fake backend sends Offers for BTC/USD instrument."; }
        }

        public override int Order
        {
            get { return 30; }
        }

        class FakeBackend : IFxConnectProxy, ISessionProvider
        {
            private ISessionProviderValidator Validator { get; set; }
            private DateTime NextOfferTime { get; set; }
            private int OfferStamp { get; set; }
            private double Ask { get; set; }
            private double Bid { get; set; }
            private double High { get; set; }
            private double Low { get; set; }
            private int Volume { get; set; }
            private const double Spread = 3.0;
            private Random Rnd { get; set; }
            private int QuoteID { get; set; }


            public event EventHandler<EventArgs<DataReceived>> DataReceived;

            public event EventHandler<EventArgs<SessionStatusChanged>> SessionStatusChanged;

#pragma warning disable 67
            public event EventHandler<EventArgs<TableManagerStatusChanged>> TableManagerStatusChanged;
            public event EventHandler<EventArgs<LoginFailed>> LoginFailed;
            public event EventHandler<EventArgs<RequestFailed>> RequestFailed;
#pragma warning restore 67

            public FakeBackend()
            {
                this.Validator = new SessionProviderValidator();
                this.Rnd = new Random();

                this.Setup();
            }

            private void Setup()
            {
                this.Ask = 500d + (this.Rnd.Next(20000) / 100d);
                this.Bid = this.Ask - Spread + (-0.5 + this.Rnd.Next(10) / 10d);
                this.High = int.MinValue;
                this.Low = int.MaxValue;
            }

            public void Login(LoginRequest request)
            {
                this.Validator.Validate(request);

                var t = this;

                this.SetSessionStatus(FxConnectProxy.SessionStatus.Connecting);

                Helpers.SetTimeout(() =>
                    {
                        t.SetSessionStatus(FxConnectProxy.SessionStatus.Connected);
                    }, 800);
            }

            private void SetSessionStatus(FxConnectProxy.SessionStatus sessionStatus)
            {
                this.SessionStatus = sessionStatus;

                if (this.SessionStatusChanged != null)
                {
                    this.SessionStatusChanged(this, new EventArgs<SessionStatusChanged>(new SessionStatusChanged()
                    {
                        Status = sessionStatus,
                    }));
                }
            }

            public void Logout()
            {
                this.SetSessionStatus(FxConnectProxy.SessionStatus.Disconnecting);

                var t = this;

                Helpers.SetTimeout(() =>
                {
                    t.SetSessionStatus(FxConnectProxy.SessionStatus.Disconnected);
                }, 800);
            }

            public void SetNumberOfReconnections(SetNumberOfReconnectionsRequest request)
            {
                throw new NotImplementedException();
            }

            public void SetProxy(SetProxyRequest request)
            {
                throw new NotImplementedException();
            }

            public GetPriceUpdateModeResponse GetPriceUpdateMode()
            {
                throw new NotImplementedException();
            }

            public GetReportURLResponse GetReportURL(GetReportURLRequest request)
            {
                throw new NotImplementedException();
            }

            public GetServerTimeResponse GetServerTime()
            {
                throw new NotImplementedException();
            }

            public void SetPriceUpdateMode(SetPriceUpdateModeRequest request)
            {
                throw new NotImplementedException();
            }

            public void SetTradingSession(SetTradingSessionRequest request)
            {
                throw new NotImplementedException();
            }

            public void UseTableManager(UseTableManagerRequest request)
            {
                throw new NotImplementedException();
            }

            public ILoginRulesProvider LoginRules
            {
                get;
                private set;
            }

            public ITradingSettingsProvider TradingSettings
            {
                get;
                private set;
            }

            public IPermissionChecker PermissionChecker
            {
                get;
                private set;
            }

            public ITableManager TableManager
            {
                get;
                private set;
            }

            public SessionStatus SessionStatus
            {
                get;
                private set;
            }

            public TableManagerStatus TableManagerStatus
            {
                get;
                private set;
            }

            public bool UsingTableManager
            {
                get;
                private set;
            }

            public RequestResponse MarketDataSnapshotRequest(MarketDataSnapshotRequest request)
            {
                throw new NotImplementedException();
            }

            public RequestResponse OrderRequest(OrderRequest request)
            {
                throw new NotImplementedException();
            }

            public RequestResponse RefreshTableRequest(RefreshTableRequest request)
            {
                throw new NotImplementedException();
            }

            public RequestResponse RefreshTableByAccountRequest(RefreshTableByAccountRequest request)
            {
                throw new NotImplementedException();
            }

            public GetLastErrorResponse GetLastError()
            {
                throw new NotImplementedException();
            }

            public void Cycle()
            {
                if (this.SessionStatus == FxConnectProxy.SessionStatus.Connected)
                {
                    this.SendOffer();
                }
            }

            private void SendOffer()
            {
                if (this.NextOfferTime > DateTime.Now)
                {
                    // Not yet.
                    return;
                }

                // Update price
                if (this.Rnd.Next(30) != 1)
                {
                    var upDown = this.Rnd.Next(2) == 0 ? -1d : 1d;
                    var max = Spread * 6 + ((-Spread/2d) + this.Rnd.Next((int)Math.Ceiling(Spread * 10)) / 10d);

                    var change = 0.7 * (this.Rnd.Next((int)Spread * 10) / 10d) +
                        (this.Rnd.Next(5) == 1 ? 1.6 : 0) * (this.Rnd.Next((int)Spread * 10) / 10d) +
                        (this.Rnd.Next(30) == 1 ? 2.9 : 0) * (this.Rnd.Next((int)Spread * 10) / 10d);

                    this.Ask = Math.Round(Math.Max(77d, this.Ask + Math.Min(max, change) * upDown), 2, MidpointRounding.AwayFromZero);
                    this.Bid = Math.Round(this.Ask - Spread + (-0.5 + this.Rnd.Next(10) / 10d) * (this.Rnd.Next(10) == 1 ? 1d : 0), 2, MidpointRounding.AwayFromZero);
                }

                var volume = 1 + this.Rnd.Next(3) + (this.Rnd.Next(15) == 1 ? this.Rnd.Next(5) : 0);

                var stamp = DateTime.Now.Hour * 100 + DateTime.Now.Minute;
                if (this.OfferStamp != stamp)
                {
                    this.Volume = 0;
                    this.OfferStamp = stamp;
                }

                this.High = Math.Max(this.High, this.Ask);
                this.Low = Math.Min(this.Low, this.Bid);

                this.Volume += volume;

                this.NextOfferTime = DateTime.Now.AddMilliseconds(600 + (this.Rnd.Next(30) / 10d) * this.Rnd.Next(400));

                if (this.DataReceived != null)
                {
                    this.DataReceived(this, new EventArgs<DataReceived>(new DataReceived()
                    {
                        Row = new OfferRow()
                        {
                            Ask = this.Ask,
                            AskTradable = PriceTradable.Tradable,
                            Bid = this.Bid,
                            BidTradable = PriceTradable.Tradable,
                            BuyInterest = 0,
                            ContractCurrency = "USD",
                            ContractMultiplier = 1,
                            Digits = 2,
                            High = this.High,
                            Instrument = "BTC/USD",
                            InstrumentType = InstrumentType.Forex,
                            Low = this.Low,
                            OfferID = "9999",
                            PointSize = 0.01,
                            QuoteID = "QBU_" + ++this.QuoteID,
                            SellInterest = 0,
                            Time = DateTime.Now,
                            TradingStatus = InstrumentTradingStatus.Open,
                            Volume = this.Volume,
                        },
                    }));
                }
            }

            public IRequestProvider Requests
            {
                get { throw new NotImplementedException(); }
            }

            public ISessionProvider Session
            {
                get { return this; }
            }
        }
    }
}
