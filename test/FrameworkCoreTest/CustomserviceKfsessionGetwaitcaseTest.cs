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
    public class CustomserviceKfsessionGetwaitcaseTest : MockPostApiBaseTest<CustomserviceKfsessionGetwaitcaseRequest, CustomserviceKfsessionGetwaitcaseResponse>
    {
        protected override CustomserviceKfsessionGetwaitcaseRequest InitRequestObject()
        {
            return new CustomserviceKfsessionGetwaitcaseRequest{
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return @"{
            ""count"" : 150,
            ""waitcaselist"" : [
               {
                  ""createtime"" : 123456789,
                  ""kf_account"" : ""test1@test"",
                  ""openid"" : ""OPENID""
               },
               {
                  ""createtime"" : 123456789,
                  ""kf_account"" : """",
                  ""openid"" : ""OPENID""
               }
            ]
         }";
        }

        public override CustomserviceKfsessionGetwaitcaseResponse GetResponse()
        {
 	        return mock_client.Object.Execute(Request);
        }
    }
}
