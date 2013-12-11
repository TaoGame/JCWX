using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WX.Business;
using WX.Model;

namespace WebDemo.App_Code
{
    public class MsgTypeMessageRole : IMessageRole
    {
        private MsgType MsgType { get; set; }

        public MsgTypeMessageRole(MsgType msgType)
        {
            this.MsgType = msgType;
        }

        public IMessageHandler MessageRole(XElement xml)
        {
            switch (MsgType)
            {
                case MsgType.Text:
                    return new TextMessageRole().MessageRole(xml);
                default:
                    return new DefaultMessageHandler();
            }
        }
    }
}