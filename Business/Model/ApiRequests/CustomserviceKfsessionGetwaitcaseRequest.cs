using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class CustomserviceKfsessionGetwaitcaseRequest : ApiGetNeedTokenRequest<CustomserviceKfsessionGetwaitcaseResponse>
    {
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/customservice/kfsession/getwaitcase?access_token={0}"; }
        }
    }
}
