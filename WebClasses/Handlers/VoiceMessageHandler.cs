using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Framework;
using WX.Model;

namespace WX.Demo.WebClasses.Handlers
{
    public class VoiceMessageHandler : IMessageHandler
    {
        public ResponseMessage HandlerRequestMessage(MiddleMessage message)
        {
            return new ResponseTextMessage(message.RequestMessage)
            {
                Content = "您声音真好听"
            };
        }
    }
}
