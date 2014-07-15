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
    public class MerchantShelfUpdatestatusTest : MockPostApiBaseTest<MerchantShelfUpdatestatusRequest, MerchantShelfUpdatestatusResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal("http://mp.weixin.qq.com/bizmall/mallshelf?t=mall/list", response.ShelfUrl);
        }

        [Fact]
        public void MockThrow()
        {
            MockSetup(false);
            Request.Status = 3;
            Assert.Throws(typeof(ArgumentOutOfRangeException), () =>
            {
                var response = mock_client.Object.Execute(Request);
            });
        }

        protected override MerchantShelfUpdatestatusRequest InitRequestObject()
        {
            return new MerchantShelfUpdatestatusRequest
            {
                AccessToken = "123",
                ShelfID = 97,
                Status = 1
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            return errResult ? s_errmsg :
                JsonSerialize(new
                {
                    errcode = 0,
                    errmsg = "success",
                    shelf_url = "http://mp.weixin.qq.com/bizmall/mallshelf?t=mall/list"
                });
        }
    }
}
