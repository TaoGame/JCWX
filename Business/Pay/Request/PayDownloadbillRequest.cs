using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WX.Pay.Response;

namespace WX.Pay.Request
{
    /// <summary>
    /// 下载对账单
    /// 商户可以通过该接口下载历史交易清单。比如掉单、系统错误等导致商户侧和微信侧数据不一致，通过对账单核对后可校正支付状态。
    /// 注意：
    /// 1.微信侧未成功下单的交易不会出现在对账单中。支付成功后撤销的交易会出现在对账单中，跟原支付单订单号一致，bill_type为REVOKED；
    /// 2.微信在次日9点启动生成前一天的对账单，建议商户10点后再获取；
    /// 3.对账单中涉及金额的字段单位为“元”。
    /// </summary>
    public class PayDownloadbillRequest : PayRequest<PayDownloadResponse>
    {
        public override string Url
        {
            get { return "https://api.mch.weixin.qq.com/pay/downloadbill"; }
        }

        private string _billdate;

        /// <summary>
        /// 对账单日期
        /// </summary>
        [XmlElement("bill_date")]
        public string BillDate
        {
            get { return _billdate; }
            set
            {
                _billdate = value;
                PushKeyValue("bill_date", value);
            }
        }

        private string _bill_type;

        /// <summary>
        /// 账单类型
        /// ALL，返回当日所有订单信息，默认值
        /// SUCCESS，返回当日成功支付的订单
        /// REFUND，返回当日退款订单
        /// REVOKED，已撤销的订单
        /// </summary>
        [XmlElement("bill_type")]
        public string BillType
        {
            get { return _bill_type; }
            set
            {
                _bill_type = value;
                PushKeyValue("bill_type", value);
            }
        }
    }
}
