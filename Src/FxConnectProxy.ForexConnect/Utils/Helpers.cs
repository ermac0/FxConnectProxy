// Copyright (c) 2014 Patrick Pulka
// License: https://raw.githubusercontent.com/ermac0/FxConnectProxy/master/LICENSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fxcore2;

namespace FxConnectProxy.ForexConnect
{
    static class Helpers
    {
        public static O2GAccountRow GetAccountRow(AccountRow account)
        {
            return account == null ? null :
                (account is AccountRowEx ? (account as AccountRowEx)._FxAccountRow :
                (account is AccountTableRowEx ? (account as AccountTableRowEx)._FxAccountRow : null));
        }

        public static RequestResponse GetRequestResponse(O2GRequest fxReq)
        {
            if (fxReq == null)
            {
                return null;
            }

            var response = new RequestResponse();

            response.RequestID = fxReq.RequestID;

            if (fxReq.ChildrenCount > 0)
            {
                for (var i = 0; i < fxReq.ChildrenCount; i++)
                {
                    var child = GetRequestResponse(fxReq.getChildRequest(i));
                    if (child != null)
                    {
                        response.ChildRequests.Add(child);
                    }
                }
            }

            return response;
        }
    }
}
