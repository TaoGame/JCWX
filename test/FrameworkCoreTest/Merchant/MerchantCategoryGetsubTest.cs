using Newtonsoft.Json;
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
    public class MerchantCategoryGetsubTest : MockPostApiBaseTest<MerchantCategoryGetsubRequest, MerchantCategoryGetsubResponse>
    {
        [Fact]
        public void MockMerchantCategoryGetsubSuccessTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(3, response.CateList.Count());
        }

        protected override MerchantCategoryGetsubRequest InitRequestObject()
        {
            return new MerchantCategoryGetsubRequest
            {
                CateID = 123,
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            var result = new
            {
                errcode = 0,
                errmsg = "success",
                cate_list = new List<Cate>
                {
                    new Cate{ Id = "123", Name = "1111"},
                    new Cate{Id = "222", Name= "2222"},
                    new Cate{Id = "333", Name = "333"}
                }
            };

            Console.WriteLine(JsonConvert.SerializeObject(result));
            return JsonConvert.SerializeObject(result);
        }
    }
}
