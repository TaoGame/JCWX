using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MerchantCategoryGetsubResponse : ApiResponse
    {
        [JsonProperty("cate_list")]
        public IEnumerable<Cate> CateList { get; set; }
    }
}
