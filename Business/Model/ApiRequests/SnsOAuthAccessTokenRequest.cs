using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class SnsOAuthAccessTokenRequest : ApiRequest<SnsOAuthAccessTokenResponse>
    {
        public string AppID { get; set; }

        public string AppSecret { get; set; }

        public string Code { get; set; }

        internal override string Method
        {
            get { return "GET"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AppID, AppSecret, Code);
        }

        protected override bool NeedToken
        {
            get { return false; }
        }

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
