using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.OAuth;
using Xunit;

namespace FrameworkCoreTest
{
    public class OAuthManagerTest
    {
        [Fact]
        public void BuildOAuthUrlScopeBaseTest()
        {
            var oauth = new OAuthHelper("wx7fc05579394bd02c");
            Console.WriteLine(oauth.BuildOAuthUrl("http://wx.taogame.com/OAuth2Demo.aspx", WX.Model.OAuthScope.Base, ""));
        }

        [Fact]
        public void BuildOAuthUrlScopeUserInfoTest()
        {
            var oauth = new OAuthHelper("wx7fc05579394bd02c");
            Console.WriteLine(oauth.BuildOAuthUrl("http://wx.taogame.com/OAuth2Demo.aspx", WX.Model.OAuthScope.UserInfo, "123123"));
        }
    }
}
