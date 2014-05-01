using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxConnectProxy.Utils;

namespace FxConnectProxy
{
    public class MessageRow : BaseRow
    {
        public override RowType RowType
        {
            get { return RowType.Message; }
        }

        public bool HTMLFragmentFlag { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        public MessageFeature Feature { get; set; }

        public MessageType Type { get; set; }

        public string From { get; set; }

        public System.DateTime Time { get; set; }

        public string MsgID { get; set; }

        public MessageRow Clone()
        {
            return (MessageRow)this.MemberwiseClone();
        }
    }
}
