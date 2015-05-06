using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WX.Pay.Response;

namespace WX.Pay.Request
{
    [XmlRoot("xml")]
    public class PayCloseorderRequest : PayRequest<PayCloseorderResponse>
    {
        [XmlIgnore]
        public override string Url
        {
            get { return "https://api.mch.weixin.qq.com/pay/closeorder"; }
        }

        private string out_trade_no;

        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo
        {
            get { return out_trade_no; }
            set
            {
                out_trade_no = value;
                PushKeyValue("out_trade_no", value);
            }
        }

        private string nonce_str;

        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr
        {
            get { return nonce_str; }
            set
            {
                nonce_str = value;
                PushKeyValue("nonce_str", value);
            }
        }
    }
}
