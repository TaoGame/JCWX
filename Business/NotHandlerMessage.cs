using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model;

namespace WX.Business
{
    public class NotHandlerMessage : IMessageHandler
    {
        public ResponseMessage HandlerRequestMessage(System.Xml.Linq.XElement xml)
        {
            return null;
        }
    }
}
