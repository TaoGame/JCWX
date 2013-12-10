using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WX.Model
{
    public class RequestLocationEventMessage : RequestEventMessage
    {
        public RequestLocationEventMessage(XElement xml)
            : base(xml)
        {
            Latitude = float.Parse(xml.Element("Latitude").Value);
            Longitude = float.Parse(xml.Element("Longitude").Value);
            Precision = float.Parse(xml.Element("Precision").Value);
        }

        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// 地理位置精度
        /// </summary>
        public float Precision { get; set; }
    }
}
