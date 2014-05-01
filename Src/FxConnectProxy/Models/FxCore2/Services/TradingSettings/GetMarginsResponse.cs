// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class GetMarginsResponse
    {
        public double MMR { get; set; }

        public double EMR { get; set; }

        public double LMR { get; set; }

        public bool ThreeMarginPolicy { get; set; }
    }
}
