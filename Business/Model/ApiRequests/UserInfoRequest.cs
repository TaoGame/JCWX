using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class UserInfoRequest : ApiRequest<UserInfoResponse>
    {
        public string OpenId { get; set; }

        public string Lang { get; set; }

        internal override string Method
        {
            get { return "GET"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang={2}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, OpenId, Lang);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
