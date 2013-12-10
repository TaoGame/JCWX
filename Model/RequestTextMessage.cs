using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WX.Model
{
    [Serializable]
    [XmlRoot("xml", 
        Namespace="")]
    public class RequestTextMessage : RequestMessage
    {
        public RequestTextMessage() { }

        public RequestTextMessage(XElement xml)
            : base(xml)
        {
            this.Content = xml.Element("Content").Value;
        }

        public override MsgType MsgType
        {
            get { return MsgType.Text; }
        }

        [XmlIgnore]
        public string Content { get; set; }

        [XmlElement("Content")]
        public XmlCDataSection CContent
        {
            get
            {
                return doc.CreateCDataSection(Content.ToString());
            }
            set
            {
                Content = value.Value;
            }
        }
    }
}
