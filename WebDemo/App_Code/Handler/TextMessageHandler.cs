using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WX.Business;
using WX.Model;

namespace WebDemo.App_Code
{
    public class TextMessageHandler : IMessageHandler
    {
        private string Message { get; set; }

        public TextMessageHandler(string msg)
        {
            Message = msg;
        }

        public ResponseMessage HandlerRequestMessage(MiddleMessage msg)
        {
            return new ResponseTextMessage(msg.RequestMessage)
            {
                CreateTime = DateTime.Now.Ticks,
                Content = Message
            };
        }
    }
}