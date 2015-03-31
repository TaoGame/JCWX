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
    public class UserInfoTest : MockPostApiBaseTest<UserInfoRequest, UserInfoResponse>
    {
        [Fact]
        public void MockUserInfoTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal("o6_bmjrPTlm6_2sgVt7hMZOPfL2M", response.OpenId);
            Assert.Equal("广州", response.City);
            Assert.Equal("o6_bmasdasdsad6_2sgVt7hMZOPfL", response.UnionID);
        }

        [Fact]
        public void MockUserInfoErrorTest()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(true, response.IsError);
            Console.WriteLine(response);
        }

        protected override UserInfoRequest InitRequestObject()
        {
            return new UserInfoRequest
            {
                AccessToken = "asdf",
                Lang = "zh_cn",
                OpenId = "asdf"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
                return "{\"errcode\":40013,\"errmsg\":\"invalid appid\"}";
            return @"{
                    ""subscribe"": 1, 
                    ""openid"": ""o6_bmjrPTlm6_2sgVt7hMZOPfL2M"", 
                    ""nickname"": ""Band"", 
                    ""sex"": 1, 
                    ""language"": ""zh_CN"", 
                    ""city"": ""广州"", 
                    ""province"": ""广东"", 
                    ""country"": ""中国"", 
                    ""headimgurl"":    ""http://wx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/0"", 
                    ""subscribe_time"": 1382694957,
                    ""unionid"": ""o6_bmasdasdsad6_2sgVt7hMZOPfL""
                }";
        }
    }
}
