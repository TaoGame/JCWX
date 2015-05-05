using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    /// <summary>
    /// 新增永久图文素材 Response
    /// </summary>
    public class MaterialAddNewsResponse : ApiResponse
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
