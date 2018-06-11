using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class AccessTokenCodeRequest : ApiRequest<AccessTokenCodeResponse>
    {
        public string Code { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }

        protected override string UrlFormat => "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";

        protected override bool NeedToken => false;

        internal override string Method => GETMETHOD;

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AppId, AppSecret, Code);
        }
    }
}
