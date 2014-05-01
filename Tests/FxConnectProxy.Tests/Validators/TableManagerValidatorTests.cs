// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FxConnectProxy.Validators;

namespace FxConnectProxy.Tests.Validators
{
    [TestClass]
    public class TableManagerValidatorTests
    {
        [TestMethod]
        public void ValidateGetTableRequest()
        {
            // Null.
            {
                var v = new TableManagerValidator();
                GetTableRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                    {
                        v.Validate(r);
                    });
            }

            // Invalid table.
            {
                var v = new TableManagerValidator();
                GetTableRequest r = new GetTableRequest();
                r.Table = TableType.Unknown;

                AssertEx.Throws<ArgumentOutOfRangeException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                foreach (var opt in ((TableType[])Enum.GetValues(typeof(TableType))).Where(x => x != TableType.Unknown))
                {
                    var v = new TableManagerValidator();
                    GetTableRequest r = new GetTableRequest();
                    r.Table = opt;

                    v.Validate(r);
                }
            }
        }
    }
}
