// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface ITableManager
    {
        GetTableResponse GetTable(GetTableRequest request);
        void LockUpdates();
        void UnlockUpdates();
    }
}
