using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface ITableManagerValidator
    {
        void Validate(GetTableRequest request);
    }
}
