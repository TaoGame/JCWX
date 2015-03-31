using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WX.Model.ApiResponses;
using WX.Model.ApiRequests;
using WX.Framework;

namespace FrameworkCoreTest
{
    public class UserGetTest : MockPostApiBaseTest<UserGetRequest, UserGetResponse>
    {
        [Fact]
        public void MockUserGetTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(2, response.Total);
            Assert.Equal(2, response.Count);
            Assert.Equal(2, response.Data.OpenIds.Length);
            Assert.Equal("NEXT_OPENID", response.NextOpenId);
        }

        [Fact]
        public void MockUserGetErrorTest()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(40013, response.ErrorCode);
        }

        [Fact]
        public void ReallyUserGetTest()
        {
            var request = new UserGetRequest
            {
                AccessToken = GetCurrentToken(),
                NextOpenId = "oI1_vjreLbQfGy79Thnsh4ziJZNo"
            };
            var response = m_client.Execute(request);
            if (!response.IsError)
            {
                foreach (var user in response.Data.OpenIds)
                {
                    Console.WriteLine(user);
                }
            }
        }

        protected override UserGetRequest InitRequestObject()
        {
            return new UserGetRequest
            {
                AccessToken = GetCurrentToken(),
                NextOpenId = ""
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
            {
                return "{\"errcode\":40013,\"errmsg\":\"invalid appid\"}";
            }

            return "{\"total\":2,\"count\":2,\"data\":{\"openid\":[\"OPENID1\",\"OPENID2\"]},\"next_openid\":\"NEXT_OPENID\"}";
        }
    }
}
