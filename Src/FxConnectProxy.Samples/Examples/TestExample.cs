// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Samples.Examples
{
    class TestExample : BaseExample
    {
        private int Counter { get; set; }

        protected override void StartInternal()
        {
            this.LogInternal("Starting...");
        }

        protected override void StopInternal()
        {
        }

        protected override void Cycle()
        {
            this.LogInternal("This is very long line {0} long looong looooooong. This is very long line. This is very long line. This is very long line. This is very long line. This is very long line. ", ++this.Counter);
        }

        public override string Name
        {
            get { return "Test Example"; }
        }

        public override string Description
        {
            get { return "Sends dummy data back to the output."; }
        }

        public override int Order
        {
            get { return 100000; }
        }

        public override bool IsHidden
        {
            get
            {
                return true;
            }
        }
    }
}
