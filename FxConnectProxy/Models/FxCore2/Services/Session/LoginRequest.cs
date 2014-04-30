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
