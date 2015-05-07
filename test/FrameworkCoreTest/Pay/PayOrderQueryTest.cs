using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Pay.Request;
using WX.Pay.Response;
using System.Configuration;

namespace FrameworkCoreTest.Pay
{
    public class PayOrderQueryTest : PayTest<PayOrderqueryRequest, PayOrderqueryResponse>
    {
        protected override PayOrderqueryRequest GetRequest()
        {
            return new PayOrderqueryRequest
            {
               
                OutTradeNo = "DB123123123",
                NonceStr = "123123"
            };
        }

        protected override string GetResponseXml()
        {
            throw new NotImplementedException();
        }
    }
}
