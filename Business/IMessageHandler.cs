using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WX.Model;

namespace WX.Framework
{
    public interface IMessageHandler
    {
        ResponseMessage HandlerRequestMessage(MiddleMessage message);
    }
}
