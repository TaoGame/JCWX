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
    public class MerchantOrderCloseTest : MockPostApiBaseTest<MerchantOrderCloseRequest, DefaultResponse>
    {
        protected override MerchantOrderCloseRequest InitRequestObject()
        {
            return new MerchantOrderCloseRequest
            {
                AccessToken = "123",
                OrderID = "7197417460812584720"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return s_successmsg;
        }
    }
}
