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
    public class GroupsMembersUpdateTest : MockPostApiBaseTest<GroupsMembersUpdateRequest, GroupsMembersUpdateResponse>
    {
        [Fact]
        public void GroupsMembersUpdateJsonTest()
        {
            Console.WriteLine(Request.GetPostContent());
        }

        [Fact]
        public void MockGroupsMemberUpdateTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(0, response.ErrorCode);
            Assert.Equal("ok", response.ErrorMessage);
            Assert.Equal(false, response.IsError);
        }

        [Fact]
        public void MockGroupsMemberUpdateErrorTest()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(40013, response.ErrorCode);
            Assert.Equal("invalid appid", response.ErrorMessage);
            Assert.Equal(true, response.IsError);
        }

        protected override GroupsMembersUpdateRequest InitRequestObject()
        {
            return new GroupsMembersUpdateRequest
            {
                AccessToken = "123",
                OpenId = "test_openid",
                ToGroupId = 100
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
                return "{\"errcode\":40013,\"errmsg\":\"invalid appid\"}";
            return "{\"errcode\": 0, \"errmsg\": \"ok\"}";
        }
    }
}
