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
    public class GroupsGetIdTest : MockPostApiBaseTest<GroupsGetIdRequest, GroupsGetIdResponse>
    {
        private static string m_openId = "oI1_vjirqEuoDttmL-eRcsO-G9to";

        [Fact]
        public void MockGroupsGetIdTest()
        {
            MockSetup(false);
            Console.WriteLine(mock_client.Object.Execute(Request));
        }

        [Fact]
        public void MockGroupsGetIdErrorTest()
        {
            MockSetup(true);
            Console.WriteLine(mock_client.Object.Execute(Request));
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
            {
                return "{\"errcode\":40003,\"errmsg\":\"invalid openid\"}";
            }
            else
            {
                return @"{
                    ""groupid"": 102
                }";
            }
        }

        protected override GroupsGetIdRequest InitRequestObject()
        {
            return new GroupsGetIdRequest
            {
                AccessToken = "123",
                OpenId = m_openId
            };
        }
    }
}
