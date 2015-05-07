using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WX.Common;
using WX.Pay.Response;

namespace WX.Pay.Request
{
    [XmlRoot("xml")]
    public abstract class PayRequest<T>
        where T : PayResponse
    {
        private string appid;

        /// <summary>
        /// 公众账号ID
        /// </summary>
        [XmlElement("appid")]
        public string AppId
        {
            get
            {
                return appid;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    appid = value;
                    PushKeyValue("appid", appid);   
                }
            }
        }

        /// <summary>
        /// API密钥,在商户后台进行设置，非AppSecret
        /// </summary>
        [XmlIgnore]
        public string PayApiSecret { get; set; }

        private string mchid;

        /// <summary>
        /// 商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string MchId
        {
            get
            {
                return mchid;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    mchid = value;
                    PushKeyValue("mch_id", mchid);
                }
            }
        }

        [XmlElement("sign")]
        public string Sign
        {
            get
            {
                return CreateSign();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private string CreateSign()
        {
            var sb = new StringBuilder();
            foreach (var key in m_keyValue.Keys)
            {
                if (!String.IsNullOrEmpty(m_keyValue[key]))
                {
                    sb.AppendFormat("{0}={1}&", key, m_keyValue[key]);
                }
            }
            sb.AppendFormat("key={0}", PayApiSecret);
            return sb.ToString().Md5().ToUpper();
        }

        protected void PushKeyValue(string key, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                if (m_keyValue.Keys.Contains(key))
                {
                    m_keyValue[key] = value;
                }
                else
                {
                    m_keyValue.Add(key, value);
                }
            }
        }

        protected SortedDictionary<string, string> m_keyValue = new SortedDictionary<string, string>();

        [XmlIgnore]
        public abstract string Url { get; }

        protected XmlDocument _doc = new XmlDocument();

        public String Serializable()
        {
            var stream = new MemoryStream();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = true;
            
            using (var sw = XmlWriter.Create(stream, settings))
            {
                var xmlSerializer = new XmlSerializer(this.GetType());
                
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                xmlSerializer.Serialize(sw, this, ns);
            }

            stream.Position = 0;
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
