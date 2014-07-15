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
    public class MerchantShelfDelTest : MockPostApiBaseTest<MerchantShelfDelRequest, DefaultResponse>
    {
        protected override MerchantShelfDelRequest InitRequestObject()
        {
            return new MerchantShelfDelRequest
            {
                AccessToken = "123",
                ShelfID = 19
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            throw new NotImplementedException();
        }
    }
}
