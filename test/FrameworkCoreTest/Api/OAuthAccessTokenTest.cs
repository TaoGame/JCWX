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
    public class OAuthAccessTokenTest : MockPostApiBaseTest<SnsOAuthAccessTokenRequest, SnsOAuthAccessTokenResponse>
    {
        [Fact]
        public void MockSnsOAuthAccessTokenTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal("ACCESS_TOKEN", response.AccessToken);
            Assert.Equal(7200, response.ExpiresIn);
            Assert.Equal("OPENID", response.OpenId);
            Assert.Equal("REFRESH_TOKEN", response.RefreshToken);
            Assert.Equal("SCOPE", response.Scope);
        }

        [Fact]
        public void MockSnsOAuthAccessTokenErrorTest()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Console.WriteLine(response);
        }

        protected override SnsOAuthAccessTokenRequest InitRequestObject()
        {
            return new SnsOAuthAccessTokenRequest
            {
                AppID = "AppID",
                AppSecret = "SECRET",
                Code = "CODE"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
            {
                return "{\"errcode\":40029,\"errmsg\":\"invalid code\"}";
            }
            return @"{
                       ""access_token"":""ACCESS_TOKEN"",
                       ""expires_in"":7200,
                       ""refresh_token"":""REFRESH_TOKEN"",
                       ""openid"":""OPENID"",
                       ""scope"":""SCOPE""
                    }";
        }
    }
}
