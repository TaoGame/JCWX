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
    public class MerchantOrderSetdeliveryTest : MockPostApiBaseTest<MerchantOrderSetdeliveryRequest, DefaultResponse>
    {


        protected override MerchantOrderSetdeliveryRequest InitRequestObject()
        {
            return new MerchantOrderSetdeliveryRequest
            {
                AccessToken = "123",
                DeliveryCompany = DeliveryCompany.EMS,
                DeliveryTrackNo = "1900659372473",
                OrderID = "7197417460812533543"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return s_successmsg;
        }
    }
}
