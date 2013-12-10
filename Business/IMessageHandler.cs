using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WX.Model;

namespace WX.Business
{
    public interface IMessageHandler
    {
        ResponseMessage HandlerRequestMessage(XElement xml);
    }
}
