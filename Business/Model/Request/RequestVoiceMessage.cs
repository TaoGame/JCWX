using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Model
{
    public class RequestVoiceMessage : RequestMessage
    {
        public RequestVoiceMessage(XElement xml):base(xml)
        {
            this.MediaId = xml.Element("MediaId").Value;
            this.Format = xml.Element("Format").Value;
            this.Recognition = xml.Element("Recognition").Value;
        }

        public override MsgType MsgType
        {
            get { return Model.MsgType.Voice; }
        }

        public string MediaId { get; set; }

        public string Format { get; set; }
        
        public string Recognition { get; set; }
    }
}
