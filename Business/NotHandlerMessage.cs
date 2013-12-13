using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WX.Model;

namespace WX.Business
{
    public class NotHandlerMessage : IMessageHandler
    {
        public ResponseMessage HandlerRequestMessage(MiddleMessage message)
        {
            return null;
        }
    }
}
