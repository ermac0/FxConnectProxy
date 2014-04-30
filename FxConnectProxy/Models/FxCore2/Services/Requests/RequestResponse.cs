using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class RequestResponse
    {
        public string RequestID { get; set; }

        public List<RequestResponse> ChildRequests { get; set; }

        public RequestResponse()
        {
            this.ChildRequests = new List<RequestResponse>();
        }
    }
}
