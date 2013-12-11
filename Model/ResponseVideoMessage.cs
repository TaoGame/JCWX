using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WX.Model
{
    [XmlRoot("xml")]
    public class ResponseVideoMessage : ResponseMessage
    {
        public ResponseVideoMessage() { }
        public ResponseVideoMessage(RequestMessage request)
            : base(request)
        {
        }
        public override MsgType MsgType
        {
            get { return Model.MsgType.Video; }
        }

        public string MediaId { get; set; }

        public string ThumbMediaId { get; set; }
    }
}
