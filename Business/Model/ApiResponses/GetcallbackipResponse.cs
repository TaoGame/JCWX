using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class GetcallbackipResponse : ApiResponse
    {
        /// <summary>
        /// 微信服务器IP地址列表
        /// </summary>
        [JsonProperty("ip_list")]
        public IEnumerable<string> IPList { get; set; }
    }
}
