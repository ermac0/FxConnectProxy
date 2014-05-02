// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxConnectProxy.ForexConnect.Tests
{
    class Helpers
    {
        /// <summary>
        /// Creates an instance of the specified type defined in FxConnectProxy.ForexConnect assembly.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object CreateInstance(string type, params object[] args)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException("type");
            }

            var t = GetType(type);

            if (t == null)
            {
                throw new InvalidOperationException("Type '" + type + "' not found.");
            }

            return Activator.CreateInstance(t, args);
        }

        public static Type GetType(string type)
        {
            var asm = typeof(FxServiceProxy).Assembly;

            var t = asm.GetTypes().FirstOrDefault(x => string.Equals(x.FullName, type, StringComparison.OrdinalIgnoreCase));

            return t;
        }
    }
}
