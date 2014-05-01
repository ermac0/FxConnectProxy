using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface IPermissionCheckerValidator
    {
        void Validate(InstrumentBaseRequest request);
    }
}
