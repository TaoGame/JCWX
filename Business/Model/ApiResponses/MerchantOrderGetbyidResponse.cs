using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantOrderGetbyidResponse : ApiResponse
    {
        [JsonProperty("order")]
        public OrderInfo Order { get; set; }
    }
}
