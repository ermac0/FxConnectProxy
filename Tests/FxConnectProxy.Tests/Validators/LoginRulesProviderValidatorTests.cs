// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FxConnectProxy.Validators;
using System.Collections.Generic;

namespace FxConnectProxy.Tests.Validators
{
    [TestClass]
    public class LoginRulesProviderValidatorTests
    {
        [TestMethod]
        public void ValidateGetTableRequest()
        {
            // Null.
            {
                var v = new LoginRulesProviderValidator();
                GetTableRequest r = null;

                AssertEx.Throws<ArgumentNullException>(() =>
                    {
                        v.Validate(r);
                    });
            }

            // Invalid table.
            {
                var v = new LoginRulesProviderValidator();
                GetTableRequest r = new GetTableRequest();
                r.Table = TableType.Unknown;

                AssertEx.Throws<ArgumentOutOfRangeException>(() =>
                {
                    v.Validate(r);
                });
            }

            // Valid.
            {
                var values = (TableType[])Enum.GetValues(typeof(TableType));
                foreach (var opt in values.Where(x => x != TableType.Unknown))
                {
                    var v = new LoginRulesProviderValidator();
                    GetTableRequest r = new GetTableRequest();
                    r.Table = opt;

                    v.Validate(r);
                }
            }
        }
    }
}
