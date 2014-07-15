using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantOrderGetbyfilterResponse : ApiResponse
    {
        [JsonProperty("order_list")]
        public IEnumerable<OrderInfo> OrderList { get; set; }
    }
}
