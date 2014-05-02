// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace FxConnectProxy.ForexConnect.Tests.Utils
{
    [TestClass]
    public class ConvertersTests
    {
        private const string __Type = "FxConnectProxy.ForexConnect.Utils.Converters";

        /// <summary>
        /// Checks if Converters expose functions to convert from A to B and from B to A.
        /// </summary>
        [TestMethod]
        public void CanConvertBothWays()
        {
            var t = Helpers.GetType(__Type);

            if (t == null)
            {
                throw new AssertFailedException("Type not found.");
            }

            var methods = t.GetMethods(BindingFlags.Public | BindingFlags.Static).ToLookup(x => x.Name);
            foreach (var name in methods.Select(x => x.Key))
            {
                var found = t.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(x => x.Name == name).ToList();

                if (found.Count != 2)
                {
                    throw new AssertFailedException("Wrong count of methods for '" + name + "'.");
                }

                var rt = found[0].ReturnType;
                var pt = found[0].GetParameters()[0].ParameterType;

                if (!found[1].ReturnType.Equals(pt) || !found[1].GetParameters()[0].ParameterType.Equals(rt))
                {
                    throw new AssertFailedException("Method '" + name + "' does not provide both ways conversion.");
                }
            }
        }
    }
}
