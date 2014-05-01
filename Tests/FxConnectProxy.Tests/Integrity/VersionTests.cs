using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fxcore2;
using System.Diagnostics.CodeAnalysis;

namespace FxConnectProxy.Tests.Integrity
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VersionTests
    {
        /// <summary>
        /// Checks if ForexConnect version is what we expect.
        /// </summary>
        [TestMethod]
        public void ForexConnect()
        {
            var asm = typeof(O2GResponse).Assembly;

            var v = asm.GetName().Version;

            Assert.AreEqual(1, v.Major);
            Assert.AreEqual(3, v.Minor);
        }
    }
}
