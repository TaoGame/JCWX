using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WX.Model
{
    [XmlRoot("xml")]
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

        public VoiceMessage Voice { get; set; }
    }

    
}
