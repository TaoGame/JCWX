using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Model
{
    public class RequestQREventMessage : RequestEventMessage
    {
        public RequestQREventMessage(XElement xml)
            : base(xml)
        {
            this.EventKey = xml.Element("EventKey").Value;
            this.Ticket = xml.Element("Ticket").Value;
        }

        public string EventKey { get; set; }

        public string Ticket { get; set; }
    }
}
