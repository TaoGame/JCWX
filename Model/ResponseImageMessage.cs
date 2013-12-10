using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model
{
    public class ResponseImageMessage : ResponseMessage
    {
        public ResponseImageMessage() { }
        public ResponseImageMessage(RequestMessage request)
            : base(request)
        {
        }

        public override MsgType MsgType
        {
            get { return Model.MsgType.Image; }
        }

        public string MediaId { get; set; }
    }
}
