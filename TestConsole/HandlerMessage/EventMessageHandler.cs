using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WX.Business;
using WX.Model;

namespace TestConsole.HandlerMessage
{
    public class EventMessageHandler : IMessageHandler
    {
        public ResponseMessage HandlerRequestMessage(XElement xml)
        {
            var request = new RequestEventMessage(xml);
            
            if (request.Event == Event.Subscribe)
            {
                return new ResponseTextMessage(request)
                {
                    Content = "new user subscribe"
                };
            }
            else if (request.Event == Event.Unsubscribe)
            {
                return new ResponseTextMessage(request)
                {
                    Content = "o no~~~ one user unsubscribe!"
                };
            }

            return null;
        }
    }
}
