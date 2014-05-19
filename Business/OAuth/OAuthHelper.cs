using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model;

namespace WX.OAuth
{
    public class OAuthHelper
    {
        private String AppID { get; set; }

        public OAuthHelper(string appId)
        {
            AppID = appId;
        }

        private static string s_weixin_oauth_format_url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_{2}&state={3}#wechat_redirect";

        public string BuildOAuthUrl(string redirectUrl, OAuthScope scope, string state)
        {
            return String.Format(s_weixin_oauth_format_url,
                AppID, redirectUrl, scope.ToString().ToLower(), state);
        }
    }
}
