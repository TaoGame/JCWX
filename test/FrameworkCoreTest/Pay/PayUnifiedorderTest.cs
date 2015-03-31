using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WX.Pay.Request;
using WX.Pay.Response;

namespace FrameworkCoreTest.Pay
{
    public class PayUnifiedorderTest : PayTest<PayUnifiedOrderRequest, PayUnifiedOrderResponse>
    {

        protected override PayUnifiedOrderRequest GetRequest()
        {
            return new PayUnifiedOrderRequest
            {
                AppId = "appid",
                AppSecret = "appsecret",
                DeviceInfo = "nubia z7",
                NonceStr = "suijishuzuu",
                Body = "Ipad mini  16G  白色",
                Detail = "Ipad mini  16G  白色",
                Attach = "说明",
                OutTradeNo = "1217752501201407033233368018",
                TotalFee = 888,
                SpbillCreateIp = "8.8.8.8",
                TimeStart = DateTime.Now.ToString("yyyyMMddHHmmss"),
                TimeExpire = DateTime.Now.AddDays(2).ToString("yyyyMMddHHmmss"),
                NotifyUrl = "http://www.test.com/notifyurl",

            };
        }

        protected override string GetResponseXml()
        {
            return @"<xml>
                       <return_code><![CDATA[SUCCESS]]></return_code>
                       <return_msg><![CDATA[OK]]></return_msg>
                       <appid><![CDATA[wx2421b1c4370ec43b]]></appid>
                       <mch_id><![CDATA[10000100]]></mch_id>
                       <nonce_str><![CDATA[IITRi8Iabbblz1Jc]]></nonce_str>
                       <sign><![CDATA[7921E432F65EB8ED0CE9755F0E86D72F]]></sign>
                       <result_code><![CDATA[SUCCESS]]></result_code>
                       <prepay_id><![CDATA[wx201411101639507cbf6ffd8b0779950874]]></prepay_id>
                       <trade_type><![CDATA[JSAPI]]></trade_type>
                    </xml>";
        }

        protected override PayUnifiedOrderResponse ParseResponse(string xml)
        {
            var stream = new MemoryStream(Encoding.Default.GetBytes(xml));
            var xs = new XmlSerializer(typeof(PayUnifiedOrderResponse), "");
            return (PayUnifiedOrderResponse)xs.Deserialize(stream);
        }

        
    }
}
