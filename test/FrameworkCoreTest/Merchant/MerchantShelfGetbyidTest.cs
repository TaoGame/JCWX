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
    public class MerchantShelfGetbyidTest : MockPostApiBaseTest<MerchantShelfGetbyidRequest, MerchantShelfGetbyidResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(123, response.ShelfID);
            Assert.Equal(1, response.ShelfInfo.Modules.Count());
            Assert.Equal(typeof(ShelfModuleFive), response.ShelfInfo.Modules.FirstOrDefault().GetType());
        }

        protected override MerchantShelfGetbyidRequest InitRequestObject()
        {
            return new MerchantShelfGetbyidRequest
            {
                AccessToken = "123",
                ShelfID = 12312312
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            var shelf = new
            {
                errcode = 0,
                errmsg = "success",
                shelf_banner = "banner",
                shelf_name = "shelf 1",
                shelf_id = 123,
                shelf_info = new ShelfModulesInfo
                {
                    Modules = new List<ShelfModule>{
                                new ShelfModuleFive(
                                    new long[]{2000080093, 2000080094, 2000080095},
                                    "imgbackgournd.jpg"
                                    )
                            },
                }
            };
            var result = JsonSerialize(shelf);
            Console.WriteLine(result);
            return result;
        }
    }
}
