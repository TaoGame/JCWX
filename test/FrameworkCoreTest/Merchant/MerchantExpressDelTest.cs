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
    public class MerchantExpressDelTest : MockPostApiBaseTest<MerchantExpressDelRequest, DefaultResponse>
    {
        [Fact]
        public void Fail()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(true, response.IsError);
        }

        [Fact]
        public void Success()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
        }

        protected override MerchantExpressDelRequest InitRequestObject()
        {
            return new MerchantExpressDelRequest { 
                AccessToken = "123",
                TemplateID = 123123
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            return errResult ? s_errmsg : s_successmsg;
        }
    }
}
