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
    public class QrCreatedRequestTestTest : MockPostApiBaseTest<QrcodeCreateRequest, QrcodeCreateResponse>
    {
        protected override QrcodeCreateRequest InitRequestObject()
        {
            return new QrcodeCreateRequest
            {
                AccessToken = "123",
                ActionInfo = new ActionInfo
                {
                    Scene = new Scene
                    {
                        SceneId = 1234
                    }
                },
                ActionName = ActionName.QR_LIMIT_SCENE,
                ExpireSeconds = 1000
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            throw new NotImplementedException();
        }
    }
}
