using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WX.Business;
using WX.Model;

namespace WebDemo.App_Code
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