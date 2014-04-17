using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Model
{
    public class RequestVideoMessage : RequestMessage
    {
        public RequestVideoMessage(XElement xml)
            : base(xml)
        {
            this.MediaId = xml.Element("MediaId").Value;
            this.ThumbMediaId = xml.Element("ThumbMediaId").Value;
        }

        public override MsgType MsgType
        {
            get { return Model.MsgType.Video; }
        }

        public string MediaId { get; set; }

        public string ThumbMediaId { get; set; }
    }
}
