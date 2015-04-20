using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest
{
    public class CustomserviceKfsessionGetsessionlistTest : MockPostApiBaseTest<CustomserviceKfsessionGetsessionlistRequest, CustomserviceKfsessionGetsessionlistResponse>
    {
        protected override CustomserviceKfsessionGetsessionlistRequest InitRequestObject()
        {
            return new CustomserviceKfsessionGetsessionlistRequest
            {
                KfAccount = "test.123@.com",
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return @" {
            ""sessionlist"" : [
               {
                  ""createtime"" : 123456789,
                  ""openid"" : ""OPENID""
               },
               {
                  ""createtime"" : 123456789,
                  ""openid"" : ""OPENID""
               }
            ]
         }";
        }

        public override CustomserviceKfsessionGetsessionlistResponse GetResponse()
        {
            return mock_client.Object.Execute(Request);
        }
    }
}
