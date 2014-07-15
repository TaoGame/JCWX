using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantShelfUpdatestatusResponse : ApiResponse
    {
        [JsonProperty("shelf_url")]
        public string ShelfUrl { get; set; }
    }
}
