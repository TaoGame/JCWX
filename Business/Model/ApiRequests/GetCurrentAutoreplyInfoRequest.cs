using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class GetCurrentAutoreplyInfoRequest : ApiRequest<GetCurrentAutoreplyInfoResponse>
    {
        internal override string Method
        {
            get { return GETMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/get_current_autoreply_info?access_token={0}"; }
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
            return String.Empty;
        }
    }
}
