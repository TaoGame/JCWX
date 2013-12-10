using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WX.Business;
using WX.Model;

namespace TestConsole.HandlerMessage
{
    public class TextMessageHander : IMessageHandler
    {
        public ResponseMessage HandlerRequestMessage(XElement xml)
        {
            var request = new RequestTextMessage(xml);
            if (request.Content.IndexOf("info") > -1)
            {
                return new ResponseTextMessage(request)
                {
                    Content = "this message has keyword:info"
                };
            }
            else
            {
                return new ResponseTextMessage(request)
                {
                    Content = "this message has not keyword"
                };
            }
        }
    }
}
