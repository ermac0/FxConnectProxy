using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxConnectProxy.Tests.Misc
{
    [TestClass]
    public class FxConnectProxyExceptionTests
    {
        [TestMethod]
        public void Constructor()
        {
            // Empty constructor.
            {
                var ex = new FxConnectProxyException();

                Assert.AreEqual(FxConnectProxyExceptionCode.Default, ex.ErrorCode);
            }

            // Constructor with code.
            {
                var expected = FxConnectProxyExceptionCode.CannotChangeOnActiveSession;
                
                var ex = new FxConnectProxyException(expected);

                Assert.AreEqual(expected, ex.ErrorCode);
            }

            // Constructor with message.
            {
                var expected = "Test message";

                var ex = new FxConnectProxyException(expected);

                Assert.AreEqual(expected, ex.Message);
                Assert.AreEqual(FxConnectProxyExceptionCode.Default, ex.ErrorCode);
            }

            // Constructor with message and code.
            {
                var expectedMsg = "Test message";
                var expectedCode = FxConnectProxyExceptionCode.TableManagerNotInitialized;

                var ex = new FxConnectProxyException(expectedMsg, expectedCode);

                Assert.AreEqual(expectedMsg, ex.Message);
                Assert.AreEqual(expectedCode, ex.ErrorCode);
            }
        }
    }
}
