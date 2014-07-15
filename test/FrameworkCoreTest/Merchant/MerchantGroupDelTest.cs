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
    public class MerchantGroupDelTest : MockPostApiBaseTest<MerchantGroupDelRequest, DefaultResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
        }

        protected override MerchantGroupDelRequest InitRequestObject()
        {
            return new MerchantGroupDelRequest
            {
                AccessToken = "123",
                GroupID = 19
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            return errResult ? s_errmsg : s_successmsg;
        }
    }
}
