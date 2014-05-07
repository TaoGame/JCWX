using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    public class MessageCustomSendVideoRequest : MessageCustomSendRequest
    {
        public override string MsgType
        {
            get { return "video"; }
        }

        [JsonProperty("video")]
        public VideoMessage Video { get; set; }
    }
}
