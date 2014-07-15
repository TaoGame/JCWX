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
    public class MerchantDelTest : MockPostApiBaseTest<MerchantDelRequest, DefaultResponse>
    {
        [Fact]
        public void MockGetPostContent()
        {
            Console.WriteLine(Request.GetPostContent());
        }

        [Fact]
        public void MockDeleteSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
        }


        protected override MerchantDelRequest InitRequestObject()
        {
            return new MerchantDelRequest
            {
                ProductID = "123456789",
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return s_successmsg;
        }
    }
}
