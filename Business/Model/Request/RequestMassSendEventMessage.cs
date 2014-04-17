using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Model
{
    public class RequestMassSendEventMessage : RequestEventMessage
    {
        public RequestMassSendEventMessage(XElement xml)
            : base(xml)
        {
            MsgId = long.Parse(xml.Element("MsgID").Value);
            Status = xml.Element("Status").Value;
            TotalCount = int.Parse(xml.Element("TotalCount").Value);
            FilterCount = int.Parse(xml.Element("FilterCount").Value);
            SentCount = int.Parse(xml.Element("SentCount").Value);
            ErrorCount = int.Parse(xml.Element("ErrorCount").Value);
        }

        public string Status { get; set; }

        public int TotalCount { get; set; }

        public int FilterCount { get; set; }

        public int SentCount { get; set; }

        public int ErrorCount { get; set; }
    }
}
