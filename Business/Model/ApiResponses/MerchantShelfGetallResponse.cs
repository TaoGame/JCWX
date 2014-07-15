using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantShelfGetallResponse : ApiResponse
    {
        [JsonProperty("shelves")]
        public IEnumerable<ShelfInfo> Shelves { get; set; }
    }
}
