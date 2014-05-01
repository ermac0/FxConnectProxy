// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fxcore2;
using FxConnectProxy.Utils;

namespace FxConnectProxy.ForexConnect
{
    class ResponseReader
    {
        private O2GResponseReaderFactory Factory { get; set; }
        private ObjectMapper ObjectMapper { get; set; }
        private GetMarketDataInstrumentDelegate MarketDataInstrumentGetter { get; set; }

        public ResponseReader(O2GResponseReaderFactory factory, GetMarketDataInstrumentDelegate marketDataInstrumentGetter)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            if (marketDataInstrumentGetter == null)
            {
                throw new ArgumentNullException("marketDataInstrumentGetter");
            }

            this.Factory = factory;
            this.MarketDataInstrumentGetter = marketDataInstrumentGetter;
            this.ObjectMapper = new ObjectMapper(true);
            Mappings.RegisterMappings(this.ObjectMapper);
        }

        public List<BaseRow> ReadResponse(O2GResponse response)
        {
            var list = new List<BaseRow>();

            if (response == null)
            {
                return list;
            }

            var factory = this.Factory;

            switch (response.Type)
            {
                case O2GResponseType.GetAccounts:
                    {
                        var reader = factory.createAccountsTableReader(response);
                        list.AddRange(this.GetGenericResponse(reader));
                    }
                    break;

                case O2GResponseType.GetClosedTrades:
                    {
                        var reader = factory.createClosedTradesTableReader(response);
                        list.AddRange(this.GetGenericResponse(reader));
                    }
                    break;

                case O2GResponseType.GetLastOrderUpdate:
                    {
                        var reader = factory.createLastOrderUpdateResponseReader(response);
                        list.AddRange(this.GetGenericResponse(reader));
                    }
                    break;

                case O2GResponseType.GetMessages:
                    {
                        var reader = factory.createMessagesTableReader(response);
                        list.AddRange(this.GetGenericResponse(reader));
                    }
                    break;

                case O2GResponseType.GetOffers:
                    {
                        var reader = factory.createOffersTableReader(response);
                        list.AddRange(this.GetGenericResponse(reader));
                    }
                    break;

                case O2GResponseType.GetOrders:
                    {
                        var reader = factory.createOrdersTableReader(response);
                        list.AddRange(this.GetGenericResponse(reader));
                    }
                    break;

                case O2GResponseType.GetSystemProperties:
                    {
                        var reader = factory.createSystemPropertiesReader(response);
                        list.AddRange(this.GetGenericResponse(reader));
                    }
                    break;

                case O2GResponseType.GetTrades:
                    {
                        var reader = factory.createTradesTableReader(response);
                        list.AddRange(this.GetGenericResponse(reader));
                    }
                    break;

                case O2GResponseType.TablesUpdates:
                    {
                        var reader = factory.createTablesUpdatesReader(response);
                        list.AddRange(this.GetGenericResponse(reader));
                    }
                    break;

                case O2GResponseType.CreateOrderResponse:
                    {
                        var reader = factory.createOrderResponseReader(response);
                        list.AddRange(this.GetGenericResponse(reader));
                    }
                    break;

                case O2GResponseType.MarketDataSnapshot:
                    {
                        var reader = factory.createMarketDataSnapshotReader(response);
                        list.AddRange(this.GetGenericResponse(reader, response.RequestID));
                    }
                    break;
            }

            return list;
        }

        private TOut GetRow<TOut, TIn>(TIn row)
            where TOut : BaseRow, new() 
        {
            var result = new TOut();
            this.ObjectMapper.Map(row, result);
            return result;
        }

