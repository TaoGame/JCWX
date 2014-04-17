using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WX.Framework;
using WX.Model;

namespace WX.Demo.WebClasses
{
    public class UnSubScribeEventMessageHandler : TextMessageHandler
    {
        private static string unsubScribeMsg = "让您失望了，有什么好的建议您可以通过网站留言给我，我们将会改进，此微信关注公众平台快速框架的开发，详细内容可参考：http://inday.cnblogs.com";

        public UnSubScribeEventMessageHandler()
            : base(unsubScribeMsg)
        {
        }
    }
}
