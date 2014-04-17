using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Framework;
using WX.Model;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest
{
    public class GroupCreateTest : MockPostApiBaseTest<GroupsCreateRequest, GroupCreateResponse>
    {
        
        [Fact]
        public void MockGroupCreateTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Console.WriteLine(response);
        }

        [Fact]
        public void MockGroupCreateErrorTest()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Console.WriteLine(response);
        }


        protected override string GetReturnResult(bool errResult)
        {
            if (!errResult)
            {
                return @"{
                    ""group"": 
                        {
                            ""id"": 0, 
                            ""name"": ""未分组"", 
                            ""count"": 72596
                        }
                }";
            }
            else
            {
                return "{\"errcode\":40013,\"errmsg\":\"invalid appid\"}";
            }
        }

        protected override GroupsCreateRequest InitRequestObject()
        {
            return new GroupsCreateRequest
            {
                AccessToken = "123",
                Group = new Group
                {
                    Name = "test"
                }
            };
        }
    }
}
