using Newtonsoft.Json;
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
    public class MerchantGroupAddTest : MockPostApiBaseTest<MerchantGroupAddRequest, MerchantGroupAddResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(19, response.GroupID);
        }

        protected override MerchantGroupAddRequest InitRequestObject()
        {
            return new MerchantGroupAddRequest
            {
                GroupDetail = new WX.Model.MerchantGroupDetail
                {
                    Name = "测试分组",
                    ProductList = new string[] {"pdf3iy9ce1idje1","0dkajfdkjasldfkj3" }
                },
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;

            return JsonSerialize(new { 
                errcode = 0,
                errmsg = "success",
                group_id = 19
            });
        }
    }
}
