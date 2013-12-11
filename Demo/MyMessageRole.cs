using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TestConsole.HandlerMessage;
using WX.Business;
using WX.Model;

namespace TestConsole
{
    public class MyMessageRole : IMessageRole
    {
        public IMessageHandler MessageRole(XElement xml)
        {
            try
            {
                MsgType msgType = (MsgType)Enum.Parse(typeof(MsgType), xml.Element("MsgType").Value, true);
                return MessageHandlerByMsgType(msgType);
            }
            catch
            {
                return new NotHandlerMessage();
            }
        }

        private IMessageHandler MessageHandlerByMsgType(MsgType msgType)
        {
            IMessageHandler messageHandler = null;

            switch (msgType)
            {
                case MsgType.Text:
                    messageHandler = new NewsMessageHandler();
                    break;
                case MsgType.Event:
                    messageHandler = new EventMessageHandler();
                    break;
                default:
                    messageHandler = new NotHandlerMessage();
                    break;
            }

            return messageHandler;
        }
    }
}
