using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Model.Request
{
    public class RequestTemplateEventMessage : RequestEventMessage
    {
        public RequestTemplateEventMessage(XElement xml)
            : base(xml)
        {
            this.Status = xml.Element("Status").Value;
        }


        public string Status { get; set; }

        public override MsgType MsgType
        {
            get { return Model.MsgType.Event; }
        }
    }
}
