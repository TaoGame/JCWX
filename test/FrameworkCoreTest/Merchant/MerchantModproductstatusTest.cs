using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest.Merchant
{
    public class MerchantModproductstatusTest : MockPostApiBaseTest<MerchantModproductstatusRequest, DefaultResponse>
    {
        [Fact]
        public void MockMerchantModProductStatusTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
        }

        protected override MerchantModproductstatusRequest InitRequestObject()
        {
            return new MerchantModproductstatusRequest
            {
                ProductID = "123456789",
                Status = 0,
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            return errResult ? s_errmsg : s_successmsg;
        }
    }
}
