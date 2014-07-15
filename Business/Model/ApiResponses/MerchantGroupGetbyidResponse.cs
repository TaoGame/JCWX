using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantGroupGetbyidResponse : ApiResponse
    {
        [JsonProperty("group_detail")]
        public MerchantGroupDetail GroupDetail { get; set; }
    }
}
