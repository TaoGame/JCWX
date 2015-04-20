using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest.Api
{
    public class CustomserviceKfsessionGetsessionTest : MockPostApiBaseTest<CustomserviceKfsessionGetsessionRequest, CustomserviceKfsessionGetsessionResponse>
    {
        protected override CustomserviceKfsessionGetsessionRequest InitRequestObject()
        {
            return new CustomserviceKfsessionGetsessionRequest
            {
                AccessToken = "123",
                OpenId = "openid"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return @"{
                ""createtime"" : 123456789,
                ""errcode"" : 0,
                ""errmsg"" : ""ok"",
                ""kf_account"" : ""test1@test""
             }";
        }

        public override CustomserviceKfsessionGetsessionResponse GetResponse()
        {
            return mock_client.Object.Execute(Request);
        }
    }
}
