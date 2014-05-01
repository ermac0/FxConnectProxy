// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Url { get; set; }

        public string AccountType { get; set; }
    }
}
