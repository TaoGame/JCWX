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
    public class MerchantGroupProductmodTest : MockPostApiBaseTest<MerchantGroupProductmodRequest, DefaultResponse>
    {
        protected override MerchantGroupProductmodRequest InitRequestObject()
        {
            return new MerchantGroupProductmodRequest
            {
                AccessToken = "123",
                GroupDetail = new WX.Model.MerchantGroupDetail
                {
                    GroupId = 28,
                    Product = new List<ProductInfo>{
                        new ProductInfo{ ProductID = "product1", ModAction = 1},
                        new ProductInfo{ ProductID = "product2", ModAction = 2  }
                    }
                }
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            return errResult ? s_errmsg : s_successmsg;
        }
    }
}
