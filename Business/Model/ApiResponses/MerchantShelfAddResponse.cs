using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantShelfAddResponse : ApiResponse
    {
        [JsonProperty("shelf_id")]
        public long ShelfID { get; set; }
    }
}
