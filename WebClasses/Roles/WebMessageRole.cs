using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WX.Framework;
using WX.Model;

namespace WX.Demo.WebClasses
{
    public class WebMessageRole : IMessageRole
    {
        public IMessageHandler MessageRole(MiddleMessage msg)
        {
            try
            {
                return new MsgTypeMessageRole().MessageRole(msg);
            }
            catch
            {
                return new DefaultMessageHandler();
            }
        }
    }
}