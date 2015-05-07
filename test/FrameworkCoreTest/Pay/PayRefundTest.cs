using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Pay.Response;
using WX.Pay.Request;

namespace FrameworkCoreTest.Pay
{
    public class PayRefundTest : PayTest<PayRefundRequest, PayRefundResponse>
    {
        protected override PayRefundRequest GetRequest()
        {
            return new PayRefundRequest
            {
                AppId = "wx2421b1c4370ec43b",
                MchId = "10000100",
                NonceStr = "6cefdb308e1e2e8aabd48cf79e546a02",
                OpUserId = "10000100",
                OutRefundNo = "1415701182",
                OutTradeNo = "1415757673",
                RefundFee = 1,
                TotalFee = 1,
            };
        }

        protected override string GetResponseXml()
        {
            return @"<xml>
                   <return_code><![CDATA[SUCCESS]]></return_code>
                   <return_msg><![CDATA[OK]]></return_msg>
                   <appid><![CDATA[wx2421b1c4370ec43b]]></appid>
                   <mch_id><![CDATA[10000100]]></mch_id>
                   <nonce_str><![CDATA[NfsMFbUFpdbEhPXP]]></nonce_str>
                   <sign><![CDATA[B7274EB9F8925EB93100DD2085FA56C0]]></sign>
                   <result_code><![CDATA[SUCCESS]]></result_code>
                   <transaction_id><![CDATA[1008450740201411110005820873]]></transaction_id>
                   <out_trade_no><![CDATA[1415757673]]></out_trade_no>
                   <out_refund_no><![CDATA[1415701182]]></out_refund_no>
                   <refund_id><![CDATA[2008450740201411110000174436]]></refund_id>
                   <refund_channel><![CDATA[]]></refund_channel>
                   <refund_fee>1</refund_fee>
                   <coupon_refund_fee>0</coupon_refund_fee>
                </xml>";
        }
    }
}
