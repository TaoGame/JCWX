using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WX.Model
{
    [Serializable]
    [XmlRoot("xml")]
    public abstract class ResponseMessage : WXMessage
    {
        public ResponseMessage() { }

        public ResponseMessage(RequestMessage request)
        {
            this.FromUserName = request.ToUserName;
            this.ToUserName = request.FromUserName;
        }

        public override MsgType MsgType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public String Serializable()
        {
            var sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(this.GetType());
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(sw, this, ns);

            return sw.ToString();
        }
    }
}
