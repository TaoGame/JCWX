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
    public class MerchantGroupPropertymodTest : MockPostApiBaseTest<MerchantGroupPropertymodRequest, DefaultResponse>
    {
       
        protected override MerchantGroupPropertymodRequest InitRequestObject()
        {
            return new MerchantGroupPropertymodRequest
            {
                AccessToken = "123",
                GroupDetail = new WX.Model.MerchantGroupDetail
                {
                    GroupId = 29,
                    Name = "特惠专场"
                }
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            return errResult ? s_errmsg : s_successmsg;
        }
    }
}
