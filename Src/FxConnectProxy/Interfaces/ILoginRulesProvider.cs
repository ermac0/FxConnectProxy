using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface ILoginRulesProvider
    {
        GetTableResponse GetTableRefresh(GetTableRequest request);
        IsTableLoadedByDefaultResponse IsTableLoadedByDefault(GetTableRequest request);
        GetTableResponse GetSystemProperties();
    }
}
