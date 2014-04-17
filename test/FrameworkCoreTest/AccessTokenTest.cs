using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Api;
using WX.Model;
using WX.Model.ApiRequests;
using Xunit;

namespace FrameworkCoreTest
{
    public class AccessTokenTest
    {
        [Fact]
        public void GetAccessTokenCore()
        {
            var appid = new AppIdentication("wx7fc05579394bd02c", "26f8f072c53e97d0033e3589e7de4e84");
            var request = new AccessTokenRequest(appid);
            IApiClient client = new DefaultApiClient();
            var response = client.Execute(request);

            Console.WriteLine(response.ToString());
        }

        [Fact]
        public void MatchMessageTest()
        {
            var appid = new AppIdentication("wx7fc05579394bd02c", "26f8f072c53e97d0033e3589e7de4e84");
            var request = new AccessTokenRequest(appid);
            var mock = new Mock<DefaultApiClient>();
            mock.Setup(d => d.DoExecute(request)).Returns("{\"access_token\":\"ACCESS_TOKEN\",\"expires_in\":7200}");

            var testobj = mock.Object.Execute(request);
            Console.WriteLine(testobj);
        }

        [Fact]
        public void ErrorMessageTest()
        {
            var appid = new AppIdentication("wx7fc05579394bd02c", "26f8f072c53e97d0033e3589e7de4e84");
            var request = new AccessTokenRequest(appid);
            var mock = new Mock<DefaultApiClient>();
            mock.Setup(d => d.DoExecute(request)).Returns("{\"errcode\":40013,\"errmsg\":\"invalid appid\"}");

            var testobj = mock.Object.Execute(request);
            Console.WriteLine(testobj);
        }
    }
}
