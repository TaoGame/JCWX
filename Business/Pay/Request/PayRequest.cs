using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WX.Common;

namespace WX.Pay.Request
{
    public abstract class PayRequest
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
        /// app密钥
        /// </summary>
        [XmlIgnore]
        public string AppSecret { get; set; }

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
        }

        private string CreateSign()
        {
            var sb = new StringBuilder();
            foreach (var key in m_keyValue.Keys)
            {
                sb.AppendFormat("{0}={1}&", key, m_keyValue[key]);
            }
            sb.AppendFormat("key={0}", AppSecret);
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
