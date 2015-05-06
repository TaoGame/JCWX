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
                PayApiSecret = "appsecret",
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
                       <return_code><![CDATA[FAIL]]></return_code>
                       <return_msg><![CDATA[中文出错]]></return_msg>
                       
                    </xml>";
        }
               
    }
}
