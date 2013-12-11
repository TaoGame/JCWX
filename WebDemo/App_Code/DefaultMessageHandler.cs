using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WX.Business;
using WX.Model;

namespace WebDemo.App_Code
{
    public class DefaultMessageHandler : IMessageHandler
    {
        private static string s_defaultMsg = "对不起，亲，我还无法了解您的需求，我会不断改进的！";

        public ResponseMessage HandlerRequestMessage(XElement xml)
        {
            var fromUserName = xml.Element("ToUserName").Value;
            var toUserName = xml.Element("FromUserName").Value;
            return new ResponseTextMessage
            {
                FromUserName = fromUserName,
                ToUserName = toUserName,
                CreateTime = DateTime.Now.Ticks,
                Content = s_defaultMsg
            };
        }
    }
}