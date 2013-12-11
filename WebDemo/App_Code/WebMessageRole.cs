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
        public IMessageHandler MessageRole(XElement xml)
        {
            try
            {
                var msgType = (MsgType)Enum.Parse(typeof(MsgType), xml.Element("MsgType").Value, true);

                return new MsgTypeMessageRole(msgType).MessageRole(xml);
            }
            catch
            {
                return new DefaultMessageHandler();
            }
        }
    }
}