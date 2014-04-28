using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MediaUploadResponse : ApiResponse
    {
        [JsonProperty("type")]
        public MediaType MediaType { get; set; }

        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }
}
