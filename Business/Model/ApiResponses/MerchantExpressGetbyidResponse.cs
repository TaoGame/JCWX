using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantExpressGetbyidResponse : ApiResponse
    {
        [JsonProperty("template_info")]
        public DeliveryTemplate TemplateInfo { get; set; }
    }
}
