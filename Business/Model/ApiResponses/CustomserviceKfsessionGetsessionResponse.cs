using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class CustomserviceKfsessionGetsessionResponse : ApiResponse
    {
        /// <summary>
        /// 正在接待的客服，为空表示没有人在接待
        /// </summary>
        [JsonProperty("kf_account")]
        public string KfAccount { get; set; }

        /// <summary>
        /// 会话接入的时间
        /// </summary>
        [JsonProperty("createtime")]
        public long Createtime { get; set; }
    }
}
