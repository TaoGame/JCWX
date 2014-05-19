using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class SnsUserInfoResponse : ApiResponse
    {
        public string OpenId { get; set; }

        public string NickName { get; set; }

        public string Sex { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [JsonProperty("headimgurl")]
        public string HeadImageUrl { get; set; }

        [JsonProperty("privilege")]
        public IEnumerable<string> Privilege { get; set; }
    }
}
