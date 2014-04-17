using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;

namespace FrameworkCoreTest
{
    public abstract class MockPostApiBaseTest<TRequest, TResponse> : BaseTest
        where TRequest : ApiRequest<TResponse>
        where TResponse : ApiResponse
    {

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

        public void MockSetup(bool errResult)
        {
            mock_client.Setup(d => d.DoExecute(Request)).Returns(GetReturnResult(errResult));
        }

        protected abstract string GetReturnResult(bool errResult);
    }
}
