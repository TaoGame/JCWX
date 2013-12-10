using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model
{
    public class ResponseTextMessage : ResponseMessage
    {
        public ResponseTextMessage() { }
        public ResponseTextMessage(RequestMessage request)
            : base(request)
        {
        }
        public override MsgType MsgType
        {
            get { return Model.MsgType.Text; }
        }

        public string Content { get; set; }
    }
}
