using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MessageMassSendAllResponse : ApiResponse
    {
        [JsonProperty("msg_id")]
        public int MsgId { get; set; }
    }
}
