// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxConnectProxy.Tests.Misc
{
    [TestClass]
    public class EventArgsTests
    {
        [TestMethod]
        public void Constructor()
        {
            // Empty constructor with ValueType.
            {
                var o = new EventArgs<int>();

                Assert.AreEqual(default(int), o.Value);
            }

            // Empty constructor with ReferenceType.
            {
                var o = new EventArgs<AccountRow>();

                Assert.AreEqual(default(AccountRow), o.Value);
            }

            // With assignment ValueType.
            {
                var expected = 6;
                var o = new EventArgs<int>(expected);

                Assert.AreEqual(expected, o.Value);
            }

            // With assignment ReferenceType.
            {
                var expected = new AccountRow();
                var o = new EventArgs<AccountRow>(expected);

                Assert.AreEqual(expected, o.Value);
            }
        }

        [TestMethod]
        public void ManualAssignment()
        {
            // Manual assignment ValueType.
            {
                var expected = 7;
                var o = new EventArgs<int>();
                o.Value = expected;

                Assert.AreEqual(expected, o.Value);
            }

            // Manual assignment RefType.
            {
                var expected = new AccountRow();
                var o = new EventArgs<AccountRow>();
                o.Value = expected;

                Assert.AreEqual(expected, o.Value);
            }
        }
    }
}
