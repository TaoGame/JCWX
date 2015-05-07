using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WX.Pay.Response
{
    [XmlRoot("xml")]
    public class PayOrderqueryResponse : PayResponse
    {

        /// <summary>
        /// 用户在商户appid下的唯一标识
        /// </summary>
        [XmlElement("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
        /// </summary>
        [XmlElement("is_subscribe")]
        public string IsSubcribe { get; set; }

        /// <summary>
        /// 交易类型
        /// 调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP，MICROPAY，详细说明见http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        /// 交易状态
        /// SUCCESS—支付成功
        ///REFUND—转入退款
        ///NOTPAY—未支付
        ///CLOSED—已关闭
        ///REVOKED—已撤销
        ///USERPAYING--用户支付中
        ///PAYERROR--支付失败(其他原因，如银行返回失败)
        /// </summary>
        [XmlElement("trade_state")]
        public string TradeState { get; set; }

        /// <summary>
        /// 付款银行 银行类型，采用字符串类型的银行标识
        /// </summary>
        [XmlElement("bank_type")]
        public string BankType { get; set; }

        /// <summary>
        /// 总金额 订单总金额，单位为分
        /// </summary>
        [XmlElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 货币种类 货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额 详见http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2
        /// </summary>
        [XmlElement("cash_fee")]
        public int CashFee { get; set; }

        /// <summary>
        /// 货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=4_2
        /// </summary>
        [XmlElement("cash_fee_type")]
        public string CashFeeType { get; set; }

        /// <summary>
        /// 代金券或立减优惠”金额 订单总金额，订单总金额-“代金券或立减优惠”金额=现金支付金额，详见
        /// </summary>
        [XmlElement("coupon_fee")]
        public int CouponFee { get; set; }

        /// <summary>
        /// 代金券或立减优惠使用数量
        /// </summary>
        [XmlElement("coupon_count")]
        public int CouponCount { get; set; }

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商家数据包
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间
        /// </summary>
        [XmlElement("time_end")]
        public string TimeEnd { get; set; }

        /// <summary>
        /// 交易状态描述
        /// </summary>
        [XmlElement("trade_state_desc")]
        public string TradeStateDesc { get; set; }
    }
}
