// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fxcore2;
using FxConnectProxy.Utils;
using FxConnectProxy.Validators;
using FxConnectProxy.Interfaces;

namespace FxConnectProxy.ForexConnect
{
    class TableManager : ITableManager
    {
        private O2GTableManager Manager { get; set; }
        private ResponseReader Reader { get; set; }
        private ITableManagerValidator Validator { get; set; }

        public TableManager(O2GTableManager manager, ResponseReader reader, ITableManagerValidator validator = null)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("manager");
            }

            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            this.Manager = manager;
            this.Reader = reader;
            this.Validator = validator ?? new TableManagerValidator();
        }

        public GetTableResponse GetTable(GetTableRequest request)
        {
            this.Validator.Validate(request);

            var table = this.Manager.getTable(Converters.GetTableType(request.Table));

            return new GetTableResponse()
            {
                Rows = this.Reader.ReadTable(table),
            };
        }

        public void LockUpdates()
        {
            this.Manager.lockUpdates();
        }

        public void UnlockUpdates()
        {
            this.Manager.unlockUpdates();
        }
    }
}
