using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class CustomserviceKfsessionCloseRequest : ApiRequest<CustomserviceKfsessionCloseResponse>
    {
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("kf_account")]
        public string KfAccount { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        internal override string Method
        {
            get { return POSTMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/customservice/kfsession/close?access_token={0}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
