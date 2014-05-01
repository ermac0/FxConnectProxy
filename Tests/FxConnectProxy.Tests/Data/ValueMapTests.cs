using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxConnectProxy.Tests.Data
{
    [TestClass]
    public class ValueMapTests
    {
        [TestMethod]
        public void Constructor()
        {
            // Constructor.
            {
                var o = new ValueMap();
            }
        }

        [TestMethod]
        public void AddParam()
        {
            // Basic AddParam.
            {
                var o = new ValueMap();

                o.AddParam(RequestParam.AccountID, "Test");
                o.AddParam(RequestParam.ClientRate, 2.1);
                o.AddParam(RequestParam.ContingencyID, 677);
                o.AddParam(RequestParam.PegType, true);
                o.AddParam(RequestParam.Command, RequestCommand.EditOrder);

                Assert.AreEqual(0, o.ChildMaps.Count);
                Assert.AreEqual(5, o.Values.Count);
            }

            // Param test - string.
            {
                var o = new ValueMap();

                var expected = "Test";
                o.AddParam(RequestParam.AccountID, expected);

                Assert.AreEqual(1, o.Values.Count);
                var v = o.Values[0];
                Assert.AreEqual(RequestParam.AccountID, v.Param);
                Assert.AreEqual(ValueMapItemType.String, v.Type);
                Assert.AreEqual(expected, (v as ValueMapItem<string>).Value);
            }

            // Param test - int.
            {
                var o = new ValueMap();

                var expected = 55;
                o.AddParam(RequestParam.AccountID, expected);

                Assert.AreEqual(1, o.Values.Count);
                var v = o.Values[0];
                Assert.AreEqual(RequestParam.AccountID, v.Param);
                Assert.AreEqual(ValueMapItemType.Int, v.Type);
                Assert.AreEqual(expected, (v as ValueMapItem<int>).Value);
            }

            // Param test - double.
            {
                var o = new ValueMap();

                var expected = 40.66;
                o.AddParam(RequestParam.AccountID, expected);

                Assert.AreEqual(1, o.Values.Count);
                var v = o.Values[0];
                Assert.AreEqual(RequestParam.AccountID, v.Param);
                Assert.AreEqual(ValueMapItemType.Double, v.Type);
                Assert.AreEqual(expected, (v as ValueMapItem<double>).Value);
            }

            // Param test - bool.
            {
                var o = new ValueMap();

                var expected = true;
                o.AddParam(RequestParam.AccountID, expected);

                Assert.AreEqual(1, o.Values.Count);
                var v = o.Values[0];
                Assert.AreEqual(RequestParam.AccountID, v.Param);
                Assert.AreEqual(ValueMapItemType.Boolean, v.Type);
                Assert.AreEqual(expected, (v as ValueMapItem<bool>).Value);
            }

            // Param test - Command.
            {
                var o = new ValueMap();

                var expected = RequestCommand.RemoveFromContingencyGroup;
                o.AddParam(RequestParam.AccountID, expected);

                Assert.AreEqual(1, o.Values.Count);
                var v = o.Values[0];
                Assert.AreEqual(RequestParam.AccountID, v.Param);
                Assert.AreEqual(ValueMapItemType.Command, v.Type);
                Assert.AreEqual(expected, (v as ValueMapItem<RequestCommand>).Value);
            }
        }

        [TestMethod]
        public void AddChild()
        {
            // Null child.
            {
                var o = new ValueMap();

                o.AddChild(null);

                Assert.AreEqual(0, o.ChildMaps.Count);
            }

            // Valid child.
            {
                var o = new ValueMap();
                var child = new ValueMap();
                o.AddChild(child);

                Assert.AreEqual(1, o.ChildMaps.Count);
                Assert.AreEqual(child, o.ChildMaps[0]);
            }
        }

        [TestMethod]
        public void Clear()
        {
            // No items.
            {
                var o = new ValueMap();
                
                Assert.AreEqual(0, o.Values.Count);
                Assert.AreEqual(0, o.ChildMaps.Count);
                
                o.Clear();
                
                Assert.AreEqual(0, o.Values.Count);
                Assert.AreEqual(0, o.ChildMaps.Count);
            }

            // Only values.
            {
                var o = new ValueMap();
                o.AddParam(RequestParam.AccountID, true);
                o.AddParam(RequestParam.AccountName, "Test");

                Assert.AreEqual(2, o.Values.Count);
                Assert.AreEqual(0, o.ChildMaps.Count);
                
                o.Clear();

                Assert.AreEqual(0, o.Values.Count);
                Assert.AreEqual(0, o.ChildMaps.Count);
            }

            // Values and child maps.
            {
                var o = new ValueMap();

                o.AddParam(RequestParam.AccountID, true);
                o.AddParam(RequestParam.AccountName, "Test");
                o.AddChild(new ValueMap());

                Assert.AreEqual(2, o.Values.Count);
                Assert.AreEqual(1, o.ChildMaps.Count);

                o.Clear();

                Assert.AreEqual(0, o.Values.Count);
                Assert.AreEqual(0, o.ChildMaps.Count);
            }

            // Only child maps.
            {
                var o = new ValueMap();

                o.AddChild(new ValueMap());

                Assert.AreEqual(0, o.Values.Count);
                Assert.AreEqual(1, o.ChildMaps.Count);

                o.Clear();

                Assert.AreEqual(0, o.Values.Count);
                Assert.AreEqual(0, o.ChildMaps.Count);
            }
        }

        [TestMethod]
        public void ValueMapItem()
        {
            // Constructor (empty).
            {
                var o = new ValueMapItem<int>();

                Assert.AreEqual(default(int), o.Value);
                Assert.AreEqual(default(RequestParam), o.Param);
                Assert.AreEqual(default(ValueMapItemType), o.Type);
            }

            // Constructor (with params).
            {
                var expectedValue = 7;
                var expectedType = ValueMapItemType.Int;
                var expectedParam = RequestParam.BuySell;
                
                var o = new ValueMapItem<int>(expectedType, expectedParam, expectedValue);

                Assert.AreEqual(expectedValue, o.Value);
                Assert.AreEqual(expectedParam, o.Param);
                Assert.AreEqual(expectedType, o.Type);
            }
        }
    }
}
