using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WX.Model;

namespace WX.Business
{
    public interface IMessageRole
    {
        IMessageHandler MessageRole(MiddleMessage message);
    }
}
