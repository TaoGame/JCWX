using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WX.Pay.Response
{
    [XmlRoot("xml")]
    public class PayRefundResponse : PayResponse
    {
        /// <summary>
        /// 微信订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [XmlElement("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [XmlElement("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// 退款渠道 ORIGINAL—原路退款 BALANCE—退回到余额
        /// </summary>
        [XmlElement("refund_channel")]
        public string RefundChannel { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        [XmlElement("refund_fee")]
        public int RefundFee { get; set; }

        /// <summary>
        /// 退款货币种类
        /// </summary>
        [XmlIgnore]
        [Obsolete]
        public string RefundFeeType { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        [XmlElement("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 订单金额货币种类
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// </summary>
        [XmlElement("cash_fee")]
        public int CashFee { get; set; }

        /// <summary>
        /// 货币种类
        /// </summary>
        [XmlIgnore]
        [Obsolete]
        public string CashFeeType { get; set; }

        /// <summary>
        /// 现金退款金额
        /// </summary>
        [XmlElement("cash_refund_fee")]
        public int CashRefundFee { get; set; }

        /// <summary>
        /// 现金退款货币类型
        /// </summary>
        [XmlIgnore]
        [Obsolete]
        public string CashRefundFeeType { get; set; }

        /// <summary>
        /// 代金券或立减优惠退款金额
        /// </summary>
        [XmlElement("coupon_refund_fee")]
        public int CouponRefundFee { get; set; }


        /// <summary>
        /// 代金券或立减优惠使用数量
        /// </summary>
        [XmlElement("coupon_count")]
        public int CouponCount { get; set; }

        /// <summary>
        /// 代金券或立减优惠ID
        /// </summary>
        [XmlElement("coupon_refund_id")]
        public string CouponRefundId { get; set; }

        //代金券或立减优惠批次ID
        //coupon_batch_id_$n
        //否
        //String(20)
        //100
        //代金券或立减优惠批次ID ,$n为下标，从1开始编号
        //代金券或立减优惠ID
        //coupon_id_$n
        //否
        //String(20)
        //10000 
        //代金券或立减优惠ID, $n为下标，从1开始编号
        //单个代金券或立减优惠支付金额
        //coupon_fee_$n
        //否
        //Int
        //100
        //单个代金券或立减优惠支付金额, $n为下标，从1开始编号
    }
}
