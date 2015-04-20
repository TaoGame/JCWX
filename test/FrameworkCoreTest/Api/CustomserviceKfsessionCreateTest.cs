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
    public class CustomserviceKfsessionCreateTest : MockPostApiBaseTest<CustomserviceKfsessionCreateRequest, CustomserviceKfsessionCreateResponse>
    {
        protected override CustomserviceKfsessionCreateRequest InitRequestObject()
        {
            return new CustomserviceKfsessionCreateRequest
            {
                AccessToken = "123",
                KfAccount = "kf@kf.com",
                OpenId = "123lkjzcv",
                Text = "this is test text"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return @"{
                ""kf_account"" : ""test1@test"",
                ""openid"" : ""OPENID"",
                ""text"" : ""这是一段附加信息""
             }";
        }

        public override CustomserviceKfsessionCreateResponse GetResponse()
        {
            return mock_client.Object.Execute(Request);
        }
    }
}
