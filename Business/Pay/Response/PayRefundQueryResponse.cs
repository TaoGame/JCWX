using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WX.Pay.Response
{
    [XmlRoot("xml")]
    public class PayRefundQueryResponse : PayRefundResponse
    {
        /// <summary>
        /// 退款渠道
        /// </summary>
        [XmlElement("refund_channel")]
        public string RefundChannel { get; set; }

        
    }
}
