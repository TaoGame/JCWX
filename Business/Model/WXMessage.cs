using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WX.Model
{
    [Serializable]
    public abstract class WXMessage
    {
        protected XmlDocument doc = new XmlDocument();
        
        [XmlIgnore]
        public string ToUserName { get; set; }

        [XmlIgnore]
        public string FromUserName { get; set; }

        [XmlElement("CreateTime")]
        public long CreateTime { get; set; }

        public abstract MsgType MsgType { get; }

        [XmlElement("MsgType")]
        public XmlCDataSection CMsgType
        {
            get
            {
                return doc.CreateCDataSection(MsgType.ToString().ToLower());
            }
            set { ;}
        }

        [XmlElement("ToUserName")]
        public XmlCDataSection CToUserName
        {
            get
            {
                return doc.CreateCDataSection(ToUserName);
            }
            set
            {
                ToUserName = value.Value;
            }
        }

        [XmlElement("FromUserName")]
        public XmlCDataSection CFromUserName
        {
            get
            {
                return doc.CreateCDataSection(FromUserName);
            }
            set
            {
                FromUserName = value.Value;
            }
        }
    }
}
