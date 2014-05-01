// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
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
