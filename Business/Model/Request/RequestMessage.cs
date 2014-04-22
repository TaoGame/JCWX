using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WX.Model
{
    [Serializable]
    public abstract class RequestMessage : WXMessage
    {
        public RequestMessage() { }

        public RequestMessage(XElement xml)
        {
            this.FromUserName = xml.Element("FromUserName").Value;
            this.ToUserName = xml.Element("ToUserName").Value;
            this.CreateTime = Int64.Parse(xml.Element("CreateTime").Value);
            this.MsgId = xml.Element("MsgId") != null ? Int64.Parse(xml.Element("MsgId").Value) : 0;
        }

        public static T Deserializ<T>(Stream stream)
            where T : RequestMessage
        {
            var xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(stream);
        }

        [XmlElement("MsgId")]
        public long MsgId { get; set; }
    }
}
