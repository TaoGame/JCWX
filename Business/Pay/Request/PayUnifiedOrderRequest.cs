using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WX.Pay.Response;

namespace WX.Pay.Request
{
    /// <summary>
    /// 统一下单
    /// 除被扫支付场景以外，商户系统先调用该接口在微信支付服务后台生成预支付交易单，返回正确的预支付交易回话标识后再按扫码、JSAPI、APP等不同场景生成交易串调起支付。
    /// </summary>
    [XmlRoot(ElementName = "xml", DataType = "string")]
    public class PayUnifiedOrderRequest : PayRequest<PayUnifiedOrderResponse>
    {
        [XmlIgnore]
        public override string Url
        {
            get { return "https://api.mch.weixin.qq.com/pay/unifiedorder"; }
        }

        private string device_info;

        /// <summary>
        /// 设备号 微信支付分配的终端设备号，商户自定义
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
        /// 随机字符串 随机字符串，不长于32位 http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_3
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

        private string body;

        /// <summary>
        /// 商品描述 商品或支付单简要描述
        /// </summary>
        [XmlElement("body")]
        public string Body
        {
            get { return body; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    body = value;
                    PushKeyValue("body", value);
                }
            }
        }

        private string detail;

        /// <summary>
        /// 商品详情 商品名称明细列表
        /// </summary>
        //[XmlElement("detail")]
        [XmlIgnore]
        public string Detail
        {
            get { return detail; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    detail = value;
                    PushKeyValue("detail", value);
                }
            }
        }

        /// <summary>
        /// 请勿赋值
        /// </summary>
        [XmlElement("detail")]
        public XmlCDataSection CDetail
        {
            get { return _doc.CreateCDataSection(detail); }
            set { ;}
        }

        private string attach;

        /// <summary>
        /// 附加数据 附加数据，在查询API和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据
        /// </summary>
        [XmlElement("attach")]
        public string Attach
        {
            get { return attach; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    attach = value;
                    PushKeyValue("attach", value);
                }
            }
        }

        private string out_trade_no;

        /// <summary>
        /// 商户订单号 商户系统内部的订单号,32个字符内、可包含字母, 其他说明见商户订单号
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

        private string fee_type;

        /// <summary>
        /// 货币类型 符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType
        {
            get { return fee_type; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    fee_type = value;
                    PushKeyValue("fee_type", value);
                }
            }
        }

        private int total_fee;

        /// <summary>
        /// 总金额 订单总金额，只能为整数，详见支付金额 http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2
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

        private string spbill_create_ip;

        /// <summary>
        /// 终端IP APP和网页支付提交用户端ip，Native支付填调用微信支付API的机器IP。
        /// </summary>
        [XmlElement("spbill_create_ip")]
        public string SpbillCreateIp
        {
            get { return spbill_create_ip; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    spbill_create_ip = value;
                    PushKeyValue("spbill_create_ip", value);
                }
            }
        }

        private string time_start;

        /// <summary>
        /// 交易起始时间 订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010
        /// </summary>
        [XmlElement("time_start")]
        public string TimeStart
        {
            get { return time_start; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    time_start = value;
                    PushKeyValue("time_start", value);
                }
            }
        }

        private string time_expire;

        /// <summary>
        /// 交易结束时间 订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010
        /// </summary>
        [XmlElement("time_expire")]
        public string TimeExpire
        {
            get { return time_expire; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    time_expire = value;
                    PushKeyValue("time_expire", value);
                }
            }
        }

        private string goods_tag;

        /// <summary>
        /// 商品标记 商品标记，代金券或立减优惠功能的参数，说明详见http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=12_1
        /// </summary>
        [XmlElement("goods_tag")]
        public string GoodsTag
        {
            get { return goods_tag; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    goods_tag = value;
                    PushKeyValue("goods_tag", value);
                }
            }
        }

        private string notify_url;

        /// <summary>
        /// 通知地址 接收微信支付异步通知回调地址
        /// </summary>
        [XmlElement("notify_url")]
        public string NotifyUrl
        {
            get { return notify_url; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    notify_url = value;
                    PushKeyValue("notify_url", value);
                }
            }
        }

        private string trade_type;

        /// <summary>
        /// 交易类型 取值如下：JSAPI，NATIVE，APP，详细说明见http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType
        {
            get { return trade_type; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    trade_type = value;
                    PushKeyValue("trade_type", value);
                }
            }
        }

        private string product_id;

        /// <summary>
        /// 商品ID trade_type=NATIVE，此参数必传。此id为二维码中包含的商品ID，商户自行定义。
        /// </summary>
        [XmlElement("product_id")]
        public string ProductId
        {
            get { return product_id; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    product_id = value;
                    PushKeyValue("product_id", value);
                }
            }
        }

        private string openid;

        /// <summary>
        /// 用户标识 trade_type=JSAPI，此参数必传，用户在商户appid下的唯一标识。下单前需要调用【网页授权获取用户信息】接口获取到用户的Openid。
        /// </summary>
        [XmlElement("openid")]
        public string Openid
        {
            get { return openid; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    openid = value;
                    PushKeyValue("openid", value);
                }
            }
        }
    }
}
