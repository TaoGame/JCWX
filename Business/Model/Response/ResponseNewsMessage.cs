using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WX.Model
{
    [XmlRoot("xml")]
    public class ResponseNewsMessage : ResponseMessage
    {
        public ResponseNewsMessage() { }
        public ResponseNewsMessage(RequestMessage request)
            : base(request)
        {
        }
        public override MsgType MsgType
        {
            get { return Model.MsgType.News; }
        }

        public int ArticleCount { get; set; }

        [XmlArrayItem("item")]
        public List<ArticleMessage> Articles { get; set; }
    }
}
