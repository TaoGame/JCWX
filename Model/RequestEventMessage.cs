using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Model
{
    public class RequestEventMessage : RequestMessage
    {
        public RequestEventMessage(XElement xml)
            : base(xml)
        {
            this.Event = (Model.Event)Enum.Parse(typeof(Model.Event), xml.Element("Event").Value, true);
        }

        public Event Event { get; set; }

        public override MsgType MsgType
        {
            get { return MsgType.Event; }
        }
    }
}
