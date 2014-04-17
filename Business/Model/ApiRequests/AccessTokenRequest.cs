using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class AccessTokenRequest : ApiRequest<AccessTokenResponse>
    {
        public AccessTokenRequest(AppIdentication id)
        {
            AppIdentity = id;
        }

        public AppIdentication AppIdentity { get; set; }

        internal override string Method
        {
            get { return "GET"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AppIdentity.AppID, AppIdentity.AppSecret);
        }

        protected override bool NeedToken
        {
            get { return false; }
        }

        internal override void Validate()
        {
            if (AppIdentity == null)
            {
                throw new ArgumentNullException("AppIdentity");
            }
        }

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
