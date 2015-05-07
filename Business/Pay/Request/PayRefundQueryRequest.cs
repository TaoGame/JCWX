using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WX.Pay.Response;

namespace WX.Pay.Request
{
    /// <summary>
    /// 提交退款申请后，通过调用该接口查询退款状态。退款有一定延时，用零钱支付的退款20分钟内到账，银行卡支付的退款3个工作日后重新查询退款状态。
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class PayRefundQueryRequest : PayRequest<PayRefundQueryResponse>
    {
        public override string Url
        {
            get { return "https://api.mch.weixin.qq.com/pay/refundquery"; }
        }

        private string device_info;

        /// <summary>
        /// 设备号 微信支付分配的终端设备号，与下单一致
        /// </summary>
        [XmlElement("device_info")]
        public string DeviceInfo
        {
            get { return device_info; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    device_info = value;
                    PushKeyValue("device_info", value);
                }
            }
        }

        private string nonce_str;

        /// <summary>
        /// 随机字符串
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

        private string transaction_id;

        /// <summary>
        /// 微信订单号
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
        /// 商户订单号
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

        private string out_refund_no;

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [XmlElement("out_refund_no")]
        public string OutRefundNo
        {
            get { return out_refund_no; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    out_refund_no = value;
                    PushKeyValue("out_refund_no", value);
                }
            }
        }


        private string refund_id;

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [XmlElement("refund_id")]
        public string RefundId 
        {
            get { return refund_id; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    refund_id = value;
                    PushKeyValue("refund_id", value);
                }
            }
        }
    }
}
