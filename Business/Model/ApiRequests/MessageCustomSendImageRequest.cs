using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    public class MessageCustomSendImageRequest : MessageCustomSendRequest
    {
        [JsonProperty("image")]
        public ImageMessage Image { get; set; }

        public override string MsgType
        {
            get { return "image"; }
        }
    }
}
