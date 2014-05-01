using FxConnectProxy.ForexConnect.Models;
using FxConnectProxy.Interfaces;
using FxConnectProxy.Validators;
using fxcore2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.ForexConnect.Providers
{
    class SessionProvider : ISessionProvider
    {
        /// <summary>
        /// Time (in seconds) after which requests are removed from MarketDataRequests.
        /// </summary>
        private const int __MarketDataRequestTimeout = 300;

        private Dictionary<string, MarketDataRequestItem> MarketDataRequests { get; set; }

        #region Initial objects
        // We keep initial objects for testing purposes - if we're unit testing the client
        // we may want to pass fake providers, but because they're initiated when session
        // establishes connection, that's why we need to keep hold of them until then.
        private ILoginRulesProvider InitialLoginRulesProvider { get; set; }
        private ITradingSettingsProvider InitialTradingSettingsProvider { get; set; }
        private IPermissionChecker InitialPermissionChecker { get; set; }
        private ITableManager InitialTableManager { get; set; }
        private IRequestProvider InitialRequestProvider { get; set; }
        #endregion

        private O2GSession FxSession { get; set; }
        private O2GResponseReaderFactory FxResponseFactory { get; set; }
        private O2GRequestFactory FxRequestFactory { get; set; }
        private ResponseReader ResponseReader { get; set; }

        private SessionFeedbackContext FeedbackContext { get; set; }

        private ISessionProviderValidator Validator { get; set; }

        public SessionProvider(ILoginRulesProvider loginRules, ITradingSettingsProvider tradingSettings,
            IPermissionChecker permissionChecker, IRequestProvider requests, ITableManager tableManager,
            ISessionProviderValidator validator, SessionFeedbackContext feedbackContext)
        {
            if (feedbackContext == null)
            {
                throw new ArgumentNullException("feedbackContext");
            }

            this.InitialLoginRulesProvider = loginRules;
            this.InitialPermissionChecker = permissionChecker;
            this.InitialTableManager = tableManager;
            this.InitialTradingSettingsProvider = tradingSettings;
            this.InitialRequestProvider = requests;
            
            this.Validator = validator;
            this.FeedbackContext = feedbackContext;

            this.InitSession();
            this.MarketDataRequests = new Dictionary<string, MarketDataRequestItem>(StringComparer.OrdinalIgnoreCase);
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
        public IRequestProvider Requests
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

        public void Login(LoginRequest request)
        {
            this.Validator.Validate(request);

            this.FxSession.login(request.Username, request.Password, request.Url, request.AccountType);
        }

        public void Logout()
        {
            this.FxSession.logout();
        }

        public void SetNumberOfReconnections(SetNumberOfReconnectionsRequest request)
        {
            this.Validator.Validate(request);

            O2GTransport.setNumberOfReconnections(request.Number);
        }

        public void SetProxy(SetProxyRequest request)
        {
            this.Validator.Validate(request);

            O2GTransport.setProxy(request.Host, request.Port, request.User, request.Password);
        }

        public GetPriceUpdateModeResponse GetPriceUpdateMode()
        {
            var result = this.FxSession.getPriceUpdateMode();

            return new GetPriceUpdateModeResponse()
            {
                PriceUpdateMode = Converters.GetPriceUpdateMode(result),
            };
        }

        public GetReportURLResponse GetReportURL(GetReportURLRequest request)
        {
            this.Validator.Validate(request);

            var result = this.FxSession.getReportURL(Helpers.GetAccountRow(request.Account), request.DateFrom, request.DateTo,
                Converters.GetReportFormat(request.Format), Converters.GetReportType(request.Type),
                Converters.GetReportLanguage(request.Language), request.CodePage);

            return new GetReportURLResponse()
            {
                Url = result,
            };
        }

        public GetServerTimeResponse GetServerTime()
        {
            var result = this.FxSession.getServerTime();

            return new GetServerTimeResponse()
            {
                Time = result,
            };
        }

        public void SetPriceUpdateMode(SetPriceUpdateModeRequest request)
        {
            this.Validator.Validate(request);

            this.FxSession.setPriceUpdateMode(Converters.GetPriceUpdateMode(request.PriceUpdateMode));
        }

        public void SetTradingSession(SetTradingSessionRequest request)
        {
            this.Validator.Validate(request);

            this.FxSession.setTradingSession(request.SessionId, request.Pin == null ? string.Empty : request.Pin);
        }

        public void UseTableManager(UseTableManagerRequest request)
        {
            if (this.SessionStatus != FxConnectProxy.SessionStatus.Disconnected)
            {
                throw new FxConnectProxyException(FxConnectProxyExceptionCode.CannotChangeOnActiveSession);
            }

            this.Validator.Validate(request);

            this.UsingTableManager = request.UseTableManager;
            this.FxSession.useTableManager(request.UseTableManager ? O2GTableManagerMode.Yes : O2GTableManagerMode.No, null);
        }

        private void InitSession()
        {
            if (this.FxSession != null)
            {
                this.DeinitSession();
            }

            this.FxSession = O2GTransport.createSession();

            this.FxSession.LoginFailed += this.OnLoginFailed;
            this.FxSession.RequestCompleted += this.OnRequestCompleted;
            this.FxSession.RequestFailed += this.OnRequestFailed;
            this.FxSession.SessionStatusChanged += this.OnSessionStatusChanged;
            this.FxSession.TableManagerStatusChanged += this.OnTableManagerStatusChanged;
            this.FxSession.TablesUpdates += this.OnTablesUpdates;
        }

        private void OnTablesUpdates(object sender, TablesUpdatesEventArgs e)
        {
            if (this.DataReceived == null)
            {
                // No listeners.
                return;
            }

            if (e.Response == null)
            {
                // No response.
                return;
            }

            this.ProcessResponse(e.Response);
        }

        private void ProcessResponse(O2GResponse response)
        {
            if (response == null)
            {
                // No response.
                return;
            }

            if (this.DataReceived == null)
            {
                // No listeners.
                return;
            }

            foreach (var item in this.ResponseReader.ReadResponse(response))
            {
                this.DataReceived(this, new EventArgs<DataReceived>(new DataReceived()
                {
                    RequestID = response.RequestID,
                    Row = item,
                }));
            }
        }

        private void OnTableManagerStatusChanged(object sender, TableManagerStatusChangedEventArgs e)
        {
            var status = Converters.GetTableManagerStatus(e.Status);

            this.TableManagerStatus = status;

            if (this.TableManagerStatusChanged != null)
            {
                this.TableManagerStatusChanged(this, new EventArgs<TableManagerStatusChanged>(new TableManagerStatusChanged()
                {
                    Status = status,
                }));
            }
        }

        private void OnSessionStatusChanged(object sender, SessionStatusEventArgs e)
        {
            var status = Converters.GetSessionStatus(e.SessionStatus);

            this.SessionStatus = status;

            switch (status)
            {
                case FxConnectProxy.SessionStatus.Connected:
                    this.PopulateProviders();

                    if (this.UsingTableManager)
                    {
                        this.PopulateTableManager();
                    }
                    break;

                case FxConnectProxy.SessionStatus.Disconnected:
                case FxConnectProxy.SessionStatus.SessionLost:
                    this.DeinitSession();
                    this.InitSession();
                    break;
            }

            if (this.SessionStatusChanged != null)
            {
                this.SessionStatusChanged(this, new EventArgs<SessionStatusChanged>(new SessionStatusChanged()
                {
                    Status = status,
                }));
            }
        }

        private void PopulateTableManager()
        {
            this.TableManager = this.InitialTableManager ??
                new TableManager(this.FxSession.getTableManager(), this.ResponseReader, new TableManagerValidator());

            this.FeedbackContext.SetTableManager(this.TableManager);
        }

        private void PopulateProviders()
        {
            this.FxRequestFactory = this.FxSession.getRequestFactory();
            this.FxResponseFactory = this.FxSession.getResponseReaderFactory();

            this.ResponseReader = new ResponseReader(this.FxResponseFactory, this.GetMarketDataInstrument);

            this.Requests = this.InitialRequestProvider ??
                new RequestProvider(new RequestProviderSettings()
                    {
                        AddMakrtedDataRequestItem = this.AddMarketDataRequestItem,
                        CleanupMarketDataRequests = this.CleanUpMarketDataRequests,
                        Reader = this.ResponseReader,
                        RequestFactory = this.FxRequestFactory,
                        Session = this.FxSession,
                        Validator = new RequestProviderValidator(),
                    });

            var loginRules = this.FxSession.getLoginRules();

            this.LoginRules = this.InitialLoginRulesProvider ??
                new LoginRulesProvider(loginRules, this.ResponseReader, new LoginRulesProviderValidator());

            this.PermissionChecker = this.InitialPermissionChecker ??
                new PermissionChecker(loginRules.getPermissionChecker(), new PermissionCheckerValidator());

            this.TradingSettings = this.InitialTradingSettingsProvider ??
                new TradingSettingsProvider(loginRules.getTradingSettingsProvider(), new TradingSettingsProviderValidator());

            this.FeedbackContext.SetLoginRulesProvider(this.LoginRules);
            this.FeedbackContext.SetPermissionChecker(this.PermissionChecker);
            this.FeedbackContext.SetRequestProvider(this.Requests);
            this.FeedbackContext.SetTradingSettingsProvider(this.TradingSettings);
        }

        private void OnRequestFailed(object sender, RequestFailedEventArgs e)
        {
            if (this.RequestFailed != null)
            {
                this.RequestFailed(this, new EventArgs<RequestFailed>(new RequestFailed()
                {
                    Error = e.Error,
                    RequestID = e.RequestID,
                }));
            }
        }

        private void OnRequestCompleted(object sender, RequestCompletedEventArgs e)
        {
            this.ProcessResponse(e.Response);
        }

        private void OnLoginFailed(object sender, LoginFailedEventArgs e)
        {
            if (this.LoginFailed != null)
            {
                this.LoginFailed(this, new EventArgs<LoginFailed>(new LoginFailed()
                {
                    Error = e.Error,
                }));
            }
        }

        private void DeinitSession()
        {
            if (this.FxSession == null)
            {
                return;
            }

            this.FxSession.LoginFailed -= this.OnLoginFailed;
            this.FxSession.RequestCompleted -= this.OnRequestCompleted;
            this.FxSession.RequestFailed -= this.OnRequestFailed;
            this.FxSession.SessionStatusChanged -= this.OnSessionStatusChanged;
            this.FxSession.TableManagerStatusChanged -= this.OnTableManagerStatusChanged;
            this.FxSession.TablesUpdates -= this.OnTablesUpdates;

            this.FxSession = null;
            this.FxRequestFactory = null;
            this.FxResponseFactory = null;
            this.ResponseReader = null;
            this.TableManager = null;
            this.TradingSettings = null;
            this.PermissionChecker = null;
            this.LoginRules = null;
            this.Requests = null;
        }

        private string GetMarketDataInstrument(string requestID)
        {
            return this.MarketDataRequests.ContainsKey(requestID) ? this.MarketDataRequests[requestID].Instrument : null;
        }

        private void CleanUpMarketDataRequests()
        {
            var cutOff = DateTime.Now.AddSeconds(-__MarketDataRequestTimeout);

            var expired = this.MarketDataRequests.Where(x => x.Value.Time <= cutOff).Select(x => x.Key).ToList();
            foreach (var item in expired)
            {
                this.MarketDataRequests.Remove(item);
            }
        }

        private void AddMarketDataRequestItem(MarketDataRequestItem item)
        {
            this.MarketDataRequests[item.RequestID] = item;
        }

        public event EventHandler<EventArgs<LoginFailed>> LoginFailed;

        public event EventHandler<EventArgs<DataReceived>> DataReceived;

        public event EventHandler<EventArgs<RequestFailed>> RequestFailed;

        public event EventHandler<EventArgs<SessionStatusChanged>> SessionStatusChanged;

        public event EventHandler<EventArgs<TableManagerStatusChanged>> TableManagerStatusChanged;
    }
}
