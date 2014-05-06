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

        public ResponseVideo Video { get; set; }
    }

    public class ResponseVideo
    {
        public string MediaId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
