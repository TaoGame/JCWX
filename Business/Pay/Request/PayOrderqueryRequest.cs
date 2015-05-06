using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WX.Pay.Response;

namespace WX.Pay.Request
{
    [XmlRoot("xml")]
    public class PayOrderqueryRequest : PayRequest<PayOrderqueryResponse>
    {
        [XmlIgnore]
        public override string Url
        {
            get { return "https://api.mch.weixin.qq.com/pay/orderquery"; }
        }

        private string transaction_id;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId
        {
            get { return transaction_id; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    transaction_id = value;
                    PushKeyValue("transaction_id", value);
                }
            }
        }

        private string out_trade_no;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo
        {
            get { return out_trade_no; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    out_trade_no = value;
                    PushKeyValue("out_trade_no", value);
                }
            }
        }

        private string nonce_str;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr
        {
            get { return nonce_str; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    nonce_str = value;
                    PushKeyValue("nonce_str", value);
                }
            }
        }
    }
}
