using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantExpressGetallResponse : ApiResponse
    {
        [JsonProperty("templates_info")]
        public IEnumerable<DeliveryTemplate> Templates { get; set; }
    }
}
