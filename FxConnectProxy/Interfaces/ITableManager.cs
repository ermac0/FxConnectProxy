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
