using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WX.Business;
using WX.Model;

namespace WebDemo.App_Code
{
    public class EventMessageRole : IMessageRole
    {
        public IMessageHandler MessageRole(MiddleMessage msg)
        {
            var eventType = (Event)Enum.Parse(typeof(Event), msg.Element.Element("Event").Value, true);

            switch (eventType)
            {
                case Event.Subscribe:
                    return new SubScribeEventMessageHandler();
                case Event.Unsubscribe:
                    return new UnSubScribeEventMessageHandler();
            }

            return new DefaultMessageHandler();
        }
    }
}