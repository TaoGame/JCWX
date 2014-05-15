using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WX.Demo.WebClasses.Handlers;
using WX.Demo.WebClasses.Roles;
using WX.Framework;
using WX.Model;

namespace WX.Demo.WebClasses
{
    public class MsgTypeMessageRole : IMessageRole
    {
        public IMessageHandler MessageRole(MiddleMessage msg)
        {
            switch (msg.RequestMessage.MsgType)
            {
                case MsgType.Text:
                    return new TextMessageRole().MessageRole(msg);
                case MsgType.Event:
                    return new EventMessageRole().MessageRole(msg);
                case MsgType.Voice:
                    return new VoiceMessageRole().MessageRole(msg);
                default:
                    return new DefaultMessageHandler();
            }
        }
    }
}