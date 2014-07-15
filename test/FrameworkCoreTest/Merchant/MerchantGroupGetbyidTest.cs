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
    public class MerchantGroupGetbyidTest : MockPostApiBaseTest<MerchantGroupGetbyidRequest, MerchantGroupGetbyidResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(2000077549, response.GroupDetail.GroupId);
            Assert.Equal(3, response.GroupDetail.ProductList.Count());
        }

        protected override MerchantGroupGetbyidRequest InitRequestObject()
        {
            return new MerchantGroupGetbyidRequest
            {
                AccessToken = "a123",
                GroupID = 29
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return JsonSerialize(new { 
                errcode = 0,
                errmsg = "success",
                group_detail = new
                {
                    group_id = 2000077549,
                    group_name = "last update",
                    product_list = new string[]{ 
                        "product 1",
                        "product 2",
                        "product 3"
                    }
                }
            });
        }
    }
}
