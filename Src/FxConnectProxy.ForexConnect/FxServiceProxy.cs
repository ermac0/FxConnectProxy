using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fxcore2;
using FxConnectProxy.ForexConnect.Providers;
using FxConnectProxy.ForexConnect.Models;
using FxConnectProxy.Interfaces;
using FxConnectProxy.Validators;

namespace FxConnectProxy.ForexConnect
{
    public class FxServiceProxy : IFxConnectProxy
    {
        public FxServiceProxy()
            // We're passing nulls so they can be instatiated with internal providers.
            : this(null, null, null, null, null, null)
        {
        }

        public FxServiceProxy(ILoginRulesProvider loginRulesProvider, ITradingSettingsProvider tradingSettingsProvider,
            IPermissionChecker permissionChecker, IRequestProvider requestProvider, ITableManager tableManager, ISessionProvider sessionProvider)
        {
            var feedback = new SessionFeedbackContext();
            feedback.SetLoginRulesProvider = this.SetLoginRules;
            feedback.SetPermissionChecker = this.SetPermissionChecker;
            feedback.SetRequestProvider = this.SetRequests;
            feedback.SetTableManager = this.SetTableManager;
            feedback.SetTradingSettingsProvider = this.SetTradingSettings;

            this.Session = sessionProvider ??
                new SessionProvider(loginRulesProvider, tradingSettingsProvider, permissionChecker, requestProvider,
                    tableManager, new SessionProviderValidator(), feedback);
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

        public ISessionProvider Session
        {
            get;
            private set;
        }

        public ITableManager TableManager
        {
            get;
            private set;
        }

        private void SetLoginRules(ILoginRulesProvider provider)
        {
            this.LoginRules = provider;
        }

        private void SetPermissionChecker(IPermissionChecker provider)
        {
            this.PermissionChecker = provider;
        }

        private void SetRequests(IRequestProvider provider)
        {
            this.Requests = provider;
        }

        private void SetTradingSettings(ITradingSettingsProvider provider)
        {
            this.TradingSettings = provider;
        }

        private void SetTableManager(ITableManager provider)
        {
            this.TableManager = provider;
        }
    }
}
