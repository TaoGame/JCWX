using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantGetbystatusResponse : ApiResponse
    {
        [JsonProperty("products_info")]
        public IEnumerable<ProductInfo> ProductInfos { get; set; }
    }
}
