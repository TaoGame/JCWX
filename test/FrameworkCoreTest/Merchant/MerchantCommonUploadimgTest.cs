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
    public class MerchantCommonUploadimgTest : MockPostApiBaseTest<MerchantCommonUploadimgRequest, MerchantCommonUploadimgResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal("http://uploadimg.jpg", response.ImageUrl);
        }

        protected override MerchantCommonUploadimgRequest InitRequestObject()
        {
            return new MerchantCommonUploadimgRequest
            {
                AccessToken = "123",
                FileName = "1.jpg",
                FilePath = "e:\\123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return JsonSerialize(
                new
                {
                    errcode = 0,
                    errmsg = "success",
                    image_url = "http://uploadimg.jpg"
                });
        }
    }
}
