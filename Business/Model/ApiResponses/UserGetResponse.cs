using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class UserGetResponse : ApiResponse
    {
        public int Total { get; set; }

        public int Count { get; set; }

        public UserGetData Data { get; set; }

        [JsonProperty("next_openid")]
        public string NextOpenId { get; set; }
    }

    public class UserGetData
    {
        [JsonProperty("openid")]
        public string[] OpenIds { get; set; }
    }
}
