using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantGroupGetallResponse : ApiResponse
    {
        [JsonProperty("groups_detail")]
        public IEnumerable<MerchantGroupDetail> GroupsDetail { get; set; }
    }
}
