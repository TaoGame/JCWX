using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Business
{
    public interface IMessageRole
    {
        IMessageHandler MessageRole(XElement xml);
    }
}
