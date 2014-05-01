using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxConnectProxy.Tests.Data
{
    [TestClass]
    public class RequestResponseTests
    {
        [TestMethod]
        public void Constructor()
        {
            var o = new RequestResponse();

            Assert.IsNotNull(o.ChildRequests);
        }
    }
}