        private IEnumerable<BaseRow> GetGenericResponse(O2GTablesUpdatesReader reader)
        {
            var rows = new List<BaseRow>();

            for (var i = 0; i < reader.Count; i++)
            {
                var type = reader.getUpdateTable(i);

                BaseRow row = null;

                switch (type)
                {
                    case O2GTableType.Accounts:
                        {
                            // AccountRowEx - so we can get hold of O2GAccountRow internally when needed.
                            row = this.GetRow<AccountRowEx, O2GAccountRow>(reader.getAccountRow(i));
                            break;
                        }

                    case O2GTableType.ClosedTrades:
                        {
                            row = this.GetRow<ClosedTradeRow, O2GClosedTradeRow>(reader.getClosedTradeRow(i));
                            break;
                        }

                    case O2GTableType.Messages:
                        {
                            row = this.GetRow<MessageRow, O2GMessageRow>(reader.getMessageRow(i));
                            break;
                        }

                    case O2GTableType.Offers:
                        {
                            row = this.GetRow<OfferRow, O2GOfferRow>(reader.getOfferRow(i));
                            break;
                        }

                    case O2GTableType.Orders:
                        {
                            row = this.GetRow<OrderRow, O2GOrderRow>(reader.getOrderRow(i));
                            break;
                        }

                    case O2GTableType.Trades:
                        {
                            row = this.GetRow<TradeRow, O2GTradeRow>(reader.getTradeRow(i));
                            break;
                        }
                }

                if (row != null)
                {
                    row.UpdateType = Converters.GetUpdateType(reader.getUpdateType(i));
                    rows.Add(row);
                }
            }

            return rows;
        }

