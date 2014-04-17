using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WX.Framework;
using WX.Model;

namespace WX.Demo.WebClasses
{
    public class CnblogsTextMessageHandler : IMessageHandler
    {
        private static string s_cnblogsMsg = 
            "HI，博客园的园友，欢迎来到JamesYing的微信世界，请关注我，http://inday.cnblogs.com";
        public ResponseMessage HandlerRequestMessage(MiddleMessage msg)
        {
            
            return new ResponseTextMessage(msg.RequestMessage)
            {
                CreateTime = DateTime.Now.Ticks,
                Content = s_cnblogsMsg
            };
        }
    }
}