using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WX.Framework;
using WX.Model;

namespace WX.Demo.WebClasses
{
    public class DefaultMessageHandler : IMessageHandler
    {
        private static string s_defaultMsg = "对不起，亲，我还无法了解您的需求，我会不断改进的！";

        public ResponseMessage HandlerRequestMessage(MiddleMessage msg)
        {
            return new ResponseTextMessage(msg.RequestMessage)
            {
                CreateTime = DateTime.Now.Ticks,
                Content = s_defaultMsg
            };
        }
    }
}