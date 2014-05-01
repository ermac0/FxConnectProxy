// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FxConnectProxy.Samples
{
    [DataContract]
    class Config
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string AccountType { get; set; }

        [DataMember]
        public bool SavePassword { get; set; }

        [DataMember]
        public bool ChangeAccount { get; set; }
    }
}
