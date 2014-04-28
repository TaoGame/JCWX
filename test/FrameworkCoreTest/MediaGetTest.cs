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
    public class MediaGetTest : MockPostApiBaseTest<MediaGetRequest, MediaGetResponse>
    {
        [Fact]
        public void MockMediaGetTest()
        {
            IsMock = true;
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Console.WriteLine(response);
        }

        [Fact]
        public void MockMediaGetErrorTest()
        {
            IsMock = true;
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(true, response.IsError);
            Assert.Equal(40004, response.ErrorCode);
        }

        [Fact]
        public void ReallyMediaGetTest()
        {
            IsMock = false;
            var response = m_client.Execute(Request);
            Console.WriteLine(response);
        }

        protected override MediaGetRequest InitRequestObject()
        {
            return new MediaGetRequest
            {
                AccessToken = GetCurrentToken(),
                MediaId = "iofROOOriAPeiX6zeMG4rt2LKGWgav7kPKNZKxXqhc7l4BYCNx_JLWQyUfKqzR_i"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
                return "{\"errcode\":40004,\"errmsg\":\"invalid media type\"}";
            return "200";
        }
    }
}
