// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
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
    class RequestProvider : IRequestProvider
    {
        private O2GSession FxSession { get; set; }
        private O2GRequestFactory FxRequestFactory { get; set; }

        private IRequestProviderValidator Validator { get; set; }

        private ResponseReader ResponseReader { get; set; }

        private Action<MarketDataRequestItem> AddMakrtedDataRequestItem { get; set; }

        private Action CleanupMarketDataRequests { get; set; }


        public RequestProvider(RequestProviderSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (settings.Session == null)
            {
                throw new ArgumentNullException("Session");
            }

            if (settings.RequestFactory == null)
            {
                throw new ArgumentNullException("RequestFactory");
            }

            if (settings.Reader == null)
            {
                throw new ArgumentNullException("Reader");
            }

            if (settings.AddMakrtedDataRequestItem == null)
            {
                throw new ArgumentNullException("AddMakrtedDataRequestItem");
            }

            if (settings.CleanupMarketDataRequests == null)
            {
                throw new ArgumentNullException("CleanupMarketDataRequests");
            }

            this.FxSession = settings.Session;
            this.FxRequestFactory = settings.RequestFactory;
            this.ResponseReader = settings.Reader;
            this.Validator = settings.Validator ?? new RequestProviderValidator();
            this.AddMakrtedDataRequestItem = settings.AddMakrtedDataRequestItem;
            this.CleanupMarketDataRequests = settings.CleanupMarketDataRequests;
        }

        public RequestResponse MarketDataSnapshotRequest(MarketDataSnapshotRequest request)
        {
            this.Validator.Validate(request);

            var timeframeId = request.Timeframe == Timeframe.Custom ?
                request.CustomTimeframeId : Converters.GetTimeframeId(request.Timeframe);

            var fxReq = this.FxRequestFactory.createMarketDataSnapshotRequestInstrument(request.Instrument,
                this.FxRequestFactory.Timeframes[timeframeId], request.MaxBars);

            this.FxRequestFactory.fillMarketDataSnapshotRequestTime(fxReq, request.TimeFrom, request.TimeTo,
                request.IncludeWeekends);

            this.CleanupMarketDataRequests();
            var mdr = new MarketDataRequestItem()
            {
                Instrument = request.Instrument,
                RequestID = fxReq.RequestID,
                Time = DateTime.Now,
            };
            this.AddMakrtedDataRequestItem(mdr);

            this.FxSession.sendRequest(fxReq);

            return Helpers.GetRequestResponse(fxReq);
        }

        public RequestResponse OrderRequest(OrderRequest request)
        {
            this.Validator.Validate(request);

            var fxReq = this.FxRequestFactory.createOrderRequest(this.GetValueMap(request.Map));

            this.FxSession.sendRequest(fxReq);

            return Helpers.GetRequestResponse(fxReq);
        }

        private O2GValueMap GetValueMap(ValueMap valueMap)
        {
            if (valueMap == null)
            {
                return null;
            }

            var result = this.FxRequestFactory.createValueMap();

            foreach (var v in valueMap.Values)
            {
                var p = Converters.GetRequestParam(v.Param);
                switch (v.Type)
                {
                    case ValueMapItemType.Boolean:
                        result.setBoolean(p, (v as ValueMapItem<bool>).Value);
                        break;

                    case ValueMapItemType.Double:
                        result.setDouble(p, (v as ValueMapItem<double>).Value);
                        break;

                    case ValueMapItemType.Int:
                        result.setInt(p, (v as ValueMapItem<int>).Value);
                        break;

                    case ValueMapItemType.String:
                        result.setString(p, (v as ValueMapItem<string>).Value);
                        break;

                    case ValueMapItemType.Command:
                        result.setString(p, Converters.GetRequestCommand((v as ValueMapItem<RequestCommand>).Value));
                        break;
                }
            }

            foreach (var child in valueMap.ChildMaps)
            {
                result.appendChild(GetValueMap(child));
            }

            return result;
        }

        public RequestResponse RefreshTableRequest(RefreshTableRequest request)
        {
            this.Validator.Validate(request);

            var fxReq = this.FxRequestFactory.createRefreshTableRequest(Converters.GetTableType(request.Table));

            this.FxSession.sendRequest(fxReq);

            return Helpers.GetRequestResponse(fxReq);
        }

        public RequestResponse RefreshTableByAccountRequest(RefreshTableByAccountRequest request)
        {
            this.Validator.Validate(request);

            var fxReq = this.FxRequestFactory.createRefreshTableRequestByAccount(Converters.GetTableType(request.Table),
                request.AccountID);

            this.FxSession.sendRequest(fxReq);

            return Helpers.GetRequestResponse(fxReq);
        }

        public GetLastErrorResponse GetLastError()
        {
            var result = this.FxRequestFactory.getLastError();

            return new GetLastErrorResponse()
            {
                Error = result,
            };
        }
    }
}
