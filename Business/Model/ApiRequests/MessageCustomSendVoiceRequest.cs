using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    public class MessageCustomSendVoiceRequest : MessageCustomSendRequest
    {
        public override string MsgType
        {
            get { return "voice"; }
        }

        [JsonProperty("voice")]
        public VoiceMessage Voice { get; set; }
    }
}
