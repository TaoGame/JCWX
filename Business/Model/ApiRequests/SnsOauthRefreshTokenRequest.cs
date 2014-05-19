using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class SnsOauthRefreshTokenRequest : ApiRequest<SnsOAuthAccessTokenResponse>
    {
        public string AppID { get; set; }

        public string RefreshToken { get; set; }

        internal override string Method
        {
            get { return "GET"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AppID, RefreshToken);
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
