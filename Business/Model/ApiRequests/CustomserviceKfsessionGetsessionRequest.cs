using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class CustomserviceKfsessionGetsessionRequest : ApiGetNeedTokenRequest<CustomserviceKfsessionGetsessionResponse>
    {
        [JsonProperty("openid")]
        public string OpenId { get; set; }


        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/customservice/kfsession/getsession?access_token={0}&openid={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, OpenId);
        }
    }
}
