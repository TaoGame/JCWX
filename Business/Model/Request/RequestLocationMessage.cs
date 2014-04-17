using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Model
{
    public class RequestLocationMessage : RequestMessage
    {
        public RequestLocationMessage(XElement xml)
            : base(xml)
        {
            this.Location_X = float.Parse(xml.Element("Location_X").Value);
            this.Location_Y = float.Parse(xml.Element("Location_Y").Value);
            this.Scale = int.Parse(xml.Element("Scale").Value);
            this.Label = xml.Element("Label").Value;
        }

        public override MsgType MsgType
        {
            get { return Model.MsgType.Location; }
        }

        public float Location_X { get; set; }

        public float Location_Y { get; set; }

        public int Scale { get; set; }

        public string Label { get; set; }
    }
}
