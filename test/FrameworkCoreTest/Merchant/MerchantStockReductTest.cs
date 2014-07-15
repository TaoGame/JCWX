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
    public class MerchantStockReductTest : MockPostApiBaseTest<MerchantStockReduceRequest, DefaultResponse>
    {
        [Fact]
        public void MockMerchantStockReduceSuccess()
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

        protected override MerchantStockReduceRequest InitRequestObject()
        {
            return new MerchantStockReduceRequest
            {
                AccessToken = "123",
                ProductID = "pDf3iY5EYkMxs4-tF8xedyES5GqI",
                Quantity = 20,
                SkuInfo = "10000983:10000995;10001007:10001010"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            return errResult ? s_errmsg : s_successmsg;
        }
    }
}