        private IEnumerable<AccountRow> GetGenericResponse(O2GAccountsTableResponseReader reader)
        {
            var rows = new List<AccountRow>();

            for (var i = 0; i < reader.Count; i++)
            {
                // AccountRowEx - so we can get hold of O2GAccountRow internally when needed.
                rows.Add(this.GetRow<AccountRowEx, O2GAccountRow>(reader.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<ClosedTradeRow> GetGenericResponse(O2GClosedTradesTableResponseReader reader)
        {
            var rows = new List<ClosedTradeRow>();

            for (var i = 0; i < reader.Count; i++)
            {
                rows.Add(this.GetRow<ClosedTradeRow, O2GClosedTradeRow>(reader.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<LastOrderUpdateRow> GetGenericResponse(O2GLastOrderUpdateResponseReader reader)
        {
            var rows = new List<LastOrderUpdateRow>();

            var r = this.GetRow<LastOrderUpdateRow, O2GOrderRow>(reader.Order);
            r.UpdateType = Converters.GetUpdateType(reader.UpdateType);

            rows.Add(r);

            return rows;
        }

        private IEnumerable<BaseRow> GetGenericResponse(O2GMarketDataSnapshotResponseReader reader, string requestID)
        {
            var rows = new List<MarketDataRow>();

            // Try to obtain the instrument from a saved list of market data requests.
            var instrument = this.MarketDataInstrumentGetter(requestID);

            for (var i = 0; i < reader.Count; i++)
            {
                var row = new MarketDataRow();

                row.Instrument = instrument;

                if (reader.isBar)
                {
                    row.AskClose = reader.getAskClose(i);
                    row.AskHigh = reader.getAskHigh(i);
                    row.AskLow = reader.getAskLow(i);
                    row.AskOpen = reader.getAskOpen(i);
                    row.BidClose = reader.getBidClose(i);
                    row.BidHigh = reader.getBidHigh(i);
                    row.BidLow = reader.getBidLow(i);
                    row.BidOpen = reader.getBidOpen(i);
                }
                else
                {
                    row.Ask = reader.getAsk(i);
                    row.Bid = reader.getBid(i);
                }

                row.IsBar = reader.isBar;
                row.Time = reader.getDate(i);
                row.Volume = reader.getVolume(i);

                rows.Add(row);
            }

            return rows;
        }

        private IEnumerable<MessageRow> GetGenericResponse(O2GMessagesTableResponseReader reader)
        {
            var rows = new List<MessageRow>();

            for (var i = 0; i < reader.Count; i++)
            {
                rows.Add(this.GetRow<MessageRow, O2GMessageRow>(reader.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<OfferRow> GetGenericResponse(O2GOffersTableResponseReader reader)
        {
            var rows = new List<OfferRow>();

            for (var i = 0; i < reader.Count; i++)
            {
                rows.Add(this.GetRow<OfferRow, O2GOfferRow>(reader.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<BaseRow> GetGenericResponse(O2GOrderResponseReader reader)
        {
            // Check if we need this.
            throw new NotImplementedException();
        }

        private IEnumerable<OrderRow> GetGenericResponse(O2GOrdersTableResponseReader reader)
        {
            var rows = new List<OrderRow>();

            for (var i = 0; i < reader.Count; i++)
            {
                rows.Add(this.GetRow<OrderRow, O2GOrderRow>(reader.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<SystemPropertyRow> GetGenericResponse(O2GSystemPropertiesReader reader)
        {
            var rows = new List<SystemPropertyRow>();

            foreach (var item in reader.Properties)
            {
                var ar = new SystemPropertyRow();
                ar.Name = item.Key;
                ar.Value = item.Value;
                rows.Add(ar);
            }

            return rows;
        }

        private IEnumerable<TradeRow> GetGenericResponse(O2GTradesTableResponseReader reader)
        {
            var rows = new List<TradeRow>();

            for (var i = 0; i < reader.Count; i++)
            {
                rows.Add(this.GetRow<TradeRow, O2GTradeRow>(reader.getRow(i)));
            }

            return rows;
        }

        public List<BaseRow> ReadTable(O2GTable table)
        {
            var list = new List<BaseRow>();

            switch (table.Type)
            {
                case O2GTableType.Accounts:
                    {
                        list.AddRange(this.GetRows((O2GAccountsTable)table));
                    }
                    break;

                case O2GTableType.ClosedTrades:
                    {
                        list.AddRange(this.GetRows((O2GClosedTradesTable)table));
                    }
                    break;

                case O2GTableType.Messages:
                    {
                        list.AddRange(this.GetRows((O2GMessagesTable)table));
                    }
                    break;

                case O2GTableType.Offers:
                    {
                        list.AddRange(this.GetRows((O2GOffersTable)table));
                    }
                    break;

                case O2GTableType.Orders:
                    {
                        list.AddRange(this.GetRows((O2GOrdersTable)table));
                    }
                    break;

                case O2GTableType.Summary:
                    {
                        list.AddRange(this.GetRows((O2GSummaryTable)table));
                    }
                    break;

                case O2GTableType.Trades:
                    {
                        list.AddRange(this.GetRows((O2GTradesTable)table));
                    }
                    break;
            }

            return list;
        }

        private IEnumerable<BaseRow> GetRows(O2GAccountsTable table)
        {
            var rows = new List<AccountTableRow>();

            for (var i = 0; i < table.Count; i++)
            {
                // AccountTableRowEx - so we can get hold of O2GAccountRow internally when needed.
                rows.Add(this.GetRow<AccountTableRowEx, O2GAccountTableRow>(table.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<BaseRow> GetRows(O2GClosedTradesTable table)
        {
            var rows = new List<ClosedTradeTableRow>();

            for (var i = 0; i < table.Count; i++)
            {
                rows.Add(this.GetRow<ClosedTradeTableRow, O2GClosedTradeTableRow>(table.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<BaseRow> GetRows(O2GMessagesTable table)
        {
            var rows = new List<MessageTableRow>();

            for (var i = 0; i < table.Count; i++)
            {
                rows.Add(this.GetRow<MessageTableRow, O2GMessageTableRow>(table.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<BaseRow> GetRows(O2GOffersTable table)
        {
            var rows = new List<OfferTableRow>();

            for (var i = 0; i < table.Count; i++)
            {
                rows.Add(this.GetRow<OfferTableRow, O2GOfferTableRow>(table.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<BaseRow> GetRows(O2GOrdersTable table)
        {
            var rows = new List<OrderTableRow>();

            for (var i = 0; i < table.Count; i++)
            {
                rows.Add(this.GetRow<OrderTableRow, O2GOrderTableRow>(table.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<BaseRow> GetRows(O2GSummaryTable table)
        {
            var rows = new List<SummaryTableRow>();

            for (var i = 0; i < table.Count; i++)
            {
                rows.Add(this.GetRow<SummaryTableRow, O2GSummaryTableRow>(table.getRow(i)));
            }

            return rows;
        }

        private IEnumerable<BaseRow> GetRows(O2GTradesTable table)
        {
            var rows = new List<TradeTableRow>();

            for (var i = 0; i < table.Count; i++)
            {
                rows.Add(this.GetRow<TradeTableRow, O2GTradeTableRow>(table.getRow(i)));
            }

            return rows;
        }
    }
}
