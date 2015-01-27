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
    public class MockGetcallbackipTestTest : MockPostApiBaseTest<GetcallbackipRequest, GetcallbackipResponse>
    {
        [Fact]
        public void MockCallbackiptest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(2, response.IPList.Count());
            foreach (var ip in response.IPList)
            {
                Console.WriteLine(ip);
            }
        }

        protected override GetcallbackipRequest InitRequestObject()
        {
            return new GetcallbackipRequest()
            {
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return "{\"ip_list\":[\"127.0.0.1\",\"127.0.0.1\"]}";
        }
    }
}
