using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WX.Framework;
using WX.Model;

namespace WX.Demo.WebClasses
{
    public class SubScribeEventMessageHandler : TextMessageHandler
    {
        private static string subScribeMsg = "欢迎您关注本微信，此微信关注公众平台快速框架的开发，详细内容可参考：http://inday.cnblogs.com";

        public SubScribeEventMessageHandler()
            : base(subScribeMsg)
        {
        }
    }
}
