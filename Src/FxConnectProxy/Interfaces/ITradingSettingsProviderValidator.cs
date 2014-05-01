using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Interfaces
{
    public interface ITradingSettingsProviderValidator
    {
        void Validate(InstrumentBaseRequest request);

        void Validate(InstrumentAccountBaseRequest request);
    }
}
