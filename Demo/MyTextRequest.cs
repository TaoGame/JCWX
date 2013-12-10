using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WX.Business;
using WX.Model;
using System.Xml.Serialization;

namespace TestConsole
{
    //public class MyTextRequest : WXRequest
    //{
    //    public override ResponseMessage Dotit(Stream stream)
    //    {
    //        //var xs = new XmlSerializer(typeof(RequestTextMessage));
    //        var req = RequestMessage.Deserializ<RequestTextMessage>(stream);
    //        if (req.Content.IndexOf("request") > -1)
    //        {
    //            return new ResponseTextMessage
    //            {
    //                FromUserName = "sh_bus",
    //                ToUserName = "jamesying1",
    //                CreateTime = req.CreateTime,
    //                Content = "you request is save"
    //            };
    //        }

    //        throw new NotSupportedException();
    //    }
    //}
}
