using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Pay.Request;
using WX.Pay.Response;

namespace FrameworkCoreTest.Pay
{
    public class ReallyPayUnifiedorderRequestTest : PayTest<PayUnifiedOrderRequest, PayUnifiedOrderResponse>
    {
        protected override PayUnifiedOrderRequest GetRequest()
        {
            var date = DateTime.Today;

            return new PayUnifiedOrderRequest
            {
                
                Attach = "测试支付订单",
                Body = "测试支付订单",
                Detail = "测试支付订单",
                DeviceInfo = "test pay order",
                NonceStr = "123123",
                NotifyUrl = "http://www.sh-bus.com",
                OutTradeNo = "DB123123124",
                ProductId = "123123",
                SpbillCreateIp = "127.0.0.1",
                TimeStart = date.ToString("yyyyMMddHHmmss"),
                TimeExpire = date.AddDays(4).ToString("yyyyMMddHHmmss"),
                TotalFee = 100,
                TradeType = "NATIVE"
            };
        }

        protected override string GetResponseXml()
        {
            throw new NotImplementedException();
        }
    }
}
