using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model
{
    public class ResponseVoiceMessage : ResponseMessage
    {
        public ResponseVoiceMessage() { }
        public ResponseVoiceMessage(RequestMessage request)
            : base(request)
        {
        }
        public override MsgType MsgType
        {
            get { return Model.MsgType.Voice; }
        }

        public string MediaId { get; set; }
    }
}
