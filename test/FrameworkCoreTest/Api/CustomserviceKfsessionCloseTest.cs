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
    public class CustomserviceKfsessionCloseTest : MockPostApiBaseTest<CustomserviceKfsessionCloseRequest, CustomserviceKfsessionCloseResponse>
    {
        protected override CustomserviceKfsessionCloseRequest InitRequestObject()
        {
            return new CustomserviceKfsessionCloseRequest
            {
                AccessToken = "123",
                KfAccount = "kf@kf.com",
                OpenId = "asdf",
                Text = "zsdfa"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return @" {
                ""errcode"" : 0,
                ""errmsg"" : ""ok""
             }";
        }

        public override CustomserviceKfsessionCloseResponse GetResponse()
        {
            return mock_client.Object.Execute(Request);
        }
    }
}
