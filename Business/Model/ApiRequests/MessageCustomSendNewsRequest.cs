using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    public class MessageCustomSendNewsRequest : MessageCustomSendRequest
    {
        public override string MsgType
        {
            get { return "news"; }
        }

        [JsonProperty("news")]
        public NewsMessage News { get; set; }
    }
}
