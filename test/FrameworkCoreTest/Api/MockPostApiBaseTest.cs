using Newtonsoft.Json;
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
    public abstract class MockPostApiBaseTest<TRequest, TResponse> : BaseTest
        where TRequest : ApiRequest<TResponse>
        where TResponse : ApiResponse
    {
        protected static string s_errmsg = "{\"errcode\":40007,\"errmsg\":\"invalid media_id\"}";
        protected static string s_successmsg = "{\"errcode\":0,\"errmsg\":\"success\"}";
        private TRequest m_request = null;
        public TRequest Request
        {
            get
            {
                if (m_request == null)
                {
                    m_request = InitRequestObject();
                }

                return m_request;
            }
        }

        protected abstract TRequest InitRequestObject();

        protected bool IsMock { get; set; }

        public void MockSetup(bool errResult)
        {
            mock_client.Setup(d => d.DoExecute(Request)).Returns(GetReturnResult(errResult));
        }

        protected abstract string GetReturnResult(bool errResult);

        public override string GetCurrentToken()
        {
            if (IsMock)
                return "123";
            return base.GetCurrentToken();
        }

        [Fact]
        public virtual void MockGetPostContent()
        {
            Console.WriteLine(Request.GetPostContent());
        }

        protected string JsonSerialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

    }
}
