using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest.Merchant
{
    public class MerchantGroupGetallTest : MockPostApiBaseTest<MerchantGroupGetallRequest, MerchantGroupGetallResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(2, response.GroupsDetail.Count());
        }

        protected override MerchantGroupGetallRequest InitRequestObject()
        {
            return new MerchantGroupGetallRequest
            {
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;

            return JsonSerialize(new { 
                errcode = 0,
                errmsg = "success",
                groups_detail = new List<MerchantGroupDetail>
                {
                    new MerchantGroupDetail{ GroupId = 200077549, Name = "last update"},
                    new MerchantGroupDetail{GroupId = 200079772, Name = "hot"}
                }
            });
        }
    }
}
