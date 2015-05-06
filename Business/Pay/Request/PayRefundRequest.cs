using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WX.Pay.Response;

namespace WX.Pay.Request
{
    [XmlRoot("xml")]
    public class PayRefundRequest : PayRequest<PayRefundResponse>
    {
        [XmlIgnore]
        public override string Url
        {
            get { return "https://api.mch.weixin.qq.com/secapi/pay/refund"; }
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

        private int total_fee;

        /// <summary>
        /// 总金额
        /// </summary>
        [XmlElement("total_fee")]
        public int TotalFee
        {
            get { return total_fee; }
            set
            {

                total_fee = value;
                PushKeyValue("total_fee", value.ToString());

            }
        }

        private int refund_fee;

        /// <summary>
        /// 退款金额
        /// </summary>
        [XmlElement("refund_fee")]
        public int RefundFee
        {
            get { return refund_fee; }
            set
            {

                refund_fee = value;
                PushKeyValue("refund_fee", value.ToString());

            }
        }

        private string refund_fee_type;

        /// <summary>
        /// 货币种类
        /// </summary>
        [XmlElement("refund_fee_type")]
        public string RefundFeeType
        {
            get { return refund_fee_type; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    refund_fee_type = value;
                    PushKeyValue("refund_fee_type", value);
                }
            }
        }

        private string op_user_id;

        /// <summary>
        /// 操作员
        /// </summary>
        [XmlElement("op_user_id")]
        public string OpUserId
        {
            get { return op_user_id; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    op_user_id = value;
                    PushKeyValue("op_user_id", value);
                }
            }
        }
    }
}
