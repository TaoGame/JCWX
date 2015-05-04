using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Model.Request
{
    /// <summary>
    /// 小视频消息
    /// V4.1版本增加
    /// At 2015-04-01
    /// </summary>
    public class RequestShortVideoMessage : RequestMessage
    {
        public RequestShortVideoMessage(XElement xml)
            : base(xml)
        {
            this.MediaId = xml.Element("MediaId").Value;
            this.ThumbMediaId = xml.Element("ThumbMediaId").Value;
        }

        public override MsgType MsgType
        {
            get { return Model.MsgType.ShortVideo; }
        }

        public string MediaId { get; set; }

        public string ThumbMediaId { get; set; }
    }
}
