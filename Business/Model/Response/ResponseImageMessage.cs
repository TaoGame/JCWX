using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WX.Model
{
    [XmlRoot("xml")]
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

        public ImageMessage Image { get; set; }
    }
}
