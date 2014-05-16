using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Framework.OAuth;
using Xunit;

namespace FrameworkCoreTest
{
    public class OAuthManagerTest
    {
        [Fact]
        public void BuildOAuthUrlTest()
        {
            var oauth = new OAuthHelper("wx7fc05579394bd02c");
            Console.WriteLine(oauth.BuildOAuthUrl("http://wx.taogame.com/OAuth2Demo.aspx", WX.Model.OAuthScope.Base, ""));
        }
    }
}
