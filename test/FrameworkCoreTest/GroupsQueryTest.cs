using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Framework;
using WX.Model.ApiRequests;
using WX.Model.Exceptions;
using Xunit;

namespace FrameworkCoreTest
{
    public class GroupsQueryTest : BaseTest
    {
        [Fact]
        public void GroupsQueryTestNoToken()
        {
            var request = new GroupsQueryRequest();

            Assert.Throws<WXApiException>(() =>
                {
                    m_client.Execute(request);
                });
        }

        [Fact]
        public void MockGroupsQueryTest()
        {
            var request = new GroupsQueryRequest()
            {
                AccessToken = "asdf"
            };
            var doresult = @"{
            ""groups"": [
                {
                    ""id"": 0, 
                    ""name"": ""未分组"", 
                    ""count"": 72596
                }, 
                {
                    ""id"": 1, 
                    ""name"": ""黑名单"", 
                    ""count"": 36
                }, 
                {
                    ""id"": 2, 
                    ""name"": ""星标组"", 
                    ""count"": 8
                }, 
                {
                    ""id"": 104, 
                    ""name"": ""华东媒"", 
                    ""count"": 4
                }, 
                {
                    ""id"": 106, 
                    ""name"": ""★不测试组★"", 
                    ""count"": 1
                }
            ]
        }";
            mock_client.Setup(d => d.DoExecute(request)).Returns(doresult);
            var response = mock_client.Object.Execute(request);
            foreach (var group in response.Groups)
            {
                Console.WriteLine("id:{0}, name:{1}, count:{2}", group.ID, group.Name, group.Count);
            }
        }

        [Fact]
        public void GrousQueryTest()
        {
            //ApiAccessTokenManager.Instance.SetAppIdentity(m_appIdentity);
            var token = GetCurrentToken();
            var request = new GroupsQueryRequest()
            {
                AccessToken = token
            };
            var response = m_client.Execute(request);
            if (!response.IsError)
            {
                foreach (var group in response.Groups)
                {
                    Console.WriteLine("id:{0}, name:{1}, count:{2}", group.ID, group.Name, group.Count);
                }
            }
            else
            {
                Console.WriteLine(response.ErrorCode + ", " + response.ErrorMessage);
            }
        }
    }
}
