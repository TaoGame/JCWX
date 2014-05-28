using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Model
{
    public sealed class MiddleMessage
    {
        public MiddleMessage(XElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element is null");

            Element = element;
            RequestMessage = GetRequestMessageByElement(element);
        }

        private RequestMessage GetRequestMessageByElement(XElement element)
        {
            MsgType msgType = (MsgType)Enum.Parse(typeof(MsgType), element.Element("MsgType").Value, true);
            switch (msgType)
            {
                case MsgType.Text:
                    return new RequestTextMessage(element);
                case MsgType.Video :
                    return new RequestVideoMessage(element);
                case MsgType.Voice:
                    return new RequestVoiceMessage(element);
                case MsgType.Image:
                    return new RequestImageMessage(element);
                case MsgType.Link:
                    return new RequestLinkMessage(element);
                case MsgType.Location:
                    return new RequestLocationMessage(element);
                case MsgType.Event:
                    return GetEventRequestMessage(element);
            }

            throw new ArgumentException("msgType is error");
        }

        private RequestMessage GetEventRequestMessage(XElement element)
        {
            var eventType = (Event)Enum.Parse(typeof(Event), element.Element("Event").Value, true);
            switch (eventType)
            {
                case Event.Unsubscribe:
                    return new RequestEventMessage(element);
                case Event.Location:
                    return new RequestLocationEventMessage(element);
                case Event.Click:
                    return new RequestClickEventMessage(element);
                case Event.Scan:
                    return new RequestQREventMessage(element);
                case Event.Subscribe:
                    return GetSubscribeRequestMessageForQR(element);
                case Event.View:
                    return new RequestViewEventMessage(element);
            }

            throw new ArgumentException("event type is error");
        }

        private RequestMessage GetSubscribeRequestMessageForQR(XElement element)
        {
            if (element.Element("Ticket") != null)
            {
                return new RequestQREventMessage(element);
            }

            return new RequestEventMessage(element);
        }

        public ResponseMessage ResponseMeesage { get; private set; }

        public RequestMessage RequestMessage { get; private set; }

        public XElement Element { get; private set; }
    }
}
