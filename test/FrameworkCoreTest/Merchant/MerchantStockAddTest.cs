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
    public class MerchantStockAddTest : MockPostApiBaseTest<MerchantStockAddRequest, DefaultResponse>
    {
        [Fact]
        public void MockMerchantStockAddSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
        }

        [Fact]
        public void MockGetPostContent()
        {
            Console.WriteLine(Request.GetPostContent());
        }

        protected override MerchantStockAddRequest InitRequestObject()
        {
            return new MerchantStockAddRequest
            {
                AccessToken = "123",
                ProductID = "pDf0123lj-asdf-j3kasdfjk",
                Quantity = 10,
                SkuInfo = "111:111;222:222"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            return errResult ? s_errmsg : s_successmsg;
        }
    }
}
