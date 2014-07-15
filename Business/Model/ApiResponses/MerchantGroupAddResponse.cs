using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantGroupAddResponse : ApiResponse
    {
        [JsonProperty("group_id")]
        public long GroupID { get; set; }
    }
}
